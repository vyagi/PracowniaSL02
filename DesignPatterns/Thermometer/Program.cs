using System;
using AdapterPattern;

namespace Thermometer
{
    class Program
    {
        static void Main(string[] args)
        {
            // var d = new Detector(new MercuryThermometer());
            //
            // Console.WriteLine(d.Detect());

            var d = new Detector(new InternetThermometerAdapter(new InternetThermometer()));

            Console.WriteLine(d.Detect());
        }
    }
}
