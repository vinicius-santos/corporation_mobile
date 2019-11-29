using CorporationMobile.Helpers;
using CorporationMobile.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CorporationMobile.Service.Api
{
    public class CorporationApi : BaseApi
    {

        public CorporationApi()
        {
            base.ConfigureHttpCLient();
        }

        public async Task<List<Corporation>> GetAll()
        {
            List<Corporation> result = null;
            try
            {
                var uri = new Uri(string.Concat(Constants.API_URL, "corporations"));
                var response = await MyHttpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var res = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<List<Corporation>>(res);
                    return result;
                }
                return result;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
                return result;
            }
        }


        public async Task<bool> Save(Corporation corporation)
        {
            try
            {
                var uri = new Uri(string.Concat(Constants.API_URL, $"corporation/save"));
                var json = JsonConvert.SerializeObject(corporation, Formatting.None);
                using (var content = new StringContent(json, Encoding.UTF8, "application/json"))
                {
                    var response = await MyHttpClient.PostAsync(uri, content);
                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
                return false;
            }
        }


        public async Task<bool> Update(int id, Corporation corporation)
        {
            try
            {
                var uri = new Uri(string.Concat(Constants.API_URL, $"corporation/put/{id}"));
                var json = JsonConvert.SerializeObject(corporation, Formatting.None);
                using (var content = new StringContent(json, Encoding.UTF8, "application/json"))
                {
                    var response = await MyHttpClient.PutAsync(uri, content);
                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
                return false;
            }
        }


        public async Task<bool> Delete(int id)
        {
            try
            {
                var uri = new Uri(string.Concat(Constants.API_URL, $"corporation/delete/{id}"));
                var response = await MyHttpClient.DeleteAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
                return false;
            }
        }
    }
}
