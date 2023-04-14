using WeatherForcastApp.Entity;

namespace WeatherForcastApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
        beginining:
            Console.ForegroundColor = ConsoleColor.White;
            //Requested for the City Name
            Console.WriteLine("Please input the City Name :");
            string cityName = Console.ReadLine();
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

                    Console.WriteLine("Do you want to exit from the application. Press 0 for exit . Press 1 for new search");

                    var input = Console.ReadLine();
                    switch (input.ToString())
                    {
                        case "0": Environment.Exit(0); break;

                        default:
                            goto beginining;
                            break;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("City name is Invalid");

                    goto beginining;
                }

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter Valid City name");
                goto beginining;
            }


        }


    }


}