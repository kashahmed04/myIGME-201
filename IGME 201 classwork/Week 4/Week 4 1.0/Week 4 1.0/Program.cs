using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//delegates are a way to call other methods by using a ref. to a method**
//we could ref. varibales like arrays, but now we can reference methods**
//program asks for 2 numbers and we can only read from the console as a string so we have to validate with while loops
//then we ask if they want to divide or multiply and stay in loop until they want to divide or multiply
//we have a dvide and multiply method and we call mutiply method if they want to multiply or we can call the dicivde method
//if they want to divide 
//what if we want to use the same varuable to call one of those methods based on what they said what they wanted to do**
//delegate method is a data type, just like enums and structures, its a data tyoe we create ourseves that can be used to point to a method and we can**
//use a variable of that datatype to call that method**
//1. define the datatype based on the method signature (our multiply takes 2 doubles and c# will look for a mthod lik that that will take 2 doubles and **
//our first step is to make it pascalcase because its our own data type **
//we make a math functon data type that calls multiply or divide and in () after our data type we put the para. the method will accept**
//before the data type, we put if the method returns a data type or not (void)**
//delegate looks just like method signature**
//when we say delegate in front of it then it tells c# we are making delegate method **
//a delegate can point to**
//we can use same delegate if they have different para. (but we cant use the same delegate twice)**
//than the other delegate and they have to match the signature of the delegate to use it**
//2. create our variable of that delegate data type**
//create a processdivmult variable of the mathfunctuiion datatype (from the delegate)**
//variables and delegates have to be defined in the namespace and can only be used there or within main and class program?? Also we cant define it outside**
////where the using statements are??********
//the variable can point to the divsision or multiplcatjon method**
//If the want to multiplty we set that variable equal to a new MathFunction (new delegate variable) and pass the mutltiply method as the constructor for the****
//math function****
//constructor excepts the method we want to point to, in this case the multiply**
//constructor is whatever we put in () based if we say the new keyword then something else on what the user does or says**
//all we have done is point to the method we want to use then after, we call the delegate method and the para. we want to use**
//use the 4 steps when creating delegates because its the most direct and explicit way to do delegates**
namespace Week_4_1._0
{

