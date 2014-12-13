using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace MyWCFServices
{
    public class BiedaService: IBiedaService
    {

        public String GetMessage(String name)
        {
            return "Kojotki witaja, " + name + "! Czuj sie jak u siebie!";
        }


        public string GetMessage2( string user, string pass )
        {
            string serverName = "mssql.wmi.amu.edu.pl";
            string database = "dtas_s383964";
            string userId = "s383964";
            string password = "674lCgcV";


            SqlConnection conn = null; 
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            //List<string> toReturn = new List<string>();
            //toReturn.Add("lol");
            //return toReturn;

            try
            {
                conn = new SqlConnection("Server=" + serverName + ";Database=" + database + ";User Id=" + userId + ";Password=" + password + ";"); conn.Open();
            }
            catch (InvalidOperationException ex)
            {
              //  toReturn.Add("pierwszy fail");
                return "InvalidOperationException";
            }
            catch (SqlException ex)
            {
                //toReturn.Add("drugi fail");
                return "sqlException";
            }

            //return ("tu je dobrze");
            //finally
            //{


            string wynik = null;
            
            try
            {
                cmd = new SqlCommand("select * from KLIENT where login = \'" + user + "\' and haslo = \'" + pass + "\'", conn);
                dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    wynik = dr.HasRows.ToString();

                    if (dr.HasRows == true)
                        while (dr.Read())
                        {
                            for (int i = 0; i < dr.FieldCount; i++)
                            {
                                wynik = dr[0].ToString();
                            }

                        }

                }
                wynik = "lel, dziala " + wynik;


            }

            catch (SqlException elol)
            {
                return "sqlException2";
            }

            finally { conn.Close(); }

            return wynik;
        }







    }
}
