using System.Web.Mvc;

namespace iCafe.Web.Areas.App
{
    public class AppAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "App";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "App_default",
                "App/{controller}/{action}/{id}",
                new {controller = "Dashboard", action = "Index", id = UrlParameter.Optional }
            );//.DataTokens.Add("area", "App");
        }
    }
}
