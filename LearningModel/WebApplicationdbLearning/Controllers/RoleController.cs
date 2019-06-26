using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationdbLearning.Models;

namespace WebApplicationdbLearning.Controllers
{
    public class RoleController : Controller
    {
        // GET: Role
        public ActionResult Index()
        {
            List<Role> mRole = new Role().GetRoles();
            return View(mRole);
        }

        // GET: Role/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Role/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Role/Create
        [HttpPost]
        public ActionResult Create(Role role)
        {
            try
            {
                // TODO: Add insert logic here

                role.Create();


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Role/Edit/5
        public ActionResult Edit(int id)
        {
            Role mRole = new Role().GetRoles().Where(x => x.RoleId == id).FirstOrDefault();
            return View(mRole);
        }

        // POST: Role/Edit/5
        [HttpPost]
        public ActionResult Edit(int id,Role role)
        {
            try
            {
                // TODO: Add update logic here
                role.Update();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Role/Delete/5
        public ActionResult Delete(int id)
        {
            Role mRole = new Role().GetRoles().Where(x=>x.RoleId==id).FirstOrDefault();
            return View(mRole);

          
        }

        // POST: Role/Delete/5
        [HttpPost]
        public ActionResult Delete(int id,Role oRole)
        {
            try
            {
                
                // TODO: Add delete logic here
                (new Role() { RoleId=id}).Delete();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
