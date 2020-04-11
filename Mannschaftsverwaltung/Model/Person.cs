//Autor:        Kroll
//Datum:        11.02.2020
//Dateiname:    Person.cs
//Beschreibung: Klasse Personen die als Basisklasse aller Spieler/Trainer/Ärzte dient
//Änderungen:
//11.02.2020:   Entwicklungsbeginn
//Basisklasse
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mannschaftsverwaltung
{
    public abstract class Person
    {
        #region Eigenschaften
        string _name;
        string _vorname;
        int _alter;
        string _rolle;
        #endregion

        #region Accessoren/Modifier
        public string Name { get => _name; set => _name = value; }
        public int Alter { get => _alter; set => _alter = value; }
        public string Rolle { get => _rolle; set => _rolle = value; }
        public string Vorname { get => _vorname; set => _vorname = value; }
        #endregion

        #region Konstruktoren
        public Person()
        {
            this.Name = "niemand";
            this.Alter = -1;
            this.Rolle = "nichts";
        }

        //Spezialkonstruktor
        public Person(string Name, string Vorname, int Alter)
        {
            this.Vorname = Vorname;
            this.Name = Name;
            this.Alter = Alter;
            this.Rolle = null;
        }
        public Person(string Name, int Alter, string Rolle)
        {
            this.Name = Name;
            this.Alter = Alter;
            this.Rolle = Rolle;
        }
        //Kopierkonstruktor
        public Person(Person p)
        {
            this.Name = p.Name;
            this.Alter = p.Alter;
            this.Rolle = p.Rolle;
        }
        #endregion

        #region Worker
        public string aendereRolle(string r)
        {
            string retVal = this.Rolle;
            this.Rolle = r;
            return retVal;
        }
        public abstract int compareByName(Person p);
        #endregion

        #region Schnittstellen
        #endregion
    }
}
