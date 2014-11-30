using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using BiedaPL_BusAPI.Entities;

namespace BiedaPL_BusAPI
{

    public class DatabaseManager
    {
        private static DbAuctionHouseDataContext database;

        public DbAuctionHouseDataContext Database 
        {
            get { return database = database ?? Activator.CreateInstance<DbAuctionHouseDataContext>(); } 
            set { database = value; } 
        }
    }


    public class AuctionManager : DatabaseManager, IAuctionManager
    {

        public IList<string> getCategoryList()
        {
            return Database.KATEGORIAs.Select(x=>x.Nazwa).ToList();
            //return (from categories in database.KATEGORIAs select categories.Nazwa)
        }

        public IList<Auction> getAuctionList(string category)
        {
            IList<Auction> result = new List<Auction>();

            var items = (from auctions in Database.AUKCJAs
                    where auctions.KATEGORIA.Nazwa == category
                    select auctions).ToList();

            foreach (var item in items)
                result.Add(new Auction(item));

            return result;
            //return database.AUKCJAs.Where(x=>x.KATEGORIA.Nazwa==category).ToList();
            //x => Z     
            //dla kazdej krotki istnieje obiekt x okreslonego typu T, taki ze przekaz go do funkcji Z i wykonaj funkcje Z
        
        }

        public Auction doCreateAuction(User user, Auction auction, string categoryName)
        {
            user.Search(Database); //czy istnieje uzytkownik
            //moze bedzie trzeba bedzie przechowac "potajemnie = wewnatrz warstwy biznesowej" bazodanowego uzytkownika, zeby go 2 razy nei szukac
            //na projekt bedzie ok, 
            //ale w rzeczywistosci )witualnej= co sie stanie, jak przechowamy kogos kto przestanie istniec?

            Auction result = null;

            switch (user.Found)
            {
                case ResultSearch.None: //nie ma usera
                    break;

                case ResultSearch.Single: //jest user
                case ResultSearch.Multiple: //a nawet wielu
                    var dbItem = new AUKCJA();
                    dbItem.cena_startowa = auction.Price.Price;
                    dbItem.cena_wysylki = auction.Delivery.Price;
                    dbItem.data_zakonczenia = auction.TimeToEnd.DateTime;

                    //first jest ryzykowny, bo first z zero jest ... gwarancja wypieprzenia sie aplikacji... uzywajcie try{} catch{}
                    var category = Database.KATEGORIAs.Where(x => x.Nazwa == auction.Category).First(); //mam nadzieje ze tak to dziala, tzn ze jakos logicznie zostanie to zresializowane
                    dbItem.KATEGORIA = category; //jesli nie to trzeba zastapic id_kategoria

                    var seller = Database.SPRZEDAWCAs.Where(x => x.DANE.id_dane == user.Id).First();
                    dbItem.SPRZEDAWCA = seller;

                    dbItem.login = user.Login;
                    dbItem.opis = auction.Item.Description;
                    dbItem.nazwa_produktu = auction.Item.Name;

                    dbItem.komentarz_dla_sprzedawcy = ""; //closure nie ma prawa wystapic podczas tworzenia
                    dbItem.ocena_sprzedawcy = 0; //nie ma oceny
                    dbItem.OFERTAs = null; //nie ma ofert

                    try
                    {
                        Database.AUKCJAs.InsertOnSubmit(dbItem);
                        Database.SubmitChanges(); //strach sie bac co tu sie stanie!
                    }
                    finally
                    {
                        result = new Auction(dbItem);                            
                    }
                    break;
            }

            return result;
        }

        public Auction doCloneAuction(User user, Auction auction)
        {
            throw new NotImplementedException();
        }

        public Auction doFindAuction(Auction auction)
        {
            throw new NotImplementedException();
        }

        public void doBid(User user, Auction auction, decimal pricePerUnit, int amount)
        {
            throw new NotImplementedException();
        }

        public void doCloseAuction(User user, Auction auction, string comment)
        {
            throw new NotImplementedException();
        }

        public void doComment(User user, string comment)
        {
            throw new NotImplementedException();
        }
    }
}

