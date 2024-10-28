using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TuncDenizci.Models;
using TuncDenizci.Repositories;
using X.PagedList;

namespace TuncDenizci.Controllers
{
    public class PersonController : Controller
    {
        Context c = new Context();
        PersonRespository personR = new PersonRespository();
        public IActionResult Index(int page = 1)
        {
            return View(personR.TList().ToPagedList(page, 50));
        }

        //[Authorize(Roles = "Full")]
        [HttpGet]
        public IActionResult NewPerson()
        {
            List<SelectListItem> roles = new List<SelectListItem>();
            roles.Add(new SelectListItem { Text = "Fatura", Value = "FTR" });
            roles.Add(new SelectListItem { Text = "Full", Value = "Full" });
            ViewBag.roles = roles;

            var user = HttpContext.Request.Cookies["user"];
            List<SelectListItem> lu = new List<SelectListItem>();
            lu.Add(new SelectListItem { Text = user, Value = user });
            ViewBag.lu = lu;
            return View();
        }

        [HttpPost]
        public IActionResult NewPerson(PersonClass p)
        {
            if (!ModelState.IsValid)
                return View("NewPerson");
            personR.TAdd(p);
            return RedirectToAction("Index");
        }

        //[Authorize(Roles = "Full")]
        public IActionResult DeletePerson(PersonClass p)
        {
            var user = HttpContext.Request.Cookies["user"];
            var x = personR.TGet(p.Id);
            if(x.Deletes == true)
            {
                x.Deletes = false;
                x.LogUser = user;
            }
            else
            {
                x.Deletes = true;
                x.LogUser = user;
            }
            personR.TUpdate(x);
            return RedirectToAction("Index");
        }
    }
}
