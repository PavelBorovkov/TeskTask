﻿using DataApiService.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace DataApiService
{
    public interface IDataManager
    {
        Task<T> GetItems<T>(string pointName, Dictionary<string, string> getParams = null);
        Task PostRequest<T>(string pointName, T Parameters);
        Task<T> PutRequest<T>(string pointName, T Parameters);
        Task<string> DeleteRequest<T>(string pointName, Dictionary<string, string> Parameters);
    }

    public class BaseApiOptions
    {
        public string BaseUrl { get; set; }
        public string GetUrlApiService(string controllerName)
        {
            return $"{BaseUrl}/{controllerName}";
        }



    }
    
    public class DataManager : IDataManager
    {
        private BaseApiOptions _options;
        private WebClient _client;

        public DataManager(BaseApiOptions options)
        {
            _options = options;

            _client = new WebClient();
            _client.Headers.Add(HttpRequestHeader.Accept, "application/json");
        }

        
        public async Task<T> GetItems<T>(string pointName, Dictionary<string, string> getParams = null)
        {
            try
            {
                string urlService = _options.GetUrlApiService(pointName);
                var paramString = getParams.ToGetParameters();

                var url = new Uri($"{urlService}{paramString}");

                var responseData = await _client.DownloadDataTaskAsync(url);
                var jsonStr = System.Text.Encoding.UTF8.GetString(responseData);
                var result = JsonConvert.DeserializeObject<T>(jsonStr);
                return result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task PostRequest<T>(string pointName, T Parameters)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string urlService = _options.GetUrlApiService(pointName);
                    string paramString = JsonConvert.SerializeObject(Parameters);

                    var content = new StringContent(paramString, Encoding.UTF8, "application/json-patch+json");

                    var response = await client.PostAsync(urlService, content);
                    
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public async Task<string> DeleteRequest<T>(string pointName, Dictionary<string, string> Parameters)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string urlService = _options.GetUrlApiService(pointName);
                    var paramString = Parameters.ToGetParameters(); ;

                    var url = new Uri($"{urlService}{paramString}");

                    var response = await client.DeleteAsync(url);
                    string responseContent = await response.Content.ReadAsStringAsync();
                    return responseContent;
                }
                catch (Exception)
                {

                    throw;
                }
            }

        }

        public async Task<T> PutRequest<T>(string pointName, T Parameters)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string urlService = _options.GetUrlApiService(pointName);
                    string paramString = JsonConvert.SerializeObject(Parameters);

                    var content = new StringContent(paramString, Encoding.UTF8, "application/json-patch+json");

                    var response = await client.PutAsync(urlService, content);
                    string responseContent = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<T>(responseContent);
                    return result;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
