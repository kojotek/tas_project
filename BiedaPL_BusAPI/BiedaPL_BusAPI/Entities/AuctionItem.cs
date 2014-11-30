using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace BiedaPL_BusAPI.Entities
{
    [DataContract]
    public class AuctionItem : IEntity<DbAuctionHouseDataContext>
    {
        public AuctionItem()
        {
            this.Id = -1;
            this.Name = "";
            this.Description = "";
            this.UnitType = "";
            this.PhotoLinkList = new List<string>();
        }

        public AuctionItem(AUKCJA aukcja)
        {
            this.Id = -1;
            this.Name = aukcja.nazwa_produktu;
            this.Description = aukcja.opis;
            this.UnitType = "";
            this.PhotoLinkList = new List<string>(); //TO DO: baza danych powinna zawierac linki do obrazkow
        }

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string UnitType { get; set; }
        [DataMember]
        public IList<string> PhotoLinkList { get; set; }

        public void Search(DbAuctionHouseDataContext db)
        {   //nie wiem czy to ma sens, 
            //tak jakby powiedziec, ze gdzies w swiecie jest item "Oko Pustelnika" 
            //i wyskakuje 50 historyjek co do jego posiadacza
            //albo opis Oka i wyskakuje ze to Kij +5 do zamiatania
            var result = db.AUKCJAs.Where(x => x.nazwa_produktu == Name || x.opis == Description).Count();
            Found = result > 0 ? (result == 1 ? ResultSearch.Single : ResultSearch.Multiple) : ResultSearch.None;
        }

        public ResultSearch Found { get; set; }
    }
}
