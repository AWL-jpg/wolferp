using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using wolffERPWebApplication.Areas.Couriers.Models;
using wolffERPWebApplication.Models;

namespace wolffERPWebApplication.Areas.Couriers.Controllers
{
    public class CouriersController : Controller
    {
        private wolffDBContext db = new wolffDBContext();

        // GET: Couriers/Couriers
        public ActionResult Index()
        {
            return View(db.Couriers.ToList());
        }

        // GET: Couriers/Couriers/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Courier courier = db.Couriers.Find(id);
            if (courier == null)
            {
                return HttpNotFound();
            }
            return View(courier);
        }

        // GET: Couriers/Couriers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Couriers/Couriers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourierId,AccountNumber,PhoneNumber,Email,Name")] Courier courier)
        {
            if (ModelState.IsValid)
            {
                db.Couriers.Add(courier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(courier);
        }

        // GET: Couriers/Couriers/Edit/
        // The method loads customer data from customer table. 
        //It will display customers related with one courier
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Courier courier = db.Couriers.Find(id);
            if (courier == null)
            {
                return HttpNotFound();
            }
            using (db)
            {
                var data = from item in db.CustomerCouriers
                           where item.CourierId == id
                           select new CustomerCouriersViewModel()
                           {
                               CustomerId = item.CustomerId,
                               CourierId = item.CourierId,
                               Name = item.Customer.Name,
                               Email = item.Customer.Email,
                               PhoneNumber = item.Customer.PhoneNumber,
                               Preferred = item.Preferred
                           };
                ViewData["CustomerCouriers"] = data.ToList();
                return View(courier);
            }
        }
     

        // POST: Couriers/Couriers/Edit/ 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourierId,AccountNumber,PhoneNumber,Email,Name")] Courier courier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(courier);
        }

        // GET: Couriers/Couriers/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Courier courier = db.Couriers.Find(id);
            if (courier == null)
            {
                return HttpNotFound();
            }
            return View(courier);
        }

        // POST: Couriers/Couriers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            Courier courier = db.Couriers.Find(id);
            db.Couriers.Remove(courier);
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
