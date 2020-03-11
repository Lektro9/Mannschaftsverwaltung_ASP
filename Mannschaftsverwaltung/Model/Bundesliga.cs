//Autor:        Kroll
//Datum:        06.02.2020
//Dateiname:    Bundesliga.cs
//Beschreibung: Bundesliga Klasse
//Änderungen:
//11.02.2020:   Entwicklungsbeginn


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mannschaftsverwaltung
{
    class Bundesliga : Turnier
    {
        #region Eigenschaften
        private string _sportart;
        private int _spieltag;


        #endregion

        #region Accessoren/Modifier
        public string Sportart { get => _sportart; set => _sportart = value; }
        public int Spieltag { get => _spieltag; set => _spieltag = value; }
        #endregion

        #region Konstruktoren
        public Bundesliga():base()
        {
            Sportart = "nichts";
            Spieltag = -1;
        }
        //Spezialkonstruktor
        public Bundesliga(int id, string sportart) : base(id)
        {
            this.Sportart = sportart;
            Spieltag = -1;
        }
        public Bundesliga(int id, string sportart, int spieltag) : base(id)
        {
            this.Sportart = sportart;
            this.Spieltag = spieltag;
        }
        //Kopierkonstruktor
        public Bundesliga(Bundesliga bl) : base(bl)
        {
            this.Sportart = bl.Sportart;
        }
        #endregion

        #region Worker
        public int zeigeAktuellenSpieltag()
        {
            int retVal = Spieltag;
            return retVal;
        }
        #endregion

        #region Schnittstellen
        #endregion
    }
}
