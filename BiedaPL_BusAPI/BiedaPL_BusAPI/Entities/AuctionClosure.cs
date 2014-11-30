using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace BiedaPL_BusAPI.Entities
{
    [DataContract(IsReference = true)]
    public class AuctionClosure : IEntity<DbAuctionHouseDataContext>
    {
        //do powiadomien, wystawianych sobie wzajemnie ocen
        public AuctionClosure()
        {
            this.Comment = null;
            this.Auction = null;
            this.Offer = null;
            this.Buyer = null;
        }

        [DataMember]
        public string Comment { get; set; }
        [DataMember]
        public Auction Auction { get; set; }
        public User Buyer { get; set; }
        [DataMember]
        public Bid Offer { get; set; }

        public virtual void Search(DbAuctionHouseDataContext dbManager)
        {
            throw new NotImplementedException();
        }

        public ResultSearch Found { get; set; }
    }
}
