using System.Web.Mvc;

namespace Homework.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {

            context.MapRoute(
            name: "MoneyAdmin",
            url: "skilltree/Admin/{action}/{yyyy}/{mm}",
            defaults: new
            {
                controller = "Money",
                yyyy = UrlParameter.Optional,
                mm = UrlParameter.Optional
            }
            );

            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}