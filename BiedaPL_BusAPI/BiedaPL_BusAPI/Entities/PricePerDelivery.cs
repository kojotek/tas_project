using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace BiedaPL_BusAPI.Entities
{
    [DataContract]
    public class PricePerDelivery
    {
        //enum Way { None, Personal, Service }

        public PricePerDelivery()
        {
            this.Price = 0;
            this.DeliverBy = "";
        }

        public PricePerDelivery(decimal price, string deliverBy)
        {
            this.Price = price;
            this.DeliverBy = deliverBy;
        }

        [DataMember]
        public string DeliverBy { get; set; }
        [DataMember]
        public decimal Price { get; set; }
    }
}
