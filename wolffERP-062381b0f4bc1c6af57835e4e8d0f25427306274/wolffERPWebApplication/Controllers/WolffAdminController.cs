using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using wolffERPWebApplication.Models;

namespace wolffERPWebApplication.Controllers
{
    /// <summary>
    /// Provides functionality for the Admin page.
    /// </summary>
    
    //Added the Annotation to check for valid users
    [Authorize]
    public class WolffAdminController : Controller
    {
        /// <summary>
        /// GET: Admin Page
        /// Return Admin page if the role is Admin.
        /// </summary>
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ViewBag.Name = user.Name;

                ViewBag.displayMenu = "No";

                if (isAdminUser())
                {
                    ViewBag.displayMenu = "Yes";
                }
                return View();
            }
            else
            {
                ViewBag.Name = "Not Logged IN";
            }
            return View();
        }
        /// <summary>
        /// Return true if the LoggedIn User is Admin 
        /// </summary>
        public Boolean isAdminUser()
        {
            if (User.Identity.IsAuthenticated)
            { 
                /// <summary>
                /// Creates an instance of the context class, to get the role of Logged In User.
                /// </summary>
                var user = User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = UserManager.GetRoles(user.GetUserId());
                if (s[0].ToString() == "Admin")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
    }
}