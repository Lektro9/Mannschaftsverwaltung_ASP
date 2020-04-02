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
            this.Sportarten = new List<string>() { "Fussball", "Handball" };
        }
        #endregion

        #region Worker

        #endregion

        #region Schnittstellen
        #endregion
    }
}