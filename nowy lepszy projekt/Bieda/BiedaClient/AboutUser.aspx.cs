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
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BiedaClient
{
    public partial class AboutUser : Page
    {

        string login;

        protected void Page_Load(object sender, EventArgs e)
        {
            BiedaServiceClient client = new BiedaServiceClient();

            if( User.Identity.IsAuthenticated )
            {

                login = Request.QueryString["usr"];

                if (String.IsNullOrEmpty(login))
                {
                    return;
                }


                LabelName.Visible = true;
                LabelEmail.Visible = true;
                LabelNumber.Visible = true;
                LabelPersonal.Visible = true;

                LabelName.Text = "Dane użytkownika " + login;
                LabelEmail.Text = "e-mail: ";
                LabelNumber.Text = "Numer Telefonu: ";
                LabelPersonal.Text = "Imię i Nazwisko: ";

                List<string> lista = new List<string>( client.getUserInfo(login) );

                if( lista.Count != 0 )
                {
                    LabelEmail.Text = "<b>e-mail:</b> " + lista[3];
                    LabelNumber.Text = "<b>Numer Telefonu:</b> " + lista[2];
                    LabelPersonal.Text = "<b>Imię i Nazwisko:</b> " + lista[0] + " " + lista[1];
                }
                else
                {
                    LabelPersonal.Visible = true;
                    LabelEmail.Visible = false;
                    LabelNumber.Visible = false;
                    LabelPersonal.Text = "Podany użytkownik nie istnieje. Zostałeś oszukany.</br>Przykro nam.</br>Zespół Bieda.pl świetnie rozumie, jak czuje się okłamany człowiek.</br>Płacz, jeżeli Ci to pomoże. To nieprawda, że mężczyźni nie płaczą.</br>To tylko brzydki, krzywdzący stereotyp.";
                    return;
                }

            }
            else
            {

                LabelName.Visible = true;
                LabelEmail.Visible = false;
                LabelNumber.Visible = false;
                LabelPersonal.Visible = false;

                LabelName.Text = "Nie masz uprawnień do oglądania tej strony.</br>Zaloguj się lub załóż konto.";

            }

        }


    }
}