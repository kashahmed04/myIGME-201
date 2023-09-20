using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers; //set the timer in a using statement**


//what cases are delgates enums and structs and classes like timers are they all pascal as well as what we define inside of them**
/// delegate steps
/// 1. define the delegate method data type based on the method signature
///         delegate double MathFunction(double n1, double n2);
/// 2. declare the delegate method variable
///         MathFunction processDivMult;
/// 3. point the variable to the method that it should call
///         processDivMult = new MathFunction(Multiply);
/// 4. call the delegate method / add the delegate method to the object's event handler** go over this step
///         nAnswer = processDivMult(n1, n2); in this case nasnwer was already set to an int., but how could it hold a method that returns a double (is it because an int is**
///                                             //smaller than a double to it could be implicitly casted, but not the other way around because a**
///                                             double 64 bits cant be imlcitly converted to**
///                                             //32 bits an int.**
///         timer.Elapsed += TimesUp; //go over**

namespace MemoryGame
{
    static internal class Program
    {
        // class-level variables that are available to every method in the class
        static Timer timeOutTimer; //do we declare classes here as well as methods** (declare timer to be called timeouttimer)**
        static bool bTimeOut = false; //we need to bool. here because**
        //why static here and how do we know when to use staic because with enums and structs we did not, but what about delegates**

        static void Main(string[] args)
        {

        start:

            string displayString = "";
            Random rand = new Random();
            Console.Clear(); //why do we clear the console if nothing shows up**

            while (!bTimeOut)
            {
                // add a random letter to the current display string
                displayString += (char)('A' + rand.Next(0, 26));
                //we pick a random letter from 0-26 but the 26 is excluside so its 25 valuues, and based on that number we make it a character from A-Z**
                //how does it know to do letters and why did we put A +**
                //also how to know when to use ' ' .vs. " "**

                // iterate through the string to output each character
                foreach (char c in displayString)
                {
                    Console.Write(c);

                    // 0.5 second delay between outputting each character
                    System.Threading.Thread.Sleep(500); //how does this work**
                }

                Console.Clear(); //we clear the console once each character is entered then we start the timer for**

                timeOutTimer = new Timer(displayString.Length * 500 + 1000); //how does timers work here and in general**

                // Timer calls the Timer.Elapsed event handler when the time elapses**
                // The Timer.Elapsed event handler uses a delegate function with the following signature:
                //        public delegate void ElapsedEventHandler(object sender, ElapsedEventArgs e);
                //        //what does the para. mean in this case**
                           //and do we have to define public or not because**
                           //in our previous example with delegates we did not have it**
                           // what is the scope without public for delegates, enums, structs, and** 
                           //in general with other classes like the timer**
                // This delegate method type is already defined for us by .NET
                timeOutTimer.Elapsed += new ElapsedEventHandler(TimesUp);

                // start the timer just before the user is prompted for the answer
                // the timer process will be a second process running at the same time as this program**
                // it will countdown from the value initialized in line #48 and call the delegate method(s)**
                // associated with the Elapsed event handler as set in line #59**
                timeOutTimer.Start();

                string sAnswer = null;
                sAnswer = Console.ReadLine();

                // always stop the timer directly after the Console.ReadLine()
                // otherwise the timer will keep running even if the user entered the correct answer in time
                // and the TimesUp() method will be called**
                timeOutTimer.Stop();

                // if the correct character sequence was entered and the timer did not expire** (go over)**
                if (sAnswer.ToUpper() == displayString && !bTimeOut /* same as bTimeOut == false */ )
                {
                    Console.WriteLine("Well Done!  Your current score is {0}", displayString.Length);
                }
                else
                {
                    // otherwise they entered the wrong answer or the timer expired
                    Console.WriteLine("Bad luck.  :(  The correct code was {0}.  Your final score is: {1}", displayString, displayString.Length - 1);
                    //we do the length minus 1 because its 0 based and we need to represent the letters starting from 1**

                    // set timeout to leave the while() loop
                    bTimeOut = true;
                }
            }

            Console.Write("Press Enter to Play Again");
            Console.ReadLine();

            bTimeOut = false;
            goto start;

        }

        static void TimesUp(object sender, ElapsedEventArgs e) //what does this mean**
            //how does it go to this method first, then goes back to the if stattement above to show our score**
            //if the scoare it 0 and we do length-1 how is that not an error because we are doing 0-1 and that would be -1 and we cant have negative lengths**
        {
            // send a newline to the console to interrupt the user entry
            Console.WriteLine();

            // let the user know their time is up
            Console.WriteLine("Your time is up!");

            // ask them to press enter to get out of the Console.ReadLine() at line #68
            Console.WriteLine("Please press Enter.");

            // set the time out flag 
            bTimeOut = true;

            // stop the timer, otherwise it will start over
            timeOutTimer.Stop();
        }
    }
}
