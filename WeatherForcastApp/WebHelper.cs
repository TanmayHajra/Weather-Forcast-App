
using Newtonsoft.Json;
using System.Net;

namespace WeatherForcastApp
{
    public static class HttpHelper
    {
        /// <summary>
        /// Get API Call
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="uri"></param>
        /// <returns></returns>
        public static async Task<T> GetAsync<T>(string uri)
        {
            try
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
            catch (Exception ex) { Console.Error.WriteLine(ex.Message); }

            return default(T);
        }

    }
}

