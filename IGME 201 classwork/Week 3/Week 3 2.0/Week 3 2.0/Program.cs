
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
//Enums and Structs
//Enums are a way we can define human readable datatypes (like int and str)
//enums let us create our own datatypes and let us create the values that we want to use (we create them) by creaitn data types you mean like how int is in c# and we create
//something like that but with our data**
//the values under the hood in enums are basically indexes like 0,1,2,etc. for each identifier we have within the enum
//enum type is defined by enum, the name we want to give it (put "E" in front of name to make it an enumerated type)**
//after we declare the name of our enum (our own creation/datatypes) and we can put a ":" after it to use which type of
//numeric value we want to use to store it (its an int. by defualt)(for the indexes in the enum??)**
//if we do : byte after the enum and name, we can only use from 0-255 values instead of the int. being 2 billion numbers
//and if we use more than 255 values for the byte, then it wont work (which type of error)**
//list of values are seperated by commas in the enum, and by default it sets the first value equal to 0, or we can
//override them with other numbers for the index**
//"public" defines accessibility of the variables of values and by default enum, are private so they are only avaiable within the namespace
//so we put public if we want to access it outside of the enum (same for struct)**

//if enums and structs are used to hold daat types how are they different then because they can hold specific or similar information**
//can enums also have objects associated with them like structs as well as properties and constructors?? What is the difference between a class and a struct**



//we can also use stuructures to create our own datatypes (stuct) 
//for example, there might be a record for a specific student so the name,gender,college year, grade, etc. would be in a struct (organzie data about a certain topic)
//a structure defines the associated data for just 1 of that type of object basically we cant have a copy of an object and they all must be different**
//each of our students has individual name,graduation year,etc. (are these are considered different objects or properties for each student then?? and each student would be
////and object**)
//way to organize the data so if we had 20 students in the class, we could have an array of 20 structures instead of different arrays for ecah topic like
//name, grade,etc.**
//with structs we can just oraganize all the info. into one unit
//we can put structures within stuctures (ex. another stucture within the academic strucutre talking about the classes the student is taking)
////how would we reference that when creating a student object then**
//public defines the accessibility of the value or variable (both or just 1**)
//(any other namepace can access the information if it public)(if its not defined like password its private by defult and 
//if we specify private, it's also avialable within the code structure block)**
//we can also put priperties within structures (this.name ,etc.) and its a combinaiotion between a field and a method**
//the property has a get method(this.name having a get and set method as well as the rest of the properties)****
//(write our own method code within the coede block so that when this property called password is accessed it will call our get method and run the code
//we have to get that data withiin the get (the password)**
//peroperties within structs have a get and set method (both or only one or does it not matter**)(what about enums)**
//properties are pascalcase because it a method and a field (for enums as well or only structs)(example**)**
//ex. its a string that has methods associated with it if we used the propertty with a string and have get and set
////do we make get and set or is it just there and do we ref. it like this.prop.get or set or does it do that itself**
//the this keyword means we areaccessing the field within the current context so when we work with a student structure (1 student object**)
//we use the data type whhich is studentstruct and
//we declare our variable name and if we access structustudent.password and set it equal to "pass123" what its doing, its that its calling the password propertty and using the
//set method and setting whatevr we put in as the value to encrypt it as a password**
//the thiw keyword thats in get and set it refers to the password variable and its associated with the stduentstruct variable and its referring the currnet
//object we are in** (this is the current object we are in)**
//get is what we use to return value of our proroperty snd in this case its called the decrypt** 
//we can also have strings,enum,properties(defined with get and set methods), and we can have methods within structs
////if we have a return within the method  in the struct does it also exit the struct****
////enums only property and values**
//we dont use static because we need to be able to call the moethods based on the individual student 


//recursive means that it calls itself and refers to itself**
namespace Week_3_2._0
{
    internal class Program
    {
        public string RecursivePrperty
        {
            get
            {
                return this.RecursivePrperty; //always include this keyword when refering to things in our structs**
                //the get method needs to return a value no matter what**
                //when we refer to the property itself it will call its get method and in this case it will keep calling the get method until
                //we get a runtime error because our application will run out of spcae**
                //if we want the properrt to retunr itself then we dont put it in the code block, but if we dont, then we use the code blokc**
                //set takes the value thats passed in (right of equal sign when we pass password in from input)**
                //structs can take methods but no static keyword in front of them becuse they are associated with the instance of that strucuture**
                //we can only get the grade, see it, with the get method while set basically sets the value**
                //so we dont need static anymore because**
            }
        }
        static void Main(string[] args)
        {
        }
    }
}
