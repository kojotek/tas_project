using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;
using System.Web.UI;
using System.Security.Principal;
namespace ProjektBieda
{
    public partial class buyer : Page
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
        
        

        public void loadUserData(String login)
        {

            SqlCommand cmd = new SqlCommand("select * from KLIENT where login = '" + login + "'", conn);
            SqlDataReader dr = cmd.ExecuteReader();

            try
            {
                while (dr.Read())
                {
                    LabelUserName.Text = "Profil użytkownika " + dr["login"].ToString();
                }
            }
            catch (Exception)
            {
                System.Web.HttpContext.Current.Response.Write("<SCRIPT LANGUAGE=\"\"JavaScript\"\">alert(\"Błąd wczytywania danych z serwera SQL\")</SCRIPT>");
            }

            dr.Close();

        }



        protected void loadMessages(String login)
        {

            SqlCommand cmd2 = new SqlCommand("select tresc from POWIADOMIENIE where login = '" + login + "'", conn);
            SqlDataReader dr = cmd2.ExecuteReader();

            try
            {
                while (dr.Read())
                {
                    TableCell c = new TableCell();
                    c.Text = dr["tresc"].ToString();
                    TableRow r = new TableRow();
                    r.Controls.Add(c);
                    Table1.Controls.Add(r);
                }
            }
            catch (Exception)
            {
                System.Web.HttpContext.Current.Response.Write("<SCRIPT LANGUAGE=\"\"JavaScript\"\">alert(\"Błąd wczytywania danych z serwera SQL 2\")</SCRIPT>");
            }

            dr.Close();

        }



        protected void endConnection()
        {
            conn.Close();
        }



        protected void Page_Load(object sender, EventArgs e)
        {
            Table1.BorderColor = System.Drawing.Color.Gray;
            Table1.BorderStyle = BorderStyle.Solid;
            Table1.BorderWidth = 1;
            Table1.CellPadding = 3;
            Table1.CellSpacing = 10;
            Table1.GridLines = GridLines.Horizontal;
            Table1.HorizontalAlign = HorizontalAlign.Left;

            SqlConnect("mssql.wmi.amu.edu.pl", "dtas_s383964", "s383964", "674lCgcV");
            loadUserData("damianek");
            loadMessages("damianek");
            endConnection();
        }

    }
}