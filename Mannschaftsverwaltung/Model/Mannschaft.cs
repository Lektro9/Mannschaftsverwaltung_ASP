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
        string _name;
        string _sportart;
        List<Person> _personen;
        int _anzahlSpieler;
        int _sortBy; //1 = BubbleSort
        int _gewSpiele;
        int _unentschieden;
        int _verlSpiele;
        int _erzielteTore;
        int _gegnerischeTore;
        #endregion

        #region Accessoren/Modifier
        public string Sportart { get => _sportart; set => _sportart = value; }
        public Verein Verein { get => _verein; set => _verein = value; }
        public List<Person> Personen { get => _personen; set => _personen = value; }
        public int AnzahlSpieler { get => _anzahlSpieler; set => _anzahlSpieler = value; }
        public int SortBy { get => _sortBy; set => _sortBy = value; }
        public int GewSpiele { get => _gewSpiele; set => _gewSpiele = value; }
        public int Unentschieden { get => _unentschieden; set => _unentschieden = value; }
        public int VerlSpiele { get => _verlSpiele; set => _verlSpiele = value; }
        public int ErzielteTore { get => _erzielteTore; set => _erzielteTore = value; }
        public int GegnerischeTore { get => _gegnerischeTore; set => _gegnerischeTore = value; }
        public string Name { get => _name; set => _name = value; }
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

        public Mannschaft(string name, string sportart, List<Person> personen, int gewSpiele, int unentschieden, int verlSpiele, int erzielteTore, int gegnerischeTore)
        {
            Name = name;
            Sportart = sportart;
            Personen = personen;
            SortBy = -1;
            GewSpiele = gewSpiele;
            Unentschieden = unentschieden;
            VerlSpiele = verlSpiele;
            ErzielteTore = erzielteTore;
            GegnerischeTore = gegnerischeTore;
            AnzahlSpieler = personen.Count;
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
        
        public int compareByName(Mannschaft m)
        {
            int retVal;
            if (Name[0] > m.Name[0])
            {
                retVal = 1;
            }
            else if (Name[0] == m.Name[0])
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
