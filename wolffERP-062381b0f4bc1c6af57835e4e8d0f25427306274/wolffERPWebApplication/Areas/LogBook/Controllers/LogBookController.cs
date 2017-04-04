using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using wolffERPWebApplication.Areas.LogBook.Models;
using wolffERPWebApplication.Models;

namespace wolffERPWebApplication.Areas.LogBook.Controllers
{
    /// <summary>
    /// Provides functionality for the LogBook pages.
    /// </summary>
    public class LogBookController : Controller
    {
        /// <summary>
        /// Creates an instance of the context class, allowing for access to the database entities.
        /// </summary>
        private wolffDBContext db = new wolffDBContext();


        /// <summary>
        /// GET: LogBook/LogBook
        /// Returns all LogBook items to be displayed on the index page.
        /// </summary>
        /*public ActionResult Index()
        {
            using (db)
            {
                var data = from soItem in db.ServiceOrderItems
                           select new LogBookItem()
                           {
                               ServiceOrderitemId = soItem.ServiceOrderitemId,
                               SerialNumber = soItem.SerialNumber,
                               ServiceOrderNumber = soItem.ServiceOrder.ServiceOrderNumber,
                               CalibrationCertificateNumber = soItem.ServiceCertificate.CalibrationCertificateNumber,
                               OxygenCertificateNumber = soItem.OxygenCertificate.OxygenCertificateNumber,
                               Name = soItem.ServiceOrder.Customer.Name,
                               Date = soItem.ServiceOrder.Date
                           };
                return View(data.ToList());
            }
        }*/

        /// <summary>
        /// GET: LogBook/LogBook
        /// Returns LogBook items based on a supplied search term and table column. Will return all LogBook
        /// items if no string is provided.
        /// </summary>
        public ActionResult Index(string propertyName, string searchString)
        {
            using(db)
            {
                var data = from soItem in db.ServiceOrderItems
                           select new LogBookItem()
                           {
                               ServiceOrderitemId = soItem.ServiceOrderitemId,
                               SerialNumber = soItem.SerialNumber,
                               ServiceOrderNumber = soItem.ServiceOrder.ServiceOrderNumber,
                               CalibrationCertificateNumber = soItem.ServiceCertificate.CalibrationCertificateNumber,
                               OxygenCertificateNumber = soItem.OxygenCertificate.OxygenCertificateNumber,
                               Name = soItem.ServiceOrder.Customer.Name,
                               Date = soItem.ServiceOrder.Date
                           };
                if(!String.IsNullOrEmpty(searchString))
                {
                    data = data.Where(term => term.SerialNumber.Contains(searchString)
                                      || term.ServiceOrderNumber.ToString().Contains(searchString)
                                      || term.CalibrationCertificateNumber.ToString().Contains(searchString)
                                      || term.OxygenCertificateNumber.ToString().Contains(searchString)
                                      || term.Name.Contains(searchString)
                                      || term.Date.ToString().Contains(searchString));
                }

                if(!String.IsNullOrEmpty(searchString) 
                    && !String.IsNullOrEmpty(propertyName))
                {
                    switch (propertyName)
                    { 
                        case "SerialNumber":
                            data = data.Where(term => term.SerialNumber.Contains(searchString));
                            break;
                        case "ServiceOrderNumber":
                            data = data.Where(term => term.ServiceOrderNumber.ToString().Contains(searchString));
                            break;
                        case "CalibrationCertificateNumber":
                            data = data.Where(term => term.CalibrationCertificateNumber.ToString().Contains(searchString));
                            break;
                        case "OxygenCertificateNumber":
                            data = data.Where(term => term.OxygenCertificateNumber.ToString().Contains(searchString));
                            break;
                        case "Name":
                            data = data.Where(term => term.Name.Contains(searchString));
                            break;
                        case "Date":
                            data = data.Where(term => term.Date.ToString().Contains(searchString));
                            break;
                    }
                }
                return View(data.ToList());
            }
        }
    }
}
