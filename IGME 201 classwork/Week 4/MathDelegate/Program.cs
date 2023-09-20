using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathDelegate
{
    /// delegate steps
    /// 1. define the delegate method data type based on the method signature
    ///         delegate double MathFunction(double n1, double n2); (when we base it on the method signature does that refer to the para. only or the return type as well**)
    /// 2. declare the delegate method variable
    ///         MathFunction processDivMult; (we create a variable to hold a method or an object of the delegate class??**)
    /// 3. point the variable to the method that it should call (make a new delegate to hold the certain method but it has to have the same para. type and return type
    ///                                                          to work)**
    ///         processDivMult = new MathFunction(Multiply);
    /// 4. call the delegate method
    ///         nAnswer = processDivMult(n1, n2); (we store it in a variable because whatever this method returns we need to hold it)**(which processdivmult are we reffering
    ///                                             to in this case in the code)**(does it have to have a return statement for the method we store every time we use this delegate 
    ///                                             type of method**)
    ///                                             **which type of delegate method should we use or is perferred**
    ///                                             


    //why use delegets when we can have regular methods and when is the case where we would have to copy functions over and over again** what is the scope of delegates**

    // define a custom delegate data type whose variable can point to a method that
    // accepts 2 doubles and returns a double
    delegate double MathFunction(double n1, double n2); //method signature in this case for this type of delegate consisting of the delegeate and the return and the**
    //name of the delegate and the para and their data types** (this is used for the first way to make delegates (step 1 of 4)**
    //what if the actual method does not have a return type are we allowed to put void because I know func does not allow it and we need a return type**

    internal class Program
    {
        static void Main(string[] args)
        {
            string sNumber = null;
            string sOperation = null;

            double nNum1 = 0;
            double nNum2 = 0;
            double nAnswer = 0;

            int[] aInt = new int[5];
            int[] bInt;

            bInt = aInt;
            //was this part here basically shoowing how we can call by ref. here because its an object (ref. data type), but when its value data types
            //like variables we cant do that and it would be call by value and in this case, for delegates and arrow functions they are calling a method
            //by reference in this case**


            // prompt and convert first number
            do
            {
                Console.Write("Enter a number: ");
                sNumber = Console.ReadLine();
            } while (!double.TryParse(sNumber, out nNum1));

            // prompt and convert second number
            do
            {
                Console.Write("Enter another number: ");
                sNumber = Console.ReadLine();
            } while (!double.TryParse(sNumber, out nNum2));

            // prompt for operation
            do
            {
                Console.Write("Multiply or Divide: ");
                sOperation = Console.ReadLine();
            } while (!sOperation.ToLower().StartsWith("m") &&
                     !sOperation.ToLower().StartsWith("d"));

            // declare a variable of our custom delegate type
            //MathFunction processDivMult; //do we usually just decalre and not initizialize and then do it later with delegates like we did here**
            //in this case our delegate was named Mathfunction and now we are declaring a varibale of that delegate processdivmult to hold an instance**
            //of a method that has the same return type and para. types (step 2-4 for above approach)****

            // use the built-in method delegate type that returns a value
            // the last type in the <> is the return data type
            //here is a second way to do deleagtes instead of making one, we use the built in one in c#, and it consists of the para.**
            //type, and the very last value is the return type (cant have void usually have a datatype), then the variable that will**
            //contain the method we want to use with the func delegate**
            Func<double, double, double> processDivMult;

            // if the method does not return data, then use the Action<> generic delegate type
            //here is a third way of using a delegate (also built in like func), but we want to**
            //not have a return type so we use action in these situations, after the <> after action and func.,*
            //they are usually the variable that holds the method then we always put a method in there**
            //by setting that variable equal to new action or func., then the para it takes in this case (in func. we would also have a return type in the <>,**
            //then, the name of the method in () after the <> for both delegates**
            Action<double> outputAnswer;
            outputAnswer = new Action<double>(OutputAnswer);

            //func and action are also a way to use delegate methods, but are built in c# instead of using our own delegate like the first method**

            if (sOperation.ToLower().StartsWith("m"))
            {
                // we could of course simply call Multiply()
                //nAnswer = Multiply(nNum1, nNum2);

                // but let's use a delegate variable to call the intended method
                // because it's fun!  (and because it's used everywhere in UI development)

                // the most explicit approach using the 4 steps at the top
                //processDivMult  = new MathFunction(Multiply); (step 3-4 for above approach) this holds the instance of the multiply method
                ////using the delegate stored in a variable because****

                // use the built-in C# generic template delegate type
                processDivMult = new Func<double, double, double>(Multiply);

                // or we can just set the variable to the method without using the constructor** (what is a constructor and prop. and differences)*****
                processDivMult = Multiply;

                // use an anonymous codeblock using the delegate keyword (is this another way to make a delegate or just a way to make a local function to a vairable)**
                //(4th way to make delegate???? or 4th method????)**
                processDivMult = delegate (double n1, double n2) //make the delegate variable in a variable (why not claim data type here when we make our variables and above**
                //then have the para. (what about return type)**, after we store the return val and do the math adn return it and now the variable holds that
                //and we can use it anywhere if it was made in a parent code block*****
                //how to know the scope of a delegate*****
                {
                    double returnVal = 0;
                    returnVal = n1 * n2;
                    return returnVal;
                };

                // use an anonymous codeblock using the lambda operator "=>"
                //(basically replacing the delegate keyword with an arrow function)(how does it know
                //its a delegate then**
                processDivMult = (double n1, double n2) =>
                {
                    double returnVal = 0;
                    returnVal = n1 * n2;
                    return returnVal;
                };

                // abbreviate the lambda expression 
                //we take away the double and the delegate keyword but why could we take away the data type of the para. how would it know what to put in**
                processDivMult = (n1, n2) =>
                {
                    double returnVal = 0;
                    returnVal = n1 * n2;
                    return returnVal;
                };

                // further abbreviate the lambda expression
                //instead of having a variable be stored inside the arrow function (only local to that arrow function and nowhere outside unless**
                //its the actual variable that stores the whole function**
                //and when we return now, the processdivmult holds the variable**
                //how do we know to keep copying and pasting if we want to use the same method in arrow functions**(same for delegates**)
                processDivMult = (n1, n2) =>
                {
                    return n1 * n2;
                };

                // most abstruse abbreviation of the lambda expression
                // please don't write this code!
                // the goal is always to write code that documents itself as much as possible
                //instead of return we put it right after the arrow (no return keyword needed in this case or the {}**
                processDivMult = (n1, n2) => n1 * n2;
            }
            else
            {
                //nAnswer = Divide(nNum1, nNum2); regular function call**
                //processDivMult = new MathFunction(Divide); delegate way (first approach) to use the divide but we are storing the divide within a variable now**
                //we did not use it yet**
                //why did we need the second step if we were going to set the variable equal to a new math function regardless**(ex. mathfunction processdivmult)**
                processDivMult = new Func<double, double, double>(Divide);
                //first we create the func variable then this would be the second step to use it with the divide method**
            }

            // call the method via the delegate variable
            nAnswer = processDivMult(nNum1, nNum2); //(step 4-4 for above approach)**
            //processdivmult is based on if divide or multiply was called and its already set, we make the num1/num2 the para. (doubles) that the user put in**

            // use the Action<> delegate to output the answer
            //what about func**
            //for func and action first we make the variable that holds the method**
            //then set the variable to a new func or action in () at the end put the method name, then call it at the very end based on variable that holds
            ////the certain method**
            outputAnswer(nAnswer); //nanswer is the processdivmult whatever function its set equal to (mult or div)**
                                   //and based on whatever the user puts in, it does the math**
                                   //the the action delgate calls the output answer we defined up top for the action**
                                   //and gives us the answer from processdivmult**

        }

        static void OutputAnswer(double dAnswer)
        {
            Console.WriteLine("The answer is: {0}", dAnswer);
        }


        static double Multiply(double num1, double num2)
        {
            return num1 * num2;
        }

        static double Divide(double num1, double num2)
        {
            return num1 / num2;
        }

        static double Sum(double n1, double n2, double n3)
        {
            return n1 + n2 + n3;
        }

    }
}
