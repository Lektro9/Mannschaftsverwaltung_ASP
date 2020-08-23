//Autor:        Kroll
//Datum:        06.02.2020
//Dateiname:    Enums.cs
//Beschreibung: Speichert alle möglichen Enums ab und weißt ihnen Zahlen zu zum Vergleichen
//Änderungen:
//11.02.2020:   Entwicklungsbeginn

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mannschaftsverwaltung
{
    public enum Turnierstatus
    {
        Gestartet = 0,
        Beendet = 1,
    }

    public enum Role
    {
        ADMIN = 0,
        USER = 1,
    }
}
