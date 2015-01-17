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
    public partial class About : Page
    {

        int numer = 19;

        protected void Page_Load(object sender, EventArgs e)
        {

            BiedaServiceClient client = new BiedaServiceClient();
            List<string> lista = new List<string>(client.getAuctionInfo(numer));

            if(!Page.IsPostBack)
            {
                kontrolka.Text = "false";
                ocena.Items.Add(new ListItem(""));
                for (int a = 0; a < 5; a++)
                {
                    ListItem li = new ListItem((a + 1).ToString());
                    ocena.Items.Add(li);
                }
            }


            if (client.getAuctionWinner(numer) == Context.User.Identity.GetUserName())
            {
                LabelState.Text = "Twoja oferta jest najlepsza.";
            }
            else
            {
                LabelState.Text = "Przebij najlepszą ofertę, by przejąć prowadzenie w licytacji.";
            }

            
            LabelLogin.Text = "Aukcja użytkownika " + lista[1];
            LabelName.Text =  "(" + lista[0] + ") " + lista[2];
            LabelPrice.Text = lista[3];
            LabelSendPrice.Text = lista[4];
            LabelTime.Text = "Zakończenie aukcji: " + lista[5];
            TextBoxDescription.Text = lista[6];

            LabelActualPrice.Text = client.getAuctionHighestOffer(numer);

            zlozOferte.Visible = false;
            oferta.Visible = false;
            opinia.Visible = false;
            dodajOcene.Visible = false;
            ocena.Visible = false;

            if ( !client.isAuctionOver(numer) )
            {
                zlozOferte.Visible = true;
                oferta.Visible = true;
            }
            else
            {
                LabelName.Text += " (ZAKOŃCZONA)";
                if ( client.getAuctionWinner(numer) == Context.User.Identity.GetUserName() )
                {

                    if (!client.AuctionAllreadyCommented(numer) && kontrolka.Text == "false")
                    {
                        opinia.Visible = true;
                        dodajOcene.Visible = true;
                        ocena.Visible = true;
                    }
                }
            }

        }


        protected void zlozOferte_Click(object sender, EventArgs e)
        {

        }



        protected void dodajOpinie_Click(object sender, EventArgs e)
        {
            BiedaServiceClient client = new BiedaServiceClient();

            opiniaError.Text = "";
            bool ready = true;
            
            if( opinia.Text.Length < 10 )
            {
                opiniaError.Text = "Twoja opinia jest za krótka.";
                ready = false;
            }
            
            if( ocena.SelectedIndex == 0 )
            {
                opiniaError.Text = "Musisz wybrać ocenę.";
                ready = false;
            }


            if( ready )
            {
                client.addComment( numer, Context.User.Identity.GetUserName(), opinia.Text, ocena.SelectedIndex );
                zlozOferte.Visible = false;
                oferta.Visible = false;
                opinia.Visible = false;
                dodajOcene.Visible = false;
                ocena.Visible = false;
            }
            
        }

    }
}