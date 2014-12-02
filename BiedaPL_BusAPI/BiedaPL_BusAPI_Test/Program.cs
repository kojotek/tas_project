using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BiedaPL_BusAPI_Test.AuctionHouse;

namespace BiedaPL_BusAPI_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            AuctionManagerClient auc_mngr = new AuctionManagerClient();

            var user = new User();
            var auction = new Auction();
            var categoryName = "agd";
            BiedaPL_BusAPI_Test.AuctionHouse.AuctionManagerClient 
            auc_mngr.doCreateAuction(user, auction, categoryName); 
            //po odpaleniu powinno wywolac metode z 'webservicu' - to nie do konca jest webservice, .. jest nawet LEPSZE
            //teoretycznie czesc z atrybutow jest ustawiona jako blokujaca (InOneWay = true) 
            //wiec powinno zawiesic caly program, ale... mozna uzyc ThreadPool albo TaskPool, ale wtedy bojmy sie synchronizacji
        }
    }
}
