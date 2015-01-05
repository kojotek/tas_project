using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using BiedaClient.Models;
using System.Web.UI.WebControls;

namespace BiedaClient.Account
{
    public partial class Register : Page
    {
        BiedaServiceClient client = new BiedaServiceClient();

        protected void back_Click(object sender, EventArgs e)
        {
            if(Panel2_1.Visible == true && Panel3_1.Visible == true && Panel4_1.Visible == true)
            {
                Panel4_1.Visible = false;

                next3.Visible = true;
                back2.Visible = true;

                kraj.ReadOnly = false;
                miasto.ReadOnly = false;
                kod.ReadOnly = false;
                ulica.ReadOnly = false;
                dom.ReadOnly = false;
                mieszkanie.ReadOnly = false;
            }
            else if (Panel2_1.Visible == true && Panel3_1.Visible == true && Panel4_1.Visible == false)
            {
                Panel3_1.Visible = false;

                next2.Visible = true;
                back1.Visible = true;

                imie.ReadOnly = false;
                nazwisko.ReadOnly = false;
                email.ReadOnly = false;
                telefon.ReadOnly = false;
            }
            else if (Panel2_1.Visible == true && Panel3_1.Visible == false && Panel4_1.Visible == false)
            {
                Panel2_1.Visible = false;

                next1.Visible = true;

                login.ReadOnly = false;
                haslo.ReadOnly = false;
                powtorz_haslo.ReadOnly = false;
            }
        }

        protected void next1_Click(object sender, EventArgs e)
        {
            if (login.Text != "" && haslo.Text != "" && powtorz_haslo.Text != "")
            {
                bool git = true;
                string[,] dane = new string[2,3] {{"login", "haslo1", "haslo2"}, {login.Text, haslo.Text, haslo.Text}};

                for(int i = 0; i < dane.Length/2; i++)
                {
                    string result = client.CheckRegex(dane[0, i], dane[1, i]);

                    if( result != "git")
                    {
                        Panel1ErrorMsg.Text = result;
                        git = false;
                    }
                }
                
                if(git == true)
                {
                    if(haslo.Text == powtorz_haslo.Text)
                    {
                        next1.Visible = false;
                        Panel1ErrorMsg.Visible = false;
                        Panel2_1.Visible = true; 
                        
                        //blokowanie edycji poprzednich danych
                        login.ReadOnly = true;
                        haslo.ReadOnly = true;
                        powtorz_haslo.ReadOnly = true;

                    }
                    else
                    {
                        Panel1ErrorMsg.Text = "haslo i powtorzone haslo musza byc takie same!";
                        Panel1ErrorMsg.Visible = true;
                        Panel1ErrorMsg.ForeColor = System.Drawing.Color.Red;
                    }      
                }
                else
                {
                    Panel1ErrorMsg.Visible = true;
                    Panel1ErrorMsg.ForeColor = System.Drawing.Color.Red;
                }     
            }
            else
            {
                Panel1ErrorMsg.Text = "Zadne z pol niemoze pozostac puste!";
                Panel1ErrorMsg.Visible = true;
                Panel1ErrorMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void next2_Click(object sender, EventArgs e)
        {
            if (imie.Text != "" && nazwisko.Text != "" && email.Text != "" && telefon.Text != "")
            {
                bool git = true;
                string[,] dane = new string[2, 4] { { "imie", "nazwisko", "email", "telefon" }, { imie.Text, nazwisko.Text, email.Text, telefon.Text } };

                for (int i = 0; i < dane.Length / 2; i++)
                {
                    string result = client.CheckRegex(dane[0, i], dane[1, i]);

                    if (result != "git")
                    {
                        Panel2ErrorMsg.Text = result;
                        git = false;
                    }
                }

                if(git == true)
                {
                    next2.Visible = false;
                    back1.Visible = false;
                    Panel2ErrorMsg.Visible = false;
                    Panel3_1.Visible = true;

                    //blokowanie edycji poprzednich danych
                    imie.ReadOnly = true;
                    nazwisko.ReadOnly = true;
                    email.ReadOnly = true;
                    telefon.ReadOnly = true;
                }
                else
                {
                    Panel2ErrorMsg.Visible = true;
                    Panel2ErrorMsg.ForeColor = System.Drawing.Color.Red;
                } 
            }
            else
            {
                Panel2ErrorMsg.Text = "Zadne z pol niemoze pozostac puste!";
                Panel2ErrorMsg.Visible = true;
                Panel2ErrorMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void next3_Click(object sender, EventArgs e)
        {
            if (kraj.Text != "" && miasto.Text != "" && kod.Text != "" && ulica.Text != "" && dom.Text != "")
            {
                bool git = true;
                string[,] dane = new string[2, 6] { { "kraj", "miasto", "kod", "ulica", "budynek", "mieszkanie" }, { kraj.Text, miasto.Text, kod.Text, ulica.Text, dom.Text, mieszkanie.Text } };

                for (int i = 0; i < dane.Length / 2; i++)
                {
                    string result = client.CheckRegex(dane[0, i], dane[1, i]);

                    if (result != "git")
                    {
                        Panel3ErrorMsg.Text = result;
                        git = false;
                    }
                }

                if (git == true)
                {
                    next3.Visible = false;
                    back2.Visible = false;
                    Panel3ErrorMsg.Visible = false;
                    Panel4_1.Visible = true;

                    //blokowanie edycji poprzednich danych
                    kraj.ReadOnly = true;
                    miasto.ReadOnly = true;
                    kod.ReadOnly = true;
                    ulica.ReadOnly = true;
                    dom.ReadOnly = true;
                    mieszkanie.ReadOnly = true;
                }
                else
                {
                    Panel3ErrorMsg.Visible = true;
                    Panel3ErrorMsg.ForeColor = System.Drawing.Color.Red;
                } 
            }
            else
            {
                Panel3ErrorMsg.Text = "Zadne z pol niemoze pozostac puste!";
                Panel3ErrorMsg.Visible = true;
                Panel3ErrorMsg.ForeColor = System.Drawing.Color.Red;
            }

        }

        protected void register_Click(object sender, EventArgs e)
        {
            if(reg_check.Checked && bot_check.Checked)
            {
                string result = client.RegisterUser(login.Text, haslo.Attributes["value"], imie.Text, nazwisko.Text,
                email.Text, telefon.Text, kraj.Text, miasto.Text, kod.Text, ulica.Text, dom.Text, mieszkanie.Text);

                if (result == "git")
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    Panel4ErrorMsg.Text = result;
                    Panel4ErrorMsg.Visible = true;
                    Panel4ErrorMsg.ForeColor = System.Drawing.Color.Red;
                }
            }
            else 
            {
                Panel4ErrorMsg.Text = "Musisz zgodzic sie z wszystkimi warunkami koncowymi";
                Panel4ErrorMsg.Visible = true;
                Panel4ErrorMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
                Page.MaintainScrollPositionOnPostBack = true;

                if (IsPostBack)
                {
                    if (!(String.IsNullOrEmpty(haslo.Text.Trim())))
                    {
                        haslo.Attributes["value"] = haslo.Text;
                    }
                    if (!(String.IsNullOrEmpty(powtorz_haslo.Text.Trim())))
                    {
                        powtorz_haslo.Attributes["value"] = powtorz_haslo.Text;
                    }
                }
        }
    }
}