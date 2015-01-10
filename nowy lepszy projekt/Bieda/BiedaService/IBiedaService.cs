using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Data.SqlClient;

namespace MyWCFServices
{
    [ServiceContract]
    public interface IBiedaService
    {
        [OperationContract]
        string RegisterUser(string login, string haslo, string imie, string nazwisko, string email, string telefon, string kraj, string miasto, string kod, string ulica, string dom, string mieszkanie); 
     
        [OperationContract]
        List<string> getAuctionInfo(int id);   
     
        [OperationContract]
        bool isAuctionOver(int id);
        //Check Regular Expression - sprawdza warunek zmiennej typu varchar z tabeli w bazie danych,
        //kluczem jest nazwa zmiennej z bazy, wartosc to tekst ktory ma zostac sprawdzony       
       
        [OperationContract]
        string CheckRegex(string klucz, string wartosc);
       
        [OperationContract]
        string LoginIn(string login, string pass);

        [OperationContract]
        string IsSeller(string login);
        
        [OperationContract]
        string ChangePass(string login, string newPass);
        
        [OperationContract]
        string UpgradeAcc(string login, string numerKonta);

        [OperationContract]
        string EditBankAccount(string login, string numerKonta);
        
        [OperationContract]
        string DeleteAcc(string login);
        
        [OperationContract]
        List<string> LoadAccInfo(string login);
        
        [OperationContract]
        string ChangeUserInfo(string login, string imie, string nazwisko, string email, string telefon, string kraj, string miasto, string kod, string ulica, string dom, string mieszkanie);

        [OperationContract]
        List<string> getMessages(string login);

        [OperationContract]
        string getAuctionWinner(int id);

        [OperationContract]
        string getAuctionHighestOffer(int id);
    }

    public interface helpfullThings
    {
        bool connect();

        void disconnect();
    }
}
