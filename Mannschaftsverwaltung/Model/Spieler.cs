//Autor:        Kroll
//Datum:        11.02.2020
//Dateiname:    Spieler.cs
//Beschreibung: Klasse zur Identifizierung der einzelnen Spieler
//Änderungen:
//11.02.2020:   Entwicklungsbeginn
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mannschaftsverwaltung
{
    public abstract class Spieler : Person
    {
        #region Eigenschaften
        string _sportArt;

        
        #endregion

        #region Accessoren/Modifier
        public string SportArt { get => _sportArt; set => _sportArt = value; }
        #endregion

        #region Konstruktoren
        public Spieler() : base()
        {
            if (this is FussballSpieler)
            {
                SportArt = "FusballSpieler";
            }
            else if (this is HandballSpieler)
            {
                SportArt = "HandballSpieler";
            }
            else if (this is TennisSpieler)
            {
                SportArt = "TennisSpieler";
            }
            else
            {
                SportArt = null;
            }
        }
        //Spezialkonstruktor
        public Spieler(string name, int alter) : base(name, alter)
        {
            if (this is FussballSpieler)
            {
                SportArt = "FusballSpieler";
            }
            else if (this is HandballSpieler)
            {
                SportArt = "HandballSpieler";
            }
            else if (this is TennisSpieler)
            {
                SportArt = "TennisSpieler";
            }
            else
            {
                SportArt = null;
            }
        }
        public Spieler(int alter, string name) : base(alter, name)
        {
            if (this is FussballSpieler)
            {
                SportArt = "FusballSpieler";
            }
            else if (this is HandballSpieler)
            {
                SportArt = "HandballSpieler";
            }
            else if (this is TennisSpieler)
            {
                SportArt = "TennisSpieler";
            }
            else
            {
                SportArt = null;
            }
        }
        //Kopierkonstruktor
        public Spieler(Spieler s) : base(s)
        {
            SportArt = s.SportArt;
        }
        #endregion

        #region Worker

        public abstract string spielen();

        public abstract int compareByErfolg(Spieler s);
        #endregion

        #region Schnittstellen
        #endregion
    }
}
