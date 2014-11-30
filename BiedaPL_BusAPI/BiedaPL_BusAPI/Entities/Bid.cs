using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace BiedaPL_BusAPI.Entities
{
    [DataContract]
    public class Bid : IEntity<DbAuctionHouseDataContext>
    {
        public Bid()
        {
            this.Offerent = null;
            this.Time = DateTimeOffset.Now;
        }

        [DataMember]
        public DateTimeOffset Time { get; set; }
        [DataMember]
        public User Offerent { get; set; }

        public virtual void Search(DbAuctionHouseDataContext dbManager)
        {
            throw new NotImplementedException();
        }

        public ResultSearch Found { get; set; }
    }
}
