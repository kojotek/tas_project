using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace MyWCFServices
{
    public class BiedaService: IBiedaService, helpfullThings
    {

        
//POLA/////////////////////////////////////////////////////////////////////////////
        SqlConnection conn = null;
//POLA/////////////////////////////////////////////////////////////////////////////
        
//CONNECT - TWORZENIE POŁĄCZENIA Z BAZĄ DANYCH/////////////////////////////////////////////////////////////
        public bool connect(string serverName, string database, string userId, string password)
        {

            try
            {
                conn = new SqlConnection("Server=" + serverName + ";Database=" + database + ";User Id=" + userId + ";Password=" + password + ";"); conn.Open();
            }
            catch (InvalidOperationException ex)
            {
                return false;
            }
            catch (SqlException ex)
            {
                return false;
            }

            return true;
        }
//CONNECT - TWORZENIE POŁĄCZENIA Z BAZĄ DANYCH/////////////////////////////////////////////////////////////





//DISCONNECT - ZRYWA POŁĄCZENIA Z BAZĄ DANYCH/////////////////////////////////////////////////////////////
        public void disconnect()
        {
            conn.Close();
        }
//DISCONNECT - ZRYWA POŁĄCZENIA Z BAZĄ DANYCH/////////////////////////////////////////////////////////////
        
        
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

            SqlCommand cmd = null;
            SqlDataReader dr = null;

            if ( connect( serverName, database,userId, password ) == false )
            {
                return "Błąd";
            }

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

            finally { disconnect(); }

            return wynik;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////RegisterUser////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public string RegisterUser(string login, string haslo, string imie, string nazwisko, 
        string email, string telefon, string kraj, string miasto, string kod, string ulica, string dom, string mieszkanie)
        {
            if (connect("mssql.wmi.amu.edu.pl", "dtas_s383964", "s383964", "674lCgcV") == false)
            {
                return "Blad polaczenia z baza danych";
            }

            SqlCommand cmd = null;
            string result = "git";

            try
            {
                cmd = new SqlCommand(
                "EXEC DODAJ_KLIENTA " +
                "\'" + telefon + "\'," +
                "\'" + email + "\'," +
                "\'" + kraj + "\'," +
                "\'" + miasto + "\'," +
                "\'" + kod + "\'," +
                "\'" + ulica + "\'," +
                "\'" + dom + "\'," +
                "\'" + mieszkanie + "\'," +
                "\'" + imie + "\'," +
                "\'" + nazwisko + "\'," +
                "\'" + login + "\'," +
                "\'" + haslo + "\'", conn);
                cmd.ExecuteReader();
            }
            catch (SqlException blad)
            {
                result = "Blad podczas wykonywania polecenia w bazie: " + blad.Errors.ToString();      
            }

            return result;
        }





    }
}
