//Autor:        Kroll
//Datum:        11.02.2020
//Dateiname:    Physiotherapeut.cs
//Beschreibung: Definierung eines Tunieres im Sport
//Änderungen:
//11.02.2020:   Entwicklungsbeginn
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mannschaftsverwaltung
{
    public class Physiotherapeut : Person
    {
        #region Eigenschaften
        string _anerkennungen; //Ärztliche Annerkennungen, Erfolge, etc.
        #endregion

        #region Accessoren/Modifier
        public string Anerkennungen { get => _anerkennungen; set => _anerkennungen = value; }
        #endregion

        #region Konstruktoren
        public Physiotherapeut() : base()
        {
            Anerkennungen = null;
        }
        //Spezialkonstruktor
        public Physiotherapeut(string anerkennungen) : base()
        {
            Anerkennungen = anerkennungen;
        }

        public Physiotherapeut(int id, string name, string vorname, DateTime geburtstag, string anerkennungen = "nothing") : base(id, name, vorname, geburtstag)
        {
            Anerkennungen = anerkennungen;
        }
        //Kopierkonstruktor
        public Physiotherapeut(Physiotherapeut p) : base(p)
        {
            Anerkennungen = p.Anerkennungen;
        }
        #endregion

        #region Worker
        public string stelleAttestAus(Spieler s)
        {
            string retVal = "Der Physiotherapeut " + this.Name + " stellt ein Attest aus für den Spieler " + s.Name;
            return retVal;
        }
        #endregion

        #region Schnittstellen
        #endregion
    }
}
