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

            FussballSpieler p1 = new FussballSpieler(1, "Shidoski", "Klaus", DateTime.Parse("01-01-1993"), "Stürmer", 23, anzahlJahre: 12);
            FussballSpieler p2 = new FussballSpieler(2, "Johnsons", "Dennis", DateTime.Parse("01-01-1993"), "Stürmer", 25);
            FussballSpieler p4 = new FussballSpieler(3, "Redgrave", "Vergil", DateTime.Parse("01-01-1993"), "Stürmer", 857);
            FussballSpieler p5 = new FussballSpieler(4, "Redgrave", "Dante", DateTime.Parse("01-01-1993"), "Stürmer", 900, anzahlJahre: 3);
            FussballSpieler p6 = new FussballSpieler(5, "Son", "Goku", DateTime.Parse("01-01-1993"), "Stürmer", 1010, anzahlJahre: 5);
            Trainer t1 = new Trainer(6, "Taylor", "Tom", DateTime.Parse("01-01-1993"), 23);

            HandballSpieler h1 = new HandballSpieler(7, "Ball", "Bernd", DateTime.Parse("01-01-1993"), "Verteidiger", 3);
            HandballSpieler h3 = new HandballSpieler(8, "Potter", "Harry", DateTime.Parse("01-01-1993"), "Stürmer", 25, anzahlJahre: 2);
            HandballSpieler h2 = new HandballSpieler(9, "Dohnson", "Henry", DateTime.Parse("01-01-1993"), "Stürmer", 16);
            HandballSpieler h4 = new HandballSpieler(10, "Hamper", "Holly", DateTime.Parse("01-01-1993"), "Mittelfeld", 17);

            TennisSpieler ts1 = new TennisSpieler(11, "Federer", "Roger", DateTime.Parse("01-01-1993"), 95, anzahlJahre: 18, gewonneneSpiele: 98);

            Mannschaft m = new Mannschaft("Azeroth SV", "Fussball", new List<Person>() { p1, p2 }, 23, 12, 2, 150, 14);

            Verwalter.Personen = new List<Person>() { p1, p2, p4, p5, p6, t1, h1, h2, h3, h4, ts1 };
            Verwalter.Mannschaften.Add(m);
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