//Autor:        Kroll
//Datum:        20.08.2020
//Dateiname:    DataManager.cs
//Beschreibung: CRUD für Datenbank
//Änderungen:
//20.08.2020:   Entwicklungsbeginn 

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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

        #region Worker
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
                return false;
            }
        }

        public List<Person> getAllPerson(User activeUser)
        {
            List<Person> retVal = new List<Person>();
            string FetchAllFussbQuery = String.Format(
                    @"SELECT person.id, person.vorname, person.name, person.geburtstag, fussballspieler.position, fussballspieler.tore, fussballspieler.anzahlJahre, fussballspieler.gewonneneSpiele, fussballspieler.anzahlVereine, fussballspieler.anzahlSpiele, person.session_id, user.session
                    FROM `fussballspieler` 
                    JOIN person 
                    ON fussballspieler.person_id = person.id
                    JOIN user
                    ON person.session_id={0} where user.session='{1}';", activeUser.ID, activeUser.Login);

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
                @"SELECT person.id, person.vorname, person.name, person.geburtstag,
                    handballspieler.position, handballspieler.tore, handballspieler.anzahlJahre, handballspieler.gewonneneSpiele,
                    handballspieler.anzahlVereine, handballspieler.anzahlSpiele, person.session_id, user.session
                    FROM `handballspieler` 
                    JOIN person 
                    ON handballspieler.person_id=person.id
                    JOIN user
                    ON person.session_id={0} where user.session='{1}';", activeUser.ID, activeUser.Login);

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
                @"SELECT person.id, person.vorname, person.name, person.geburtstag,
                    tennisspieler.aufschlaggeschwindigkeit , tennisspieler.gewonnenespiele, 
                    tennisspieler.gewonneneSpiele , tennisspieler.schlaeger,
                    tennisspieler.anzahlJahre , tennisspieler.anzahlVereine, tennisspieler.anzahlSpiele,
                    person.session_id, user.session
                    FROM `tennisspieler` 
                    JOIN person 
                    ON tennisspieler.person_id=person.id
                    JOIN user
                    ON person.session_id={0} where user.session='{1}';", activeUser.ID, activeUser.Login);

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
                @"SELECT person.id, person.vorname, person.name, person.geburtstag,
                    trainer.erfahrung, 
                    person.session_id, user.session
                    FROM `trainer` 
                    JOIN person 
                    ON trainer.person_id=person.id
                    JOIN user
                    ON person.session_id={0} where user.session='{1}';", activeUser.ID, activeUser.Login);

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
                @"SELECT person.id, person.vorname, person.name, person.geburtstag,
                    physiotherapeut.annerkennungen, 
                    person.session_id, user.session
                    FROM `physiotherapeut` 
                    JOIN person 
                    ON physiotherapeut.person_id=person.id
                    JOIN user
                    ON person.session_id={0} where user.session='{1}';", activeUser.ID, activeUser.Login);

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

        public void closeConnection()
        {
            MySqlConnection.Dispose();
            MySqlConnection.Close();
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

            MySqlCommand command = new MySqlCommand(SQLString, MySqlConnection);
            int anzahl = -1; // why?
            try
            {
                anzahl = command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MySqlConnection.Close();
                throw;
            }

            return retVal;
        }
        #endregion
    }
}