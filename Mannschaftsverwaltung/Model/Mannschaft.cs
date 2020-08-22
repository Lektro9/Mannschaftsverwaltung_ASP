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
        int _iD;
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
        public int ID { get => _iD; set => _iD = value; }
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
        public Mannschaft(int id, string sportart, Verein verein, List<Person> personen)
        {
            Sportart = sportart;
            Verein = verein;
            Personen = personen;
            pruefeListeAufSpieler();
            ID = id;
            GewSpiele = 0;
            Unentschieden = 0;
            VerlSpiele = 0;
            ErzielteTore = 0;
            GegnerischeTore = 0;
        }
        public Mannschaft(List<Person> personen) : this()
        {
            Personen = personen;
            pruefeListeAufSpieler();
        }

        public Mannschaft(int id, string name, string sportart, List<Person> personen)
        {
            Name = name;
            Sportart = sportart;
            Personen = personen;
            SortBy = -1;
            GewSpiele = 0;
            Unentschieden = 0;
            VerlSpiele = 0;
            ErzielteTore = 0;
            GegnerischeTore = 0;
            AnzahlSpieler = personen.Count;
            ID = id;
        }

        public Mannschaft(int id, string name, string sportart)
        {
            Name = name;
            Sportart = sportart;
            Personen = new List<Person>();
            SortBy = -1;
            GewSpiele = 0;
            Unentschieden = 0;
            VerlSpiele = 0;
            ErzielteTore = 0;
            GegnerischeTore = 0;
            AnzahlSpieler = Personen.Count;
            ID = id;
        }

        public Mannschaft(int id, string name, List<Person> personen)
        {
            Name = name;
            Sportart = "";
            Personen = personen;
            SortBy = -1;
            GewSpiele = 0;
            Unentschieden = 0;
            VerlSpiele = 0;
            ErzielteTore = 0;
            GegnerischeTore = 0;
            AnzahlSpieler = personen.Count;
            ID = id;
        }
        #endregion

        #region Worker
        public void fuegePersonHinzu(Person p)
        {
            this.Personen.Add(p);
            pruefeListeAufSpieler();
        }

        public void RemovePerson(int id)
        {
            List<Person> DeleteList = new List<Person>();
            foreach (Person p in this.Personen)
            {
                if (p.ID == id)
                {
                    DeleteList.Add(p);
                }
            }
            //take them out
            foreach (Person p in DeleteList)
            {
                this.Personen.Remove(p);
            }
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
