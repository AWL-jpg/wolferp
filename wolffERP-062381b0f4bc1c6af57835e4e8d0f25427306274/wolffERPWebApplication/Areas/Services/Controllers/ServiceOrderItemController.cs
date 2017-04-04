using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using wolffERPWebApplication.Models;

namespace wolffERPWebApplication.Areas.Services.Controllers
{
    public class ServiceOrderItemController : Controller
    {
        private wolffDBContext db = new wolffDBContext();

        // GET: Services/ServiceOrderItem
        public ActionResult Index()
        {
            return View(db.ServiceOrderItems.ToList());
        }

        // GET: Services/ServiceOrderItem/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Services/ServiceOrderItem/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Services/ServiceOrderItem/Create
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

        // GET: Services/ServiceOrderItem/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Services/ServiceOrderItem/Edit/5
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

        // GET: Services/ServiceOrderItem/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Services/ServiceOrderItem/Delete/5
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
