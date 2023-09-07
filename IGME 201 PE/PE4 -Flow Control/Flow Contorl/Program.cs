using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flow_Control
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int? firstNumber  = null; //tryParse does not accept a variable that has a ? defined to have null
            int? secondNumber = null; //should we know all 3 methods of conversion
            //Is there a way to simplifiy this code?

            Console.WriteLine("Please enter a number: ");
            string firstNumberStr = Console.ReadLine();

            while(firstNumber == null)
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

            while (firstNumber > 10)
            {
                Console.WriteLine("Second number is greater than 10 try again: ");
                firstNumberStr = Console.ReadLine();
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


            
            while (secondNumber > 10)
            {
                Console.WriteLine("Second number is greater than 10 try again: ");
                secondNumberStr = Console.ReadLine();
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

            Console.WriteLine("The numbers are: " + firstNumber + " and " + secondNumber);


            }





        }
    }

