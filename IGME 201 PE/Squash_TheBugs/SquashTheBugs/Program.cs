using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquashTheBugs
{
    // Class Program
    // Author: David Schuh
    // Purpose: Bug squashing exercise
    // Restrictions: None
    class Program
    {
        // Method: Main
        // Purpose: Loop through the numbers 1 through 10 
        //          Output N/(N-1) for all 10 numbers
        //          and list all numbers processed
        // Restrictions: None
        static void Main(string[] args)
        {
            // declare int counter
            //int i = 0
            //Bug #1: Syntax error: There is no semicolon after the statement.
            int i = 0;

            // loop through the numbers 1 through 10
            //for (i = 1; i < 10; ++i)
            //Bug #2: Logic error: Code runs but does not go from 1-10, only
            //goes from 1-9
            string allNumbers = null;
            for (i = 1; i < 11; ++i) //last number usually does not count so it goes up to 10 rather than 11
                {
                // declare string to hold all numbers
                //string allNumbers = null;
                //Bug #3 Compile time error: The scope of this var. should be initialized outside the loop
                //so that allNumbers could be accessed when we have to print to the console. (scope is compile time error)

                // output explanation of calculation
                //Console.Write(i + "/" + i - 1 + " = ");
                //Bug #4: Compile time error: Trying to add a number and string
                //together so we have to do the math first then add it
                //to the string. 
                Console.Write(i + "/" + (i - 1) + " = ");

                // output the calculation based on the numbers
                //Console.WriteLine(i / (i - 1));
                //Bug #5: Run time error: Attempted to divide by 0 during the first loop.
                if (i == 1)
                {
                    Console.WriteLine("Can't divide by 0");
                }
                else 
                {
                    Console.WriteLine(i / (i - 1));
                }

                // concatenate each number to allNumbers
                allNumbers += i + " ";

                // increment the counter
                //i = i + 1;
                //Bug #6: Logic error: The code runs but not as intended
                //because we increment twice in one loop when we only have to
                //do it once which it does in the for loop statement 

            }

            // output all numbers which have been processed
            Console.WriteLine("These numbers have been processed: " + allNumbers);
            //Bug #7: Syntax error: Did not write the + to add allNumbers to the sentence as a string 
        }
    }
}




