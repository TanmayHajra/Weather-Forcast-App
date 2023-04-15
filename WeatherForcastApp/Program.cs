using WeatherForcastApp.Entity;

namespace WeatherForcastApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //Requested for the City Name
            Console.WriteLine("Please input the City Name :");
            string cityName = Console.ReadLine();

            WeatherForcast weatherForcast = new WeatherForcast();
            await weatherForcast.GetWeatherFromMain(cityName);

            Console.WriteLine("Press any Key to Exit");

            var input = Console.ReadKey();
            switch (input.ToString())
            {
                case "0": Environment.Exit(0); break;

                default:
                    Environment.Exit(0);

                    break;
            }
        }
    }


}