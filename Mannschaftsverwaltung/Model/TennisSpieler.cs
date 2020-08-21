//Autor:        Kroll
//Datum:        11.02.2020
//Dateiname:    TennisSpieler.cs
//Beschreibung: Klasse für den einzelnen TennisSpieler
//Änderungen:   
//11.02.2020:   Entwicklungsbeginn

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mannschaftsverwaltung
{
    public class TennisSpieler : Spieler
    {
        #region Eigenschaften
        string _schlaeger; //welcher Schläger nutzt der Tennisspieler?
        int _aufschlaggeschwindigkeit; //Durchschnittl. Aufschlaggeschw. in km/h


        #endregion

        #region Accessoren/Modifier
        public string Schlaeger { get => _schlaeger; set => _schlaeger = value; }
        public int Aufschlaggeschwindigkeit { get => _aufschlaggeschwindigkeit; set => _aufschlaggeschwindigkeit = value; }
        #endregion

        #region Konstruktoren
        public TennisSpieler() : base()
        {
            Schlaeger = null;
            Aufschlaggeschwindigkeit = -1;
            GewonneneSpiele = -1;
        }
        //Spezialkonstruktor
        public TennisSpieler(int id, string name, string vorname, DateTime geburtstag, int aufschlaggeschwindigkeit, string schlaeger = "Wilson 9000", int anzahlJahre = 0, int gewonneneSpiele = 0, int anzahlVereine = 0, int anzahlSpiele = 0) : base(id, name, vorname, geburtstag, anzahlJahre: anzahlJahre, gewonneneSpiele: gewonneneSpiele, anzahlVereine: anzahlVereine, anzahlSpiele: anzahlSpiele)
        {
            Schlaeger = schlaeger;
            Aufschlaggeschwindigkeit = aufschlaggeschwindigkeit;
        }
        #endregion

        #region Worker
        public string wechselSchlaeger(string s)
        {
            string retVal = this.Schlaeger;
            this.Schlaeger = s;
            return retVal;
        }
        public override string spielen()
        {
            string retVal = "Der Tennisspieler spielt.";
            return retVal;
        }

        public override int compareByErfolg(Spieler t)
        {
            int retVal;
            if (GewonneneSpiele > t.GewonneneSpiele)
            {
                retVal = 1;
            }
            else if (GewonneneSpiele == t.GewonneneSpiele)
            {
                retVal = 0;
            }
            else
            {
                retVal = -1;
            }
            return retVal;
        }

        public override bool createPerson()
        {
            bool retVal = true;
            MySqlConnection Connection;
            string connectionString = String.Format("server={0};port={1};user id={2}; password={3}; database={4}; SslMode={5}", "localhost", "3306", "root", "", "mannschaftsverwaltung", "none");

            string SQLString = String.Format(
                @"INSERT INTO `person` (`id`, `name`, `vorname`, `geburtstag`, `mannschaft_id`, `turnier_id`) 
                VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');

                INSERT INTO `tennisspieler` (`id`, `person_id`, `aufschlaggeschwindigkeit`, `gewonnenespiele`, `schlaeger`, `anzahlJahre` , `anzahlVereine` , `anzahlSpiele`) 
                VALUES (NULL, '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}');", this.ID, this.Name, this.Vorname, this.Geburtstag.ToString("yyyy-MM-dd HH:mm:ss.fff"), 1, 1, this.ID, this.Aufschlaggeschwindigkeit, this.GewonneneSpiele, this.Schlaeger, this.AnzahlJahre, this.AnzahlVereine, this.AnzahlSpiele);

            try
            {
                Connection = new MySqlConnection(connectionString);
                Connection.Open();
            }
            catch (Exception)
            {
                throw;
            }

            MySqlCommand command = new MySqlCommand(SQLString, Connection);
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

        public override bool editPerson()
        {
            bool retVal = true;
            MySqlConnection Connection;
            string connectionString = String.Format("server={0};port={1};user id={2}; password={3}; database={4}; SslMode={5}", "localhost", "3306", "root", "", "mannschaftsverwaltung", "none");

            string SQLString = String.Format(
                @"UPDATE `person` SET `vorname` = '{0}', `name` = '{1}', `geburtstag` = '{2}' 
                WHERE `person`.`id` = {3};
                UPDATE `tennisspieler` SET `aufschlaggeschwindigkeit` = '{4}', `gewonnenespiele` = '{5}', `schlaeger` = '{6}', `anzahlJahre` = '{7}', `anzahlVereine` = '{8}', `anzahlSpiele` = '{9}' 
                WHERE `tennisspieler`.`person_id` = {3}",
                this.Vorname, this.Name, this.Geburtstag.ToString("yyyy-MM-dd HH:mm:ss.fff"), this.ID, this.Aufschlaggeschwindigkeit, this.GewonneneSpiele, this.Schlaeger, this.AnzahlJahre, this.AnzahlVereine, this.AnzahlSpiele);

            try
            {
                Connection = new MySqlConnection(connectionString);
                Connection.Open();
            }
            catch (Exception)
            {
                throw;
            }

            MySqlCommand command = new MySqlCommand(SQLString, Connection);
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

        public override bool deletePerson()
        {
            DataManager DBManager = new DataManager();

            DBManager.openDBConection();
            bool retVal = DBManager.removePerson(this);
            DBManager.closeConnection();

            return retVal;
        }
        #endregion

        #region Schnittstellen
        #endregion
    }
}
