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

            if (!lista.Any())
            {
                return;
            }

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
            LabelActualPrice.Text =  client.getAuctionHighestOffer(numer);
            if (LabelActualPrice.Text != "Brak ofert")
                LabelActualPrice.Text += " zł";


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

            refreshOffers();

            if( lista[1] == User.Identity.Name )
            {
                zlozOferte.Visible = false;
                oferta.Visible = false;
                LabelState.Text = "Jesteś właścicielem tej aukcji.";
            }

        }

        



        protected void zlozOferte_Click(object sender, EventArgs e)
        {
            BiedaServiceClient client = new BiedaServiceClient();

            opiniaError.Visible = true;
            opiniaError.Text = client.addOffer( numer, User.Identity.GetUserName(), oferta.Text );

            if (client.getAuctionWinner(numer) == Context.User.Identity.GetUserName())
            {
                LabelState.Text = "Twoja oferta jest najlepsza.";
                oferta.Visible = false;
                zlozOferte.Visible = false;
                LabelActualPrice.Text = oferta.Text;
                if (LabelActualPrice.Text != "Brak ofert")
                    LabelActualPrice.Text += " zł";
            }

            refreshOffers();
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



        protected void refreshOffers()
        {
            BiedaServiceClient client = new BiedaServiceClient();

            bool switcher = false;

            List<string> lista = new List<string>(client.getOffers(numer));

            TableOferty.Controls.Clear();



            TableCell t1 = new TableCell();
            t1.BackColor = System.Drawing.Color.White;
            t1.Width = 700;
            Label tl1 = new Label();
            tl1.Font.Size = FontUnit.Large;
            tl1.Font.Bold = true;
            tl1.Text = "Użytkownik";
            t1.Controls.Add(tl1);

            TableCell t2 = new TableCell();
            t2.BackColor = System.Drawing.Color.White;
            t2.Width = 700;
            Label tl2 = new Label();
            tl2.Font.Size = FontUnit.Large;
            tl2.Font.Bold = true;
            tl2.Text = "Kwota";
            t2.Controls.Add(tl2);

            TableCell t3 = new TableCell();
            t3.BackColor = System.Drawing.Color.White;
            t3.Width = 700;
            Label tl3 = new Label();
            tl3.Font.Size = FontUnit.Large;
            tl3.Font.Bold = true;
            tl3.Text = "Data";
            t3.Controls.Add(tl3);

            TableRow tr = new TableRow();
            tr.BorderColor = System.Drawing.Color.Black;
            tr.BorderWidth = 3;
            tr.Controls.Add(t1);
            tr.Controls.Add(t2);
            tr.Controls.Add(t3);


            TableOferty.Controls.Add(tr);


            for (int i = 0; i < lista.Count; i = i + 3)
            {
                TableCell c1 = new TableCell();
                if(switcher)
                    c1.BackColor = System.Drawing.Color.FromName("#FFBC79");
                else
                    c1.BackColor = System.Drawing.Color.FromName("#FF9D3C");
                c1.Width = 700;
                HyperLink l1 = new HyperLink();
                l1.NavigateUrl = "/aboutUser?usr=" + lista[i];
                l1.Font.Size = FontUnit.Large;
                l1.Font.Bold = true;
                l1.Text = lista[i];
                c1.Controls.Add(l1);

                TableCell c2 = new TableCell();
                if (switcher)
                    c2.BackColor = System.Drawing.Color.FromName("#FFBC79");
                else
                    c2.BackColor = System.Drawing.Color.FromName("#FF9D3C");
                c2.Width = 200;
                Label l2 = new Label();
                l2.Font.Size = FontUnit.Large;
                l2.Font.Bold = true;
                l2.Text = "   " + lista[i+1];
                c2.Controls.Add(l2);

                TableCell c3 = new TableCell();
                if (switcher)
                    c3.BackColor = System.Drawing.Color.FromName("#FFBC79");
                else
                    c3.BackColor = System.Drawing.Color.FromName("#FF9D3C");
                c3.Width = 300;
                Label l3 = new Label();
                l3.Font.Size = FontUnit.Large;
                l3.Font.Bold = true;
                l3.Text = lista[i+2];
                c3.Controls.Add(l3);

                TableRow r = new TableRow();
                r.BorderColor = System.Drawing.Color.Black;
                r.BorderWidth = 3;
                r.Controls.Add(c1);
                r.Controls.Add(c2);
                r.Controls.Add(c3);

                TableOferty.Controls.Add(r);
                TableOferty.Visible = true;

                switcher = !switcher;
            }
        }

    }
}