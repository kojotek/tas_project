using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Web;
using System.Linq;
using BiedaClient.Models;
using System.Data.SqlClient;
using System.Web.UI.WebControls;



namespace BiedaClient.Account
{
    public partial class Manage : System.Web.UI.Page
    {
        BiedaServiceClient client = new BiedaServiceClient();

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////PageLoad////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadUserInfo();
            }

            Page.MaintainScrollPositionOnPostBack = true;

            List<string> msg = new List<string>(client.getMessages(Context.User.Identity.GetUserName()));

            bool switcher = true;
            List<KeyValuePair<string, string>> pary = new List<KeyValuePair<string, string>>();
            string helper = "";

            foreach( string s in msg )
            {
                if(switcher)
                {
                    helper = s;
                }
                else
                {
                    pary.Add(new KeyValuePair<string, string>(helper, s));
                }
                switcher = !switcher;
            }

            bool sw = true;

            foreach( KeyValuePair<string, string> p in pary )
            {
                TableCell c = new TableCell();
                c.Text = p.Key;
                TableCell c2 = new TableCell();
                c2.Text = p.Value;
                TableRow r = new TableRow();
                r.Controls.Add(c);
                r.Controls.Add(c2);
                if (sw) { r.BackColor = System.Drawing.Color.FromName("#FFBC79"); }
                else { r.BackColor = System.Drawing.Color.FromName("#FF9D3C"); }
                sw = !sw;
                Table2.Controls.Add(r);
            }


        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////LoadUserInfo////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void LoadUserInfo()
        {
            List<string> lista = new List<string>(client.LoadAccInfo(Context.User.Identity.GetUserName()));
      
            if(lista[0] == "git")
            {
                login.Text = lista[1];
                data_od.Text = lista[2];
                imie.Text = lista[3];
                nazwisko.Text = lista[4];
                telefon.Text = lista[5];
                email.Text = lista[6];
                kraj.Text = lista[7];
                miasto.Text = lista[8];
                kod.Text = lista[9];
                ulica.Text = lista[10];
                budynek.Text = lista[11];
                mieszkanie.Text = lista[12];         
            }
            else
            {
                ErrorMsg.Text = lista[0];
                ErrorMsg.Visible = true;
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////ChangePass//////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void changePass_Click(object sender, EventArgs e)
        {
            change_pass.Visible = false;
            upgrade.Visible = false;
            delete_acc.Visible = false;
            changePassword.Visible = true;
            ustawieniaKontaMsg.Visible = false;
        }

        protected void changePass_cancel_Click(object sender, EventArgs e)
        {
            change_pass.Visible = true;
            upgrade.Visible = true;
            delete_acc.Visible = true;
            changePassword.Visible = false;
        }

        protected void changePass_ok_Click(object sender, EventArgs e)
        {
            if (IsValid && (newPassT_Box.Text == confirmPassT_Box.Text))
            {
                UserManager manager = new UserManager();
                IdentityResult result = manager.ChangePassword(Context.User.Identity.GetUserId(), oldPassT_Box.Text, newPassT_Box.Text);

                if (result.Succeeded)
                {
                    string wynik = client.ChangePass(Context.User.Identity.GetUserName(), newPassT_Box.Text);

                    if (wynik == "git")
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
                    else 
                    { 
                        manager.ChangePassword(Context.User.Identity.GetUserId(), newPassT_Box.Text, oldPassT_Box.Text);

                        ustawieniaKontaMsg.Text = wynik;
                        ustawieniaKontaMsg.Visible = true;
                        ustawieniaKontaMsg.ForeColor = System.Drawing.Color.Red;
                    }
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

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////UpgradeAcc//////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void upgradeAcc_Click(object sender, EventArgs e)
        {
            change_pass.Visible = false;
            upgrade.Visible = false;
            delete_acc.Visible = false;
            upgradeAccPanel.Visible = true;
            ustawieniaKontaMsg.Visible = false;
        }

        protected void upgradeAcc_cancel_Click(object sender, EventArgs e)
        {
            change_pass.Visible = true;
            upgrade.Visible = true;
            delete_acc.Visible = true;
            upgradeAccPanel.Visible = false;
        }

        protected void upgradeAcc_ok_Click(object sender, EventArgs e)
        {
            if(geszeft.Checked)
            {
                string wynik = client.UpgradeAcc(Context.User.Identity.GetUserName(), numerKontaT_Box.Text);

                if(wynik == "git")
                {
                    ustawieniaKontaMsg.Text = "Twoje konto zostalo ulepszone!";
                    ustawieniaKontaMsg.Visible = true;
                    ustawieniaKontaMsg.ForeColor = System.Drawing.Color.Green;

                    change_pass.Visible = true;
                    upgrade.Visible = true;
                    delete_acc.Visible = true;
                    upgradeAccPanel.Visible = false;
                }
                else
                {
                    ustawieniaKontaMsg.Text = wynik;
                    ustawieniaKontaMsg.Visible = true;
                    ustawieniaKontaMsg.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                ustawieniaKontaMsg.Text = "Nie zgodziles sie na warunki umowy!";
                ustawieniaKontaMsg.Visible = true;
                ustawieniaKontaMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////DeleteAcc///////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void deleteAcc_Click(object sender, EventArgs e)
        {
            change_pass.Visible = false;
            upgrade.Visible = false;
            delete_acc.Visible = false;
            deleteAccPanel.Visible = true;
        }

        protected void deleteAcc_cancel_Click(object sender, EventArgs e)
        {
            change_pass.Visible = true;
            upgrade.Visible = true;
            delete_acc.Visible = true;
            deleteAccPanel.Visible = false;
        }

        protected void deleteAcc_ok_Click(object sender, EventArgs e)
        {
            string wynik = client.LoginIn(Context.User.Identity.GetUserName(), deleteAccT_Box.Text);

            if(wynik == "git")
            {
                change_pass.Visible = true;
                upgrade.Visible = true;
                delete_acc.Visible = true;
                deleteAccPanel.Visible = false;

                wynik = client.DeleteAcc(Context.User.Identity.GetUserName());

                if(wynik == "git")
                {
                    Context.GetOwinContext().Authentication.SignOut();
                    Response.Redirect("~/Default.aspx");
                }
                else
                {
                    ustawieniaKontaMsg.Text = wynik;
                    ustawieniaKontaMsg.Visible = true;
                    ustawieniaKontaMsg.ForeColor = System.Drawing.Color.Red;
                }
            }
            else if(wynik == "Błędny login lub hasło")
            {
                ustawieniaKontaMsg.Text = "Błędne hasło";
                ustawieniaKontaMsg.Visible = true;
                ustawieniaKontaMsg.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                ustawieniaKontaMsg.Text = wynik;
                ustawieniaKontaMsg.Visible = true;
                ustawieniaKontaMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////EditUserInfo////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void ChangeUserInfo()
        {
            string wynik = client.ChangeUserInfo(login.Text, imie.Text, nazwisko.Text, email.Text, 
            telefon.Text, kraj.Text, miasto.Text, kod.Text, ulica.Text, budynek.Text, mieszkanie.Text);

            if(wynik != "git")
            {
                ErrorMsg.Text = wynik;
                ErrorMsg.Visible = true;
            }
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

