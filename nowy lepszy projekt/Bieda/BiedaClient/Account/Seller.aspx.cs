using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BiedaClient.Account
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        BiedaServiceClient client = new BiedaServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if(client.IsSeller(Context.User.Identity.GetUserName()) == "git")
                {
                    NoAccess.Visible = false;
                    Access.Visible = true;
                }
            }    
        }
    }
}