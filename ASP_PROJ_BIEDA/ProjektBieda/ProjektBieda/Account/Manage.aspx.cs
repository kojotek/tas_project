using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using ProjektBieda.Models;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;

namespace ProjektBieda.Account
{
    public partial class Manage : System.Web.UI.Page
    {
       /* protected string SuccessMessage
        {
            get;
            private set;
        }

        protected bool CanRemoveExternalLogins
        {
            get;
            private set;
        }

        private bool HasPassword(UserManager manager)
        {
            var user = manager.FindById(User.Identity.GetUserId());
            return (user != null && user.PasswordHash != null);
        }
        
        protected void Page_Load()
        {
            if (!IsPostBack)
            {
                // Determine the sections to render
                UserManager manager = new UserManager();
                if (HasPassword(manager))
                {
                    changePasswordHolder.Visible = true;
                }
                else
                {
                    setPassword.Visible = true;
                    changePasswordHolder.Visible = false;
                }
                CanRemoveExternalLogins = manager.GetLogins(User.Identity.GetUserId()).Count() > 1;

                // Render success message
                var message = Request.QueryString["m"];
                if (message != null)
                {
                    // Strip the query string from action
                    Form.Action = ResolveUrl("~/Account/Manage");

                    SuccessMessage =
                        message == "ChangePwdSuccess" ? "Your password has been changed."
                        : message == "SetPwdSuccess" ? "Your password has been set."
                        : message == "RemoveLoginSuccess" ? "The account was removed."
                        : String.Empty;
                    successMessage.Visible = !String.IsNullOrEmpty(SuccessMessage);
                }
            }
        }
        
        protected void ChangePassword_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                UserManager manager = new UserManager();
                IdentityResult result = manager.ChangePassword(User.Identity.GetUserId(), CurrentPassword.Text, NewPassword.Text);
                if (result.Succeeded)
                {
                    Response.Redirect("~/Account/Manage?m=ChangePwdSuccess");
                }
                else
                {
                    AddErrors(result);
                }
            }
        }

        protected void SetPassword_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                // Create the local login info and link the local account to the user
                UserManager manager = new UserManager();
                IdentityResult result = manager.AddPassword(User.Identity.GetUserId(), password.Text);
                if (result.Succeeded)
                {
                    Response.Redirect("~/Account/Manage?m=SetPwdSuccess");
                }
                else
                {
                    AddErrors(result);
                }
            }
        }

        public IEnumerable<UserLoginInfo> GetLogins()
        {
            UserManager manager = new UserManager();
            var accounts = manager.GetLogins(User.Identity.GetUserId());
            CanRemoveExternalLogins = accounts.Count() > 1 || HasPassword(manager);
            return accounts;
        }

        public void RemoveLogin(string loginProvider, string providerKey)
        {
            UserManager manager = new UserManager();
            var result = manager.RemoveLogin(User.Identity.GetUserId(), new UserLoginInfo(loginProvider, providerKey));
            var msg = result.Succeeded
                ? "?m=RemoveLoginSuccess"
                : String.Empty;
            Response.Redirect("~/Account/Manage" + msg);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }*/

        SqlConnection conn;


        public void SqlConnect(string serverName, string database, string userId, string password)
        {
            conn = null;

            try
            {
                conn = new SqlConnection("Server=" + serverName + ";Database=" + database + ";User Id=" + userId + ";Password=" + password + ";");
                conn.Open();
            }
            catch (InvalidOperationException ex)
            {
                System.Web.HttpContext.Current.Response.Write("<SCRIPT LANGUAGE=\"\"JavaScript\"\">alert(\"Błąd klienta\")</SCRIPT>");
                conn.Close();
            }
            catch (SqlException ex)
            {
                System.Web.HttpContext.Current.Response.Write("<SCRIPT LANGUAGE=\"\"JavaScript\"\">alert(\"Błąd serwera SQL\")</SCRIPT>");
                conn.Close();
            }
        }



