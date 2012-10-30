using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Reflection;


namespace FixedAssetsHost
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Console Based WCF Host *****");

            using(ServiceHost serw = new ServiceHost(typeof(ZMTFixedAssetsService.Services.FixedAssetService)))
            {
                serw.Open();
                DisplayHostInfo(serw);
                Console.WriteLine("The service is ready");
                Console.WriteLine("Press the Enter key to terminate service");
                Console.ReadLine();
            }
            
        }


        static void DisplayHostInfo(ServiceHost host)
        {
            Console.WriteLine();
            Console.WriteLine("***** Host Info *****");
            Console.WriteLine("Name: {0}", host.Description.ConfigurationName);
            Console.WriteLine("Port: {0}", host.BaseAddresses[0].Port);
            Console.WriteLine("Local Path: {0}", host.BaseAddresses[0].LocalPath);
            Console.WriteLine("Uri: {0}", host.BaseAddresses[0].AbsoluteUri);
            Console.WriteLine("Scheme: {0}", host.BaseAddresses[0].Scheme);
            Console.WriteLine("**********************");
            Console.WriteLine();
        }
    }
}
