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
        private bool _DBstatus;

        public MySqlConnection Connection { get => connection; set => connection = value; }
        public string Server { get => server; set => server = value; }
        public string Database { get => database; set => database = value; }
        public string User { get => user; set => user = value; }
        public string Password { get => password; set => password = value; }
        public string Port { get => port; set => port = value; }
        public string ConnectionString { get => connectionString; set => connectionString = value; }
        public string SslM { get => sslM; set => sslM = value; }
        public bool DBstatus { get => _DBstatus; set => _DBstatus = value; }

        public VerwaltungsDAO()
        {
            Server = "localhost";
            Database = "mannschaftsverwaltung";
            User = "root";
            Password = "";
            Port = "3306";
            SslM = "none";
            DBstatus = false;

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


                this.DBstatus = true;
            }
            catch (Exception)
            {
                this.DBstatus = false;
                throw;
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

        public bool DeletePersonFromDB(int personID)
        {
            bool retVal = false;

            string DeleteFussballSpieler =
                    "DELETE FROM `fussballspieler` " +
                    "WHERE `fussballspieler`.`person_id` = " + personID + "; " +

                    "DELETE FROM `handballspieler` " +
                    "WHERE `handballspieler`.`person_id` = " + personID + "; " +

                    "DELETE FROM `tennisspieler` " +
                    "WHERE `tennisspieler`.`person_id` = " + personID + "; " +

                    "DELETE FROM `trainer` " +
                    "WHERE `trainer`.`person_id` = " + personID + "; " +

                    "DELETE FROM `physiotherapeut` " +
                    "WHERE `physiotherapeut`.`person_id` = " + personID + "; " +

                    "DELETE FROM `person` " +
                    "WHERE `person`.`id` = " + personID + "; ";
            try
            {
                Connection = new MySqlConnection(connectionString);
                Connection.Open();
            }
            catch (Exception)
            {
                this.DBstatus = false;
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

        //public bool EditFussballSpieler(int personID)
        //{
        //    bool retVal = true;

        //    string EditFussballSpieler =
        //           "DELETE FROM `fussballspieler` " +
        //           "WHERE `fussballspieler`.`person_id` = " + personID + ";";
        //    try
        //    {
        //        Connection = new MySqlConnection(connectionString);
        //        Connection.Open();
        //    }
        //    catch (Exception)
        //    {
        //        this.DBstatus = false;
        //        throw;
        //    }
        //    return retVal;
        //}
    }
}