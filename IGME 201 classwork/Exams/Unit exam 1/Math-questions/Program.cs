using System.IO;
using System;

//Does spacing matter in programs as well as the ghilghitng of blue going to the next line****************

// Class: Program
// Author: Kashaf Ahmed
// Purpose: A simple MathQuiz application that is limited to +, -, *, and /
// Restrictions: None
static class Program
{
    // Method: Main()
    // Purpose: Play a math quiz with +,-,*, and /
    // I had added division by incremementing nOp by 1 more to account for division and added the comments where I had done
    //that within my code 
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
        double dAnswer = 0;

        // string and int for the response
        string sResponse = "";
        Int32 nResponse = 0;
        double qResponse = 0;

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
        for (nCntr = 0; nCntr < nQuestions; ++nCntr)
        {
            // generate a random number between 0 inclusive and 4 exclusive to get the operation
            nOp = rand.Next(0, 4); 

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
                    sQuestions = "Question #" + (nCntr + 1) + ": " + val1 + " + " + val2 + " ==> ";
                    break;
                case 1:
                    nAnswer = val1 - val2;
                    sQuestions = $"Question #{nCntr + 1}: {val1} - {val2} ==> ";
                    break;
                case 2:
                    nAnswer = val1 * val2;
                    sQuestions = $"Question #{nCntr + 1}: {val1} * {val2} ==> ";
                    break;
                case 3:
                    dAnswer = (double)val1/ val2;
                    dAnswer = Math.Round(dAnswer, 2);
                    sQuestions = $"Question #{nCntr + 1} (Please enter up to 2 decimal places): {val1} / {val2} ==> ";
                    break;
            }

            //// if nOp == 0, then addition
            //if (nOp == 0)
            //{
            //    nAnswer = val1 + val2;
            //    sQuestions = $"Question #{nCntr + 1}: {val1} + {val2} ==> ";
            //}
            //// if nOp == 1, then subtraction
            //else if (nOp == 1)
            //{
            //    nAnswer = val1 - val2;
            //    sQuestions = $"Question #{nCntr + 1}: {val1} - {val2} ==> ";
            //}
            //// else multiplication
            //else if(nOp == 2)
            //{
            //    nAnswer = val1 * val2;
            //    sQuestions = $"Question #{nCntr + 1}: {val1} * {val2} ==> ";
            //}
            //else if (nOp == 3)
            //{

            //    dAnswer = val1 / val2;
            //    dAnswer = Math.Round(dAnswer, 2);
            //    Console.WriteLine("Please enter the answer to the nearest 2 decimal places");
            //    sQuestions = $"Question #{nCntr + 1}: {val1} / {val2} ==> ";
            //}

            bValid = false;

            // display the question and prompt for the answer until they enter a valid number
            do
            {
                Console.WriteLine(sQuestions);
                sResponse = Console.ReadLine();


                //Implementing division:
                //Here, I check if division was done and if it was I try to convert to a double
                //and see if the response was correct or not, if it was, it gets printed to the console,
                //otherwise we tell them the correct answer and go onto the next question. If the parse cant be done
                //we ask them to enter another # that goes up to 2 decimal places. Same thing is done for +,-, and *, but 
                //it converts to an int instead.

                if(nOp == 3)
                {
                    try
                    {
                        qResponse = Convert.ToDouble(sResponse);
                        if (qResponse == dAnswer)
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("Well done, {0}!!", myName);
                            ++nCorrect;
                        }
                        else if (qResponse != dAnswer)
                        {

                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("I'm sorry {0}, the answer is {1}", myName, dAnswer);
                        }

                        bValid = true;
                    }
                    catch
                    {
                        Console.WriteLine("Please enter a number that goes up to 2 decimal places");
                        bValid = false;
                    }
                }
                else if (nOp == 0 || nOp == 1 || nOp == 2)
                {
                    try
                    {
                        nResponse = Convert.ToInt32(sResponse);
                        if (nResponse == nAnswer)
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("Well done, {0}!!", myName);
                            ++nCorrect;
                        }
                        else if (nResponse != nAnswer)
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("I'm sorry {0}, the answer is {1}", myName, nAnswer);
                        }
                        bValid = true;
                    }
                    catch
                    {
                        Console.WriteLine("Please enter an integer");
                        bValid = false;
                    }
                    
                }


            } while (!bValid);
            // if response == answer, output flashy reward and increment # correct
            //if (nResponse == nAnswer)
            //{
            //    Console.BackgroundColor = ConsoleColor.Blue;
            //    Console.ForegroundColor = ConsoleColor.Magenta;
            //    Console.WriteLine("Well done, {0}!!", myName);
            //    ++nCorrect;
            //}
            //else if (nResponse != nAnswer)
            //{
            //    Console.BackgroundColor = ConsoleColor.Black;
            //    Console.ForegroundColor = ConsoleColor.Red;
            //    Console.WriteLine("I'm sorry {0}, the answer is {1}", myName, nAnswer);
            //}
            //else if(qResponse == dAnswer)
            //{
            //    Console.BackgroundColor = ConsoleColor.Blue;
            //    Console.ForegroundColor = ConsoleColor.Magenta;
            //    Console.WriteLine("Well done, {0}!!", myName);
            //    ++nCorrect;
            //}
            //else if(qResponse != dAnswer)
            //{
            //
            //    Console.BackgroundColor = ConsoleColor.Black;
            //    Console.ForegroundColor = ConsoleColor.Red;
            //    Console.WriteLine("I'm sorry {0}, the answer is {1}", myName, dAnswer);
            //}

            // restore the screen colors
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine();
        }

        Console.WriteLine();
       
        //calculate their score 
        Console.WriteLine($"You got {nCorrect} of {nQuestions} correct. That is a score of {100 * (Math.Round((double)nCorrect / nQuestions,2))} %");
      

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
                goto start;
            }
            else
            {
                break;
            }
        } while (true);
    }
}