using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForcastApp
{
    using Newtonsoft.Json;
    using System;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using System.Configuration;
    using System.Net;

    namespace WebApp
    {
        public static class HttpHelper
        {
          
            public static async Task<T> GetAsync<T>(string uri)
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);

                using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                   
                    string resultContentString = await reader.ReadToEndAsync();
                    T resultContent = JsonConvert.DeserializeObject<T>(resultContentString);
                    return resultContent;
                }
            }

        }
    }
}
