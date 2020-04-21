//Autor:        Kroll
//Datum:        02.11.2019
//Dateiname:    Controller.cs
//Beschreibung: Businesslogik für die Packstation
//Änderungen:
//02.04.2020:   Entwicklungsbeginn 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mannschaftsverwaltung
{
    public class Controller
    {
        #region Eigenschaften
        private List<Mannschaft> _Mannschaften;
        // private List<Gruppe> _Gruppen;
        private List<Person> _Personen;
        private Person _NeuesMitglied;
        private List<String> _Sportarten;
        private bool _EditPerson;
        private int _EditPersonIndex;
        private bool _MannschaftOderGruppe;
        private bool _MannschaftsAnzeige;

        #endregion

        #region Accessoren/Modifier
        public List<Mannschaft> Mannschaften { get => _Mannschaften; set => _Mannschaften = value; }
        public List<Person> Personen { get => _Personen; set => _Personen = value; }
        public Person NeuesMitglied { get => _NeuesMitglied; set => _NeuesMitglied = value; }
        public List<string> Sportarten { get => _Sportarten; set => _Sportarten = value; }
        public bool EditPerson { get => _EditPerson; set => _EditPerson = value; }
        public int EditPersonIndex { get => _EditPersonIndex; set => _EditPersonIndex = value; }
        public bool MannschaftOderGruppe { get => _MannschaftOderGruppe; set => _MannschaftOderGruppe = value; }
        public bool MannschaftsAnzeige { get => _MannschaftsAnzeige; set => _MannschaftsAnzeige = value; }
        #endregion

        #region Konstruktoren
        public Controller()
        {
            Mannschaften = new List<Mannschaft>();
            Personen = new List<Person>();
            NeuesMitglied = null;
            Sportarten = null;
            EditPerson = false;
            EditPersonIndex = -1;
            MannschaftOderGruppe = false;
            MannschaftsAnzeige = false;
        }
        #endregion

        #region Worker
        public static int generateID()
        {
            return Math.Abs(Guid.NewGuid().GetHashCode() / 10000);
        }

        internal void AddFussballSpieler(string name, string vorname, DateTime geburtstag, string position, int geschosseneTore, int anzahlJahre, int gewSpiele, int anzahlVereine, int anzahlSpiele)
        {
            int id = generateID();
            FussballSpieler f = new FussballSpieler(id, name, vorname, geburtstag, position, geschosseneTore, anzahlJahre, gewSpiele, anzahlVereine, anzahlSpiele);
            this.Personen.Add(f);
        }

        internal void AddHandballSpieler(string name, string vorname, DateTime geburtstag, string position, int geworfeneTore, int anzahlJahre, int gewSpiele, int anzahlVereine, int anzahlSpiele)
        {
            int id = generateID();
            HandballSpieler h = new HandballSpieler(id, name, vorname, geburtstag, position, geworfeneTore, anzahlJahre, gewSpiele, anzahlVereine, anzahlSpiele);
            this.Personen.Add(h);
        }

        internal void AddTennisSpieler(string name, string vorname, DateTime geburtstag, int aufschlagGeschw, string schlaeger, int anzahlJahre, int gewSpiele, int anzahlVereine, int anzahlSpiele)
        {
            int id = generateID();
            TennisSpieler t = new TennisSpieler(id, name, vorname, geburtstag, aufschlagGeschw, schlaeger, anzahlJahre, gewSpiele, anzahlVereine, anzahlSpiele);
            this.Personen.Add(t);
        }

        internal void createMannschaft(string name, string sportart, List<Person> personen, int gewSpiele, int unentschieden, int verlSpiele, int erzielteTore, int gegnerischeTore)
        {
            Mannschaft m = new Mannschaft(name, sportart, personen, gewSpiele, unentschieden, verlSpiele, erzielteTore, gegnerischeTore);
            this.Mannschaften.Add(m);
        }

        internal void AddTrainer(string name, string vorname, DateTime geburtstag, int anzahlJahre)
        {
            int id = generateID();
            Trainer t = new Trainer(id, name, vorname, geburtstag, anzahlJahre);
            this.Personen.Add(t);
        }

        internal void AddPhysio(string name, string vorname, DateTime geburtstag)
        {
            int id = generateID();
            Physiotherapeut p = new Physiotherapeut(id, name, vorname, geburtstag);
            this.Personen.Add(p);
        }
        #endregion

        #region Schnittstellen
        #endregion
    }
}