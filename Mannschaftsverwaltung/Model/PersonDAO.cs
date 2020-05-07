using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;
using System.Data;

namespace Mannschaftsverwaltung
{
    public class VerwaltungsDAO
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string user;
        private string password;
        private string port;
        private string connectionString;
        private string sslM;

        public MySqlConnection Connection { get => connection; set => connection = value; }
        public string Server { get => server; set => server = value; }
        public string Database { get => database; set => database = value; }
        public string User { get => user; set => user = value; }
        public string Password { get => password; set => password = value; }
        public string Port { get => port; set => port = value; }
        public string ConnectionString { get => connectionString; set => connectionString = value; }
        public string SslM { get => sslM; set => sslM = value; }

        public VerwaltungsDAO()
        {
            Server = "localhost";
            Database = "mannschaftsverwaltung";
            User = "user";
            Password = "user";
            Port = "3306";
            SslM = "none";

            connectionString = String.Format("server={0};port={1};user id={2}; password={3}; database={4}; SslMode={5}", server, port, user, password, database, sslM);

        }

        public List<Person> getAllPerson()
        {
            List<Person> retVal = new List<Person>();
            try
            {
                Connection = new MySqlConnection(connectionString);
                Connection.Open();
                string FetchAllFussbQuery =
                    "SELECT person.id, person.vorname, person.name, person.geburtstag, fussballspieler.position, fussballspieler.tore, fussballspieler.anzahlJahre, fussballspieler.gewonneneSpiele, fussballspieler.anzahlVereine, fussballspieler.anzahlSpiele " +
                    "FROM `fussballspieler`  " +
                    "JOIN person " +
                    "ON fussballspieler.person_id = person.id";

                
                MySqlDataAdapter adapter = new MySqlDataAdapter(FetchAllFussbQuery, Connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                DataRow[] dr = ds.Tables[0].Select();

                foreach (DataRow person in dr)
                {
                    Person p = new FussballSpieler
                        (
                            person.Field<int>("id"),
                            person.Field<string>("name"),
                            person.Field<string>("vorname"),
                            person.Field<DateTime>("geburtstag"),
                            person.Field<string>("position"),
                            person.Field<int>("tore"),
                            person.Field<int>("anzahlJahre"),
                            person.Field<int>("gewonneneSpiele"),
                            person.Field<int>("anzahlVereine"),
                            person.Field<int>("anzahlSpiele")
                        );
                    retVal.Add(p);
                }
            }
            catch (Exception)
            {
                throw;
                //TODO: Definieren was passieren soll wenn Datenbank nicht erreichbar oder fehlerhaft
            }
            finally
            {
                Connection.Dispose();
                Connection.Close();
            }
            return retVal;
        }

        public bool DeletePersonFromDB(int personID)
        {
            bool retVal = false;

            string DeleteFussballSpieler =
                    "DELETE FROM `fussballspieler` " +
                    "WHERE `fussballspieler`.`id` = " + personID + "; " +
                    "DELETE FROM `person` " +
                    "WHERE `person`.`id` = " + personID + "; ";
            try
            {
                Connection = new MySqlConnection(connectionString);
                Connection.Open();
            }
            catch (Exception)
            {
                throw;
                //TODO: Definieren was passieren soll wenn Datenbank nicht erreichbar oder fehlerhaft
            }


            MySqlCommand command = new MySqlCommand(DeleteFussballSpieler, Connection);
            int anzahl = -1;
            try
            {
                anzahl = command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                Connection.Close();
                throw;
            }
            finally
            {
                Connection.Dispose();
                Connection.Close();
            }

            return retVal;
        }
    }
}