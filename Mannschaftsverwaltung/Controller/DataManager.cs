//Autor:        Kroll
//Datum:        20.08.2020
//Dateiname:    DataManager.cs
//Beschreibung: CRUD für Datenbank
//Änderungen:
//20.08.2020:   Entwicklungsbeginn 

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Windows;

namespace Mannschaftsverwaltung
{
    public class DataManager
    {
        #region Eigenschaften
        DBConfig _dBConfig;
        MySqlConnection _mySqlConnection;
        bool _dBStatus;
        string _connectionString;
        #endregion

        #region Accessoren/Modifier
        public MySqlConnection MySqlConnection { get => _mySqlConnection; set => _mySqlConnection = value; }
        public bool DBStatus { get => _dBStatus; set => _dBStatus = value; }
        public DBConfig DBConfig { get => _dBConfig; set => _dBConfig = value; }
        public string ConnectionString { get => _connectionString; set => _connectionString = value; }
        #endregion

        #region Konstruktoren
        public DataManager(MySqlConnection mySqlConnection, bool dBStatus, DBConfig dBConfig, string connectionString)
        {
            MySqlConnection = mySqlConnection;
            DBStatus = dBStatus;
            DBConfig = dBConfig;
            ConnectionString = connectionString;
        }
        public DataManager()
        {
            MySqlConnection = new MySqlConnection();
            DBStatus = false;
            DBConfig = new DBConfig();
            ConnectionString = DBConfig.getConnectionString();
        }
        #endregion

        #region Worker (Generell)
        public bool openDBConection()
        {
            try
            {
                MySqlConnection.ConnectionString = ConnectionString;
                MySqlConnection.Open();
                DBStatus = true;

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                DBStatus = false;
                return false;
            }
        }

        private bool executeSQLState(string sQLString)
        {
            bool retVal = false;
            MySqlCommand command = new MySqlCommand(sQLString, MySqlConnection);
            int anzahl = -1; // why?
            try
            {
                anzahl = command.ExecuteNonQuery();
                retVal = true;
            }
            catch (Exception)
            {
                MySqlConnection.Close();
                retVal = false;
                throw;
            }
            return retVal;
        }

        private bool executeSQLCommand(MySqlCommand command)
        {
            bool retVal = false;
            int anzahl = -1; // why?
            try
            {
                anzahl = command.ExecuteNonQuery();
                retVal = true;
            }
            catch (MySqlException e)
            {
                MySqlConnection.Close();
                retVal = false;
                MessageBox.Show(e.Message);
                //throw;
            }
            return retVal;
        }

        public void closeConnection()
        {
            MySqlConnection.Dispose();
            MySqlConnection.Close();
        }
        #endregion

