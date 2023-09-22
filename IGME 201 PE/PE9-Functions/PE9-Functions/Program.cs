using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PE9_Functions
{

    // Struct: Order
    // Author: Kashaf Ahmed
    // Purpose: Has fields and 2 methods, 1 that returns the cost of the total items bought as well as
    //returning to the console the information the user had entered in as well as the calculation of the price
    //based on the OrderTotal method
    // Restrictions: None
    struct Order
    { 
        public string itemName;
        public int unitCount;
        public double unitCost;
        public double OrderTotal (int count, double cost)
            //I was really confused on this question****
            //why do we have to name the para. the same as the fields****(1)
            //and redefine the data type*****(2)
            //should we put sttaic here****(3)
            //should we make methods public within a struct****(4)
            //is this how we do it****(5)
        {

            //double totalPrice = count * cost;
            return count * cost;  //becomes implicitly casted to a double when the mult.
            //can we define variables in here why cant we use
            // a field for it*****(6)
        }
        public string StringTotal(int count, string item, double cost)
        {
            count.ToString();
            cost.ToString();
            return(count + " " + item + " items at " + "$" + cost +
                " each, " + "total cost " + "$" + OrderTotal(count,cost));
        }
    }





    /// delegate steps
    /// 1. define the delegate method data type based on the method signature
    ///         delegate double MathFunction(double n1, double n2);
    /// 2. declare the delegate method variable
    ///         MathFunction processDivMult;
    /// 3. point the variable to the method that it should call
    ///         processDivMult = new MathFunction(Multiply);
    /// 4. call the delegate method / add the delegate method to the object's event handler** go over this step
    ///         nAnswer = processDivMult(n1, n2); 


    // Class: Program
    // Author: Kashaf Ahmed
    // Purpose: Create a delegate for reading in user input 
    // Restrictions: None
    static internal class Program //structs and enums can be set within the namespace
        //or class right but not within the main**(7)
    {
       

        delegate string Readline();
        static string Input()
        {
            return Console.ReadLine();
        }

        // Method: Main()
        // Purpose: Create a delegate for reading in user input 
        // Restrictions: None
        static void Main(string[] args) //is this ok and how to use delegates**(8)
        {
            string userInputRead = "";
            Readline userInput;
            userInput = new Readline(Input);
            userInputRead = userInput();


            //if no constructor then we ref. the structure like this otherwise if there is constructors then we have the ()******(9)

            //Order randomVal = new Order(); 
            //randomVal.itemName = "something";
            //randomVal.unitCount = 2;
            //randomVal.unitCost = 1.50;
            //Console.WriteLine(randomVal.StringTotal(randomVal.unitCount, randomVal.itemName, randomVal.unitCost));
        }
    }
}



﻿
