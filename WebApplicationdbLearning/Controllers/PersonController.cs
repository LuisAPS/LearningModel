using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationdbLearning.Models;

namespace WebApplicationdbLearning.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index()
        {
            return View();
        }

        // GET: Person/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            List<SelectListItem> lst = new List<SelectListItem>();
            new Role().GetRoles().ForEach(x=> {
                lst.Add(new SelectListItem() { Text = x.RoleName, Value = x.RoleId.ToString() });
            });

            ViewBag.oRoles = lst;

            return View();
        }

        // POST: Person/Create
        [HttpPost]
        public ActionResult Create(Person person)
        {
            try
            {
                // TODO: Add insert logic here
                person.Create();

                return RedirectToAction("Index");             
            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Person/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Person/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult login()
        {
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        public ActionResult login(string sPerson, string sPassword)
        {
            List<Person> lstPerson = new Person().GetPeople();
            Person pSessionUser=null;

            bool userAuthenticated = false;

            foreach (var item in lstPerson)
            {
                if (item.Password.GUID==sPassword && item.UserName==sPerson)
                {
                    userAuthenticated = true;
                    pSessionUser= item;
                    break;                    
                }                
            }

            if (userAuthenticated)
            {                    
                var url = System.Web.HttpContext.Current.Request.Url.Authority + @"\Home\Index";
                userAuthenticated = true;
                var result = new { url = Url.Action("Index", "Home"), IsAuthenticated = userAuthenticated };
                Session["user"] = pSessionUser;

                return Json(result);
            }
            else
            {
                var result = new { url = string.Empty, IsAuthenticated = userAuthenticated };

                return Json(result);

            }
            
        }
    }
}
