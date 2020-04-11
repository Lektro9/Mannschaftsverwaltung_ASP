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
        List<string> _anerkennungen; //Ärztliche Annerkennungen, Erfolge, etc.
        #endregion

        #region Accessoren/Modifier
        public List<string> Anerkennungen { get => _anerkennungen; set => _anerkennungen = value; }
        #endregion

        #region Konstruktoren
        public Physiotherapeut() : base()
        {
            Anerkennungen = null;
        }
        //Spezialkonstruktor
        public Physiotherapeut(List<string> anerkennungen) : base()
        {
            Anerkennungen = anerkennungen;
        }

        public Physiotherapeut(string name, string vorname, int alter) : base(name, vorname, alter)
        {
            Anerkennungen = null;
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

        public override int compareByName(Person p)
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
        #endregion

        #region Schnittstellen
        #endregion
    }
}
