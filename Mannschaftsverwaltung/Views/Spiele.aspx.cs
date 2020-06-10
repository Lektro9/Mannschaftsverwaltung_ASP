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
            if (this.Session["Verwalter"] != null)
            {
                Verwalter = (Controller)this.Session["Verwalter"];
            }
            else
            {
                this.Response.Redirect(@"~\Views\Login.aspx");
            }
            Repeater1.DataSource = this.Verwalter.Turniere;
            Repeater1.DataBind();
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
            Button button = (Button)sender;
            int index = int.Parse(button.ClientID.Split('_').Last());
            string team1id = this.Request.Form["Select1_" + (index + 1)];
            string team2id = this.Request.Form["Select2_" + (index + 1)];
            string team1punkte = this.Request.Form["team1goals_" + (index + 1)];
            string team2punkte = this.Request.Form["team2goals_" + (index + 1)];
            if (team1id != null && team2id != null && team1punkte != null && team2punkte != null)
            {
                this.Verwalter.createGame(index, int.Parse(team1id), int.Parse(team2id), int.Parse(team1punkte), int.Parse(team2punkte));
                Response.Redirect(Request.RawUrl);
            }
        }

        protected void SpielEntf_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int TurnierIndex = int.Parse(button.ClientID.Split('_')[1]);
            int SpielIndex = int.Parse(button.ClientID.Split('_').Last());
            this.Verwalter.deleteGame(TurnierIndex, this.Verwalter.Turniere[TurnierIndex].Spiele[SpielIndex]);
            Response.Redirect(Request.RawUrl);
        }

        protected void TurEntf_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int TurnierIndex = int.Parse(button.ClientID.Split('_')[1]);
            //this.Verwalter.deleteGame(TurnierIndex, this.Verwalter.Turniere[TurnierIndex].Spiele[SpielIndex]);
            this.Verwalter.removeTurnier(TurnierIndex);
            Response.Redirect(Request.RawUrl);
        }

        

        protected void ItemBound(object sender, RepeaterItemEventArgs args)
        {
            if (args.Item.DataItem != null)
            {
                Repeater rp2 = (Repeater)args.Item.FindControl("Repeater2");
                Repeater rp3 = (Repeater)args.Item.FindControl("Repeater3");
                Repeater rp4 = (Repeater)args.Item.FindControl("Repeater4");
                int index = int.Parse(rp2.ClientID.Split('_').Last());
                rp2.DataSource = this.Verwalter.Turniere[index].Spiele;
                rp2.DataBind();
                rp3.DataSource = this.Verwalter.Mannschaften;
                rp3.DataBind();
                rp4.DataSource = this.Verwalter.Mannschaften;
                rp4.DataBind();
            }
        }

        protected string getTeamName(string ID)
        {
            string retVal = "";
            int TeamID = int.Parse(ID);

            foreach (Mannschaft m in this.Verwalter.Mannschaften)
            {
                if (m.ID == TeamID)
                {
                    retVal = m.Name;
                }
            }

            return retVal;
        }
    }
}