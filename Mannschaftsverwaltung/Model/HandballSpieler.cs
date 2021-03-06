﻿//Autor:        Kroll
//Datum:        11.02.2020
//Dateiname:    HandballSpieler.cs
//Beschreibung: Klasse für den einzelnen Handballspieler
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
    public class HandballSpieler : Spieler
    {
        #region Eigenschaften
        string _position;
        int _geworfeneTore;
        #endregion

        #region Accessoren/Modifier
        public string Position { get => _position; set => _position = value; }
        public int GeworfeneTore { get => _geworfeneTore; set => _geworfeneTore = value; }
        #endregion

        #region Konstruktoren
        public HandballSpieler() : base()
        {
            Position = null;
            GeworfeneTore = -1;
        }
        //Spezialkonstruktor
        public HandballSpieler(string position) : base()
        {
            Position = position;
            GeworfeneTore = -1;
        }

        public HandballSpieler(int id, string name, string vorname, DateTime geburtstag, string position, int geworfeneTore, int anzahlJahre = 0, int gewonneneSpiele = 0, int anzahlVereine = 0, int anzahlSpiele = 0) : base(id, name, vorname, geburtstag, anzahlJahre: anzahlJahre, gewonneneSpiele: gewonneneSpiele, anzahlVereine: anzahlVereine, anzahlSpiele: anzahlSpiele)
        {
            Position = position;
            GeworfeneTore = geworfeneTore;
        }

        //Kopierkonstruktor
        public HandballSpieler(HandballSpieler h) : base()
        {
            Position = h.Position;
        }
        #endregion

        #region Worker
        public string aenderePosition(string p)
        {
            string retVal = this.Position;
            Position = p;
            return retVal;
        }
        public override string spielen()
        {
            string retVal = "Der Handballer spielt.";
            return retVal;
        }

        public override int compareByErfolg(Spieler s)
        {
            HandballSpieler h = (HandballSpieler)s;
            int retVal;
            if (GeworfeneTore > h.GeworfeneTore)
            {
                retVal = 1;
            }
            else if (GeworfeneTore == h.GeworfeneTore)
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
