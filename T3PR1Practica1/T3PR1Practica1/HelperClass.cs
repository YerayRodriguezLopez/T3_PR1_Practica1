using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3PR1Practica1
{
    public static class HelperClass
    {
        public static double RequestValue(string message, string errorMessage, double minValue)
        {
            double value;
            bool validInput = false;

            do
            {
                Console.Write(message);
                if (double.TryParse(Console.ReadLine(), out value) && value > minValue)
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine(errorMessage);
                }
            } while (!validInput);

            return value;
        }
    }
}
