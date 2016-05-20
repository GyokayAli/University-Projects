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
        // Declaration
        double tempC;
        double tempF;
        DateTime myDate;

        // Temperature constructor with 3 params
        public Temperature(double temperature, bool CtoF, DateTime myDate)
        {
            if (CtoF == true)
            {
                tempC = temperature;

            }
            else
            {
                tempF = temperature;
            }

            Convert(CtoF);

            this.myDate = myDate;
            count++; //increment by 1
        }

        // Temperature constractor with 2 params
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
            count++; //increment by 1
        }

        /* Method that checks which radio button is pressed CtoF/FtoC
         * Does conversion using the 2 methods in Conversions class */
        private void Convert(bool CtoF) {
            if (CtoF == true) {
                tempF = Conversions.ConvertCelsiusToFahranheit(tempC);
                     }
            else
            {
                tempC = Conversions.ConvertFahranheitToCelsius(tempF);
            }        
        }
        //Output data to log
        public string getOutputString() {
            return myDate.ToShortDateString() + " C: " + tempC + " F: " + tempF; 
        }
    }
}
