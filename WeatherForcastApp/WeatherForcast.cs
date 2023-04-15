using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForcastApp.Entity;

namespace WeatherForcastApp
{
    public class WeatherForcast
    {
        public async Task<bool> GetWeatherFromMain(string cityName)
        {
        
            Console.ForegroundColor = ConsoleColor.White;
           
            if (!string.IsNullOrEmpty(cityName))
            {
                City cityObj = new City();
                cityObj.CityName = cityName.ToUpper();

                //Getting City Long and Latt Details
                Entity.City cityDetails = cityObj.getCityDetails();

                if (cityDetails != null)
                {

                    //Getting Weather Forcast
                    Weather result = await cityObj.getAPIDetails(cityDetails);

                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(string.Format("Weather Forcast For City {0} -", cityObj.CityName));
                    Console.WriteLine(string.Format("Temparature :{0}", result.current_weather.temperature));
                    Console.WriteLine(string.Format("Winddirection :{0}", result.current_weather.winddirection));
                    Console.WriteLine(string.Format("Windspeed :{0}", result.current_weather.windspeed));

                    Console.ForegroundColor = ConsoleColor.White;

                    return true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("City name is Invalid");
                    Console.ForegroundColor = ConsoleColor.White;
                    return false;

                }

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter Valid City name");
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }
        }

    }
}
