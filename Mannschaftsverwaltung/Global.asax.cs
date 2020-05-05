//Autor:        Kroll
//Datum:        21.04.2020
//Dateiname:    Global.asax.cs
//Beschreibung: Erstellen der Routen und des Verwalters


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

            FussballSpieler p1 = new FussballSpieler(1, "Shidoski", "Klaus", DateTime.Parse("01-01-1993"), "Stürmer", 23, anzahlJahre: 1, anzahlSpiele: 32, anzahlVereine: 2, gewonneneSpiele: 2);
            FussballSpieler p2 = new FussballSpieler(2, "Johnsons", "Dennis", DateTime.Parse("02-01-1993"), "Stürmer", 25, anzahlJahre: 6, anzahlSpiele: 567, anzahlVereine: 2, gewonneneSpiele: 234);
            FussballSpieler p4 = new FussballSpieler(3, "Redgrave", "Vergil", DateTime.Parse("03-01-1993"), "Stürmer", 857, anzahlJahre: 2, anzahlSpiele: 234, anzahlVereine: 5, gewonneneSpiele: 65);
            FussballSpieler p5 = new FussballSpieler(4, "Redgrave", "Dante", DateTime.Parse("04-01-1993"), "Stürmer", 900, anzahlJahre: 8, anzahlSpiele: 199, anzahlVereine: 6, gewonneneSpiele: 4);
            FussballSpieler p6 = new FussballSpieler(5, "Son", "Goku", DateTime.Parse("05-02-1993"), "Stürmer", 1010, anzahlJahre: 9, anzahlSpiele: 23, anzahlVereine: 1, gewonneneSpiele: 16);
            Trainer t1 = new Trainer(6, "Taylor", "Tom", DateTime.Parse("01-01-1993"), 23);

            HandballSpieler h1 = new HandballSpieler(7, "Ball", "Bernd", DateTime.Parse("01-03-1995"), "Verteidiger", 3, anzahlJahre: 2, anzahlSpiele: 77, anzahlVereine: 8, gewonneneSpiele: 56);
            HandballSpieler h3 = new HandballSpieler(8, "Potter", "Harry", DateTime.Parse("16-07-1999"), "Stürmer", 25, anzahlJahre: 4, anzahlSpiele: 182, anzahlVereine: 1, gewonneneSpiele: 245);
            HandballSpieler h2 = new HandballSpieler(9, "Dohnson", "Henry", DateTime.Parse("12-06-1963"), "Stürmer", 16, anzahlJahre: 6, anzahlSpiele: 90, anzahlVereine: 2, gewonneneSpiele: 78);
            HandballSpieler h4 = new HandballSpieler(10, "Hamper", "Holly", DateTime.Parse("05-01-1995"), "Mittelfeld", 17, anzahlJahre: 10, anzahlSpiele: 33, anzahlVereine: 3, gewonneneSpiele: 98);

            TennisSpieler ts1 = new TennisSpieler(11, "Federer", "Roger", DateTime.Parse("01-12-2001"), 95, anzahlJahre: 12, anzahlSpiele: 2, anzahlVereine: 1, gewonneneSpiele: 23);

            Mannschaft m = new Mannschaft("Azeroth SV", "Fussball", new List<Person>() { p1, p2 });

            VerwaltungsDAO newCon = new VerwaltungsDAO();
            newCon.ExecuteNonQuery("select * from person");

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