using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Data.SqlClient;

namespace MyWCFServices
{
    [ServiceContract]
    public interface IBiedaService
    {
        [OperationContract]
        String GetMessage(String name);
        [OperationContract]
        string GetMessage2(String user, String pass);
        [OperationContract]
        List<string> getAuctionInfo(int id);
        [OperationContract]
        bool isAuctionOver(int id);
    }

    public interface helpfullThings
    {
        bool connect();
        void disconnect();
    }
}
