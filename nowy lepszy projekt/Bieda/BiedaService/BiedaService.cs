using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Text.RegularExpressions;


namespace MyWCFServices
{
    public class BiedaService: IBiedaService, helpfullThings
    {
        
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////Konstruktor//////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////// 

        public BiedaService()
        {
            //uzupelnienie slownika dla funkcji CheckRegex
            dic.Add("telefon", new RegexData("^([0-9]{9})$", "musi zawierac 9 cyfr", 9));
            dic.Add("email", new RegexData("^(\\w+@\\w+\\.\\w+)$", "nieprawidlowy email", 50));
            dic.Add("nr_konta", new RegexData("^([0-9]{26})$", "musi zawierac 26 cyfr", 26));
            dic.Add("kraj", new RegexData("^([A-Z][a-z]+(([A-z]+)|\\s)*)$", "musi skladac sie z liter oraz zaczynac od wielkiej litery", 50));
            dic.Add("miasto", new RegexData("^([A-Z][a-z]+(([A-z]+)|\\s)*)$", "musi skladac sie z liter oraz zaczynac od wielkiej litery", 50));
            dic.Add("ulica", new RegexData("", "", 50));
            dic.Add("budynek", new RegexData("", "", 10));
            dic.Add("mieszkanie", new RegexData("", "", 10));
            dic.Add("imie", new RegexData("", "", 50));
            dic.Add("nazwisko", new RegexData("", "", 50));
            dic.Add("login", new RegexData("", "", 20));
            dic.Add("haslo", new RegexData("", "", 20));
            dic.Add("kod", new RegexData("", "", 6));
            dic.Add("kod", new RegexData("", "", 6));
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////connect & disconnect/////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////        

        SqlConnection conn = null;

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

        public void disconnect()
        {
            conn.Close();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////getAuctionInfo//////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////

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

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////isAuctionOver///////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////

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

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////GetMessage//////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////

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

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////RegisterUser////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        struct RegexData
        {
            public RegexData(string a, string b, int c)
            {
                reg = a;
                info = b;
                maxLength = c;
            }

            public string reg;
            public string info;
            public int maxLength;
        };

        Dictionary<string, RegexData> dic = new Dictionary<string, RegexData>();

        public string CheckRegex(string klucz, string wartosc)
        {
            RegexData data = new RegexData();

            try 
            { 
                data = dic[klucz]; 
            }
            catch { return "bledny klucz"; }

            if (data.maxLength < wartosc.Length) { return "wprowadzana wartosc jest za dluga"; }

            try 
            { 
                if(!Regex.IsMatch(wartosc, data.reg))
                {
                    return data.info;
                }
            }
            catch { return "bledna regula"; }

            return "git";
        }
    }
}
