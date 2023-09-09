﻿using System;
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
        //          the console.(Tried to do error checking
        //          but try catch was not working?)
        // Restrictions: None
        static void Main(string[] args)
        {
            int? first_conversion = null;
            int? second_conversion = null;
            int? third_conversion = null;
            int? fourth_conversion = null;
            
            
            Console.WriteLine("Please enter the first number: ");
            string first_str = Console.ReadLine();
            
            while (first_conversion == null)
            {
                try
                {
                    first_conversion = Convert.ToInt32(first_str);
                }
            
                catch
                {
                    Console.WriteLine("Please enter an integer.");
                    first_str = Console.ReadLine();
                }
            }
            
            Console.WriteLine("Please enter the second number: ");
            string second_str = Console.ReadLine();
            
            while (second_conversion == null)
            {
                try
                {
                    second_conversion = Convert.ToInt32(second_str);
                }
            
                catch
                {
                    Console.WriteLine("Please enter an integer.");
                    second_str = Console.ReadLine();
                }
            }
            
            Console.WriteLine("Please enter the third number: ");
            string third_str = Console.ReadLine();
            
            while (third_conversion == null)
            {
                try
                {
                    third_conversion = Convert.ToInt32(third_str);
                }
            
                catch
                {
                    Console.WriteLine("Please enter an integer.");
                    third_str = Console.ReadLine();
                }
            }
            
            Console.WriteLine("Please enter the fourth number: ");
            string fourth_str = Console.ReadLine();
            
            
            while (fourth_conversion == null)
            {
                try
                {
                    fourth_conversion = Convert.ToInt32(fourth_str);
                }
            
                catch
                {
                    Console.WriteLine("Please enter an integer.");
                    fourth_str = Console.ReadLine();
                }
            }
            
            int product = (int)(first_conversion * second_conversion * third_conversion * fourth_conversion);
            //why do we have to put it around () itself and not the whole product to make it an int**
            
            Console.WriteLine("The product of all the numbers is: " + product);


            //Console.WriteLine("Please enter a number with a decimal precision of 2.");
            //string input = Console.ReadLine();
            //double decimal_Val = double.Parse(input);
            //double added_Val = decimal_Val + 55;
            //Console.WriteLine("Result of ", input, " added to 55 is ", added_Val);



        }
    }
}
