using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mannschaftsverwaltung
{
    public class User
    {
        #region Eigenschaften
        private int _iD;
        private string _Login;
        private string _Password;
        private Role _rolle;
        #endregion

        #region Accessoren/Modifier
        public string Login { get => _Login; set => _Login = value; }
        public string Password { get => _Password; set => _Password = value; }
        public int ID { get => _iD; set => _iD = value; }
        public Role Rolle { get => _rolle; set => _rolle = value; }
        #endregion

        #region Konstruktoren
        public User(int id, string login, string password, Role rolle)
        {
            ID = id;
            Login = login;
            Password = password;
            Rolle = rolle;
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