        protected void endConnection()
        {
            conn.Close();
        }



        protected void LoadUserInfo()
        {
            SqlConnect("mssql.wmi.amu.edu.pl", "dtas_s383964", "s383964", "674lCgcV");

            SqlCommand cmd = new SqlCommand("select * from KLIENT INNER JOIN DANE on klient.id_dane = dane.id_dane where klient.login = \'"
                + Context.User.Identity.GetUserName() + "\'", conn);
            SqlDataReader dr = cmd.ExecuteReader();

            try
            {
                while (dr.Read())
                {
                    login.Text = dr["login"].ToString();
                    data_od.Text = dr["data_od"].ToString();

                    imie.Text = dr["imie"].ToString();
                    nazwisko.Text = dr["nazwisko"].ToString();
                    telefon.Text = dr["telefon"].ToString();
                    email.Text = dr["email"].ToString();

                    kraj.Text = dr["kraj"].ToString();
                    miasto.Text = dr["miasto"].ToString();
                    kod.Text = dr["kod"].ToString();
                    ulica.Text = dr["ulica"].ToString();
                    budynek.Text = dr["budynek"].ToString();
                    mieszkanie.Text = dr["mieszkanie"].ToString();
                }
            }
            catch (Exception)
            {
                System.Web.HttpContext.Current.Response.Write("<SCRIPT LANGUAGE=\"\"JavaScript\"\">alert(\"Błąd wczytywania danych z serwera SQL\")</SCRIPT>");
            }

            dr.Close();
            endConnection();
        }



        protected void ChangeUserInfo()
        {
            SqlConnect("mssql.wmi.amu.edu.pl", "dtas_s383964", "s383964", "674lCgcV");

            SqlCommand cmd = null;
            
            try
            {
                cmd = new SqlCommand(
                "EXEC EDYTUJ_DANE " +
                "\'" + telefon.Text + "\'," +
                "\'" + email.Text + "\'," +
                "\'" + kraj.Text + "\'," +
                "\'" + miasto.Text + "\'," +
                "\'" + kod.Text + "\'," +
                "\'" + ulica.Text + "\'," +
                "\'" + budynek.Text + "\'," +
                "\'" + mieszkanie.Text + "\'," +
                "\'" + imie.Text + "\'," +
                "\'" + nazwisko.Text + "\'," +
                "\'" + login.Text + "\'", conn);
                cmd.ExecuteReader();
            }
            catch (SqlException elol)
            {
                ErrorMsg.Text = cmd.CommandText;
                ErrorMsg.Visible = true;
            }
            finally
            {
            }


            endConnection();
        }



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadUserInfo();
            }

