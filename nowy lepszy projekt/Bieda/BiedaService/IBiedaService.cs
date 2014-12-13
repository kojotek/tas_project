using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace MyWCFServices
{
    [ServiceContract]
    public interface IBiedaService
    {
        [OperationContract]
        String GetMessage(String name);
    }
}
