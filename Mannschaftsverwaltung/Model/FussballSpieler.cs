//Autor:        Kroll
//Datum:        11.02.2020
//Dateiname:    FussballSpieler.cs
//Beschreibung: Klasse für den einzelnen FussballSpieler
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
    public class FussballSpieler : Spieler
    {
        #region Eigenschaften
        string _position;
        int geschosseneTore; //in einem Turnier
        #endregion

        #region Accessoren/Modifier
        public string Position { get => _position; set => _position = value; }
        public int GeschosseneTore { get => geschosseneTore; set => geschosseneTore = value; }
        #endregion

        #region Konstruktoren
        public FussballSpieler() : base()
        {
            Position = null;
            geschosseneTore = -1;
        }
        //Spezialkonstruktor
        public FussballSpieler(string position, int geschosseneTore) : base()
        {
            Position = position;
            GeschosseneTore = geschosseneTore;
        }

        public FussballSpieler(int id, string name, string vorname, DateTime geburtstag, string position, int geschosseneTore, int anzahlJahre = 0, int gewonneneSpiele = 0, int anzahlVereine = 0, int anzahlSpiele = 0) : base(id, name, vorname, geburtstag, anzahlJahre: anzahlJahre, gewonneneSpiele: gewonneneSpiele, anzahlVereine: anzahlVereine, anzahlSpiele: anzahlSpiele)
        {
            Position = position;
            GeschosseneTore = geschosseneTore;
        }
        //Kopierkonstruktor
        public FussballSpieler(FussballSpieler f) : base(f)
        {
            Position = f.Position;
            geschosseneTore = f.geschosseneTore;
        }

        #endregion

        #region Worker
        public string gebePositionsStatistik()
        {
            string retVal = this.Name + " hat in diesem Turnier " + this.geschosseneTore + " Tore erzielt von der Position " + this.Position;
            return retVal;
        }
        public override string spielen()
        {
            string retVal = "Der Fussballer spielt.";
            return retVal;
        }

        public override int compareByErfolg(Spieler s)
        {
            FussballSpieler f = (FussballSpieler)s;
            int retVal;
            if (GeschosseneTore > f.GeschosseneTore)
            {
                retVal = 1;
            }
            else if (GeschosseneTore == f.GeschosseneTore)
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

                INSERT INTO `fussballspieler` (`id`, `person_id`, `position`, `tore`, `anzahlJahre`, `gewonneneSpiele` , `anzahlVereine` , `anzahlSpiele`) 
                VALUES (NULL, '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}');", 
                this.ID, this.Name, this.Vorname, this.Geburtstag.ToString("yyyy-MM-dd HH:mm:ss.fff"), 1, 1, this.ID, this.Position, this.GeschosseneTore, this.AnzahlJahre, this.GewonneneSpiele, this.AnzahlVereine, this.AnzahlSpiele);

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
                UPDATE `fussballspieler` SET `position` = '{4}', `tore` = '{5}', `anzahlJahre` = '{6}', `gewonneneSpiele` = '{7}', `anzahlVereine` = '{8}', `anzahlSpiele` = '{9}' 
                WHERE `fussballspieler`.`person_id` = {3}",
                this.Vorname, this.Name, this.Geburtstag.ToString("yyyy-MM-dd HH:mm:ss.fff"), this.ID, this.Position, this.GeschosseneTore, this.AnzahlJahre, this.GewonneneSpiele, this.AnzahlVereine ,this.AnzahlSpiele);

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

            string SQLString = String.Format(
                @"DELETE FROM `fussballspieler` 
                WHERE `fussballspieler`.`person_id` = {0};

                DELETE FROM `person` 
                WHERE `person`.`id` = {0};", this.ID);

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
        #endregion
        #region Database
        #endregion

        #region Schnittstellen
        #endregion
    }
}
