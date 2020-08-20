//Autor:        Kroll
//Datum:        21.04.2020
//Dateiname:    Personenverwaltung.aspx.cs
//Beschreibung: Personen verwalten

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

namespace Mannschaftsverwaltung
{
    public partial class _Default : Page
    {
        private Controller _Verwalter;
        private string _auswahl;
        private TextBox _nameEdit;
        private TextBox _vornameEdit;
        private TextBox _geburtsDatEdit;
        private TextBox _anzahlSpieleEdit;
        private TextBox _erzielteToreEdit;
        private TextBox _gewSpieleEdit;
        private TextBox _anzJahreEdit;
        private TextBox _anzVereineEdit;
        private TextBox _einsatzEdit;


        public Controller Verwalter { get => _Verwalter; set => _Verwalter = value; }
        public string Auswahl { get => _auswahl; set => _auswahl = value; }
        public TextBox NameEdit { get => _nameEdit; set => _nameEdit = value; }
        public TextBox VornameEdit { get => _vornameEdit; set => _vornameEdit = value; }
        public TextBox GeburtsDatEdit { get => _geburtsDatEdit; set => _geburtsDatEdit = value; }
        public TextBox AnzahlSpieleEdit { get => _anzahlSpieleEdit; set => _anzahlSpieleEdit = value; }
        public TextBox ErzielteToreEdit { get => _erzielteToreEdit; set => _erzielteToreEdit = value; }
        public TextBox GewSpieleEdit { get => _gewSpieleEdit; set => _gewSpieleEdit = value; }
        public TextBox AnzJahreEdit { get => _anzJahreEdit; set => _anzJahreEdit = value; }
        public TextBox AnzVereineEdit { get => _anzVereineEdit; set => _anzVereineEdit = value; }
        public TextBox EinsatzEdit { get => _einsatzEdit; set => _einsatzEdit = value; }

