using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using wolffERPWebApplication.Areas.Customers.Models;
using wolffERPWebApplication.Models;

namespace wolffERPWebApplication.Areas.Customers.Controllers
{
    public class CustomersController : Controller
    {
        private wolffDBContext db = new wolffDBContext();

        // GET: Customers/Customers
        public ActionResult Index()
        {
            return View(db.Customers.ToList());
        }

        // GET: Customers/Customers/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        /// POST: Customers/Customers/Create
        /// This method retrieves data from the CustomersViewModel and repackages the data
        /// into the Customer, Address, and CustomerAddress models to be saved into their
        /// respective tables in the database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerId,Email,PhoneNumber,Name,Notes,AddressId,City,Country,PostalCode,Province,Street1,Street2,AddressType")] CustomersViewModel customersViewModel)
        {
            if (ModelState.IsValid)
            {
                Customer customer = new Customer();
                customer.CustomerId = customersViewModel.CustomerId;
                customer.Email = customersViewModel.Email;
                customer.PhoneNumber = customersViewModel.PhoneNumber;
                customer.Name = customersViewModel.Name;
                customer.Notes = customersViewModel.Notes;

                Address address = new Address();
                address.AddressId = customersViewModel.AddressId;
                address.City = customersViewModel.City;
                address.Country = customersViewModel.Country;
                address.PostalCode = customersViewModel.PostalCode;
                address.Province = customersViewModel.Province;
                address.Street1 = customersViewModel.Street1;
                address.Street2 = customersViewModel.Street2;

                CustomerAddress customerAddress = new CustomerAddress();
                customerAddress.CustomerId = customersViewModel.CustomerId;
                customerAddress.AddressId = customersViewModel.AddressId;
                customerAddress.AddressType = customersViewModel.AddressType;

                db.Customers.Add(customer);
                db.Addresses.Add(address);
                db.CustomerAddresses.Add(customerAddress);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customersViewModel);
        }

        /// GET: Customers/Customers/Edit/5
        /// This method loads data from the customer table and populates a view with addresses
        /// associated with that particular customer
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }

            using (db)
            {
                var data = from item in db.CustomerAddresses
                           where item.CustomerId == id
                           select new CustomerAddressesViewModel()
                           {
                               CustomerId = item.CustomerId,
                               AddressId = item.AddressId,
                               City = item.Address.City,
                               Country = item.Address.Country,
                               PostalCode = item.Address.PostalCode,
                               Province = item.Address.Province,
                               Street1 = item.Address.Street1,
                               Street2 = item.Address.Street2,
                               AddressType = item.AddressType
                           };
                ViewData["CustomerAddresses"] = data.ToList();
            }
            return View(customer);
        }

        // POST: Customers/Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerId,Email,PhoneNumber,Name,Notes")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Customers/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
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
