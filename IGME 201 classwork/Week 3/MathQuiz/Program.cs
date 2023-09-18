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
        string sQuestions = ""; //we can only get what they type as a string 
        //first read it into a string then parse it into an integer 
        int nQuestions = 0;

        // string and base value related to difficulty
        string sDifficulty = ""; //we can only get what they type as a string 
        //first read it into a string then parse it into an int
        int nMaxRange = 0;

        // constant for setting difficulty with 1 variable
        //for the easy questions it would just be between 1 and 10, then for medium it would be 20, thats why we
        //multiple by 2, same for hard but bigger, etc. (variable will not change so thats why we multiply
        //so val1 and val2 based on the switch statement, it chooses a random number based on the MAXBASE then we can do
        //the math the get the number, but if any of them are 0 we cant do the math so we go back but dont skip the current question
        const int MAX_BASE = 10; //put const variables in uppercase usually

        // question and # correct questions answered counters
        int nCntr = 0; 
        int nCorrect = 0;

        // operator picker
        int nOp = 0;

        // operands and solution
        int val1 = 0; //when we implement division, use doubles for the anawer at least (also operands??) (make sure one of our operands is a double
                      // by doing (double) or 1.0 to make sure its a double
        int val2 = 0;
        int nAnswer = 0;

        // string and int for the response
        string sResponse = "";
        Int32 nResponse = 0;// why need both because it only prints a string to the console(we need both so it can check if the answer put in was correct)
        //is intiailizating to int32 the same thing as doing int

        // play again?
        string sAgain = "";

        // valid state
        bool bValid = false;

        //set the background color of the text and the text color itself
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;

        // seed the random number generator
        Random rand = new Random(); //Random is an object and the rand object lets us create random numbers and we use.next to pick the next number 
        //even if varibales are class variables then its CamelCase

        Console.WriteLine("Math Quiz!");
        Console.WriteLine(); 

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
    start: //do we usually set these "points" for the goto by any name and what are the capitalization rules for it
           //allow us to jump around our code with the goto statments (this is where we want to go back to if they want to play the game again so we use this in
           //in a goto statemtn

        // initialize correct responses for each time around (for each time we start a new quiz)
        nCorrect = 0;

        Console.WriteLine(); //the writeline adds a bunch or space in between because we use .write in the case for the question statements 

        // ask how many questions until they enter a valid number
        do
        {
            Console.Write("How many questions-> ");
            sQuestions = Console.ReadLine();
            //bValid = int.TryParse(sQuestions, out nQuestions);
        } while (!int.TryParse(sQuestions, out nQuestions)); //sets nQuestions equal to the value of sQuestions converted we get and that will
        //set equal only if the int.TryParse works
        //} while ( !bValid );

        Console.WriteLine();

        // ask difficulty level until they enter a valid response
        do
        {
            Console.Write("Difficulty level (easy, medium, hard)-> ");
            sDifficulty = Console.ReadLine();
            sDifficulty = sDifficulty.ToLower().Trim(); //trim does the white space on the ends only 
                                                        //split returns an array of the things , seperated based the delimeter
                                                        //but if thats multiple spaces in a row (ex. more than 1 space then we get an extra entry for each
                                                        //space greater than 1
                                                        //could also just do replace with the number of spcaes and do , then do an alternative to set it equal to
                                                        //one sapce so the split wont store the empty space
        } while ( sDifficulty != "easy" && //we do and here and not or because if we did an or and we typed in "hard" for example,
                                            //then it would check the or condition for not being equal to easy and would automatically go back to the loop
                                            //becaues something or something, if one of them is true it defaults to true. (what about if we have 3 items)**
                sDifficulty != "medium" &&
                sDifficulty != "hard"
                );

        Console.WriteLine(); 

        // if they choose easy, then set nMaxRange = MAX_BASE, unless myName == "David", then set difficulty to hard
        // if they choose medium, set nMaxRange = MAX_BASE * 2 (both values used in the for loop)
        // if they choose hard, set nMaxRange = MAX_BASE * 3
        switch (sDifficulty) //in this case would we also lower here so our cases are constant with being lowercasee
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
            // generate a random number between 0 inclusive and 3 exclusive to get the operation
            nOp = rand.Next(0, 3); //it will go from 0-2 the 3 is exclusive for random (last number exclusive for ranom) and it returns the number for the operation
            //needing to be done 
            //double d = rand.NextDouble() returns a float number from 0-1 only, we dont put anything in it (and multiply by 10 to get a rnadom number between 0-10)

            val1 = rand.Next(0, nMaxRange) + nMaxRange; // choose the numbers based on the range given in the above statement
            val2 = rand.Next(0, nMaxRange);

            // if either argument is 0, pick new numbers
            if( val1 == 0 || val2 == 0)
            {
                --nCntr; //we do -- here so it does not take away one question when the question has not event started
                //so we basically subtract 1 then have it add 1 automatically when it goes back up to the top of the loop
                //to be on the current number we had before because we did not even start the question yet
                continue;
            }


            // if nOp == 0, then addition (determines which operation we need to do)
            if( nOp == 0)
            {
                nAnswer = val1 + val2;
                sQuestions = $"Question #{nCntr + 1}: {val1} + {val2} ==> "; // (do we want to add one to nCntr because 
                //then it increases the question by one because it is the current question we are on and it does not increment until we are done
                //with the loop and it also shows our val1 and val2 to the user to do the problem (we use string interpolation to basically do the math in
                //curly braces) for linear interpolation we dont have to do "+" and add strings together like we do in regular strings and we can do
                //things in one string the {} represent a code block (we do + 1 because it starts from 0 and we have to add 1 to be on the right question)
                //but if we just wanted to put the nCntr we could start from 1 but then do <= for the condition 
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

            bValid = false; //display it as false here because in the above loop we made it to true so reset it here

            // display the question and prompt for the answer until they enter a valid number
            do
            {
                Console.WriteLine(sQuestions);
                sResponse = Console.ReadLine();

                //or without the try and catch
                //bValid = int.TryParse(sResponse, out nResponse);
                //if(!bValid){
                //} console.writeline("please enter and int) //if its true it exits the loop other wise it prints this statement and checks the
                //while sttaement and basically runs this code again
                try
                {
                    nResponse = int.Parse(sResponse);
                    //nResponse = Convert.ToInt32(sResponse);
                    bValid = true; //set it to true when it tries to parse, but when the catch executes, thats when its set
                    //back to false to go back through the loop to ask for accurate info.
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
                Console.ForegroundColor = ConsoleColor.Magenta; //the background is the box behind the text (blue) and foregreound is the text color (magenta)
                Console.WriteLine("Well done, {0}!!", myName);
                ++nCorrect; //add to the correct number count because what they said was equal to the answer that was calculated
            }
            // else output stark answer
            else
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("I'm sorry {0}, the answer is {1}", myName, nAnswer);
            }

            // restore the screen colors otherwise the text and background would stay that way
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine(); //why is it here again(white space)
        }

        Console.WriteLine();

        // output how many they got correct and their score
        Console.WriteLine($"You got {nCorrect} of {nQuestions} correct. That is a score of {100*(Math.Round((double)nCorrect/nQuestions))} %");
        //get the percent by converting the nCorrect by the total questions then multiplying by 100 to get a percentage (could cast either of them as a double though
        //but if we did not make it a double then round cant round because its an int so it would not work because we need a percentage so we need a deciaml for the percentage
        //we could also multilply one of them numbers by 1.0 to get a double (but we should cast it as a double though)

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