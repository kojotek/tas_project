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
            BiedaServiceClient client = new BiedaServiceClient();
            string dr =  client.GetMessage2("damianek", "damianek1");
            Label1.Text = dr;
        }
    }
}