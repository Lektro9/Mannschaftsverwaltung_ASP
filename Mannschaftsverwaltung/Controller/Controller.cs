//Autor:        Kroll
//Datum:        02.11.2019
//Dateiname:    Controller.cs
//Beschreibung: Businesslogik für die Packstation
//Änderungen:
//02.04.2020:   Entwicklungsbeginn 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mannschaftsverwaltung
{
    public class Controller
    {
        #region Eigenschaften
        private List<Mannschaft> _Mannschaften;
        // private List<Gruppe> _Gruppen;
        private List<Person> _Personen;
        private Person _NeuesMitglied;
        private List<String> _Sportarten;
        private bool _EditPerson;
        private int _EditPersonIndex;
        private bool _EditMannschaft;
        private int _EditMannID;
        private int _EditMannIndex;
        private bool _MannschaftOderGruppe;
        private bool _MannschaftsAnzeige;
        private bool _reverseSort;
        VerwaltungsDAO _anbindung;
        List<Turnier> _turniere;
        

        #endregion

        #region Accessoren/Modifier
        public List<Mannschaft> Mannschaften { get => _Mannschaften; set => _Mannschaften = value; }
        public List<Person> Personen { get => _Personen; set => _Personen = value; }
        public Person NeuesMitglied { get => _NeuesMitglied; set => _NeuesMitglied = value; }
        public List<string> Sportarten { get => _Sportarten; set => _Sportarten = value; }
        public bool EditPerson { get => _EditPerson; set => _EditPerson = value; }
        public int EditPersonIndex { get => _EditPersonIndex; set => _EditPersonIndex = value; }
        public bool MannschaftOderGruppe { get => _MannschaftOderGruppe; set => _MannschaftOderGruppe = value; }
        public bool MannschaftsAnzeige { get => _MannschaftsAnzeige; set => _MannschaftsAnzeige = value; }
        public bool ReverseSort { get => _reverseSort; set => _reverseSort = value; }
        public VerwaltungsDAO Anbindung { get => _anbindung; set => _anbindung = value; }
        public bool EditMannschaft { get => _EditMannschaft; set => _EditMannschaft = value; }
        public int EditMannID { get => _EditMannID; set => _EditMannID = value; }
        public int EditMannIndex { get => _EditMannIndex; set => _EditMannIndex = value; }
        public List<Turnier> Turniere { get => _turniere; set => _turniere = value; }
        #endregion

        #region Konstruktoren
        public Controller()
        {
            Mannschaften = new List<Mannschaft>();
            Personen = new List<Person>();
            NeuesMitglied = null;
            Sportarten = null;
            EditPerson = false;
            EditPersonIndex = -1;
            EditMannschaft = false;
            EditMannID = -1;
            EditMannIndex = -1;
            MannschaftOderGruppe = false;
            MannschaftsAnzeige = false;
            ReverseSort = true;
            Anbindung = new VerwaltungsDAO();
            Turniere = new List<Turnier>();
        }
        #endregion

        #region Worker
        public static int generateID()
        {
            return Math.Abs(Guid.NewGuid().GetHashCode() / 10000);
        }

        internal void createGame(int TurnierIndex, int team1id, int team2id, int team1Punkte, int team2Punkte)
        {
            Spiel s = new Spiel(generateID(), team1id, team2id, team1Punkte, team2Punkte);
            this.Turniere[TurnierIndex].Spiele.Add(s);
            addMannschaftsStats(s);
        }

        internal void deleteGame(int TurnierIndex, Spiel s)
        {
            this.Turniere[TurnierIndex].Spiele.Remove(s);
            removeMannschaftsStats(s);
        }

        private void removeMannschaftsStats(Spiel s)
        {
            int winner = s.showWinner();
            int loser = s.showLoser();
            if (winner == -1 && loser == -1)
            {
                Mannschaft team1 = findMann(s.Team1ID);
                Mannschaft team2 = findMann(s.Team2ID);
                team1.Unentschieden -= 1;
                team2.Unentschieden -= 1;
                // Bei Unentschieden ist egal welche Punkte von welchem Team hinzugefügt werden
                team1.ErzielteTore -= s.Team1Punkte;
                team1.GegnerischeTore -= s.Team1Punkte;
                team2.ErzielteTore -= s.Team1Punkte;
                team2.GegnerischeTore -= s.Team1Punkte;
            }
            else
            {
                Mannschaft mWin = findMann(winner);
                Mannschaft mLos = findMann(loser);
                if (mWin.ID == s.Team1ID)
                {
                    mWin.ErzielteTore -= s.Team1Punkte;
                    mLos.ErzielteTore -= s.Team2Punkte;
                    mWin.GegnerischeTore -= s.Team2Punkte;
                    mLos.GegnerischeTore -= s.Team1Punkte;
                }
                else
                {
                    mWin.ErzielteTore -= s.Team2Punkte;
                    mLos.ErzielteTore -= s.Team1Punkte;
                    mWin.GegnerischeTore -= s.Team1Punkte;
                    mLos.GegnerischeTore -= s.Team2Punkte;
                }
                mWin.GewSpiele -= 1;
                mLos.VerlSpiele -= 1;
            }
        }

        private void addMannschaftsStats(Spiel s)
        {
            int winner = s.showWinner();
            int loser = s.showLoser();
            if (winner == -1 && loser == -1)
            {
                Mannschaft team1 = findMann(s.Team1ID);
                Mannschaft team2 = findMann(s.Team2ID);
                team1.Unentschieden += 1;
                team2.Unentschieden += 1;
                // Bei Unentschieden ist egal welche Punkte von welchem Team hinzugefügt werden
                team1.ErzielteTore += s.Team1Punkte;
                team1.GegnerischeTore += s.Team1Punkte;
                team2.ErzielteTore += s.Team1Punkte;
                team2.GegnerischeTore += s.Team1Punkte;
            }
            else
            {
                Mannschaft mWin = findMann(winner);
                Mannschaft mLos = findMann(loser);
                if (mWin.ID == s.Team1ID)
                {
                    mWin.ErzielteTore += s.Team1Punkte;
                    mLos.ErzielteTore += s.Team2Punkte;
                    mWin.GegnerischeTore += s.Team2Punkte;
                    mLos.GegnerischeTore += s.Team1Punkte;
                }
                else
                {
                    mWin.ErzielteTore += s.Team2Punkte;
                    mLos.ErzielteTore += s.Team1Punkte;
                    mWin.GegnerischeTore += s.Team1Punkte;
                    mLos.GegnerischeTore += s.Team2Punkte;
                }
                mWin.GewSpiele += 1;
                mLos.VerlSpiele += 1;
            }
        }

        public Mannschaft findMann(int ID)
        {
            Mannschaft EditMann = null;
            foreach (Mannschaft m in this.Mannschaften)
            {
                if (m.ID == ID)
                {
                    EditMann = m;
                }
            }
            return EditMann;
        }

        internal void TurnierHinzuf(string turnierName)
        {
            Turnier t = new Turnier(generateID(), turnierName);
            this.Turniere.Add(t);
        }

        internal void AddFussballSpieler(string name, string vorname, DateTime geburtstag, string position, int geschosseneTore, int anzahlJahre, int gewSpiele, int anzahlVereine, int anzahlSpiele)
        {
            int id = generateID();
            FussballSpieler f = new FussballSpieler(id, name, vorname, geburtstag, position, geschosseneTore, anzahlJahre, gewSpiele, anzahlVereine, anzahlSpiele);
            this.Personen.Add(f);
        }

        internal void AddHandballSpieler(string name, string vorname, DateTime geburtstag, string position, int geworfeneTore, int anzahlJahre, int gewSpiele, int anzahlVereine, int anzahlSpiele)
        {
            int id = generateID();
            HandballSpieler h = new HandballSpieler(id, name, vorname, geburtstag, position, geworfeneTore, anzahlJahre, gewSpiele, anzahlVereine, anzahlSpiele);
            this.Personen.Add(h);
        }

        internal void AddTennisSpieler(string name, string vorname, DateTime geburtstag, int aufschlagGeschw, string schlaeger, int anzahlJahre, int gewSpiele, int anzahlVereine, int anzahlSpiele)
        {
            int id = generateID();
            TennisSpieler t = new TennisSpieler(id, name, vorname, geburtstag, aufschlagGeschw, schlaeger, anzahlJahre, gewSpiele, anzahlVereine, anzahlSpiele);
            this.Personen.Add(t);
        }

        internal void createMannschaft(string name, string sportart, List<Person> personen)
        {
            int id = generateID();
            Mannschaft m = new Mannschaft(id, name, sportart, personen);
            this.Mannschaften.Add(m);
        }

        internal void AddTrainer(string name, string vorname, DateTime geburtstag, int anzahlJahre)
        {
            int id = generateID();
            Trainer t = new Trainer(id, name, vorname, geburtstag, anzahlJahre);
            this.Personen.Add(t);
        }

        internal void AddPhysio(string name, string vorname, DateTime geburtstag)
        {
            int id = generateID();
            Physiotherapeut p = new Physiotherapeut(id, name, vorname, geburtstag);
            this.Personen.Add(p);
        }

        public void sortiereNachName()
        {
            List<Person> retVal = this.Personen;

            //Alle nach Namen sortieren
            bool fertig = false;
            while (fertig == false)
            {
                fertig = true;
                for (int i = 0; i < retVal.Count - 1; i++)
                {
                    if (this.ReverseSort)
                    {
                        if (retVal[i].compareByName(retVal[i + 1]) < 0)
                        {
                            Person temp = retVal[i];
                            retVal[i] = retVal[i + 1];
                            retVal[i + 1] = temp;
                            fertig = false;
                        }
                    }
                    else
                    {
                        if (retVal[i].compareByName(retVal[i + 1]) > 0)
                        {
                            Person temp = retVal[i];
                            retVal[i] = retVal[i + 1];
                            retVal[i + 1] = temp;
                            fertig = false;
                        }
                    }

                }
            }
            this.Personen = retVal;
        }

        internal void sortiereNachMannschaftName()
        {
            List<Mannschaft> retVal = this.Mannschaften;

            //Alle nach Namen sortieren
            bool fertig = false;
            while (fertig == false)
            {
                fertig = true;
                for (int i = 0; i < retVal.Count - 1; i++)
                {
                    if (this.ReverseSort)
                    {
                        if (retVal[i].compareByName(retVal[i + 1]) < 0)
                        {
                            Mannschaft temp = retVal[i];
                            retVal[i] = retVal[i + 1];
                            retVal[i + 1] = temp;
                            fertig = false;
                        }
                    }
                    else
                    {
                        if (retVal[i].compareByName(retVal[i + 1]) > 0)
                        {
                            Mannschaft temp = retVal[i];
                            retVal[i] = retVal[i + 1];
                            retVal[i + 1] = temp;
                            fertig = false;
                        }
                    }

                }
            }
            this.Mannschaften = retVal;
        }

        public void sortiereNachGeburtstag()
        {
            List<Person> retVal = this.Personen;

            //Alle nach Namen sortieren
            bool fertig = false;
            while (fertig == false)
            {
                fertig = true;
                for (int i = 0; i < retVal.Count - 1; i++)
                {
                    if (this.ReverseSort)
                    {
                        if (retVal[i].compareByBirthday(retVal[i + 1]) < 0)
                        {
                            Person temp = retVal[i];
                            retVal[i] = retVal[i + 1];
                            retVal[i + 1] = temp;
                            fertig = false;
                        }
                    }
                    else
                    {
                        if (retVal[i].compareByBirthday(retVal[i + 1]) > 0)
                        {
                            Person temp = retVal[i];
                            retVal[i] = retVal[i + 1];
                            retVal[i + 1] = temp;
                            fertig = false;
                        }
                    }
                }
            }
            this.Personen = retVal;
        }

        public void sortiereNachTore()
        {
            List<Person> retVal = this.Personen;

            List<Person> Fussballer = getAllFussballer();
            List<Person> HandBaller = getAllHandballer();
            List<Person> TennisLeute = getAllTennisSpieler();
            List<Person> Trainers = getAllTrainer();
            List<Person> Physios = getAllPhysios();
            //Alle nach Namen sortieren

            bool fertig = false;
            while (fertig == false)
            {
                fertig = true;
                for (int i = 0; i < Fussballer.Count - 1; i++)
                {
                    if (((FussballSpieler)Fussballer[i]).compareByErfolg((FussballSpieler)Fussballer[i + 1]) < 0)
                    {
                        Person temp = Fussballer[i];
                        Fussballer[i] = Fussballer[i + 1];
                        Fussballer[i + 1] = temp;
                        fertig = false;
                    }
                }
            }

            fertig = false;
            while (fertig == false)
            {
                fertig = true;
                for (int i = 0; i < HandBaller.Count - 1; i++)
                {
                    if (((HandballSpieler)HandBaller[i]).compareByErfolg((HandballSpieler)HandBaller[i + 1]) < 0)
                    {
                        Person temp = HandBaller[i];
                        HandBaller[i] = HandBaller[i + 1];
                        HandBaller[i + 1] = temp;
                        fertig = false;
                    }
                }
            }

            fertig = false;
            while (fertig == false)
            {
                fertig = true;
                for (int i = 0; i < TennisLeute.Count - 1; i++)
                {
                    if (((TennisSpieler)TennisLeute[i]).compareByErfolg((TennisSpieler)TennisLeute[i + 1]) < 0)
                    {
                        Person temp = TennisLeute[i];
                        TennisLeute[i] = TennisLeute[i + 1];
                        TennisLeute[i + 1] = temp;
                        fertig = false;
                    }
                }
            }
            List<Person> mergedPersonen = new List<Person>();
            mergedPersonen.Concat(Fussballer).Concat(HandBaller).Concat(TennisLeute).Concat(Trainers).Concat(Physios);
            this.Personen = retVal;
        }

        private List<Person> getAllTrainer()
        {
            List<Person> retVal = new List<Person>();
            foreach (Person p in this.Personen)
            {
                if (p is Trainer)
                {
                    retVal.Add(p);
                }
            }
            return retVal;
        }

        private List<Person> getAllPhysios()
        {
            List<Person> retVal = new List<Person>();
            foreach (Person p in this.Personen)
            {
                if (p is Physiotherapeut)
                {
                    retVal.Add(p);
                }
            }
            return retVal;
        }

        private List<Person> getAllTennisSpieler()
        {
            List<Person> retVal = new List<Person>();
            foreach (Person p in this.Personen)
            {
                if (p is TennisSpieler)
                {
                    retVal.Add(p);
                }
            }
            return retVal;
        }

        private List<Person> getAllHandballer()
        {
            List<Person> retVal = new List<Person>();
            foreach (Person p in this.Personen)
            {
                if (p is HandballSpieler)
                {
                    retVal.Add(p);
                }
            }
            return retVal;
        }

        private List<Person> getAllFussballer()
        {
            List<Person> retVal = new List<Person>();
            foreach (Person p in this.Personen)
            {
                if (p is FussballSpieler)
                {
                    retVal.Add(p);
                }
            }
            return retVal;
        }
        #endregion

        #region Database
        public void getAllPersonsFromDatabase()
        {
            Personen = Anbindung.getAllPerson();
            if (true)
            {

            }
        }


        public bool DeleteFromDB(int personID)
        {
            bool retVal = Anbindung.DeletePersonFromDB(personID);
            return retVal;
        }
        #endregion

        #region Schnittstellen
        #endregion
    }
}