using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
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
                MyHttpClient.Timeout = TimeSpan.FromSeconds(1000);
                MyHttpClient.MaxResponseContentBufferSize = 3000000 * 10;
                MyHttpClient.DefaultRequestHeaders.Accept.Clear();
                MyHttpClient.DefaultRequestHeaders.Add("Accept", "application/json");
                MyHttpClient.DefaultRequestHeaders.Add("Content-Type", "application/json");
            }
        }
    }
}
