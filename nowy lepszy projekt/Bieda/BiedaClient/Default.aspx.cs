﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ServiceModel;
using BiedaClient;
using System.Data.SqlClient;

namespace BiedaClient
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox01.Text = "basketo_pl";
            //Button1.Visible
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