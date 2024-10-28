using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TuncDenizci.Models;
using TuncDenizci.Repositories;

namespace TuncDenizci.Controllers
{
    public class FactoriesController : Controller
    {
        Context c = new Context();
        FactoriesRespository factoriesR = new FactoriesRespository();
        public IActionResult Index()
        {
            return View(factoriesR.TList());
        }

        [HttpGet]
        public IActionResult NewFactories()
        {
            var user = HttpContext.Request.Cookies["user"];
            List<SelectListItem> lu = new List<SelectListItem>();
            lu.Add(new SelectListItem { Text = user, Value = user });
            ViewBag.lu = lu;
            return View();
        }

        [HttpPost]
        public IActionResult NewFactories(FactoriesClass p)
        {
            factoriesR.TAdd(p);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteFactories(FactoriesClass p)
        {
            var user = HttpContext.Request.Cookies["user"];
            var x = factoriesR.TGet(p.Id);
            x.Deletes = true;
            x.LogUser = user;
            factoriesR.TUpdate(x);
            return RedirectToAction("Index");
        }

        public IActionResult DetailFactories(int id)
        {
            var ındustries = c.IndustryTable.Where(x => x.FactoriesID == id).ToList();

            var f = c.FactoriesTable.Where(x => x.Id == id).Select(y => y.IndustryName).FirstOrDefault();
            ViewBag.f = f;

            var x = new FactoriesClass
            {
                IndustryC = ındustries
            };
            return View(x);
        }
    }
}
