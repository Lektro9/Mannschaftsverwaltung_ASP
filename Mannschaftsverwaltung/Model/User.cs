using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mannschaftsverwaltung
{
    public class User
    {
        #region Eigenschaften
        private string _Login;
        private string _Password;
        #endregion

        #region Accessoren/Modifier
        public string Login { get => _Login; set => _Login = value; }
        public string Password { get => _Password; set => _Password = value; }
        #endregion

        #region Konstruktoren
        public User(string login, string password)
        {
            Login = login;
            Password = password;
        }
        #endregion

        #region Worker
        public bool auth(string login, string password)
        {
            if (login == this.Login && password == this.Password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
        #region Database

        #endregion

        #region Schnittstellen
        #endregion
    }
}