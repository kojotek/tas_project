using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BiedaClient.Auction
{
    public partial class AuctionView : System.Web.UI.Page
    {
        BiedaServiceClient bieda = new BiedaServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            var auctionId = int.Parse(Request.QueryString["id"]);
        }

        protected void BidClick(object sender, EventArgs e)
        {
            
        }
    }
}