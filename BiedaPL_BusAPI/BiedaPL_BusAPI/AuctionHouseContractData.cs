using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.Data.Linq;
using System.ComponentModel;
using System.Reflection;
using System.ComponentModel.DataAnnotations;

#pragma warning disable 1591
namespace BiedaPL_BusAPI
{
    /*[DataContract(IsReference = true)]
    public class User
    {
        public User()
        {
            this.Id = 0;
            this.Login = "";
        }

        public User(string login)
        {
            this.Id = 0; //TO DO gen ID from server table
            this.Login = login;
        }

        public User(KLIENT klient, DANE dane)
        {
            this.Login = klient.login;
            this.Id = dane.id_dane;
        }

        public User(SPRZEDAWCA klient, DANE dane)
        {
            this.Login = klient.login;
            this.Id = dane.id_dane;
        }

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Login { get; set; }
    }

    [DataContract(IsReference=true)]
    public class Bid
    {
        public Bid()
        {
            this.Offerent = null;
            this.Amount = 0;
            this.PricePerUnit = 0;
            this.Auction = null;
            this.Time = DateTimeOffset.Now;
        }

        public Bid(User offerent, Auction auction, int amount, decimal pricePerUnit)
        {
            this.Offerent = offerent;
            this.Amount = amount;
            this.PricePerUnit = pricePerUnit;
            this.Auction = auction;
            this.Time = DateTimeOffset.Now;
        }

        public Bid(KLIENT klient, OFERTA oferta)
        {
            this.Amount = 1;
            this.Auction = new Auction();
            this.Offerent = new User(klient, klient.DANE);
            this.PricePerUnit = oferta.kwota;
            this.Time = oferta.data_zlozenia; //slabe zalozenie, brak tabeli dot servera i strefy czasowej

        }

        [DataMember]
        public User Offerent { get; set; }
        [DataMember]
        public Auction Auction { get; set; }
        [DataMember]
        public int Amount { get; set; }
        [DataMember]
        public decimal PricePerUnit { get; set; }
        [DataMember]
        public DateTimeOffset Time { get; set; }

    }

    public class AuctionItem
    {
        public AuctionItem()
        {
            this.Id = 0;
            this.Name = "";
            this.UnitType = "";
            this.Owner = null;
            this.Description = "";
            this.MinPrice = 0;
            this.Photos = new List<string>();
        }

        public AuctionItem(User owner, string name, string unitType, string desc, 
            decimal minPrice, IList<string> photos)
        {
            this.Id = 0; //TO DO gen ID from server table
            this.Name = name;
            this.UnitType = unitType;
            this.Owner = owner;
            this.Description = desc;
            this.MinPrice = minPrice;
            this.Photos = new List<string>();
        }

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string UnitType { get; set; }
        [DataMember]
        public User Owner { get; set; }
        [DataMember]
        public IList<string> Photos { get; set; }

        [DataMember]
        public decimal MinPrice { get; set; }
        [DataMember]
        public string Description { get; set; }
    }

    public class AuctionDraft
    {
        public AuctionDraft()
        {
            this.Id = 0;
            this.Title = "";
            this.Owner = null;
            this.Duration = new TimeSpan(0);
            this.Item = null;
            this.Amount = 0;
            this.MinPrice = 0;
            this.DeliveryCost = 0;
            this.Description = "";
            this.CategoryName = "";
        }

        public AuctionDraft(AuctionDraft other)
        {
            this.Id = 0; //TO DO gen ID from server table
            this.Amount = other.Amount;
            this.CategoryName = other.CategoryName;
            this.DeliveryCost = other.DeliveryCost;
            this.Description = other.Description;
            this.Item = other.Item;
            this.MinPrice = other.MinPrice;
            this.Owner = other.Owner;
            this.Title = other.Title;
        }

        public AuctionDraft(string title,  string category, 
            User owner, AuctionItem item, 
            int amount, decimal minPrice, decimal deliveryCost)
        {
            this.Id = 0;//TO DO gen ID from server table
            this.Title = title;
            this.Owner = owner;
            this.Item = item;
            this.Amount = amount;
            this.MinPrice = minPrice;
            this.DeliveryCost = deliveryCost;
            this.Description = desc;
            this.CategoryName = category;
        }

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public User Owner { get; set; }
        //[DataMember]
        //public TimeSpan Duration { get; set; }
        [DataMember]
        public AuctionItem Item { get; set; }
        [DataMember]
        public int Amount { get; set; }
        [DataMember]
        public decimal DeliveryCost { get; set; }
        [DataMember]
        public string CategoryName { get; set; }
    }

    public class Auction : AuctionDraft
    { //draft , auction gain from one Id generator
        public Auction()
            : base()
        {
            //TO DO gen ID from server table
            this.LastPrice = 0;
            this.Comment = "";
            this.TimeToStart = DateTimeOffset.Now;
            this.AmountLeft = 0;
            this.Bids = new List<Bid>();
            this.Draft = null;
        }

        public Auction(decimal lastPrice, int amountLeft, string comment,
            DateTimeOffset startAt, IList<Bid> bids, AuctionDraft draft)
            : base()
        {
            //TO DO gen ID from server table
            this.LastPrice = lastPrice;
            this.Comment = comment;
            this.TimeToStart = startAt;
            this.AmountLeft = amountLeft;
            this.Bids = bids;
            this.Draft = draft;
        }

        //moze zrobic tablice stringow i pojechac enumem po category description comment, etc?
        //tak samo z tablica decimali?
        public Auction(string title, string desc, string category, 
            User owner, TimeSpan duration, AuctionItem item, 
            int amount, decimal minPrice, decimal deliveryCost, decimal lastPrice, int amountLeft, string comment,
            DateTimeOffset startTime, DateTimeOffset endTime, IList<Bid> bids, AuctionDraft draft)
            : base(title, category, owner, item, amount, minPrice, deliveryCost)
        {
            //TO DO gen ID from server table
            this.LastPrice = lastPrice;
            this.DeliveryCost = deliveryCost;
            this.Comment = comment;
            this.CategoryName = category;
            this.Description = desc;
            this.TimeToStart = startTime;
            this.TimeToEnd = endTime;
            this.AmountLeft = amountLeft;
            this.Bids = bids;
            this.Draft = draft;
        }

        public Auction(AuctionDraft draft)
            : base(draft)
        {
            //TO DO gen ID from server table
            this.LastPrice = 0;
            this.Comment = "";
            this.TimeToStart = DateTimeOffset.Now;
            this.TimeToEnd = this.TimeToStart.AddDays(7);
            this.AmountLeft = 0;
            this.Bids = new List<Bid>();
            this.Draft = null;
        }

        public Auction(SPRZEDAWCA klient, AUKCJA aukcja)
            : base()
        {
        }

        [DataMember]
        public decimal LastPrice { get; set; }
        [DataMember]
        public string Comment { get; set; }
        [DataMember]
        public DateTimeOffset TimeToStart { get; set; }
        [DataMember]
        public DateTimeOffset TimeToEnd { get; set; }
        [DataMember]
        public int AmountLeft { get; set; }
        [DataMember]
        public IList<Bid> Bids { get; set; }
        [DataMember]
        public AuctionDraft Draft { get; set; }
    }*/
}

#pragma warning restore 1591