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
                categoryListDropdown.DataSource = categoryList.Select(x => x.Name);
                categoryListDropdown.DataBind();
            }   
        
        }

        protected void CreateAuctionClick(object sender, EventArgs e)
        {
            if (!Page.IsValid)  
            {
                return;
            }

            var userId = System.Web.HttpContext.Current.User.Identity.Name;

            string categoryName = categoryListDropdown.Items[categoryListDropdown.SelectedIndex > 0 ? categoryListDropdown.SelectedIndex : 0].Text;

            bool success = bieda.createAuction(userId, categoryName, itemNameTextBox.Text, descriptionTextBox.Text,
               decimal.Parse(priceEditBox.Text), decimal.Parse(deliveryTextBox.Text), int.Parse(expireTimeEditBox.Text));

            if (success)
                Response.Redirect("~/Auction/List?row_index=0&row_count=20");

        }


    }
}