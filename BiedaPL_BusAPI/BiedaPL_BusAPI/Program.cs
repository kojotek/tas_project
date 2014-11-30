using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Data.SqlClient;
using System.Data.Sql;
using System.IO;

namespace BiedaPL_BusAPI
{

    //Instrukcje:
    //kto nie ma, niech utworzy u siebie na lokalnym serwerze (Main Menu | Data | T-SQL Editor | New Query Connection) tabelki zgodnie z tym co w projekcie
    //kto nie moze utworzyc tabelek niech zainstaluje jakis serwer bazodanowy SQLa (np MS Managment Studio 2008 R2 albo 2012)

    //F5

    class Program
    {
        static void Main(string[] args)
        {
            string adr = "http://" + Environment.MachineName + ":8080/Auction";
            Uri uri = new Uri(adr);
            ServiceHost host = new ServiceHost(typeof(AuctionManager), uri);

            try
            {
                host.AddServiceEndpoint(typeof(IAuctionManager), new BasicHttpBinding(), uri);

                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                host.Description.Behaviors.Add(smb);

                host.Open();
                Console.WriteLine("Host opened");
                Console.Write("Press ENTER to close the host");
                Console.ReadLine();
                host.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("An exception occurred: {0}", e.Message);
                host.Abort();
            }
            Console.Write("press Enter to exit application");

            //cholera wie do czego to nizej moze sie przydac, wiec zostawiam na przyszlosc (jakis inny sposob)

            //host.AddServiceEndpoint(typeof(IAuctionManager), new BasicHttpBinding(), uri);
            //host.Open();
            //Console.WriteLine("Host opened");
            //ChannelFactory<ITest> factory = new ChannelFactory<ITest>(new BasicHttpBinding(), new EndpointAddress(adr));
            //ITest proxy = factory.CreateChannel();

            //Article article = new Article { ArticleName = "AName" };
            //Category category = new Category { CategoryName = "cname" };
            //category.Articles.Add(article);
            //article.Category = category;

            //Console.WriteLine(proxy.MyFunction(category));

            //((IClientChannel)proxy).Close();
            //factory.Close();

        }
    }
}
