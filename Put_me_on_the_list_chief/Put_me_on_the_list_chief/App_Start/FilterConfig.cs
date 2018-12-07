using System.Web;
using System.Web.Mvc;

namespace Put_me_on_the_list_chief
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
