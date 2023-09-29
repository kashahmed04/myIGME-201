using System;
using System.Collections.Generic;
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
    static class Program //always put static in front of our class program so it forces us to put static in front of the class program
    {
        delegate double LowestOrHighestFunction(double[] a);

        //c# has a datatype built into it a list
        //a list data type is whats called a generic template datatype which means within the <> we can specify what the list is going to hold
        //instead of an array of doubles we have an list (we use a list because build into this data structure has the function to increase or decrease the size
        //of the list whereas for the array we had to create a new array to decrease or incrase the size)**
        //list data type within the <> and its usually only the type it takes in and nothing else**
        static void Main(string[] args)
        {
            // declare the unsorted and sorted arrays
            //double[] aUnsorted;
            //double[] aSorted;
            //to create the list object we need to use new operator otherwise its just avaruable of the list**
            List<double> aUnsorted = new List<double>();
            List<double> aSorted = new List<double>();


        // a label to allow us to easily loop back to the start if there are input issues
        start:
            Console.WriteLine("Enter a list of space-separated numbers");

            // read the space-separated string of numbers
            string sNumberString = Console.ReadLine();

            // split the string into the an array of strings which are the individual numbers
            string[] sNumbers = sNumberString.Split(' ');

            // initialize the size of the unsorted array to 0
            int nUnsortedLength = 0;

            // a double used for parsing the current array element
            double nThisNumber;

            // iterate through the array of number strings
            foreach (string sThisNumber in sNumbers)
            {
                // if the length of this string is 0 (ie. they typed 2 spaces in a row)
                if (sThisNumber.Length == 0)
                {
                    // skip it
                    continue;
                }

                try
                {
                    // try to parse the current string into a double
                    nThisNumber = double.Parse(sThisNumber);

                    // if it's successful, increment the number of unsorted numbers
                    ++nUnsortedLength;
                }
                catch
                {
                    // if an exception occurs
                    // indicate which number is invalid
                    Console.WriteLine($"Number #{nUnsortedLength + 1} is not a valid number.");

                    // loop back to the start
                    goto start;
                }
            }

            // now we know how many unsorted numbers there are
            // allocate the size of the unsorted array
            //aUnsorted = new double[nUnsortedLength];
            //dont need this because we made a list**

            // reset nUnsortedLength back to 0 to use as the index to store the numbers in the unsorted array
            nUnsortedLength = 0;
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
                aUnsorted.Add(nThisNumber); //this is how we add elements to a list**

                // increment the array index
                nUnsortedLength++;
            }

            string sAscDesc = "";

            // prompt for whether to sort ascending or descending
            Console.Write("Sort by (a)scending or (d)escending: ");
            sAscDesc = Console.ReadLine();


            // allocate the size of the sorted array
            //aSorted = new double[nUnsortedLength]; (we already made a list above**)

            aSorted = aUnsorted.GetRange(0, aUnsorted.Count);//gets the elements from the unsorted list all the way to to the last item within our underosted
                                                             //list and copies it into our sorted list** (always start from 0)**



            // declare delegate method variable
            LowestOrHighestFunction lowestOrHighest;

            // point the variable to the appropriate method to call based on user input
            if (sAscDesc.ToLower().StartsWith("a"))
            {
                aSorted.Sort(); //we can just use the built in sort instead of doing manually with array*
                //lowestOrHighest = new LowestOrHighestFunction(FindLowestValue);
            }
            else
            {
                aSorted.Sort();
                aSorted.Reverse(); //sort it first then remove it**
                //when we work with arrays but it is not built into it but the list class has it built into it**
                //lowestOrHighest = new LowestOrHighestFunction(FindHighestValue);
            }


            // start the sorted length at 0 to use as sorted index element
            int nSortedLength = 0;

            // while there are unsorted values to sort
            //no longer needed because we used a list**
            //while (aUnsorted.Length > 0)
            //{
            //    // store the lowest unsorted value as the next sorted value
            //    //aSorted[nSortedLength] = FindLowestValue(aUnsorted);
            //    //aSorted[nSortedLength] = FindHighestValue(aUnsorted);
            //
            //    // call the delegate method
            //    aSorted[nSortedLength] = lowestOrHighest(aUnsorted);
            //
            //    // remove the current sorted value
            //    RemoveUnsortedValue(aSorted[nSortedLength], ref aUnsorted);
            //
            //    // increment the number of values in the sorted array
            //    ++nSortedLength;
            //}


            // write the sorted array of numbers
            Console.WriteLine("The sorted list is: ");
            foreach (double thisNum in aSorted)
            {
                Console.Write($"{thisNum} ");
            }

            Console.WriteLine();
        }


        //these methods are not needed because we commented out the delegates and the list already does it for us**
        // find the lowest value in the array of ints
        // the method "signature" defines a method and consists of the return type (double) and method arguments (double[] array)
        static double FindLowestValue(double[] array)
        {
            // define return value
            double returnVal;

            // initialize to the first element in the array
            // (we must initialize to an array element)
            returnVal = array[0];

            // loop through the array
            foreach (double thisNum in array)
            {
                // if the current value is less than the saved lowest value
                if (thisNum < returnVal)
                {
                    // save this as the lowest value
                    returnVal = thisNum;
                }
            }

            // return the lowest value
            return (returnVal);
        }

        // find the highest value in the array of ints
        // the method "signature" defines a method and consists of the return type (double) and method arguments (double[] array)
        static double FindHighestValue(double[] array)
        {
            // define return value
            double returnVal;

            // initialize to the first element in the array
            // (we must initialize to an array element)
            returnVal = array[0];

            // loop through the array
            foreach (double thisNum in array)
            {
                // if the current value is greater than the saved highest value
                if (thisNum > returnVal)
                {
                    // save this as the highest value
                    returnVal = thisNum;
                }
            }

            // return the highest value
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
        static void RemoveUnsortedValue(double removeValue, ref double[] array)
        {
            // allocate a new array to hold 1 less value than the source array
            double[] newArray = new double[array.Length - 1];

            // we need a separate counter to index into the new array, 
            // since we are skipping a value in the source array
            int dest = 0;

            // the same value may occur multiple times in the array, so skip subsequent occurrences
            bool bAlreadyRemoved = false;

            // iterate through the source array
            foreach (double srcNumber in array)
            {
                // if this is the number to be removed and we didn't remove it yet
                if (srcNumber == removeValue && !bAlreadyRemoved)
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

            // set the ref array equal to the new array, which has the target number removed
            // this changes the variable in the calling function (aUnsorted in this case)
            array = newArray;
        }
    }
}
