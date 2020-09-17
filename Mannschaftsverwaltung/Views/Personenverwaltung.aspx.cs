using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.Globalization;

namespace Mannschaftsverwaltung {
    public partial class _Default : Page {
        private Controller _Verwalter;
        private string _auswahl;


        public Controller Verwalter { get => _Verwalter; set => _Verwalter = value; }
        public string Auswahl { get => _auswahl; set => _auswahl = value; }

        protected void Page_Init(object sender, EventArgs e) {

        }

        protected void Page_Load(object sender, EventArgs e) {
            if (this.Session["Verwalter"] != null) {
                Verwalter = (Controller)this.Session["Verwalter"];
                if (this.Verwalter.ActiveUser != null) {
                    Verwalter = (Controller)this.Session[this.Verwalter.ActiveUser.ID.ToString()];
                    this.Verwalter.Personen = Verwalter.getAllPerson(this.Verwalter.ActiveUser);
                }
                else {
                    this.Response.Redirect(@"~\Views\Login.aspx");
                }
            }
            else {
                this.Response.Redirect(@"~\Views\Login.aspx");
            }
            LoadPersonen();

        }

        protected void Button2_Click(object sender, EventArgs e) {
            this.Auswahl = RadioButtonList1.SelectedValue;
            int index = RadioButtonList1.SelectedIndex;
            disableAndClearInputs();
            foreach (ListItem item in RadioButtonList1.Items) {
                item.Attributes.Add("class", "list-group-item list-group-item-action disabled");
            }
            if (Auswahl == "Fussballspieler") {
                RadioButtonList1.SelectedIndex = index;
                RadioButtonList1.Items[RadioButtonList1.SelectedIndex].Attributes.Add("class", "list-group-item list-group-item-action active");
                name.Disabled = false;
                vorname.Disabled = false;
                geburtstag.Disabled = false;
                position.Disabled = false;
                geschosseneTore.Disabled = false;
                anzahlJahre.Disabled = false;
                gewonneneSpiele.Disabled = false;
                anzahlVereine.Disabled = false;
                anzahlSpiele.Disabled = false;
                this.Button3.Visible = true;
            }
            else if (Auswahl == "Handballspieler") {
                RadioButtonList1.SelectedIndex = index;
                RadioButtonList1.Items[RadioButtonList1.SelectedIndex].Attributes.Add("class", "list-group-item list-group-item-action active");
                name.Disabled = false;
                vorname.Disabled = false;
                geburtstag.Disabled = false;
                position.Disabled = false;
                geschosseneTore.Disabled = false;
                anzahlJahre.Disabled = false;
                gewonneneSpiele.Disabled = false;
                anzahlVereine.Disabled = false;
                anzahlSpiele.Disabled = false;
                this.Button3.Visible = true;
            }
            else if (Auswahl == "Tennisspieler") {
                RadioButtonList1.SelectedIndex = index;
                RadioButtonList1.Items[RadioButtonList1.SelectedIndex].Attributes.Add("class", "list-group-item list-group-item-action active");
                name.Disabled = false;
                vorname.Disabled = false;
                geburtstag.Disabled = false;
                anzahlJahre.Disabled = false;
                gewonneneSpiele.Disabled = false;
                anzahlVereine.Disabled = false;
                anzahlSpiele.Disabled = false;
                schlaeger.Disabled = false;
                aufschlagGeschw.Disabled = false;
                this.Button3.Visible = true;
            }
            else if (Auswahl == "Trainer") {
                RadioButtonList1.SelectedIndex = index;
                RadioButtonList1.Items[RadioButtonList1.SelectedIndex].Attributes.Add("class", "list-group-item list-group-item-action active");
                name.Disabled = false;
                vorname.Disabled = false;
                geburtstag.Disabled = false;
                anzahlJahre.Disabled = false;
                this.Button3.Visible = true;
            }
            else if (Auswahl == "Physiotherapeut") {
                RadioButtonList1.SelectedIndex = index;
                RadioButtonList1.Items[RadioButtonList1.SelectedIndex].Attributes.Add("class", "list-group-item list-group-item-action active");
                name.Disabled = false;
                vorname.Disabled = false;
                geburtstag.Disabled = false;
                this.Button3.Visible = true;
            }
            else {
                Response.Write("Keine Rolle ausgewählt!");
            }

        }

