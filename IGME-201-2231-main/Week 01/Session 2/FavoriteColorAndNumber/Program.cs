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
    using System.ComponentModel;

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
            //changes myInt from 0 to 42 because its calling it by ref. instead of by value which in that case
            //would have made a copy and myint would have remained 0 outside the method but inside it would have been 42
            //why do we have to put ref. as the parameter and argument (because we know we want to call the second method with the ref and not the
            //first one without the ref.)
            //(also if we call by reference dont we have to have a return statement)
            nParameter = 42;
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
            ColorsAndNumbers.Colors.EColors eColors1 = EColors.blue; //these all lead to Ecolors now since we have access to it but if we want a specific
            //color we have to say that from Ecolors give us this color with . notation (cant just say blue) (yes)

            // or via the above using statement, we can avoid the prefixes
            EColors eColors2 = EColors.red; //how would we index a value**

            // or via the above namespace alias, we can be more explicit
            ColorsAlias.EColors eColors3 = EColors.orange;

            //dont have to worry about these because we only will be using 1 namespace per file

            // always define your variables and initialize them at the top of your methods
            // strings can be set to null or "" (usually use null if we are going to check their input meaning they have not put anything yet and stay in if
            //they dont put anything and that if they did not type anything (""), then it tells the user to enter it again and set the color to null again to go
            //through the loop again (usually use an empty string) while loop starting off with empty string and if the string is still empty then we ask again for the color
            //and get input then check again**
            string sFavoriteColor = null;
            string sFavoriteNumber = "";

            // all other value data types can NOT be set to null
            int myInt = 0;
            int anotherInt = 2;

            // int is the alias for Int32
            // 32 indicates the variable uses 32 bits to store the value, therefore it has 2^32 possible values

            // add the ? after the data type for all other data types we initialize minus string
            // this is useful because whatever value you initialize the variable to, might be someone's favorite number ex. when we put in 0**
            // so you cannot tell if they entered the number yet
            int? nFavoriteNumber = null;

            // the boolean data type can be true or false
            bool bValid = false;
            
            //string hi = "hi"; over here, we could replace var. if they are the same datatype
            //hi = "no";
            //Console.WriteLine(hi);

            // bool is the alias for Boolean

            // Console.WriteLine() outputs text to the console and adds a newline character (\n)
            Console.WriteLine("Hello");  // this will output "Hello\n"

            // Console.Write() does not add the newline character

            // value variables copy the contents from one variable to another
            // anotherInt will be 0
            //in that case if we modify anotherInt then it wont effect myInt because it made a copy (call by value)
            //any value data types we can set equal directly and it would be call by value 
            anotherInt = myInt;

            // pass myInt by value (ie. make a copy of it in the method)
            WriteMyVar(myInt);

            // myInt will still be 0 here

            // pass myInt by reference (ie. the method parameter points back to myInt like a mirror)
            WriteMyVar(ref myInt); 

            // myInt will be 42 here because WriteMyVar() changed it via the reference variable (dont we have to do a return statement for that to happen)
            //when we have a return statement store the function call into a variable so we dont lose the return statment value


            // Three types of errors
            // 1. syntax errors (missing semi)
            // 2. logical (code works but doesn't do the right thing)
            // 3. run-time errors (code crashes!)

            // PE-2 example:  comment the original code, document the error type and description, fix the code
            // prompt the user for their favorite color
            //Console.Write("Hello!  Please enter your favorite color: ")
            // this was a syntax error as it was missing the semicolon
            Console.Write("Hello!  Please enter your favorite color: ");

            // read the favorite color from the user and store it in a variable
            sFavoriteColor = Console.ReadLine();

            // prompt the user for their favorite number
            Console.Write("Please enter your favorite number: ");

            // read their favorite number into a variable
            // Console.ReadLine() only can return strings
            sFavoriteNumber = Console.ReadLine();
            //console is a class and nearly everything in c# is object oriented 
            //a static class is a class definition that gives us access to the class and its members without doing any extra work (dont have to create anything)
            //a console class is a static class and allows us to access the console and the only type of data we can get from them is the string from the console 

            // the while loop
            while (nFavoriteNumber == null)
                //a while loop may never done if the condition starts off as not being true
                // == is a way to test if something is equal to something else and = is used to set a variable equal to another variable or a value 
                //method = functions 
                //classes are a collection of methods that allow us to do anything to interact with the console
                //for the color stuff after we use the color, if will be set to that color and we have to set it back if we want to write something else 
                //to the console we have to change it ack
            {
                try
                {
                    nFavoriteNumber = Convert.ToInt32(sFavoriteNumber); //if the string can be converted into an int. then it skips catch by default then checks*
                    //the loop condition and since it's false we can leave the loop and use nFavoriteNumber in the program as an int
                    //Convert is a static class and it contains a bunch of methods for converting datatypes 
                }
                catch
                {
                    Console.WriteLine("Please enter an integer."); //if an error was caught (user did not put a number in because it did not get converted)
                    // then it goes to catch then it goes back to the loop and checks if its equal to null which it is and keeps looping
                    sFavoriteNumber = Console.ReadLine();
                }
            }

            do
            {
                sFavoriteColor = Console.ReadLine(); //we can hvae first line be read line here so we are sure the loop runs at least once**
                try
                {
                    nFavoriteNumber = Convert.ToInt32(sFavoriteNumber); //if the string can be converted into an int. then it skips catch by default then checks** 
                    //the loop condition and since it's false we can leave the loop and use nFavoriteNumber in the program as an int**
                    //Convert is a static class and it contains a bunch of methods for converting datatypes 
                }
                catch
                {
                    Console.WriteLine("Please enter an integer."); //if an error was caught (user did not put a number in because it did not get converted)**
                    // then it goes to catch then it goes back to the loop and checks if its equal to null which it is and keeps looping**
                    sFavoriteNumber = Console.ReadLine();
                }

            } while (nFavoriteNumber == null); //stay in loop if we need to prompt them again**


            //each of our datatypes are structures**
            //structures are value data types which are consistent with value data types**

            do
            {
                sFavoriteColor = Console.ReadLine(); //we can hvae first line be read line here so we are sure the loop runs at least once**
                try
                {
                    sFavoriteNumber = "42";
                    //sFavoriteNumber + sFavoriteNumber != 84("4242");
                    //length property of our string 42 would be 2 in this case 
                    //sFavoriteNumber.Length = 2
                    nFavoriteNumber = int.Parse(sFavoriteNumber); //we can do int.Parse as well to convert a string to an integer (parses the string until it finds and int.
                    //to convert and ignores the rest**)
                }
                catch
                {
                    Console.WriteLine("Please enter an integer."); //if an error was caught (user did not put a number in because it did not get converted)**
                    // then it goes to catch then it goes back to the loop and checks if its equal to null which it is and keeps looping**
                    sFavoriteNumber = Console.ReadLine();
                }

            } while (nFavoriteNumber == null); //stay in loop if we need to prompt them again**



            int nFavoriteNumberInt = 0;
            do
            {
                sFavoriteColor = Console.ReadLine(); //we can hvae first line be read line here so we are sure the loop runs at least once**
             
                    sFavoriteNumber = "42";
                    //sFavoriteNumber + sFavoriteNumber != 84("4242");
                    //length property of our string 42 would be 2 in this case 
                    //sFavoriteNumber.Length = 2
                    bValid = int.TryParse(sFavoriteNumber , out nFavoriteNumberInt); //Returns true or false whaether it was able to successfully convert the data
                                                                                     //into an int. but false if it cant and dont need to use a try catch for it** we usually pass it into the variable that we want to convert
                                                                                     //ex. we wanted to convert the nFvaoriteNumver string to a number so we set it = to that**
                                                                                     //c# is strongly typed which means**
                                                                                     //out works the same way as ref except that we dont care what they value of the variable was as it got passed into the method**
                                                                                     //the value is not set and its an output value**
                    //Parse parses the datatype into a datatype (usually a string) and tryparse will try to convert the string into a number and set the value
                    // as the integer converted and the out keyword is used as an output value and is used to set the out variable equal to the first variable 
                    //and with tryparse if it does not work the if statment checks if it ws false to go through the loop again**
                    //should we make the bool initialliy equal to true or false for bValid**
                //if(bValid == false) either is good 
                if (!bValid) 
                {


                    Console.WriteLine("Please enter an integer: "); //if an error was caught (user did not put a number in because it did not get converted)**
                    // then it goes to catch then it goes back to the loop and checks if its equal to null which it is and keeps looping**
                    sFavoriteNumber = Console.ReadLine();
                }
               

            } while (nFavoriteNumber == null); //stay in loop if we need to prompt them again**

            nFavoriteNumber = nFavoriteNumberInt; //set new number equal to nFavNumber for access purposes





            //code blocks are surrounded by {} and if we have another {} within the first one thats the child code block and we can access anything outside of that
            //code block within it** (cant access inside code block from the outside**
            //we cant create a variable with the same name that exists in a parent code block (local error)(compile time error**)

            {
                int myInt2 = 0;
                {
                    myInt = 3;
                    myInt = 5;
                    string myString = "";
                }
            }



            // a loop that outputs their fav color fav num times
            Console.WriteLine(13 / 4); //how to get remainder from this instead of the whole number 3**
            Console.WriteLine((6 / 4.0 + 3.5) / 2); //whenever we have a float with a whole number the float takes over**
            double money = 3.50;
            Console.WriteLine(money); //prints out 3.5 instead of 3.50**

            Console.Write("Hi there");
            Console.Write("David");

            //usually need a console.writeline for a question and a readline right after stored in a variable so it knows
            //to take in information otherwise it does not**




            //ser fav. color to lowercase
            //this wont change the original string contents
            sFavoriteColor.ToLower(); //we return a new string with lowercase but usually set equal to var. otherwise it gets lost**

            sFavoriteColor = sFavoriteColor.ToLower(); //this will change the actual string but we dont want to do that because**

            //change the console output color to match their favorite color 
            //we can use a switch statement to do that
            //switch statment is similar to if and else statments 
            switch (sFavoriteColor.ToLower()) //takes the value of a variable that we want to check against the other values (cases)** 
                                              //toLower does not change the original string and creates a copy that is lowercase** its more efficient so we can just check 1 case
            {
                case "red":
                    //case "RED":
                    //case "Red":
                    //case "rEd":
                    //case "reD":
                    Console.ForegroundColor = ConsoleColor.Red;//**
                    break; //says that we are done with this case and done with the switch statment so now we can leave

                case "blue":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;

                case "green":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.White; //always put default statement if nothing gets put in that matches the cases**
                    break;

            }


            int y = 0;
            int x = 5;
            y = ++x; //++ is called the incrementer and first it increments x to become 6 then y will be set equal to the 6
            y = x++; //it first sets y = 5 then it will incrememnt x at the very end of thet statment 
            //have a loop (best loop in c# is a for loop)
            //initialize somrthing first (i,j,k), condition to stay in the loop, and what needs to change when we 
            //are done with the loop
            for (int i = 0; i < nFavoriteNumber; i++) //i++ and ++i and when does it get incremented** wont i++ also work**
            {
                Console.WriteLine("Your favorite color is " + sFavoriteColor + "!"); //tell them their fav. color cant we also use , to add strings together**
                //Console.WriteLine("5 + 5 = " + (x + x)); //the tostring method converts and int. to a string only x.ToString()**
                //put the x + x into () so it does the math first then adds it to the string** using int. and float will not work so use the ()
                Console.WriteLine($"Your favorite color is {sFavoriteColor + "!"} "); //put $ before quotes and its called string interpolation 
                //how does it know when to space**
                Console.WriteLine("Your favorite color is {0}{1}", "most ", sFavoriteColor, "!"); //substituion and the tokens are the 0 and 1 and are usualyl complicated
                                                                                                 ////which method is perferred**


            }




        }




    }
}

//we can write methods within or outside the class but within namespace**
//but if we write the method in namespace but outside of class, to ref. the method within the class**
//can we just call the method regularly since it's within the namespace**
//would we use . notation to access something inside of the class, outside the class and within the namespace**

//internal class program is where we define additional methods or classes whereas the main is where we define variables and call these methods**
//we can do loops in the internal class program or main right**



//what does the build solution do and do we have to do it**