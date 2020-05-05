using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;
using System.Data;
using Newtonsoft.Json;

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
            User = "root";
            Password = "";
            Port = "3306";
            SslM = "none";

            connectionString = String.Format("server={0};port={1};user id={2}; password={3}; database={4}; SslMode={5}", server, port, user, password, database, sslM);

            Connection = new MySqlConnection(connectionString);

            //connection.Open();
        }

        public void ExecuteNonQuery(string query)
        {
            try
            {
                Connection.Open();
                //MySqlCommand command = Connection.CreateCommand();
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, Connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "person");
                string JSONString = string.Empty;
                JSONString = JsonConvert.SerializeObject(ds.Tables[0]);
                DataRow[] dr = ds.Tables[0].Select();

                List<string> DataBasePersons = new List<string>();
                foreach (DataRow person in dr)
                {
                    string p = person.Field<string>("name");
                    DataBasePersons.Add(p);
                    person.Field<string>("Name");
                    //Person p = new Person(person.Field<int>("id"), person.Field<string>("name"), "none", person.Field<DateTime>("geburtstag"));
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Connection.Dispose();
                Connection.Close();
            }
        }
    }
}