//Autor:        Kroll
//Datum:        11.02.2020
//Dateiname:    Physiotherapeut.cs
//Beschreibung: Definierung eines Tunieres im Sport
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
    public class Physiotherapeut : Person
    {
        #region Eigenschaften
        string _anerkennungen; //Ärztliche Annerkennungen, Erfolge, etc.
        #endregion

        #region Accessoren/Modifier
        public string Anerkennungen { get => _anerkennungen; set => _anerkennungen = value; }
        #endregion

        #region Konstruktoren
        public Physiotherapeut() : base()
        {
            Anerkennungen = null;
        }
        //Spezialkonstruktor
        public Physiotherapeut(string anerkennungen) : base()
        {
            Anerkennungen = anerkennungen;
        }

        public Physiotherapeut(int id, string name, string vorname, DateTime geburtstag, string anerkennungen = "nothing") : base(id, name, vorname, geburtstag)
        {
            Anerkennungen = anerkennungen;
        }
        //Kopierkonstruktor
        public Physiotherapeut(Physiotherapeut p) : base(p)
        {
            Anerkennungen = p.Anerkennungen;
        }
        #endregion

        #region Worker
        public string stelleAttestAus(Spieler s)
        {
            string retVal = "Der Physiotherapeut " + this.Name + " stellt ein Attest aus für den Spieler " + s.Name;
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

                INSERT INTO `physiotherapeut` (`id`, `person_id`, `annerkennungen`) 
                VALUES (NULL, '{6}', '{7}');", this.ID, this.Name, this.Vorname, this.Geburtstag.ToString("yyyy-MM-dd HH:mm:ss.fff"), 1, 1, this.ID, this.Anerkennungen);

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
                @"UPDATE `physiotherapeut` SET `annerkennungen` = '{0}' 
                WHERE `physiotherapeut`.`person_id` = {1};

                UPDATE `person` SET `vorname` = '{2}', `name` = '{3}', `geburtstag` = '{4}'
                WHERE `person`.`id` = {1}",
                this.Anerkennungen, this.ID, this.Vorname, this.Name, this.Geburtstag.ToString("yyyy-MM-dd HH:mm:ss.fff"));

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
