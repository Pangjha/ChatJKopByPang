using System;
using System.Net;

namespace LiteChat
{
    class InternetConnection
    {
       public static Boolean checkConnectionInternet()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://clients3.google.com/generate_204"))

                    Console.WriteLine("connectInternet");
                    return true;
               
            }
            catch
            {
                return false;
            }
        }
    }
}
