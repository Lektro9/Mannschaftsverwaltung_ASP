using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mannschaftsverwaltung
{
    public partial class SiteMaster : MasterPage
    {
        private Controller _Verwalter;

        public Controller Verwalter { get => _Verwalter; set => _Verwalter = value; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["Verwalter"] != null)
            {
                Verwalter = (Controller)this.Session["Verwalter"];
                if (this.Verwalter.ActiveUser != null)
                {
                    Verwalter = (Controller)this.Session[this.Verwalter.ActiveUser.ID.ToString()];
                }
            }
            else
            {
            }
            this.Verwalter.IsError = false;
            this.Verwalter.ErrorMsg = "";
        }
    }
}