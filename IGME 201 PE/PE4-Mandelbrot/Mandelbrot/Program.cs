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

            Console.WriteLine("Enter a number for the starting imagniary number: ");
            string startImagVal = Console.ReadLine();
            
            Console.WriteLine("Enter a number for the ending imaginary number: ");
            string endImagVal = Console.ReadLine();

            Console.WriteLine("Enter a number for the starting real number: ");
            string startReal = Console.ReadLine();

            Console.WriteLine("Enter a number for the starting real number: ");
            string endReal = Console.ReadLine();

            while(startImagValNum == null)
            {
                try
                {
                    startImagValNum = Convert.ToDouble(startImagVal);
                }
                catch
                {
                    Console.WriteLine("Enter a number for the starting imagniary number: ");
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
                    Console.WriteLine("Enter a number for the starting imagniary number: ");
                    endImagVal = Console.ReadLine();

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
                    Console.WriteLine("Enter a number for the ending imagniary number: ");
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
                    Console.WriteLine("Enter a number for the ending imagniary number: ");
                    endReal = Console.ReadLine();

                }
            }

            while(endImagValNum > startImagValNum)
            {
                while (startImagValNum == null)
                {
                    try
                    {
                        startImagValNum = Convert.ToDouble(startImagVal);
                    }
                    catch
                    {
                        Console.WriteLine("Enter a valid number for the starting imagniary number: ");
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
                        Console.WriteLine("Enter a valid number for the starting imagniary number: ");
                        endImagVal = Console.ReadLine();

                    }
                }
            }

            while (endRealNum > startRealNum)
            {
                while (startRealNum == null)
                {
                    try
                    {
                        startRealNum = Convert.ToDouble(startReal);
                    }
                    catch
                    {
                        Console.WriteLine("Enter a valid number for the ending imagniary number: ");
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
                        Console.WriteLine("Enter a valid number for the ending imagniary number: ");
                        endReal = Console.ReadLine();

                    }
                }
            }









            double realCoord, imagCoord;
            double realTemp, imagTemp, realTemp2, arg;
            int iterations;
            for (imagCoord = 1.2; imagCoord >= -1.2; imagCoord -= ((double)startImagValNum - (double)endImagValNum) / 48)
            {
                for (realCoord = -0.6; realCoord <= 1.77; realCoord += ((double)endRealNum - (double)startRealNum) / 80 )
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
                Console.Write("\n");
                Console.Out.WriteLine("50 plus 25 is " + 50 + 25);

            }
        }
    }
}
