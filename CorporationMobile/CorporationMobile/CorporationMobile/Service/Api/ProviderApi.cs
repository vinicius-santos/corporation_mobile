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
    public class ProviderApi : BaseApi
    {

        public ProviderApi()
        {
            base.ConfigureHttpCLient();
        }

        public async Task<List<Provider>> GetAll()
        {
            List<Provider> result = null;
            try
            {
                var uri = new Uri(string.Concat(Constants.API_URL, "providers"));
                var response = await MyHttpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var res = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<List<Provider>>(res);
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


        public async Task<bool> Save(Provider provider)
        {
            try
            {
                var uri = new Uri(string.Concat(Constants.API_URL, $"provider/save"));
                var json = JsonConvert.SerializeObject(provider, Formatting.None);
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


        public async Task<bool> Update(int id, Provider provider)
        {
            try
            {
                var uri = new Uri(string.Concat(Constants.API_URL, $"provider/put/{id}"));
                var json = JsonConvert.SerializeObject(provider, Formatting.None);
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
                var uri = new Uri(string.Concat(Constants.API_URL, $"provider/delete/{id}"));
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
