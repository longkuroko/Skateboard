using System.Web.Mvc;

namespace SkateBoard.Areas.Admin
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
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index",Controller="Products" ,id = UrlParameter.Optional },
                  new[] { "SkateBoard.Areas.Admin.Controllers" }
            );
        }
    }
}