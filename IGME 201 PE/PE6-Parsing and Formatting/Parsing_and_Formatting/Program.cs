using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Parsing_and_Formatting
{

    // Class Program
    // Author: Kashaf Ahmed
    // Purpose: Tell the user to guess what the random
    //number is, in 8 tries and if they don't get it
    //we tell them what the number is.
    // Restrictions: None
    static internal class Program
    {
        // Method: Main
        // Purpose: Generate a random (0-100 inclusive) number then make a loop to go through the 8 times
        //representing the guesses the user has to get the number. Within the loop I create a
        //"Start:" represents that if they guessed wrong, then we go back to the start of the
        //first while loop and increment a guess for that. But, we go back to the starting while loop without incrementing if 
        //the number they guessed was above or below the bounds for 0-100. While the user guesses, we make sure if they even
        //entered a number to begin with and if not, we keep looping through to get the number, but it does not take up a turn.
        //same concept for if they guessed a number above 100, or below 0, but instead we go back to the first while loop.
        //After, we get a number that is valid we check if their guesses have exceeded 8 and tell them what the number was. 
        //After that conditional, if the user gets the answer right, we incrememnt for 1 turn, we tell them they got it correct and the number of turns they
        //took and exit out of the loop. If not, we increment a turn and tell them if they were too high or too low, then convert the variable equal to the
        //number back to null then go back to the start so the loop can execute for the next turn.
        // Restrictions: None
        static void Main(string[] args)
        {   
            Random rand = new Random(); //is this how we use random(yes)
            //basically create a random variable to store random
            //then use the data type, usually an int. but could be a double
            //and set it equal to uor random variable.next to get random values
            //between a certain range (in this case 0-100 (last number is exclusive)
            int randomNumber = rand.Next(0, 101);
            int? randomConvertedNum = null;

            Console.WriteLine(randomNumber);

            for (int i = 0; i < 7; i++) //fixed loop control var. now it does 8 values instead of 9 because its 0 based
            {
                Start: //basicaly we start back in the while so we can use goto on this(yes)
                //are we allowed to use start and goto in this code? (yes)
                //is the for loop unecessary because I don't really go back to it because I go back to the Start with goto if the number was
                //greather than 100 or less than 0, or if their guess was too high. So could I just take out the for loop and just initialize i as an int.
                //and increment then just end the loop with my conditional I have down below(yes), but i would be 1-8 and we would have else if statements
                //so it knows to stop after a certain condition and not check all conditions
                Console.WriteLine("Guess a random number between 0 and 100");
                string ran_num_str = Console.ReadLine();
                while (randomConvertedNum == null)
                {
                    try
                    {
                        randomConvertedNum = Convert.ToInt32(ran_num_str);
                    }

                    catch
                    {
                        Console.WriteLine("Please enter a number");
                        ran_num_str = Console.ReadLine();

                    }

                }

                if (randomConvertedNum > 100 || randomConvertedNum < 0)
                {
                    Console.WriteLine("The number is rather too high or too low, try again!");
                    randomConvertedNum = null;
                    goto Start;
                }

                if (i == 7)
                {
                    Console.WriteLine("No more gueses! The answer was " + randomNumber);
                    break; 
                    //conditional is not necessary but if we would not have it we would go from 1-8 instead and make the statements below, else if statements
                    //and dont need break because we are not in a loop anymore and we need else if not if statements sep. so that only one of them
                    //would run and not the rest of them would run because of the else
                }

                i++; 
                //increment regardless becaues even if our number was not in bounds, then it would
                //just go back to start and not come here (only comes here when number is valid)
                if (randomConvertedNum == randomNumber)
                {
                    //increment for all 3 based on their guesses or should I not incremement if they are correct as well(yes)
                    //is my console statements ok or does it look too cluttered?(yes)
                    //are my console statements ok if they are a bit different from the documentation because I tried to make them more specific
                    //than the ones wirrten in the documentation(yes)
                    //i++;
                    Console.WriteLine("The answer is correct!");
                    Console.WriteLine("You guessed the number in " + i + " turns!");
                    break;
                }
                else if (randomConvertedNum > randomNumber)
                {
                    //i++;
                    Console.WriteLine("The answer was too high! Guess again!");
                    randomConvertedNum = null;
                    goto Start;
                }
                else if (randomConvertedNum < randomNumber)
                {
                    //i++;
                    Console.WriteLine("The answer was too low! Guess again!");
                    randomConvertedNum = null;
                    goto Start;
                }


            }



        }
    }
}
