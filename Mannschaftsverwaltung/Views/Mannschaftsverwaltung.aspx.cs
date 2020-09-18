//Autor:        Kroll
//Datum:        21.04.2020
//Dateiname:    Manschaftsverwlatung.aspx.cs
//Beschreibung: Mannschaften verwalten


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Serialization;

namespace Mannschaftsverwaltung
{
    public partial class Mannschaftsverwaltung : Page
    {
        private Controller _Verwalter;
        int _editMannIndex;

        public Controller Verwalter { get => _Verwalter; set => _Verwalter = value; }
        public int EditMannIndex { get => _editMannIndex; set => _editMannIndex = value; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["Verwalter"] != null)
            {
                Verwalter = (Controller)this.Session["Verwalter"];
                if (this.Verwalter.ActiveUser != null)
                {
                    Verwalter = (Controller)this.Session[this.Verwalter.ActiveUser.ID.ToString()];
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
            this.Verwalter.Personen = this.Verwalter.getAllPerson(Verwalter.ActiveUser);
            this.Verwalter.Mannschaften = this.Verwalter.getAllMannschaften();
            LoadMannschaften();
            Verwalter.getAllTurniereFromDB();
            if (this.Verwalter.EditMannschaft)
            {
                LoadEditMannschaft();
                this.accept.Attributes.Remove("disabled");
            }
            Repeater1.DataSource = this.Verwalter.Mannschaften;
            Repeater1.DataBind();

        }

        protected void ItemBound(object sender, RepeaterItemEventArgs args)
        {
            if (args.Item.DataItem != null)
            {
                Repeater rp2 = (Repeater)args.Item.FindControl("Repeater2");
                int index = int.Parse(rp2.ClientID.Split('_').Last());
                rp2.DataSource = Verwalter.Mannschaften[index].Personen;
                rp2.DataBind();
            }
        }

        private void LoadMannschaften()
        {
            int index = 1;
            foreach (Mannschaft m in this.Verwalter.Mannschaften)
            {
                TableRow neueZeile = new TableRow();
                if (this.Verwalter.EditMannschaft && index == this.Verwalter.EditMannIndex)
                {
                    TableCell neueZelle = new TableCell();

                    //Name
                    neueZelle = new TableCell();
                    neueZelle.Text = m.Name;
                    neueZeile.Cells.Add(neueZelle);

                    //Spieleranzahl
                    neueZelle = new TableCell();
                    neueZelle.Text = m.getAnzahlSpieler().ToString();
                    neueZelle.CssClass = "text-center";
                    neueZeile.Cells.Add(neueZelle);

                    //Spieler
                    ListBox Mannschaft = new ListBox();
                    foreach (Person p in this.Verwalter.Mannschaften[index - 1].Personen)
                    {
                        ListItem item = new ListItem();
                        item.Text = "(" + p.ID + ") " + p.Name + ", " + p.Vorname;
                        Mannschaft.Items.Add(item);
                    }
                    neueZelle = new TableCell();
                    neueZelle.CssClass = "text-center";
                    neueZelle.Controls.Add(Mannschaft);
                    neueZeile.Cells.Add(neueZelle);

                    //edit
                    neueZelle = new TableCell();
                    Button editBtn = new Button();
                    editBtn.ID = "edit" + index;
                    editBtn.Text = "edit";
                    editBtn.Click += acc_Click;
                    editBtn.CssClass = "btn btn-info disabled";
                    editBtn.Enabled = false;
                    neueZelle.Controls.Add(editBtn);
                    neueZeile.Cells.Add(neueZelle);

                    //Personen entfernen
                    neueZelle = new TableCell();
                    Button removePersBtn = new Button();
                    removePersBtn.ID = "deletePers" + index;
                    removePersBtn.Text = "Pers. entfernen";
                    removePersBtn.Click += PersEntf_Click;
                    removePersBtn.CssClass = "btn btn-warning disabled";
                    removePersBtn.Enabled = false;
                    neueZelle.Controls.Add(removePersBtn);
                    neueZeile.Cells.Add(neueZelle);

                    //Mannschaft entfernen
                    neueZelle = new TableCell();
                    Button removeMannBtn = new Button();
                    removeMannBtn.ID = "deleteMann" + index;
                    removeMannBtn.Text = "Mannsch. löschen";
                    removeMannBtn.Click += MannEntf_Click;
                    removeMannBtn.CssClass = "btn btn-danger disabled";
                    removeMannBtn.Enabled = false;
                    neueZelle.Controls.Add(removeMannBtn);
                    neueZeile.Cells.Add(neueZelle);
                }
                else
                {
                    TableCell neueZelle = new TableCell();
                    //Name
                    neueZelle = new TableCell();
                    neueZelle.Text = m.Name;
                    neueZeile.Cells.Add(neueZelle);

                    //Spieleranzahl
                    neueZelle = new TableCell();
                    neueZelle.Text = m.getAnzahlSpieler().ToString();
                    neueZelle.CssClass = "text-center";
                    neueZeile.Cells.Add(neueZelle);

                    //Spieler
                    ListBox Mannschaft = new ListBox();
                    Mannschaft.SelectionMode = ListSelectionMode.Multiple;
                    Mannschaft.ID = "Liste" + index.ToString();
                    foreach (Person p in this.Verwalter.Mannschaften[index - 1].Personen)
                    {
                        ListItem item = new ListItem();
                        item.Text = "(" + p.ID + ") " + p.Name + " " + p.Vorname;
                        Mannschaft.Items.Add(item);
                    }
                    neueZelle = new TableCell();
                    neueZelle.CssClass = "text-center";
                    neueZelle.Controls.Add(Mannschaft);
                    neueZeile.Cells.Add(neueZelle);

                    //edit
                    neueZelle = new TableCell();
                    Button editBtn = new Button();
                    editBtn.ID = "bearb" + index;
                    editBtn.Text = "edit";
                    editBtn.Click += edit_Click;
                    editBtn.CssClass = "btn btn-info";
                    neueZelle.Controls.Add(editBtn);
                    neueZeile.Cells.Add(neueZelle);

                    //Personen entfernen
                    neueZelle = new TableCell();
                    Button removePersBtn = new Button();
                    removePersBtn.ID = "deletePers" + index;
                    removePersBtn.Text = "Pers. entfernen";
                    removePersBtn.Click += PersEntf_Click;
                    removePersBtn.CssClass = "btn btn-warning";
                    neueZelle.Controls.Add(removePersBtn);
                    neueZeile.Cells.Add(neueZelle);

                    //Mannschaft entfernen
                    neueZelle = new TableCell();
                    Button removeMannBtn = new Button();
                    removeMannBtn.ID = "deleteMann" + index;
                    removeMannBtn.Text = "Mannsch. löschen";
                    removeMannBtn.Click += MannEntf_Click;
                    removeMannBtn.CssClass = "btn btn-danger";
                    neueZelle.Controls.Add(removeMannBtn);
                    neueZeile.Cells.Add(neueZelle);
                }
                this.Table1.Rows.Add(neueZeile);

                index++;
            }

        }

        protected void LoadEditMannschaft()
        {
            string sportart = RadioButtonList1.SelectedValue;

            this.ListBox1.Items.Clear();
            int ID = this.Verwalter.EditMannID;
            Mannschaft EditMann = this.Verwalter.findMann(ID);

            foreach (ListItem item in this.RadioButtonList1.Items)
            {
                if (item.Text != EditMann.Sportart && item.Text != "Trainer" && item.Text != "Physiotherapeut")
                {
                    item.Enabled = false;
                }
            }

            this.mannschaftsName.Text = EditMann.Name;
        }


        protected void loadPersons(Object sender, EventArgs e)
        {
            string sportart = RadioButtonList1.SelectedValue;
            this.ListBox1.Items.Clear();
            if (this.Verwalter.EditMannschaft)
            {
                loadEditPers(sportart, this.Verwalter.EditMannID);
            }
            else
            {
                foreach (Person p in this.Verwalter.Personen)
                {
                    if (p is FussballSpieler && sportart == "Fussball")
                    {
                        ListItem item = new ListItem();
                        item.Text = "(" + p.ID + ") " + p.Name + " " + p.Vorname;
                        this.ListBox1.Items.Add(item);
                    }
                    else if (p is HandballSpieler && sportart == "Handball")
                    {
                        ListItem item = new ListItem();
                        item.Text = "(" + p.ID + ") " + p.Name + " " + p.Vorname;
                        this.ListBox1.Items.Add(item);
                    }
                    else if (p is TennisSpieler && sportart == "Tennis")
                    {
                        ListItem item = new ListItem();
                        item.Text = "(" + p.ID + ") " + p.Name + " " + p.Vorname;
                        this.ListBox1.Items.Add(item);
                    }
                    else if (p is Trainer && sportart == "Trainer")
                    {
                        ListItem item = new ListItem();
                        item.Text = "(" + p.ID + ") " + p.Name + " " + p.Vorname;
                        this.ListBox1.Items.Add(item);
                    }
                    else if (p is Physiotherapeut && sportart == "Physiotherapeut")
                    {
                        ListItem item = new ListItem();
                        item.Text = "(" + p.ID + ") " + p.Name + " " + p.Vorname;
                        this.ListBox1.Items.Add(item);
                    }
                }
                Button2.Attributes.Remove("disabled");
            }
        }

        protected void download_XML_click(object sender, EventArgs e)
        {
            Type[] types = new Type[] {
                typeof(Person),
                typeof(Spieler),
                typeof(FussballSpieler),
                typeof(HandballSpieler),
                typeof(TennisSpieler),
                typeof(Trainer),
                typeof(Physiotherapeut)
            };
            XmlSerializer x = new XmlSerializer(this.Verwalter.Mannschaften.GetType(), types);
            StringWriter textWriter = new StringWriter();
            x.Serialize(textWriter, this.Verwalter.Mannschaften);
            string allPers = textWriter.ToString();

            Response.AddHeader("Content-disposition", String.Format("attachment; filename={0}.xml", "MannschaftsverwaltungSave"));
            Response.ContentType = "application/xml";
            Response.Write(allPers);
            Response.End();
        }

        private void loadEditPers(string sportart, int mannID)
        {
            Mannschaft editMann = this.Verwalter.findMann(mannID);

            foreach (Person p in this.Verwalter.Personen)
            {
                if (!isDuplicate(p, editMann))
                {
                    if (p is FussballSpieler && sportart == "Fussball")
                    {
                        ListItem item = new ListItem();
                        item.Text = "(" + p.ID + ") " + p.Name + " " + p.Vorname;
                        this.ListBox1.Items.Add(item);
                    }
                    else if (p is HandballSpieler && sportart == "Handball")
                    {
                        ListItem item = new ListItem();
                        item.Text = "(" + p.ID + ") " + p.Name + " " + p.Vorname;
                        this.ListBox1.Items.Add(item);
                    }
                    else if (p is TennisSpieler && sportart == "Tennis")
                    {
                        ListItem item = new ListItem();
                        item.Text = "(" + p.ID + ") " + p.Name + " " + p.Vorname;
                        this.ListBox1.Items.Add(item);
                    }
                    else if (p is Trainer && sportart == "Trainer")
                    {
                        ListItem item = new ListItem();
                        item.Text = "(" + p.ID + ") " + p.Name + " " + p.Vorname;
                        this.ListBox1.Items.Add(item);
                    }
                    else if (p is Physiotherapeut && sportart == "Physiotherapeut")
                    {
                        ListItem item = new ListItem();
                        item.Text = "(" + p.ID + ") " + p.Name + " " + p.Vorname;
                        this.ListBox1.Items.Add(item);
                    }
                }
            }
        }

        private bool isDuplicate(Person p, Mannschaft editMann)
        {
            bool retVal = false;

            foreach (Person mp in editMann.Personen)
            {
                if (mp.ID == p.ID)
                {
                    retVal = true;
                }
            }

            return retVal;
        }

        protected void createManschaft(object sender, EventArgs e)
        {
            List<Person> mitglieder = new List<Person>();
            foreach (ListItem item in this.ListBox1.Items)
            {
                if (item.Selected)
                {
                    Match m = Regex.Match(item.ToString(), @"^\(([0-9]+)\)");
                    int personID = Int32.Parse(m.Groups[1].ToString());
                    foreach (Person p in this.Verwalter.Personen)
                    {
                        if (p.ID == personID)
                        {
                            mitglieder.Add(p);
                        }
                    }
                }
            }
            string sportart = RadioButtonList1.SelectedValue;
            string name = this.mannschaftsName.Text;

            this.Verwalter.createMannschaft(name, sportart, mitglieder);
            Response.Redirect(Request.RawUrl);
        }

        protected void orderByName(object sender, EventArgs e)
        {
            this.Verwalter.ReverseSort = !this.Verwalter.ReverseSort;
            this.Verwalter.sortiereNachMannschaftName();
            LoadMannschaften();
        }

        protected void edit_Click(object sender, EventArgs e)
        {
            int index = Int32.Parse(((Button)sender).ID.Substring(5));
            this.Verwalter.EditMannIndex = index;
            this.Verwalter.EditMannschaft = true;
            for (int i = 0; i < this.Verwalter.Mannschaften.Count; i++)
            {
                if (i == index - 1)
                {
                    this.Verwalter.EditMannID = this.Verwalter.Mannschaften[i].ID;
                }
            }
            Response.Redirect(Request.RawUrl);
        }

        protected void PersEntf_Click(object sender, EventArgs e)
        {
            int index = Int32.Parse(((Button)sender).ID.Substring(10));
            if (this.Request.Form[String.Format("ctl00$MainContent$Liste{0}", index)] != null)
            {
                string[] Spieler = this.Request.Form[String.Format("ctl00$MainContent$Liste{0}", index)].Split(',');
                List<int> SpielderIDs = new List<int>();
                foreach (string item in Spieler)
                {
                    Match m = Regex.Match(item.ToString(), @"^\(([0-9]+)\)");
                    int personID = Int32.Parse(m.Groups[1].ToString());
                    SpielderIDs.Add(personID);
                }

                for (int i = 0; i < this.Verwalter.Mannschaften.Count; i++)
                {
                    if (i == index - 1)
                    {
                        foreach (int id in SpielderIDs)
                        {
                            this.Verwalter.removePersonFromMannschaft(this.Verwalter.Mannschaften[i], id);
                        }
                    }
                }
            }
            Response.Redirect(Request.RawUrl);
        }

        protected void MannEntf_Click(object sender, EventArgs e)
        {
            int index = Int32.Parse(((Button)sender).ID.Substring(10));
            //this.Verwalter.DeleteFromDB(this.Verwalter.Mannschaften[index - 1].ID);
            // check if Mannschaft is used in tournament game
            if (!this.Verwalter.isMannschaftInGame(this.Verwalter.Mannschaften[index - 1]))
            {
                this.Verwalter.deleteMannFromDB(this.Verwalter.Mannschaften[index - 1]);
                this.Verwalter.Mannschaften.RemoveAt(index - 1);
            }
            else
            {
                this.Verwalter.IsError = true;
                this.Verwalter.ErrorMsg = "Mannschaft ist noch in Spielen eingetragen, bitte diese erst löschen.";
            }
        }

        protected void acc_Click(object sender, EventArgs e)
        {
            int index = -1;
            for (int i = 0; i < this.Verwalter.Mannschaften.Count; i++)
            {
                if (this.Verwalter.Mannschaften[i].ID == this.Verwalter.EditMannID)
                {
                    index = i;
                }
            }
            //change name of Mannschaft
            this.Verwalter.Mannschaften[index].Name = this.Request.Form["ctl00$MainContent$mannschaftsName"];
            this.Verwalter.renameMannInDB(this.Verwalter.Mannschaften[index]);

            //add Person to Mannschaft
            if (this.Request.Form["ctl00$MainContent$ListBox1"] != null)
            {
                string[] Spieler = this.Request.Form["ctl00$MainContent$ListBox1"].Split(',');
                foreach (string s in Spieler)
                {
                    Match m = Regex.Match(s, @"^\(([0-9]+)\)");
                    int personID = Int32.Parse(m.Groups[1].ToString());
                    foreach (Person p in this.Verwalter.Personen)
                    {
                        if (p.ID == personID)
                        {
                            this.Verwalter.Mannschaften[index].Personen.Add(p);
                            this.Verwalter.addPersonToMannInDB(this.Verwalter.Mannschaften[index], p);
                        }
                    }

                }
            }
            this.Verwalter.EditMannschaft = false;
            Response.Redirect(Request.RawUrl);
        }
    }
}