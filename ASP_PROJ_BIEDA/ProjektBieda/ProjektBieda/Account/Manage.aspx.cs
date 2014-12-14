using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Web;
using System.Linq;
using ProjektBieda.Models;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;

namespace ProjektBieda.Account
{
    public partial class Manage : System.Web.UI.Page
    {
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

        protected void changePass_Click(object sender, EventArgs e)
        {
            change_pass.Visible = false;
            upgrade.Visible = false;
            delete_acc.Visible = false;
            changePassword.Visible = true;
            ustawieniaKontaMsg.Visible = false;
        }

        protected void changePass_ok_Click(object sender, EventArgs e)
        {
            if (IsValid && (newPassT_Box.Text == confirmPassT_Box.Text))
            {
                UserManager manager = new UserManager();
                IdentityResult result = manager.ChangePassword(Context.User.Identity.GetUserId(), oldPassT_Box.Text, newPassT_Box.Text);

                if (result.Succeeded)
                {
                    if (SQL_changePass())
                    {
                        ustawieniaKontaMsg.Text = "Pomyslna zmiana hasla";
                        ustawieniaKontaMsg.Visible = true;
                        ustawieniaKontaMsg.ForeColor = System.Drawing.Color.Green;

                        Context.GetOwinContext().Authentication.SignOut();
                        Response.Redirect("Login.aspx");

                        change_pass.Visible = true;
                        upgrade.Visible = true;
                        delete_acc.Visible = true;
                        changePassword.Visible = false;
                    }
                    else manager.ChangePassword(Context.User.Identity.GetUserId(), newPassT_Box.Text, oldPassT_Box.Text);
                }
                else
                {
                    ustawieniaKontaMsg.Text = "Nieprawidlowe akutalne haslo";
                    ustawieniaKontaMsg.Visible = true;
                    ustawieniaKontaMsg.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                ustawieniaKontaMsg.Text = "Haslo oraz zawartosc pola powtorz haslo nie są takie same";
                ustawieniaKontaMsg.Visible = true;
                ustawieniaKontaMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void changePass_cancel_Click(object sender, EventArgs e)
        {
            change_pass.Visible = true;
            upgrade.Visible = true;
            delete_acc.Visible = true;
            changePassword.Visible = false;
        }

        protected bool SQL_changePass()
        {
            SqlConnect("mssql.wmi.amu.edu.pl", "dtas_s383964", "s383964", "674lCgcV");

            SqlCommand cmd = null;

            try
            {
                cmd = new SqlCommand(
                "EXEC ZMIEN_HASLO " +
                "\'" + Context.User.Identity.GetUserName() + "\'," +
                "\'" + newPassT_Box.Text + "\'" , conn);
                
                cmd.ExecuteReader();
            }
            catch (Exception)
            {
                ustawieniaKontaMsg.Text = "Blad polaczenia z baza danych";
                ustawieniaKontaMsg.Visible = true;
                ustawieniaKontaMsg.ForeColor = System.Drawing.Color.Red;
                return false;
            }

            endConnection();

            return true;
        }

        protected void upgradeAcc_Click(object sender, EventArgs e)
        {
            change_pass.Visible = false;
            upgrade.Visible = false;
            delete_acc.Visible = false;
            upgradeAccPanel.Visible = true;
            ustawieniaKontaMsg.Visible = false;
        }

        protected void upgradeAcc_ok_Click(object sender, EventArgs e)
        {
            if(geszeft.Checked)
            {
                if(SQL_upgradeAcc())
                {
                    ustawieniaKontaMsg.Text = "Twoje konto zostalo ulepszone!";
                    ustawieniaKontaMsg.Visible = true;
                    ustawieniaKontaMsg.ForeColor = System.Drawing.Color.Green;

                    change_pass.Visible = true;
                    upgrade.Visible = true;
                    delete_acc.Visible = true;
                    upgradeAccPanel.Visible = false;
                }
            }
            else
            {
                ustawieniaKontaMsg.Text = "Nie zgodziles sie na warunki umowy!";
                ustawieniaKontaMsg.Visible = true;
                ustawieniaKontaMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void upgradeAcc_cancel_Click(object sender, EventArgs e)
        {
            change_pass.Visible = true;
            upgrade.Visible = true;
            delete_acc.Visible = true;
            upgradeAccPanel.Visible = false;
        }

        protected bool SQL_upgradeAcc()
        {
            SqlConnect("mssql.wmi.amu.edu.pl", "dtas_s383964", "s383964", "674lCgcV");

            SqlCommand cmd = null;

            try
            {
                cmd = new SqlCommand(
                "EXEC DODAJ_SPRZEDAWCE " +
                "\'" + Context.User.Identity.GetUserName() + "\'," +
                "\'" + numerKontaT_Box.Text + "\'", conn);

                cmd.ExecuteReader();
            }
            catch (Exception)
            {
                ustawieniaKontaMsg.Text = "Blad polaczenia z baza danych lub niewlasciwy numer konta";
                ustawieniaKontaMsg.Visible = true;
                ustawieniaKontaMsg.ForeColor = System.Drawing.Color.Red;
                return false;
            }

            endConnection();

            return true;
        }

        protected void deleteAcc_Click(object sender, EventArgs e)
        {
            change_pass.Visible = false;
            upgrade.Visible = false;
            delete_acc.Visible = false;
            deleteAccPanel.Visible = true;
        }

        protected void deleteAcc_ok_Click(object sender, EventArgs e)
        {

            if(SQL_checkPass())
            {
                change_pass.Visible = true;
                upgrade.Visible = true;
                delete_acc.Visible = true;
                deleteAccPanel.Visible = false;

                SQL_DeleteAcc();

                Context.GetOwinContext().Authentication.SignOut();
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                ustawieniaKontaMsg.Text = "Bledne haslo";
                ustawieniaKontaMsg.Visible = true;
                ustawieniaKontaMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void deleteAcc_cancel_Click(object sender, EventArgs e)
        {
            change_pass.Visible = true;
            upgrade.Visible = true;
            delete_acc.Visible = true;
            deleteAccPanel.Visible = false;
        }

        protected bool SQL_checkPass()
        {
            SqlConnect("mssql.wmi.amu.edu.pl", "dtas_s383964", "s383964", "674lCgcV");

            SqlCommand cmd = null;
            bool cacy = false;

            try
            {
                cmd = new SqlCommand
                    ("select login from KLIENT where login = \'" + Context.User.Identity.GetUserName()
                    + "\' and haslo = \'" + deleteAccT_Box.Text + "\' and data_do is null", conn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    if (dr["login"].ToString() == Context.User.Identity.GetUserName()) { cacy = true; }
                    else { cacy = false; }
                }
            }
            catch (Exception)
            {
                ustawieniaKontaMsg.Text = "Blad polaczenia z baza danych";
                ustawieniaKontaMsg.Visible = true;
                ustawieniaKontaMsg.ForeColor = System.Drawing.Color.Red;
            }

            endConnection();

            return cacy;
        }

        protected bool SQL_DeleteAcc()
        {
            SqlConnect("mssql.wmi.amu.edu.pl", "dtas_s383964", "s383964", "674lCgcV");

            SqlCommand cmd = null;

            try
            {
                cmd = new SqlCommand(
                "EXEC USUN_KONTO " +
                "\'" + Context.User.Identity.GetUserName() + "\'", conn);

                cmd.ExecuteReader();
            }
            catch (Exception)
            {
                ustawieniaKontaMsg.Text = "Blad polaczenia z baza danych";
                ustawieniaKontaMsg.Visible = true;
                ustawieniaKontaMsg.ForeColor = System.Drawing.Color.Red;
                return false;
            }

            endConnection();

            return true;
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
            LoadUserInfo();

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


    }
}

