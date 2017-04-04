using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace wolffERPWebApplication.Areas.Calibration.Controllers
{
    public class CalibrationController : Controller
    {
        // GET: Calibration/Calibration
        public ActionResult Index()
        {
            return View();
        }

        // GET: Calibration/Calibration/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Calibration/Calibration/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Calibration/Calibration/Create
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

        // GET: Calibration/Calibration/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Calibration/Calibration/Edit/5
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

        // GET: Calibration/Calibration/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Calibration/Calibration/Delete/5
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
