using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmed_HelloWorld
{
    // Class Internal class Program
    // Author: Kashaf Ahmed
    // Purpose: Testnig out random functions of C#
    // Restrictions: implicitNumber does not display 5.0 like it shoud
    // even though it's a double and the explicitNumber
    //does not work (not an int.)
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Kashaf");
            int firstNumber = 5;
            int secondNumber = 6;
            Console.WriteLine(firstNumber + secondNumber);
            //int explicitNumber = 1.2;
            //Console.WriteLine(explicitNumber); 
            double implicitNumber = 5;
            Console.WriteLine(implicitNumber);
            for(int i = 0; i < firstNumber; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
