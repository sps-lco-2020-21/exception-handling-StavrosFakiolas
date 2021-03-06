using Geometry.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsTest.App
{
    class Program
    {
        static void Main()
        {
            Program2.Test();
            
            string strUnable = "56F34";
            string strBig = "1.29e325";

            //value is not a number in a valid format.

            try
            {
                double result1 = Convert.ToDouble(strUnable);
            }
            catch (FormatException)
            {
                Console.WriteLine("Unable to convert '{0}' to a Double.", strUnable);
            }

            //value represents a number that is less than MinValue or greater than MaxValue.

            try
            {
                double result2 = Convert.ToDouble(strBig);
            }
            catch (OverflowException)
            {
                Console.WriteLine("'{0}' is outside the range of a Double.", strBig);
            }

            Console.ReadKey();


        }
    }
}

//string to double
//Exceptions:
//FormatException


//OverflowException
//value represents a number that is less than MinValue or greater than MaxValue.