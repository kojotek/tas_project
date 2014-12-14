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
        public bool connect()
        {
            string serverName = "mssql.wmi.amu.edu.pl";
            string database = "dtas_s383964";
            string userId = "s383964";
            string password = "674lCgcV";

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
        
        




//getAuctionInfo/////////////////////////////////////////////////////////////////////////////////////////
        public List<string> getAuctionInfo(int id)
        {
            connect();
            List<string> lista = new List<string>();

            try
            {
                SqlCommand cmd = new SqlCommand("select * from AUKCJA where id_aukcji = " + id.ToString(), conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add( dr["id_aukcji"].ToString() );
                    lista.Add( dr["login"].ToString() );
                    lista.Add( dr["nazwa_produktu"].ToString() );
                    lista.Add( String.Format("{0:F2}", float.Parse(dr["cena_startowa"].ToString())) + " zł" );
                    lista.Add( String.Format("{0:F2}", float.Parse(dr["cena_wysylki"].ToString())) + " zł" );
                    lista.Add( dr["data_zakonczenia"].ToString() );
                    lista.Add(dr["opis"].ToString());
                }
            }
            finally
            {
                disconnect();
            }

            return lista;

        }
//getAuctionInfo/////////////////////////////////////////////////////////////////////////////////////////







//isAuctionOver/////////////////////////////////////////////////////////////////////////////////////////
        public bool isAuctionOver(int id)
        {
            connect();

            bool wynik = true;
            string temp = "dupa";

            try
            {
                SqlCommand cmd = new SqlCommand("SELECT CASE WHEN EXISTS (SELECT * FROM aukcja WHERE id_aukcji = " + id.ToString() + " AND getDate()<data_zakonczenia) THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) END", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    temp = dr[0].ToString();
                }
            }
            finally
            {
                disconnect();
            }
            
            if ( String.Compare(temp, "True") == 0 )
                wynik = false;
            else
                wynik = true;

            return wynik;
        }
//isAuctionOver/////////////////////////////////////////////////////////////////////////////////////////









        public String GetMessage(String name)
        {
            return "Kojotki witaja, " + name + "! Czuj sie jak u siebie!";
        }



        public string GetMessage2( string user, string pass )
        {

            SqlCommand cmd = null;
            SqlDataReader dr = null;

            if ( connect() == false )
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
            if (connect() == false)
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
