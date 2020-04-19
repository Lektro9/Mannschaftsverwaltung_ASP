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
        int _gewonneneSpiele;
        int _anzahlJahre;
        int _anzahlSpiele;
        int _anzahlVereine;        
        #endregion

        #region Accessoren/Modifier
        public string SportArt { get => _sportArt; set => _sportArt = value; }
        public int GewonneneSpiele { get => _gewonneneSpiele; set => _gewonneneSpiele = value; }
        public int AnzahlJahre { get => _anzahlJahre; set => _anzahlJahre = value; }
        public int AnzahlSpiele { get => _anzahlSpiele; set => _anzahlSpiele = value; }
        public int AnzahlVereine { get => _anzahlVereine; set => _anzahlVereine = value; }
        #endregion

        #region Konstruktoren
        public Spieler() : base()
        {
            if (this is FussballSpieler)
            {
                SportArt = "Fusball";
            }
            else if (this is HandballSpieler)
            {
                SportArt = "Handball";
            }
            else if (this is TennisSpieler)
            {
                SportArt = "Tennis";
            }
            else
            {
                SportArt = null;
            }
        }
        //Spezialkonstruktor
        public Spieler(string name, string vorname, DateTime geburtstag, int gewonneneSpiele = -1, int anzahlJahre = 0, int anzahlSpiele = 0, int anzahlVereine = 0) : base(name, vorname, geburtstag)
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
            this.GewonneneSpiele = gewonneneSpiele;
            this.AnzahlJahre = anzahlJahre;
            this.AnzahlSpiele = anzahlSpiele;
            this.AnzahlVereine = anzahlVereine;
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
