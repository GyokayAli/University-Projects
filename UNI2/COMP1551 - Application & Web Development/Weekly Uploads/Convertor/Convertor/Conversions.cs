using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Convertor
{
    class Conversions
    {
        // Method that calculates the conversion from Fahrenheit to Celsius
        public static double ConvertFahranheitToCelsius(double aNumber)
        {
            double result = (5.0 / 9.0) * (aNumber - 32);
            return Math.Round(result, 2);
        }
        // Method that calculates the conversion from Celsius to Fahrenheit
        public static double ConvertCelsiusToFahranheit(double aNumber)
        {
            double result = (9.0 / 5.0) * (aNumber + 32);
            return Math.Round(result, 2);
        }
    }
}
