using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using BiedaClient.Models;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;
namespace BiedaClient.Account
{
    public partial class Register : Page
    {

        BiedaServiceClient client = new BiedaServiceClient();

        protected void next1_Click(object sender, EventArgs e)
        {
            if (login.Text != "" && haslo.Text != "" && powtorz_haslo.Text != "")
            {
                next1.Visible = false;
                Panel1ErrorMsg.Visible = false;
                Panel2_1.Visible = true;
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
                next2.Visible = false;
                Panel2ErrorMsg.Visible = false;
                Panel3_1.Visible = true;

                //Panel3ErrorMsg.Focus();
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
                next3.Visible = false;
                Panel3ErrorMsg.Visible = false;
                Panel4_1.Visible = true;
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
                string result = client.RegisterUser(login.Text, haslo.Text, imie.Text, nazwisko.Text,
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
        }
    }
}