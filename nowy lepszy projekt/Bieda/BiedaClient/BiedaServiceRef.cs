﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.5485
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyWCFServices
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="AuctionCategory", Namespace="http://schemas.datacontract.org/2004/07/MyWCFServices")]
    public partial class AuctionCategory : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private int IdField;
        
        private string NameField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id
        {
            get
            {
                return this.IdField;
            }
            set
            {
                this.IdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name
        {
            get
            {
                return this.NameField;
            }
            set
            {
                this.NameField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="AuctionData", Namespace="http://schemas.datacontract.org/2004/07/MyWCFServices")]
    public partial class AuctionData : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private string CenaField;
        
        private string CenaStartowaField;
        
        private string CenaWysylkiField;
        
        private string DataZakonczeniaField;
        
        private string LoginField;
        
        private string NazwaProduktuField;
        
        private string OcenaSprzedawcyField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Cena
        {
            get
            {
                return this.CenaField;
            }
            set
            {
                this.CenaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CenaStartowa
        {
            get
            {
                return this.CenaStartowaField;
            }
            set
            {
                this.CenaStartowaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CenaWysylki
        {
            get
            {
                return this.CenaWysylkiField;
            }
            set
            {
                this.CenaWysylkiField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DataZakonczenia
        {
            get
            {
                return this.DataZakonczeniaField;
            }
            set
            {
                this.DataZakonczeniaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Login
        {
            get
            {
                return this.LoginField;
            }
            set
            {
                this.LoginField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string NazwaProduktu
        {
            get
            {
                return this.NazwaProduktuField;
            }
            set
            {
                this.NazwaProduktuField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string OcenaSprzedawcy
        {
            get
            {
                return this.OcenaSprzedawcyField;
            }
            set
            {
                this.OcenaSprzedawcyField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Auction", Namespace="http://schemas.datacontract.org/2004/07/MyWCFServices")]
    public partial class Auction : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private decimal cena_startowaField;
        
        private decimal cena_wysylkiField;
        
        private System.DateTime data_zakonczeniaField;
        
        private int id_aukcjiField;
        
        private int id_kategoriaField;
        
        private string komentarz_dla_sprzedawcyField;
        
        private string loginField;
        
        private string nazwa_produktuField;
        
        private int ocena_sprzedawcyField;
        
        private string opisField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal cena_startowa
        {
            get
            {
                return this.cena_startowaField;
            }
            set
            {
                this.cena_startowaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal cena_wysylki
        {
            get
            {
                return this.cena_wysylkiField;
            }
            set
            {
                this.cena_wysylkiField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime data_zakonczenia
        {
            get
            {
                return this.data_zakonczeniaField;
            }
            set
            {
                this.data_zakonczeniaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int id_aukcji
        {
            get
            {
                return this.id_aukcjiField;
            }
            set
            {
                this.id_aukcjiField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int id_kategoria
        {
            get
            {
                return this.id_kategoriaField;
            }
            set
            {
                this.id_kategoriaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string komentarz_dla_sprzedawcy
        {
            get
            {
                return this.komentarz_dla_sprzedawcyField;
            }
            set
            {
                this.komentarz_dla_sprzedawcyField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string login
        {
            get
            {
                return this.loginField;
            }
            set
            {
                this.loginField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string nazwa_produktu
        {
            get
            {
                return this.nazwa_produktuField;
            }
            set
            {
                this.nazwa_produktuField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ocena_sprzedawcy
        {
            get
            {
                return this.ocena_sprzedawcyField;
            }
            set
            {
                this.ocena_sprzedawcyField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string opis
        {
            get
            {
                return this.opisField;
            }
            set
            {
                this.opisField = value;
            }
        }
    }
}


[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(ConfigurationName="IBiedaService")]
public interface IBiedaService
{
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBiedaService/CheckRegex", ReplyAction="http://tempuri.org/IBiedaService/CheckRegexResponse")]
    string CheckRegex(string klucz, string wartosc);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBiedaService/getMessages", ReplyAction="http://tempuri.org/IBiedaService/getMessagesResponse")]
    string[] getMessages(string login);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBiedaService/RegisterUser", ReplyAction="http://tempuri.org/IBiedaService/RegisterUserResponse")]
    string RegisterUser(string login, string haslo, string imie, string nazwisko, string email, string telefon, string kraj, string miasto, string kod, string ulica, string dom, string mieszkanie);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBiedaService/LoginIn", ReplyAction="http://tempuri.org/IBiedaService/LoginInResponse")]
    string LoginIn(string login, string pass);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBiedaService/IsSeller", ReplyAction="http://tempuri.org/IBiedaService/IsSellerResponse")]
    string IsSeller(string login);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBiedaService/ChangePass", ReplyAction="http://tempuri.org/IBiedaService/ChangePassResponse")]
    string ChangePass(string login, string newPass);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBiedaService/UpgradeAcc", ReplyAction="http://tempuri.org/IBiedaService/UpgradeAccResponse")]
    string UpgradeAcc(string login, string numerKonta);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBiedaService/EditBankAccount", ReplyAction="http://tempuri.org/IBiedaService/EditBankAccountResponse")]
    string EditBankAccount(string login, string numerKonta);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBiedaService/DeleteAcc", ReplyAction="http://tempuri.org/IBiedaService/DeleteAccResponse")]
    string DeleteAcc(string login);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBiedaService/LoadAccInfo", ReplyAction="http://tempuri.org/IBiedaService/LoadAccInfoResponse")]
    string[] LoadAccInfo(string login);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBiedaService/ChangeUserInfo", ReplyAction="http://tempuri.org/IBiedaService/ChangeUserInfoResponse")]
    string ChangeUserInfo(string login, string imie, string nazwisko, string email, string telefon, string kraj, string miasto, string kod, string ulica, string dom, string mieszkanie);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBiedaService/getAuctionWinner", ReplyAction="http://tempuri.org/IBiedaService/getAuctionWinnerResponse")]
    string getAuctionWinner(int id);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBiedaService/getAuctionHighestOffer", ReplyAction="http://tempuri.org/IBiedaService/getAuctionHighestOfferResponse")]
    string getAuctionHighestOffer(int id);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBiedaService/getAuctionInfo", ReplyAction="http://tempuri.org/IBiedaService/getAuctionInfoResponse")]
    string[] getAuctionInfo(int id);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBiedaService/isAuctionOver", ReplyAction="http://tempuri.org/IBiedaService/isAuctionOverResponse")]
    bool isAuctionOver(int id);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBiedaService/getAuctionIdList", ReplyAction="http://tempuri.org/IBiedaService/getAuctionIdListResponse")]
    int[] getAuctionIdList();
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBiedaService/getAuctionCategoryList", ReplyAction="http://tempuri.org/IBiedaService/getAuctionCategoryListResponse")]
    MyWCFServices.AuctionCategory[] getAuctionCategoryList();
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBiedaService/getAuctionIdListByCategory", ReplyAction="http://tempuri.org/IBiedaService/getAuctionIdListByCategoryResponse")]
    int[] getAuctionIdListByCategory(int categoryId);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBiedaService/createAuction", ReplyAction="http://tempuri.org/IBiedaService/createAuctionResponse")]
    void createAuction(string userLogin, string categoryName, string productName, string productDesc, decimal pricePerUnit, decimal priceDelivery, int lifeTimeDays);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBiedaService/getAuctions", ReplyAction="http://tempuri.org/IBiedaService/getAuctionsResponse")]
    MyWCFServices.AuctionData[] getAuctions(string haslo, int kategoria, int sposob_sort, int rosnaco);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBiedaService/getAuctionById", ReplyAction="http://tempuri.org/IBiedaService/getAuctionByIdResponse")]
    MyWCFServices.Auction getAuctionById(int auctionId);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBiedaService/getAuctionListbyUserId", ReplyAction="http://tempuri.org/IBiedaService/getAuctionListbyUserIdResponse")]
    int[] getAuctionListbyUserId(string userId);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBiedaService/AuctionAllreadyCommented", ReplyAction="http://tempuri.org/IBiedaService/AuctionAllreadyCommentedResponse")]
    bool AuctionAllreadyCommented(int id);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBiedaService/addComment", ReplyAction="http://tempuri.org/IBiedaService/addCommentResponse")]
    bool addComment(int id_aukcji, string login, string comment, int ocena);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBiedaService/addCommentMessage", ReplyAction="http://tempuri.org/IBiedaService/addCommentMessageResponse")]
    bool addCommentMessage(int id_aukcji, string login);
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public interface IBiedaServiceChannel : IBiedaService, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public partial class BiedaServiceClient : System.ServiceModel.ClientBase<IBiedaService>, IBiedaService
{
    
    public BiedaServiceClient()
    {
    }
    
    public BiedaServiceClient(string endpointConfigurationName) : 
            base(endpointConfigurationName)
    {
    }
    
    public BiedaServiceClient(string endpointConfigurationName, string remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public BiedaServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public BiedaServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
    {
    }
    
    public string CheckRegex(string klucz, string wartosc)
    {
        return base.Channel.CheckRegex(klucz, wartosc);
    }
    
    public string[] getMessages(string login)
    {
        return base.Channel.getMessages(login);
    }
    
    public string RegisterUser(string login, string haslo, string imie, string nazwisko, string email, string telefon, string kraj, string miasto, string kod, string ulica, string dom, string mieszkanie)
    {
        return base.Channel.RegisterUser(login, haslo, imie, nazwisko, email, telefon, kraj, miasto, kod, ulica, dom, mieszkanie);
    }
    
    public string LoginIn(string login, string pass)
    {
        return base.Channel.LoginIn(login, pass);
    }
    
    public string IsSeller(string login)
    {
        return base.Channel.IsSeller(login);
    }
    
    public string ChangePass(string login, string newPass)
    {
        return base.Channel.ChangePass(login, newPass);
    }
    
    public string UpgradeAcc(string login, string numerKonta)
    {
        return base.Channel.UpgradeAcc(login, numerKonta);
    }
    
    public string EditBankAccount(string login, string numerKonta)
    {
        return base.Channel.EditBankAccount(login, numerKonta);
    }
    
    public string DeleteAcc(string login)
    {
        return base.Channel.DeleteAcc(login);
    }
    
    public string[] LoadAccInfo(string login)
    {
        return base.Channel.LoadAccInfo(login);
    }
    
    public string ChangeUserInfo(string login, string imie, string nazwisko, string email, string telefon, string kraj, string miasto, string kod, string ulica, string dom, string mieszkanie)
    {
        return base.Channel.ChangeUserInfo(login, imie, nazwisko, email, telefon, kraj, miasto, kod, ulica, dom, mieszkanie);
    }
    
    public string getAuctionWinner(int id)
    {
        return base.Channel.getAuctionWinner(id);
    }
    
    public string getAuctionHighestOffer(int id)
    {
        return base.Channel.getAuctionHighestOffer(id);
    }
    
    public string[] getAuctionInfo(int id)
    {
        return base.Channel.getAuctionInfo(id);
    }
    
    public bool isAuctionOver(int id)
    {
        return base.Channel.isAuctionOver(id);
    }
    
    public int[] getAuctionIdList()
    {
        return base.Channel.getAuctionIdList();
    }
    
    public MyWCFServices.AuctionCategory[] getAuctionCategoryList()
    {
        return base.Channel.getAuctionCategoryList();
    }
    
    public int[] getAuctionIdListByCategory(int categoryId)
    {
        return base.Channel.getAuctionIdListByCategory(categoryId);
    }
    
    public void createAuction(string userLogin, string categoryName, string productName, string productDesc, decimal pricePerUnit, decimal priceDelivery, int lifeTimeDays)
    {
        base.Channel.createAuction(userLogin, categoryName, productName, productDesc, pricePerUnit, priceDelivery, lifeTimeDays);
    }
    
    public MyWCFServices.AuctionData[] getAuctions(string haslo, int kategoria, int sposob_sort, int rosnaco)
    {
        return base.Channel.getAuctions(haslo, kategoria, sposob_sort, rosnaco);
    }
    
    public MyWCFServices.Auction getAuctionById(int auctionId)
    {
        return base.Channel.getAuctionById(auctionId);
    }
    
    public int[] getAuctionListbyUserId(string userId)
    {
        return base.Channel.getAuctionListbyUserId(userId);
    }
    
    public bool AuctionAllreadyCommented(int id)
    {
        return base.Channel.AuctionAllreadyCommented(id);
    }
    
    public bool addComment(int id_aukcji, string login, string comment, int ocena)
    {
        return base.Channel.addComment(id_aukcji, login, comment, ocena);
    }
    
    public bool addCommentMessage(int id_aukcji, string login)
    {
        return base.Channel.addCommentMessage(id_aukcji, login);
    }
}
