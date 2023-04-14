namespace WeatherForcastApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please input the City Name");
            string cityName = Console.ReadLine();

            City cityObj = new City();

           var cityDetails= cityObj.getCityDetails(cityName);

            Console.WriteLine(cityDetails);
        }

      
    }


}