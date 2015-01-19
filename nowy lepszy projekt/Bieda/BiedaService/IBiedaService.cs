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
        //Check Regular Expression - sprawdza warunek zmiennej typu varchar z tabeli w bazie danych,
        //kluczem jest nazwa zmiennej z bazy, wartosc to tekst ktory ma zostac sprawdzony       
       
        [OperationContract]
        string CheckRegex(string klucz, string wartosc);  

        [OperationContract]
        List<string> getMessages(string login);

        #region AccountManagment

        [OperationContract]
        string RegisterUser(string login, string haslo, string imie, string nazwisko, string email, 
            string telefon, string kraj, string miasto, string kod, string ulica, string dom, string mieszkanie);  
       
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



        #endregion
                             
        #region AuctionManagment

        [OperationContract]
        string getAuctionWinner(int id);

        [OperationContract]
        string getAuctionHighestOffer(int id);
                                                 
        [OperationContract]
        List<string> getAuctionInfo(int id);  
 
        [OperationContract]
        bool isAuctionOver(int id); 

        [OperationContract]
        IList<int> getAuctionIdList();        
                                      
        [OperationContract]
        IList<AuctionCategory> getAuctionCategoryList();  

        [OperationContract]
        IList<int> getAuctionIdListByCategory(int categoryId);

        [OperationContract]
        void createAuction(string userLogin, string categoryName, string productName, string productDesc, 
            decimal pricePerUnit, decimal priceDelivery, int lifeTimeDays);
                          
        [OperationContract]
        List<AuctionData> getAuctions(string haslo, int kategoria, int sposob_sort, int rosnaco);

        [OperationContract]
        Auction getAuctionById(int auctionId);

        [OperationContract]
        IList<int> getAuctionListbyUserId(string userId);

        #endregion      

        #region AuctionFinalizationManagment

        [OperationContract]
        bool AuctionAllreadyCommented(int id);

        [OperationContract]
        bool addComment(int id_aukcji, string login, string comment, int ocena);

        [OperationContract]
        bool addCommentMessage(int id_aukcji, string login);

        #endregion

    }

    public interface helpfullThings
    {
        bool connect();

        void disconnect();
    }
}
