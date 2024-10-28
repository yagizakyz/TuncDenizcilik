using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TuncDenizci.Models;
using TuncDenizci.Repositories;

namespace TuncDenizci.Controllers
{
    public class ExpenseController : Controller
    {
        Context c = new Context();
        ExpenseResposityory expenseR = new ExpenseResposityory();
        MonthRespository monthR = new MonthRespository();
        public IActionResult Index()
        {
            var result = c.MonthTable.Sum(x => x.Amount);
            ViewBag.e = result;
            return View(monthR.TList());
        }

        [HttpGet]
        public IActionResult NewExpense()
        {
            List<SelectListItem> values = (from x in c.MonthTable.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.MonthName,
                                               Value = x.Id.ToString()
                                           }).ToList();
            ViewBag.mon = values;
            
            var user = HttpContext.Request.Cookies["user"];
            List<SelectListItem> lu = new List<SelectListItem>();
            lu.Add(new SelectListItem { Text = user, Value = user });
            ViewBag.lu = lu;

            List<SelectListItem> y = new List<SelectListItem>();
            y.Add(new SelectListItem { Text = Convert.ToString(2022), Value = Convert.ToString(2022) });
            ViewBag.y = y;

            return View();
        }

        [HttpPost]
        public IActionResult NewExpense(ExpenseClass p, MonthClass m)
        {
            expenseR.TAdd(p);

            var x = monthR.TGet(Convert.ToInt32(p.MonthID));
            x.Amount = m.Amount + x.Amount;
            monthR.TUpdate(x);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult GetExpense(int id)
        {
            List<SelectListItem> values = (from x in c.MonthTable.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.MonthName,
                                               Value = x.Id.ToString()
                                           }).ToList();
            ViewBag.mon = values;

            var user = HttpContext.Request.Cookies["user"];
            List<SelectListItem> lu = new List<SelectListItem>();
            lu.Add(new SelectListItem { Text = user, Value = user });
            ViewBag.lu = lu;

            List<SelectListItem> y = new List<SelectListItem>();
            y.Add(new SelectListItem { Text = Convert.ToString(2022), Value = Convert.ToString(2022) });
            ViewBag.y = y;

            var p = expenseR.TGet(id);
            ExpenseClass expense = new ExpenseClass()
            {
                Id = p.Id,
                Description = p.Description,
                Day = p.Day,
                MonthID = p.MonthID,
                Year = p.Year,
                Amount = p.Amount,
                LogUser = p.LogUser
            };
            return View(expense);
        }

        [HttpPost]
        public IActionResult UpdateExpense(ExpenseClass p, MonthClass m)
        {
            var z = expenseR.TGet(Convert.ToInt32(p.Id));
            var x = monthR.TGet(Convert.ToInt32(p.MonthID));

            if(z.Amount < p.Amount)
            {
                x.Amount = (p.Amount - z.Amount) + x.Amount;
            }
            else if(z.Amount > p.Amount)
            {
                x.Amount = x.Amount - (z.Amount - p.Amount);
            }
            monthR.TUpdate(x);

            z.Description = p.Description;
            z.Day = p.Day;
            z.MonthID = p.MonthID;
            z.Year = p.Year;
            z.Amount = p.Amount;
            z.LogUser = p.LogUser;
            expenseR.TUpdate(z);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DetailExpense(int id)
        {
            var expense = c.ExpenseTable.Where(x => x.MonthID == id).ToList();

            var m = c.MonthTable.Where(x => x.Id == id).Select(y => y.MonthName).FirstOrDefault();
            ViewBag.m = m;

            var result = c.MonthTable.Where(x => x.Id == id).Sum(z => z.Amount);
            ViewBag.e = result;

            var x = new MonthClass
            {
                ExpenseC = expense
            };
            return View(x);
        }

        public IActionResult ExportToExcel()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage())
            {
                List<ExpenseClass> s = c.ExpenseTable.Select(p => new ExpenseClass
                {
                    Description = p.Description,
                    Amount = p.Amount,
                    Day = p.Day,
                    //MonthID = p.MonthID
                    Month = p.Month,
                    Year = p.Year,
                }).ToList();

                ExcelWorksheet ew = package.Workbook.Worksheets.Add("Report");

                ew.Cells["A1"].Value = "Açıklama";
                ew.Cells["B1"].Value = "Tutar";
                ew.Cells["C1"].Value = "Gün";
                ew.Cells["D1"].Value = "Ay";
                ew.Cells["E1"].Value = "Yıl";

                int rowStart = 1;
                foreach (var item in s)
                {
                    rowStart++;
                    ew.Cells[string.Format("A{0}", rowStart)].Value = item.Description;
                    ew.Cells[string.Format("B{0}", rowStart)].Value = item.Amount;
                    ew.Cells[string.Format("C{0}", rowStart)].Value = item.Day;
                    //ew.Cells[string.Format("D{0}", rowStart)].Value = item.MonthID;
                    ew.Cells[string.Format("D{0}", rowStart)].Value = item.Month.MonthName;
                    ew.Cells[string.Format("E{0}", rowStart)].Value = item.Year;
                }

                ew.Cells["A:AZ"].AutoFitColumns();
                Response.Clear();
                var excelData = package.GetAsByteArray();
                var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                var fileName = "Gider.xlsx";
                return File(excelData, contentType, fileName);
            }
        }
    }
}
