using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

    /// delegate steps
    /// 1. define the delegate method data type based on the method signature
    ///         delegate double MathFunction(double n1, double n2);
    /// 2. declare the delegate method variable
    ///         MathFunction processDivMult;
    /// 3. point the variable to the method that it should call
    ///         processDivMult = new MathFunction(Multiply);
    /// 4. call the delegate method
    ///         nAnswer = processDivMult(n1, n2);
    ///        

namespace Delegates
{
    delegate double MathFunction(double x, int y); 

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
        static double Rounds(double x, int y)
        {
            return Math.Round(x, y); 
        }

        // Method: OutPutAnswer
        // Author: Kashaf Ahmed
        // Purpose: Method for action so it prints out to the console the rounded value since it cant have a return statement
        // Restrictions: None
        static void OutputAnswer(double x, int y)
        {
            Console.WriteLine(Math.Round(x, y));
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
            MathFunction processRound;
            processRound = new MathFunction(Rounds);

            nAnswer = processRound(2.534522, 4);

            //check answer
            //Console.WriteLine(nAnswer);


            //using func delegate 
            Func<double, int, double> processRound2;
            processRound2 = new Func<double, int, double>(Rounds);
            nAnswer2 = processRound2(2.534522, 4);

            //check answer
            //Console.WriteLine(nAnswer2);

            //using action delegate 
            Action<double, int> outputAnswer;
            outputAnswer = new Action<double,int>(OutputAnswer);

            //check answer
           // outputAnswer(2.534522, 4);

            //anon. method
            MathFunction processRound3;
            processRound3 = delegate (double x, int y)
            {
                double returnVal = 0;
                returnVal = Math.Round(x, y);
                return returnVal;
            };

            //check answer
            //Console.WriteLine(processRound3(2.534522, 4));

            //anon. codeblock with lambda expression
            MathFunction processRound4;
            processRound4 = (double x, int y) =>
            {
                double returnVal = 0;
                returnVal = Math.Round(x, y);
                return returnVal;   
            };

            //check answer
            //Console.WriteLine(processRound4(2.534522, 4));

            //lambda expression
            MathFunction processRound5;
            processRound5 = (x, y) =>
            {
                double returnVal = 0;
                returnVal = Math.Round(x, y);
                return returnVal;
            };

            //check answer
            //Console.WriteLine(processRound5(2.534522, 4));


           
        }
    }
}
