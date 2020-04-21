//Autor:        Kroll
//Datum:        11.02.2020
//Dateiname:    Trainer.cs
//Beschreibung: Trainer für die Mannschaften/Vereine
//Änderungen:
//11.02.2020:   Entwicklungsbeginn
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mannschaftsverwaltung
{
    public class Trainer : Person
    {
        #region Eigenschaften
        int _erfahrung; //in Jahren
        #endregion

        #region Accessoren/Modifier
        public int Erfahrung { get => _erfahrung; set => _erfahrung = value; }
        #endregion

        #region Konstruktoren
        public Trainer() : base()
        {
            Erfahrung = -1;
        }
        //Spezialkonstruktor
        public Trainer(int erfahrung) : base()
        {
            Erfahrung = erfahrung;
        }
        public Trainer(int id, string name, string vorname, DateTime geburtstag, int erfahrung) : base(id, name, vorname, geburtstag)
        {
            Erfahrung = erfahrung;
        }
        //Kopierkonstruktor
        public Trainer(Trainer t) : base(t)
        {
            Erfahrung = t.Erfahrung;
        }
        #endregion

        #region Worker
        public string gebeFeedback(string fb)
        {
            string retVal = "Trainer " + this.Name + " gibt folgendes Feedback: " + fb;
            return retVal;
        }
        #endregion

        #region Schnittstellen
        #endregion
    }
}
