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
        public void SqlConnect(string serverName, string database, string userId, string password)
        {
            SqlConnection conn = null; SqlCommand cmd = null;

            try { conn = new SqlConnection("Server=" + serverName + ";Database=" + database + ";User Id=" + userId + ";Password=" + password + ";"); conn.Open(); }
            catch (InvalidOperationException ex) { System.Web.HttpContext.Current.Response.Write("<SCRIPT LANGUAGE=\"\"JavaScript\"\">alert(\"Klient\")</SCRIPT>"); }
            catch (SqlException ex) { System.Web.HttpContext.Current.Response.Write("<SCRIPT LANGUAGE=\"\"JavaScript\"\">alert(\"serwer!\")</SCRIPT>"); }
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
                    //System.Web.HttpContext.Current.Response.Write("<SCRIPT LANGUAGE=\"\"JavaScript\"\">alert(\"dupa2!\")</SCRIPT>");
                    ErrorMessage.Text = cmd.CommandText;
                }
                finally
                {
                    System.Web.HttpContext.Current.Response.Write("<SCRIPT LANGUAGE=\"\"JavaScript\"\">alert(\"hahaha!\")</SCRIPT>");
                    conn.Close();
                }
            }
        }

        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            SqlConnect("mssql.wmi.amu.edu.pl", "dtas_s383964", "s383964", "674lCgcV");
        }

    }
}