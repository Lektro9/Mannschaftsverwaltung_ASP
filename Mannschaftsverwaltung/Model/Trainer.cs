//Autor:        Kroll
//Datum:        11.02.2020
//Dateiname:    Trainer.cs
//Beschreibung: Trainer für die Mannschaften/Vereine
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
    public class Trainer : Person
    {
        #region Eigenschaften
        int _erfahrung; //in Jahren
        #endregion

        #region Accessoren/Modifier
        public int Erfahrung { get => _erfahrung; set => _erfahrung = value; }
        #endregion

        #region Konstruktoren
        public Trainer() : base()
        {
            Erfahrung = -1;
        }
        //Spezialkonstruktor
        public Trainer(int erfahrung) : base()
        {
            Erfahrung = erfahrung;
        }
        public Trainer(int id, string name, string vorname, DateTime geburtstag, int erfahrung) : base(id, name, vorname, geburtstag)
        {
            Erfahrung = erfahrung;
        }
        //Kopierkonstruktor
        public Trainer(Trainer t) : base(t)
        {
            Erfahrung = t.Erfahrung;
        }
        #endregion

        #region Worker
        public string gebeFeedback(string fb)
        {
            string retVal = "Trainer " + this.Name + " gibt folgendes Feedback: " + fb;
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

                INSERT INTO `trainer` (`id`, `person_id`, `erfahrung`) 
                VALUES (NULL, '{6}', '{7}');", this.ID, this.Name, this.Vorname, this.Geburtstag.ToString("yyyy-MM-dd HH:mm:ss.fff"), 1, 1, this.ID, this.Erfahrung);

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
                @"UPDATE `trainer` SET `erfahrung` = '{0}' WHERE `trainer`.`person_id` = {1};

                UPDATE `person` SET `vorname` = '{2}', `name` = '{3}', `geburtstag` = '{4}'
                WHERE `person`.`id` = {1}", 
                this.Erfahrung, this.ID, this.Vorname, this.Name, this.Geburtstag.ToString("yyyy-MM-dd HH:mm:ss.fff"));

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
            bool retVal = true;
            MySqlConnection Connection;
            string connectionString = String.Format("server={0};port={1};user id={2}; password={3}; database={4}; SslMode={5}", "localhost", "3306", "root", "", "mannschaftsverwaltung", "none");

            string DeleteFussballSpieler = "DELETE FROM `trainer` " +
                    "WHERE `trainer`.`person_id` = " + this.ID + "; " +
                    "DELETE FROM `person` " +
                    "WHERE `person`.`id` = " + this.ID + "; ";

            try
            {
                Connection = new MySqlConnection(connectionString);
                Connection.Open();
            }
            catch (Exception)
            {
                throw;
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
        #endregion

        #region Schnittstellen
        #endregion
    }
}
