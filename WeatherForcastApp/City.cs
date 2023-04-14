using Newtonsoft.Json;
using System.Configuration;
using System.Reflection;
using System.Text;
using WeatherForcastApp.Entity;

namespace WeatherForcastApp
{
    internal class City
    {
        public string CityName { get; set; }

        /// <summary>
        /// Load All the City from Citydb.json file
        /// </summary>
        /// <returns></returns>
        public List<Entity.City>? getAllCity()
        {
            try
            {
                string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"citydb.json");
                if (!File.Exists(path))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("City DB File is unavailable.");

                    Console.ForegroundColor = ConsoleColor.White;
                    return new List<Entity.City>();
                }
                string cityJson = File.ReadAllText(path);

                string accentedStr;
                byte[] tempBytes;
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                tempBytes = Encoding.GetEncoding("ISO-8859-8").GetBytes(cityJson);
                string asciiStr = Encoding.UTF8.GetString(tempBytes);

                var listCity = JsonConvert.DeserializeObject<List<Entity.City>>(asciiStr);
                return listCity;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            return new List<Entity.City>();

        }
        /// <summary>
        /// Get the specific CIty Details
        /// </summary>
        /// <returns></returns>
        public Entity.City getCityDetails()
        {
            try
            {
                List<Entity.City> cities = getAllCity();
                Entity.City? city = cities.Where(a => a.city.ToUpper() == this.CityName).FirstOrDefault();
                return city;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }

            return new Entity.City();
        }
        /// <summary>
        /// Get Weather of the Specific City 
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        public async Task<Weather> getAPIDetails(Entity.City city)
        {
            try
            {
                string baseurl = ConfigurationManager.AppSettings["baseurl"];
                string url = string.Format(baseurl + "/v1/forecast?latitude={0}&longitude={1}&current_weather=true", city.lat, city.lng);

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(url);

                var result = await HttpHelper.GetAsync<Weather>(url);

                return result;

            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }

            return new Weather();
        }
    }
}
