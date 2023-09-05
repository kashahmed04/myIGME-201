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
            string first_Str = Console.ReadLine();

            Console.WriteLine("Please enter the second number: ");
            string second_Str = Console.ReadLine();

            Console.WriteLine("Please enter the third number: ");
            string third_Str = Console.ReadLine();

            Console.WriteLine("Please enter the fourth number: ");
            string fourth_Str = Console.ReadLine();

            int first_Int = Convert.ToInt32(first_Str);
            int second_Int = Convert.ToInt32(second_Str);
            int third_Int = Convert.ToInt32(third_Str);
            int fourth_Int = Convert.ToInt32(fourth_Str);

            int product = (first_Int * second_Int * third_Int * fourth_Int);

            Console.WriteLine("The product of all the numbers is: " + product); 





        }
    }
}
