﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BiedaClient.Auction
{
    public partial class AuctionList : System.Web.UI.Page
    {
        protected int rowIndex = 0;
        protected int rowCount = 20;
        protected BiedaServiceClient biedaWebService = new BiedaServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AuctionListNextPage(object sender, EventArgs e)
        {
            rowIndex += rowCount;
            StringBuilder sb = new StringBuilder();
            sb.Append("~/Auction/List?")
                .Append("row_index=").Append(rowIndex)
                .Append("&row_count=").Append(rowCount);
            Response.Redirect(sb.ToString());
        }

        protected void AuctionListPrevPage(object sender, EventArgs e)
        {
            rowIndex -= rowCount;
            rowIndex = rowIndex > 0 ? rowIndex : 0;
            StringBuilder sb = new StringBuilder();
            sb.Append("~/Auction/List?")
                .Append("row_index=").Append(rowIndex)
                .Append("&row_count=").Append(rowCount);
            Response.Redirect("~/Auction/List");
        }
    }
}