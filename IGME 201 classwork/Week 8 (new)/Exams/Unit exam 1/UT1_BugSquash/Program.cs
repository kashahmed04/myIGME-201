using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Threading;

namespace UT1_BugSquash
{
    static class Program
    {
        // Calculate x^y for y > 0 using a recursive function
        static void Main(string[] args)
        {
            string sNumber;
            int nX;
            int nY;
            //(Bug #1: Compile Time Error: forgot the ";")
            //int nY 
            int nAnswer;

            //(Bug #2: Compile Time Error: There are not any " " around the text)
            //Console.WriteLine(This program calculates x ^ y.);
            Console.WriteLine("This program calculates x ^ y.");

        start:;
            do
            {
                Console.Write("Enter a whole number for x: ");
                sNumber = Console.ReadLine();
            } while (!int.TryParse(sNumber, out nX));
            //(Bug #3: Compile Time error: sNumber is not defined
            //while (!int.TryParse(sNumber, out nX)); 

            do
            {
                Console.Write("Enter a positive whole number for y: ");
                sNumber = Console.ReadLine();
            } while (!int.TryParse(sNumber, out nY));

            if(nY <= 0)
            {
                goto start;
            }
            //(Bug #4: Logic Error: we put out nX which is the x value, not the y so we have to put nY instead)
            //while (int.TryParse(sNumber, out nX));

            //(Bug #5: Logic Error: Did not put the "!" for the int.TryParse() statement)
            //while (int.TryParse(sNumber, out nY));

            //(Bug #6: Run Time Error: When we put in a negative number for y, we got a Stackoverflow exception, also it said that it should
            //take a pos. number for y so we have to account for if they put in 0)
            // do
            //{
               // Console.Write("Enter a positive whole number for y: ");
                //sNumber = Console.ReadLine();
            //} while (!int.TryParse(sNumber, out nY)) ;


            // compute the exponent of the number using a recursive function
            nAnswer = Power(nX, nY);

            Console.WriteLine($"{nX}^{nY} = {nAnswer}");
            //(Bug #7: Logic error: Returns the values as shown in the " " and not as a calcualtion with the actual numbers put in by the user
            //Console.WriteLine("{nX}^{nY} = {nAnswer}");
        }


        //(Bug #8: Compile Timer Error: Did not use "static" for the method)
        //int Power(int nBase, int nExponent)
        static int Power(int nBase, int nExponent)
        {
            int returnVal = 0;
            int nextVal = 0;

            // the base case for exponents is 0 (x^0 = 1)
            if (nExponent == 0)
            {
                // return the base case and do not recurse
                returnVal = 1;
                //(Bug #9: Logic Error: returnVal was set to 0 when it should have been set to 1)
                //returnVal = 0;
            }
            else
            {
                // compute the subsequent values using nExponent-1 to eventually reach the base case
                nextVal = Power(nBase, nExponent + 1);

                //(Bug #10: Logic error (should have done nExponent +1)
                returnVal = nBase * nextVal;
            }

            return returnVal;
            //(Bug #11: Compile Time Error: There is no "return" before the returnVal to actually return a value)
            //returnVal;
        }
    }
}

