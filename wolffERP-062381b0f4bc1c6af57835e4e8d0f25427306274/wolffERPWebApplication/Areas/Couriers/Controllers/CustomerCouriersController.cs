using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using wolffERPWebApplication.Models;

namespace wolffERPWebApplication.Areas.Couriers.Controllers
{
    public class CustomerCouriersController : Controller
    {
        private wolffDBContext db = new wolffDBContext();

        // GET: Couriers/CustomerCouriers
        public ActionResult Index()
        {
            var customerCouriers = db.CustomerCouriers.Include(c => c.Courier).Include(c => c.Customer);
            return View(customerCouriers.ToList());
        }

        // GET: Couriers/CustomerCouriers/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerCourier customerCourier = db.CustomerCouriers.Find(id);
            if (customerCourier == null)
            {
                return HttpNotFound();
            }
            return View(customerCourier);
        }

        // GET: Couriers/CustomerCouriers/Create
        public ActionResult Create()
        {
            ViewBag.CourierId = new SelectList(db.Couriers, "CourierId", "AccountNumber");
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Email");
            return View();
        }

        // POST: Couriers/CustomerCouriers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerId,CourierId,Preferred")] CustomerCourier customerCourier)
        {
            if (ModelState.IsValid)
            {
                db.CustomerCouriers.Add(customerCourier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourierId = new SelectList(db.Couriers, "CourierId", "AccountNumber", customerCourier.CourierId);
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Email", customerCourier.CustomerId);
            return View(customerCourier);
        }

        // GET: Couriers/CustomerCouriers/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerCourier customerCourier = db.CustomerCouriers.Find(id);
            if (customerCourier == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourierId = new SelectList(db.Couriers, "CourierId", "AccountNumber", customerCourier.CourierId);
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Email", customerCourier.CustomerId);
            return View(customerCourier);
        }

        // POST: Couriers/CustomerCouriers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerId,CourierId,Preferred")] CustomerCourier customerCourier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerCourier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourierId = new SelectList(db.Couriers, "CourierId", "AccountNumber", customerCourier.CourierId);
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Email", customerCourier.CustomerId);
            return View(customerCourier);
        }

        // GET: Couriers/CustomerCouriers/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerCourier customerCourier = db.CustomerCouriers.Find(id);
            if (customerCourier == null)
            {
                return HttpNotFound();
            }
            return View(customerCourier);
        }

        // POST: Couriers/CustomerCouriers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            CustomerCourier customerCourier = db.CustomerCouriers.Find(id);
            db.CustomerCouriers.Remove(customerCourier);
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
