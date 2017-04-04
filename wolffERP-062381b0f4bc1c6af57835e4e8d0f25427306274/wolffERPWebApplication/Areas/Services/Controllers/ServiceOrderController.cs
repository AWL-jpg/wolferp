using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using wolffERPWebApplication.Models;
using PagedList;

namespace wolffERPWebApplication.Areas.Services.Controllers
{
    public class ServiceOrderController : Controller
    {
        private wolffDBContext db = new wolffDBContext();

        // GET: Services/ServiceOrder
        /// <summary>Gets the Index View, and sets the ViewData for the partial view 'ServiceOrders'.</summary>
        public ActionResult Index(int? page)
        {
            ViewData["ServiceOrdersTable"] = db.ServiceOrders.ToList();//.ToPagedList(page ?? 1, 3);
            ViewData["VendorList"] = db.Vendors.ToList();
            ViewData["CourierList"] = db.Couriers.ToList();
            return View();
        }

        // GET: Services/ServiceOrder/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Services/ServiceOrder/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Services/ServiceOrder/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {

            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Services/ServiceOrder/Edit/5
        /// <summary>Gets the Edit View, and passes a Service Order for it to display.</summary>
        public ActionResult Edit(int id)
        {
            ServiceOrder serviceOrder = db.ServiceOrders.Find(id);
            if (serviceOrder == null)
            {
                return HttpNotFound();
            }

            ViewData["VendorList"] = db.Vendors.ToList();
            ViewData["CourierList"] = db.Couriers.ToList();
            return View(serviceOrder);
        }

        // POST: Services/ServiceOrder/Edit/5
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

        // GET: Services/ServiceOrder/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Services/ServiceOrder/Delete/5
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
    }
}
