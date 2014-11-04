using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;

namespace ProjektBieda
{
    public partial class About : Page
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
                    cmd = new SqlCommand("select * from dane", conn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Label1.Text = dr[1].ToString();
                        Label2.Text = dr[2].ToString();
                        Label3.Text = dr[3].ToString();
                        Label4.Text = dr[4].ToString();
                    }
                } 
                catch (Exception) 
                {
                    System.Web.HttpContext.Current.Response.Write("<SCRIPT LANGUAGE=\"\"JavaScript\"\">alert(\"dupa2!\")</SCRIPT>");
                } 
                finally 
                {
                    System.Web.HttpContext.Current.Response.Write("<SCRIPT LANGUAGE=\"\"JavaScript\"\">alert(\"hahaha!\")</SCRIPT>");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            SqlConnect("mssql.wmi.amu.edu.pl", "dtas_s383964", "s383964", "674lCgcV");

        }
    }
}