    delegate double MathFunction(double n1, double n2); 
    //C# has an internal data type which** (usually define delegates in namespace, not within anywhere else)******
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] aInt = new int[5];
            int[] bInt;
            bInt = aInt; //this is an example of call by reference with variables and now we are doing that with methods (only delegate is call by ref. with
                         ////methods not structs or enums)**

            //MathFunction processDivMult; can get rid of this then**
            Func<double,double,double> //put data types within the <> symbols and it takes ant number of para. and it can return any type of data type (has to match
                                       ////data type of whats put int though??**
                //the starting data type is what the delegate takes as a para. (all of it) and the last type is the return type**
                //last value is expected to be the out type which is the return value*****
                //this is the same as the MathFunction we created ourself, but its using c# built in delegate method***
                //and instead of new mathfunction call within the mult. and division conditionals, then we say
                processDivMult = new Func<double, double, double>(Divide) //instead of doing new MatchFunctin(Divide)**
                                                                          ////func is only used when returning a datatype**
            ///



            //if we want to call a method that does not return a type then we use action**
                Action<double> outputAnswer; //we need to list all of the para. the method accepts** 
                outputAnswer = new Action<double>(outputAnswer);
            //action returns a void so we could use this instead of func if we want to have no return value because func
            //always gives a return value no matter waht cant we just say void for the return**
            //where to call and use all of these**

            processDivMult = Multiply; //we can ref. it like this if we use action??** within the conditional using mult. or division.



            //anon. code blocksm(gover over all)**
            //the code block that does our multilcaton has a name called multiply and we can write that code anon. so its called wthin**
            //the parent code and we do that by writing a delegate code block**

            processDivMult = delegate (double n1, double n2)
            {
                double returnVal = 0; //we can be explicit as we want**** 
                returnVal = n1 * n2; //anon code block and its done this way and making it look like a method but the method has no name
                //when orcoess div mult. is called, then it exccutes this statement within the code block*****
                return returnVal;
            }; //why do we need a ; here**

            processDivMult = ( n1,  n2) => //we can get rid of the douvles here becyse**
            {
                double returnVal = 0; //lamda functon replaces delegate keyword (an arrow functino**)**
                //and its still an anon. funcition**
                //when would we want to use arrow functions and delegates**
                returnVal = n1 * n2;
                return returnVal;
            };

            //we can just return n1*n2 instead of forget the 2 other lines as shown below 

            processDivMult = (n1, n2) => n1 * n2; //only used when we only have a return statement within the arrow function**

            //we can use the explicit 4 step method for delegates (self documentation), we can use the bult in c# data type of func or action to not need to define**
            //our own data type but the one thats in c#, we can use anon. code blocks so we dont need to have sep methods and write**
            //a method code block within a variable within the code itself, but if we want to use logic somewhere else we need to copy it (why for arrow functions)**
            //a named method can be called from anywhere else, but anon. cant**
            //we can replaec delegate keyword wuth an arrow function and further simplified**
            //arrow functions also follow scope since its equal to a variable right**
            //

            //we can ref. variables like we do with arrays, and we can also do it with methods with delegates and arrow funcitons**



            //Memory Game (go over all)**
            //for exam, comment every line of code and show what we are using 
            //gives time lmimit to enter our response by using a timer
            //the timer is an object in c# which when we tell it to start it runs in the background and it just counts down for
            //the amount of time we tell it to**
            //we use system.timers name space with the using statement so we can use a timer because its built into c# thats why we need to put it in a using**
            //we need access to the timer within our code and as the timer moves on we want to call a method to say the time is up**
            //the timer variable needs to be outside of our main method and whatever method thats going to be called when the time is up**
            //the variable needs to be accessible from msot of our levels
            //when we create a new project, VS wraps eveyrthing in a class for us and anything within the class is availabel to all the methods wihin out class**
            //we have our time variable and a boolean for the time if it has elapsed or is over a and when its over we set the boolean to true
            //displayString displays the text to the console and a random to pick random letters
            //from thr alpahebet and the main code for our program is  while the program has not lekapsed or is over and we are going to add
            //a random letter to out dipplay string and we put half a second out to lay between wrtiging out each ketter of the display string**
            //after the letters are written out, we clear the string and hide the answer in the console, then set the time for our timer to count
            //based on the length of the string and based on our length of our word, we get half a second more to memorize a letter
            //constructor for our timer is*****
            //timer elapsed has a built in delegate type when the timer leapses and its defined within c# itself and its the data type**
            //step 1 in delegate method data type, we dont have to do it because its provided to us by c# and we can know that by hovering over the elapsed data type**
            //elapsedeventhandler is a delegate and returs void and accepts 2 para. an object sender and the time elapsed**
            //it needs to match elapsed delgate signature when we write our own method*****
            //we set our timer that has elapcsed with . notiation and we use += which adds a meethod to an evenet handler
            //in c# any evenet handler can handle one event but can do muktiple things based on the event, but not multiple events**
            //now we cna start the timer and prompt the user for their answer and as soon as they hit enter, but the timer is still runniing and now its a multi threaded
            //application with our timer running and our parent application waitint for the user to press enter 
            //when they enter their response we want to stop the timer to it wont keep going and go to the statement taking about the time is up**
           
            
            //tokens start from 0 and we just use , seperators to fill in those place holders or tokens according to the order from 0 to whatever number we put there
            

            //the delegate creates the anon. code block or method and accepts two doubles, n1,and n2 and when process div is called then we are
            //passing the number the user entered 
            //what should we usually do for delegates** which way should we know or delegates are these all anon functions within our code within a varibale**
            //and not a seperate method**





        }
    }
}
