﻿//Autor:        Kroll
//Datum:        02.04.2020
//Dateiname:    Controller.cs
//Beschreibung: Businesslogik für die Mannschaftsverwaltung
//Änderungen:
//02.04.2020:   Entwicklungsbeginn 

using MySql.Data.MySqlClient;
using Newtonsoft.Json;
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
        List<Turnier> _turniere;
        List<User> _Nutzer;
        bool _authenticated;
        User _activeUser;
        DataManager _dBManager;
        private int _editGameID;
        private bool _isError;
        private string _errorMsg;
        private bool _isTurnierEdit;
        private int _editTurnierID;

        #endregion

        #region Accessoren/Modifier
        public List<Mannschaft> Mannschaften { get => _Mannschaften; set => _Mannschaften = value; }
        public List<Person> Personen { get => _Personen; set => _Personen = value; }
        [JsonIgnore]
        public Person NeuesMitglied { get => _NeuesMitglied; set => _NeuesMitglied = value; }

        public List<string> Sportarten { get => _Sportarten; set => _Sportarten = value; }
        [JsonIgnore]
        public bool EditPerson { get => _EditPerson; set => _EditPerson = value; }
        [JsonIgnore]
        public int EditPersonIndex { get => _EditPersonIndex; set => _EditPersonIndex = value; }
        [JsonIgnore]
        public bool MannschaftOderGruppe { get => _MannschaftOderGruppe; set => _MannschaftOderGruppe = value; }
        [JsonIgnore]
        public bool MannschaftsAnzeige { get => _MannschaftsAnzeige; set => _MannschaftsAnzeige = value; }
        [JsonIgnore]
        public bool ReverseSort { get => _reverseSort; set => _reverseSort = value; }
        [JsonIgnore]
        public bool EditMannschaft { get => _EditMannschaft; set => _EditMannschaft = value; }
        [JsonIgnore]
        public int EditMannID { get => _EditMannID; set => _EditMannID = value; }
        [JsonIgnore]
        public int EditMannIndex { get => _EditMannIndex; set => _EditMannIndex = value; }
        public List<Turnier> Turniere { get => _turniere; set => _turniere = value; }
        public List<User> Nutzer { get => _Nutzer; set => _Nutzer = value; }
        public bool Authenticated { get => _authenticated; set => _authenticated = value; }
        public User ActiveUser { get => _activeUser; set => _activeUser = value; }
        public DataManager DBManager { get => _dBManager; set => _dBManager = value; }
        public int EditGameID { get => _editGameID; set => _editGameID = value; }
        public bool IsError { get => _isError; set => _isError = value; }
        public string ErrorMsg { get => _errorMsg; set => _errorMsg = value; }
        public bool IsTurnierEdit { get => _isTurnierEdit; set => _isTurnierEdit = value; }
        public int EditTurnierID { get => _editTurnierID; set => _editTurnierID = value; }
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
            Turniere = new List<Turnier>();
            Authenticated = false;
            ActiveUser = null;
            DBManager = new DataManager();
            Nutzer = new List<User>();
            EditGameID = -1;
            IsError = false;
            ErrorMsg = "";
            IsTurnierEdit = false;
            EditTurnierID = -1;
        }
        #endregion

        #region Worker
        public bool login(string username, string password)
        {
            bool retVal = false;
            foreach (User user in Nutzer)
            {
                this.Authenticated = user.auth(username, password);
                if (this.Authenticated)
                {
                    this.ActiveUser = user;
                    retVal = this.Authenticated;
                    break;
                }
            }
            return retVal;
        }
        public static int generateID()
        {
            return Math.Abs(Guid.NewGuid().GetHashCode() / 10000);
        }

        public void removeTurnier(int turnierIndex)
        {
            DBManager.openDBConection();
            DBManager.deleteTurnier(this.Turniere[turnierIndex]);
            DBManager.closeConnection();
            foreach (Spiel s in this.Turniere[turnierIndex].Spiele)
            {
                removeMannschaftsStats(s);
            }
            this.Turniere.RemoveAt(turnierIndex);
        }

        public void removePersonFromMannschaft(Mannschaft m, int personID)
        {
            m.RemovePerson(personID); //only really needed when there is no DB
            DBManager.openDBConection();
            DBManager.editPersonMannschaft(null, this.Personen.Find(p => p.ID == personID));
            DBManager.closeConnection();

        }

        public void createGame(int TurnierIndex, int team1id, int team2id, int team1Punkte, int team2Punkte)
        {
            Spiel s = new Spiel(generateID(), team1id, team2id, team1Punkte, team2Punkte);
            this.Turniere[TurnierIndex].Spiele.Add(s);

            addMannschaftsStats(s);

            DBManager.openDBConection();
            DBManager.createSpiel(this.Turniere[TurnierIndex].ID, s);
            DBManager.closeConnection();
        }

        public void editGame(int team1id, int team2id, int team1Punkte, int team2Punkte)
        {
            this.Turniere.ForEach(turnier =>
            {
                foreach (Spiel spiel in turnier.Spiele)
                {
                    if (spiel.ID == this.EditGameID)
                    {
                        removeMannschaftsStats(spiel);
                        spiel.Team1ID = team1id;
                        spiel.Team2ID = team2id;
                        spiel.Team1Punkte = team1Punkte;
                        spiel.Team2Punkte = team2Punkte;
                        addMannschaftsStats(spiel);

                        DBManager.openDBConection();
                        DBManager.updateSpiel(spiel);
                        DBManager.closeConnection();
                    }
                }
            });
        }

        public void deleteGame(int TurnierIndex, Spiel s)
        {
            this.Turniere[TurnierIndex].Spiele.Remove(s);
            DBManager.openDBConection();
            DBManager.deleteSpiel(s);
            DBManager.closeConnection();
            removeMannschaftsStats(s);
        }

        private void removeMannschaftsStats(Spiel s)
        {
            int winner = s.getWinnerID();
            int loser = s.getLoserID();
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

                DBManager.openDBConection();
                DBManager.updateMannStats(team1);
                DBManager.updateMannStats(team2);
                DBManager.closeConnection();
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

                DBManager.openDBConection();
                DBManager.updateMannStats(mWin);
                DBManager.updateMannStats(mLos);
                DBManager.closeConnection();
            }
        }

        private void addMannschaftsStats(Spiel s)
        {
            int winner = s.getWinnerID();
            int loser = s.getLoserID();
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

                DBManager.openDBConection();
                DBManager.updateMannStats(team1);
                DBManager.updateMannStats(team2);
                DBManager.closeConnection();

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

                DBManager.openDBConection();
                DBManager.updateMannStats(mWin);
                DBManager.updateMannStats(mLos);
                DBManager.closeConnection();
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

        public void TurnierHinzuf(string turnierName, List<Mannschaft> selectedMannschaften)
        {
            Turnier t = new Turnier(generateID(), turnierName);
            DBManager.openDBConection();
            DBManager.createTurnier(t, ActiveUser);
            DBManager.closeConnection();

            DBManager.openDBConection();
            DBManager.createTurnierMannschaften(t.ID, selectedMannschaften);
            DBManager.closeConnection();

            this.Turniere.Add(t);
        }

        public bool deleteMannschaftFromTurnier(int turnierID, List<Mannschaft> selectedMannschaften)
        {
            bool retVal = true;
            Turnier turnier = this.Turniere.Find(t => t.ID == turnierID);
            foreach (Mannschaft mannschaft in selectedMannschaften)
            {
                foreach (Spiel spiel in turnier.Spiele)
                {
                    if (mannschaft.ID == spiel.Team1ID || mannschaft.ID == spiel.Team2ID)
                    {
                        retVal = false;
                        return retVal;
                    }
                }
                DBManager.openDBConection();
                DBManager.deleteMannschaftFromTurnier(turnierID, mannschaft.ID);
                DBManager.closeConnection();
            }

            return retVal;
        }

        public void EditTurnierName(string turnierName)
        {
            DBManager.openDBConection();
            DBManager.updateTurnier(EditTurnierID, turnierName);
            DBManager.closeConnection();
        }

        public void TurnierEdit(int turnierID, List<Mannschaft> selectedMannschaften)
        {
            DBManager.openDBConection();
            DBManager.createTurnierMannschaften(turnierID, selectedMannschaften);
            DBManager.closeConnection();
        }

        public void AddFussballSpieler(string name, string vorname, DateTime geburtstag, string position, int geschosseneTore, int anzahlJahre, int gewSpiele, int anzahlVereine, int anzahlSpiele)
        {
            int id = generateID();
            FussballSpieler f = new FussballSpieler(id, name, vorname, geburtstag, position, geschosseneTore, anzahlJahre, gewSpiele, anzahlVereine, anzahlSpiele);
            this.Personen.Add(f);
            if (this.DBManager.DBStatus)
            {
                CreatePersonInDB(f.ID);
            }
        }

        public void AddHandballSpieler(string name, string vorname, DateTime geburtstag, string position, int geworfeneTore, int anzahlJahre, int gewSpiele, int anzahlVereine, int anzahlSpiele)
        {
            int id = generateID();
            HandballSpieler h = new HandballSpieler(id, name, vorname, geburtstag, position, geworfeneTore, anzahlJahre, gewSpiele, anzahlVereine, anzahlSpiele);
            this.Personen.Add(h);
            if (this.DBManager.DBStatus)
            {
                CreatePersonInDB(h.ID);
            }
        }

        public void AddTennisSpieler(string name, string vorname, DateTime geburtstag, int aufschlagGeschw, string schlaeger, int anzahlJahre, int gewSpiele, int anzahlVereine, int anzahlSpiele)
        {
            int id = generateID();
            TennisSpieler t = new TennisSpieler(id, name, vorname, geburtstag, aufschlagGeschw, schlaeger, anzahlJahre, gewSpiele, anzahlVereine, anzahlSpiele);
            this.Personen.Add(t);
            if (this.DBManager.DBStatus)
            {
                CreatePersonInDB(t.ID);
            }
        }

        public void AddTrainer(string name, string vorname, DateTime geburtstag, int anzahlJahre)
        {
            int id = generateID();
            Trainer t = new Trainer(id, name, vorname, geburtstag, anzahlJahre);
            this.Personen.Add(t);
            if (this.DBManager.DBStatus)
            {
                CreatePersonInDB(t.ID);
            }
        }

        public void AddPhysio(string name, string vorname, DateTime geburtstag, string annerkennung)
        {
            int id = generateID();
            Physiotherapeut p = new Physiotherapeut(id, name, vorname, geburtstag, annerkennung);
            this.Personen.Add(p);
            if (this.DBManager.DBStatus)
            {
                CreatePersonInDB(p.ID);
            }
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

        public void sortiereNachSpezEigenschaft()
        {
            List<Person> Fussballer = getAllFussballer();
            List<Person> HandBaller = getAllHandballer();
            List<Person> TennisLeute = getAllTennisSpieler();
            List<Person> Trainers = getAllTrainer();
            List<Person> Physios = getAllPhysios();
            //Alle nach ihren speziellen Eigenschaften sortieren

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
            mergedPersonen = Fussballer.Concat(HandBaller).Concat(TennisLeute).Concat(Trainers).Concat(Physios).ToList();
            this.Personen = mergedPersonen;
        }

        public bool isMannschaftInGame(Mannschaft m)
        {
            bool retVal = false;
            foreach (Turnier turnier in Turniere)
            {
                foreach (Spiel spiel in turnier.Spiele)
                {
                    if (spiel.Team1ID == m.ID || spiel.Team2ID == m.ID)
                    {
                        retVal = true;
                    }
                }
            }
            return retVal;
        }

        public void deleteMannFromDB(Mannschaft m)
        {
            DBManager.openDBConection();
            foreach (Person p in m.Personen)
            {
                DBManager.editPersonMannschaft(null, p);
            }
            DBManager.deleteMann(m);
            DBManager.closeConnection();
        }

        public void renameMannInDB(Mannschaft mannschaft)
        {
            DBManager.openDBConection();
            DBManager.renameMann(mannschaft);
            DBManager.closeConnection();
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

        public void addPersonToMannInDB(Mannschaft m, Person p)
        {
            DBManager.openDBConection();
            DBManager.editPersonMannschaft(m, p);
            DBManager.closeConnection();
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
        public List<Person> getAllPerson(User activeUser)
        {
            List<Person> retVal = new List<Person>();
            DBManager.openDBConection();
            retVal = DBManager.getAllPerson(activeUser);
            DBManager.closeConnection();
            return retVal;
        }

        public void CreatePersonInDB(int personID)
        {
            Person createPerson = this.Personen.Find(p => p.ID == personID);
            bool retVal = createPerson.createPersonInDB(this.ActiveUser);
        }

        public List<Mannschaft> getAllMannschaften()
        {
            List<Mannschaft> allMann = new List<Mannschaft>();
            this.Personen = getAllPerson(ActiveUser);
            DBManager.openDBConection();
            allMann = DBManager.getAllMannschaften(this.Personen, this.ActiveUser);
            DBManager.closeConnection();
            return allMann;
        }

        public void createMannschaft(string name, string sportart, List<Person> personen)
        {
            int id = generateID();
            Mannschaft m = new Mannschaft(id, name, sportart, personen);
            this.DBManager.openDBConection();
            this.DBManager.createMannschaft(m, this.ActiveUser);
            this.DBManager.closeConnection();
            this.Mannschaften.Add(m);
        }

        public void getAllTurniereFromDB()
        {
            DBManager.openDBConection();
            Turniere = DBManager.getAllTurniere(this.ActiveUser);
            DBManager.closeConnection();
        }
        #endregion

        #region Schnittstellen
        #endregion
    }
}