using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace BiedaPL_BusAPI.Entities
{
    [DataContract]
    public class PricePerUnit
    {
        public PricePerUnit()
        {
            this.Price = 0;
            this.Amount = 0;
        }

        public PricePerUnit(decimal price, int amount)
        {
            this.Price = price;
            this.Amount = amount;
        }

        [DataMember]
        public int Amount { get; set; }
        [DataMember]
        public decimal Price { get; set; }
    }
}
