using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberSortV1
{
    /// delegate steps
    /// 1. define the delegate method data type based on the method signature
    ///         delegate double MathFunction(double n1, double n2);
    /// 2. declare the delegate method variable
    ///         MathFunction processDivMult;
    /// 3. point the variable to the method that it should call
    ///         processDivMult = new MathFunction(Multiply);
    /// 4. call the delegate method
    ///         nAnswer = processDivMult(n1, n2); <summary>
    /// delegate steps
    /// </summary>
    /// 

    // Class: Program
    // Author: Kashaf Ahmed
    // Purpose: Get a sentence from the user and display it from rather ascending or descending order
    // Restrictions: None
    static class Program
    {
        delegate string LowestOrHighestFunction(string[] a);

        // Method: Main
        // Author: Kashaf Ahmed
        // Purpose: Get a sentence from the user and count how many items are in the array then insert it in the unsorted array
        //then sort it based on if the user wants it in ascending or descending order and add the values into the sorted array based on that value and
        //remove it from the unsorted array. After display the sorted sentence to the console
        // Restrictions: None
        static void Main(string[] args)
        {
            // declare the unsorted and sorted arrays
            string[] aUnsorted;
            string[] aSorted;

        // a label to allow us to easily loop back to the start if there are input issues
        start:
            Console.WriteLine("Enter a sentence");

            // read the space-separated string 
            string sString = Console.ReadLine();

            // split the string into the an array of strings which are the individual words
            string[] sStringSplit = sString.Split(' ');

            // initialize the size of the unsorted array to 0
            int nUnsortedLength = 0;

            // a double used for parsing the current array element
            double nThisString;

            // iterate through the array of strings
            foreach (string sThisString in sStringSplit)
            {
                // if the length of this string is 0 (ie. they typed 2 spaces in a row)
                if (sThisString.Length == 0)
                {
                    // skip it
                    continue;
                }

                ++nUnsortedLength;
            }

            // now we know how many unsorted words there are
            // allocate the size of the unsorted array
            aUnsorted = new string[nUnsortedLength];

            // reset nUnsortedLength back to 0 to use as the index to store the words in the unsorted array
            nUnsortedLength = 0;
            foreach (string sThisNumber in sStringSplit)
            {
                // still skip the blank strings
                if (sThisNumber.Length == 0)
                {
                    continue;
                }
                // store the value into the array
                aUnsorted[nUnsortedLength] = sThisNumber;

                // increment the array index
                nUnsortedLength++;
            }

            string sAscDesc = "";

            // prompt for whether to sort ascending or descending
            Console.Write("Sort by (a)scending or (d)escending: ");
            sAscDesc = Console.ReadLine();

            // declare delegate method variable
            LowestOrHighestFunction lowestOrHighest;

            // point the variable to the appropriate method to call based on user input
            if (sAscDesc.ToLower().StartsWith("a"))
            {
                lowestOrHighest = new LowestOrHighestFunction(FindLowestValue);
            }
            else
            {
                lowestOrHighest = new LowestOrHighestFunction(FindHighestValue);
            }


            // allocate the size of the sorted array
            aSorted = new string[nUnsortedLength];

            // start the sorted length at 0 to use as sorted index element
            int nSortedLength = 0;

            // while there are unsorted values to sort
            while (aUnsorted.Length > 0)
            {

                // call the delegate method
                aSorted[nSortedLength] = lowestOrHighest(aUnsorted); //based on what the user put the proper method will get called
                //according if they put a or d and it will get the value from the unsorted array and put it in the sorted array
                //then will remove the value from the unsorted array like normal

                // remove the current sorted value
                RemoveUnsortedValue(aSorted[nSortedLength], ref aUnsorted);

                // increment the number of values in the sorted array
                ++nSortedLength;
            }


            // write the sorted array of numbers
            Console.WriteLine("The sorted list is: ");
            foreach (string thisword in aSorted)
            {
                Console.Write($"{thisword} ");
            }

            Console.WriteLine();
        }


        // Method: FindLowestValue
        // Author: Kashaf Ahmed
        // Purpose: Find the lowest value in the array and return it 
        // Restrictions: None
        static string FindLowestValue(string[] array)
        {
            // define return value
            char returnVal; //if we have char. it sorts by ASCII value 
            int index = 0;

            // initialize to the first element in the array
            // (we must initialize to an array element)
            returnVal = array[0][0];


            for(int i = 0; i < array.Length; i++) //get the first characrer for the array then compare it to the
                //return val. first character and store the current index we are on if we find a value lower than return val
                //and we return the current word in the array by the index in the end when it has the lowest value 
            {
                if(array[i][0] < returnVal)
                {
                    returnVal = array[i][0];
                    index = i; //index of the current word to store the lowest value
                }
            }

            return array[index]; //it sorts by ascii value if we use char rather than string
        }

        // find the highest value in the array of ints
        // the method "signature" defines a method and consists of the return type (double) and method arguments (double[] array)


        // Method: FindHighestValue
        // Author: Kashaf Ahmed
        // Purpose: Find the highest value in the array and return it 
        // Restrictions: None
        static string FindHighestValue(string[] array)
        {
            // define return value
            char returnVal;
            int index = 0;

            // initialize to the first element in the array
            // (we must initialize to an array element)
            returnVal = array[0][0];


            for (int i = 0; i < array.Length; i++)
            {
                if (array[i][0] > returnVal)
                {
                    returnVal = array[i][0];
                    index = i;
                }
            }

            // return the highest value
            return (array[index]);
        }


        // remove the first instance of a value from an array

        // Method: RemoveUnsortedValue
        // Author: Kashaf Ahmed
        // Purpose: Remove the value from the unsorted array that we put into the sorted array
        // after doing the lowest or highest method based on what the user puts in 
        // Restrictions: None
        static void RemoveUnsortedValue(string removeValue, ref string[] array) 
        {
            // allocate a new array to hold 1 less value than the source array
            string[] newArray = new string[array.Length - 1];

            // we need a separate counter to index into the new array, 
            // since we are skipping a value in the source array
            int dest = 0;

            // the same value may occur multiple times in the array, so skip subsequent occurrences
            bool bAlreadyRemoved = false;

            // iterate through the source array
            foreach (string srcword in array)
            {
                // if this is the number to be removed and we didn't remove it yet
                if (srcword == removeValue && !bAlreadyRemoved)
                {
                    // set the flag that it was removed
                    bAlreadyRemoved = true;

                    // and skip it (ie. do not add it to the new array)
                    continue;
                }

                // insert the source number into the new array
                newArray[dest] = srcword;

                // increment the new array index to insert the next word
                ++dest;
            }

            // set the ref array equal to the new array, which has the target number removed
            // this changes the variable in the calling function (aUnsorted in this case)
            array = newArray;
        }
    }
}
