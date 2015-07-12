using System;
using System.Collections.Generic;
using System.Linq;

namespace BitcoinBot.DataHandler
{
    class DataPrinter
    {
        public static void PrintOpportunity(List<BidAskData> asks, List<BidAskData> bids, string currentTime)
        {
            asks.Zip(bids, (ask, bid) => new { Ask = ask, Bid = bid })
                .Take(1)
                .Where(x => Math.Abs(x.Ask.Price - x.Bid.Price) > 0.10)
                .ToList()
                .ForEach(x => Console.WriteLine("{0} \t ASK: P: {1}   V: {2} \t BID: P: {3}   V: {4}",
                        currentTime,
                        x.Ask.Price.ToString("0.00"), x.Ask.Volume.ToString("0.0000"),
                        x.Bid.Price.ToString("0.00"), x.Bid.Volume.ToString("0.0000")));
        }

    }
}