        protected void Button3_Click(object sender, EventArgs e) {
            this.Auswahl = RadioButtonList1.SelectedValue;
            if (this.Auswahl == "Fussballspieler") {
                this.Verwalter.AddFussballSpieler(name.Value, vorname.Value, DateTime.Parse(geburtstag.Value), position.Value, Int32.Parse(geschosseneTore.Value), Int32.Parse(anzahlJahre.Value), Int32.Parse(gewonneneSpiele.Value), Int32.Parse(anzahlVereine.Value), Int32.Parse(anzahlSpiele.Value));
            }
            else if (this.Auswahl == "Handballspieler") {
                this.Verwalter.AddHandballSpieler(name.Value, vorname.Value, DateTime.Parse(geburtstag.Value), position.Value, Int32.Parse(geschosseneTore.Value), Int32.Parse(anzahlJahre.Value), Int32.Parse(gewonneneSpiele.Value), Int32.Parse(anzahlVereine.Value), Int32.Parse(anzahlSpiele.Value));
            }
            else if (this.Auswahl == "Tennisspieler") {
                this.Verwalter.AddTennisSpieler(name.Value, vorname.Value, DateTime.Parse(geburtstag.Value), Int32.Parse(aufschlagGeschw.Value), schlaeger.Value, Int32.Parse(anzahlJahre.Value), Int32.Parse(gewonneneSpiele.Value), Int32.Parse(anzahlVereine.Value), Int32.Parse(anzahlSpiele.Value));
            }
            else if (this.Auswahl == "Trainer") {
                this.Verwalter.AddTrainer(name.Value, vorname.Value, DateTime.Parse(geburtstag.Value), Int32.Parse(anzahlJahre.Value));
            }
            else {
                this.Verwalter.AddPhysio(name.Value, vorname.Value, DateTime.Parse(geburtstag.Value));
            }
            enableAllRadioButtons();
            disableAndClearInputs();
            Response.Redirect(Request.RawUrl);
        }

        protected void editBtn_Click(object sender, EventArgs e) {
            disableAndClearInputs();

            this.Verwalter.EditPerson = true;
            this.Verwalter.EditPersonIndex = Int32.Parse(((Button)sender).ID.Substring(5));

            Response.Redirect(Request.RawUrl);
        }

        protected void delBtn_Click(object sender, EventArgs e) {
            int index = Int32.Parse(((Button)sender).ID.Substring(3));
            if (this.Verwalter.DBManager.DBStatus) {
                this.Verwalter.Personen[index - 1].deletePerson();
            }
            this.Verwalter.Personen.RemoveAt(index - 1);
            Response.Redirect(Request.RawUrl);
        }

        protected void accBtn_Click(object sender, EventArgs e) {
            // TODO: Maybe put in Wrapper function
            Dictionary<string, string> fields = new Dictionary<string, string>();
            foreach (string fieldName in Request.Form.AllKeys) {
                string fieldNameShort = fieldName;
                if (fieldName.Contains("$")) {
                    fieldNameShort = fieldName.Substring(fieldName.LastIndexOf("$") + 1);
                }
                fields[fieldNameShort] = fieldName;
            }

            int index = Int32.Parse(((Button)sender).ID.Substring(3));
            for (int i = 0; i <= this.Verwalter.Personen.Count; i++) {
                if (i == index) {
                    this.Verwalter.Personen[i - 1].Name = Request.Form[fields["name"]];
                    this.Verwalter.Personen[i - 1].Vorname = Request.Form[fields["vorname"]];
                    this.Verwalter.Personen[i - 1].Geburtstag = DateTime.Parse(Request.Form[fields["geburtstag"]]);

                    if (this.Verwalter.Personen[i - 1] is Spieler) {
                        ((Spieler)this.Verwalter.Personen[i - 1]).AnzahlSpiele = Int32.Parse(Request.Form[fields["anzahlSpiele"]]);
                        ((Spieler)this.Verwalter.Personen[i - 1]).GewonneneSpiele = Int32.Parse(Request.Form[fields["gewonneneSpiele"]]);
                        ((Spieler)this.Verwalter.Personen[i - 1]).AnzahlJahre = Int32.Parse(Request.Form[fields["anzahlJahre"]]);
                        ((Spieler)this.Verwalter.Personen[i - 1]).AnzahlVereine = Int32.Parse(Request.Form[fields["anzahlVereine"]]);

                        if (this.Verwalter.Personen[i - 1] is FussballSpieler) {
                            ((FussballSpieler)this.Verwalter.Personen[i - 1]).GeschosseneTore = Int32.Parse(Request.Form[fields["geschosseneTore"]]);
                            ((FussballSpieler)this.Verwalter.Personen[i - 1]).Position = Request.Form[fields["position"]];
                        }
                        else if (this.Verwalter.Personen[i - 1] is HandballSpieler) {
                            ((HandballSpieler)this.Verwalter.Personen[i - 1]).GeworfeneTore = Int32.Parse(Request.Form[fields["geschosseneTore"]]);
                            ((HandballSpieler)this.Verwalter.Personen[i - 1]).Position = Request.Form[fields["position"]];
                        }
                        else if (this.Verwalter.Personen[i - 1] is TennisSpieler) {
                            ((TennisSpieler)this.Verwalter.Personen[i - 1]).Schlaeger = Request.Form[fields["schlaeger"]];
                            ((TennisSpieler)this.Verwalter.Personen[i - 1]).Aufschlaggeschwindigkeit = Int32.Parse(Request.Form[fields["aufschlagGeschw"]]);
                        }
                    }
                    else if (this.Verwalter.Personen[i - 1] is Trainer) {
                        ((Trainer)this.Verwalter.Personen[i - 1]).Erfahrung = Int32.Parse(Request.Form[fields["anzahlJahre"]]);
                    }
                    // Physiotherapeut is missing (same for insert?)

                    if (this.Verwalter.DBManager.DBStatus) {
                        this.Verwalter.Personen[i - 1].editPerson();
                    }
                }
            }
            this.Verwalter.EditPerson = false;
            disableAndClearInputs();
            Response.Redirect(Request.RawUrl);
        }

