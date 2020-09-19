//Autor:        Kroll
//Datum:        21.04.2020
//Dateiname:    Spiele.aspx.cs
//Beschreibung: vergangende Spiele einsehen


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
                if (this.Verwalter.ActiveUser != null)
                {
                    Verwalter = (Controller)this.Session[this.Verwalter.ActiveUser.ID.ToString()];
                    this.Verwalter.Personen = this.Verwalter.getAllPerson(Verwalter.ActiveUser);
                    this.Verwalter.Mannschaften = this.Verwalter.getAllMannschaften();
                    Verwalter.getAllTurniereFromDB();
                    loadMannschaften();
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
            Repeater1.DataSource = this.Verwalter.Turniere;
            Repeater1.DataBind();
        }

        protected void TurnierErst_Click(object sender, EventArgs e)
        {
            List<Mannschaft> selectedMannschaften = new List<Mannschaft>();
            foreach (ListItem item in this.ListBox1.Items)
            {
                if (item.Selected)
                {
                    Match m = Regex.Match(item.ToString(), @"^\(([0-9]+)\)");
                    int MannschaftID = Int32.Parse(m.Groups[1].ToString());
                    foreach (Mannschaft mannschaft in this.Verwalter.Mannschaften)
                    {
                        if (mannschaft.ID == MannschaftID)
                        {
                            selectedMannschaften.Add(mannschaft);
                        }
                    }
                }
            }
            this.ListBox1.Items.Clear();

            string TurnierName = this.Request.Form["ctl00$MainContent$TurnierNameEing"];
            this.Verwalter.TurnierHinzuf(TurnierName, selectedMannschaften);
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
            if (!String.IsNullOrEmpty(team1id) && !String.IsNullOrEmpty(team2id) && !String.IsNullOrEmpty(team1punkte) && !String.IsNullOrEmpty(team2punkte))
            {
                this.Verwalter.createGame(index, int.Parse(team1id), int.Parse(team2id), int.Parse(team1punkte), int.Parse(team2punkte));
                Response.Redirect(Request.RawUrl);
            }
            else
            {
                this.Verwalter.IsError = true;
                this.Verwalter.ErrorMsg = "Falsche Eingabe, bitte prüfen.";
            }
        }

        protected void SpielBearbeitet_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Console.WriteLine(this.Request.Form);
            int index = int.Parse(button.ClientID.Split('_').Last());
            string team1id = this.Request.Form["EditSelect1_" + (index + 1)];
            string team2id = this.Request.Form["EditSelect2_" + (index + 1)];
            string team1punkte = this.Request.Form["EditTeam1goals_" + (index + 1)];
            string team2punkte = this.Request.Form["EditTeam2goals_" + (index + 1)];
            if (!String.IsNullOrEmpty(team1id) && !String.IsNullOrEmpty(team2id) && !String.IsNullOrEmpty(team1punkte) && !String.IsNullOrEmpty(team2punkte))
            {
                this.Verwalter.editGame(int.Parse(team1id), int.Parse(team2id), int.Parse(team1punkte), int.Parse(team2punkte));
                this.Verwalter.EditGameID = -1;
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

        protected void SpielEdit_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int TurnierIndex = int.Parse(button.ClientID.Split('_')[1]);
            int SpielIndex = int.Parse(button.ClientID.Split('_').Last());
            this.Verwalter.EditGameID = this.Verwalter.Turniere[TurnierIndex].Spiele[SpielIndex].ID;
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
                rp3.DataSource = this.Verwalter.Turniere[index].Mannschaften;
                rp3.DataBind();
                rp4.DataSource = this.Verwalter.Turniere[index].Mannschaften;
                rp4.DataBind();
            }
        }

        protected void ItemBoundOnRepeater2(object sender, RepeaterItemEventArgs args)
        {
            Repeater button = sender as Repeater;
            if (button != null)
            {
                int index = int.Parse(button.ClientID.Split('_').Last());
                if (args.Item.DataItem != null)
                {
                    Repeater rp5 = (Repeater)args.Item.FindControl("Repeater5");
                    Repeater rp6 = (Repeater)args.Item.FindControl("Repeater6");
                    rp5.DataSource = this.Verwalter.Turniere[index].Mannschaften;
                    rp5.DataBind();
                    rp6.DataSource = this.Verwalter.Turniere[index].Mannschaften;
                    rp6.DataBind();
                }
            }
            //if (args.Item.DataItem != null)
            //{
            //    Repeater rp5 = (Repeater)args.Item.FindControl("Repeater5");
            //    Repeater rp6 = (Repeater)args.Item.FindControl("Repeater6");
            //    rp5.DataSource = this.Verwalter.Mannschaften;
            //    rp5.DataBind();
            //    rp6.DataSource = this.Verwalter.Mannschaften;
            //    rp6.DataBind();
            //}
        }

        protected void loadMannschaften()
        {
            foreach (Mannschaft mannschaft in this.Verwalter.Mannschaften)
            {
                ListItem item = new ListItem();
                item.Text = "(" + mannschaft.ID + ") -" + mannschaft.Sportart + "- " + mannschaft.Name;
                this.ListBox1.Items.Add(item);
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

        protected bool isGameEdit(string gameID)
        {
            bool retVal = false;
            if (gameID == this.Verwalter.EditGameID.ToString())
            {
                retVal = true;
            }
            return retVal;
        }
    }
}