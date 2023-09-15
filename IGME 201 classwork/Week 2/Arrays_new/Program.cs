using System;
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
                int[] myIntArray = { 5, 6, 7, 8, 9, 23, 123, -90 }; //we usually initialize arrays with int[] or can it be another data type (can use muktiple) 
                //and in this case it can be infinite values within the array because theres no new int[] within it
                //myIntArray[0] 

                //if we wanted to add another element to it, we would have to make a new array and increase the size of the new array to represent current array
                //increase of size then use a for loop to go through the original array and we need to copy the index of the first array we are on into the index
                //of the second array, then we make the new value equal to a new index placement

                //copy the contents of the first array into the second array via a foreach (cant edit content) or for loop then add the last value
            }

            {
                int[] myIntArray = new int[8] { 5, 6, 7, 8, 9, 23, 123, -90 }; //This creates a new array with size of 8
                //can arrays have multiple datatypes within them (when we initizlaize arrays like this we can add from anywhere in the code whereas
                ////the top solution, we can only initizialize it
            }

            {
                int[] myIntArray = new int[8]; //usualy use this when making arrays 
                myIntArray[0] = 5;
                myIntArray[1] = 6;
                myIntArray[2] = 7;
                myIntArray[3] = 8;
                myIntArray[4] = 9;
                myIntArray[5] = 23;
                myIntArray[6] = 123;
                myIntArray[7] = -90; //if we went outside of bounds in this case, if we added more than 8 elements would that
                //be a run time error because our program runs, but it gives an error in the console**

                int[] myIntArray2;
                myIntArray2 = myIntArray; //call by ref.

                myIntArray2[0] = 55; //changes the 0 element to 55 in myIntArray1 because 
                //they have a ref. to the same location and are not 2 different arrays 
                //changing at the same time 

                myIntArray = null;  //this array is taken by the garabage collector so not it's lost but
                //we cna still access the arrat with my int array 2 before its set equal to null because its still pointing to the first array 
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
                funcVal[x] = y; //how does this get used within the loop**

                // cannot access arrays with negative indexes
                //funcVal[-10] = 45;

                // we may want a parallel array to store each value of x
                int[] xArray = new int[21];

                // for example: y = 2 * x^2 + 3
                // fill the array for -10 <= x <= 10 (21 data points)
                for (x = -10, xCntr = 0; x <= 10; ++x, ++xCntr) //first loop does increment but after it does**
                {
                    // Math.Pow() returns a double, so we need to cast as int
                    //when we cast as an int. does it cut off the other part of the double or does it round**
                    y = 2 * (int)Math.Pow(x, 2) + 3;

                    // the array indexer must be a positive integer and 0-based
                    // (ie. we cannot store funcVal[-10])
                    funcVal[xCntr] = y; //store the y value at a certain index according to the loop number we are on and the y is calaulated (the column)****
                    xArray[xCntr] = x; //store the x values based on the loop number as well and the x goes from -10 to 10 (the rows or lines)**
                    //in this case, for each index it would store and x and a y value within each column but how would the lines (or rows) be referrenced and their labels**
                    //is the x the rows or lines and the y values are the columns for each x**
                }

                int[,] funcVal2 = new int[21, 2]; //21 inputs but we want to have 2 inputs per index with a comma seperator?? or is this 2 arrays with 21 inputs**


                //if we want a 2D array we can use a comma in the braackets as well as if we want 3 2D dimensions, creates a 21 by 2 possible values (42 different
                //cells we can hold) to acces them we use the index, 
                //our  array can go from 0-20**
                //and our same  array can go from 0-1**
                //out x values can go from -10 to 10 and for each x value we get our index value and we cant use negative numbers for array indexing 
                //and it has to be an positive integer
                //our first integer for x is -10 so we put xCntr instead to start at index 0 to represent the -10 index
                //xcntr is the rows (21 rows) and 2 columns for our y values 
                //A rows would be x values from -10 to 10, and our B values would hold the x and y values (going y,x)**
                //for each x dimension from -10 to 10, there are 2 values that can be accessed the y and x** (why do we have 2 x values in this case)**

                //so basically its 21 rows (lines) and for each of those rows or lines, there are 2 values, and x and a y (is this technically like an array within
                //an array because for each index we haev 2 valeus so would that be an array within an array**

                //basically for each index we have an x and a y (y,x) value representing the 2 and the 21 is the each index from -10 to 10**








                for (x = -10; x <= 10; ++x, ++xCntr)
                {
                    // Math.Pow() returns a double, so we need to cast as int
                    y = 2 * (int)Math.Pow(x, 2) + 3;

                    // the array indexer must be a positive integer and 0-based
                    // (ie. we cannot store funcVal[-10])
                    funcVal2[xCntr, 0] = y; //at this row, in the 0th dimension column put the y 
                    funcVal2[xCntr, 1] = x; //at this row, in the first dimension column put the x 
                    //the xCntr is the A rows, then the 0 is the 0th dimension the B columns which is the y, and the first dimension is the 
                    //C columns which is the x
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



                //if its 3D, then our first dimension 81 is the rows representing the x, and we have 36 values of y that can be stored in
                //each column, and then for each of the y, the third one is representing storing x y and z within that y**

                //for each value of x (rows) we have 5 values of y in each column and for each value of y we have 3 values in the third dimension
                //and for each value of x, we have 15 values set equal to y not including itself y** [5,5,3] 
                
                //so basically we wil have 5 values of x for the lines or rows,5 values for y in the columns for each x, then for each y, we would
                //have the 3 values of x,y,z, making it 15 values of x,y,z for each x value**

                //and if we had 81 values of x(rows or lines), then for each x, there would be 36 values of y(columns), then for each y there would be 3 values of x,y,z,
                //making there be a total of 36*3 values of x,y,z for each value of x (108 values of x,y,x for each x)**








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

                        zFunc[nX, nY, 0] = x; //for each index of the  nx and ny, basically the nx is the current x (rows or lines), and the curruent,
                        //y is the ny, but we have 3 parts to the array (or 3 arrays within an array)** and basically 0 is the x (rows), and y is the columns
                        //for each y, the z is the 3 values of x,y,z for that spcific x we are on (the inner loop does this for each value of y)(the loop
                        ////does not use 36 values of y for its loop condition though)**
                        zFunc[nX, nY, 1] = y; //would be 2D instead of jagged
                        zFunc[nX, nY, 2] = z; //nx is the current x and the ny the current y but it loops fully because its nested and gives the y
                        //the 3 values of x,y,z for each of the 36 values of x, then moves to the second index of x**
                    }
                }
            }

            {
                int[][] jaggedIntArray = new int[2][];
                //we can only initizalize size of the first dimension in jagged arrays and to do the second array we have to access the first
                //element in the first dimension(0)**
                //the [2] tells us how many rows (lines) we use and for the second[] it tells us how many columns there is going to be 
                //our first line [0] had 3 columns the new int.[3]**
                //and our second line (row) had 4 columns by the new int.[4]**
                //basically first part is rows, second part is columns, then third part if needed would be the values for the secnod part to be set equal to**




                //first dimension
                //0
                //1

                //
                jaggedIntArray[0] = new int[3];
                //0 0
                //0 1
                //0 2
                jaggedIntArray[1] = new int[4];
                //1 0
                //1 1
                //1 2
                //1 3

                jaggedIntArray[0][0] = 1; //can have 3 values in first dimension out of the [2]
                jaggedIntArray[0][1] = 2;
                jaggedIntArray[0][2] = 3;

                jaggedIntArray[1][0] = 1; //but our index of 1 can have 4 values because we created them individually rather than a rectangle 2D array
                jaggedIntArray[1][1] = 2;
                jaggedIntArray[1][2] = 3;
                jaggedIntArray[1][3] = 4;

                {
                    // a jagged array lets you have a different number of values per "line" of the array
                    //not 2D (jagged  = [][], while 2D is [,])**
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
                double[][][] zFunc = new double[81][][]; //why do we initizialize to a douvle here and the loop above, but not the
                //very first loop with 1D arrays**

                // we need to allocate each dimension of the array separately
                for (nX = 0; nX < 81; ++nX)
                {
                    // allocate the 36 "y" elements for each of the 81 "x" elements
                    zFunc[nX] = new double[36][]; //why could we put numbers in the brackets here, but not the above part in the intro. to jagged arrays**

                    for (nThirdDim = 0; nThirdDim < 3; ++nThirdDim)
                    {
                        // allocate the 3 elements of the 3rd dimension for each [x][y] dimension
                        zFunc[nX][nThirdDim] = new double[3]; //within the y value, within that index, we want to have an index for the x,y,z vaues as well
                        //for each value of y**
                    }

                    //for each x and y (the first loop) we want to fill those y's up for that x for each value of x,y,z (the second loop)**
                    //go over these loops again why 2 of them this time**
                    //so with jagged arrays we have to allocate space ahead of time but not why for 2D arrays**
                }

                for (nX = 0,x = -4; x <= 4; x += 0.1, nX++)
                {
                    x = Math.Round(x, 1);

                    // start with the 0'th "y" bucket for this value of x
                    nY = 0;

                    for (y = -2; y <= 5; y += 0.2, ++nY)
                    {
                        y = Math.Round(y, 1);

                        z = 2 * Math.Pow(x, 3) + 3 * Math.Pow(y, 3) + 6;

                        z = Math.Round(z, 3);

                        zFunc[nX][nY][0] = x; //nX and nY are the integer indexes into our array and at that specific index, it inserts the specific x in that line
                        zFunc[nX][nY][1] = y; //the 0,1,2, represent the 81 values of x, 36 values of y, and 3 x,y,z values**
                                              //at this current x and y index, insert this x value at the 0th dimension(row or line), y value at the first dimension
                                              //(comlumn),and in the third dimension x,y,z value (for each value of y)** (do we usually say 0th dimension or first them move on**)
                        zFunc[nX][nY][2] = z;
                    }
                }

            }

        }
    }
}
