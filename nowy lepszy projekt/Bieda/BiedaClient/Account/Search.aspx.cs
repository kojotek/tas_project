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
            string[] test = client.getAuctions("8000 beko", 3, 0, 0);

            bool sw = true;

            foreach (string s in test)
            {
                TableCell a = new TableCell();
                a.Text = s;
                a.Width = 200;

                TableRow r = new TableRow();
                r.Controls.Add(a);
 
                if (sw) { r.BackColor = System.Drawing.Color.FromName("#FFBC79"); }
                else { r.BackColor = System.Drawing.Color.FromName("#FF9D3C"); }
                sw = !sw;

                Table2.Controls.Add(r);
            }

            //błedy na ćwiczeniach
            
        }
    }
}