//Autor:        Kroll
//Datum:        21.04.2020
//Dateiname:    Tabellen.aspx.cs
//Beschreibung: Erfolge der Mannschaften in Turnieren


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mannschaftsverwaltung
{
    public partial class Tabellen : Page
    {
        private Controller _Verwalter;

        public Controller Verwalter { get => _Verwalter; set => _Verwalter = value; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["Verwalter"] != null)
            {
                Verwalter = (Controller)this.Session["Verwalter"];
            }
            else
            {
                this.Response.Redirect(@"~\Views\Login.aspx");
            }
            Repeater1.DataSource = this.Verwalter.Mannschaften;
            Repeater1.DataBind();
        }
    }
}