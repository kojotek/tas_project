using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace BiedaPL_BusAPI.Entities
{
    [DataContract]
    public class User : IEntity<DbAuctionHouseDataContext>
    {
        public User()
        {
            this.Id = -1;
            this.Login = "";
        }

        public User(SPRZEDAWCA sprzedawca)
        {
            this.Id = sprzedawca.DANE.id_dane;
            this.Login = sprzedawca.login;
        }

        public User (KLIENT klient)
        {
            this.Id = klient.DANE.id_dane;
            this.Login = klient.login;
	    }

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Login { get; set; }

        public virtual void Search(DbAuctionHouseDataContext db)
        {
            var buyers = db.KLIENTs.Where(x => x.login == Login).Count();
            var sellers = db.SPRZEDAWCAs.Where(x => x.login == Login).Count();

            if (buyers * sellers == 1)
                Found = ResultSearch.Single;
            else if (buyers + sellers > 1)
                Found = ResultSearch.Multiple;
            else
                Found = ResultSearch.None;
        }

        public ResultSearch Found { get; set; }

    }
}
