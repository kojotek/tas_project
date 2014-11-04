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

        SqlConnection conn;
        SqlCommand cmd;

        public void SqlConnect(string serverName, string database, string userId, string password)
        {
            conn = null; cmd = null;

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




        public void loadAuction(int id)
        {

            try
            {
                cmd = new SqlCommand("select * from AUKCJA where id_aukcji = " + id.ToString() , conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    LabelLogin.Text = "Aukcja użytkownika " + dr["login"].ToString();
                    LabelName.Text = "(" + dr["id_aukcji"].ToString() + ") " + dr["nazwa_produktu"].ToString();
                    LabelTime.Text = "Oferta ważna do " + dr["data_zakonczenia"].ToString();
                    LabelPrice.Text = String.Format( "{0:F2}", float.Parse ( dr["cena_startowa"].ToString() ) ) + " zł";
                    LabelSendPrice.Text = String.Format("{0:F2}", float.Parse(dr["cena_wysylki"].ToString())) + " zł";
                    TextBoxDescription.Text = dr["opis"].ToString();
                }
            }
            catch (Exception)
            {
                System.Web.HttpContext.Current.Response.Write("<SCRIPT LANGUAGE=\"\"JavaScript\"\">alert(\"Błąd wczytywania danych z serwera SQL\")</SCRIPT>");
            }
            finally
            {
                conn.Close();
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnect("mssql.wmi.amu.edu.pl", "dtas_s383964", "s383964", "674lCgcV");
            loadAuction(2);
        }
    }
}