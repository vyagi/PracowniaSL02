using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace AdapterPattern
{
    public class InternetThermometerAdapter : IThermometer
    {
        private readonly InternetThermometer _internetThermometer;

        public InternetThermometerAdapter(InternetThermometer internetThermometer) => _internetThermometer = internetThermometer;

        public double GetTemperature() => 
            double.Parse(_internetThermometer.Themperature.Replace(".",",")) - 273.15;
    }


    //3rd party library
    public class InternetThermometer
    {
        private static readonly HttpClient Client = new ();

        public InternetThermometer() => Client.BaseAddress = new Uri("http://api.openweathermap.org/");

        public string Themperature =>
            ((dynamic) JObject.Parse(Client.GetAsync("data/2.5/weather?q=Rzeszow&appid=b58fe45ce203b7a6893d3ea90a0974f8")
                .Result.Content.ReadAsStringAsync()
                .Result))["main"]["temp"];
    }
    
    public interface IThermometer
    {
        double GetTemperature();
    }

    public class MercuryThermometer : IThermometer
    {
        public static readonly Random Generator = new();

        public double GetTemperature() => Generator.NextDouble() * 100 - 50;
    }

    public class Detector
    {
        private readonly IThermometer _thermometer;

        public Detector(IThermometer thermometer)
        {
            _thermometer = thermometer;
        }

        public Decision Detect() =>
            _thermometer.GetTemperature() switch
            {
                < -5 => Decision.TooCold,
                > 25 => Decision.TooHot,
                _ => Decision.JustRight
            };
    }

    public enum Decision
    {
        TooCold,
        JustRight,
        TooHot
    }
}
