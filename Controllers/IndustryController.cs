using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
    public class IndustryController : Controller
    {
        Context c = new Context();
        IndustryRespository industryR = new IndustryRespository();
        public IActionResult Index(string plate, string sh, string ff, string date, int page = 1)
        {
            var v = c.IndustryTable.OrderBy(x => x.DateT).ToList();

            var s = from x in c.IndustryTable select x;
            if (!string.IsNullOrEmpty(plate) || !string.IsNullOrEmpty(sh) || !string.IsNullOrEmpty(ff) || !string.IsNullOrEmpty(date))
            {
                c.IndustryTable.OrderBy(x => x.DateT).ToList();
                s = s.Where(x => x.Plate.StartsWith(plate) || x.ShipName.StartsWith(sh) || x.Factories.IndustryName.StartsWith(ff) || x.DateT.StartsWith(date));
                return View(s.Include("Factories").ToList().ToPagedList(page, 75));
            }
            return View(s.Include("Factories").ToList().ToPagedList(page, 75));
        }

        [HttpGet]
        public IActionResult NewIndustry()
        {
            List<SelectListItem> values = (from x in c.FactoriesTable.Where(x => x.Deletes != true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.IndustryName,
                                               Value = x.Id.ToString()
                                           }).ToList();
            ViewBag.ind = values;

            var user = HttpContext.Request.Cookies["user"];
            List<SelectListItem> lu = new List<SelectListItem>();
            lu.Add(new SelectListItem { Text = user, Value = user });
            ViewBag.lu = lu;
            return View();
        }

        [HttpPost]
        public IActionResult NewIndustry(IndustryClass p)
        {
            industryR.TAdd(p);
            return RedirectToAction("NewIndustry");
        }

        [HttpGet]
        public IActionResult GetIndustry(int id)
        {
            List<SelectListItem> values = (from x in c.FactoriesTable.Where(x => x.Deletes != true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.IndustryName,
                                               Value = x.Id.ToString()
                                           }).ToList();
            ViewBag.ind = values;

            var user = HttpContext.Request.Cookies["user"];
            List<SelectListItem> lu = new List<SelectListItem>();
            lu.Add(new SelectListItem { Text = user, Value = user });
            ViewBag.lu = lu;

            var p = industryR.TGet(id);
            IndustryClass industry = new IndustryClass()
            {
                Id = p.Id,
                IrsaliyeNo = p.IrsaliyeNo,
                Plate = p.Plate,
                Tonaj = p.Tonaj,
                ShipName = p.ShipName,
                FactoriesID = p.FactoriesID,
                DateT = p.DateT,
                LogUser = p.LogUser
            };
            return View(industry);
        }

        [HttpPost]
        public IActionResult UpdateIndustry(IndustryClass p)
        {
            var x = industryR.TGet(p.Id);
            x.Id = p.Id;
            x.IrsaliyeNo = p.IrsaliyeNo;
            x.Plate = p.Plate;
            x.Tonaj = p.Tonaj;
            x.ShipName = p.ShipName;
            x.FactoriesID = p.FactoriesID;
            x.DateT = p.DateT;
            x.LogUser = p.LogUser;
            industryR.TUpdate(x);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteIndustry(IndustryClass p)
        {
            var x = industryR.TGet(p.Id);
            industryR.TDelete(x);
            return RedirectToAction("Index");
        }

        public IActionResult ExportToExcel()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage())
            {
                List<IndustryClass> s = c.IndustryTable.Select(p => new IndustryClass
                {
                    IrsaliyeNo = p.IrsaliyeNo,
                    Plate = p.Plate,
                    Tonaj = p.Tonaj,
                    ShipName = p.ShipName,
                    Factories = p.Factories,
                    DateT = p.DateT
                }).ToList();

                ExcelWorksheet ew = package.Workbook.Worksheets.Add("Report");

                ew.Cells["A1"].Value = "İrsaliye NO";
                ew.Cells["B1"].Value = "Plaka";
                ew.Cells["C1"].Value = "Tonaj";
                ew.Cells["D1"].Value = "Gemi Adı";
                ew.Cells["E1"].Value = "Firma Adı";
                ew.Cells["F1"].Value = "Tarih";

                int rowStart = 1;
                foreach (var item in s)
                {
                    rowStart++;
                    ew.Cells[string.Format("A{0}", rowStart)].Value = item.IrsaliyeNo;
                    ew.Cells[string.Format("B{0}", rowStart)].Value = item.Plate;
                    ew.Cells[string.Format("C{0}", rowStart)].Value = item.Tonaj;
                    ew.Cells[string.Format("D{0}", rowStart)].Value = item.ShipName;
                    ew.Cells[string.Format("E{0}", rowStart)].Value = item.Factories.IndustryName;
                    ew.Cells[string.Format("F{0}", rowStart)].Value = string.Format("{0:dd.MM.yyyy hh:mm:ss}", item.DateT);
                }

                ew.Cells["A:AZ"].AutoFitColumns();
                Response.Clear();
                var excelData = package.GetAsByteArray();
                var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                var fileName = "Fabrika_Fatura.xlsx";
                return File(excelData, contentType, fileName);
            }
        }
    }
}
