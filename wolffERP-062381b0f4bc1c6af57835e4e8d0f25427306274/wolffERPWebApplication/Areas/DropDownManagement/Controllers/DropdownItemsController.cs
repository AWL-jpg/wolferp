using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using wolffERPWebApplication.Models;

namespace wolffERPWebApplication.Areas.DropDownManagement.Controllers
{
    public class DropdownItemsController : Controller
    {
        private wolffDBContext db = new wolffDBContext();

        // GET: DropDownManagement/DropdownItems
        public ActionResult Index()
        {
            var dropdownItems = db.DropdownItems.Include(d => d.DropdownType);
            return View(dropdownItems.ToList());
        }

        // GET: DropDownManagement/DropdownItems/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DropdownItem dropdownItem = db.DropdownItems.Find(id);
            if (dropdownItem == null)
            {
                return HttpNotFound();
            }
            return View(dropdownItem);
        }

        // GET: DropDownManagement/DropdownItems/Create
        public ActionResult Create()
        {
            ViewBag.DropdownTypeId = new SelectList(db.DropdownTypes, "DropdownTypeId", "DropdownName");
            return View();
        }

        // POST: DropDownManagement/DropdownItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DropdownItemId,DropdownValue,Hidden,DropdownTypeId")] DropdownItem dropdownItem)
        {
            if (ModelState.IsValid)
            {
                db.DropdownItems.Add(dropdownItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DropdownTypeId = new SelectList(db.DropdownTypes, "DropdownTypeId", "DropdownName", dropdownItem.DropdownTypeId);
            return View(dropdownItem);
        }

        // GET: DropDownManagement/DropdownItems/Edit/5
        public ActionResult Edit(decimal id =0)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DropdownItem dropdownItem = db.DropdownItems.Find(id);
            if (dropdownItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.DropdownTypeId = new SelectList(db.DropdownTypes, "DropdownTypeId", "DropdownName", dropdownItem.DropdownTypeId);
            return View(dropdownItem);
        }

        // POST: DropDownManagement/DropdownItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DropdownItemId,DropdownValue,Hidden,DropdownTypeId")] DropdownItem dropdownItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dropdownItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DropdownTypeId = new SelectList(db.DropdownTypes, "DropdownTypeId", "DropdownName", dropdownItem.DropdownTypeId);
            return View(dropdownItem);
        }

        // GET: DropDownManagement/DropdownItems/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DropdownItem dropdownItem = db.DropdownItems.Find(id);
            if (dropdownItem == null)
            {
                return HttpNotFound();
            }
            return View(dropdownItem);
        }

        // POST: DropDownManagement/DropdownItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            DropdownItem dropdownItem = db.DropdownItems.Find(id);
            db.DropdownItems.Remove(dropdownItem);
            db.SaveChanges();
            return RedirectToAction("Index");
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
