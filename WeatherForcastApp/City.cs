using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace WeatherForcastApp
{
    internal class City
    {

        public List<Entity.City>? getAllCity()
        {

            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"citydb.json");
            string cityJson = File.ReadAllText(path);

            string accentedStr;
            byte[] tempBytes;
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            tempBytes = System.Text.Encoding.GetEncoding("ISO-8859-8").GetBytes(cityJson);
            string asciiStr = System.Text.Encoding.UTF8.GetString(tempBytes);

            var listCity = JsonConvert.DeserializeObject<List<Entity.City>>(asciiStr);
            return listCity;

        }

        public Entity.City getCityDetails(string cityName)
        {

            List<Entity.City> cities = getAllCity();
            Entity.City? city = cities.Where(a=>a.city==cityName).FirstOrDefault();
            return city;
        }
    }
}
