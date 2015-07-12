using BitcoinBot.Connection;
using System.Threading;

namespace BitcoinBot
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                DataHandler.DataParser.PopulateData(ConnectionHandler.GetJsonFromUrl("https://www.bitstamp.net/api/order_book/"));
                Thread.Sleep(1200);
            }
        }
    }
}
