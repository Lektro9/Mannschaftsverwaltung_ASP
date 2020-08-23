//Autor:        Kroll
//Datum:        06.02.2020
//Dateiname:    Turnier.cs
//Beschreibung: Definierung eines Tunieres im Sport
//Basisklasse
//Änderungen:
//11.02.2020:   Entwicklungsbeginn

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mannschaftsverwaltung
{
    public class Turnier
    {
        #region Eigenschaften
        private int _ID;
        private Turnierstatus _status;
        private List<Spiel> _spiele;
        private string _name;
        #endregion

        #region Accessoren/Modifier
        public int ID { get => _ID; set => _ID = value; }
        public Turnierstatus Status { get => _status; set => _status = value; }
        public List<Spiel> Spiele { get => _spiele; set => _spiele = value; }
        public string Name { get => _name; set => _name = value; }
        #endregion

        #region Konstruktoren
        public Turnier()
        {
            ID = -1;
            Status = Turnierstatus.Gestartet;
            Spiele = null;
        }
        //Spezialkonstruktor
        public Turnier(int id, string name, List<Spiel> spiele)
        {
            this.ID = id;
            this.Name = name;
            Status = Turnierstatus.Gestartet;
            this.Spiele = spiele;
        }
        public Turnier(int id, string name)
        {
            this.ID = id;
            this.Name = name;
            Status = Turnierstatus.Gestartet;
            this.Spiele = new List<Spiel>();
        }
        public Turnier(int id, string name, int turnierstatus)
        {
            this.ID = id;
            this.Name = name;
            Status = (Turnierstatus)turnierstatus;
            this.Spiele = new List<Spiel>();
        }
        //Kopierkonstruktor
        public Turnier(Turnier t)
        {
            this.ID = t.ID;
            this.Status = t.Status;
        }
        #endregion

        #region Worker
        public void aendereStatus(Turnierstatus s)
        {
            Status = s;
        }
        #endregion

        #region Schnittstellen
        #endregion
    }
}
