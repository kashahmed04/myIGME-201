﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                int[] myIntArray = { 5, 6, 7, 8, 9, 23, 123, -90 }; //we usually initialize arrays with int[] then use
                //any of the below methods to fill them in** 
                //myIntArray[0] 
            }

            {
                int[] myIntArray = new int[8] { 5, 6, 7, 8, 9, 23, 123, -90 }; //here we can specify a specific size whereas
                //the first one we could do as many values as we want or are we adding a new value**
                //can arrays have multiple datatypes within them**
            }

            {
                int[] myIntArray = new int[8];
                myIntArray[0] = 5;
                myIntArray[1] = 6;
                myIntArray[2] = 7;
                myIntArray[3] = 8;
                myIntArray[4] = 9;
                myIntArray[5] = 23;
                myIntArray[6] = 123;
                myIntArray[7] = -90; //if we went outside of bounds in this case, if we added more than 8 elements would that
                //be a run time error because our program runs, but it gives an error in the console

                int[] myIntArray2;
                myIntArray2 = myIntArray; //call by ref.**

                myIntArray2[0] = 55; //changes the 0 element to 55 in myIntArray1 because** 
                //they have a ref. to the same location and are not 2 different arrays 
                //changing at the same time 

                myIntArray = null;  //this array is taken by the garabage collector so not it's lost but*
                //does myIntArray2 still have access to it or is it equal to null since the first one is equal to null
                myIntArray2 = null; //now it completely lost because it was taken by the garbage collector
            }

            {
                int arraySize = 5;
                int[] myIntArray = new int[arraySize]; //specifiying how many things should be in the array
            }

            if( false )
            {
                int[] funcVal = new int[21];
                int x = 0;
                int xCntr = 0;
                int y = 0;

                // the value of y at x
                funcVal[x] = y;

                // cannot access arrays with negative indexes
                //funcVal[-10] = 45;

                // we may want a parallel array to store each value of x
                int[] xArray = new int[21];

                // for example: y = 2 * x^2 + 3
                // fill the array for -10 <= x <= 10 (21 data points)
                for (x = -10; x <= 10; ++x, ++xCntr) //first loop does increment but after it does**
                {
                    // Math.Pow() returns a double, so we need to cast as int
                    y = 2 * (int)Math.Pow(x, 2) + 3;

                    // the array indexer must be a positive integer and 0-based
                    // (ie. we cannot store funcVal[-10])
                    funcVal[xCntr] = y; //store the y value at a certain index according to the loop number we are on and the y is calaulated**
                    xArray[xCntr] = x; //store the x values based on the loop number as well and the x goes from -10 to 10**
                }

                int[,] funcVal2 = new int[21, 2]; //21 inputs but we want to have 2 inputs per index with a comma seperator?? or is this 2 arrays with 21 inputs**

                for (x = -10; x <= 10; ++x, ++xCntr)
                {
                    // Math.Pow() returns a double, so we need to cast as int
                    y = 2 * (int)Math.Pow(x, 2) + 3;

                    // the array indexer must be a positive integer and 0-based
                    // (ie. we cannot store funcVal[-10])
                    funcVal2[xCntr, 0] = y; //the first array stores the y (the 0 is the array and the index it will be stored at)**
                    funcVal2[xCntr, 1] = x; //the second array stores the x based on the index (the array being the second one started at 1 though because
                    //array numbers and indexes are 0 based)**
                }
            }

            {
                // 3-d formula example with rectangular array

                // implement the code to calculate: z = 2x ^ 3 + 3y ^ 3 + 6
                // for -4 <= x <= 4 in 0.1 increments: there are 81 values of x
                // for -2 <= y <= 5 in 0.2 increments: there are 36 values of y

                double x = 0;
                double y = 0;
                double z = 0;

                int nX = 0;
                int nY = 0;

                // we declare our 3 dimensional array to hold:
                //        81 values of x
                //        36 values of y for each value of x
                //        3 values for each data point: the x, y and z
                double[,,] zFunc = new double[81, 36, 3];

                for (x = -4; x <= 4; x += 0.1, nX++)
                {
                    x = Math.Round(x, 1);

                    // start with the 0'th "y" bucket for this value of x
                    nY = 0;

                    for (y = -2; y <= 5; y += 0.2, ++nY)
                    {
                        y = Math.Round(y, 1);

                        z = 2 * Math.Pow(x, 3) + 3 * Math.Pow(y, 3) + 6;

                        z = Math.Round(z, 3);

                        zFunc[nX, nY, 0] = x;
                        zFunc[nX, nY, 1] = y;
                        zFunc[nX, nY, 2] = z;
                    }
                }
            }

            {
                int[][] jaggedIntArray = new int[2][];

                jaggedIntArray[0] = new int[3];
                jaggedIntArray[1] = new int[4];

                jaggedIntArray[0][0] = 1;
                jaggedIntArray[0][1] = 2;
                jaggedIntArray[0][2] = 3;

                jaggedIntArray[1][0] = 1;
                jaggedIntArray[1][1] = 2;
                jaggedIntArray[1][2] = 3;
                jaggedIntArray[1][3] = 4;

                {
                    // a jagged array lets you have a different number of values per "line" of the array
                    //not 2D**
                    // line #1 supports 3 values: 1,2,3
                    // line #2 supports 4 values: 1,2,3,4
                }
            }

            {
                // 3-d formula example with jagged array

                // implement the code to calculate: z = 2x ^ 3 + 3y ^ 3 + 6
                // for -4 <= x <= 4 in 0.1 increments: there are 81 values of x
                // for -2 <= y <= 5 in 0.2 increments: there are 36 values of y

                double x = 0;
                double y = 0;
                double z = 0;

                int nX = 0;
                int nY = 0;
                int nThirdDim = 0;

                // we declare our 3 dimensional array to hold:
                //        81 values of x
                //        36 values of y for each value of x
                //        3 values for each data point: the x, y and z
                double[][][] zFunc = new double[81][][];

                // we need to allocate each dimension of the array separately
                for (nX = 0; nX < 81; ++nX)
                {
                    // allocate the 36 "y" elements for each of the 81 "x" elements
                    zFunc[nX] = new double[36][];

                    for (nThirdDim = 0; nThirdDim < 3; ++nThirdDim)
                    {
                        // allocate the 3 elements of the 3rd dimension for each [x][y] dimension
                        zFunc[nX][nThirdDim] = new double[3];
                    }
                }

                for (x = -4; x <= 4; x += 0.1, nX++)
                {
                    x = Math.Round(x, 1);

                    // start with the 0'th "y" bucket for this value of x
                    nY = 0;

                    for (y = -2; y <= 5; y += 0.2, ++nY)
                    {
                        y = Math.Round(y, 1);

                        z = 2 * Math.Pow(x, 3) + 3 * Math.Pow(y, 3) + 6;

                        z = Math.Round(z, 3);

                        zFunc[nX][nY][0] = x;
                        zFunc[nX][nY][1] = y;
                        zFunc[nX][nY][2] = z;
                    }
                }

            }

        }
    }
}
