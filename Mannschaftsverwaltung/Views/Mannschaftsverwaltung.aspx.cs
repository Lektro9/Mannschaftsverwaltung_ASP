//Autor:        Kroll
//Datum:        21.04.2020
//Dateiname:    Manschaftsverwlatung.aspx.cs
//Beschreibung: Mannschaften verwalten


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mannschaftsverwaltung
{
    public partial class Mannschaftsverwaltung : Page
    {
        private Controller _Verwalter;

        public Controller Verwalter { get => _Verwalter; set => _Verwalter = value; }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Verwalter = Global.Verwalter;
            LoadMannschaften();
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
                    //neueZelle = new TableCell();
                    //neueZelle.Text = m.Name;
                    //neueZeile.Cells.Add(neueZelle);

                    TableCell neueEditZelle = new TableCell();
                    TextBox NameEdit = new TextBox();
                    NameEdit.Attributes["value"] = m.Name;
                    NameEdit.CssClass = "form-control w-50";
                    neueEditZelle.Controls.Add(NameEdit);
                    neueZeile.Cells.Add(neueEditZelle);

                    //Spieleranzahl
                    neueZelle = new TableCell();
                    neueZelle.Text = m.AnzahlSpieler.ToString();
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

                    //accept
                    neueZelle = new TableCell();
                    Button editBtn = new Button();
                    editBtn.ID = "acc" + index;
                    editBtn.Text = "accept";
                    editBtn.Click += acc_Click;
                    editBtn.CssClass = "btn btn-success";
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
                    neueZelle.Text = m.AnzahlSpieler.ToString();
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

        protected void loadPersons(Object sender, EventArgs e)
        {
            string sportart = RadioButtonList1.SelectedValue;
            this.ListBox1.Items.Clear();
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
            }
            Button2.Attributes.Remove("disabled");
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
            Response.Redirect(Request.RawUrl);
        }

        protected void edit_Click(object sender, EventArgs e)
        {
            int index = Int32.Parse(((Button)sender).ID.Substring(5));
            this.Verwalter.EditMannschaft = true;
            this.Verwalter.EditMannIndex = index;
            Response.Redirect(Request.RawUrl);
        }

        protected void PersEntf_Click(object sender, EventArgs e)
        {
            int index = Int32.Parse(((Button)sender).ID.Substring(10));
            string[] Spieler = this.Request.Form[String.Format("ctl00$MainContent$Liste{0}", index )].Split(',');
            System.Collections.Specialized.NameValueCollection test = this.Request.Form;
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
                        this.Verwalter.Mannschaften[i].RemovePerson(id);
                    }
                }
            }
            Response.Redirect(Request.RawUrl);
        }

        protected void MannEntf_Click(object sender, EventArgs e)
        {
            int index = Int32.Parse(((Button)sender).ID.Substring(5));
            this.Verwalter.EditMannschaft = true;
            this.Verwalter.EditMannIndex = index;
            Response.Redirect(Request.RawUrl);
        }

        protected void acc_Click(object sender, EventArgs e)
        {
            int index = Int32.Parse(((Button)sender).ID.Substring(3));
            for (int i = 0; i <= this.Verwalter.Mannschaften.Count; i++)
            {
                if (i == index)
                {
                    this.Verwalter.Mannschaften[i - 1].Name = this.Request.Form["ctl00$MainContent$ctl00"];
                }
            }

            this.Verwalter.EditMannschaft = false;
            Response.Redirect(Request.RawUrl);
        }
    }
}