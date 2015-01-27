using MyWCFServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ServiceModel;
using BiedaClient;
using System.Data.SqlClient;
using BiedaClient.Models;

namespace BiedaClient
{
    public partial class _Default : Page
    {
        BiedaServiceClient client = new BiedaServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        { 
            if (!IsPostBack)
            {
                IList<AuctionCategory> categories = client.getAuctionCategoryList();
                var categoryList = client.getAuctionCategoryList();
                DropDownList_kategoria.DataSource = categoryList.Select(x => x.Name);
                DropDownList_kategoria.DataBind(); 
                
                Search("", "null", 0, 1); //Defaultowo wyświetlamy wszystkie aukcje w kolejności od tych, które kończą się najszybiej
            }  
        }
           
        protected void Search_Click(object sender, EventArgs e)
        {   
            string kategoria;
            switch(DropDownList_kategoria.Text)
            {
                case "wszystkie": kategoria = "null"; break;
                case "RTV": kategoria = "2"; break;
                case "AGD": kategoria = "3"; break;
                case "sport": kategoria = "4"; break;
                case "komputery": kategoria = "5"; break;

                default: kategoria = "null"; break;
            }

            int sortuj;
            switch (DropDownList_sortuj.Text)
            {
                case "Cena": sortuj = 1; break;
                case "Data zakończenia": sortuj = 0; break;

                default: sortuj = 1; break;
            }

            int kierunek;
            switch (DropDownList_kierunek.Text)
            {
                case "Rosnąco": kierunek = 1; break;
                case "Malejąco": kierunek = 0; break;

                default: kierunek = 1; break;
            }
            //sortowanie trzeba dorobic, narazie ustawilem domyslnie 0
            /*Search(TextBox_haslo.Text, kategoria, 0 /*Convert.ToInt16(DropDownList_sortuj.Text)*, 0 *Convert.ToInt16(DropDownList_kierunek.Text)*);*/
            Search(TextBox_haslo.Text, kategoria, sortuj, kierunek); 
        }

        protected void Search(string haslo, string kategoria, int sortuj, int kierunek)
        {
            List<string> lista = new List<string>(client.getAuctionList( haslo, kategoria, sortuj, kierunek));

            Table1.Visible = false;

            for (int i = 0; i < lista.Count; i = i + 8)
            {
                string link = "About?numer=" + lista[7];

                TableCell c1 = new TableCell();
                c1.BackColor = System.Drawing.Color.FromName("#FFCC66");
                Label l1 = new Label();
                l1.Font.Size = FontUnit.Large;
                l1.Font.Bold = true;
                l1.Text = lista[i];
                c1.Controls.Add(l1);

                TableCell c2 = new TableCell();
                c2.BackColor = System.Drawing.Color.FromName("#FFFF66");
                Label l2 = new Label();
                l2.Font.Size = FontUnit.Large;
                l2.Font.Bold = true;
                l2.Text = lista[i + 1];
                c2.Controls.Add(l2);

                TableCell c3 = new TableCell();
                c3.BackColor = System.Drawing.Color.FromName("#FFFF99");
                HyperLink l3 = new HyperLink();
                l3.NavigateUrl = link;
                l3.Font.Size = FontUnit.Large;
                l3.Font.Bold = true;
                l3.Text = lista[i + 2];
                c3.Controls.Add(l3);

                TableCell c4 = new TableCell();
                c4.BackColor = System.Drawing.Color.FromName("#FFFFCC");
                Label l4 = new Label();
                l4.Font.Size = FontUnit.Large;
                l4.Font.Bold = true;
                l4.Text = lista[i + 3];
                c4.Controls.Add(l4);

                TableCell c5 = new TableCell();
                c5.BackColor = System.Drawing.Color.FromName("White");
                Label l5 = new Label();
                l5.Font.Size = FontUnit.Large;
                l5.Font.Bold = true;
                l5.Text = lista[i + 4];
                c5.Controls.Add(l5);

                TableCell c6 = new TableCell();
                c6.BackColor = System.Drawing.Color.FromName("#CCFFFF");
                Label l6 = new Label();
                l6.Font.Size = FontUnit.Large;
                l6.Font.Bold = true;
                l6.Text = lista[i + 5];
                c6.Controls.Add(l6);

                TableCell c7 = new TableCell();
                c7.BackColor = System.Drawing.Color.FromName("#66FFFF");
                Label l7 = new Label();
                l7.Font.Size = FontUnit.Large;
                l7.Font.Bold = true;
                l7.Text = lista[i + 6];
                c7.Controls.Add(l7);

                TableRow r = new TableRow();
                r.BorderColor = System.Drawing.Color.Black;
                r.BorderWidth = 3;
                r.Controls.Add(c1);
                r.Controls.Add(c2);
                r.Controls.Add(c3);
                r.Controls.Add(c4);
                r.Controls.Add(c5);
                r.Controls.Add(c6);
                r.Controls.Add(c7);

                Table1.Controls.Add(r);
                Table1.Visible = true;
            }  
             
        }

    }
}
