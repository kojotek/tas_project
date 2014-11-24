using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using ProjektBieda.Models;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;

namespace ProjektBieda.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        protected bool SprawdzJegomoscia(string user, string pass)
        {
            string serverName = "mssql.wmi.amu.edu.pl";
            string database = "dtas_s383964";
            string userId = "s383964";
            string password = "674lCgcV";

            bool cacy = false;

            SqlConnection conn = null; SqlCommand cmd = null;
            try { conn = new SqlConnection("Server=" + serverName + ";Database=" + database + ";User Id=" + userId + ";Password=" + password + ";"); conn.Open(); }
            catch (InvalidOperationException ex) { System.Web.HttpContext.Current.Response.Write("<SCRIPT LANGUAGE=\"\"JavaScript\"\">alert(\"Klient\")</SCRIPT>"); }
            catch (SqlException ex) { System.Web.HttpContext.Current.Response.Write("<SCRIPT LANGUAGE=\"\"JavaScript\"\">alert(\"serwer!\")</SCRIPT>"); }
            finally
            {
                try
                {
                    cmd = new SqlCommand
                    ("select login from KLIENT where login = \'" + user + "\' and haslo = \'" + pass + "\' and data_do is null", conn);
                    SqlDataReader dr = cmd.ExecuteReader();

                    while(dr.Read())
                    {
                        if (dr["login"].ToString() == user) { cacy = true; }
                        else { cacy = false; }
                    }
                    
                }

                catch (SqlException elol)
                {
                    FailureText.Text = "MS SQL ERROR";
                    ErrorMessage.Visible = true;
                }

                finally
                {
                    conn.Close();
                }
            }

            return cacy;
        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {
                //Validate the user password
                var manager = new UserManager();
                ApplicationUser user = manager.Find(UserName.Text, Password.Text);
                if (SprawdzJegomoscia(UserName.Text, Password.Text))
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

                        else { FailureText.Text = "ASP AUTHENTIFICATION ERROR"; }
                        ErrorMessage.Visible = true;
                    }
                }
                else
                {
                    FailureText.Text = "Invalid username or password.";
                    ErrorMessage.Visible = true;
                }
            }
        }
    }
}