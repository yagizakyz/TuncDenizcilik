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
using X.PagedList;

namespace TuncDenizci.Controllers
{
    public class PastExpenseController : Controller
    {
        // 2021 yılı giderleri
        Context c = new Context();
        Expense21Respository expense21R = new Expense21Respository();
        public IActionResult Index(int page = 1)
        {
            var result = c.Expense21Table.Sum(x => x.Amount);
            ViewBag.e = result;
            return View(expense21R.TList().ToPagedList(page, 75));
        }

        [HttpGet]
        public IActionResult NewPE()
        {
            List<SelectListItem> values = new List<SelectListItem>();
            values.Add(new SelectListItem { Text = "Ocak", Value = "Ocak" });
            values.Add(new SelectListItem { Text = "Şubat", Value = "Şubat" });
            values.Add(new SelectListItem { Text = "Mart", Value = "Mart" });
            values.Add(new SelectListItem { Text = "Nisan", Value = "Nisan" });
            values.Add(new SelectListItem { Text = "Mayıs", Value = "Mayıs" });
            values.Add(new SelectListItem { Text = "Haziran", Value = "Haziran" });
            values.Add(new SelectListItem { Text = "Temmuz", Value = "Temmuz" });
            values.Add(new SelectListItem { Text = "Ağustos", Value = "Ağustos" });
            values.Add(new SelectListItem { Text = "Eylül", Value = "Eylül" });
            values.Add(new SelectListItem { Text = "Ekim", Value = "Ekim" });
            values.Add(new SelectListItem { Text = "Kasım", Value = "Kasım" });
            values.Add(new SelectListItem { Text = "Aralık", Value = "Aralık" });
            ViewBag.mon = values;

            var user = HttpContext.Request.Cookies["user"];
            List<SelectListItem> lu = new List<SelectListItem>();
            lu.Add(new SelectListItem { Text = user, Value = user });
            ViewBag.lu = lu;

            List<SelectListItem> y = new List<SelectListItem>();
            y.Add(new SelectListItem { Text = Convert.ToString(2021), Value = Convert.ToString(2021) });
            ViewBag.y = y;

            return View();
        }

        [HttpPost]
        public IActionResult NewPE(Expense21Class p)
        {
            expense21R.TAdd(p);

            return RedirectToAction("Index");
        }

        public IActionResult ExportToExcel()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage())
            {
                List<Expense21Class> s = c.Expense21Table.Select(p => new Expense21Class
                {
                    Description = p.Description,
                    Amount = p.Amount,
                    Day = p.Day,
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
                    ew.Cells[string.Format("D{0}", rowStart)].Value = item.Month;
                    ew.Cells[string.Format("E{0}", rowStart)].Value = item.Year;
                }

                ew.Cells["A:AZ"].AutoFitColumns();
                Response.Clear();
                var excelData = package.GetAsByteArray();
                var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                var fileName = "2021Gider.xlsx";
                return File(excelData, contentType, fileName);
            }
        }

        public IActionResult DeleteExpense(Expense21Class p)
        {
            var id = expense21R.TGet(p.Id);
            expense21R.TDelete(id);
            return RedirectToAction("Index");
        }
    }
}
