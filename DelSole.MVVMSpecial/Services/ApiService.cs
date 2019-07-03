﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DelSole.MVVMSpecial.Services
{
    public class ApiService
    {
        public virtual async Task<HttpResponseMessage> GetAsync<T>(T data, string url, string id = null, bool forcePost = false)
        {
            HttpResponseMessage response;
            using (var client = new HttpClient())
            {
               if (id != null) url = $"{url}/{id}";
               if(forcePost == true)
               {
                   var json = JsonConvert.SerializeObject(data, Formatting.None);
                   var content = new StringContent(json, Encoding.UTF8, "application/json");
                   response = await client.PostAsync(url, content);
               }
               else
                   response = await client.GetAsync(url);
            }

            return response;
        }
        public virtual async Task<HttpResponseMessage> WriteAsync<T>(T data, string url, string id = null)
        {

            HttpResponseMessage response;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                string json = JsonConvert.SerializeObject(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                if (id != null) url = $"{url}/{id}";

                response = await client.PostAsync(url, content);
            }
            return response;
        }

        public virtual async Task<HttpResponseMessage> EditAsync<T>(T data, string url, string id = null)
        {

            HttpResponseMessage response;
            using (var client = new HttpClient())
            {
                string json = JsonConvert.SerializeObject(data, Formatting.None);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                if (id != null) url = $"{url}/{id}";
                response = await client.PutAsync(url, content);

            }

            return response;
        }

        public virtual async Task<HttpResponseMessage> DeleteAsync<T>(T data, string url, string id = null)
        {

            HttpResponseMessage response;
            using (var client = new HttpClient())
            {
                string json = JsonConvert.SerializeObject(data, Formatting.None);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                if (id != null) url = $"{url}/{id}";
                response = await client.DeleteAsync(url);
            }

            return response;
        }

    }
}
