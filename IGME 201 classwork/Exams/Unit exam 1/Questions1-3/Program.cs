using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace Questions1_3
{
    // Class: Program
    // Author: Kashaf Ahmed
    // Purpose: Ask the user to pick a question and time them (5 sec) to put in their answer based on the question
    // Restrictions: None
    static internal class Program
    {

        static Timer timeOutTimer; //set up the timer and the timer being a false variable saying that the timer did not run out
        static bool bTimeOut = false;
        static string realAnswer = ""; //can we define this out here as static or is it not needed****(1)***************8

        // Method: Main()
        // Purpose: Ask the user to pick a question between 1-3, then time them for 5 sec to put in their answer and if they get it correct in the right amount of
        //time, then we ask if they want to play again, otherwise we say they were wrong or the time is up if they did not answer it in time and tell them the
        //correct answer. There are comments below at certain steps
        // Restrictions:None
        static void Main(string[] args)
        {
            string answerQuestion = ""; //declare variables for the question #, their answers for the specific question,their answer for if they want to play again,
                                        //their converted answer to an int. to check for which questions they want, and a bool. for the loop conditions
            string answer1 = "";
            string answer2 = "";
            string answer3 = "";
            string playAgain = "";
            int readAnswer = 0;
            bool bValid = false;

            timeOutTimer = new Timer(5000); //set up the timer and method that gets called if the timer runs out
            timeOutTimer.Elapsed += new ElapsedEventHandler(TimesUp);

        start:;
            Console.WriteLine(); //ask the user for the question
            Console.Write("Choose your question (1-3): ");
            answerQuestion = Console.ReadLine();

            while(!bValid) //loop through and see if they enter and int. and a number between 1-3
            {
                try
                {
                    readAnswer = Convert.ToInt32(answerQuestion);
                    bValid = true;
                    if(readAnswer > 3 || readAnswer == 0)
                    {
                        Console.Write("Choose your question (1-3): ");
                        answerQuestion = Console.ReadLine();
                        bValid = false;
                        continue;
                    }
                }
                catch
                {
                    Console.Write("Choose your question (1-3): ");
                    answerQuestion = Console.ReadLine();
                    bValid = false;
                }
            }

            if(readAnswer == 1) //if they input the first question, time them and get their answer and output based on what they put in 
            {
                realAnswer = "black";
                Console.WriteLine("You have 5 seconds to answer the following question: ");
                Console.WriteLine("What is your favorite color?");
                timeOutTimer.Start();
                bTimeOut = false;
                answer1 = Console.ReadLine();
                timeOutTimer.Stop();
                if(answer1 != "black" && bTimeOut == false)
                {
                    Console.WriteLine("Wrong! The answer is: black");
                }
                else if(answer1 == "black")
                {
                    Console.WriteLine("Well done!");
                }
            }
            else if(readAnswer == 2) //if they input the second question, time them and get their answer and output based on what they put in 
            {
                realAnswer = "42";
                Console.WriteLine("You have 5 seconds to answer the following question: ");
                Console.WriteLine("What is the answer to life, the universe and everything?");
                timeOutTimer.Start();
                bTimeOut = false;
                answer2 = Console.ReadLine();
                timeOutTimer.Stop();
                if(answer2 != "42" && bTimeOut == false)
                {
                    Console.WriteLine("Wrong! The answer is: 42");
                }
                else if (answer2 == "42")
                {
                    Console.WriteLine("Well done!");
                }
            }

            else if (readAnswer == 3) ////if they input the third question, time them and get their answer and output based on what they put in 
            {
                realAnswer = "What do you mean? African or European swallow?";
                Console.WriteLine("You have 5 seconds to answer the following question: ");
                Console.WriteLine("What is the airspeed velocity of an unladen swallow?");
                timeOutTimer.Start();
                bTimeOut = false;
                answer3 = Console.ReadLine();
                timeOutTimer.Stop();
                if (answer3 != "What do you mean? African or European swallow?" && bTimeOut == false)
                {
                    Console.WriteLine("Wrong! The answer is: What do you mean? African or European swallow?");
                }
                else if (answer3 == "What do you mean? African or European swallow?")
                {
                    Console.WriteLine("Well done!");
                }
            }
            
            
            
            bValid = false; //loop to check if they want to play again and reset the timer as
                            //well as their questions number and bool. for loop conditions
            while (!bValid)
            {
                Console.Write("Play again? ");
                playAgain = Console.ReadLine();
                if(playAgain.ToLower() == "y")
                {
                    bTimeOut = false;
                    readAnswer = 0;
                    bValid = false;
                    goto start;

                }
                else if(playAgain.ToLower() == "n") 
                {
                    bTimeOut = false;
                    readAnswer = 0;
                    bValid = false;
                    goto end;
                }
                else
                {
                    bValid = false;
                }
            }
            end:;

        }


        static void TimesUp(object sender, ElapsedEventArgs e) //method that runs if the timer is up
        {
            // send a newline to the console to interrupt the user entry
            Console.WriteLine();

            // let the user know their time is up
            Console.WriteLine("Times up!");

            //tell them the answer
            Console.WriteLine("The answer is: " + realAnswer);

            // ask them to press enter to get out of the Console.ReadLine() 
            Console.WriteLine("Please press Enter.");

            // set the time out flag 
            bTimeOut = true;

            // stop the timer, otherwise it will start over
            timeOutTimer.Stop();
        }
    }
}
