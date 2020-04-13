using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace Mannschaftsverwaltung
{
    public partial class _Default : Page
    {
        private Controller _Verwalter;
        private string _auswahl;
        TextBox nameInput;

        public Controller Verwalter { get => _Verwalter; set => _Verwalter = value; }
        public string Auswahl { get => _auswahl; set => _auswahl = value; }

        protected void Page_Init(object sender, EventArgs e)
        {
            this.Verwalter = Global.Verwalter;
            nameInput = new TextBox();
            nameInput.ID = "nameEdit";
            LoadPersonen();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            this.Auswahl = RadioButtonList1.SelectedValue;
            int index = RadioButtonList1.SelectedIndex;
            if (Auswahl == "Fussballspieler")
            {
                RadioButtonList1.SelectedIndex = index;
                name.Disabled = false;
                vorname.Disabled = false;
                alter.Disabled = false;
                position.Disabled = false;
                geschosseneTore.Disabled = false;
                anzahlJahre.Disabled = false;
                gewonneneSpiele.Disabled = false;
                anzahlVereine.Disabled = false;
                anzahlSpiele.Disabled = false;
                disableAllRadioButtons();
                this.Button3.Visible = true;
            }
            else if (Auswahl == "Handballspieler")
            {
                RadioButtonList1.SelectedIndex = index;
                name.Disabled = false;
                vorname.Disabled = false;
                alter.Disabled = false;
                position.Disabled = false;
                geschosseneTore.Disabled = false;
                anzahlJahre.Disabled = false;
                gewonneneSpiele.Disabled = false;
                anzahlVereine.Disabled = false;
                anzahlSpiele.Disabled = false;
                disableAllRadioButtons();
                this.Button3.Visible = true;
            }
            else if (Auswahl == "Tennisspieler")
            {
                RadioButtonList1.SelectedIndex = index;
                name.Disabled = false;
                vorname.Disabled = false;
                alter.Disabled = false;
                anzahlJahre.Disabled = false;
                gewonneneSpiele.Disabled = false;
                anzahlVereine.Disabled = false;
                anzahlSpiele.Disabled = false;
                schlaeger.Disabled = false;
                aufschlagGeschw.Disabled = false;
                disableAllRadioButtons();
                this.Button3.Visible = true;
            }
            else if (Auswahl == "Trainer")
            {
                RadioButtonList1.SelectedIndex = index;
                name.Disabled = false;
                vorname.Disabled = false;
                alter.Disabled = false;
                anzahlJahre.Disabled = false;
                disableAllRadioButtons();
                this.Button3.Visible = true;
            }
            else if (Auswahl == "Physiotherapeut")
            {
                RadioButtonList1.SelectedIndex = index;
                name.Disabled = false;
                vorname.Disabled = false;
                alter.Disabled = false;
                disableAllRadioButtons();
                this.Button3.Visible = true;
            }
            else
            {
                Response.Write("Keine Rolle ausgewählt!");
            }

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            this.Auswahl = RadioButtonList1.SelectedValue;
            if (this.Auswahl == "Fussballspieler")
            {
                FussballSpieler f = new FussballSpieler(name.Value, vorname.Value, Int32.Parse(alter.Value), position.Value, Int32.Parse(geschosseneTore.Value), Int32.Parse(anzahlJahre.Value), Int32.Parse(gewonneneSpiele.Value), Int32.Parse(anzahlVereine.Value), Int32.Parse(anzahlSpiele.Value));
                this.Verwalter.Personen.Add(f);
                enableAllRadioButtons();
                disableAndClearInputs();
            }
            else if (this.Auswahl == "Handballspieler")
            {
                HandballSpieler h = new HandballSpieler(name.Value, vorname.Value, Int32.Parse(alter.Value), position.Value, Int32.Parse(geschosseneTore.Value), Int32.Parse(anzahlJahre.Value), Int32.Parse(gewonneneSpiele.Value), Int32.Parse(anzahlVereine.Value), Int32.Parse(anzahlSpiele.Value));
                this.Verwalter.Personen.Add(h);
                enableAllRadioButtons();
                disableAndClearInputs();
            }
            else if (this.Auswahl == "Tennisspieler")
            {
                TennisSpieler t = new TennisSpieler(name.Value, vorname.Value, Int32.Parse(alter.Value), Int32.Parse(aufschlagGeschw.Value), schlaeger.Value, Int32.Parse(anzahlJahre.Value), Int32.Parse(gewonneneSpiele.Value), Int32.Parse(anzahlVereine.Value), Int32.Parse(anzahlSpiele.Value));
                this.Verwalter.Personen.Add(t);
                enableAllRadioButtons();
                disableAndClearInputs();
            }
            else if (this.Auswahl == "Trainer")
            {
                Trainer t = new Trainer(name.Value, vorname.Value, Int32.Parse(alter.Value), Int32.Parse(anzahlJahre.Value));
                this.Verwalter.Personen.Add(t);
                enableAllRadioButtons();
                disableAndClearInputs();
            }
            else
            {
                Physiotherapeut p = new Physiotherapeut(name.Value, vorname.Value, Int32.Parse(alter.Value));
                this.Verwalter.Personen.Add(p);
                enableAllRadioButtons();
                disableAndClearInputs();
            }
            Response.Redirect(Request.RawUrl);
        }

        protected void editBtn_Click(object sender, EventArgs e)
        {
            int index = Int32.Parse(((Button)sender).ID.Substring(5));
            this.Verwalter.EditPerson = true;
            this.Verwalter.EditPersonIndex = index;
            Response.Redirect(Request.RawUrl);
        }

        protected void delBtn_Click(object sender, EventArgs e)
        {
            int index = Int32.Parse(((Button)sender).ID.Substring(3));
            this.Verwalter.Personen.RemoveAt(index - 1);
            Response.Redirect(Request.RawUrl);
        }

        protected void accBtn_Click(object sender, EventArgs e)
        {
            int index = Int32.Parse(((Button)sender).ID.Substring(3));
            for (int i = 0; i < this.Verwalter.Personen.Count; i++)
            {
                if (i == index)
                {
                    this.Verwalter.Personen[i - 1].Name = nameInput.Text;
                }
            }
            this.Verwalter.EditPerson = false;
            Response.Redirect(Request.RawUrl);
        }

        #region Worker
        private void LoadPersonen()
        {
            int index = 1;
            int ex_id = 1;
            foreach (Person person in this.Verwalter.Personen)
            {
                TableRow neueZeile = new TableRow();
                if (this.Verwalter.EditPerson && index == this.Verwalter.EditPersonIndex)
                {
                    TableCell neueEditZelle = new TableCell();
                    if (person.ID != -1)
                    {
                        neueEditZelle.Text = person.ID.ToString();
                    }
                    else
                    {
                        neueEditZelle.Text = ex_id.ToString();
                        ex_id++;
                    }
                    neueZeile.Cells.Add(neueEditZelle);

                    //Name
                    neueEditZelle = new TableCell();
                    nameInput.Attributes["value"] = person.Name;
                    neueEditZelle.Controls.Add(nameInput);
                    neueZeile.Cells.Add(neueEditZelle);

                    neueEditZelle = new TableCell();
                    Button accBtn = new Button();
                    accBtn.ID = "acc" + index;
                    accBtn.Text = "accept";
                    accBtn.Click += accBtn_Click;
                    accBtn.CssClass = "btn-info";
                    neueEditZelle.Controls.Add(accBtn);
                    neueZeile.Cells.Add(neueEditZelle);
                }
                else
                {
                    //ID
                    TableCell neueZelle = new TableCell();
                    if (person.ID != -1)
                    {
                        neueZelle.Text = person.ID.ToString();
                    }
                    else
                    {
                        neueZelle.Text = ex_id.ToString();
                        ex_id++;
                    }
                    neueZeile.Cells.Add(neueZelle);

                    //Name
                    neueZelle = new TableCell();
                    neueZelle.Text = person.Name;
                    neueZeile.Cells.Add(neueZelle);

                    //Vorname
                    neueZelle = new TableCell();
                    neueZelle.Text = person.Vorname;
                    neueZeile.Cells.Add(neueZelle);

                    //Geburtsdatum
                    neueZelle = new TableCell();
                    neueZelle.Text = person.Alter.ToString();
                    neueZeile.Cells.Add(neueZelle);

                    //SportArt
                    neueZelle = new TableCell();
                    neueZelle.Text = getSportart(person);
                    neueZeile.Cells.Add(neueZelle);

                    //Anzahl Spiele
                    neueZelle = new TableCell();
                    neueZelle.Text = getAnzahlSpiele(person);
                    neueZeile.Cells.Add(neueZelle);

                    //Erziele Tore
                    neueZelle = new TableCell();
                    neueZelle.Text = getErzielteTore(person);
                    neueZeile.Cells.Add(neueZelle);

                    //Gewonnene Spiele
                    neueZelle = new TableCell();
                    neueZelle.Text = getGewonneneSpiele(person);
                    neueZeile.Cells.Add(neueZelle);

                    //Anzahl Jahre
                    neueZelle = new TableCell();
                    neueZelle.Text = getAnzahlJahre(person);
                    neueZeile.Cells.Add(neueZelle);

                    //Anzahl Vereine
                    neueZelle = new TableCell();
                    neueZelle.Text = getAnzahlVereine(person);
                    neueZeile.Cells.Add(neueZelle);

                    //Anzahl Vereine
                    neueZelle = new TableCell();
                    neueZelle.Text = getRolle(person);
                    neueZeile.Cells.Add(neueZelle);

                    //Edit
                    neueZelle = new TableCell();
                    Button editBtn = new Button();
                    editBtn.ID = "bearb" + index;
                    editBtn.Text = "edit";
                    editBtn.Click += editBtn_Click;
                    editBtn.CssClass = "btn-info";
                    neueZelle.Controls.Add(editBtn);
                    neueZeile.Cells.Add(neueZelle);

                    //Del
                    neueZelle = new TableCell();
                    Button delBtn = new Button();
                    delBtn.ID = "del" + index;
                    delBtn.Text = "Del";
                    delBtn.Click += delBtn_Click;
                    delBtn.CssClass = "btn-danger";
                    neueZelle.Controls.Add(delBtn);
                    neueZeile.Cells.Add(neueZelle);
                }

                index++;

                this.Table1.Rows.Add(neueZeile);
            }
        }
        public void disableAndClearInputs()
        {
            name.Disabled = true;
            name.Value = "";
            vorname.Disabled = true;
            vorname.Value = "";
            alter.Disabled = true;
            alter.Value = "";
            position.Disabled = true;
            position.Value = "";
            geschosseneTore.Disabled = true;
            geschosseneTore.Value = "";
            anzahlJahre.Disabled = true;
            anzahlJahre.Value = "";
            gewonneneSpiele.Disabled = true;
            gewonneneSpiele.Value = "";
            anzahlVereine.Disabled = true;
            anzahlVereine.Value = "";
            anzahlSpiele.Disabled = true;
            anzahlSpiele.Value = "";
            schlaeger.Disabled = true;
            schlaeger.Value = "";
            aufschlagGeschw.Disabled = true;
            aufschlagGeschw.Value = "";
        }
        public void disableAllRadioButtons()
        {
            foreach(ListItem radioButton in RadioButtonList1.Items)
            {
                radioButton.Enabled = false;
            }
        }
        public void enableAllRadioButtons()
        {
            foreach (ListItem radioButton in RadioButtonList1.Items)
            {
                radioButton.Enabled = true;
            }
        }
        public string getErzielteTore(Person p)
        {
            if (p is FussballSpieler)
            {
                return ((FussballSpieler)p).GeschosseneTore.ToString();
            }
            else if (p is HandballSpieler)
            {
                return ((HandballSpieler)p).GeworfeneTore.ToString();
            }
            else
            {
                return "";
            }
        }

        public string getGewonneneSpiele(Person p)
        {
            if (p is Spieler)
            {
                return ((Spieler)p).GewonneneSpiele.ToString();
            }
            else
            {
                return "";
            }
        }

        public string getAnzahlJahre(Person p)
        {
            if (p is Trainer)
            {
                return ((Trainer)p).Erfahrung.ToString();
            }
            else if (p is Spieler)
            {
                return ((Spieler)p).AnzahlJahre.ToString();
            }
            else
            {
                return "";
            }
        }

        public string getRolle(Person p)
        {
            if (p is FussballSpieler)
            {
                return ((FussballSpieler)p).Position;
            }
            else if (p is HandballSpieler)
            {
                return ((HandballSpieler)p).Position;
            }
            else if (p is TennisSpieler)
            {
                return ((TennisSpieler)p).Schlaeger + " " + ((TennisSpieler)p).Aufschlaggeschwindigkeit + "km/h";
            }
            else
            {
                return "";
            }
        }

        public string getAnzahlSpiele(Person p)
        {
            if (p is Spieler)
            {
                return ((Spieler)p).AnzahlSpiele.ToString();
            }
            else
            {
                return "";
            }
        }
        public string getAnzahlVereine(Person p)
        {
            if (p is Spieler)
            {
                return ((Spieler)p).AnzahlVereine.ToString();
            }
            else
            {
                return "";
            }
        }
        public string getSportart(Person p)
        {
            if (p is Spieler)
            {
                return ((Spieler)p).SportArt;
            }
            else
            {
                string type = p.GetType().ToString();
                string[] array = type.Split('.');
                return array[1];
            }
        }
        #endregion
    }
}