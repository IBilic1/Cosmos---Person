using MyCosmos.DAO;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MyCosmos
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            CosmosDbServiceProvider.Init().GetAwaiter().GetResult();
        }
    }
}
