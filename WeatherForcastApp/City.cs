using Newtonsoft.Json;
using System.Reflection;
using System.Text;
using WeatherForcastApp.Entity;
using WeatherForcastApp.WebApp;

namespace WeatherForcastApp
{
    internal class City
    {
        public string CityName { get; set; }
        

        public  List<Entity.City>? getAllCity()
        {

            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"citydb.json");
            string cityJson = File.ReadAllText(path);

            string accentedStr;
            byte[] tempBytes;
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            tempBytes = Encoding.GetEncoding("ISO-8859-8").GetBytes(cityJson);
            string asciiStr = Encoding.UTF8.GetString(tempBytes);

            var listCity =  JsonConvert.DeserializeObject<List<Entity.City>>(asciiStr);
            return listCity;

        }

        public  Entity.City getCityDetails()
        {

            List<Entity.City> cities = getAllCity();
            Entity.City? city = cities.Where(a => a.city.ToUpper() == this.CityName).FirstOrDefault();
            return city;
        }

        public async Task<Weather> getAPIDetails(Entity.City city)
        {
            string baseurl = "https://api.open-meteo.com";
            string url = string.Format(baseurl+"/v1/forecast?latitude={0}&longitude={1}&current_weather=true", city.lat, city.lng);

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);

            var result = await HttpHelper.GetAsync<Weather>(url);

            return result;

        }
    }
}
