using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TubeMine2021.Models;

namespace TubeMine2021.Controllers
{
    [Authorize(Roles ="Admins")]
    public class RolesController : Controller
    {
        // GET: Rolres
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View(db.Roles.ToList());
        }

        // GET: Rolres/Details/5
        public ActionResult Details(string id)
        {
            var role = db.Roles.Find(id);
            if (role==null)
            {
                HttpNotFound();
            }
            return View(role);
        }

        // GET: Rolres/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rolres/Create
        [HttpPost]
        public ActionResult Create(IdentityRole role)
        {
                if (ModelState.IsValid)
                {
                    db.Roles.Add(role);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                   return View(role);
              
                  }

        // GET: Rolres/Edit/5
        public ActionResult Edit(string id)
        {
            var role = db.Roles.Find(id);
            if (role == null)
            {
                HttpNotFound();
            }
            return View(role);
        }

        // POST: Rolres/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include ="Id,Name")] IdentityRole role)
        {
            if (ModelState.IsValid)
            {
                db.Entry(role).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            return View(role);
            
            
        }

        // GET: Rolres/Delete/5
        public ActionResult Delete(string id)
        {
            var role = db.Roles.Find(id);
            if (role == null)
            {
                HttpNotFound();
            }
            return View(role);
        }

        // POST: Rolres/Delete/5
        [HttpPost]
        public ActionResult Delete(IdentityRole role)
        {
            // TODO: Add delete logic here
            try
            {
                db.Roles.Remove(role);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return RedirectToAction("Index"); 
            }
               
           
    
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
