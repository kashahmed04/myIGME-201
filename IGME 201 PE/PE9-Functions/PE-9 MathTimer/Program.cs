using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace PE_9_MathTimer
{
    // Class: Program
    // Author: David Schuh
    // Purpose: A simple MathQuiz application that is limited to +, - and *
    // Restrictions: None
    static class Program
    {
        static Timer timeOutTimer;
        static bool bTimeOut = false; //we classes and methods here but why this
        //vairbale? could we do that within the main**? if bTimeOut is false then does that mean that the time has run out
        //or that the time has not run out*****(1)

        // Method: Main()
        // Purpose: Play a math quiz.
        // Restrictions: If the username = "David" and he chose "easy", override with "hard"
        static void Main()
        {
            // store user name
            string myName = "";

            // string and int of # of questions
            string sQuestions = "";
            int nQuestions = 0;

            // string and base value related to difficulty
            string sDifficulty = "";
            int nMaxRange = 0;

            // constant for setting difficulty with 1 variable
            const int MAX_BASE = 10;

            // question and # correct counters
            int nCntr = 0;
            int nCorrect = 0;

            // operator picker
            int nOp = 0;

            // operands and solution
            int val1 = 0;
            int val2 = 0;
            int nAnswer = 0;

            // string and int for the response
            string sResponse = "";
            Int32 nResponse = 0;

            // play again?
            string sAgain = "";

            // valid state
            bool bValid = false;

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            // seed the random number generator
            Random rand = new Random();

            Console.WriteLine("Math Quiz!");
            Console.WriteLine();

            // fetch the user's name into myName
            while (true)
            {
                Console.Write("What is your name-> ");
                myName = Console.ReadLine();

                if (myName.Length > 0)
                {
                    break;
                }
            }

            timeOutTimer = new Timer(5000);
            timeOutTimer.Elapsed += new ElapsedEventHandler(TimesUp);
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
                //bValid = int.TryParse(sQuestions, out nQuestions);
            } while (!int.TryParse(sQuestions, out nQuestions));
            //} while ( !bValid );

            Console.WriteLine();

            // ask difficulty level until they enter a valid response
            do
            {
                Console.Write("Difficulty level (easy, medium, hard)-> ");
                sDifficulty = Console.ReadLine();
                sDifficulty = sDifficulty.ToLower().Trim();
            } while (sDifficulty != "easy" &&
                    sDifficulty != "medium" &&
                    sDifficulty != "hard"
                    );

            Console.WriteLine();

            // if they choose easy, then set nMaxRange = MAX_BASE, unless myName == "David", then set difficulty to hard
            // if they choose medium, set nMaxRange = MAX_BASE * 2
            // if they choose hard, set nMaxRange = MAX_BASE * 3
            switch (sDifficulty)
            {
                case "easy":
                    nMaxRange = MAX_BASE;

                    if (myName.ToLower() == "david")
                    {
                        goto case "hard";
                    }
                    break;

                case "medium":
                case "med":
                    nMaxRange = MAX_BASE * 2;
                    break;

                case "hard":
                    nMaxRange = MAX_BASE * 3;
                    break;
            }

            // ask each question
            for (nCntr = 1; nCntr <= nQuestions; ++nCntr) //why do I have to change it to
                //0 now when it started at 1 before********(2)
            {
                // generate a random number between 0 inclusive and 3 exclusive to get the operation
                nOp = rand.Next(0, 3);

                val1 = rand.Next(0, nMaxRange) + nMaxRange;
                val2 = rand.Next(0, nMaxRange);

                // if either argument is 0, pick new numbers
                if (val1 == 0 || val2 == 0)
                {
                    --nCntr;
                    continue;
                }


                switch (nOp)
                {
                    case 0:
                        nAnswer = val1 + val2;
                        sQuestions = $"Question #{nCntr + 1}: {val1 + " (this first value is really hard)"} + {val2} ==> {val1 + val2} ";
                        sQuestions = "Question #" + (nCntr + 1) + ": " + val1 + " + " + val2 + " ==> " + (val1 + val2) + " ";
                        break;
                    case 1:
                        nAnswer = val1 - val2;
                        sQuestions = $"Question #{nCntr + 1}: {val1} - {val2} ==> ";
                        break;
                    case 2:
                        nAnswer = val1 * val2;
                        sQuestions = $"Question #{nCntr + 1}: {val1} * {val2} ==> ";
                        break;
                }

                // if nOp == 0, then addition
                if (nOp == 0)
                {
                    nAnswer = val1 + val2;
                    sQuestions = $"Question #{nCntr + 1}: {val1} + {val2} ==> ";
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

                bValid = false;

                // display the question and prompt for the answer until they enter a valid number
                do
                {
                    Console.WriteLine(sQuestions);
                    timeOutTimer.Start();
                    sResponse = Console.ReadLine();
                    timeOutTimer.Stop();

                    // can use either TryParse
                    bValid = int.TryParse(sResponse, out nResponse);

                    if (!bValid)
                    {
                        Console.WriteLine("Please enter an integer");
                    }


                    // or try/catch with Parse() or Convert.ToInt32()
                    try
                    {
                        nResponse = int.Parse(sResponse);
                        nResponse = Convert.ToInt32(sResponse);
                        bValid = true;
                    }
                    catch
                    {
                        Console.WriteLine("Please enter an integer");
                        bValid = false;
                    }
                } while (!bValid);

                // if response == answer, output flashy reward and increment # correct
                if (nResponse == nAnswer && !bTimeOut)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Well done, {0}!!", myName);
                    ++nCorrect;
                }
                // else output stark answer
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("I'm sorry {0}, the answer is {1}", myName, nAnswer);

                    bTimeOut = true;
                }

                // restore the screen colors
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine();
            }

            Console.WriteLine();

            // output how many they got correct and their score
            Console.WriteLine($"You got {nCorrect} out of {nQuestions} correct!  That is a score of {100 * (double)nCorrect / nQuestions}%");


            Console.WriteLine();

            do
            {
                // prompt if they want to play again
                Console.Write("Do you want to play again? ");

                sAgain = Console.ReadLine();

                // if they type y or yes then play again
                // else if they type n or no then leave this loop
                if (sAgain.ToLower().Trim().StartsWith("y"))
                {
                    bTimeOut = false;
                    goto start;
                }
                else
                {
                    break;
                }
            } while (true);
        }
        static void TimesUp(object sender, ElapsedEventArgs e) 
        {
            // send a newline to the console to interrupt the user entry
            Console.WriteLine();

            // let the user know their time is up
            Console.WriteLine("Your time is up!");

            // ask them to press enter to get out of the Console.ReadLine() 
            Console.WriteLine("Please press Enter.");

            // set the time out flag 
            bTimeOut = true;

            // stop the timer, otherwise it will start over
            timeOutTimer.Stop();
        }
    }

}
