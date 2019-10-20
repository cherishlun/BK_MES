using System.Web;
using System.Web.Mvc;

namespace BK_MES_MVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //全局过滤器
            //filters.Add(new App_Code.UserAuthorize() { IsCheck = true });
        }
    }
}