            Page.MaintainScrollPositionOnPostBack = true;
        }



        protected void edit1_Click(object sender, EventArgs e)
        {
            edit1.Visible = false;
            edit1_ok.Visible = true;
            edit1_cancel.Visible = true;

            imie.BorderStyle = System.Web.UI.WebControls.BorderStyle.Solid;
            imie.ReadOnly = false;

            nazwisko.BorderStyle = System.Web.UI.WebControls.BorderStyle.Solid;
            nazwisko.ReadOnly = false;

            telefon.BorderStyle = System.Web.UI.WebControls.BorderStyle.Solid;
            telefon.ReadOnly = false;

            email.BorderStyle = System.Web.UI.WebControls.BorderStyle.Solid;
            email.ReadOnly = false;
        }


        protected void edit1_ok_Click(object sender, EventArgs e)
        {
            ChangeUserInfo();
            LoadUserInfo();


            edit1.Visible = true;
            edit1_ok.Visible = false;
            edit1_cancel.Visible = false;

            imie.BorderStyle = System.Web.UI.WebControls.BorderStyle.None;
            imie.ReadOnly = true;

            nazwisko.BorderStyle = System.Web.UI.WebControls.BorderStyle.None;
            nazwisko.ReadOnly =true;

            telefon.BorderStyle = System.Web.UI.WebControls.BorderStyle.None;
            telefon.ReadOnly = true;

            email.BorderStyle = System.Web.UI.WebControls.BorderStyle.None;
            email.ReadOnly = true;
        }


        protected void edit1_cancel_Click(object sender, EventArgs e)
        {
            edit1.Visible = true;
            edit1_ok.Visible = false;
            edit1_cancel.Visible = false;

            imie.BorderStyle = System.Web.UI.WebControls.BorderStyle.None;
            imie.ReadOnly = true;

            nazwisko.BorderStyle = System.Web.UI.WebControls.BorderStyle.None;
            nazwisko.ReadOnly = true;

            telefon.BorderStyle = System.Web.UI.WebControls.BorderStyle.None;
            telefon.ReadOnly = true;

            email.BorderStyle = System.Web.UI.WebControls.BorderStyle.None;
            email.ReadOnly = true;
        }

        protected void edit2_Click(object sender, EventArgs e)
        {
            edit2.Visible = false;
            edit2_ok.Visible = true;
            edit2_cancel.Visible = true;

            kraj.BorderStyle = System.Web.UI.WebControls.BorderStyle.Solid;
            kraj.ReadOnly = false;

            miasto.BorderStyle = System.Web.UI.WebControls.BorderStyle.Solid;
            miasto.ReadOnly = false;

            kod.BorderStyle = System.Web.UI.WebControls.BorderStyle.Solid;
            kod.ReadOnly = false;

            ulica.BorderStyle = System.Web.UI.WebControls.BorderStyle.Solid;
            ulica.ReadOnly = false;

            budynek.BorderStyle = System.Web.UI.WebControls.BorderStyle.Solid;
            budynek.ReadOnly = false;

            mieszkanie.BorderStyle = System.Web.UI.WebControls.BorderStyle.Solid;
            mieszkanie.ReadOnly = false;
        }


        protected void edit2_ok_Click(object sender, EventArgs e)
        {
            ChangeUserInfo();
            LoadUserInfo();


            edit2.Visible = true;
            edit2_ok.Visible = false;
            edit2_cancel.Visible = false;

            kraj.BorderStyle = System.Web.UI.WebControls.BorderStyle.None;
            kraj.ReadOnly = true;

            miasto.BorderStyle = System.Web.UI.WebControls.BorderStyle.None;
            miasto.ReadOnly = true;

            kod.BorderStyle = System.Web.UI.WebControls.BorderStyle.None;
            kod.ReadOnly = true;

            ulica.BorderStyle = System.Web.UI.WebControls.BorderStyle.None;
            ulica.ReadOnly = true;

            budynek.BorderStyle = System.Web.UI.WebControls.BorderStyle.None;
            budynek.ReadOnly = true;

            mieszkanie.BorderStyle = System.Web.UI.WebControls.BorderStyle.None;
            mieszkanie.ReadOnly = true;
        }


        protected void edit2_cancel_Click(object sender, EventArgs e)
        {
            edit2.Visible = true;
            edit2_ok.Visible = false;
            edit2_cancel.Visible = false;

            kraj.BorderStyle = System.Web.UI.WebControls.BorderStyle.None;
            kraj.ReadOnly = true;

            miasto.BorderStyle = System.Web.UI.WebControls.BorderStyle.None;
            miasto.ReadOnly = true;

            kod.BorderStyle = System.Web.UI.WebControls.BorderStyle.None;
            kod.ReadOnly = true;

            ulica.BorderStyle = System.Web.UI.WebControls.BorderStyle.None;
            ulica.ReadOnly = true;

            budynek.BorderStyle = System.Web.UI.WebControls.BorderStyle.None;
            budynek.ReadOnly = true;

            mieszkanie.BorderStyle = System.Web.UI.WebControls.BorderStyle.None;
            mieszkanie.ReadOnly = true;
        }


    }
}