using System.Web;
using System.Web.Mvc;

namespace wolffERPWebApplication
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            // Add authorization on whole application
            filters.Add(new AuthorizeAttribute());
        }
    }
}
