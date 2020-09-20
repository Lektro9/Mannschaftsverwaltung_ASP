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
                if (this.Verwalter.ActiveUser != null)
                {
                    Verwalter = (Controller)this.Session[this.Verwalter.ActiveUser.ID.ToString()];
                    this.Verwalter.Mannschaften = this.Verwalter.getAllMannschaften();
                    Verwalter.getAllTurniereFromDB();
                }
                else
                {
                    this.Response.Redirect(@"~\Views\Login.aspx");
                }
            }
            else
            {
                this.Response.Redirect(@"~\Views\Login.aspx");
            }
            Repeater1.DataSource = this.Verwalter.Mannschaften;
            Repeater1.DataBind();
            Repeater2.DataSource = this.Verwalter.Turniere;
            Repeater2.DataBind();
        }

        protected void ItemBound(object sender, RepeaterItemEventArgs args)
        {
            if (args.Item.DataItem != null)
            {
                Repeater rp3 = (Repeater)args.Item.FindControl("Repeater3");
                int index = int.Parse(rp3.ClientID.Split('_').Last());
                rp3.DataSource = this.Verwalter.Turniere[index].Mannschaften;
                rp3.DataBind();
            }
        }

        protected string getGewSpiele(string teamID, int turnierIndex)
        {
            int retVal = 0;
            foreach (Spiel spiel in this.Verwalter.Turniere[turnierIndex].Spiele)
            {
                if (spiel.getWinnerID().ToString() == teamID)
                {
                    retVal += 1;
                }
            }
            return retVal.ToString();
        }

        protected string getUnentschieden(string teamID, int turnierIndex)
        {
            int retVal = 0;
            foreach (Spiel spiel in this.Verwalter.Turniere[turnierIndex].Spiele)
            {
                if (spiel.getWinnerID() == -1 && spiel.getLoserID() == -1)
                {
                    retVal += 1;
                }
            }
            return retVal.ToString();
        }

        protected string getVerlSpiele(string teamID, int turnierIndex)
        {
            int retVal = 0;
            foreach (Spiel spiel in this.Verwalter.Turniere[turnierIndex].Spiele)
            {
                if (spiel.getLoserID().ToString() == teamID)
                {
                    retVal += 1;
                }
            }
            return retVal.ToString();
        }
    }
}