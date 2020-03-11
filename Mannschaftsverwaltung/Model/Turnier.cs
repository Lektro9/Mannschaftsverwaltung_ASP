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
        #endregion

        #region Accessoren/Modifier
        public int ID { get => _ID; set => _ID = value; }
        public Turnierstatus Status { get => _status; set => _status = value; }
        #endregion

        #region Konstruktoren
        public Turnier()
        {
            ID = -1;
            Status = Turnierstatus.Vorbereitung;
        }
        //Spezialkonstruktor
        public Turnier(int id)
        {
            this.ID = id;
            Status = Turnierstatus.Vorbereitung;
        }
        public Turnier(int id, Turnierstatus status)
        {
            this.ID = id;
            Status = status;
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
