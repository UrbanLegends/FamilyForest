using System.Web.Mvc;

namespace FamilyForest.Web.Areas.Share
{
    public class ShareAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Share";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Share_default",
                "Share/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
