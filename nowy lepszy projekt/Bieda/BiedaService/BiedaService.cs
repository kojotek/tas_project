﻿using System;
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
            dic.Add("telefon", new RegexData("^([0-9]{9})$", "numer telefonu musi zawierac 9 cyfr", 9));
            dic.Add("email", new RegexData("^(\\w+@\\w+\\.\\w+)$", "nieprawidlowy adres email", 50));
            dic.Add("nr_konta", new RegexData("^([0-9]{26})$", "numer konta musi zawierac 26 cyfr", 26));
            dic.Add("kraj", new RegexData("^([A-Z][a-z]+(([A-z]+)|\\s)*)$", "kraj musi skladac sie z liter oraz zaczynac od wielkiej litery", 50));
            dic.Add("miasto", new RegexData("^([A-Z][a-z]+(([A-z]+)|\\s)*)$", "miasto musi skladac sie z liter oraz zaczynac od wielkiej litery", 50));
            dic.Add("ulica", new RegexData("^(.+)$", "nazwa ulica niemoze byc pusta", 50));
            dic.Add("budynek", new RegexData("^([0-9]+\\w*)$", "numer budynku musi zaczynac sie od cyfry", 10));
            dic.Add("mieszkanie", new RegexData("^([0-9]+\\w*|)$", "numer mieszkania musi zaczynac sie od cyfry (dopuszczalny jest brak numeru mieszkania)", 10));
            dic.Add("imie", new RegexData("^([A-Z][a-z]+)$", "imie musi zaczynac sie z wielkiej litery i skladac sie z liter", 50));
            dic.Add("nazwisko", new RegexData("^([A-Z][a-z]+(\\s[A-z]+)*)$", "nazwisko musi zaczynac sie z wielkiej litery i skladac sie z liter", 50));
            dic.Add("login", new RegexData("^(\\w{3,})$", "login musi miec przynajmniej 3 znaki", 20));
            dic.Add("haslo1", new RegexData("^(\\w{6,})$", "haslo musi miec przynajmniej 6 znakow", 20));
            dic.Add("haslo2", new RegexData("[0-9]", "haslo musi zawierac cyfre", 20));
            dic.Add("kod", new RegexData("^([0-9][0-9]( |-)[0-9][0-9][0-9])$", "kod musi skladac sie z samych cyfr (dopuszczalne formaty XX-XXX oraz XX XXX)", 6));

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
                //result = "Blad podczas wykonywania polecenia w bazie: " + blad.Errors.ToString();
                result = cmd.CommandText;
            }

            disconnect();
            return result;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////LoginIn/////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public string LoginIn(string login, string pass)
        {
            if (connect() == false)
            {
                return "Blad polaczenia z baza danych";
            }

            SqlCommand cmd = null;
            string result = "Błędny login lub hasło";

            try
            {
                cmd = new SqlCommand
                ("select login from KLIENT where login = \'" + login + "\' and haslo = \'" + pass + "\' and data_do is null", conn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    if (dr["login"].ToString() == login) { result = "git"; }
                }
            }
            catch (SqlException blad)
            {
                result = "Blad podczas wykonywania polecenia w bazie: " + blad.Errors.ToString();
            }

            disconnect();
            return result;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////ChangePass//////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public string ChangePass(string login, string newPass)
        {
            if (connect() == false)
            {
                return "Blad polaczenia z baza danych";
            }

            SqlCommand cmd = null;
            string result = "git";

            try
            {
                cmd = new SqlCommand("EXEC ZMIEN_HASLO " + "\'" + login + "\'," + "\'" + newPass + "\'", conn);
                cmd.ExecuteReader();
            }
            catch (SqlException blad)
            {
                result = "Blad podczas wykonywania polecenia w bazie: " + blad.Errors.ToString();
            }

            disconnect();
            return result;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////UpgradeAcc//////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public string UpgradeAcc(string login, string numerKonta)
        {
            string result = CheckRegex("nr_konta", numerKonta);

            if (result != "git")
            {
                return result;
            }

            if (connect() == false)
            {
                return "Blad polaczenia z baza danych";
            }

            SqlCommand cmd = null;
            result = "git";

            try
            {
                cmd = new SqlCommand("EXEC DODAJ_SPRZEDAWCE " + "\'" + login + "\'," + "\'" + numerKonta + "\'", conn);
                cmd.ExecuteReader();
            }
            catch (SqlException blad)
            {
                result = "Blad podczas wykonywania polecenia w bazie: " + blad.Errors.ToString();
                //result = cmd.CommandText;
            }

            disconnect();
            return result;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////DeleteAcc///////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public string DeleteAcc(string login)
        {
            if (connect() == false)
            {
                return "Blad polaczenia z baza danych";
            }

            SqlCommand cmd = null;
            string result = "git";

            try
            {
                cmd = new SqlCommand("EXEC USUN_KONTO " + "\'" + login + "\'", conn);
                cmd.ExecuteReader();
            }
            catch (SqlException blad)
            {
                result = "Blad podczas wykonywania polecenia w bazie: " + blad.Errors.ToString();
            }

            disconnect();
            return result;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////LoadAccInfo/////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public List<string> LoadAccInfo(string login)
        {
            List<string> result = new List<string>();
            result.Add("git");

            if (connect() == false)
            {
                result[0] = "Blad polaczenia z baza danych";
                return result;
            }

            SqlCommand cmd = null;

            try
            {
                cmd = new SqlCommand("select * from KLIENT INNER JOIN DANE on klient.id_dane = dane.id_dane where klient.login = \'" + login + "\'", conn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    result.Add(dr["login"].ToString());
                    result.Add(dr["data_od"].ToString());
                    result.Add(dr["imie"].ToString());
                    result.Add(dr["nazwisko"].ToString());
                    result.Add(dr["telefon"].ToString());
                    result.Add(dr["email"].ToString());
                    result.Add(dr["kraj"].ToString());
                    result.Add(dr["miasto"].ToString());
                    result.Add(dr["kod"].ToString());
                    result.Add(dr["ulica"].ToString());
                    result.Add(dr["budynek"].ToString());
                    result.Add(dr["mieszkanie"].ToString());
                }
            }
            catch (SqlException blad)
            {
                result[0] = "Blad podczas wykonywania polecenia w bazie: " + blad.Errors.ToString();
            }

            disconnect();
            return result;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////ChangeUserInfo//////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public string ChangeUserInfo(string login, string imie, string nazwisko, string email, string telefon, string kraj,
                                     string miasto, string kod, string ulica, string dom, string mieszkanie)
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
                "EXEC EDYTUJ_DANE " +
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
                "\'" + login + "\'", conn);
                cmd.ExecuteReader();
            }
            catch (SqlException blad)
            {
                result = "Blad podczas wykonywania polecenia w bazie: " + blad.Errors.ToString();
            }

            disconnect();
            return result;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////CheckRegex//////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //Check Regular Expression - sprawdza warunek zmiennej typu varchar z tabeli w bazie danych,
        //kluczem jest nazwa zmiennej z bazy, wartosc to tekst ktory ma zostac sprawdzony
        //dostepne zmienne mozna podejrzec w konstruktorze klasy WCF-a, tam tez mozna je dopisywac

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
