using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




/*  
 *  Dictionaies and lists and recursion with factorial 
 
 */
namespace Week_5_1._0
{

    static internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dPersonAge = new Dictionary<string, int>();
            //has a key to look up values within the list (like a word decitionary and the word is the key, and the definition is the value)
            //the key is normally a string (in this case the lookup (key) is the name and the value it will return will be the age)
            //when we construct the data type on the rght hand side of = side, then it creates the constrctor with the new keyword and the () (This can also*****
            //be considered the instance of the object (dict) right?)*****

            //Dictionary<string,StudentStruct> dStudent = new Dictionary<string,Stidentstruct>();

            //dPersonAge.Add("sue", 84);//if we added sue first, then david below then sue would be first because there is no order
            //dStudent.Add("Max",maxStudent); //this would add the name and their structure to our dictionairy and we could read their student record using the index of max which
            //is the key 
            //or this way dStudent["Max"] = maxStudent (both the same)
            dPersonAge["david"] = 50; //this is how we store a key in the [] and the value after the = usually

            //we xcan use add which takes the para. of the dictionatry we put in
            //dPersonAge.Add("sue", 84); //dictionaries can store a mix of datatypes as well as structs and enums and classes (same for lists)

            //the key is always unique in dicitonaries 
            dPersonAge.Add("sue", 84); //if we attemtp to do this we get a run time error within the code because its the same key and does not matter if its a diffrent value
            //cant add the same key twice but we can with value

            dPersonAge["david"] = 60; //we cna change the entires though (value), but not the keys

            foreach (KeyValuePair<string, int> valuePair in dPersonAge) //goes through all the keys and values in the dict.
                //always use the keyvalue pair and name in then go through the dict 
            {
                Console.WriteLine($"person[{valuePair.Key}] = {valuePair.Value}"); //dict. are not sorted when we add our items in and they are stored in the order we add them
            }

            SortedList<string,int> personAge = new SortedList<string, int>(); //sorts the values in the dict and we can have key value pairs in lists??
            //dPersonAge.Add("sue", 84); //this is how we created a sorted list as we put the values in so it gets stored 
            dPersonAge["david"] = 50; 
            personAge["joe"] = 80;
            //personAge["poe"] = 80;



            //if we want to remove an item then do this and do it by the key always
            //values can repeat in a dict.
            personAge.Remove("joe");
            foreach (KeyValuePair<string, int> valuePair in personAge)
            {
                Console.WriteLine($"person[{valuePair.Key}] = {valuePair.Value}");
            } //joe does not show up here anymore because we removed him from the sorted list

            //the dict. lets us read the list(dict). using a name and we can access it quicker by saying the key and indexing rather than if it was a list we would
            //have to read through all the students then (with dict. we can index through a key not a number)

            //the dict and srtoedList allows us to access the key to get to their data instead of using an index and looping through to find a value instead

            //list,dict.,and srtoed list is the dattypes we will be using as well



            //recursion with factorial
            //0! is 1 
            string sNumber = null; //read in string from user
            int nNumber = 0; //read in the value
            int nAnswer = 0; 

            do
            {
                Console.WriteLine("Enter a positive integer: "); //facortial only works with pos. valeus
                sNumber = Console.ReadLine();

            }while(!int.TryParse(sNumber, out nNumber) && nNumber >= 0);

            nAnswer = 1;
            while(nNumber > 0) //factorial is like 4*3*2*1 (multilpes all of the numbers before the number we put in an multiply it)**
            {
                nAnswer *= nNumber; //was this a way of doing the same thing but non recursive**
                --nNumber; 
            }

      

            nAnswer = Factorial(nNumber);


            double a1 = Average(2, 1, 3, 4, 5, 3, 2, 1, 23); //this is the list and it gets stored in the array with the params
            double a2 = Average(1, 2, 3, 5, 6, 2, 3, 4, 5);

        }

        static double Average(int nRoundTo, params int[] aInt) //params. lets us pass a list to the method and put it at the end because its inifinte amount of values it can hold
        {
            double avg = 0; //make this a double so we cna average 
            int sum = 0;
            foreach(int i in aInt)
            {
                sum += i; 

            }
            avg = Math.Round((double)sum / aInt.Length, nRoundTo);

            return avg;
        }

        static int Factorial(int nNumber) //a recursion calls itselt to calculate the factorial (multiplying each number by the next number below it)**
        {
            int nAnswer = 1;

            if (nNumber == 0)
            {
                nAnswer = 1;
            }
            else
            {


                nAnswer = nNumber * Factorial(nNumber - 1); //takes our current number and multiply it by our next value which is n - 1 and keeps going by
                                                            //calling itself but its in an inifinite loop so we need a base case so it can stop inifinite looping and it can stop recusing**
                
            }
            return (nAnswer);

           
        }
        //Factorial(2) = 2 * f(1) //it comes in and does the else statment for the first loop and it waits for the answer for the first time it calls itself and now:
        //Factorial(1) = 1 * f(0) //and now it has been called twice and its called itself again and does the math and now its waiting in the else nAswer for another answer
        //
        //Factorial(0) = 1 //now we reach 0 and it returns 1 and it gets passed to the facotrial of 1 case and now it can complete its work for f(1)
        //
        //Factorail(1) = 1 * 1 = 1 //we can now do the math to get an answer
        //
        //Factorial(2) = 2 * 1 = 2 //when the method calls itself it launces a new instance of itself and it spawns a new instance of the method running 
            //its making a copy of itself to continue doing the work in the else and when it got the answer we are no longer waiting and it can return the answer of 2 back to
            //the calling line in

            //when they call themselves they make a copy of themself then wait for base case then do the math and return final answer after every recursion

            //it always goes 1 more then the factorial deep because of the base case of 0
            //its very important to have a base case or we will have an infinite loop
    }
}
