using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace BiedaPL_BusAPI.Entities
{
    [DataContract]
    public class AuctionDraft : IEntity<DbAuctionHouseDataContext>
    {
        public AuctionDraft()
        {
            this.Id = -1;
            this.Title = "";
            this.Owner = null;
            this.Item = null;
            this.Category = "";
            this.Delivery = null;
            this.Price = null;
        }

        public AuctionDraft(AUKCJA aukcja)
        {
            this.Id = aukcja.id_aukcji;//TO DO: generate ID, nowa tabela z zakresami ID
            this.Title = aukcja.nazwa_produktu;
            this.Owner = new User(aukcja.SPRZEDAWCA);
            this.Category = aukcja.KATEGORIA.Nazwa;
            this.Item = new AuctionItem(aukcja);
            this.Delivery = new PricePerDelivery(aukcja.cena_wysylki,"swiniowoz");
            this.Price = new PricePerUnit(aukcja.cena_startowa,1);
        }

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public User Owner { get; set; }
        [DataMember]
        public AuctionItem Item { get; set; }
        [DataMember]
        public string Category { get; set; }
        [DataMember]
        public PricePerUnit Price { get; set; }
        [DataMember]
        public PricePerDelivery Delivery { get; set; }

        public virtual void Search(DbAuctionHouseDataContext dbManager)
        {
            throw new NotImplementedException();
        }

        public ResultSearch Found { get; set; }
    }
}
