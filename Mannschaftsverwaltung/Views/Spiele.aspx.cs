//Autor:        Kroll
//Datum:        21.04.2020
//Dateiname:    Spiele.aspx.cs
//Beschreibung: vergangende Spiele einsehen


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mannschaftsverwaltung
{
    public partial class Spiele : Page
    {
        private Controller _Verwalter;

        public Controller Verwalter { get => _Verwalter; set => _Verwalter = value; }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Verwalter = Global.Verwalter;
            Repeater1.DataSource = this.Verwalter.Turniere;
            Repeater1.DataBind();
            Response.Write(Repeater1);
        }

        protected void TurnierErst_Click(object sender, EventArgs e)
        {
            string TurnierName = this.Request.Form["ctl00$MainContent$TurnierNameEing"];
            this.Verwalter.TurnierHinzuf(TurnierName);
            this.TurnierNameEing.Value = "";
            Response.Redirect(Request.RawUrl);
        }
        protected void SpielErst_Click(object sender, EventArgs e)
        {
            // string TurnierName = this.Request.Form["ctl00$MainContent$TurnierNameEing"];
            this.Verwalter.Turniere[0].Spiele.Add(new Spiel(-1, -1, -1, -1, -1));
            //this.TurnierNameEing.Value = "";
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }
    }
}