        #region Worker (Personenverwaltung)
        public List<Person> getAllPerson(User activeUser)
        {
            List<Person> retVal = new List<Person>();
            string FetchAllFussbQuery = String.Format(
                    @"SELECT DISTINCT person.id, person.vorname, person.name, person.geburtstag, fussballspieler.position, 
                    fussballspieler.tore, fussballspieler.anzahlJahre, fussballspieler.gewonneneSpiele, 
                    fussballspieler.anzahlVereine, fussballspieler.anzahlSpiele, person.session_id, 
                    user.canreadsession 
                    FROM `fussballspieler` 
                    JOIN person 
                    ON fussballspieler.person_id = person.id 
                    JOIN user 
                    ON person.session_id={0} ;", activeUser.CanReadSession);

            MySqlCommand command = new MySqlCommand(FetchAllFussbQuery, MySqlConnection);
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

            string FetchAllHandQuery = String.Format(
                @"SELECT DISTINCT person.id, person.vorname, person.name, person.geburtstag,
                    handballspieler.position, handballspieler.tore, handballspieler.anzahlJahre, handballspieler.gewonneneSpiele,
                    handballspieler.anzahlVereine, handballspieler.anzahlSpiele, person.session_id, user.canreadsession
                    FROM `handballspieler` 
                    JOIN person 
                    ON handballspieler.person_id=person.id
                    JOIN user
                    ON person.session_id={0};", activeUser.CanReadSession);

            command = new MySqlCommand(FetchAllHandQuery, MySqlConnection);
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

            string FetchAllTennisQuery = String.Format(
                @"SELECT DISTINCT person.id, person.vorname, person.name, person.geburtstag,
                    tennisspieler.aufschlaggeschwindigkeit , tennisspieler.gewonnenespiele, 
                    tennisspieler.gewonneneSpiele , tennisspieler.schlaeger,
                    tennisspieler.anzahlJahre , tennisspieler.anzahlVereine, tennisspieler.anzahlSpiele,
                    person.session_id, user.canreadsession
                    FROM `tennisspieler` 
                    JOIN person 
                    ON tennisspieler.person_id=person.id
                    JOIN user
                    ON person.session_id={0};", activeUser.CanReadSession);

            command = new MySqlCommand(FetchAllTennisQuery, MySqlConnection);
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

            string FetchAllTrainQuery = String.Format(
                @"SELECT DISTINCT person.id, person.vorname, person.name, person.geburtstag,
                    trainer.erfahrung, 
                    person.session_id, user.canreadsession
                    FROM `trainer` 
                    JOIN person 
                    ON trainer.person_id=person.id
                    JOIN user
                    ON person.session_id={0};", activeUser.CanReadSession);

            command = new MySqlCommand(FetchAllTrainQuery, MySqlConnection);
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

            string FetchAllPhysioQuery = String.Format(
                @"SELECT DISTINCT person.id, person.vorname, person.name, person.geburtstag,
                    physiotherapeut.annerkennungen, 
                    person.session_id, user.canreadsession
                    FROM `physiotherapeut` 
                    JOIN person 
                    ON physiotherapeut.person_id=person.id
                    JOIN user
                    ON person.session_id={0};", activeUser.CanReadSession);

            command = new MySqlCommand(FetchAllPhysioQuery, MySqlConnection);
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

            return retVal;
        }

        public bool removePerson(Person deletePerson)
        {
            bool retVal = false;
            string SQLString = "";
            if (deletePerson is FussballSpieler)
            {
                SQLString = String.Format(
                @"DELETE FROM `fussballspieler` 
                WHERE `fussballspieler`.`person_id` = {0};

                DELETE FROM `person` 
                WHERE `person`.`id` = {0};", deletePerson.ID);
            }
            else if (deletePerson is HandballSpieler)
            {
                SQLString = String.Format(
                @"DELETE FROM `handballspieler` 
                WHERE `handballspieler`.`person_id` = {0};

                DELETE FROM `person` 
                WHERE `person`.`id` = {0};", deletePerson.ID);
            }
            else if (deletePerson is TennisSpieler)
            {
                SQLString = String.Format(
                @"DELETE FROM `tennisspieler` 
                WHERE `tennisspieler`.`person_id` = {0};

                DELETE FROM `person` 
                WHERE `person`.`id` = {0};", deletePerson.ID);
            }
            else if (deletePerson is Trainer)
            {
                SQLString = "DELETE FROM `trainer` " +
                    "WHERE `trainer`.`person_id` = " + deletePerson.ID + "; " +
                    "DELETE FROM `person` " +
                    "WHERE `person`.`id` = " + deletePerson.ID + "; ";
            }
            else if (deletePerson is Physiotherapeut)
            {
                SQLString = String.Format(
                @"DELETE FROM `physiotherapeut` 
                WHERE `physiotherapeut`.`person_id` = {0};

                DELETE FROM `person` 
                WHERE `person`.`id` = {0};", deletePerson.ID);
            }

            retVal = executeSQLState(SQLString);

            return retVal;
        }

        public bool createPerson(Person person, User activeUser)
        {
            bool retVal = false;
            string SQLString = "";
            if (person is FussballSpieler)
            {
                FussballSpieler fussballer = (FussballSpieler)person;
                SQLString = String.Format(
                @"INSERT INTO `person` (`id`, `name`, `vorname`, `geburtstag`, `session_id`) 
                VALUES ('{0}', '{1}', '{2}', '{3}', {11});

                INSERT INTO `fussballspieler` (`id`, `person_id`, `position`, `tore`, `anzahlJahre`, `gewonneneSpiele` , `anzahlVereine` , `anzahlSpiele`) 
                VALUES (NULL, '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}');",
                fussballer.ID, fussballer.Name, fussballer.Vorname, fussballer.Geburtstag.ToString("yyyy-MM-dd HH:mm:ss.fff"), fussballer.ID, fussballer.Position, fussballer.GeschosseneTore, fussballer.AnzahlJahre, fussballer.GewonneneSpiele, fussballer.AnzahlVereine, fussballer.AnzahlSpiele, activeUser.ID);
                retVal = true;
            }
            else if (person is HandballSpieler)
            {
                HandballSpieler handballer = (HandballSpieler)person;
                SQLString = String.Format(
                @"INSERT INTO `person` (`id`, `name`, `vorname`, `geburtstag`, `mannschaft_id`, `turnier_id`, `session_id`) 
                VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', {13});

                INSERT INTO `handballspieler` (`id`, `person_id`, `position`, `tore`, `anzahlJahre`, `gewonneneSpiele` , `anzahlVereine` , `anzahlSpiele`) 
                VALUES (NULL, '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}');",
                handballer.ID, handballer.Name, handballer.Vorname, handballer.Geburtstag.ToString("yyyy-MM-dd HH:mm:ss.fff"), null, null, handballer.ID, handballer.Position, handballer.GeworfeneTore, handballer.AnzahlJahre, handballer.GewonneneSpiele, handballer.AnzahlVereine, handballer.AnzahlSpiele, activeUser.ID);
                retVal = true;
            }
            else if (person is TennisSpieler)
            {
                TennisSpieler ts = (TennisSpieler)person;
                SQLString = String.Format(
                @"INSERT INTO `person` (`id`, `name`, `vorname`, `geburtstag`, `mannschaft_id`, `turnier_id`, `session_id`) 
                VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', {13});

                INSERT INTO `tennisspieler` (`id`, `person_id`, `aufschlaggeschwindigkeit`, `gewonnenespiele`, `schlaeger`, `anzahlJahre` , `anzahlVereine` , `anzahlSpiele`) 
                VALUES (NULL, '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}');", ts.ID, ts.Name, ts.Vorname, ts.Geburtstag.ToString("yyyy-MM-dd HH:mm:ss.fff"), null, null, ts.ID, ts.Aufschlaggeschwindigkeit, ts.GewonneneSpiele, ts.Schlaeger, ts.AnzahlJahre, ts.AnzahlVereine, ts.AnzahlSpiele, activeUser.ID);
                retVal = true;
            }
            else if (person is Trainer)
            {
                Trainer trainer = (Trainer)person;
                SQLString = String.Format(
                @"INSERT INTO `person` (`id`, `name`, `vorname`, `geburtstag`, `mannschaft_id`, `turnier_id`, `session_id`) 
                VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', {8});

                INSERT INTO `trainer` (`id`, `person_id`, `erfahrung`) 
                VALUES (NULL, '{6}', '{7}');", trainer.ID, trainer.Name, trainer.Vorname, trainer.Geburtstag.ToString("yyyy-MM-dd HH:mm:ss.fff"), null, null, trainer.ID, trainer.Erfahrung, activeUser.ID);
                retVal = true;
            }
            else if (person is Physiotherapeut)
            {
                Physiotherapeut physio = (Physiotherapeut)person;
                SQLString = String.Format(
                @"INSERT INTO `person` (`id`, `name`, `vorname`, `geburtstag`, `mannschaft_id`, `turnier_id`, `session_id`) 
                VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', {8});

                INSERT INTO `physiotherapeut` (`id`, `person_id`, `annerkennungen`) 
                VALUES (NULL, '{6}', '{7}');", physio.ID, physio.Name, physio.Vorname, physio.Geburtstag.ToString("yyyy-MM-dd HH:mm:ss.fff"), null, null, physio.ID, physio.Anerkennungen, activeUser.ID);
                retVal = true;
            }

            retVal = executeSQLState(SQLString);
            return retVal;
        }
        public bool editPerson(Person person)
        {
            bool retVal = false;
            string SQLString = "";
            if (person is FussballSpieler)
            {
                FussballSpieler fussballer = (FussballSpieler)person;
                SQLString = String.Format(
                @"UPDATE `person` SET `vorname` = '{0}', `name` = '{1}', `geburtstag` = '{2}' 
                WHERE `person`.`id` = {3};
                UPDATE `fussballspieler` SET `position` = '{4}', `tore` = '{5}', `anzahlJahre` = '{6}', `gewonneneSpiele` = '{7}', `anzahlVereine` = '{8}', `anzahlSpiele` = '{9}' 
                WHERE `fussballspieler`.`person_id` = {3}",
                fussballer.Vorname, fussballer.Name, fussballer.Geburtstag.ToString("yyyy-MM-dd HH:mm:ss.fff"), fussballer.ID, fussballer.Position, fussballer.GeschosseneTore, fussballer.AnzahlJahre, fussballer.GewonneneSpiele, fussballer.AnzahlVereine, fussballer.AnzahlSpiele);
                retVal = true;
            }
            else if (person is HandballSpieler)
            {
                HandballSpieler handballer = (HandballSpieler)person;
                SQLString = String.Format(
                @"UPDATE `person` SET `vorname` = '{0}', `name` = '{1}', `geburtstag` = '{2}' 
                WHERE `person`.`id` = {3};
                UPDATE `handballspieler` SET `position` = '{4}', `tore` = '{5}', `anzahlJahre` = '{6}', `gewonneneSpiele` = '{7}', `anzahlVereine` = '{8}', `anzahlSpiele` = '{9}' 
                WHERE `handballspieler`.`person_id` = {3}",
                handballer.Vorname, handballer.Name, handballer.Geburtstag.ToString("yyyy-MM-dd HH:mm:ss.fff"), handballer.ID, handballer.Position, handballer.GeworfeneTore, handballer.AnzahlJahre, handballer.GewonneneSpiele, handballer.AnzahlVereine, handballer.AnzahlSpiele);
                retVal = true;
            }
            else if (person is TennisSpieler)
            {
                TennisSpieler ts = (TennisSpieler)person;
                SQLString = String.Format(
                @"UPDATE `person` SET `vorname` = '{0}', `name` = '{1}', `geburtstag` = '{2}' 
                WHERE `person`.`id` = {3};
                UPDATE `tennisspieler` SET `aufschlaggeschwindigkeit` = '{4}', `gewonnenespiele` = '{5}', `schlaeger` = '{6}', `anzahlJahre` = '{7}', `anzahlVereine` = '{8}', `anzahlSpiele` = '{9}' 
                WHERE `tennisspieler`.`person_id` = {3}",
                ts.Vorname, ts.Name, ts.Geburtstag.ToString("yyyy-MM-dd HH:mm:ss.fff"), ts.ID, ts.Aufschlaggeschwindigkeit, ts.GewonneneSpiele, ts.Schlaeger, ts.AnzahlJahre, ts.AnzahlVereine, ts.AnzahlSpiele);
                retVal = true;
            }
            else if (person is Trainer)
            {
                Trainer trainer = (Trainer)person;
                SQLString = String.Format(
                @"UPDATE `trainer` SET `erfahrung` = '{0}' WHERE `trainer`.`person_id` = {1};

                UPDATE `person` SET `vorname` = '{2}', `name` = '{3}', `geburtstag` = '{4}'
                WHERE `person`.`id` = {1}",
                trainer.Erfahrung, trainer.ID, trainer.Vorname, trainer.Name, trainer.Geburtstag.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                retVal = true;
            }
            else if (person is Physiotherapeut)
            {
                Physiotherapeut physio = (Physiotherapeut)person;
                SQLString = String.Format(
                @"UPDATE `physiotherapeut` SET `annerkennungen` = '{0}' 
                WHERE `physiotherapeut`.`person_id` = {1};

                UPDATE `person` SET `vorname` = '{2}', `name` = '{3}', `geburtstag` = '{4}'
                WHERE `person`.`id` = {1}",
                physio.Anerkennungen, physio.ID, physio.Vorname, physio.Name, physio.Geburtstag.ToString("yyyy-MM-dd HH:mm:ss.fff"));

            }

            retVal = executeSQLState(SQLString);

            return retVal;
        }
        #endregion

        #region Worker (Mannschaftsverwaltung)
        public void createMannschaft(Mannschaft m, User activeUser)
        {
            string SQLString = String.Format("INSERT INTO `mannschaft` (`id`, `name`, `sportart`, `session_id`) VALUES (@id, @name, @sportart, @session);");
            MySqlCommand command = new MySqlCommand(SQLString, MySqlConnection);
            command.Parameters.AddWithValue("@name", m.Name);
            command.Parameters.AddWithValue("@sportart", m.Sportart);
            command.Parameters.AddWithValue("@session", activeUser.ID);
            command.Parameters.AddWithValue("@id", m.ID);
            executeSQLCommand(command);
            foreach (Person p in m.Personen)
            {
                editPersonMannschaft(m, p);
            }
        }

        public void updateMannStats(Mannschaft m)
        {
            string SQLString = @"UPDATE `mannschaft` SET `Unentschieden` = @MannUntent, `GewSpiele` = @MannGewSp, `VerlSpiele` = @MannVerlSp, 
                                        `ErzielteTore` = @MannErzTore, `GegnerischeTore` = @MannGegnTore WHERE `mannschaft`.`id` = @mannID;";
            MySqlCommand command = new MySqlCommand(SQLString, MySqlConnection);
            command.Parameters.AddWithValue("@MannUntent", m.Unentschieden);
            command.Parameters.AddWithValue("@MannGewSp", m.GewSpiele);
            command.Parameters.AddWithValue("@MannVerlSp", m.VerlSpiele);
            command.Parameters.AddWithValue("@MannErzTore", m.ErzielteTore);
            command.Parameters.AddWithValue("@MannGegnTore", m.GegnerischeTore);
            command.Parameters.AddWithValue("@mannID", m.ID);
            executeSQLCommand(command);
        }

        public void renameMann(Mannschaft m)
        {
            string SQLString = "UPDATE `mannschaft` SET `name` = @name WHERE `mannschaft`.`id` = @id; ";
            MySqlCommand command = new MySqlCommand(SQLString, MySqlConnection);
            command.Parameters.AddWithValue("@name", m.Name);
            command.Parameters.AddWithValue("@id", m.ID);
            executeSQLCommand(command);
        }


        internal void deleteMann(Mannschaft m)
        {
            string SQLString = "DELETE FROM `mannschaft` WHERE `mannschaft`.`id` = @id;";
            MySqlCommand command = new MySqlCommand(SQLString, MySqlConnection);
            command.Parameters.AddWithValue("@id", m.ID);
            executeSQLCommand(command);
        }

        public bool editPersonMannschaft(Mannschaft m, Person person)
        {
            bool retVal = false;
            string SQLString = "UPDATE `person` SET `mannschaft_id` = @mannID WHERE `person`.`id` = @personID; ";
            MySqlCommand command = new MySqlCommand(SQLString, MySqlConnection);
            if (m != null)
            {
                command.Parameters.AddWithValue("@mannID", m.ID);
            }
            else
            {
                command.Parameters.AddWithValue("@mannID", null);
            }
            command.Parameters.AddWithValue("@personID", person.ID);
            executeSQLCommand(command);

            return retVal;
        }

        public List<Mannschaft> getAllMannschaften(List<Person> allPers, User activeUser)
        {
            List<int> mannIds = new List<int>();
            string mannName = "";
            string sportart = "";
            List<Mannschaft> allMann = new List<Mannschaft>();

            string SQLStringMann = "SELECT * FROM `mannschaft` WHERE `session_id` = @session";
            MySqlCommand command = new MySqlCommand(SQLStringMann, MySqlConnection);
            command.Parameters.AddWithValue("@session", activeUser.CanReadSession);
            executeSQLCommand(command);
            MySqlDataReader rdr = command.ExecuteReader();
            while (rdr.Read())
            {
                mannIds.Add(Convert.ToInt32(rdr.GetValue(0)));
                mannName = rdr.GetValue(1).ToString();
                sportart = rdr.GetValue(2).ToString();
                Mannschaft m = new Mannschaft(
                    Convert.ToInt32(rdr.GetValue(0)),
                    mannName,
                    sportart,
                    new List<Person>(),
                    Convert.ToInt32(rdr.GetValue(4)),
                    Convert.ToInt32(rdr.GetValue(5)),
                    Convert.ToInt32(rdr.GetValue(6)),
                    Convert.ToInt32(rdr.GetValue(7)),
                    Convert.ToInt32(rdr.GetValue(8))
                    );
                allMann.Add(m);
            }
            rdr.Close();

            foreach (var id in mannIds)
            {
                allMann.Find(m => m.ID == id).Personen = getAllMannPers(allPers, id);
            }

            return allMann;
        }

        private List<Person> getAllMannPers(List<Person> allPers, int mannId)
        {
            List<Person> retVal = new List<Person>();

            string SQLStringPerson = "SELECT * FROM `person` WHERE `mannschaft_id` = @mannId";
            MySqlCommand command = new MySqlCommand(SQLStringPerson, MySqlConnection);
            command.Parameters.AddWithValue("@mannId", mannId);
            executeSQLCommand(command);
            MySqlDataReader rdr = command.ExecuteReader();
            while (rdr.Read())
            {
                int persId = Convert.ToInt32(rdr.GetValue(0));
                Person mannPers = allPers.Find(p => p.ID == persId);
                retVal.Add(mannPers);
            }
            rdr.Close();

            return retVal;
        }
        #endregion

        #region Worker (Turniere und Spiele)
        public List<Turnier> getAllTurniere(User activeUser)
        {
            List<Turnier> retVal = new List<Turnier>();

            string SQLString = "SELECT * FROM `turnier` WHERE `session_id` = @session ";
            MySqlCommand command = new MySqlCommand(SQLString, MySqlConnection);
            command.Parameters.AddWithValue("@session", activeUser.CanReadSession);
            executeSQLCommand(command);
            MySqlDataReader rdr = command.ExecuteReader();
            while (rdr.Read())
            {
                Turnier t = new Turnier(
                        Convert.ToInt32(rdr["ID"]),
                        rdr["name"].ToString(),
                        Convert.ToInt32(rdr["turnierstatus"])
                    );
                retVal.Add(t);
            }
            rdr.Close();

            foreach (Turnier t in retVal)
            {
                t.Spiele = getAllSpiele(t);
            }

            return retVal;
        }

        private List<Spiel> getAllSpiele(Turnier t)
        {
            List<Spiel> retVal = new List<Spiel>();

            string SQLString = "SELECT * FROM `spiel` where `turnierID` = @turnierID ";
            MySqlCommand command = new MySqlCommand(SQLString, MySqlConnection);
            command.Parameters.AddWithValue("@turnierID", t.ID);
            executeSQLCommand(command);
            MySqlDataReader rdr = command.ExecuteReader();
            while (rdr.Read())
            {
                Spiel s = new Spiel(
                        Convert.ToInt32(rdr.GetValue(0)),
                        Convert.ToInt32(rdr.GetValue(1)),
                        Convert.ToInt32(rdr.GetValue(2)),
                        Convert.ToInt32(rdr.GetValue(3)),
                        Convert.ToInt32(rdr.GetValue(4))
                    );
                retVal.Add(s);
            }
            rdr.Close();

            return retVal;
        }

        public void createSpiel(int turnierID, Spiel s)
        {
            string SQLString = @"INSERT INTO `spiel` (`id`, `team1ID`, `team2ID`, `team1Punkte`, `team2Punkte`, `turnierID`) 
                                 VALUES(NULL, @team1ID, @team2ID, @team1Punkte, @team2Punkte, @turnierIndex);";
            MySqlCommand command = new MySqlCommand(SQLString, MySqlConnection);
            command.Parameters.AddWithValue("@team1ID", s.Team1ID);
            command.Parameters.AddWithValue("@team2ID", s.Team2ID);
            command.Parameters.AddWithValue("@team1Punkte", s.Team1Punkte);
            command.Parameters.AddWithValue("@team2Punkte", s.Team2Punkte);
            command.Parameters.AddWithValue("@turnierIndex", turnierID);
            executeSQLCommand(command);
        }

        public void deleteSpiel(Spiel s)
        {
            string SQLString = @"DELETE FROM `spiel` WHERE `spiel`.`id` = @spielID";
            MySqlCommand command = new MySqlCommand(SQLString, MySqlConnection);
            command.Parameters.AddWithValue("@spielID", s.ID);
            executeSQLCommand(command);
        }

        public void deleteTurnier(int turnierID, List<Spiel> spiele)
        {
            foreach (Spiel s in spiele)
            {
                deleteSpiel(s);
            }
            string SQLString = @"DELETE FROM `turnier` WHERE `turnier`.`id` = @turnierID";
            MySqlCommand command = new MySqlCommand(SQLString, MySqlConnection);
            command.Parameters.AddWithValue("@turnierID", turnierID);
            executeSQLCommand(command);
        }

        public void createTurnier(Turnier t, User activeUser)
        {
            string SQLString = @"INSERT INTO `turnier` (`id`, `name`, `turnierstatus`, `session_id`) VALUES (NULL, @turnierName, @turnierStatus, @session);";
            MySqlCommand command = new MySqlCommand(SQLString, MySqlConnection);
            command.Parameters.AddWithValue("@turnierName", t.Name);
            command.Parameters.AddWithValue("@turnierStatus", (int)t.Status);
            command.Parameters.AddWithValue("@session", activeUser.ID);
            executeSQLCommand(command);
        }
        #endregion

        #region Worker (Userverwaltung)
        public List<User> getAllUser()
        {
            List<User> retVal = new List<User>();

            string SQLString = "SELECT * FROM `user`;";
            MySqlCommand command = new MySqlCommand(SQLString, MySqlConnection);
            executeSQLCommand(command);
            MySqlDataReader rdr = command.ExecuteReader();
            while (rdr.Read())
            {
                User u = new User(
                        Convert.ToInt32(rdr["id"]),
                        rdr["login"].ToString(),
                        rdr["password"].ToString(),
                        (Role)Enum.Parse(typeof(Role), rdr["role"].ToString()),
                        Convert.ToInt32(rdr["canreadsession"])
                        );
                retVal.Add(u);
            }
            rdr.Close();

            return retVal;
        }

        public void removeUser()
        {
            throw new NotImplementedException();
        }

        public void addUser()
        {
            throw new NotImplementedException();
        }

        public void updateUser()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}