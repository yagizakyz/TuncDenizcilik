using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TuncDenizci.Models;
using TuncDenizci.Repositories;
using X.PagedList;

namespace TuncDenizci.Controllers
{
    public class IstanbulController : Controller
    {
        [Obsolete]
        private IHostingEnvironment Environment;
        private IConfiguration Configuration;

        [Obsolete]
        public IstanbulController(IHostingEnvironment _environment, IConfiguration _configuration)
        {
            Environment = _environment;
            Configuration = _configuration;
        }

        Context c = new Context();
        IstanbulRespository istanbulR = new IstanbulRespository();
        public IActionResult Index(string date, string pl, int page = 1)
        {
            var v = c.IstanbulTable.OrderBy(x => x.Date1).ToList();

            var s = from x in c.IstanbulTable select x;
            if (!string.IsNullOrEmpty(pl) || !string.IsNullOrEmpty(date))
            {
                s = s.Where(p => p.Plate.StartsWith(pl) || p.Date1.StartsWith(date));
                return View(s.ToList().ToPagedList(page, 75));
            }
            return View(v.ToList().ToPagedList(page, 75));
        }

        public IActionResult AcceptedIstanbul(IstanbulClass p)
        {
            var user = HttpContext.Request.Cookies["user"];
            var x = istanbulR.TGet(p.Id);
            x.Id = p.Id;
            x.Accepteds = true;
            x.LogUser = user;
            istanbulR.TUpdate(x);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult NewIstanbul()
        {
            return View();
        }

        [HttpPost]
        [Obsolete]
        public IActionResult NewIstanbul(IFormFile postedFile)
        {
            if (postedFile != null)
            {
                //Create a Folder.
                string path = Path.Combine(this.Environment.WebRootPath, "Uploads");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                //Save the uploaded Excel file.
                string fileName = Path.GetFileName(postedFile.FileName);
                string filePath = Path.Combine(path, fileName);
                using (FileStream stream = new FileStream(filePath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }
                

                //Read the connection string for the Excel file.
                string conString = this.Configuration.GetConnectionString("ExcelConString");
                DataTable dt = new DataTable();
                conString = string.Format(conString, filePath);

                using (OleDbConnection connExcel = new OleDbConnection(conString))
                {
                    using (OleDbCommand cmdExcel = new OleDbCommand())
                    {
                        using (OleDbDataAdapter odaExcel = new OleDbDataAdapter())
                        {
                            cmdExcel.Connection = connExcel;

                            //Get the name of First Sheet.
                            connExcel.Open();
                            DataTable dtExcelSchema;
                            dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                            string sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                            connExcel.Close();

                            //Read Data from First Sheet.
                            connExcel.Open();
                            cmdExcel.CommandText = "SELECT * From [" + sheetName + "]";
                            odaExcel.SelectCommand = cmdExcel;
                            odaExcel.Fill(dt);
                            connExcel.Close();
                        }
                    }
                }

                //Insert the Data read from the Excel file to Database Table.
                var user = HttpContext.Request.Cookies["user"];
                conString = this.Configuration.GetConnectionString("constr");
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                    {
                        //Set the database table name.
                        sqlBulkCopy.DestinationTableName = "dbo.IstanbulTable";

                        //[OPTIONAL]: Map the Excel columns with that of the database table.
                        sqlBulkCopy.ColumnMappings.Add(0, "NO");
                        sqlBulkCopy.ColumnMappings.Add(1, "Plate");
                        sqlBulkCopy.ColumnMappings.Add(2, "Tonaj1");
                        sqlBulkCopy.ColumnMappings.Add(3, "Tonaj2");
                        sqlBulkCopy.ColumnMappings.Add(4, "Net");
                        sqlBulkCopy.ColumnMappings.Add(5, "Date1");
                        sqlBulkCopy.ColumnMappings.Add(6, "Time1");
                        sqlBulkCopy.ColumnMappings.Add(7, "Date2");
                        sqlBulkCopy.ColumnMappings.Add(8, "Time2");
                        sqlBulkCopy.ColumnMappings.Add(9, "Material");
                        sqlBulkCopy.ColumnMappings.Add(10, "Location");
                        sqlBulkCopy.ColumnMappings.Add(11, "Number");
                        sqlBulkCopy.ColumnMappings.Add(12, "Destination");
                        sqlBulkCopy.ColumnMappings.Add(13, "IrsaliyeNo");
                        //sqlBulkCopy.ColumnMappings.Add(14, "Chauffeur");

                        con.Open();
                        sqlBulkCopy.WriteToServer(dt);
                        con.Close();
                    }
                }
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult GetIstanbul(int id)
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

            var p = istanbulR.TGet(id);
            IstanbulClass istanbul = new IstanbulClass()
            {
                Id = p.Id,
                NO = p.NO,
                Plate = p.Plate,
                Tonaj1 = p.Tonaj1,
                Tonaj2 = p.Tonaj2,
                Net = p.Net,
                Date1 = p.Date1,
                Time1 = p.Time1,
                Date2 = p.Date2,
                Time2 = p.Time2,
                Material = p.Material,
                Location = p.Location,
                Number = p.Number,
                Destination = p.Destination,
                IrsaliyeNo = p.IrsaliyeNo,
                Chauffeur = p.Chauffeur,
                LogUser = p.LogUser
            };
            return View(istanbul);
        }

        [HttpPost]
        public IActionResult UpdateIstanbul(IstanbulClass p)
        {
            var x = istanbulR.TGet(p.Id);
            x.Id = p.Id;
            x.NO = p.NO;
            x.Plate = p.Plate;
            x.Tonaj1 = p.Tonaj1;
            x.Tonaj2 = p.Tonaj2;
            x.Net = p.Net;
            x.Date1 = p.Date1;
            x.Time1 = p.Time1;
            x.Date2 = p.Date2;
            x.Time2 = p.Time2;
            x.Material = p.Material;
            x.Location = p.Location;
            x.Number = p.Number;
            x.Destination = p.Destination;
            x.IrsaliyeNo = p.IrsaliyeNo;
            x.Chauffeur = p.Chauffeur;
            x.LogUser = p.LogUser;
            istanbulR.TUpdate(x);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteIstanbul(IstanbulClass p)
        {
            var x = istanbulR.TGet(p.Id);
            istanbulR.TDelete(x);
            return RedirectToAction("Index");
        }

        public IActionResult ExportToExcel()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage())
            {
                List<IstanbulClass> s = c.IstanbulTable.Select(p => new IstanbulClass
                {
                    Accepteds = p.Accepteds,
                    NO = p.NO,
                    Plate = p.Plate,
                    Tonaj1 = p.Tonaj1,
                    Tonaj2 = p.Tonaj2,
                    Net = p.Net,
                    Date1 = p.Date1,
                    Time1 = p.Time1,
                    Date2 = p.Date2,
                    Time2 = p.Time2,
                    Material = p.Material,
                    Location = p.Location,
                    Number = p.Number,
                    Destination = p.Destination,
                    IrsaliyeNo = p.IrsaliyeNo,
                    Chauffeur = p.Chauffeur,
                }).ToList();

                ExcelWorksheet ew = package.Workbook.Worksheets.Add("Report");

                ew.Cells["A1"].Value = "ONAY";
                ew.Cells["B1"].Value = "TARTIM NO";
                ew.Cells["C1"].Value = "PLAKA";
                ew.Cells["D1"].Value = "TONAJ-1";
                ew.Cells["E1"].Value = "TONAJ-2";
                ew.Cells["F1"].Value = "NET";
                ew.Cells["G1"].Value = "TARİH-1";
                ew.Cells["H1"].Value = "SAAT-1";
                ew.Cells["I1"].Value = "TARİH-2";
                ew.Cells["J1"].Value = "SAAT-2";
                ew.Cells["K1"].Value = "MALZEME";
                ew.Cells["L1"].Value = "GELDİĞİ YER";
                ew.Cells["M1"].Value = "ADET";
                ew.Cells["N1"].Value = "GİTTİĞİ YER";
                ew.Cells["O1"].Value = "İRSALİYE NO";
                ew.Cells["P1"].Value = "ŞÖFÖR";

                int rowStart = 1;
                foreach (var item in s)
                {
                    rowStart++;
                    ew.Cells[string.Format("A{0}", rowStart)].Value = item.Accepteds;
                    ew.Cells[string.Format("B{0}", rowStart)].Value = item.NO;
                    ew.Cells[string.Format("C{0}", rowStart)].Value = item.Plate;
                    ew.Cells[string.Format("D{0}", rowStart)].Value = item.Tonaj1;
                    ew.Cells[string.Format("E{0}", rowStart)].Value = item.Tonaj2;
                    ew.Cells[string.Format("F{0}", rowStart)].Value = item.Net;
                    ew.Cells[string.Format("G{0}", rowStart)].Value = item.Date1;
                    ew.Cells[string.Format("H{0}", rowStart)].Value = item.Time1;
                    ew.Cells[string.Format("I{0}", rowStart)].Value = string.Format("{0:dd.MM.yyyy hh:mm:ss}", item.Date2);
                    ew.Cells[string.Format("J{0}", rowStart)].Value = item.Time2;
                    ew.Cells[string.Format("K{0}", rowStart)].Value = item.Material;
                    ew.Cells[string.Format("L{0}", rowStart)].Value = item.Location;
                    ew.Cells[string.Format("M{0}", rowStart)].Value = item.Number;
                    ew.Cells[string.Format("N{0}", rowStart)].Value = item.Destination;
                    ew.Cells[string.Format("O{0}", rowStart)].Value = item.IrsaliyeNo;
                    ew.Cells[string.Format("P{0}", rowStart)].Value = item.Chauffeur;
                }

                ew.Cells["A:AZ"].AutoFitColumns();
                Response.Clear();
                var excelData = package.GetAsByteArray();
                var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                var fileName = "İstanbul_Fatura.xlsx";
                return File(excelData, contentType, fileName);
            }
        }
    }
}
