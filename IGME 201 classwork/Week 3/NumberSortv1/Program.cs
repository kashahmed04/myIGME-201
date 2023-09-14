using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberSortV1
{
    // Class: Program
    // Author: David Schuh
    // Purpose: Number Sorting example
    // Restrictions: None
    static class Program
    {
        // Method: Main()
        // Purpose: Sort a user-entered list of space-delimited doubles
        // Restrictions: None

        //do we have to know how to do all of this (yes)
        static void Main(string[] args)
        {
            // declare the unsorted and sorted arrays, but we don't know how large to make them yet
            // the size will depend on how many numbers the user enters below
            double[] aUnsorted; //we have an unsorted and sorted array but we dont know how many numbers they stpre yet 
            //so there is no pointer to an array yet, so its kind of like the null value 
            //no value associated with them
            //arrays can be any data type but we can only access the array using integers 
            //and since arrays can only take 1 datatype, here we only take doubles and if the user enters an int. then it will be implicitly casted as an double 
            //we maed it a double so the user can also enter doubles 
            ////but if we use Object instead, we can store multiple data types
            //cant index by a negative, or a decimal value, only whole numbers 
            //we can even define and array of ecolors from favcolorandnumber 
            double[] aSorted;

        // a label to allow us to easily loop back to the start if there are input issues
        start:
            Console.WriteLine("Enter a list of space-separated numbers"); //asks user to enter the list of numbers seperated by spaces

            // read the space-separated string of numbers
            string sNumberString = Console.ReadLine();

            // split the string into the an array of strings which are the individual numbers**
            // (not in a loop so how would it do everything that the user said)**
            string[] sNumbers = sNumberString.Split(' '); //split the string into an array by splitting on the space character 
            //and it will give us an array of strings which is each number , seperated 

            // initialize the size of the unsorted array to 0
            int nUnsortedLength = 0;

            // a double used for parsing the current array element into a double when we read it from a string
            double nThisNumber;

            // you can read through an array using the index**
            //int nCntr = 0;
            //for( nCntr = 0; nCntr < sNumbers.Length; ++nCntr) //sNumbers is the array we split 
            //{
            //    // access this index of the array, and even change the contents if you want
            //    sNumbers[nCntr] = ""; //changes the contents to an empty string for that index
            //} we can read through a loop with a for loop and use nCntr as our current index

            // or you can use the foreach() loop which provides an "iterator" variable
            // pointing to each array element
            // a limitation of foreach() is that the iterator cannot modify the array's contents
            // it is read-only (so usually use a for loop to change the value at the current index if needed)**
            // iterate through the array of number strings and we can change values here whereas in the foreach its only used for arrays
            //and we cant change the array contents 
       
            foreach (string sThisNumber in sNumbers) //iterates through the array and sThisNumber is a loca variable and it set equa; to each value
                //in the sNumbers array as we go through the array 
            {
                // you cannot modify the iterator
                // this will cause a compile-time error
                //sThisNumber = ""; cant do it in a for each loop

                // if the length of this string is 0 (ie. they typed 2 spaces in a row)
                if (sThisNumber.Length == 0) 
                {
                    // skip it (if the current value we are in the array is equal to length 0 then we skip that element and go back to the
                    //loop and move on to the next one)
                    continue;
                }

                try
                {
                    // try to parse the current string into a double
                    nThisNumber = double.Parse(sThisNumber);

                    // if it's successful, increment the number of unsorted numbers length in the array 
                    ++nUnsortedLength;
                }
                catch
                {
                    // if an exception occurs
                    // indicate which number is invalid
                    Console.WriteLine($"Number #{nUnsortedLength + 1} is not a valid number."); //if we cant convert to a double
                    //then it tells us which element in the list (the index + 1 because its 0 based) was not valid and it skips that elemnt
                    //and does not add it and goes back to the start

                    // loop back to the start
                    goto start;
                }
            }

            // now we know how many unsorted numbers there are
            // allocate the size of the unsorted array
            aUnsorted = new double[nUnsortedLength]; //we make the unsorted array now equal to a new array of the length of the array we just got from the
            //for each loop from above 

            // reset nUnsortedLength back to 0 to use as the index to store the numbers in the unsorted array
            //and now we can sort the elements in the array from the sNumbers array 
            //we know they are all valid numbers, because we checked in the above loop 
            nUnsortedLength = 0; //reset the length to 1 so we can insert values into the unsorted array from sNumbers
            //snumbers is an array of strings and the unsorted array is the doubles that are parsed now
            foreach (string sThisNumber in sNumbers)
            {
                // still skip the blank strings
                if (sThisNumber.Length == 0)
                {
                    continue;
                }

                // parse it into a int (we know they are all valid now)
                nThisNumber = double.Parse(sThisNumber);

                // store the value into the array
                aUnsorted[nUnsortedLength] = nThisNumber;

                // increment the array index to go to the next index and add the element
                nUnsortedLength++;
            }

            // allocate the size of the sorted array (sorted array of doubles)(same size as unsorted array)
            aSorted = new double[nUnsortedLength]; 

            // start the sorted length at 0 to use as sorted index element**
            int nSortedLength = 0;

            // while there are unsorted values to sort (within the unsorted list)(once all numbers are removed from the unsrtoed array we are done)
            while (aUnsorted.Length > 0) 
            {
                // store the lowest unsorted value as the next sorted value
                aSorted[nSortedLength] = FindLowestValue(aUnsorted); //findlowestvalue is a method is it loops through the array and looks for the lowest value and at the
                //end of the method it returns that value (we take that lowest value and store it in our sorted array at that current index)

                // remove the current sorted value and does it replace it with the current value** but nothing is in aSorted so
                //how would that work**
                RemoveUnsortedValue(aSorted[nSortedLength], ref aUnsorted);
                //removeunsortedvalue is a method we wrote and we are passing it the value we are removing whhich is the current
                //value in our sorted array and we remove that value we just put in the sorted array from the unsorted array
                //and we want to pass it as a reference variable because we are going to change the variable (the array) to remove a value from the array
                //in the method the second para. is also a reference  to an array to remove the value

                // increment the number of values in the sorted array to find the next sorted value to add into the sorted array 
                ++nSortedLength;
            }


            // write the sorted array of numbers
            Console.WriteLine("The sorted list is: ");
            foreach (double thisNum in aSorted)
            {
                Console.Write($"{thisNum} "); //write our each element of the array
            }

            Console.WriteLine();
        }

        // find the lowest value in the array of ints
        // the method "signature" defines a method and consists of the return type (double) and method arguments (double[] array) 
        static double FindLowestValue(double[] array)
        {
            // define return value
            double returnVal;

            // initialize to the first element in the array
            // (we must initialize to an array element so we start at the 0th index of our current array)
            returnVal = array[0];

            // loop through the array
            foreach (double thisNum in array)
            {
                // if the current value is less than the saved lowest value
                if (thisNum < returnVal)
                {
                    // save this as the lowest value and move on 
                    returnVal = thisNum;
                }
            }

            // return the lowest value
            return (returnVal);
        }


        // we can overload methods by having the same method names with different signatures
        // if we call FindLowestValue with an array of int's then C# will call this method instead
        static int FindLowestValue(int[] array)
        {
            int returnVal;

            returnVal = array[0];

            foreach (int thisNum in array)
            {
                if (thisNum < returnVal)
                {
                    returnVal = thisNum;
                }
            }

            return (returnVal);
        }


        // remove the first instance of a value from an array 
        static void RemoveUnsortedValue(double removeValue, ref double[] array) //we want to remove 1 and we have aray 1,1,2 for example 
        {
            // allocate a new array to hold 1 less value than the source array because we are removing a value 
            double[] newArray = new double[array.Length - 1]; //now length 2 instead of 3

            // we need a separate counter to index into the new array, 
            // since we are skipping a value in the source array
            int dest = 0; //starting at index 0 for new array

            // the same value may occur multiple times in the array, so skip occurrences of the same number and only remove one of them
            bool bAlreadyRemoved = false; //not already removed so false

            // iterate through the source array
            foreach (double srcNumber in array)
            {
                // if this is the number to be removed and we didn't remove it yet
                if (srcNumber == removeValue && !bAlreadyRemoved) //this is the first time we remove it  (ex. array 1,1,2 and want to remove 1)
                    //if 1 is equal to the remove value which is 1, and we did not already removed it because its set to false, then set
                    //the flag it was removed, meaning we wont copy it into the new array and we want to continue to the next element in the list
                    //to add the element within the array, the next time around it goes to the second 1, but the second statement is equal to true because we 
                    //already removed the first 1 and we are on the second 1, so the conditonal eveluates to false, then we move out of if statement
                    //and now its going to set our new array index 0, to 1 then we incremenet our next index to put our new value in 
                {
                    // set the flag that it was removed
                    bAlreadyRemoved = true;

                    // and skip it (ie. do not add it to the new array)
                    continue;
                }

                // insert the source number into the new array
                newArray[dest] = srcNumber;

                // increment the new array index to insert the next number
                ++dest;
            }

            // set the ref array equal to the new array, which has the number we want to remove will be removed from the array but not a repeat of that number
            // only the first instance
            // this changes the variable in the calling function (the unsorted array so its length can get equal to 0, when we are done putting the values
            //within the sorted array)
            array = newArray;
        }
    }
}
