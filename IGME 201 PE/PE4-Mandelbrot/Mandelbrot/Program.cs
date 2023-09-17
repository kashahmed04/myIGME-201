using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandelbrot
{
    /// <summary>
    /// This class generates Mandelbrot sets in the console window!
    /// </summary>


    class Class1
    {
        /// <summary>
        /// This is the Main() method for Class1 -
        /// this is where we call the Mandelbrot generator!
        /// We ask for user input and make sure that certain
        /// conditions are met before letting those variables be
        /// used within the loop so the proper display can show up.
        /// If the user does not give a number, or does not stay in bounds 
        /// keep asking them to enter numbers over and over until
        /// they are in bounds and have submitted an actual number.
        /// </summary>
        /// <param name="args">
        /// The args parameter is used to read in
        /// arguments passed from the console window
        /// </param>

        [STAThread]
        static void Main(string[] args)
        {
            double? startImagValNum = null;
            double? endImagValNum = null;
            double? startRealNum = null;
            double? endRealNum = null;

            Console.WriteLine("Enter a number for the starting imagniary number (a good starting point would be at 1.2): ");
            string startImagVal = Console.ReadLine();
            
            Console.WriteLine("Enter a number for the ending imaginary number (a good ending point would be at -1.2): ");
            string endImagVal = Console.ReadLine();

            Console.WriteLine("Enter a number for the starting real number (a good starting point would be -0.6): ");
            string startReal = Console.ReadLine();

            Console.WriteLine("Enter a number for the starting real number (a good ending point would be 1.77): ");
            string endReal = Console.ReadLine();

            while(startImagValNum == null)
            {
                try
                {
                    startImagValNum = Convert.ToDouble(startImagVal);
                }
                catch
                {
                    Console.WriteLine("Enter an actual number for the starting imagniary number (a good starting point would be at 1.2): ");
                    startImagVal = Console.ReadLine();

                }
            }

            while (endImagValNum == null)
            {
                try
                {
                    endImagValNum = Convert.ToDouble(endImagVal);
                }
                catch
                {
                    Console.WriteLine("Enter an acutal number less than " + startImagValNum + " for the ending imagniary number (a good ending point would be at -1.2): ");
                    endImagVal = Console.ReadLine();

                }

                if (endImagValNum > startImagValNum)
                {
                    Console.WriteLine("Enter an acutal number less than " + startImagValNum + " for the ending imagniary number (a good ending point would be at -1.2): ");
                    endImagVal = Console.ReadLine();
                    endImagValNum = null;
                    continue;
                }
            }

            while (startRealNum == null)
            {
                try
                {
                    startRealNum = Convert.ToDouble(startReal);
                }
                catch
                {
                    Console.WriteLine("Enter an actual number for the starting real number (a good starting point would be -0.6): ");
                    startReal = Console.ReadLine();

                }
            }

            while (endRealNum == null)
            {
                try
                {
                    endRealNum = Convert.ToDouble(endReal);
                }
                catch
                {
                    Console.WriteLine("Enter an actual number greater than " + startRealNum + " for the ending real number (a good ending point would be 1.77): ");
                    endReal = Console.ReadLine();

                }

                if (endRealNum < startRealNum)
                {
                    Console.WriteLine("Enter an actual number greater than " + startRealNum + " for the ending real number (a good ending point would be 1.77): ");
                    endReal = Console.ReadLine();
                    endRealNum = null;
                    continue;
                }
            }


            double realCoord, imagCoord;
            double realTemp, imagTemp, realTemp2, arg;
            int iterations; //why cant we say double? here instead of double**
            for (imagCoord = (double)startImagValNum; imagCoord >= (double)endImagValNum; imagCoord -= ((double)startImagValNum - (double)endImagValNum) / 48)
            {
                for (realCoord = (double)startRealNum; realCoord <= (double)endRealNum; realCoord += ((double)endRealNum - (double)startRealNum) / 80 )
                {
                    iterations = 0;
                    realTemp = realCoord;
                    imagTemp = imagCoord;
                    arg = (realCoord * realCoord) + (imagCoord * imagCoord);
                    while ((arg < 4) && (iterations < 40))
                    {
                        realTemp2 = (realTemp * realTemp) - (imagTemp * imagTemp)
                           - realCoord;
                        imagTemp = (2 * realTemp * imagTemp) - imagCoord;
                        realTemp = realTemp2;
                        arg = (realTemp * realTemp) + (imagTemp * imagTemp);
                        iterations += 1;
                    }
                    switch (iterations % 4)
                    {
                        case 0:
                            Console.Write(".");
                            break;
                        case 1:
                            Console.Write("o");
                            break;
                        case 2:
                            Console.Write("O");
                            break;
                        case 3:
                            Console.Write("@");
                            break;
                    }
                }
                

            }
        }
    }
}
