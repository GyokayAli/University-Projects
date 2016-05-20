using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Convertor
{
    class Temperature
    {
        static int count;

        public static int Count
        {
            get { return Temperature.count; }
            set { Temperature.count = value; }
        }
        double tempC;
        double tempF;
        DateTime myDate;

        public Temperature(double t, bool CtoF)
        {
            if ( CtoF==true)
            {
                tempC = t; 
               
            }
            else
            {
                tempF = t;
            }

            Convert(CtoF);

            this.myDate = DateTime.Now;
            count++;
        }

        private void Convert(bool CtoF) {
            if (CtoF == true) {
                tempF = Conversions.ConvertCelsiusToFahranheit(tempC);
                     }
            else
            {
                tempC = Conversions.ConvertFahranheitToCelsius(tempF);
            }        
        }

        public string getOutputString() {
            return myDate.ToShortDateString() + " C: " + tempC + " F: " + tempF; 
        }
    }
}
