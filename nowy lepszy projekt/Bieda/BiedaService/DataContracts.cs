using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MyWCFServices
{
       
    [DataContract]
    public class AuctionDataContract
    {
        [DataMember]
        public string Login { get; set; }
        [DataMember]
        public string DataZakonczenia { get; set; }
        [DataMember]
        public string NazwaProduktu { get; set; }
        [DataMember]
        public string CenaStartowa { get; set; }
        [DataMember]
        public string CenaWysylki { get; set; }
        [DataMember]
        public string OcenaSprzedawcy { get; set; }
        [DataMember]
        public string Cena { get; set; }
    }
}