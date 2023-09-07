using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_2_2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            { //arrays are a list of values and we use [] to define its an array**
              //arrays are stored in a block of memory and the values within that array are stroed right next to each other**
                int[] myIntArray = { 5, 6, 7, 8, 9, 23, 123, -90 };
                myIntArray[0] //start form index 0 to access first value (this is a 1 dimensional array like an x on a graph instead of x,y)**
            }

            {
                int[] myIntArray = new int[8] {5, 6, 7, 8, 9, 23, 123, -90 }; //this is a way to add a new value into the end of an
                //array (can we also add between numbers**
            }

            {
                int[] myIntArray = new int[8]; //another way to create an array 
                myIntArray[0] = 5;
                myIntArray[1] = 6;
                myIntArray[2] = 7;
                myIntArray[3] = 8;
                myIntArray[4] = 9;
                myIntArray[5] = 23;
                myIntArray[6] = 123;
                myIntArray[7] = -90;

                //arrays are a ref. data type and when we create an array by using the {} or the new keyword a block of memory
                //was set aside for us (an object is the block of memory) and the pointer is pointing to that block of memory**

                //when we declare the pointer has a towel over it 
                int[] myIntArray2;
                myIntArray2 = myIntArray;
                //when we set intarray 2 and int array they are pointing to the same object and if we change myarray2 then the value
                //in intarray will also be changed (both mirrors look at the same thing)**

                myIntArray2[0] = 55; //both arrays see the changes made and both get changed the exact same way because they point
                //to the same block of memory and both get changed** 

                //and object is takes up memory and value data types as well difference?**

                myIntArray = null; //we have just pointed the pointer away from the data and its basically putting a towel
                //over the mirror and now we cant access the array anymore from both arrrays**
                myIntArray2 = null; //now that both of them are null we lose the object and we can no longer access it
                
                //we do not copy data, we just change the pointer to look at the same location in memory for objects**

                //a garbage collector is when a varibale is no longer being used or a local variable that is no longer accessible 
                //outside the scope, it will be put in the garbage collector and be cleaned up so it decreases the file size**
               

            }

            {
                //we can also dynamically create arrays
                int arraySize = 5;
                int[] myIntArray = new int[arraySize];
            }

            {
                //cant access arrays with negative numbers (only goes from 0 to number of elements minus 1 because
                //we start from 0)
                //to add dimensions to the array we add a ","
                int[,] funcVal2 = new int[21, 2]; //stores both the x and the y (2 dimensioonal)**
               
            }

            {
                //rectanfular arrays are defined by using the , notatino within the brackets (rectangular means that
                //they will be equally sized array ex. 2x2 arrays will gold 4 values**

                //jagged arrays are (use series of brackets**
                //if we want a jagged array with dimensinos we use the [] instead of the ,**
                //our array can hold different number of elements while regular 2 dimensional they are the same number
                //if things in the array
                //why leave the second [] empty**
                int[][] jaggedIntArray = new int[2][];
                jaggedIntArray[0] = new int[3];
                jaggedIntArray[1] = new int[4]; //each dimension can have a different size associated with them**
                //1,2,3 (0)
                //1,2,3,4 (1)

                {
                   
                }
            }
        }
    }
} 

//right clock on variable in debugging mode to see what the variables are equal to as we degbug and go through the code**
//we cant use double because its base 2 arithmetic (rounds down) while round bascically follows the simple rounding rules**
