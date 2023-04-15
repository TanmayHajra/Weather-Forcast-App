namespace WeatherForcstTestProject
{
    using WeatherForcastApp;
    public class UnitTest1
    {
        [Fact]
        public async void PassingTest1()
        {
            var result = await getCityData("Kolkata");
            Assert.Equal(true, result);
        }



        [Fact]
        public async void failingTest1()
        {
            var result = await getCityData("Kolkata1233231sdfsd");
            Assert.Equal(false, result);

        }


        public async Task<bool> getCityData(string cityName)
        {

            WeatherForcast weatherForcast = new WeatherForcast();
            return await weatherForcast.GetWeatherFromMain(cityName);

        }
    }
}