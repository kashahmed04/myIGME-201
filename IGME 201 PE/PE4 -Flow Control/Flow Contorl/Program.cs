using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flow_Control
{
    // Class Program
    // Author: Kahsaf Ahmed
    // Purpose: Getting numbers from the user
    //and displaying them to the console based on 
    //if one of the numbers were less than 10.
    // Restrictions: None
    internal class Program
    {
        // Method: Main
        // Purpose: Ask the user to enter 2 numbers and
        //use while loops to check if what they entered were even numbers
        //and if they werent we keep asking, but if they enter a number,
        //then we exit the loop. After, I check if both the numbers we had gotten
        //were greater than 10, then we loop to make sure we get at least 
        //1 number being less than 10 as well as looping to see if they user even enters a 
        //number in the first place. After those loops, we tell the user what their numbers
        //were because they may have forgotten their numbers after all of this takes place.
        // Restrictions: None
        static void Main(string[] args)
        {
            int? firstNumber = null; 
            int? secondNumber = null;

            Console.WriteLine("Please enter a number: ");
            string firstNumberStr = Console.ReadLine();

            while (firstNumber == null)
            {
                try
                {
                    firstNumber = Convert.ToInt32(firstNumberStr);
                }
                catch
                {
                    Console.WriteLine("That is not a number enter again: ");
                    firstNumberStr = Console.ReadLine();

                }
            }

            Console.WriteLine("Please enter a second number: ");
            string secondNumberStr = Console.ReadLine();

            while (secondNumber == null)
            {
                try
                {
                    secondNumber = Convert.ToInt32(secondNumberStr);
                }
                catch
                {
                    Console.WriteLine("That is not a number enter again: ");
                    secondNumberStr = Console.ReadLine();

                }
            }

            while(firstNumber > 10 && secondNumber > 10)
            {
                Console.WriteLine("Please enter another first number: ");
                firstNumberStr = Console.ReadLine();
                firstNumber = null;
                while (firstNumber == null)
                {
                    try
                    {
                        firstNumber = Convert.ToInt32(firstNumberStr);
                    }
                    catch
                    {
                        Console.WriteLine("That is not a number enter again: ");
                        firstNumberStr = Console.ReadLine();
            
                    }
                }
            
                Console.WriteLine("Please enter another second number: ");
                secondNumberStr = Console.ReadLine();
                secondNumber = null;
                while (secondNumber == null)
                {
                    try
                    {
                        secondNumber = Convert.ToInt32(secondNumberStr);
                    }
                    catch
                    {
                        Console.WriteLine("That is not a number enter again: ");
                        secondNumberStr = Console.ReadLine();
            
                    }
                }
            
            }
            Console.WriteLine("The numbers are: " + firstNumber + " and " + secondNumber);



        }





    }
}