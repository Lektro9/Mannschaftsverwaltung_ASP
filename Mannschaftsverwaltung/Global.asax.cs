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

            FussballSpieler p1 = new FussballSpieler("Shidoski", "Klaus", 15, "Stürmer", 23, anzahlJahre: 12);
            FussballSpieler p2 = new FussballSpieler("Johnsons", "Dennis", 15, "Stürmer", 25);
            FussballSpieler p4 = new FussballSpieler("Redgrave", "Vergil", 15, "Stürmer", 857);
            FussballSpieler p5 = new FussballSpieler("Redgrave", "Dante", 15, "Stürmer", 900, anzahlJahre: 3);
            FussballSpieler p6 = new FussballSpieler("Son", "Goku", 15, "Stürmer", 1010, anzahlJahre: 5);
            Trainer t1 = new Trainer("Taylor", "Tom", 84, 23);

            HandballSpieler h1 = new HandballSpieler("Ball", "Bernd", 12, "Verteidiger", 3);
            HandballSpieler h3 = new HandballSpieler("Potter", "Harry", 15, "Stürmer", 25, anzahlJahre: 2);
            HandballSpieler h2 = new HandballSpieler("Dohnson", "Henry", 15, "Stürmer", 16);
            HandballSpieler h4 = new HandballSpieler("Hamper", "Holly", 15, "Mittelfeld", 17);

            TennisSpieler ts1 = new TennisSpieler("Federer", "Roger", 15, 95, anzahlJahre: 18, gewonneneSpiele: 98);

            Verwalter.Personen = new List<Person>() { p1, p2, p4, p5, p6, t1, h1, h2, h3, h4, ts1 };
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
    }
}