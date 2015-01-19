using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MyWCFServices
{
    [DataContract]
    public class AuctionCategory
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Id { get; set; }
    }
       
    [DataContract]
    public class Auction
    {
        [DataMember]
        public int id_aukcji { get; set; }
        [DataMember]
        public int id_kategoria { get; set; }
        [DataMember]
        public string login { get; set; }
        [DataMember]
        public DateTime data_zakonczenia { get; set; }
        [DataMember]
        public string opis { get; set; }
        [DataMember]
        public string nazwa_produktu { get; set; }
        [DataMember]
        public decimal cena_startowa { get; set; }
        [DataMember]
        public decimal cena_wysylki { get; set; }
        [DataMember]
        public int ocena_sprzedawcy { get; set; }
        [DataMember]
        public string komentarz_dla_sprzedawcy { get; set; }
    }

    [DataContract]
    public class AuctionData
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