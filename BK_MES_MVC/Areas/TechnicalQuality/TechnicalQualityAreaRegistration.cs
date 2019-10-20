using System.Web.Mvc;

namespace BK_MES_MVC.Areas.TechnicalQuality
{
    public class TechnicalQualityAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "TechnicalQuality";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "TechnicalQuality_default",
                "TechnicalQuality/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}