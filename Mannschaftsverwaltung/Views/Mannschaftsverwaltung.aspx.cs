using System;
using System.Collections.Generic;
using System.Linq;
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
                    item.Text = p.Name + ", " + p.Vorname;
                    this.ListBox1.Items.Add(item);
                }
                else if (p is HandballSpieler && sportart == "Handball")
                {
                    ListItem item = new ListItem();
                    item.Text = p.Name + ", " + p.Vorname;
                    this.ListBox1.Items.Add(item);
                }
                else if (p is TennisSpieler && sportart == "Tennis")
                {
                    ListItem item = new ListItem();
                    item.Text = p.Name + ", " + p.Vorname;
                    this.ListBox1.Items.Add(item);
                }
            }
            Button2.Attributes.Remove("disabled");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string sportart = RadioButtonList1.SelectedValue;
            foreach (ListItem item in this.ListBox1.Items)
            {
                if (item.Selected)
                {
                    Response.Write(item.ToString());
                }
            }

        }
    }
}