using System.Web.Mvc;

namespace wolffERPWebApplication.Areas.DropDownManagement
{
    /// <summary>
    /// This method registers the containing folder as an "Area"
    /// </summary>
    public class DropDownManagementAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "DropDownManagement";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "DropDownManagement_default",
                "DropDownManagement/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}