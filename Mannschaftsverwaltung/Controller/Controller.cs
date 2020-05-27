//Autor:        Kroll
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
using System.Web.Script.Serialization;

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
        bool _dBStatus;


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
        [JsonIgnore]
        public bool DBStatus { get => _dBStatus; set => _dBStatus = value; }
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
            DBStatus = false;
        }
        #endregion

        #region Worker
        public static int generateID()
        {
            return Math.Abs(Guid.NewGuid().GetHashCode() / 10000);
        }

        internal string createCurrentStateAsJSON()
        {
            Controller saveCont = this;
            return new JavaScriptSerializer().Serialize(saveCont);
        }

        internal void removeTurnier(int turnierIndex)
        {
            foreach (Spiel s in this.Turniere[turnierIndex].Spiele)
            {
                removeMannschaftsStats(s);
            }
            this.Turniere.RemoveAt(turnierIndex);
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
            if (this.DBStatus)
            {
                CreatePersonInDB(f.ID);
            }
        }

        internal void AddHandballSpieler(string name, string vorname, DateTime geburtstag, string position, int geworfeneTore, int anzahlJahre, int gewSpiele, int anzahlVereine, int anzahlSpiele)
        {
            int id = generateID();
            HandballSpieler h = new HandballSpieler(id, name, vorname, geburtstag, position, geworfeneTore, anzahlJahre, gewSpiele, anzahlVereine, anzahlSpiele);
            this.Personen.Add(h);
            if (this.DBStatus)
            {
                CreatePersonInDB(h.ID);
            }
        }

        internal void AddTennisSpieler(string name, string vorname, DateTime geburtstag, int aufschlagGeschw, string schlaeger, int anzahlJahre, int gewSpiele, int anzahlVereine, int anzahlSpiele)
        {
            int id = generateID();
            TennisSpieler t = new TennisSpieler(id, name, vorname, geburtstag, aufschlagGeschw, schlaeger, anzahlJahre, gewSpiele, anzahlVereine, anzahlSpiele);
            this.Personen.Add(t);
            if (this.DBStatus)
            {
                CreatePersonInDB(t.ID);
            }
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
            if (this.DBStatus)
            {
                CreatePersonInDB(t.ID);
            }
        }

        internal void AddPhysio(string name, string vorname, DateTime geburtstag)
        {
            int id = generateID();
            Physiotherapeut p = new Physiotherapeut(id, name, vorname, geburtstag);
            this.Personen.Add(p);
            if (this.DBStatus)
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
        public List<Person> getAllPerson()
        {
            List<Person> retVal = new List<Person>();
            string connectionString = String.Format("server={0};port={1};user id={2}; password={3}; database={4}; SslMode={5}", "localhost", "3306", "root", "", "mannschaftsverwaltung", "none");
            MySqlConnection Connection;
            Connection = new MySqlConnection(connectionString);
            try
            {
                Connection.Open();
                string FetchAllFussbQuery =
                    "SELECT person.id, person.vorname, person.name, person.geburtstag, fussballspieler.position, fussballspieler.tore, fussballspieler.anzahlJahre, fussballspieler.gewonneneSpiele, fussballspieler.anzahlVereine, fussballspieler.anzahlSpiele " +
                    "FROM `fussballspieler`  " +
                    "JOIN person " +
                    "ON fussballspieler.person_id = person.id;";

                MySqlCommand command = new MySqlCommand(FetchAllFussbQuery, Connection);
                MySqlDataReader rdr = command.ExecuteReader();

                while (rdr.Read())
                {
                    Person p = new FussballSpieler
                        (
                            Convert.ToInt32(rdr.GetValue(0)),
                            rdr.GetValue(2).ToString(),
                            rdr.GetValue(1).ToString(),
                            Convert.ToDateTime(rdr.GetValue(3)),
                            rdr.GetValue(4).ToString(),
                            Convert.ToInt32(rdr.GetValue(5)),
                            Convert.ToInt32(rdr.GetValue(6)),
                            Convert.ToInt32(rdr.GetValue(7)),
                            Convert.ToInt32(rdr.GetValue(8)),
                            Convert.ToInt32(rdr.GetValue(9))
                        );
                    retVal.Add(p);
                }
                rdr.Close();

                string FetchAllHandQuery =
                    @"SELECT person.id, person.vorname, person.name, person.geburtstag,
                    handballspieler.position, handballspieler.tore, handballspieler.anzahlJahre, handballspieler.gewonneneSpiele,
                    handballspieler.anzahlVereine, handballspieler.anzahlSpiele
                    FROM `handballspieler` 
                    JOIN person 
                    ON handballspieler.person_id=person.id;";

                command = new MySqlCommand(FetchAllHandQuery, Connection);
                rdr = command.ExecuteReader();

                while (rdr.Read())
                {
                    Person p = new HandballSpieler
                        (
                            Convert.ToInt32(rdr.GetValue(0)),
                            rdr.GetValue(2).ToString(),
                            rdr.GetValue(1).ToString(),
                            Convert.ToDateTime(rdr.GetValue(3)),
                            rdr.GetValue(4).ToString(),
                            Convert.ToInt32(rdr.GetValue(5)),
                            Convert.ToInt32(rdr.GetValue(6)),
                            Convert.ToInt32(rdr.GetValue(7)),
                            Convert.ToInt32(rdr.GetValue(8)),
                            Convert.ToInt32(rdr.GetValue(9))
                        );
                    retVal.Add(p);
                }
                rdr.Close();

                string FetchAllTennisQuery =
                    @"SELECT person.id, person.vorname, person.name, person.geburtstag,
                    tennisspieler.aufschlaggeschwindigkeit , tennisspieler.gewonnenespiele, 
                    tennisspieler.gewonneneSpiele , tennisspieler.schlaeger,
                    tennisspieler.anzahlJahre , tennisspieler.anzahlVereine, tennisspieler.anzahlSpiele
                    FROM `tennisspieler` 
                    JOIN person 
                    ON tennisspieler.person_id=person.id;";

                command = new MySqlCommand(FetchAllTennisQuery, Connection);
                rdr = command.ExecuteReader();

                while (rdr.Read())
                {
                    Person p = new TennisSpieler
                        (
                            Convert.ToInt32(rdr.GetValue(0)),
                            rdr.GetValue(2).ToString(),
                            rdr.GetValue(1).ToString(),
                            Convert.ToDateTime(rdr.GetValue(3)),
                            Convert.ToInt32(rdr.GetValue(4)),
                            rdr.GetValue(7).ToString(),
                            Convert.ToInt32(rdr.GetValue(8)),
                            Convert.ToInt32(rdr.GetValue(5)),
                            Convert.ToInt32(rdr.GetValue(9)),
                            Convert.ToInt32(rdr.GetValue(10))
                        );
                    retVal.Add(p);
                }
                rdr.Close();

                string FetchAllTrainQuery =
                    @"SELECT person.id, person.vorname, person.name, person.geburtstag,
                    trainer.erfahrung 
                    FROM `trainer` 
                    JOIN person 
                    ON trainer.person_id=person.id;";

                command = new MySqlCommand(FetchAllTrainQuery, Connection);
                rdr = command.ExecuteReader();

                while (rdr.Read())
                {
                    Person p = new Trainer
                        (
                            Convert.ToInt32(rdr.GetValue(0)),
                            rdr.GetValue(2).ToString(),
                            rdr.GetValue(1).ToString(),
                            Convert.ToDateTime(rdr.GetValue(3)),
                            Convert.ToInt32(rdr.GetValue(4))
                        );
                    retVal.Add(p);
                }
                rdr.Close();

                string FetchAllPhysioQuery =
                    @"SELECT person.id, person.vorname, person.name, person.geburtstag,
                    physiotherapeut.annerkennungen 
                    FROM `physiotherapeut` 
                    JOIN person 
                    ON physiotherapeut.person_id=person.id;";

                command = new MySqlCommand(FetchAllPhysioQuery, Connection);
                rdr = command.ExecuteReader();

                while (rdr.Read())
                {
                    Person p = new Physiotherapeut
                        (
                            Convert.ToInt32(rdr.GetValue(0)),
                            rdr.GetValue(2).ToString(),
                            rdr.GetValue(1).ToString(),
                            Convert.ToDateTime(rdr.GetValue(3)),
                            rdr.GetValue(4).ToString()
                        );
                    retVal.Add(p);
                }
                rdr.Close();


                this.DBStatus = true;
            }
            catch (Exception)
            {
                this.DBStatus = false;
                //throw;
                //TODO: Personen wiedergeben, welche nicht in einer Datenbank liegen
                FussballSpieler p1 = new FussballSpieler(1, "Shidoski", "Klaus", DateTime.Parse("01-01-1993"), "Stürmer", 23, anzahlJahre: 1, anzahlSpiele: 32, anzahlVereine: 2, gewonneneSpiele: 2);
                FussballSpieler p2 = new FussballSpieler(2, "Johnsons", "Dennis", DateTime.Parse("02-01-1993"), "Stürmer", 25, anzahlJahre: 6, anzahlSpiele: 567, anzahlVereine: 2, gewonneneSpiele: 234);
                FussballSpieler p4 = new FussballSpieler(3, "Redgrave", "Vergil", DateTime.Parse("03-01-1993"), "Stürmer", 857, anzahlJahre: 2, anzahlSpiele: 234, anzahlVereine: 5, gewonneneSpiele: 65);
                FussballSpieler p5 = new FussballSpieler(4, "Redgrave", "Dante", DateTime.Parse("04-01-1993"), "Stürmer", 900, anzahlJahre: 8, anzahlSpiele: 199, anzahlVereine: 6, gewonneneSpiele: 4);
                FussballSpieler p6 = new FussballSpieler(5, "Son", "Goku", DateTime.Parse("05-02-1993"), "Stürmer", 1010, anzahlJahre: 9, anzahlSpiele: 23, anzahlVereine: 1, gewonneneSpiele: 16);
                Trainer t1 = new Trainer(6, "Taylor", "Tom", DateTime.Parse("01-01-1993"), 23);

                HandballSpieler h1 = new HandballSpieler(7, "Ball", "Bernd", DateTime.Parse("01-03-1995"), "Verteidiger", 3, anzahlJahre: 2, anzahlSpiele: 77, anzahlVereine: 8, gewonneneSpiele: 56);
                HandballSpieler h3 = new HandballSpieler(8, "Potter", "Harry", DateTime.Parse("16-07-1999"), "Stürmer", 25, anzahlJahre: 4, anzahlSpiele: 182, anzahlVereine: 1, gewonneneSpiele: 245);
                HandballSpieler h2 = new HandballSpieler(9, "Dohnson", "Henry", DateTime.Parse("12-06-1963"), "Stürmer", 16, anzahlJahre: 6, anzahlSpiele: 90, anzahlVereine: 2, gewonneneSpiele: 78);
                HandballSpieler h4 = new HandballSpieler(10, "Hamper", "Holly", DateTime.Parse("05-01-1995"), "Mittelfeld", 17, anzahlJahre: 10, anzahlSpiele: 33, anzahlVereine: 3, gewonneneSpiele: 98);

                TennisSpieler ts1 = new TennisSpieler(11, "Federer", "Roger", DateTime.Parse("01-12-2001"), 95, anzahlJahre: 12, anzahlSpiele: 2, anzahlVereine: 1, gewonneneSpiele: 23);

                Physiotherapeut ph1 = new Physiotherapeut(12, "Denrasen", "Dr. med", DateTime.Parse("01-01-1993"), "Auszeichnung blabla");
                retVal = new List<Person>() { p1, p2, p4, p5, p6, t1, h1, h2, h3, h4, ts1, ph1 };
            }
            finally
            {
                Connection.Dispose();
                Connection.Close();
            }
            return retVal;
        }

        public bool DeleteFromDB(int personID)
        {
            Person deletePerson = this.Personen.Find(p => p.ID == personID);
            bool retVal = deletePerson.deletePerson();
            this.Personen.Remove(deletePerson);
            return retVal;
        }

        public void CreatePersonInDB(int personID)
        {
            Person createPerson = this.Personen.Find(p => p.ID == personID);
            bool retVal = createPerson.createPerson();
        }
        #endregion

        #region Schnittstellen
        #endregion
    }
}