using System.Web;
using System.Web.Mvc;

namespace Example_SSRS_Web_API_Integration
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}