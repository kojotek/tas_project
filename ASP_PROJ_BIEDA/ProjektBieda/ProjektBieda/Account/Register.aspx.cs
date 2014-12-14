using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using ProjektBieda.Models;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;
namespace ProjektBieda.Account
{
    public partial class Register : Page
    {
        public bool SqlConnect(string serverName, string database, string userId, string password)
        {
            SqlConnection conn = null; SqlCommand cmd = null;
            bool cacy = true;
            try { conn = new SqlConnection("Server=" + serverName + ";Database=" + database + ";User Id=" + userId + ";Password=" + password + ";"); conn.Open(); }
            catch (InvalidOperationException ex) { System.Web.HttpContext.Current.Response.Write("<SCRIPT LANGUAGE=\"\"JavaScript\"\">alert(\"Błąd klienta.\")</SCRIPT>"); }
            catch (SqlException ex) { System.Web.HttpContext.Current.Response.Write("<SCRIPT LANGUAGE=\"\"JavaScript\"\">alert(\"Błąd połączenia z serwerem SQL.\")</SCRIPT>"); }  
            finally
            {
                try
                {
                    cmd = new SqlCommand(
                    "EXEC DODAJ_KLIENTA " +
                    "\'" + telefon.Text + "\'," +
                    "\'" + email.Text + "\'," +
                    "\'" + kraj.Text + "\'," +
                    "\'" + miasto.Text + "\'," +
                    "\'" + kod.Text + "\'," +
                    "\'" + ulica.Text + "\'," +
                    "\'" + dom.Text + "\'," +
                    "\'" + mieszkanie.Text + "\'," +
                    "\'" + imie.Text + "\'," +
                    "\'" + nazwisko.Text + "\'," +
                    "\'" + login.Text + "\'," +
                    "\'" + haslo.Text + "\'", conn);
                    cmd.ExecuteReader();
                }
                catch (SqlException elol)
                {
                    Panel4ErrorMsg.Text = "Blad polaczenia z baza danych";
                    Panel4ErrorMsg.Visible = true;
                    Panel4ErrorMsg.ForeColor = System.Drawing.Color.Red;

                    cacy = false;
                }
                finally
                {
                    conn.Close();
                }
            }
            return cacy;

        }

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
                if(SqlConnect("mssql.wmi.amu.edu.pl", "dtas_s383964", "s383964", "674lCgcV"))
                {
                    Response.Redirect("Login.aspx");
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