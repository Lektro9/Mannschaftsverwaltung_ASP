using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace Mannschaftsverwaltung
{
    public class Global : HttpApplication
    {
        static private Controller _Verwalter;

        public static Controller Verwalter { get => _Verwalter; set => _Verwalter = value; }

        void Application_Start(object sender, EventArgs e)
        {
            // Code, der beim Anwendungsstart ausgeführt wird
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            RegisterCustomRoutes(RouteTable.Routes);
            Verwalter = new Controller();
            start(Verwalter.Sportarten);
        }
        void RegisterCustomRoutes(RouteCollection routes)
        {
            routes.MapPageRoute(
                "Personenverwaltung",
                "",
                "~/Views/Personenverwaltung.aspx"
            );
            routes.MapPageRoute(
                "Mannschaftsverwaltung",
                "Mannschaftsverwaltung",
                "~/Views/Mannschaftsverwaltung.aspx"
            );
            routes.MapPageRoute(
                "Tabellen",
                "Tabellen",
                "~/Views/Tabellen.aspx"
            );
            routes.MapPageRoute(
                "Spiele",
                "Spiele",
                "~/Views/Spiele.aspx"
            );
        }
        public void start(List<string> Sportarten)
        {
            for (int i = 0; i < Sportarten.Count; i++)
            {
                
            }
        }
    }
}