//Autor:        Kroll
//Datum:        06.02.2020
//Dateiname:    Turnier.cs
//Beschreibung: Definierung eines Tunieres im Sport
//Basisklasse
//Änderungen:
//11.02.2020:   Entwicklungsbeginn

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mannschaftsverwaltung
{
    public class Spiel
    {
        #region Eigenschaften
        int _iD;
        int _team1ID;
        int _team2ID;
        int _team1Punkte;
        int _team2Punkte;
        //TODO: int _turnierID;
        #endregion

        #region Accessoren/Modifier
        public int ID { get => _iD; set => _iD = value; }
        public int Team1ID { get => _team1ID; set => _team1ID = value; }
        public int Team2ID { get => _team2ID; set => _team2ID = value; }
        public int Team1Punkte { get => _team1Punkte; set => _team1Punkte = value; }
        public int Team2Punkte { get => _team2Punkte; set => _team2Punkte = value; }
        #endregion

        #region Konstruktoren
        public Spiel()
        {
            ID = -1;
            Team1ID = -1;
            Team2ID = -1;
            Team1Punkte = -1;
            Team2Punkte = -1;
        }
        //Spezialkonstruktor
        public Spiel(int id, int team1id, int team2id, int team1Punkte, int team2Punkte)
        {
            this.ID = id;
            this.Team1ID = team1id;
            this.Team2ID = team2id;
            this.Team1Punkte = team1Punkte;
            this.Team2Punkte = team2Punkte;

        }
        //Kopierkonstruktor
        public Spiel(Spiel s)
        {
            this.ID = s.ID;
            this.Team1ID = s.Team1ID;
            this.Team2ID = s.Team2ID;
            this.Team1Punkte = s.Team1Punkte;
            this.Team2Punkte = s.Team2Punkte;
        }
        #endregion

        #region Worker
        public int showWinner()
        {
            int retVal;
            if (this.Team1Punkte > this.Team2Punkte)
            {
                retVal = Team1ID;
            }
            else if (this.Team1Punkte < this.Team2Punkte)
            {
                retVal = Team2ID;
            }
            else
            {
                retVal = -1; //unentschieden
            }

            return retVal;
        }

        public int showLoser()
        {
            int retVal;
            if (this.Team1Punkte > this.Team2Punkte)
            {
                retVal = Team2ID;
            }
            else if (this.Team1Punkte < this.Team2Punkte)
            {
                retVal = Team1ID;
            }
            else
            {
                retVal = -1; //unentschieden
            }

            return retVal;
        }
        #endregion

        #region Schnittstellen
        #endregion
    }
}