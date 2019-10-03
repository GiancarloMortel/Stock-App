using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Stock.Helpers;
using Stock_App.Models;

namespace Stock_App.Controllers
{
    public class HomeController : Controller
    {
        private StockRecord db = new StockRecord();
        static readonly HttpClient client = new HttpClient();

        [HttpGet]
        public ActionResult Index(string searchString = null)
        {
            var tickers = from t in db.symbols_
                          select t;

            if (!String.IsNullOrEmpty(searchString))
            {
                tickers = tickers.Where(t => t.Name.Contains(searchString));

                // check for no companies
                if (tickers.Count() == 0)
                {
                    return View("Not_Found");
                }

                return View(tickers);
            }
            // how default stock information
            else
            {
                // make request for data
                string viewResponse = "";
                var httpClient = HttpHelper.GetHttpClient();
                HttpResponseMessage response = httpClient.GetAsync("https://website/stock/AAPL").Result; // hidden for safety
                if (response.IsSuccessStatusCode)
                {
                    viewResponse = response.Content.ReadAsStringAsync().Result;
                }

                // convert to json
                StockInfo.Rootobject records = JsonConvert.DeserializeObject<StockInfo.Rootobject>(viewResponse);

                return View("Stock", records);
            }
        }

        public ActionResult Stock(string ticker)
        {
            // check for empty string
            if (String.IsNullOrEmpty(ticker))
            {
                return View("Not_Found");
            }

            // make request for data
            string viewResponse = "";
            var httpClient = HttpHelper.GetHttpClient();
            HttpResponseMessage response = httpClient.GetAsync("https://website/stock/" + ticker).Result; // hidden for safety
            if (response.IsSuccessStatusCode)
            {
                viewResponse = response.Content.ReadAsStringAsync().Result;
            }

            // convert to json
            StockInfo.Rootobject records = JsonConvert.DeserializeObject<StockInfo.Rootobject>(viewResponse);

            return View(records);
        }
    }
}
