//Autor:        Kroll
//Datum:        11.02.2020
//Dateiname:    Mannschaft.cs
//Beschreibung: Definition einer Mannschaft in Zusammenhang des Turnieres
//Änderungen:
//11.02.2020:   Entwicklungsbeginn

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mannschaftsverwaltung
{
    public class Mannschaft
    {
        #region Eigenschaften
        Verein _verein;
        string _sportart;
        List<Person> _personen;
        int _anzahlSpieler;
        int _sortBy; //1 = BubbleSort
        #endregion

        #region Accessoren/Modifier
        public string Sportart { get => _sportart; set => _sportart = value; }
        public Verein Verein { get => _verein; set => _verein = value; }
        public List<Person> Personen { get => _personen; set => _personen = value; }
        public int AnzahlSpieler { get => _anzahlSpieler; set => _anzahlSpieler = value; }
        public int SortBy { get => _sortBy; set => _sortBy = value; }
        #endregion

        #region Konstruktoren
        public Mannschaft()
        {
            Sportart = null;
            Verein = null;
            Personen = null;
            AnzahlSpieler = 0;
            SortBy = 1;
        }
        //Spezialkonstruktor
        public Mannschaft(string sportart, Verein verein, List<Person> personen)
        {
            Sportart = sportart;
            Verein = verein;
            Personen = personen;
            pruefeListeAufSpieler();
        }
        public Mannschaft(List<Person> personen) : this()
        {
            Personen = personen;
            pruefeListeAufSpieler();
        }
        #endregion

        #region Worker
        public void fuegePersonHinzu(Person p)
        {
            this.Personen.Add(p);
            pruefeListeAufSpieler();
        }

        private void pruefeListeAufSpieler()
        {
            AnzahlSpieler = 0;
            for (int i = 0; i < Personen.Count; i++)
            {
                if (Personen[i] is Spieler)
                {
                    AnzahlSpieler++;
                }
            }
        }
        public string gebeSpielerAus()
        {
            string retVal = "";
            if (Personen != null)
            {
                for (int i = 0; i < Personen.Count; i++)
                {
                    if (Personen[i] is Spieler)
                    {
                        retVal += Personen[i].Name + "\n";
                    }
                }
            }
            return retVal;
        }

        private List<Person> sortiereNachErfolg(List<Person> unsortierteListe)
        {
            List<Person> retVal = unsortierteListe;
            List<Person> nichtSpieler = new List<Person>();

            //Alle Nichtspieler Typen entfernen
            for (int i = 0; i < retVal.Count; i++)
            {
                if (retVal[i].GetType().IsSubclassOf(typeof(Spieler)) == false)
                {
                    nichtSpieler.Add(retVal[i]);
                }
            }

            for (int i = 0; i < nichtSpieler.Count; i++)
            {
                retVal.Remove(nichtSpieler[i]);
            }

            //Spieler sortieren
            bool fertig = false;
            while (fertig == false)
            {
                fertig = true;
                for (int i = 0; i < retVal.Count - 1; i++)
                {
                    if (((Spieler)retVal[i]).compareByErfolg((Spieler)retVal[i + 1]) < 0)
                    {
                        Person temp = retVal[i];
                        retVal[i] = retVal[i + 1];
                        retVal[i + 1] = temp;
                        fertig = false;
                    }
                }
            }

            //Nichtspieler wieder hinzufügen
            for (int i = 0; i < nichtSpieler.Count; i++)
            {
                retVal.Add(nichtSpieler[i]);
            }
            return retVal;
        }

        private List<Person> sortiereNachName(List<Person> unsortierteListe)
        {
            List<Person> retVal = unsortierteListe;

            //Alle nach Namen sortieren
            bool fertig = false;
            while (fertig == false)
            {
                fertig = true;
                for (int i = 0; i < retVal.Count - 1; i++)
                {
                    if (retVal[i].compareByName(retVal[i + 1]) < 0)
                    {
                        Person temp = retVal[i];
                        retVal[i] = retVal[i + 1];
                        retVal[i + 1] = temp;
                        fertig = false;
                    }
                }
            }
            return retVal;
        }

        public List<Person> sortiere()
        {
            List<Person> retVal = new List<Person>(Personen);
            if (SortBy == 1)
            {
                sortiereNachErfolg(retVal);
            }
            else if (SortBy == 2)
            {
                sortiereNachName(retVal);
            }
            return retVal;
        }
        #endregion

        #region Schnittstellen
        #endregion
    }
}
