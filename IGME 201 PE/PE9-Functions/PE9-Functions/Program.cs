using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PE9_Functions
{

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
            //is this how we do it because we did not go over this****(5)
        {

            double totalPrice = count * cost;
            return totalPrice; 
            //can we define variables in here why cant we use
            // a field for it*****(6)
        }
        public string StringTotal(int count, string item, int cost)
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
    ///  
    static internal class Program //structs and enums can be set within the namespace
        //or class right but not within the main**(7)
    {

        delegate string Readline();
        static string Input()
        { 
            return Console.ReadLine();
        }
        static void Main(string[] args) //is this ok and how to use delegates**(8)
        {
            string userInputRead = "";
            Readline userInput;
            userInput = new Readline(Input);
            userInputRead = userInput();

        }
    }
}



﻿
