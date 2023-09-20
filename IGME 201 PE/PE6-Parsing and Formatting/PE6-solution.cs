/* Grading rubric
 * Missing class comment header: -5
 * Missing method comment header: -5
 * Missing "static" before class: -5
 * Incorrect rand.Next() statement: -5
 * Missing clear instructions for the user (8 tries, 0-100): -5
 * Incorrect logic that does not limit to 8 guesses: -5
 * Incorrect logic that does not retry invalid guesses: -5
 * Run-time error if non-numeric string is entered: -5
 * Missing telling the user the random number if they run out of guesses: -5
 */

using System;

namespace PE6
{
    // Class Program
    // Author: David Schuh 
    // Purpose: Parsing and Formatting
    // Restrictions: None
    static class Program
    {
        // Method: Main
        // Purpose: A number guessing game
        // Restrictions: None
        static void Main(string[] args)
        {
            string stringNumber;
            Random rand = new Random();

            // generates a random number between 0 inclusive and 101 exclusive.
            int randomNumber = rand.Next(0, 101);

            // prints the random number.
            Console.WriteLine(randomNumber);

            int i;

            Console.WriteLine("You have 8 tries to guess a number 0-100.");

            for (i = 0; i < 8; ++i)
            {
                Console.Write($"Guess #{i+1}: ");

                stringNumber = Console.ReadLine();

                int numberGuessed;
                
                // if not valid integer input
                if (int.TryParse(stringNumber, out numberGuessed) == false)
                {
                    // don't count this guess
                    --i;

                    continue;
                }

                // if not valid range
                if (numberGuessed < 0 || numberGuessed > 100)
                {
                    // don't count this guess
                    --i;

                    continue;
                }

                // if too low
                if (numberGuessed < randomNumber)
                {
                    // tells user if their guess was correct (high or low).
                    Console.WriteLine("Your guess is too low!");
                }
                // if too high
                else if (numberGuessed > randomNumber)
                {
                    Console.WriteLine("Your guess is too high!");
                }
                else
                {
                    Console.WriteLine($"Correct! It took you {i + 1} tries!");

                    // leave the for() loop
                    break;
                }
            }

            // if i == 8, then the user ran out of tries
            if (i == 8)
            {
                Console.WriteLine("I'm sorry. You ran out of guesses. The correct number was: " + randomNumber);
            }
        }
    }
}