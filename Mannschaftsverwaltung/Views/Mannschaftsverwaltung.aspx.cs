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
            foreach (Mannschaft m in this.Verwalter.Mannschaften)
            {
                TableRow neueZeile = new TableRow();
                TableCell neueZelle = new TableCell();
                //Name
                neueZelle = new TableCell();
                neueZelle.Text = m.Name;
                neueZeile.Cells.Add(neueZelle);

                //gewonnene Spiele
                neueZelle = new TableCell();
                neueZelle.Text = m.GewSpiele.ToString();
                neueZeile.Cells.Add(neueZelle);

                //unentschieden
                neueZelle = new TableCell();
                neueZelle.Text = m.Unentschieden.ToString();
                neueZeile.Cells.Add(neueZelle);

                //verlorene Spiele
                neueZelle = new TableCell();
                neueZelle.Text = m.VerlSpiele.ToString();
                neueZeile.Cells.Add(neueZelle);

                //erzielte Tore
                neueZelle = new TableCell();
                neueZelle.Text = m.ErzielteTore.ToString();
                neueZeile.Cells.Add(neueZelle);

                //gegnerische Tore
                neueZelle = new TableCell();
                neueZelle.Text = m.GegnerischeTore.ToString();
                neueZeile.Cells.Add(neueZelle);

                this.Table1.Rows.Add(neueZeile);

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
                    item.Text = "(" + p.ID + ") " + p.Name + ", " + p.Vorname;
                    this.ListBox1.Items.Add(item);
                }
                else if (p is HandballSpieler && sportart == "Handball")
                {
                    ListItem item = new ListItem();
                    item.Text = "(" + p.ID + ") " + p.Name + ", " + p.Vorname;
                    this.ListBox1.Items.Add(item);
                }
                else if (p is TennisSpieler && sportart == "Tennis")
                {
                    ListItem item = new ListItem();
                    item.Text = "(" + p.ID +") " + p.Name + ", " + p.Vorname;
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
                    Response.Write(m.Groups[1]);
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
            int gewSpiele = Int32.Parse(this.gewSpiele.Text);
            int unentschieden = Int32.Parse(this.unentschieden.Text);
            int verlSpiele = Int32.Parse(this.verlSpiele.Text);
            int erzielteTore = Int32.Parse(this.erzielteTore.Text);
            int gegnerischeTore = Int32.Parse(this.gegnerischeTore.Text);

            this.Verwalter.createMannschaft(name, sportart, mitglieder, gewSpiele, unentschieden, verlSpiele, erzielteTore, gegnerischeTore);
            Response.Redirect(Request.RawUrl);
        }
    }
}