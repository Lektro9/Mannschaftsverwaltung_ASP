//Autor:        Kroll
//Datum:        11.02.2020
//Dateiname:    TennisSpieler.cs
//Beschreibung: Klasse für den einzelnen TennisSpieler
//Änderungen:   
//11.02.2020:   Entwicklungsbeginn

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mannschaftsverwaltung
{
    public class TennisSpieler : Spieler
    {
        #region Eigenschaften
        string _schlaeger; //welcher Schläger nutzt der Tennisspieler?
        int _aufschlaggeschwindigkeit; //Durchschnittl. Aufschlaggeschw. in km/h


        #endregion

        #region Accessoren/Modifier
        public string Schlaeger { get => _schlaeger; set => _schlaeger = value; }
        public int Aufschlaggeschwindigkeit { get => _aufschlaggeschwindigkeit; set => _aufschlaggeschwindigkeit = value; }
        #endregion

        #region Konstruktoren
        public TennisSpieler() : base()
        {
            Schlaeger = null;
            Aufschlaggeschwindigkeit = -1;
            GewonneneSpiele = -1;
        }
        //Spezialkonstruktor
        public TennisSpieler(int id, string name, string vorname, DateTime geburtstag, int aufschlaggeschwindigkeit, string schlaeger = "Wilson 9000", int anzahlJahre = 0, int gewonneneSpiele = 0, int anzahlVereine = 0, int anzahlSpiele = 0) : base(id, name, vorname, geburtstag, anzahlJahre: anzahlJahre, gewonneneSpiele: gewonneneSpiele, anzahlVereine: anzahlVereine, anzahlSpiele: anzahlSpiele)
        {
            Schlaeger = schlaeger;
            Aufschlaggeschwindigkeit = aufschlaggeschwindigkeit;
        }
        #endregion

        #region Worker
        public string wechselSchlaeger(string s)
        {
            string retVal = this.Schlaeger;
            this.Schlaeger = s;
            return retVal;
        }
        public override string spielen()
        {
            string retVal = "Der Tennisspieler spielt.";
            return retVal;
        }

        public override int compareByErfolg(Spieler t)
        {
            int retVal;
            if (GewonneneSpiele > t.GewonneneSpiele)
            {
                retVal = 1;
            }
            else if (GewonneneSpiele == t.GewonneneSpiele)
            {
                retVal = 0;
            }
            else
            {
                retVal = -1;
            }
            return retVal;
        }

        public override bool createPersonInDB(User activeUser)
        {
            DataManager DBManager = new DataManager();

            DBManager.openDBConection();
            bool retVal = DBManager.createPerson(this, activeUser);
            DBManager.closeConnection();

            return retVal;
        }

        public override bool editPerson()
        {
            DataManager DBManager = new DataManager();

            DBManager.openDBConection();
            bool retVal = DBManager.editPerson(this);
            DBManager.closeConnection();

            return retVal;
        }

        public override bool deletePerson()
        {
            DataManager DBManager = new DataManager();

            DBManager.openDBConection();
            bool retVal = DBManager.removePerson(this);
            DBManager.closeConnection();

            return retVal;
        }
        #endregion

        #region Schnittstellen
        #endregion
    }
}
