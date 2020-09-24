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
                List<Mannschaft> mannschaften = this.Verwalter.Turniere[index].Mannschaften.ToList();
                rp3.DataSource = sortAfterPoints(mannschaften, index);
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

        protected string getSpieleAnzahl(string teamID, int turnierIndex)
        {
            int retVal = 0;
            foreach (Spiel spiel in this.Verwalter.Turniere[turnierIndex].Spiele)
            {
                if (spiel.Team1ID.ToString() == teamID || spiel.Team2ID.ToString() == teamID)
                {
                    retVal += 1;
                }
            }
            return retVal.ToString();
        }

        protected string getAllTore(string teamID, int turnierIndex)
        {
            int retVal = 0;
            foreach (Spiel spiel in this.Verwalter.Turniere[turnierIndex].Spiele)
            {
                if (spiel.Team1ID.ToString() == teamID)
                {
                    retVal += spiel.Team1Punkte;
                }
                else if (spiel.Team2ID.ToString() == teamID)
                {
                    retVal += spiel.Team2Punkte;
                }
            }
            return retVal.ToString();
        }

        protected string getGegenTore(string teamID, int turnierIndex)
        {
            int retVal = 0;
            foreach (Spiel spiel in this.Verwalter.Turniere[turnierIndex].Spiele)
            {
                if (spiel.Team1ID.ToString() == teamID)
                {
                    retVal += spiel.Team2Punkte;
                }
                else if (spiel.Team2ID.ToString() == teamID)
                {
                    retVal += spiel.Team1Punkte;
                }
            }
            return retVal.ToString();
        }

        protected string getTorDifferenz(string teamID, int turnierIndex)
        {
            int retVal = 0;
            retVal = Convert.ToInt32(getAllTore(teamID, turnierIndex)) - Convert.ToInt32(getGegenTore(teamID, turnierIndex));
            return retVal.ToString();
        }

        protected string getPunkte(string teamID, int turnierIndex)
        {
            int retVal = 0;
            foreach (Spiel spiel in this.Verwalter.Turniere[turnierIndex].Spiele)
            {
                if (spiel.getWinnerID().ToString() == teamID)
                {
                    retVal += 3;
                }
                else if ((spiel.Team1ID.ToString() == teamID || spiel.Team2ID.ToString() == teamID) && (spiel.getWinnerID() == -1 && spiel.getLoserID() == -1))
                {
                    retVal += 1;
                }
            }
            return retVal.ToString();
        }

        protected List<Mannschaft> sortAfterPoints(List<Mannschaft> mannschaften, int turnierIndex)
        {
            List<Mannschaft> retVal = mannschaften;
            bool fertig = false;
            while (fertig == false)
            {
                fertig = true;
                for (int i = 0; i < mannschaften.Count - 1; i++)
                {
                    if (Convert.ToInt32(getPunkte(mannschaften[i].ID.ToString(), turnierIndex)) < Convert.ToInt32(getPunkte(mannschaften[i + 1].ID.ToString(), turnierIndex)))
                    {
                        Mannschaft temp = mannschaften[i];
                        mannschaften[i] = mannschaften[i + 1];
                        mannschaften[i + 1] = temp;
                        fertig = false;
                    }
                }
            }
            return retVal;
        }
    }
}