        #region Worker

        protected void download_XML_click(object sender, EventArgs e) {
            Type[] types = new Type[] {
                typeof(Person),
                typeof(Spieler),
                typeof(FussballSpieler),
                typeof(HandballSpieler),
                typeof(TennisSpieler),
                typeof(Trainer),
                typeof(Physiotherapeut)
            };
            XmlSerializer x = new XmlSerializer(this.Verwalter.Personen.GetType(), types);
            StringWriter textWriter = new StringWriter();
            x.Serialize(textWriter, this.Verwalter.Personen);
            string allPers = textWriter.ToString();

            Response.AddHeader("Content-disposition", String.Format("attachment; filename={0}.xml", "MannschaftsverwaltungSave"));
            Response.ContentType = "application/xml";
            Response.Write(allPers);
            Response.End();
        }

        protected void orderByName(object sender, EventArgs e) {
            this.Verwalter.ReverseSort = !this.Verwalter.ReverseSort;
            this.Verwalter.sortiereNachName();
            Response.Redirect(Request.RawUrl);
        }

        protected void orderByBirthday(object sender, EventArgs e) {
            this.Verwalter.ReverseSort = !this.Verwalter.ReverseSort;
            this.Verwalter.sortiereNachGeburtstag();
            Response.Redirect(Request.RawUrl);
        }

        protected void orderByGoals(object sender, EventArgs e) {
            this.Verwalter.ReverseSort = !this.Verwalter.ReverseSort;
            this.Verwalter.sortiereNachSpezEigenschaft();
            Response.Redirect(Request.RawUrl);
        }

