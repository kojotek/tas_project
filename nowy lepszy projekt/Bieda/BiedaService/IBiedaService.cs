﻿using System;
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
        string GetMessage2( String user, String pass );
        [OperationContract]
        string RegisterUser(string login, string haslo, string imie, string nazwisko, string email, string telefon, string kraj, string miasto, string kod, string ulica, string dom, string mieszkanie);
    }

    public interface helpfullThings
    {
        bool connect(string serverName, string database, string userId, string password);
        void disconnect();

    }
}
