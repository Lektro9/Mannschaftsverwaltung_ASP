//Autor:        Kroll
//Datum:        20.08.2020
//Dateiname:    ConfReader.cs
//Beschreibung: Auslesen von Konfigurationsdateien
//Änderungen:
//20.08.2020:   Entwicklungsbeginn 

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Hosting;

namespace Mannschaftsverwaltung
{
    public class ConfReader
    {
        #region Eigenschaften
        string _confFilePath;
        Dictionary<string, string> properties;
        #endregion

        #region Accessoren/Modifier
        public string ConfFilePath { get => _confFilePath; set => _confFilePath = value; }
        public Dictionary<string, string> Properties { get => properties; set => properties = value; }
        #endregion

        #region Konstruktoren
        public ConfReader()
        {
            string pwd = HostingEnvironment.ApplicationPhysicalPath;
            ConfFilePath = pwd + @"DataBaseConfig.conf";
            Properties = new Dictionary<string, string>();
        }

        #endregion

        #region Worker
        public Dictionary<string, string> getConfData()
        {
            foreach (var row in File.ReadAllLines(ConfFilePath))
            {
                Properties.Add(row.Split('=')[0], string.Join("=", row.Split('=').Skip(1).ToArray()));
            }
            return this.Properties;
        }
        #endregion
    }
}