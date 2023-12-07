using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

/// delegate steps
/// 1. define the delegate method data type based on the method signature
///         delegate double MyRounder(double n1, double n2);
/// 2. declare the delegate method variable
///         MyRounder processDivMult;
/// 3. point the variable to the method that it should call
///         processDivMult = new MyRounder(Multiply);
/// 4. call the delegate method
///         nAnswer = processDivMult(n1, n2);
///        

//can we do myRounder then the number for which delegate method it is**
//are these ok and what would be any other ways to write it**
//it only has to look different**
//we can use math.round when we need to right or would we use the method we created**

namespace Delegates
{
   public delegate double MyRounder(double d, int n);

    // Class: Program
    // Author: Kashaf Ahmed
    // Purpose: Use a delegate to use the Math.Round() method (Uses the specific delegate declarations.
    //lambda functions, action, func, and anon, functions. Rounds takes in a double and an int. and rounds
    //the double based on whatever int. we put for the specific delegate method and the OutputAnswer
    //if used for action because we can't have return statements so we do a Console.WriteLine() instead.
    // Restrictions: None
    static internal class Program
    {
        // Method: Rounds
        // Author: Kashaf Ahmed
        // Purpose: Rounds the double we put in to a certain number of decimal places (we put in the int. for that)
        // Restrictions: None
        static double Rounds(double d, int n)
        {
            return Math.Round(d, n);
        }

        // Method: OutPutAnswer
        // Author: Kashaf Ahmed
        // Purpose: Method for action so it prints out to the console the rounded value since it cant have a return statement
        // Restrictions: None
        static void OutputAnswer(double d, int n)
        {
            Console.WriteLine(Rounds(d, n));
        }


        // Method: Main()
        // Purpose: Use various techniques to use delegates. Comments are shown on specific lines
        // Restrictions: None
        static void Main(string[] args)
        {
            double nAnswer = 0;  //used to set the delegate calls equal to a variable to we can print
                                 //the output to the console
            double nAnswer2 = 0;

            //using defined delegate 
            MyRounder myRounder;
            myRounder = new MyRounder(Rounds);

            nAnswer = myRounder(2.534522, 4);

            //check answer
            Console.WriteLine(nAnswer);


            //using func delegate 
            Func<double, int, double> myRounder2;
            myRounder2 = new Func<double, int, double>(Rounds);
            nAnswer2 = myRounder2(2.534522, 4);

            //check answer
            Console.WriteLine(nAnswer2);

            //using action delegate 
            Action<double, int> outputAnswer;
            outputAnswer = new Action<double, int>(OutputAnswer);

            //check answer
            outputAnswer(2.534522, 4);

            //anon. method
            MyRounder myRounder3;
            myRounder3 = delegate (double d, int n)
            {
                double returnVal = 0;
                returnVal = Rounds(d, n);
                return returnVal;
            };

            //check answer
            Console.WriteLine(myRounder3(2.534522, 4));

            //anon. codeblock with lambda expression
            MyRounder myRounder4;
            myRounder4 = (double d, int n) =>
            {
                double returnVal = 0;
                returnVal = Rounds(d, n);
                return returnVal;
            };

            //check answer
            Console.WriteLine(myRounder4(2.534522, 4));

            //lambda expression
            MyRounder myRounder5;
            myRounder5 = (d, n) =>
            {
                double returnVal = 0;
                returnVal = Rounds(d, n);
                return returnVal;
            };

            //check answer
            Console.WriteLine(myRounder5(2.534522, 4));

            //further abbreviated lambda expression
            MyRounder myRounder6;
            myRounder6 = (d, n) =>
            { 
                return Rounds(d, n);
            };

            //check answer
            Console.WriteLine(myRounder6(2.534522, 4));

            MyRounder myRounder7 = (d, n) => Rounds(d,n);

            //check answer
            Console.WriteLine(myRounder7(2.534522, 4));

            //abbreviated func expression
            Func<double, int, double> myRounder8 = Rounds;

            //check answer
            Console.WriteLine(myRounder8(2.534522, 4));

            //abbreviated action expression
            Action<double, int> myRounder9 = OutputAnswer;

            //check answer
            myRounder9(2.534522, 4);

            //regular method call (named method)
            double MyRounder10(double d, int n)
            {
                return Rounds(d, n);
            }

            MyRounder round = MyRounder10;

            //check answer
            Console.WriteLine(round(2.534522, 4));

            //no need to create delegate instance
            //because method signature of Rounds matches
            //signature of MyRounder
            MyRounder myRounder11 = Rounds;

            //check answer
            Console.WriteLine(myRounder11(2.534522, 4));

        }
    }
}
