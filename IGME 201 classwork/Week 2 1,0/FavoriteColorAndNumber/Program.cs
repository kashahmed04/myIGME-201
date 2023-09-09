using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorsAndNumbers
{
    namespace Colors
    {
        enum EColors
        {
            red,
            orange,
            yellow,
            green,
            blue,
            indigo,
            violet
        }
    }

    namespace Numbers
    {
        enum ENumbers
        {
            one,
            two,
            three,
            four,
            five,
            six,
            seven
        }

    }
}

// upon creating a project VS creates a namespace with the same name
namespace FavoriteColorAndNumber
{
    // using statements can go just within a namespace or at the top of the file
    using ColorsAndNumbers.Colors;

    // we can define a namespace alias for more concise access
    using ColorsAlias = ColorsAndNumbers.Colors;

    // Class: Program
    // Author: David Schuh
    // Purpose: Console Read/Write and Exception-handling exercise
    // Restrictions: None
    // in code for Unit 1, always add "static" to any class definitions
    static internal class Program 
    {
        // Method: WriteMyVar (value variable version)
        // Purpose: Output a passed in number and change it
        // Restrictions: None
        // the method signature is the method name, return type (void in this case, which means it does not return a value) and the list of parameters that are passed to the method
        static void WriteMyVar(int nParameter)
        {
            Console.WriteLine(nParameter);

            // nParameter is simply a copy of myInt
            // this only changes the local nParameter variable
            nParameter = 42;
        }

        // Method: WriteMyVar (reference variable version)
        // Purpose: Output a passed in number and change it
        // Restrictions: None
        // in Unit 1, all methods must be "static"
        // note that you can have multiple versions of the same method name, but they must differ in their signature
        static void WriteMyVar(ref int nParameter)
        {
            Console.WriteLine(nParameter);

            // nParameter is pointing to myInt like a mirror
            // note that this changes the variable in the code that called this method
            nParameter = 42;
        }

        static int WriteMyVarFunc(int nParameter) //method declarations should be in the same line indentation like main
        {
            Console.WriteLine(nParameter);

            // nParameter is pointing to myInt like a mirror
            // note that this changes the variable in the code that called this method
            nParameter = 42;

            return( 42 ); //we return the data from the return statment if we want to use it outside the method
            //we usually make methods in this program class because if we made it in main and had a return statement, 
            //then it would exit the main because it's a method
        }

