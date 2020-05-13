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
        DateTime _geburtstag;
        string _rolle;
        int _iD;
        #endregion

        #region Accessoren/Modifier
        public string Name { get => _name; set => _name = value; }
        public DateTime Geburtstag { get => _geburtstag; set => _geburtstag = value; }
        public string Rolle { get => _rolle; set => _rolle = value; }
        public string Vorname { get => _vorname; set => _vorname = value; }
        public int ID { get => _iD; set => _iD = value; }
        #endregion

        #region Konstruktoren
        public Person()
        {
            this.Name = "niemand";
            this.Geburtstag = new DateTime();
            this.Rolle = "nichts";
        }

        //Spezialkonstruktor
        public Person(int Id, string Name, string Vorname, DateTime Geburtstag)
        {
            this.Vorname = Vorname;
            this.Name = Name;
            this.Geburtstag = Geburtstag;
            this.Rolle = null;
            this.ID = Id;
        }
        public Person(string Name, DateTime Geburtstag, string Rolle)
        {
            this.Name = Name;
            this.Geburtstag = Geburtstag;
            this.Rolle = Rolle;
        }
        //Kopierkonstruktor
        public Person(Person p)
        {
            this.Name = p.Name;
            this.Geburtstag = p.Geburtstag;
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

        public int compareByName(Person p)
        {
            int retVal;
            if (Name[0] > p.Name[0])
            {
                retVal = 1;
            }
            else if (Name[0] == p.Name[0])
            {
                retVal = 0;
            }
            else
            {
                retVal = -1;
            }
            return retVal;
        }

        public int compareByBirthday(Person p)
        {
            int retVal;
            if (Geburtstag > p.Geburtstag)
            {
                retVal = 1;
            }
            else if (Geburtstag == p.Geburtstag)
            {
                retVal = 0;
            }
            else
            {
                retVal = -1;
            }
            return retVal;
        }
        #endregion

        #region Datenbank
        public abstract bool createPerson();
        public abstract bool editPerson();
        public abstract bool deletePerson();
        #endregion
    }
}
