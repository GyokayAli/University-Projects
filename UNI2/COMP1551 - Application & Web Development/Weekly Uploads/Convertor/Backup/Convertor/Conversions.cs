using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Convertor
{
    class Conversions
    {
        public static double ConvertFahranheitToCelsius(double aNumber)
        {
            double result = (5.0 / 9.0) * (aNumber - 32);
            return Math.Round(result, 2);
        }
        public static double ConvertCelsiusToFahranheit(double aNumber)
        {
            double result = (9.0 / 5.0) * (aNumber + 32);
            return Math.Round(result, 2);
        }
    }
}
