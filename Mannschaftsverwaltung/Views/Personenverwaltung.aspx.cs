using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mannschaftsverwaltung
{
    public partial class _Default : Page
    {
        private Controller _Verwalter;

        public Controller Verwalter { get => _Verwalter; set => _Verwalter = value; }

        protected void Page_Init(object sender, EventArgs e)
        {
            this.Verwalter = Global.Verwalter;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //foreach (string Sportart in this.Verwalter.Sportarten)
            //{
            //    TableRow neueZeile = new TableRow();
            //    TableCell neueZelle = new TableCell();

            //    neueZelle.Text = Sportart;

            //    neueZeile.Cells.Add(neueZelle);

            //    this.Table1.Rows.Add(neueZeile);
            //}
            //foreach (Person person in this.Verwalter.Personen)
            //{
            //    int Tore = ((FussballSpieler)person).GeschosseneTore;
            //}
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string selectedType = RadioButtonList1.SelectedValue;
            Response.Write(selectedType);
            
        }
    }
}