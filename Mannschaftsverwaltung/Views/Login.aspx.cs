using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mannschaftsverwaltung
{
    public partial class Login : Page
    {
        private Controller _Verwalter;

        public Controller Verwalter { get => _Verwalter; set => _Verwalter = value; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["Verwalter"] != null)
            {
                Verwalter = (Controller)this.Session["Verwalter"];
                if (this.Verwalter.Authenticated)
                {
                    this.Session[this.Verwalter.ActiveUser.ID.ToString()] = new Controller();
                    User currentUser = this.Verwalter.ActiveUser;
                    Verwalter = (Controller)this.Session[this.Verwalter.ActiveUser.ID];
                    Verwalter.Authenticated = true;
                    Verwalter.ActiveUser = currentUser;
                    FussballSpieler p1 = new FussballSpieler(1, "Shidoski", "Klaus", DateTime.ParseExact("01-01-1993", "dd-MM-yyyy", null), "Stürmer", 23, anzahlJahre: 1, anzahlSpiele: 32, anzahlVereine: 2, gewonneneSpiele: 2);
                    FussballSpieler p2 = new FussballSpieler(2, "Johnsons", "Dennis", DateTime.ParseExact("02-01-1993", "dd-MM-yyyy", null), "Stürmer", 25, anzahlJahre: 6, anzahlSpiele: 567, anzahlVereine: 2, gewonneneSpiele: 234);
                    FussballSpieler p4 = new FussballSpieler(3, "Redgrave", "Vergil", DateTime.ParseExact("03-01-1993", "dd-MM-yyyy", null), "Stürmer", 857, anzahlJahre: 2, anzahlSpiele: 234, anzahlVereine: 5, gewonneneSpiele: 65);
                    FussballSpieler p5 = new FussballSpieler(4, "Redgrave", "Dante", DateTime.ParseExact("04-01-1993", "dd-MM-yyyy", null), "Stürmer", 900, anzahlJahre: 8, anzahlSpiele: 199, anzahlVereine: 6, gewonneneSpiele: 4);
                    FussballSpieler p6 = new FussballSpieler(5, "Son", "Goku", DateTime.ParseExact("05-02-1993", "dd-MM-yyyy", null), "Stürmer", 1010, anzahlJahre: 9, anzahlSpiele: 23, anzahlVereine: 1, gewonneneSpiele: 16);
                    Trainer t1 = new Trainer(6, "Taylor", "Tom", DateTime.ParseExact("01-01-1993", "dd-MM-yyyy", null), 23);

                    HandballSpieler h1 = new HandballSpieler(7, "Ball", "Bernd", DateTime.ParseExact("01-03-1995", "dd-MM-yyyy", null), "Verteidiger", 3, anzahlJahre: 2, anzahlSpiele: 77, anzahlVereine: 8, gewonneneSpiele: 56);
                    HandballSpieler h3 = new HandballSpieler(8, "Potter", "Harry", DateTime.ParseExact("16-07-1999", "dd-MM-yyyy", null), "Stürmer", 25, anzahlJahre: 4, anzahlSpiele: 182, anzahlVereine: 1, gewonneneSpiele: 245);
                    HandballSpieler h2 = new HandballSpieler(9, "Dohnson", "Henry", DateTime.ParseExact("12-06-1963", "dd-MM-yyyy", null), "Stürmer", 16, anzahlJahre: 6, anzahlSpiele: 90, anzahlVereine: 2, gewonneneSpiele: 78);
                    HandballSpieler h4 = new HandballSpieler(10, "Hamper", "Holly", DateTime.ParseExact("05-01-1995", "dd-MM-yyyy", null), "Mittelfeld", 17, anzahlJahre: 10, anzahlSpiele: 33, anzahlVereine: 3, gewonneneSpiele: 98);

                    TennisSpieler ts1 = new TennisSpieler(11, "Federer", "Roger", DateTime.ParseExact("01-12-2001", "dd-MM-yyyy", null), 95, anzahlJahre: 12, anzahlSpiele: 2, anzahlVereine: 1, gewonneneSpiele: 23);

                    Physiotherapeut ph1 = new Physiotherapeut(12, "Denrasen", "Dr. med", DateTime.ParseExact("01-01-1993", "dd-MM-yyyy", null), "Auszeichnung blabla");
                    Verwalter.Personen = new List<Person>() { p1, p2, p4, p5, p6, t1, h1, h2, h3, h4, ts1, ph1 };
                }
            }
            else
            {
                this.Session["Verwalter"] = new Controller();
                Verwalter = (Controller)this.Session["Verwalter"];
            }
        }

        protected void login_Click(object sender, EventArgs e)
        {
            string username = this.Request.Form["uname1"];
            string password = this.Request.Form["password"];
            this.Verwalter.login(username, password);
            Response.Redirect(Request.RawUrl);
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            this.Session["Verwalter"] = new Controller();
            Verwalter = (Controller)this.Session["Verwalter"];
            Response.Redirect(Request.RawUrl);
        }
    }
}