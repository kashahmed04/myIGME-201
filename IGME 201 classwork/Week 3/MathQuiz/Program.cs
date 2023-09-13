using System.IO;
using System;


// Class: Program
// Author: David Schuh
// Purpose: A simple MathQuiz application that is limited to +, - and *
// Restrictions: None
static class Program
{
    // Method: Main()
    // Purpose: Play a math quiz.
    // Restrictions: If the username = "David" and he chose "easy", override with "hard"
    static void Main()
    {
        // store user name
        string myName = "";

        // string and int of # of questions
        string sQuestions = ""; //this part is used when converting the string answer into a number answer**
        int nQuestions = 0;

        // string and base value related to difficulty
        string sDifficulty = ""; //takes in which difficulty we need and the nMaxRange basically does**
        int nMaxRange = 0;

        // constant for setting difficulty with 1 variable**
        const int MAX_BASE = 10;

        // question and # correct questions answered counters**
        int nCntr = 0; 
        int nCorrect = 0;

        // operator picker**
        int nOp = 0;

        // operands and solution
        int val1 = 0; //when we implement division, use doubles for the anawer at least (also operands??)** (make sure one of our operands is a double
                      // by doing (double) or 1.0 to make sure its a double**
        int val2 = 0;
        int nAnswer = 0;

        // string and int for the response**
        string sResponse = "";
        Int32 nResponse = 0;// why need both because it only prints a string to the console**

        // play again?
        string sAgain = "";

        // valid state
        bool bValid = false;

        //what do these do**
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;

        // seed the random number generator
        Random rand = new Random(); //Random is an object and the ran object lets us create random numbers and we use.next to pick the next number**

        Console.WriteLine("Math Quiz!");
        Console.WriteLine(); //do we do a blank here for the \n basically to skip a line,
                             //why dont we do just \n within the first writeline

        // fetch the user's name into myName
        while (true)
        {
            Console.Write("What is your name-> ");
            myName = Console.ReadLine();

            if(myName.Length > 0) 
            {
                break;
            }
        }

    // label to return to if they want to play again
    start: //do we usually set these "points" for the goto by any name and what are the capitalization rules for it**
           //allow us to jump around our code with the goto statments (this is where we want to go back to if they want to play the game again so we use this in
           //in a goto statemtn**

        // initialize correct responses for each time around** (for each time we start a new quiz)**
        nCorrect = 0;

        Console.WriteLine(); //why do we have another blank one here**

        // ask how many questions until they enter a valid number
        do
        {
            Console.Write("How many questions-> ");
            sQuestions = Console.ReadLine();
            //bValid = int.TryParse(sQuestions, out nQuestions);
        } while (!int.TryParse(sQuestions, out nQuestions)); //sets nQuestions equal to the value of sQuestions we get and that will
        //set equal only if the int.TryParse works**
        //} while ( !bValid );

        Console.WriteLine();

        // ask difficulty level until they enter a valid response
        do
        {
            Console.Write("Difficulty level (easy, medium, hard)-> ");
            sDifficulty = Console.ReadLine();
            sDifficulty = sDifficulty.ToLower().Trim(); //trim does the white space on the ends only right**
        } while ( sDifficulty != "easy" && //we do and here and not or because if we did an or and we typed in "hard" for example,
                                            //then it would check the or condition for not being equal to easy and would automatically go back to the loop
                                            //becaues something or something, if one of them is true it defaults to true. (what about if we have 3 items)**
                sDifficulty != "medium" &&
                sDifficulty != "hard"
                );

        Console.WriteLine(); //why is there another one here**

        // if they choose easy, then set nMaxRange = MAX_BASE, unless myName == "David", then set difficulty to hard**
        // if they choose medium, set nMaxRange = MAX_BASE * 2**
        // if they choose hard, set nMaxRange = MAX_BASE * 3**
        switch (sDifficulty )//go over this****
        {
            case "easy":
                nMaxRange = MAX_BASE;

                if( myName.ToLower() == "david")
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
        for (nCntr = 0; nCntr < nQuestions; ++nCntr )
        {
            // generate a random number between 0 inclusive and 3 exclusive to get the operation**
            nOp = rand.Next(0, 3); //it will go from 0-2 the 3 is exclusive for random (last number exclusive for ranom)**

            val1 = rand.Next(0, nMaxRange) + nMaxRange; //**
            val2 = rand.Next(0, nMaxRange);//**

            // if either argument is 0, pick new numbers
            if( val1 == 0 || val2 == 0)
            {
                --nCntr; //we do -- here so it does not take away one question when the question has not event started**
                //so we basically subtract 1 then have it add 1 automatically when it goes back up to the top of the loop
                //to be on the current number we had before**
                continue;
            }


            // if nOp == 0, then addition
            if( nOp == 0)
            {
                nAnswer = val1 + val2;
                sQuestions = $"Question #{nCntr + 1}: {val1} + {val2} ==> "; //go over****** (do we want to add one to nCntr because 
                //then it increases the question by one because it was already asked**
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

            bValid = false; //display it as false here because in the above loop we made it to true so reset it here**

            // display the question and prompt for the answer until they enter a valid number
            do
            {
                Console.WriteLine(sQuestions);
                sResponse = Console.ReadLine();

                try
                {
                    nResponse = int.Parse(sResponse);
                    bValid = true; //set it to true when it tries to parse, but when the catch executes, thats when its set
                    //back to false to go back through the loop to ask for accurate info.**
                }
                catch
                {
                    Console.WriteLine("Please enter an integer");
                    bValid= false;
                }
            } while (!bValid );

            // if response == answer, output flashy reward and increment # correct
            if (nResponse == nAnswer)
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Well done, {0}!!", myName);
                ++nCorrect; //add to the correct number count**
            }
            // else output stark answer
            else
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("I'm sorry {0}, the answer is {1}", myName, nAnswer);
            }

            // restore the screen colors otherwise the text and background would stay that way**
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine(); //why is it here again**
        }

        Console.WriteLine();//**

        // output how many they got correct and their score**

        Console.WriteLine();//**

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