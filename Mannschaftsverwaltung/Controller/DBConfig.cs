//Autor:        Kroll
//Datum:        20.08.2020
//Dateiname:    DBConfig.cs
//Beschreibung: Einstellungen für Datenbank
//Änderungen:
//20.08.2020:   Entwicklungsbeginn 

namespace Mannschaftsverwaltung
{
    public class DBConfig
    {
        #region Eigenschaften
        string _server;
        string _port;
        string _user;
        string _password;
        string _database;
        string _sslMode;
        ConfReader _confReader;

        #endregion

        #region Accessoren/Modifier
        public string Server { get => _server; set => _server = value; }
        public string Port { get => _port; set => _port = value; }
        public string User { get => _user; set => _user = value; }
        public string Password { get => _password; set => _password = value; }
        public string Database { get => _database; set => _database = value; }
        public string SslMode { get => _sslMode; set => _sslMode = value; }
        public ConfReader ConfReader { get => _confReader; set => _confReader = value; }
        #endregion

        #region Konstruktoren
        

        public DBConfig()
        {
            ConfReader = new ConfReader();
            ConfReader.getConfData();
            Server = ConfReader.Properties["SERVER"];
            Port = ConfReader.Properties["PORT"];
            User = ConfReader.Properties["USER"];
            Password = ConfReader.Properties["PASSWORD"];
            Database = ConfReader.Properties["DATABASE"];
            SslMode = ConfReader.Properties["SSLMODE"];
        }

        public DBConfig(string server, string port, string user, string password, string database, string sslMode, ConfReader confReader)
        {
            Server = server;
            Port = port;
            User = user;
            Password = password;
            Database = database;
            SslMode = sslMode;
            ConfReader = confReader;
        }
        #endregion

        #region Worker
        public string getConnectionString()
        {
            return $"server={Server};port={Port};user id={User}; password={Password}; database={Database}; SslMode={SslMode}";
        }
        #endregion
    }
}