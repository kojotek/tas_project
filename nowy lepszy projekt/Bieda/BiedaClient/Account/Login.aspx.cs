using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using BiedaClient.Models;

namespace BiedaClient.Account
{
    public partial class Login : Page
    {
        BiedaServiceClient client = new BiedaServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {
                var manager = new UserManager();
                ApplicationUser user = manager.Find(UserName.Text, Password.Text);

                string wynik = client.LoginIn(UserName.Text, Password.Text);

                if (wynik == "git")
                {
                    Session["zalogowand"] = UserName.Text; 
                    
                    if(user != null)
                    {
                        IdentityHelper.SignIn(manager, user, RememberMe.Checked);
                        IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                    }

                    else
                    {
                        var reg_user = new ApplicationUser() { UserName = UserName.Text };
                        IdentityResult result = manager.Create(reg_user, Password.Text);
                        if (result.Succeeded)
                        {
                            IdentityHelper.SignIn(manager, reg_user, isPersistent: false);
                            IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                        }

                        else 
                        { 
                            ErrorMsg.Text = "CRITICAL ERROR IN ASP AUTHENTIFICATION SYSTEM!!!";
                            ErrorMsg.Visible = true;
                            ErrorMsg.ForeColor = System.Drawing.Color.Red;
                        }     
                    }
                }
                else
                {
                    ErrorMsg.Text = wynik;
                    ErrorMsg.Visible = true;
                    ErrorMsg.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
    }
}