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
        public Trainer(string name, string vorname, int alter, int erfahrung) : base(name, vorname, alter)
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
