using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace UserInput
{
    // Class Program
    // Author: Kashaf Ahmed
    // Purpose: Getting 4 int. then
    //          multiplying them together
    //          and printing it to console.
    // Restrictions: None
    static internal class Program
    {
        // Method: Main
        // Purpose: Ask user for 4 numbers, convert
        //          them to integers, then multiply
        //          together and print it out into
        //          the console.
        // Restrictions: None
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the first number: ");
            string first_str = Console.ReadLine();

            Console.WriteLine("Please enter the second number: ");
            string second_str = Console.ReadLine();

            Console.WriteLine("Please enter the third number: ");
            string third_str = Console.ReadLine();

            Console.WriteLine("Please enter the fourth number: ");
            string fourth_str = Console.ReadLine();

            int first_int = Convert.ToInt32(first_str);
            int second_int = Convert.ToInt32(second_str);
            int third_int = Convert.ToInt32(third_str);
            int fourth_int = Convert.ToInt32(fourth_str);

            int product = (first_int * second_int * third_int * fourth_int); 

            Console.WriteLine("The product of all the numbers is: " + product); 





        }
    }
}
