using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mannschaftsverwaltung
{
    public partial class _Default : Page
    {
        private Controller _Verwalter;
        private string _auswahl;

        public Controller Verwalter { get => _Verwalter; set => _Verwalter = value; }
        public string Auswahl { get => _auswahl; set => _auswahl = value; }

        protected void Page_Init(object sender, EventArgs e)
        {
            this.Verwalter = Global.Verwalter;
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
                vorname.Disabled = false;
                alter.Disabled = false;
                position.Disabled = false;
                geschosseneTore.Disabled = false;
                anzahlJahre.Disabled = false;
                disableAllRadioButtons();
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
                FussballSpieler f = new FussballSpieler(vorname.Value, Int32.Parse(alter.Value), position.Value, Int32.Parse(geschosseneTore.Value), Int32.Parse(anzahlJahre.Value));
                this.Verwalter.Personen.Add(f);
                enableAllRadioButtons();
                disableAndClearInputs();
            }
        }

        #region Worker
        public void disableAndClearInputs()
        {
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