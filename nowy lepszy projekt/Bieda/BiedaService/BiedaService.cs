using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWCFServices
{
    public class BiedaService: IBiedaService
    {
        public String GetMessage(String name)
        {
            return "Kojotki witaja, " + name + "! Czuj sie jak u siebie!";
        }
    }
}
