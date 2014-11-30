using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace BiedaPL_BusAPI.Entities
{
    public enum ResultSearch { None, Single, Multiple }

    //takie troche do bani, ale poki co niech bedzie
    public interface IEntity<Database>
    {
        void Search(Database dbManager);
        ResultSearch Found { get; set; }
    }
}
