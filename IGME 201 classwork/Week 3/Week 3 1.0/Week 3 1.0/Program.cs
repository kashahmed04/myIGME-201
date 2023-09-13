using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// ADD THE CORRECT COMMENT HEADER
/// </summary>
static class Program
{
    /// <summary>
    /// ADD THE CORRECT COMMENT HEADER
    /// </summary>
    static void Main() //only one main method per application and its normally in the first
                       //course file when we create the project
    {
        // store user name
        string myName = "";

        // string and int of # of questions
        string sQuestions = "";
        int nQuestions = 0;  //int. version of that variable to store the parsed version that the user eneters

        // string and base value related to difficulty*
        string sDifficulty = "";
        int nMaxRange = 0;

        // constant for setting difficulty with 1 variable**
        const int MAX_BASE = 10;

        // question and # correct counters**
        int nCntr = 0;
        int nCorrect = 0;

        // operator picker**
        int nOp = 0;

        // operands and solution
        int val1 = 0; 
        int val2 = 0;
        int nAnswer = 0;

        // string and int for the response
        string sResponse = ""; //string and numeric values for the response**
        Int32 nResponse = 0;

        // play again?
        string sAgain = "";

        //valid state (define our variables at the top of our methods and comment what they are for and we shoukd akso initializaize)
        bool bValid = false;

        Console.BackgroundColor = ConsoleColor.Black;//**
        Console.ForegroundColor = ConsoleColor.White;

        // seed the random number generator
        Random rand = new Random(); 

        Console.WriteLine("Math Quiz!");
        Console.WriteLine();

        // fetch the user's name into myName
        while (true) //stay in the loop until they have entered something for their name**
        {
            Console.Write("What is your name-> ");
            myName = Console.ReadLine();

            if (myName.Length > 0)
            {
                break;

            }
        }

    // label to return to if they want to play again
    start: 
           

        // initialize correct responses for each time around
        nCorrect = 0;

        Console.WriteLine();

        // ask how many questions until they enter a valid number
        do
        {
            Console.Write("How many questions-> ");
            sQuestions = Console.ReadLine();
            //bValid = int.TryParse(sQuestions, out nQuestions); //parse the amount of questions they want to use to an integer**
            //use errror checking otherwise program would crsh if they did not enter a number**
        } while (!int.TryParse(sQuestions, out nQuestions)); //could use this but the below while loop and the bValid line would work together the same**
        //} while (!bValid);

        Console.WriteLine();

        // ask difficulty level until they enter a valid response
        do
        {
            Console.Write("Difficulty level (easy, medium, hard)-> ");
            sDifficulty = Console.ReadLine();
            //lowercase it and cut off the whitepsace from both ends**
            sDifficulty = sDifficulty.ToLower().Trim(); //returns the sDiffuculty in all lowercase and the whitepsace from both ends (does not change
            //2Sdifficulty, just returns a new string)**
        } while ( sDifficulty != "easy" && sDifficulty != "medium" && sDifficulty != "hard" );

        Console.WriteLine();

        // if they choose easy, then set nMaxRange = MAX_BASE, unless myName == "David", then set difficulty to hard
        // if they choose medium, set nMaxRange = MAX_BASE * 2
        // if they choose hard, set nMaxRange = MAX_BASE * 3
        switch (sDifficulty)
        {
            case "easy":
                nMaxRange = MAX_BASE;
                if(myName.ToLower() == "david")
                {

                }
                break;
            case "medium": //multiple cases fall through then they will have the same output 
            case "med":
                nMaxRange = MAX_BASE * 2;
                break;
            case "hard":
                nMaxRange = MAX_BASE * 3;
                break;
            
        }

        // ask each question
        for (nCntr = 0; nCntr < nQuestions; ++nCntr )
        {
            // generate a random number between 0 inclusive and 3 exclusive to get the operation
            nOp = rand.Next(0, 3); //it will go from 0-2 the 3 is exclusive for random**

            val1 = rand.Next(0, nMaxRange) + nMaxRange;
            val2 = rand.Next(0, nMaxRange);

            // if either argument is 0, pick new numbers (if either of the random numbers chosen are 0, then we want to pick new random numbers)
            if(val1 == 0 || val2 == 0)
            {
                --nCntr;//**
                continue; //goes to operation part of for loop and incremement the counter and it would skip the number question we are on
                //so we have the decrement so when it goes back up to the loop it increments by 1 and we are abck to our currecnt questionII
            }

            // if nOp == 0, then addition
            if(nOp == 0)
            {
                nAnswer = val1 + val2;
                sQuestions = $"Question #{nCntr + 1}: {val1} + {val2} ==> "; //code blocks will be evaluated in the {}
            }


            // if nOp == 1, then subtraction
            else if (nOp == 1)
            {
                nAnswer = val1 - val2;
                sQuestions = $"Question #{nCntr + 1}: {val1} - {val2} ==> "; 
            }



            // else multiplication

            else
            {
                nAnswer = val1 * val2;
                sQuestions = $"Question #{nCntr + 1}: {val1} * {val2} ==> ";
            }


            bValid = false; //set it back to false because it will get set to true from our last loop we did asking abuot the number of questions**
            // display the question and prompt for the answer until they enter a valid number
            do
            {
                Console.WriteLine(sQuestions);
                sResponse = Console.ReadLine();

                try
                {
                    nResponse = int.Parse(sResponse);
                    bValid = true; 

                }
                catch
                {
                    Console.WriteLine("Please enter an integer");
                    bValid = false;

                }
            } while (!bValid);

            // if response == answer, output flashy reward and increment # correct
            if(nResponse == nAnswer)
            {
                Console.BackgroundColor
            }
            // else output stark answer

            // restore the screen colors
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine();
        }

        Console.WriteLine();

        // output how many they got correct and their score

        Console.WriteLine();

        do
        {
            // prompt if they want to play again
            Console.Write("Do you want to play again? ");

            sAgain = Console.ReadLine();

            // if they type y or yes then play again
            // else if they type n or no then leave this loop
        } while (true);
    }
}
    }
    }
}
