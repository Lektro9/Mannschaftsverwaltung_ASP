﻿//Autor:        Kroll
//Datum:        11.02.2020
//Dateiname:    FussballSpieler.cs
//Beschreibung: Klasse für den einzelnen FussballSpieler
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
    public class FussballSpieler : Spieler
    {
        #region Eigenschaften
        string _position;
        int geschosseneTore; //in einem Turnier
        #endregion

        #region Accessoren/Modifier
        public string Position { get => _position; set => _position = value; }
        public int GeschosseneTore { get => geschosseneTore; set => geschosseneTore = value; }
        #endregion

        #region Konstruktoren
        public FussballSpieler() : base()
        {
            Position = null;
            geschosseneTore = -1;
        }
        //Spezialkonstruktor
        public FussballSpieler(string position, int geschosseneTore) : base()
        {
            Position = position;
            GeschosseneTore = geschosseneTore;
        }

        public FussballSpieler(int id, string name, string vorname, DateTime geburtstag, string position, int geschosseneTore, int anzahlJahre = 0, int gewonneneSpiele = 0, int anzahlVereine = 0, int anzahlSpiele = 0) : base(id, name, vorname, geburtstag, anzahlJahre: anzahlJahre, gewonneneSpiele: gewonneneSpiele, anzahlVereine: anzahlVereine, anzahlSpiele: anzahlSpiele)
        {
            Position = position;
            GeschosseneTore = geschosseneTore;
        }
        //Kopierkonstruktor
        public FussballSpieler(FussballSpieler f) : base(f)
        {
            Position = f.Position;
            geschosseneTore = f.geschosseneTore;
        }

        #endregion

        #region Worker
        public string gebePositionsStatistik()
        {
            string retVal = this.Name + " hat in diesem Turnier " + this.geschosseneTore + " Tore erzielt von der Position " + this.Position;
            return retVal;
        }
        public override string spielen()
        {
            string retVal = "Der Fussballer spielt.";
            return retVal;
        }

        public override int compareByErfolg(Spieler s)
        {
            FussballSpieler f = (FussballSpieler)s;
            int retVal;
            if (GeschosseneTore > f.GeschosseneTore)
            {
                retVal = 1;
            }
            else if (GeschosseneTore == f.GeschosseneTore)
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

        #region Database
        #endregion

        #region Schnittstellen
        #endregion
    }
}
