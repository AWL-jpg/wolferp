using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using wolffERPWebApplication.Models;

namespace wolffERPWebApplication.Areas.Vendors.Controllers
{
    /// <summary>
    /// Provides functionality for the Vendor pages.
    /// </summary>
    public class VendorController : Controller
    {
        /// <summary>
        /// Creates an instance of the context class, allowing for access to the database entities.
        /// </summary>
        private wolffDBContext db = new wolffDBContext();

        // GET: Vendor Create
        /// <summary>
        /// This create method creates a new vendor
        /// </summary>
        public ActionResult Create()
        {
            return View();
        }

        // GET: Vendor Read
        /// <summary>
        /// This method displays vendor information on page
        /// </summary>
        /// <returns>
        /// Returns information about the vendor
        /// </returns>
        public ActionResult VendorDisplay()
        {
            return View();
        }

        // GET: Vendor Update
        /// <summary>
        /// This method updates current selected vendor
        /// </summary>
        /// <returns>
        /// Returns updated Vendor
        /// </returns>
        public ActionResult Update()
        {
            return View();
        }

        // GET: Vendor Delete
        /// <summary>
        /// This method will delete the vendor. Or better said "hide" 
        /// </summary>
        /// <returns></returns>
        public ActionResult Delete()
        {
            return View();
        }
    }
}