using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace Stock.Helpers
{
    public class HttpHelper
    {
        public static HttpClient GetHttpClient()
        {
            var MyHttpClient = new HttpClient();
            return MyHttpClient;
        }
    }
}