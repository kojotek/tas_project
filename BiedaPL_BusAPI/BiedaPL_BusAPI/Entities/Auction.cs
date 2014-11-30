using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace BiedaPL_BusAPI.Entities
{
    [DataContract]
    public class Auction : AuctionDraft, IEntity<DbAuctionHouseDataContext>
    {
        public Auction()
            : base()
        {
            this.TimeToEnd = new DateTimeOffset();
            this.Id = 0;
            this.Bids = null; //albo moze new List<Bid>(), zobaczymy
            this.Closure = null;
        }

        public Auction(AUKCJA aukcja)
            : base(aukcja)
        {
            this.Id = aukcja.id_aukcji;
            this.Title = String.Format("{0} (id:{1})", aukcja.nazwa_produktu, aukcja.id_aukcji);
            this.TimeToEnd = new DateTimeOffset(aukcja.data_zakonczenia);
            this.Bids = null; //albo moze new List<Bid>(), zobaczymy
            this.Closure = null;
        }

        //public DateTimeOffset TimeToStart { get; set; }
        [DataMember]
        public DateTimeOffset TimeToEnd { get; set; }
        [DataMember]
        public IList<Bid> Bids { get; set; }
        [DataMember(IsRequired = false)]
        public AuctionClosure Closure { get; set; }

        public override void Search(DbAuctionHouseDataContext db)
        {
            int result = 0;

            if (Id != 0)
                result = db.AUKCJAs.Where(x => x.id_aukcji == Id).Count();
            else if (Owner != null)
            {
                var byId = db.AUKCJAs.Where(x => x.SPRZEDAWCA.DANE.id_dane == Owner.Id);
                var byLogin = db.AUKCJAs.Where(x => x.SPRZEDAWCA.login == Owner.Login);
                result = byId.Union(byLogin).Count();
            }
            else if (Item != null)
            {
                result = db.AUKCJAs.Where(x => x.nazwa_produktu == Item.Name || x.opis == Item.Description).Count();
            }
            else if (Title != null && Title != "")
            {
                result = db.AUKCJAs.Where(x => String.Format("{0} (id:{1})", x.nazwa_produktu, x.id_aukcji) == Title).Count();
            }
        }
    }
}
