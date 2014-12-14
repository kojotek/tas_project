using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;
using System.Globalization;

namespace BiedaClient
{
    public partial class About : Page
    {

        int numer = 36;

        protected void Page_Load(object sender, EventArgs e)
        {
            BiedaServiceClient client = new BiedaServiceClient();
            List<string> lista = new List<string>(client.getAuctionInfo(numer));
            LabelLogin.Text = "Aukcja użytkownika " + lista[1];
            LabelName.Text =  "(" + lista[0] + ") " + lista[2];
            LabelPrice.Text = lista[3];
            LabelSendPrice.Text = lista[4];
            LabelTime.Text = "Zakończenie aukcji: " + lista[5];
            TextBoxDescription.Text = lista[6];

            if ( client.isAuctionOver(numer) )
            {
                LabelName.Text += " (ZAKOŃCZONA)";
            }

        }

    }
}