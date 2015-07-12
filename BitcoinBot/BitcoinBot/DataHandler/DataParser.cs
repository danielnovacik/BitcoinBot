using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BitcoinBot.DataHandler
{
    public class DataParser
    {
        public static DateTime currentTime = DateTime.Now;

        public static void PopulateData(string rawJson)
        {
            ParsedJson = null;
            ParsedJson = JObject.Parse(rawJson);

            AllBids = ParsedJson["bids"].Select(x => { return new BidAskData { Price = (double)x[0], Volume = (double)x[0] }; }).Take(10).ToList();
            AllAsks = ParsedJson["asks"].Select(x => { return new BidAskData { Price = (double)x[0], Volume = (double)x[0] }; }).Take(10).ToList();

            DataPrinter.PrintOpportunity(AllAsks, AllBids, currentTime.ToString("dd/MM/yyyy hh:mm:ss"));
        }

        public static JObject ParsedJson { get; set; }
        public static List<BidAskData> AllBids { get; set; }
        public static List<BidAskData> AllAsks { get; set; }
    }
}
