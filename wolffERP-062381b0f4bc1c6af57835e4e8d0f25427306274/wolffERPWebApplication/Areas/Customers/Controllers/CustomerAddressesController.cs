using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using wolffERPWebApplication.Models;

namespace wolffERPWebApplication.Areas.Customers.Controllers
{
    public class CustomerAddressesController : Controller
    {
        private wolffDBContext db = new wolffDBContext();

        // GET: Customers/CustomerAddresses
        public ActionResult Index()
        {
            var customerAddresses = db.CustomerAddresses.Include(c => c.Address).Include(c => c.Customer);
            return View(customerAddresses.ToList());
        }

        // GET: Customers/CustomerAddresses/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerAddress customerAddress = db.CustomerAddresses.Find(id);
            if (customerAddress == null)
            {
                return HttpNotFound();
            }
            return View(customerAddress);
        }

        // GET: Customers/CustomerAddresses/Create
        public ActionResult Create()
        {
            ViewBag.AddressId = new SelectList(db.Addresses, "AddressId", "City");
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Email");
            return View();
        }

        // POST: Customers/CustomerAddresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerId,AddressId,AddressType")] CustomerAddress customerAddress)
        {
            if (ModelState.IsValid)
            {
                db.CustomerAddresses.Add(customerAddress);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AddressId = new SelectList(db.Addresses, "AddressId", "City", customerAddress.AddressId);
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Email", customerAddress.CustomerId);
            return View(customerAddress);
        }

        // GET: Customers/CustomerAddresses/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerAddress customerAddress = db.CustomerAddresses.Find(id);
            if (customerAddress == null)
            {
                return HttpNotFound();
            }
            ViewBag.AddressId = new SelectList(db.Addresses, "AddressId", "City", customerAddress.AddressId);
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Email", customerAddress.CustomerId);
            return View(customerAddress);
        }

        // POST: Customers/CustomerAddresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerId,AddressId,AddressType")] CustomerAddress customerAddress)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerAddress).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AddressId = new SelectList(db.Addresses, "AddressId", "City", customerAddress.AddressId);
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Email", customerAddress.CustomerId);
            return View(customerAddress);
        }

        // GET: Customers/CustomerAddresses/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerAddress customerAddress = db.CustomerAddresses.Find(id);
            if (customerAddress == null)
            {
                return HttpNotFound();
            }
            return View(customerAddress);
        }

        // POST: Customers/CustomerAddresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            CustomerAddress customerAddress = db.CustomerAddresses.Find(id);
            db.CustomerAddresses.Remove(customerAddress);
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
