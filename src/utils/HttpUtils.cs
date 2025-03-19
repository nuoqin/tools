using Newtonsoft.Json;
using nuoqin.src.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Documents;

namespace nuoqin.src.utils
{
    public class HttpUtils
    {

        public static string encode(string url)
        {
            return HttpUtility.UrlEncode(url);
        }


        public static string decode(string url)
        {
            return HttpUtility.UrlDecode(url);
        }

        public static async Task<string> Get(CutstomHttpEntity entity)
        {
            HttpClient httpCliet = buildHttpClient(entity);
            var response = await httpCliet.GetAsync(entity.Url);
            return await response.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="headers"></param>
        /// <returns></returns>
        private static HttpClient buildHttpClient(CutstomHttpEntity entity)
        {
            var url=entity.Url;
            var flag = url.IndexOf("?") != -1;
            var httpCliet = new HttpClient();
            var headers=entity.Headers;
            if (headers != null)
            {
                foreach (var item in headers)
                {
                    foreach (KeyValuePair<string, string> kvp in item)
                    {
                        httpCliet.DefaultRequestHeaders.Add(kvp.Key, kvp.Value);
                    }
                }
            }
            var Params = entity.Param;
            var tmp = 0;
            if (Params != null) {
                foreach (var item in Params)
                {
                    foreach (KeyValuePair<string, object> kvp in item)
                    {
                        if (!flag && tmp == 0)
                        {
                            url += "?" + kvp.Key + "=" + kvp.Value;
                            tmp = 1;
                        }
                        else
                        {
                            url += "&" + kvp.Key + "=" + kvp.Value;
                        }
                    }
                }
                entity.Url=url;
            }
            return httpCliet;
        }

        public static async Task<string> PostJson(CutstomHttpEntity entity)
        {
            HttpClient httpCliet = buildHttpClient(entity);
            var response = await httpCliet.PostAsync(entity.Url, new StringContent(
                    entity.Body,
                    Encoding.UTF8,
                    "application/json"));
            return await response.Content.ReadAsStringAsync();
        }

        public static async Task<string> PostForm(CutstomHttpEntity entity)
        {
            HttpClient httpCliet = buildHttpClient(entity);
            var formBody = buildForrmUrlEncodedConetnt(entity);
            var response = await httpCliet.PostAsync(entity.Url, formBody);
            return await response.Content.ReadAsStringAsync();
        }

        private static FormUrlEncodedContent buildForrmUrlEncodedConetnt(CutstomHttpEntity entity)
        {
            var Bodys = entity.Body;
            List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
            if (Bodys == null)
            {
                return new FormUrlEncodedContent(list);
            }
            var dict=JsonConvert.DeserializeObject<KeyValuePair<string, string>>(Bodys);
            list.Add(dict);
            return new FormUrlEncodedContent(list); ;
        }

        public static async Task<string> PutAsync(CutstomHttpEntity entity)
        {
            HttpClient httpCliet = buildHttpClient(entity);
            var response = await httpCliet.PutAsync(entity.Url, new StringContent(
                   JsonConvert.SerializeObject(entity.Body),
                   Encoding.UTF8,
                   "application/json"));
            return await response.Content.ReadAsStringAsync();

        }

        public static async Task<string> DeleteAsync(CutstomHttpEntity entity)
        {
            HttpClient httpCliet = buildHttpClient(entity);
            var response = await httpCliet.DeleteAsync(entity.Url);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
