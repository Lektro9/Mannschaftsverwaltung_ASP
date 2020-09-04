//Autor:        Kroll
//Datum:        05.08.2020
//Dateiname:    Login.aspx.cs
//Beschreibung: Verwaltet Authentifizierung von Usern

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mannschaftsverwaltung
{
    public partial class Login : Page
    {
        private Controller _Verwalter;

        public Controller Verwalter { get => _Verwalter; set => _Verwalter = value; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["Verwalter"] != null)
            {
                Verwalter = (Controller)this.Session["Verwalter"];
                if (this.Verwalter.Authenticated)
                {
                    this.Session[this.Verwalter.ActiveUser.ID.ToString()] = new Controller();
                    User currentUser = this.Verwalter.ActiveUser;
                    Verwalter = (Controller)this.Session[this.Verwalter.ActiveUser.ID.ToString()];
                    Verwalter.Authenticated = true;
                    Verwalter.ActiveUser = currentUser;
                }
                //for checking DB connectivity
                Verwalter.DBManager.openDBConection();
                if (Verwalter.DBManager.DBStatus)
                {
                    Verwalter.DBManager.closeConnection();
                }
            }
            else
            {
                this.Session["Verwalter"] = new Controller();
                Verwalter = (Controller)this.Session["Verwalter"];
                //for checking DB connectivity
                Verwalter.DBManager.openDBConection();
                if (Verwalter.DBManager.DBStatus)
                {
                    Verwalter.DBManager.closeConnection();
                }
            }
        }

        protected void login_Click(object sender, EventArgs e)
        {
            string username = this.Request.Form["uname1"];
            string password = this.Request.Form["password"];
            //get User from DB
            Verwalter.DBManager.openDBConection();
            if (Verwalter.DBManager.DBStatus)
            {
                Verwalter.Nutzer = Verwalter.DBManager.getAllUser();
                Verwalter.DBManager.closeConnection();
            }

            this.Verwalter.login(username, password);

            Response.Redirect(Request.RawUrl);
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            this.Session["Verwalter"] = new Controller();
            Verwalter = (Controller)this.Session["Verwalter"];
            Response.Redirect(Request.RawUrl);
        }
    }
}