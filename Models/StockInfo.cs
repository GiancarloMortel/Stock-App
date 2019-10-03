using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stock_App.Models
{
    public class StockInfo
    {
        public class Rootobject
        {
            public int symbols_requested { get; set; }
            public int symbols_returned { get; set; }
            public Datum[] data { get; set; }
        }

        public class Datum
        {
            public string symbol { get; set; }
            public string name { get; set; }
            public string price { get; set; }
            public string currency { get; set; }
            public string price_open { get; set; }
            public string day_high { get; set; }
            public string day_low { get; set; }
            public string _52_week_high { get; set; }
            public string _52_week_low { get; set; }
            public string day_change { get; set; }
            public string change_pct { get; set; }
            public string close_yesterday { get; set; }
            public string market_cap { get; set; }
            public string volume { get; set; }
            public string volume_avg { get; set; }
            public string shares { get; set; }
            public string stock_exchange_long { get; set; }
            public string stock_exchange_short { get; set; }
            public string timezone { get; set; }
            public string timezone_name { get; set; }
            public string gmt_offset { get; set; }
            public string last_trade_time { get; set; }
        }
    }
}