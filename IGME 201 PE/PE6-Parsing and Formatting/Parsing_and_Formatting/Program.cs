using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Parsing_and_Formatting
{
    static internal class Program
    {
        static void Main(string[] args)
        {   
            Random rand = new Random(); //is this how we use random(1)
            //basically create a random variable to store random
            //then use the data type, usually an int. but could be a double
            //and set it equal to uor random variable.next to get random values
            //between a certain range (in this case 0-100 (last number is exclusive)
            int randomNumber = rand.Next(0, 101);
            int? randomConvertedNum = null;

            Console.WriteLine(randomNumber); //is this what it means for step 2 (2)

            //Console.WriteLine("Guess a random number between 0 and 100");
            //string ran_num_str = Console.ReadLine();
            for (int i = 0; i < 7; i++) //fixed loop control var. now it does 8 values instead of 9
            {
                Start: //basicaly we start back in the while so we can use goto on this(3)
                //are we allowed to use start and goto in this code? (4)
                //is the for loop unecessary because I don't really go back to it because I go back to the Start with goto if the number was
                //greather than 100 or less than 0, or if their guess was too high. So could I just take out the for loop and just initialize i as an int.
                //and increment then just end the loop with my conditional I have down below(5)
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

                    if (randomConvertedNum > 100 || randomConvertedNum < 0)
                    {
                        Console.WriteLine("The number is rather too high or too low, try again!");
                        randomConvertedNum = null;
                        goto Start;
                    }
                }

                if (i == 8)
                {
                    Console.WriteLine("No more gueses! The answer was " + randomNumber);
                    break;
                }

                if (randomConvertedNum == randomNumber)
                {
                    i++; //increment for all 3 based on their guesses or should I not incremement if they are correct as well(6)
                    //is my console statements ok or does it look too cluttered?(7)
                    //are my console statements ok if they are a bit different from the documentation because I tried to make them more specific
                    //than the ones wirrten in the documentation(8)
                    Console.WriteLine("The answer is correct!");
                    Console.WriteLine("You guessed the number in " + i + " turns!");
                    break;
                }
                else if (randomConvertedNum > randomNumber)
                {
                    i++;
                    Console.WriteLine("The answer was too high! Guess again!");
                    randomConvertedNum = null;
                    goto Start;
                }
                else if (randomConvertedNum < randomNumber)
                {
                    i++;
                    Console.WriteLine("The answer was too low! Guess again!");
                    randomConvertedNum = null;
                    goto Start;
                }


            }



        }
    }
}
