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
//using MyWCFServices;

namespace BiedaClient
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BiedaServiceClient client = new BiedaServiceClient();

            //AuctionDataContract test = new AuctionDataContract(
            // client.getAuctions("", 1, 1, 1);
            //)
            //var test = client.getAuctions("", 1, 1, 1);
            string[] test = client.getAuctions("", 1, 1, 1);

            //błedy na ćwiczeniach
            ;
        }
    }
}