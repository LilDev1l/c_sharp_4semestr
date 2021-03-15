using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorSize
{
    static class Calculator
    {
            public static double ConvertToEUR(double originalValue)
            {
                return Math.Round((originalValue + 2 * (600 / 90)) / (600 / 90) - 4, 2);
            }

            public static double ConvertToRUS(double originalValue)
            {
                return Math.Round((originalValue + 2 * (600 / 90)) / (600 / 90) - 5, 2);
            }

            public static double ConvertToUK(double originalValue)
            {
                return Math.Round(((originalValue + 2 * (762 / 90)) / (762 / 90)) - 25.5, 2);
            }

            public static double ConvertToUS(double originalValue)
            {
                return Math.Round(((originalValue + 2 * (762 / 90)) / (762 / 90)) - 25, 2);
            }
    }
}
