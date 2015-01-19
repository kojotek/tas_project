using MyWCFServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BiedaClient.Auction
{
    public partial class AuctionCreatorPage : System.Web.UI.Page
    {

        BiedaServiceClient bieda = new BiedaServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                IList<AuctionCategory> categories = bieda.getAuctionCategoryList();
                var categoryList = bieda.getAuctionCategoryList();
                cmb_CategoryList.DataSource = categoryList.Select(x => x.Name);
                cmb_CategoryList.DataBind();
            }   
        }

        protected void CreateAuctionClick(object sender, EventArgs e) 
        {
            var userId = System.Web.HttpContext.Current.User.Identity.Name;

            //var categoryList = bieda.getAuctionCategoryList();
            string categoryName = cmb_CategoryList.Items[cmb_CategoryList.SelectedIndex > 0 ? cmb_CategoryList.SelectedIndex : 0].Text;

            IList<int> auctionOldList = bieda.getAuctionListbyUserId(userId);

            bieda.createAuction(userId, categoryName, tb_Name.Text, tb_Description.Text,
              decimal.Parse(tb_Price.Text), decimal.Parse(tb_Delivery.Text), int.Parse(tb_ExpireTime.Text)); 

            IList<int> auctionNewList = bieda.getAuctionListbyUserId(userId);

            var diff = auctionNewList.Except(auctionOldList);

            if (diff.Count()>0)
                Response.Redirect("~/About?numer="+diff.FirstOrDefault());

        }


    }
}