using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace CorporationMobile.Service.Api
{
    public class BaseApi
    {
        public static HttpClient MyHttpClient { get; internal set; }
        internal void ConfigureHttpCLient()
        {
            if (MyHttpClient == null)
            {
                HttpClientHandler hndlr = new HttpClientHandler();
                hndlr.Proxy = null;
                hndlr.UseProxy = false;
                MyHttpClient = new HttpClient(hndlr);
                MyHttpClient.MaxResponseContentBufferSize = 1000000 * 10;
                MyHttpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            }
        }
    }
}
