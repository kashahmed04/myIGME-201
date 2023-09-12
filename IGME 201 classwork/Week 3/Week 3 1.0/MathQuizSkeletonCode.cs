using System.IO;
using System;

class Program
{
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

        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;

        // seed the random number generator
        Random rand = new Random();

        Console.WriteLine("Math Quiz!");
        Console.WriteLine();

        // fetch the user's name into myName
        while( true )
        {
            Console.Write("What is your name-> ");
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
        } while( );

        Console.WriteLine();

        // ask difficulty level until they enter a valid response
        do
        {
            Console.Write("Difficulty level (easy, medium, hard)-> ");
        } while(  );

        Console.WriteLine();

        // if they choose easy, then set nMaxRange = MAX_BASE, unless myName == "David", then set difficulty to hard
        // if they choose medium, set nMaxRange = MAX_BASE * 2
        // if they choose hard, set nMaxRange = MAX_BASE * 3
        switch ( )
        {
        }

        // ask each question
        for( )
        {
            // generate a random number between 0 inclusive and 3 exclusive to get the operation
            nOp = rand.Next( 0, 3 );

            val1 = rand.Next( 0, nMaxRange ) + nMaxRange;
            val2 = rand.Next( 0, nMaxRange );
            
            // if either argument is 0, pick new numbers

            // if nOp == 0, then addition
            // if nOp == 1, then subtraction
            // else multiplication
 
            // display the question and prompt for the answer until they enter a valid number
            do
            {
            } while( );

            // if response == answer, output flashy reward and increment # correct
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