using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace BiedaPL_BusAPI
{

    using Entities;

    [ServiceContract]
    interface IUserManager
    {
        [OperationContract]
        IList<User> getUserList(int count, int startAt);

        [OperationContract]
        User doCreateUser(User user);

        [OperationContract]
        User doFindUser(User user);                //user.name  or user.id

        [OperationContract]
        void doTextMessage(User sender, User receiver, string msg);

    }

    [ServiceContract]
    interface IAuctionItemManager
    {
        [OperationContract]
        IList<AuctionItem> getAuctionItem(Auction auction);

        [OperationContract]
        AuctionItem doCreateAuctionItem(User user, AuctionItem item);
    }     

    [ServiceContract]
    interface IAuctionDratfManager
    {
        [OperationContract]
        IList<AuctionDraft> getAuctionDraftList(User user);

        [OperationContract]
        void doCreateDraft(User user, Auction auction, string title);

        [OperationContract]
        Auction doUseDraft(AuctionDraft draft);
    }

    [ServiceContract]
    interface IAuctionManager
    {
        [OperationContract(IsOneWay=false)]
        IList<string> getCategoryList();

        [OperationContract(IsOneWay = false)]
        IList<Auction> getAuctionList(string category);

        [OperationContract(IsOneWay = false)]
        Auction doCreateAuction(User user, Auction auction, string categoryName);

        [OperationContract(IsOneWay = false)]
        Auction doCloneAuction(User user, Auction auction);

        [OperationContract(IsOneWay = false)]
        Auction doFindAuction(Auction auction);

        [OperationContract(IsOneWay = true)]
        void doBid(User user, Auction auction, decimal pricePerUnit, int amount);

        [OperationContract(IsOneWay = true)]
        void doCloseAuction(User user, Auction auction, string comment);

        [OperationContract(IsOneWay = true)]
        void doComment(User user, string comment);
    }
}
