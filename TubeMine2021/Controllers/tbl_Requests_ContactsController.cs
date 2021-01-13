using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TubeMine2021.Models;

namespace TubeMine2021.Controllers
{
    [Authorize(Roles ="Admins")]
    public class tbl_Requests_ContactsController : Controller
    {
        private tubemineOPEEntities db = new tubemineOPEEntities();

        // GET: tbl_Requests_Contacts
       
        public ActionResult Index()
        {
            return View(db.tbl_Requests_Contacts.ToList().OrderByDescending(x=>x.RequestID));
        }
       
        // GET: tbl_Requests_Contacts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Requests_Contacts tbl_Requests_Contacts = db.tbl_Requests_Contacts.Find(id);
            if (tbl_Requests_Contacts == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Requests_Contacts);
        }

        // GET: tbl_Requests_Contacts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Requests_Contacts tbl_Requests_Contacts = db.tbl_Requests_Contacts.Find(id);
            if (tbl_Requests_Contacts == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Requests_Contacts);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Requests_Contacts tbl_Requests_Contacts = db.tbl_Requests_Contacts.Find(id);
            db.tbl_Requests_Contacts.Remove(tbl_Requests_Contacts);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
       
        // POST: tbl_Requests_Contacts/Delete/5


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