        private void LoadPersonen() {
            int index = 1;
            int ex_id = 1;
            foreach (Person person in this.Verwalter.Personen) {
                TableRow neueZeile = new TableRow();
                //ID
                TableCell neueZelle = new TableCell();
                if (person.ID != -1) {
                    neueZelle.Text = person.ID.ToString();
                }
                else {
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
                neueZelle.Text = person.Geburtstag.ToString("dd.MM.yyyy");
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

                if (this.Verwalter.ActiveUser.Rolle == Role.ADMIN) {
                    //Edit
                    neueZelle = new TableCell();
                    Button editBtn = new Button();
                    editBtn.ID = "bearb" + index;
                    editBtn.Text = "edit";
                    editBtn.Click += editBtn_Click;
                    editBtn.CssClass = "btn btn-info";
                    neueZelle.Controls.Add(editBtn);
                    neueZeile.Cells.Add(neueZelle);

                    //Del
                    neueZelle = new TableCell();
                    Button delBtn = new Button();
                    delBtn.ID = "del" + index;
                    delBtn.Text = "Del";
                    delBtn.Click += delBtn_Click;
                    delBtn.CssClass = "btn btn-danger";
                    neueZelle.Controls.Add(delBtn);
                    neueZeile.Cells.Add(neueZelle);
                }

                index++;

                this.Table1.Rows.Add(neueZeile);
            }

            if (this.Verwalter.EditPerson == true) {
                foreach (Person person in this.Verwalter.Personen) {
                    if (person.ID == this.Verwalter.Personen[this.Verwalter.EditPersonIndex - 1].ID) {
                        name.Attributes["value"] = person.Name;
                        vorname.Attributes["value"] = person.Vorname;
                        geburtstag.Attributes["value"] = person.Geburtstag.ToString("yyyy-MM-dd");

                        name.Disabled = false;
                        vorname.Disabled = false;
                        geburtstag.Disabled = false;

                        if (getSportart(person) == "FussballSpieler" || getSportart(person) == "HandballSpieler" || getSportart(person) == "TennisSpieler") {
                            if (getSportart(person) == "FussballSpieler" || getSportart(person) == "HandballSpieler") {
                                position.Attributes["value"] = getRolle(person);
                                geschosseneTore.Attributes["value"] = getErzielteTore(person);

                                position.Disabled = false;
                                geschosseneTore.Disabled = false;
                            }
                            else if (getSportart(person) == "TennisSpieler") {
                                schlaeger.Attributes["value"] = getSchlaeger(person);
                                aufschlagGeschw.Attributes["value"] = getAufschlaggeschwindigkeit(person);

                                schlaeger.Disabled = false;
                                aufschlagGeschw.Disabled = false;
                            }

                            anzahlVereine.Attributes["value"] = getAnzahlVereine(person);
                            anzahlJahre.Attributes["value"] = getAnzahlJahre(person);
                            gewonneneSpiele.Attributes["value"] = getGewonneneSpiele(person);
                            anzahlSpiele.Attributes["value"] = getAnzahlSpiele(person);

                            anzahlVereine.Disabled = false;
                            anzahlJahre.Disabled = false;
                            gewonneneSpiele.Disabled = false;
                            anzahlSpiele.Disabled = false;
                        }
                        else if (getSportart(person) == "Trainer") {
                            anzahlJahre.Attributes["value"] = getAnzahlJahre(person);

                            anzahlJahre.Disabled = false;
                        }
                        else if (getSportart(person) == "Physiotherapeut") { }
                    }
                }

                TableRow neueZeile = new TableRow();
                TableCell neueEditZelle = new TableCell();
                neueEditZelle.Text = this.Verwalter.Personen[this.Verwalter.EditPersonIndex - 1].ID.ToString();

                neueZeile.Cells.Add(neueEditZelle);

                neueEditZelle = new TableCell();
                Button accBtn = new Button();
                accBtn.ID = "acc" + this.Verwalter.EditPersonIndex;
                accBtn.Text = "Speichern";
                accBtn.Click += accBtn_Click;
                accBtn.CssClass = "btn-info";
                neueEditZelle.Controls.Add(accBtn);
                neueZeile.Cells.Add(neueEditZelle);

                this.Table1.Rows.Add(neueZeile);
            }
        }

        public void disableAndClearInputs() {
            name.Disabled = true;
            name.Value = "";
            vorname.Disabled = true;
            vorname.Value = "";
            geburtstag.Disabled = true;
            geburtstag.Value = "";
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

        public void disableAllRadioButtons() {
            foreach (ListItem radioButton in RadioButtonList1.Items) {
                radioButton.Enabled = false;
            }
        }

        public void enableAllRadioButtons() {
            foreach (ListItem radioButton in RadioButtonList1.Items) {
                radioButton.Enabled = true;
            }
        }

        public string getErzielteTore(Person p) {
            if (p is FussballSpieler) {
                return ((FussballSpieler)p).GeschosseneTore.ToString();
            }
            else if (p is HandballSpieler) {
                return ((HandballSpieler)p).GeworfeneTore.ToString();
            }
            else {
                return "";
            }
        }

        public string getSchlaeger(Person p) {
            if (p is TennisSpieler) {
                return ((TennisSpieler)p).Schlaeger;
            }
            else {
                return "";
            }
        }

        public string getAufschlaggeschwindigkeit(Person p) {
            if (p is TennisSpieler) {
                return ((TennisSpieler)p).Aufschlaggeschwindigkeit.ToString();
            }
            else {
                return "";
            }
        }

        public string getGewonneneSpiele(Person p) {
            if (p is Spieler) {
                return ((Spieler)p).GewonneneSpiele.ToString();
            }
            else {
                return "";
            }
        }

        public string getAnzahlJahre(Person p) {
            if (p is Trainer) {
                return ((Trainer)p).Erfahrung.ToString();
            }
            else if (p is Spieler) {
                return ((Spieler)p).AnzahlJahre.ToString();
            }
            else {
                return "";
            }
        }

        public string getRolle(Person p) {
            if (p is FussballSpieler) {
                return ((FussballSpieler)p).Position;
            }
            else if (p is HandballSpieler) {
                return ((HandballSpieler)p).Position;
            }
            else if (p is TennisSpieler) {
                return ((TennisSpieler)p).Schlaeger + " " + ((TennisSpieler)p).Aufschlaggeschwindigkeit + "km/h";
            }
            else {
                return "";
            }
        }

        public string getAnzahlSpiele(Person p) {
            if (p is Spieler) {
                return ((Spieler)p).AnzahlSpiele.ToString();
            }
            else {
                return "";
            }
        }

        public string getAnzahlVereine(Person p) {
            if (p is Spieler) {
                return ((Spieler)p).AnzahlVereine.ToString();
            }
            else {
                return "";
            }
        }

        public string getSportart(Person p) {
            if (p is Spieler) {
                return ((Spieler)p).SportArt;
            }
            else {
                string type = p.GetType().ToString();
                string[] array = type.Split('.');
                return array[1];
            }
        }
        #endregion
    }
}