        protected void Page_Init(object sender, EventArgs e)
        {

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["Verwalter"] != null)
            {
                Verwalter = (Controller)this.Session["Verwalter"];
                if (this.Verwalter.ActiveUser != null)
                {
                    Verwalter = (Controller)this.Session[this.Verwalter.ActiveUser.ID.ToString()];
                    this.Verwalter.Personen = Verwalter.getAllPerson(this.Verwalter.ActiveUser);
                    this.Verwalter.DBStatus = true;
                }
                else
                {
                    this.Response.Redirect(@"~\Views\Login.aspx");
                }
            }
            else
            {
                //this.Session["Verwalter"] = new Controller();
                //Verwalter = (Controller)this.Session["Verwalter"];
                //FussballSpieler p1 = new FussballSpieler(1, "Shidoski", "Klaus", DateTime.ParseExact("02-01-1993", "dd-MM-yyyy", CultureInfo.InvariantCulture), "Stürmer", 23, anzahlJahre: 1, anzahlSpiele: 32, anzahlVereine: 2, gewonneneSpiele: 2);
                //FussballSpieler p2 = new FussballSpieler(2, "Johnsons", "Dennis", DateTime.ParseExact("02-01-1993", "dd-MM-yyyy", CultureInfo.InvariantCulture), "Stürmer", 25, anzahlJahre: 6, anzahlSpiele: 567, anzahlVereine: 2, gewonneneSpiele: 234);
                //FussballSpieler p4 = new FussballSpieler(3, "Redgrave", "Vergil", DateTime.ParseExact("03-01-1993", "dd-MM-yyyy", CultureInfo.InvariantCulture), "Stürmer", 857, anzahlJahre: 2, anzahlSpiele: 234, anzahlVereine: 5, gewonneneSpiele: 65);
                //FussballSpieler p5 = new FussballSpieler(4, "Redgrave", "Dante", DateTime.ParseExact("04-01-1993", "dd-MM-yyyy", CultureInfo.InvariantCulture), "Stürmer", 900, anzahlJahre: 8, anzahlSpiele: 199, anzahlVereine: 6, gewonneneSpiele: 4);
                //FussballSpieler p6 = new FussballSpieler(5, "Son", "Goku", DateTime.ParseExact("05-02-1993", "dd-MM-yyyy", CultureInfo.InvariantCulture), "Stürmer", 1010, anzahlJahre: 9, anzahlSpiele: 23, anzahlVereine: 1, gewonneneSpiele: 16);
                //Trainer t1 = new Trainer(6, "Taylor", "Tom", DateTime.ParseExact("01-01-1993", "dd-MM-yyyy", CultureInfo.InvariantCulture), 23);

                //HandballSpieler h1 = new HandballSpieler(7, "Ball", "Bernd", DateTime.ParseExact("01-03-1995", "dd-MM-yyyy", CultureInfo.InvariantCulture), "Verteidiger", 3, anzahlJahre: 2, anzahlSpiele: 77, anzahlVereine: 8, gewonneneSpiele: 56);
                //HandballSpieler h3 = new HandballSpieler(8, "Potter", "Harry", DateTime.ParseExact("16-07-1999", "dd-MM-yyyy", CultureInfo.InvariantCulture), "Stürmer", 25, anzahlJahre: 4, anzahlSpiele: 182, anzahlVereine: 1, gewonneneSpiele: 245);
                //HandballSpieler h2 = new HandballSpieler(9, "Dohnson", "Henry", DateTime.ParseExact("12-06-1963", "dd-MM-yyyy", CultureInfo.InvariantCulture), "Stürmer", 16, anzahlJahre: 6, anzahlSpiele: 90, anzahlVereine: 2, gewonneneSpiele: 78);
                //HandballSpieler h4 = new HandballSpieler(10, "Hamper", "Holly", DateTime.ParseExact("05-01-1995", "dd-MM-yyyy", CultureInfo.InvariantCulture), "Mittelfeld", 17, anzahlJahre: 10, anzahlSpiele: 33, anzahlVereine: 3, gewonneneSpiele: 98);

                //TennisSpieler ts1 = new TennisSpieler(11, "Federer", "Roger", DateTime.ParseExact("01-12-2001", "dd-MM-yyyy", CultureInfo.InvariantCulture), 95, anzahlJahre: 12, anzahlSpiele: 2, anzahlVereine: 1, gewonneneSpiele: 23);

                //Physiotherapeut ph1 = new Physiotherapeut(12, "Denrasen", "Dr. med", DateTime.ParseExact("01-01-1993", "dd-MM-yyyy", CultureInfo.InvariantCulture), "Auszeichnung blabla");
                //Verwalter.Personen = new List<Person>() { p1, p2, p4, p5, p6, t1, h1, h2, h3, h4, ts1, ph1 };
                this.Response.Redirect(@"~\Views\Login.aspx");
            }
            LoadAllEditInputFields();
            LoadPersonen();

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            this.Auswahl = RadioButtonList1.SelectedValue;
            int index = RadioButtonList1.SelectedIndex;
            disableAndClearInputs();
            foreach (ListItem item in RadioButtonList1.Items)
            {
                item.Attributes.Add("class", "list-group-item list-group-item-action disabled");
            }
            if (Auswahl == "Fussballspieler")
            {
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
            else if (Auswahl == "Handballspieler")
            {
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
            else if (Auswahl == "Tennisspieler")
            {
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
            else if (Auswahl == "Trainer")
            {
                RadioButtonList1.SelectedIndex = index;
                RadioButtonList1.Items[RadioButtonList1.SelectedIndex].Attributes.Add("class", "list-group-item list-group-item-action active");
                name.Disabled = false;
                vorname.Disabled = false;
                geburtstag.Disabled = false;
                anzahlJahre.Disabled = false;
                this.Button3.Visible = true;
            }
            else if (Auswahl == "Physiotherapeut")
            {
                RadioButtonList1.SelectedIndex = index;
                RadioButtonList1.Items[RadioButtonList1.SelectedIndex].Attributes.Add("class", "list-group-item list-group-item-action active");
                name.Disabled = false;
                vorname.Disabled = false;
                geburtstag.Disabled = false;
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
                this.Verwalter.AddFussballSpieler(name.Value, vorname.Value, DateTime.Parse(geburtstag.Value), position.Value, Int32.Parse(geschosseneTore.Value), Int32.Parse(anzahlJahre.Value), Int32.Parse(gewonneneSpiele.Value), Int32.Parse(anzahlVereine.Value), Int32.Parse(anzahlSpiele.Value));
            }
            else if (this.Auswahl == "Handballspieler")
            {
                this.Verwalter.AddHandballSpieler(name.Value, vorname.Value, DateTime.Parse(geburtstag.Value), position.Value, Int32.Parse(geschosseneTore.Value), Int32.Parse(anzahlJahre.Value), Int32.Parse(gewonneneSpiele.Value), Int32.Parse(anzahlVereine.Value), Int32.Parse(anzahlSpiele.Value));
            }
            else if (this.Auswahl == "Tennisspieler")
            {
                this.Verwalter.AddTennisSpieler(name.Value, vorname.Value, DateTime.Parse(geburtstag.Value), Int32.Parse(aufschlagGeschw.Value), schlaeger.Value, Int32.Parse(anzahlJahre.Value), Int32.Parse(gewonneneSpiele.Value), Int32.Parse(anzahlVereine.Value), Int32.Parse(anzahlSpiele.Value));
            }
            else if (this.Auswahl == "Trainer")
            {
                this.Verwalter.AddTrainer(name.Value, vorname.Value, DateTime.Parse(geburtstag.Value), Int32.Parse(anzahlJahre.Value));
            }
            else
            {
                this.Verwalter.AddPhysio(name.Value, vorname.Value, DateTime.Parse(geburtstag.Value));
            }
            enableAllRadioButtons();
            disableAndClearInputs();
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
            if (this.Verwalter.DBStatus)
            {
                this.Verwalter.Personen[index - 1].deletePerson();
            }
            this.Verwalter.Personen.RemoveAt(index - 1);
            Response.Redirect(Request.RawUrl);
        }

        protected void accBtn_Click(object sender, EventArgs e)
        {
            int index = Int32.Parse(((Button)sender).ID.Substring(3));
            for (int i = 0; i <= this.Verwalter.Personen.Count; i++)
            {
                if (i == index)
                {
                    this.Verwalter.Personen[i - 1].Name = NameEdit.Text;
                    this.Verwalter.Personen[i - 1].Vorname = VornameEdit.Text;
                    this.Verwalter.Personen[i - 1].Geburtstag = DateTime.Parse(GeburtsDatEdit.Text);
                    if (this.Verwalter.Personen[i - 1] is Spieler)
                    {
                        ((Spieler)this.Verwalter.Personen[i - 1]).AnzahlSpiele = Int32.Parse(AnzahlSpieleEdit.Text);
                    }
                    if (this.Verwalter.Personen[i - 1] is FussballSpieler)
                    {
                        ((FussballSpieler)this.Verwalter.Personen[i - 1]).GeschosseneTore = Int32.Parse(ErzielteToreEdit.Text);
                    }
                    else if (this.Verwalter.Personen[i - 1] is HandballSpieler)
                    {
                        ((HandballSpieler)this.Verwalter.Personen[i - 1]).GeworfeneTore = Int32.Parse(ErzielteToreEdit.Text);
                    }
                    if (this.Verwalter.Personen[i - 1] is Spieler)
                    {
                        ((Spieler)this.Verwalter.Personen[i - 1]).GewonneneSpiele = Int32.Parse(GewSpieleEdit.Text);
                        ((Spieler)this.Verwalter.Personen[i - 1]).AnzahlJahre = Int32.Parse(AnzJahreEdit.Text);
                    }
                    else if (this.Verwalter.Personen[i - 1] is Trainer)
                    {
                        ((Trainer)this.Verwalter.Personen[i - 1]).Erfahrung = Int32.Parse(AnzJahreEdit.Text);
                    }
                    if (this.Verwalter.Personen[i - 1] is Spieler)
                    {
                        ((Spieler)this.Verwalter.Personen[i - 1]).AnzahlVereine = Int32.Parse(AnzVereineEdit.Text);
                    }
                    if (this.Verwalter.Personen[i - 1] is FussballSpieler)
                    {
                        ((FussballSpieler)this.Verwalter.Personen[i - 1]).Position = EinsatzEdit.Text;
                    }
                    else if (this.Verwalter.Personen[i - 1] is HandballSpieler)
                    {
                        ((HandballSpieler)this.Verwalter.Personen[i - 1]).Position = EinsatzEdit.Text;
                    }
                    if (this.Verwalter.DBStatus)
                    {
                        this.Verwalter.Personen[i - 1].editPerson();
                    }
                }
            }
            this.Verwalter.EditPerson = false;
            Response.Redirect(Request.RawUrl);
        }

        #region Worker

        protected void download_click(object sender, EventArgs e)
        {
            //string jsontext = new JavaScriptSerializer().Serialize(this.Verwalter.Personen);
            string jsontext = JsonConvert.SerializeObject(this.Verwalter);

            Response.AddHeader("Content-disposition", String.Format("attachment; filename={0}.json", "MannschaftsverwaltungSave"));
            Response.ContentType = "application/json";
            Response.Write(jsontext);

            Response.End();
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
            XmlSerializer x = new XmlSerializer(this.Verwalter.Personen.GetType(), types);
            StringWriter textWriter = new StringWriter();
            x.Serialize(textWriter, this.Verwalter.Personen);
            string allPers = textWriter.ToString();

            Response.AddHeader("Content-disposition", String.Format("attachment; filename={0}.xml", "MannschaftsverwaltungSave"));
            Response.ContentType = "application/xml";
            Response.Write(allPers);
            Response.End();
        }

        protected void upload_click(object sender, EventArgs e)
        {
            //Delete all Files in Uploads folder
            DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/Uploads/"));
            foreach (FileInfo file in di.GetFiles())
            {
                if (file.Name != Fileupload1.FileName)
                {
                    file.Delete();
                }
            }
            this.Fileupload1.SaveAs(Server.MapPath("~/Uploads/" + Fileupload1.FileName));
            Response.Write(this.Fileupload1);
            JsonConverter[] converters = { new PersonConverter() };
            Controller results = JsonConvert.DeserializeObject<Controller>(File.ReadAllText(Server.MapPath("~/Uploads/" + Fileupload1.FileName)), new JsonSerializerSettings() { Converters = converters });
            this.Verwalter.Personen = results.Personen;
            this.Verwalter.Mannschaften = results.Mannschaften;
            this.Verwalter.Turniere = results.Turniere;
        }

        protected void orderByName(object sender, EventArgs e)
        {
            this.Verwalter.ReverseSort = !this.Verwalter.ReverseSort;
            this.Verwalter.sortiereNachName();
            Response.Redirect(Request.RawUrl);
        }
        protected void orderByBirthday(object sender, EventArgs e)
        {
            this.Verwalter.ReverseSort = !this.Verwalter.ReverseSort;
            this.Verwalter.sortiereNachGeburtstag();
            Response.Redirect(Request.RawUrl);
        }
        protected void orderByGoals(object sender, EventArgs e)
        {
            this.Verwalter.ReverseSort = !this.Verwalter.ReverseSort;
            this.Verwalter.sortiereNachSpezEigenschaft();
            Response.Redirect(Request.RawUrl);
        }
        private void LoadAllEditInputFields()
        {
            NameEdit = new TextBox();
            NameEdit.ID = "nameEdit";

            VornameEdit = new TextBox();
            VornameEdit.ID = "vornameEdit";

            GeburtsDatEdit = new TextBox();
            GeburtsDatEdit.ID = "geburtsDatEdit";
            GeburtsDatEdit.Attributes["type"] = "date";

            AnzahlSpieleEdit = new TextBox();
            AnzahlSpieleEdit.ID = "anzSpieleEdit";
            AnzahlSpieleEdit.Attributes["type"] = "number";

            ErzielteToreEdit = new TextBox();
            ErzielteToreEdit.ID = "erzToreEdit";
            ErzielteToreEdit.Attributes["type"] = "number";

            GewSpieleEdit = new TextBox();
            GewSpieleEdit.ID = "gewSpieleEdit";
            GewSpieleEdit.Attributes["type"] = "number";

            AnzJahreEdit = new TextBox();
            AnzJahreEdit.ID = "anzJahreEdit";
            AnzJahreEdit.Attributes["type"] = "number";

            AnzVereineEdit = new TextBox();
            AnzVereineEdit.ID = "anzVereineEdit";
            AnzVereineEdit.Attributes["type"] = "number";

            EinsatzEdit = new TextBox();
            EinsatzEdit.ID = "einsatzEdit";

        }
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
                    NameEdit.Attributes["value"] = person.Name;
                    neueEditZelle.Controls.Add(NameEdit);
                    neueZeile.Cells.Add(neueEditZelle);

                    //Vorname
                    neueEditZelle = new TableCell();
                    VornameEdit.Attributes["value"] = person.Vorname;
                    neueEditZelle.Controls.Add(VornameEdit);
                    neueZeile.Cells.Add(neueEditZelle);

                    //Geburtsdatum
                    neueEditZelle = new TableCell();
                    GeburtsDatEdit.Attributes["value"] = person.Geburtstag.ToString("yyyy-MM-dd");
                    neueEditZelle.Controls.Add(GeburtsDatEdit);
                    neueZeile.Cells.Add(neueEditZelle);

                    //SportArt
                    neueEditZelle = new TableCell();
                    neueEditZelle.Text = getSportart(person);
                    neueZeile.Cells.Add(neueEditZelle);

                    //AnzahlSpiele
                    neueEditZelle = new TableCell();
                    AnzahlSpieleEdit.Attributes["value"] = getAnzahlSpiele(person);
                    neueEditZelle.Controls.Add(AnzahlSpieleEdit);
                    neueZeile.Cells.Add(neueEditZelle);

                    //Erziele Tore
                    neueEditZelle = new TableCell();
                    ErzielteToreEdit.Attributes["value"] = getErzielteTore(person);
                    neueEditZelle.Controls.Add(ErzielteToreEdit);
                    neueZeile.Cells.Add(neueEditZelle);

                    //Gewonnene Spiele
                    neueEditZelle = new TableCell();
                    GewSpieleEdit.Attributes["value"] = getGewonneneSpiele(person);
                    neueEditZelle.Controls.Add(GewSpieleEdit);
                    neueZeile.Cells.Add(neueEditZelle);

                    //Anzahl Jahre
                    neueEditZelle = new TableCell();
                    AnzJahreEdit.Attributes["value"] = getAnzahlJahre(person);
                    neueEditZelle.Controls.Add(AnzJahreEdit);
                    neueZeile.Cells.Add(neueEditZelle);

                    //Anzahl Vereine
                    neueEditZelle = new TableCell();
                    AnzVereineEdit.Attributes["value"] = getAnzahlVereine(person);
                    neueEditZelle.Controls.Add(AnzVereineEdit);
                    neueZeile.Cells.Add(neueEditZelle);

                    //Einsatzgebiet
                    neueEditZelle = new TableCell();
                    EinsatzEdit.Attributes["value"] = getRolle(person);
                    neueEditZelle.Controls.Add(EinsatzEdit);
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

                    if (this.Verwalter.ActiveUser.Rolle == Role.ADMIN)
                    {
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
        public void disableAllRadioButtons()
        {
            foreach (ListItem radioButton in RadioButtonList1.Items)
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