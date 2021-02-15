using Newtonsoft.Json;
using ProjetoTree.Business.Interfaces;
using ProjetoTree.Business.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProjetoTree.Data.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : Entity
    {
        protected static string baseUrl = "https://swapi.dev/api";
        public static HttpClient _client;
        public string _endpoint { get; set; }
        protected Repository(string endpoint)
        {
            _endpoint = endpoint;

            _client = new HttpClient();
        }

        public HttpResponseMessage GetAsyncRequestSWAPI()
        {
            return _client.GetAsync(baseUrl + _endpoint).Result;
        }

        public List<T> GetAllData()
        {
            var response = GetAsyncRequestSWAPI();

            if (!response.IsSuccessStatusCode) return new List<T>();

            var group = JsonConvert.DeserializeObject<BaseGroups<T>>(response.Content.ReadAsStringAsync().Result);

            List<T> list = new List<T>();
            list.AddRange(group.results);

            if (!string.IsNullOrEmpty(group.next.ToString()))
            {
                list.AddRange(ReadPagination(group.next.ToString()));
            }

            return list;   
        }

        protected List<T> ReadPagination(string pagination)
        {
            List<T> list = new List<T>();
            //var grupos = JsonConvert.DeserializeObject<BaseGroups<T>>(pagination);

            //list.AddRange(grupos.results);
            string nextUrl = pagination;

            while (!string.IsNullOrEmpty(nextUrl))
            {
                var response = _client.GetAsync(nextUrl).Result;

                if (response.IsSuccessStatusCode)
                {
                    string jsonString = response.Content.ReadAsStringAsync().Result;
                    var result = JsonConvert.DeserializeObject<BaseGroups<T>>(jsonString);
                    if (result != null && result.results.Count > 0)
                    {
                        list.AddRange(result.results);
                        nextUrl = (result.next != null) ? result.next.ToString() : string.Empty;
                    }
                }
                else
                {
                    nextUrl = string.Empty;
                }
            }
            return list;
        }
    }
}



