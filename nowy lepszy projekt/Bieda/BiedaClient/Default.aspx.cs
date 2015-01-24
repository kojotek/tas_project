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
        protected void Page_Load(object sender, EventArgs e)
        {
            
            //Button1.Visible
            BiedaServiceClient client = new BiedaServiceClient();


            //AuctionDataContract test = new AuctionDataContract();
            //client.getAuctions("", 1, 1, 1);
            //)
            //var test = client.getAuctions("", 1, 1, 1);
            /*List<string> test = */
               List<string> lista = new List<string>(client.getAuctionList("zaginiona", 3, 0, 0));
               // IList<string> lista = client.getAuctionList("zaginiona", 3, 0, 0);

                TextBox01.Text = lista[0];
                TextBox02.Text = lista[1];
                TextBox03.Text = lista[2];
                TextBox04.Text = lista[3];
                TextBox05.Text = lista[4];
                TextBox06.Text = lista[5];
                TextBox07.Text = lista[6];

                TextBox11.Text = lista[7];
                TextBox12.Text = lista[8];
                TextBox13.Text = lista[9];
                TextBox14.Text = lista[10];
                TextBox15.Text = lista[11];
                TextBox16.Text = lista[12];
                TextBox17.Text = lista[13];

                TextBox21.Text = lista[14];
                TextBox22.Text = lista[15];
                TextBox23.Text = lista[16];
                TextBox23.Text = lista[17];
                TextBox25.Text = lista[18];
                TextBox26.Text = lista[19];
                TextBox27.Text = lista[20];

                TextBox31.Text = lista[21];
                TextBox32.Text = lista[22];
                TextBox33.Text = lista[23];
                TextBox33.Text = lista[24];
                TextBox35.Text = lista[25];
                TextBox36.Text = lista[26];
                TextBox37.Text = lista[27];

                TextBox41.Text = lista[28];
                TextBox42.Text = lista[29];
                TextBox43.Text = lista[30];
                TextBox43.Text = lista[31];
                TextBox45.Text = lista[32];
                TextBox46.Text = lista[33];
                TextBox47.Text = lista[34];

                TextBox51.Text = lista[35];
                TextBox52.Text = lista[36];
                TextBox53.Text = lista[37];
                TextBox53.Text = lista[38];
                TextBox55.Text = lista[39];
                TextBox56.Text = lista[40];
                TextBox57.Text = lista[41];

                TextBox61.Text = lista[42];
                TextBox62.Text = lista[43];
                TextBox63.Text = lista[44];
                TextBox64.Text = lista[45];
                TextBox65.Text = lista[46];
                TextBox66.Text = lista[47];
                TextBox67.Text = lista[48];

                TextBox71.Text = lista[49];
                TextBox72.Text = lista[50];
                TextBox73.Text = lista[51];
                TextBox74.Text = lista[52];
                TextBox75.Text = lista[53];
                TextBox76.Text = lista[54];
                TextBox77.Text = lista[55];

                TextBox81.Text = lista[56];
                TextBox82.Text = lista[57];
                TextBox83.Text = lista[58];
                TextBox84.Text = lista[59];
                TextBox85.Text = lista[60];
                TextBox86.Text = lista[61];
                TextBox87.Text = lista[62];

                TextBox91.Text = lista[63];
                TextBox92.Text = lista[64];
                TextBox93.Text = lista[65];
                TextBox94.Text = lista[66];
                TextBox95.Text = lista[67];
                TextBox96.Text = lista[68];
                TextBox97.Text = lista[69];
                                      
        }
           
            protected void Search(object sender, EventArgs e)
        {
            if (IsValid)
            {
                var manager = new UserManager();
                ApplicationUser user = manager.Find(TextBox_haslo.Text, DropDownList_kategoria.Text, DropDownList_sortuj.Text, DropDownList_kierunek.Text);

                List<string> lista = new List<string>(client.getAuctionList(TextBox_haslo.Text, DropDownList_kategoria.Text, DropDownList_sortuj.Text, DropDownList_kierunek.Text));
            }
            
        }
    }
}

/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using BiedaClient.Models;
using System.Data.SqlClient;
using MyWCFServices;

namespace BiedaClient
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BiedaServiceClient client = new BiedaServiceClient();

           
            //AuctionDataContract test = new AuctionDataContract();
            //client.getAuctions("", 1, 1, 1);
            //)
            //var test = client.getAuctions("", 1, 1, 1);
            IList<AuctionData> test = client.getAuctions("8000 beko", 3, 0, 0);

            bool sw = true;

            foreach (var item in test)
            {
                TableCell a = new TableCell();
                a.Text = item.NazwaProduktu;
                a.Width = 200;

                TableRow r = new TableRow();
                r.Controls.Add(a);
 
                if (sw) { r.BackColor = System.Drawing.Color.FromName("#FFBC79"); }
                else { r.BackColor = System.Drawing.Color.FromName("#FF9D3C"); }
                sw = !sw;

                //Table2.Controls.Add(r);
            }

            //błedy na ćwiczeniach
            
        }
    }
}*/