        // Method: Main
        // Purpose: Prompt the user for their favorite color and number
        //          Output their favorite color (in limited text colors) their favorite number of times
        //          ALWAYS start coding by writing pseudocode comments in English (or your native language) to make
        //          the steps as detailed as possible, then go back and write the C# for each comment
        // Restrictions: None
        static void Main(string[] args)
        {
            // we can access other namespaces by walking through their lineage
            // so to access EColors, we use the dot to unlock each namespace "gate"
            ColorsAndNumbers.Colors.EColors eColors1;

            // or via the above using statement, we can avoid the prefixes
            EColors eColors2;

            // or via the above namespace alias, we can be more explicit
            ColorsAlias.EColors eColors3;

            // always define your variables and initialize them at the top of your methods
            // strings can be set to null, which means the string does not exist yet
            string sFavoriteColor = null;
            string sFavoriteNumber = "";

            // all other value data types can NOT be set to null
            int myInt = 0;
            int anotherInt = 2;

            // int is the alias for Int32
            // 32 indicates the variable uses 32 bits to store the value, therefore it has 2^32 possible values

            // unless you add the ? after the data type
            // this is useful because whatever value you initialize the variable to, might be someone's favorite number
            // so you cannot tell if they entered the number yet
            int? nFavoriteNumber = null;

            // the boolean data type can be true or false
            bool bValid = false;
            
            // bool is the alias for Boolean

            // Console.WriteLine() outputs text to the console and adds a newline character (\n)
            Console.WriteLine("Hello");  // this will output "Hello\n"

            // Console.Write() does not add the newline character

            // value variables copy the contents from one variable to another
            // anotherInt will be 0
            anotherInt = myInt;

            // pass myInt by value (ie. make a copy of it in the method)
            WriteMyVar(myInt);

            // myInt will still be 0 here

            // pass myInt by reference (ie. the method parameter points back to myInt like a mirror)
            WriteMyVar(ref myInt);

            // myInt will be 42 here because WriteMyVar() changed it via the reference variable


            // Three types of errors(examples)**
            // 1. syntax errors (missing semi), doing math operations within a string, scope
            // 2. logical (code works but doesn't do the right thing), lcv is too short, incrementing too many times
            // 3. run-time errors (code crashes!), dividing by 0 or converting a string to a number and the string is not a number**

            // PE-2 example:  comment the original code, document the error type and description, fix the code
            // prompt the user for their favorite color
            //Console.Write("Hello!  Please enter your favorite color: ")
            // this was a syntax error as it was missing the semicolon
            Console.Write("Hello!  Please enter your favorite color: ");

            // initialize favorite color to empty string to check for valid entry
            sFavoriteColor = "";

            while (sFavoriteColor == "" )
            {
                // read the favorite color from the user and store it in a variable
                sFavoriteColor = Console.ReadLine();

                if( sFavoriteColor == "" )
                {
                    Console.WriteLine("Enter a color"); //if the input is nothing then it asks again, but what if it's a number or
                    //something thats not a color**
                }

            }



            // prompt the user for their favorite number
            Console.Write("Please enter your favorite number: ");

            // read their favorite number into a variable
            // Console.ReadLine() only can return strings
            sFavoriteNumber = Console.ReadLine();

            // the while loop checks the condition before running even once
            // it will not run if nFavoriteNumber is not null
            while (nFavoriteNumber == null)
            {
                try
                {
                    // Convert will raise an exception if it cannot convert the string to a number
                    // so we need try/catch
                    nFavoriteNumber = Convert.ToInt32(sFavoriteNumber);
                }
                catch
                {
                    Console.WriteLine("Please enter an integer.");
                    sFavoriteNumber = Console.ReadLine();
                }
            }

            //cant write methods outside a class, they alwways have to be in a class
            //use public for method names and variables defined within a class to access it outside of it**
            //compile error will not let code run while logic error will let the code run but it wiuld be logically incorrect
            //Consle.WriteLine("here") is a syntax error but if we mistype the string then its a logic error 
            // the do/while loop always runs at least once because it checks the while condition at the end
            //basically a backwards while loop except it always runs once no matter what 
            //for fabulous question we need to still do the .notation because its super.smashing.great to access whoever is sitting in the house
            //even if we have a 100 name spaces deep within another namepscae we still access it the same way 
            //is there a certain situation where we would want to use this instead of a regular loop (usually use it for any appliacation that asks
            //for user input and we can check if they entered valid data or not and ask them again if they did not enter valid information
            //usually used when we have to do something once 
            //if we do a variable ++ within a loop for example, it would take longer but not that long (nanosecond)(but we should put it before like ++ varible))
            //we usually initizlize variables and not just declare them and initizilaize later (we should initizialize while we declare and if we just declare then
            //the variable would be equal to 0 if its an int. but if its a str. it initizializes to null
            do
            {
                sFavoriteNumber = Console.ReadLine();//cant we also put read line into the catch statemnent or do we need it here(we can but we also
                //have to put the readline above the do so it can read it the first time then do it in the catch but if we did it like this then
                //it would ask the user for an int. then it would come back yp and read it

                try
                {
                    nFavoriteNumber = Convert.ToInt32(sFavoriteNumber); //common way to convert to an int. or is there a better way we should use
                    //tryparse is the cleanest one we should use and we dont need the try catch for it so we should usually use that
                }
                catch
                {
                    Console.WriteLine("Please enter an integer.");
                    
                }

            } while (nFavoriteNumber == null);


            do
            {
                sFavoriteNumber = Console.ReadLine();

                try
                {
                    // adding strings just adds the characters together, it does not treat the string as numbers, even if they contain numbers
                    // sFavoriteNumber = "42";
                    // sFavoriteNumber + sFavoriteNumber != 84, it is equal to "4242"
                    // sFavoriteNumber.Length = 2  the Length property of the string is the number of characters in the string

                    // int.Parse() does the same as Convert.ToInt32()
                    nFavoriteNumber = int.Parse(sFavoriteNumber); //if we used "42" for example, since it's a number it would convert it to an int.
                    //but if it's "42hi" then it will not because there are letters within it (run time error because it makes the program crash when trying to convert)
                    //loop that is infinite is usually a logic error but eventually when it crashes its a run time error because it will run out of memory 
                    //int.,str., everything is basically an object in c#
                    //with parsing which data types can we convert to with it (int.,float, and the data types in the
                    ////data type conversion code and the enumerated types also have a parse to get it to the index of the value in the list)
                }   //parse is usually doing string to another data type 
                catch
                {
                    Console.WriteLine("Please enter an integer.");

                }

            } while (nFavoriteNumber == null);

            int nFavoriteNumberInt = 0;
            do
            {
                sFavoriteNumber = Console.ReadLine();

                // int.TryParse() tries to parse it and returns true if it was able to parse it to the certain datatype, and false if it was not successful
                // it does not raise an exception if it fails
                // so we need to save the return value of whether it was successful
                // and we pass the int as an output variable, which behaves the same as a reference variable,
                // but is used when we only care about the output value.  Note that the TryParse() method signature expects an int, not an int?**
                // so we need a new variable defined, nFavoriteNumberInt, to pass to it
                // TryParse() is preferable because we do not need the complexity of try/catch
                bValid = int.TryParse(sFavoriteNumber, out nFavoriteNumberInt);
                //Tryprase takes ths str. and tries to convert it and the out is basically the value that is set equal to the thing that it
                //converted and it reutursn true or false if it was converted and the first, para. is basically the thing we are converting and the new
                //converted value will be stored in the out varible (usually declare and initialize the out variable outside of this so we can use it here
                //to substitute in)
                //out is a ref. keyword which means we only care about its output value and not the value we initizliaed it to in the start
                //ref. can access the value of the var. thats passed in but if its out, then we cant use the value thats passed in and cant even look at it and
                //the whole point of out is changing the value first then using it while ref. we can see it whenever and change it whenver 

                // check the return value for valid input
                // the "!" is the boolean "not" operator
                if (!bValid) //if its true it would say if not true which is false and the if statment/loop does not run on a false
                             ////condition in general so if it was false it would say not false which is true making us go into the if statement in
                             /////general and the while loop in general
                // it is the same as
                //if (bValid == false)
                {
                    Console.WriteLine("Please enter an integer.");

                }

                else
                {
                    nFavoriteNumber = nFavoriteNumberInt;
                } 
            } while (nFavoriteNumber == null);

            // be sure our variables are set to the same value
            nFavoriteNumber = nFavoriteNumberInt;


            // code blocks and variable scope
            {
                // we cannot create a variable with the same name as is already defined in a parent code block
                // int myInt = 5;
                //If we define a variable in a child then after outside in the parent, we still can't do that even though we initialized it after the child
                //and not before
                //if it's in the same level but completely different code blocks (ex. 4th tab in for both), then we can create mystring for example, and
                //it would be 2 different variables 

                int myInt2 = 0;

                {
                    // myInt is defined in the parent code block line #119ish, so we have access to it
                    myInt = 3;
                    myInt = 5;

                    // myInt2 is defined in the parent code block at line #292 so we have access to it
                    myInt2 = 89;

                    // we can create new variables in this code block
                    string myString = "";
                }

                // but it is not accessible outside of the code block
                //myString = "David";

                // but myInt2 is still available
                myInt2 = 90;

                //so basically if we make it in the parent we can access it anywhere even inside the child and change it then
                //access the changed variable outside the child
                //but if we define it in the child we can't use it in the parent outside because of scope

            }

            // return favorite color as lower case
            // BUT this won't change the string contents because toLower makes a copy of the string (value data type)
            sFavoriteColor.ToLower();

            // we would need to set sFavoriteColor equal to the return value of ToLower() to change it
            //sFavoriteColor = sFavoriteColor.ToLower();

            
            //how to know when to use switch statements.vs.if else statments**
            // change the console output color to match their fav color
            switch (sFavoriteColor.ToLower()) //switch is used to compare a statement or output to see the possible options there is
                //and give a proper action for that option chosen
            {
                case "red":
                // without the ToLower() we would have to check every case permutation
                //case "RED":
                //case "Red":
                //case "rEd":
                //case "reD":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
            
                case "blue":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
            
                case "green":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
            
                default:
                    Console.ForegroundColor = ConsoleColor.White; //usually put a default just in case (but its optional and nothing
                    //happens and it just leaves statement if no condition matches)
                    break; //break statements are required even for the last statement (syntax error if we dont)
                    //to autofill code for us press tab 
                    //shift alt then let go then do the "/" to make a bunch a comment 
            }
            
            // the switch statement is similar to an if... then... else if... then... else
            // note how much more work is involved to do the same code as the string needs to be lowercased everytime
            // double equals is used to test for equality in C#
            //    if (sFavoriteColor.ToLower() == "red")
            //    {
            //        Console.ForegroundColor = ConsoleColor.Red;
            //    }
            //    else if (sFavoriteColor.ToLower() == "blue")
            //    {
            //        Console.ForegroundColor = ConsoleColor.Blue;
            //    }
            //    else if (sFavoriteColor.ToLower() == "green")
            //    {
            //        Console.ForegroundColor = ConsoleColor.Green;
            //    }
            //    else
            //    {
            //        Console.ForegroundColor = ConsoleColor.White;
            //    }


            // incrementer operator, prefixed or postfixed
            int y = 0;
            int x = 5;

            // prefixed (placed before the variable)
            //y = ++x;  // x = 6,   y = 6

            // postfixed (placed after the variable)
            //y = x++;  // y = 5,   x = 6


            // a loop that outputs their fav color, their fav num times
            // use a for(initialization;condition;operation) loop to output their favorite color the number of times as their favorite number
            // The three statements within the for() statement:
            //      1. initialization statement(s):  (i = 0) any variable initialization
            //          Note that this can include multiple comma-separated statements.
            //              For example:   for( i=0, y=0, color=Console.ReadLine(); i < favNum; ++i)
            //
            //      2. condition check:  (i < favNum) what to check at the beginning of the loop each time it loops (including the first time)
                    //usually use boolean operators wtih multiple variables like and and or the or 
            //
            //      3. operation: (++i)  any operations to execute upon each subsequent start of the loop (not including the first time)
            //          Note that this can include multiple comma-separated statements.
            //              For example:   for( i=0, y=0, color=Console.ReadLine(); i < favNum; ++i, ++y)
            //
            //          Note that using the "continue" statement to return to the top of the loop will execute the operation statement(s)
            //          so that if you need to do something N times, you may have to --i before the "continue" to repeat the same value of i. 
                        //for loop talking about temp. if its cold, we want to stop and wait until its hotter and when we go back to the top
                        //of the loop, and incremeent basically a retry to see if we can skip the contintue statement, after if we skip the
                        //continue then we can incremeent and keep going about the code but if we do the continue we need a rettry so we decrement
                        //then increment againn



                        //& = bitwise and operator
                        //| = bitwise or operator 
                        //the and and as well as the or or only checks the one ex. true or == true or false and = false
                        //and the single ones check both the values before 
                        //on the operations it evaluates from left to right and not highest to lowest based from left to right 
                        //unary is the sign of the number being pos. or neg.
                        //usually use the double symbols 
            //
            for ( int i = 0; i < nFavoriteNumber;  ++i)
            {
                // different ways to generate output
                // appending strings using the "+" operator what about ,**
                Console.WriteLine("Your favorite color is " + sFavoriteColor + "!");

                // embedding code blocks using string interpolation**
                Console.WriteLine($"Your favorite color is {sFavoriteColor + "!"}");

                // substituting numbered tokens with comma-separated arguments
                Console.WriteLine("Your {0} favorite color is {1}{2}", "most", sFavoriteColor, "!");

                //which way is printing to the console more common or better**

                // what does this line output?
                //Console.WriteLine("5 + 5 = " + x + x);
                // C# is implicitly doing the following: implicitly (in the background or under the hood without telling us)**
                //Console.WriteLine("5 + 5 = " + x.ToString() + x.ToString());

                // use parentheses to change order of operation to get correct result
                //Console.WriteLine("5 + 5 = " + (x + x));
            }

            // we may want to set the foreground color back to white for the rest of the application
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Great!");
        }
    }
}



//Definitions
//continue ends the current loop and goes back up to the condition then increments i then checks the condition
//return exits the whole loop and method
//break exits the loop only, not the method 
//goto allows us to jump out of our loop if we wanted (or not) and go to
//a specific area outside of our loop (or within our loop)
