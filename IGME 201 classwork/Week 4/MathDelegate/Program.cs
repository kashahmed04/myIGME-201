using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathDelegate
{
    /// delegate steps
    /// 1. define the delegate method data type based on the method signature
    ///         delegate double MathFunction(double n1, double n2); (when we base it on the method signature does that refer to the para. only or the return type as well)(yes)
    ///         (has to follow method signatire)
    /// 2. declare the delegate method variable
    ///         MathFunction processDivMult; (matfunction is a type and we are making a variable of that type and delegates are a data type so we use pascalcase
    ///         but we need variable of that type to do things)(the data type is like the mold for the variable and its the shape of that type (shape of a math function)
    /// 3. point the variable to the method that it should call (make a new delegate to hold the certain method but it has to have the same para. type and return type
    ///                                                          to work)
    ///         processDivMult = new MathFunction(Multiply); the new operator creates the new thing it's c# way of creating new objects and our mathfunction delegate
    ///                                                        had a constructor which is used to create it 
    ///                                                        (we want our variable to point to the multiply method and call our constructor for the mathfunction delegate)
    ///                                                        variable points to method we want to call and normally we want to do this because we dont know which method we
    ///                                                        are going to use when the program starts (may be a thousand different math functions we need to use)
    ///                                                        a constructor is a method in a class or structure and it has the same name in the class or structure
    ///                                                        we can have as many constructors as we want becase we can make their method signatures different
    ///                                                        so basically store each new mathfuncion in a variable and that will get used if needed
    ///                                                        
    ///                                                        we make sep. variables if we want to use another function bu has to have the same method signature and return
    ///                                                        as the delegate 
    ///                                                        we can make as many delegates as we want in an applicaiton
    /// 4. call the delegate method
    ///         nAnswer = processDivMult(n1, n2); (we store it in a variable because whatever this method returns we need to hold it) (which processdivmult are we reffering
    ///                                             we dont have to have a method that returns something and can have a delegate method that returns to that
    ///                                             use this appracoh usually
    ///                                             we use our variable as the method with the parameters and we store the answer in the variable because
    ///                                             we return it with whatever processdivmult is 
    ///                                             


    //delegates are just an example of how it works and we can just use a regular method if we want
    //with the memory game we need to use a delegate because we want it to do something if the timer is up

    // define a custom delegate data type whose variable can point to a method that
    // accepts 2 doubles and returns a double
    delegate double MathFunction(double n1, double n2); //method signature in this case for this type of delegate consisting of the delegeate and the return and the
    //name of the delegate and the para and their data types (this is used for the first way to make delegates (step 1 of 4)
    //what if the actual method does not have a return type are we allowed to put void because I know func does not allow it and we need a return type

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
            //by reference in this case (arrow functions are a list of instructions that we in memory and processdivmult points to that method instead and theres
            //no name associated with it but with methods we can call from anywhere, but with arrow functions, if we want to code to happen in another code block,
            //we have to copy and paste it again because the arrow function does not have a name)(within the code block we could call the arrow function as many times as 
            //we want though because its the only place defined(inefficent))


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
                //MathFunction processDivMult; //use this to declare a delegate (1st way) example of int varible; then insitializing it later like we did with lamda
            //when we use ref. variables we dont have to 
            //do we usually just decalre and not initizialize and then do it later with delegates like we did here
            //in this case our delegate was named Mathfunction and now we are declaring a varibale of that delegate processdivmult to hold an instance
            //of a method that has the same return type and para. types (step 2-4 for above approach)

            // use the built-in method delegate type that returns a value
            // the last type in the <> is the return data type
            //here is a second way to do deleagtes instead of making one, we use the built in one in c#, and it consists of the para.
            //type, and the very last value is the return type (cant have void usually have a datatype), func is the data type
            //and processdivmult is the variable 
            //last varlue in the <> are the return type 
            Func<double, double, double> processDivMult = null; //second way to dclare the delegate(set equal to null beforehand)(dont need the ? with the ref. dtaa types)

            // if the method does not return data, then use the Action<> generic delegate type
            //here is a third way of using a delegate (also built in like func), but we want to
            //not have a return type so we use action in these situations, after the <> after action and func.,
            //they are usually the variable that holds the method then we always put a method in there
            //by setting that variable equal to new action or func., then the para it takes in this case (in func. we would also have a return type in the <>,
            //then, the name of the method in () after the <> for both delegates
            //the only difference is that it does not take a return type 
            Action<double> outputAnswer;
            outputAnswer = new Action<double>(OutputAnswer);

            //func and action are also a way to use delegate methods, but are built in c# instead of using our own delegate like the first method
            //and arrow functions also counts as delgates even though we simplify it as much without the delegate keyword 
            //delegate means code that is called in place of something else 

            if (sOperation.ToLower().StartsWith("m"))
            {
                // we could of course simply call Multiply()
                //nAnswer = Multiply(nNum1, nNum2);

                // but let's use a delegate variable to call the intended method
                // because it's fun!  (and because it's used everywhere in UI development)

                // the most explicit approach using the 4 steps at the top
                //processDivMult  = new MathFunction(Multiply); (step 3-4 for above approach) this holds the instance of the multiply method
                

                // use the built-in C# generic template delegate type
                processDivMult = new Func<double, double, double>(Multiply);

                // or we can just set the variable to the method without using the constructor** (what is a constructor and prop. and differences)
                //this keyword is used for any field within a structure prop,varibales,etc.
                //the whole purpose of the constructor is to initaizlize all members of a structure and every value needs to be set with all the values in the
                //original structure (dont need need the prop. with code blocks to be initialized in the structure and as long as we have those code blocks, then we dont
                //have to intialzie it)(if we dont define a prop. that has a code block, then how does it know to use it when needed)**
                processDivMult = Multiply;

                // use an anonymous codeblock using the delegate keyword (another way to make a delegate)
                //(4th way to make a delegate, first is func, then action, then self defined delegate)
                processDivMult = delegate (double n1, double n2) //make the delegate variable in a variable (we claimed it above always claim the delegate then do it)
                //(delegates we dont tell it the return type over here because it not like a method),
                //after we store the return val and do the math adn return it and now the variable holds that
                //cant set a variable equal to it but we have to call it with the para. so it works and set it equal to var. so it works 
                //we usually create the delegate in namespcae so we can access it in whole file 
                {
                    double returnVal = 0;
                    returnVal = n1 * n2;
                    return returnVal; //if we dont do a return then we cant compile the code so always put return in lamda because our mathfunction
                    //returns a double because of our delgate  (C# keeps track of that)
                };

                // use an anonymous codeblock using the lambda operator "=>"
                //(basically replacing the delegate keyword with an arrow function)(how does it know)
                //its a delegate then we declared it up top
                processDivMult = (double n1, double n2) =>
                {
                    double returnVal = 0;
                    returnVal = n1 * n2;
                    return returnVal;
                };

                // abbreviate the lambda expression 
                //we take away the double and the delegate keyword but why could we take away the data type of the para. how would it know what to put in (we decalred it up
                //top with the mathfunction so it knows the datatypes)
                processDivMult = (n1, n2) =>
                {
                    double returnVal = 0;
                    returnVal = n1 * n2;
                    return returnVal;
                };

                // further abbreviate the lambda expression
                //its the actual variable that stores the whole function
                //and when we return now, we make a variable equal to the call and then it gets stored in there
                //cant define new datatypes within the main, but we can do it namespcae or class and cant be claimed in main or a method (can be accessible in main though)
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
                //nAnswer = Divide(nNum1, nNum2); regular function call
                //processDivMult = new MathFunction(Divide); delegate way (first approach) to use the divide but we are storing the divide within a variable now
                //we did not use it yet (we use when the user enters a d)
                //call the function divide with nanswer if its the user entered a d for division 
                processDivMult = new Func<double, double, double>(Divide); //calls divide 
                //first we create the func variable then this would be the second step to use it with the divide method
            }

            // call the method via the delegate variable
            nAnswer = processDivMult(nNum1, nNum2); //(step 4-4 for above approach)
            //processdivmult is based on if divide or multiply was called and its already set, we make the num1/num2 the para. (doubles) that the user put in**

            // use the Action<> delegate to output the answer
            //what about func**
            //for func and action first we make the variable that holds the method
            //then set the variable to a new func or action in () at the end put the method name, then call it at the very end based on variable that holds
            ////the certain method
            outputAnswer(nAnswer); //nanswer is the processdivmult whatever function its set equal to (mult or div)
                                   //and based on whatever the user puts in, it does the math
                                   //the the action delgate calls the output answer we defined up top for the action
                                   //and gives us the answer from processdivmult

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
