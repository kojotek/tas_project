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

        Int32 numer;

        protected void Page_Load(object sender, EventArgs e)
        {
            BiedaServiceClient client = new BiedaServiceClient();




            zlozOferte.Visible = false;
            oferta.Visible = false;
            opinia.Visible = false;
            opiniaError.Visible = false;
            dodajOcene.Visible = false;
            ocena.Visible = false;

            
            
            string parameter = Request.QueryString["numer"];

            if (!String.IsNullOrEmpty(parameter)){
                numer = Convert.ToInt32(parameter);
            }
            else{
                return;
            }




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




            if (Context.User.Identity.IsAuthenticated)
            {
                if (!client.isAuctionOver(numer))
                {
                    if (client.getAuctionWinner(numer) == Context.User.Identity.GetUserName())
                    {
                        LabelState.Text = "Twoja oferta jest najlepsza.";
                    }
                    else
                    {
                        LabelState.Text = "Przebij najlepszą ofertę, by przejąć prowadzenie w licytacji.";
                    }
                }
                else
                {
                    if (client.getAuctionWinner(numer) == Context.User.Identity.GetUserName())
                    {
                        LabelState.Text = "Jesteś zwycięzcą tej aukcji.";
                    }
                    else
                    {
                        LabelState.Text = "Ta aukcja już się zakończyła.";
                    }
                }
            }
            else
            {
                if (!client.isAuctionOver(numer))
                {
                    LabelState.Text = "Zaloguj się, by wziąć udział w licytacji.";
                }
                else
                {
                    LabelState.Text = "Ta aukcja już się zakończyła.";
                }
            }



            
            LabelLogin.Text = "Aukcja użytkownika ";
            link.Text = lista[1];
            link.NavigateUrl = "AboutUser?usr=" + lista[1];
            LabelName.Text =  "(" + lista[0] + ") " + lista[2];
            LabelPrice.Text = lista[3];
            LabelSendPrice.Text = lista[4];
            LabelTime.Text = "Zakończenie aukcji: " + lista[5];
            TextBoxDescription.Text = lista[6];
            LabelActualPrice.Text =  client.getAuctionHighestOffer(numer) + " zł";


            if (!client.isAuctionOver(numer) && client.getAuctionWinner(numer) != Context.User.Identity.GetUserName() && Context.User.Identity.IsAuthenticated )
            {
                zlozOferte.Visible = true;
                oferta.Visible = true;
            }



            if (client.isAuctionOver(numer) )
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
            BiedaServiceClient client = new BiedaServiceClient();

            opiniaError.Visible = true;
            opiniaError.Text = client.addOffer( numer, User.Identity.GetUserName(), oferta.Text );

            if (client.getAuctionWinner(numer) == Context.User.Identity.GetUserName())
            {
                    oferta.Visible = false;
                    zlozOferte.Visible = false;
            }

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