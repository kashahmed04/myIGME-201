using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShallowCopy
{
    struct MyStruct
    {
        public int val;
    }

    class MyContent
    {
        public string contentString;
    }

    class MyClass : ICloneable //is this built in interface (yes)
    {
        public int val; //cant access from struct these are two differene things same for classes if same field name (yes)
        public string myString;

        public MyStruct structVal;

        public MyContent myContent = new MyContent(); 

        public object Clone() //put clone in the class we are trying to clone and make the interface reference on the top
            //of the declaration and create the method Clone() then call the memberwise clone()(the interface means
            //we must have a Clone() method)
        {
            return MemberwiseClone(); //and we have to have a return for the memberwise
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            MyStruct a;
            MyStruct b;

            a.val = 4;
            b.val = 5;
            a = b; //the a is gone forever and now its equal to 5 like b.val but when we change b.val to 1 a does not change only the b since its a value type**
            //is it was a reference type a would have changed as well because they would have pointed to the same place**
            b.val = 1;

            string x = "david";
            string y = "sue";

            x = y; //same here david will now be gone forever and both will be sue types not one type its 2 distinct types because its a value type**

            MyClass myClassObj = new MyClass(); //original object and we filled in all the fields below 

            myClassObj.myString = "myString";
            myClassObj.val = 4;
            myClassObj.myContent.contentString = "my content's string"; // and we filled the my field content in it 
            myClassObj.structVal.val = 42; //and we go to the structval and give the struct a value of 42 for the val type
            //in structure

            MyClass myClassCopy = new MyClass(); 

            myClassCopy.val = 1; //we make the integer value 1 for MyClass

            // does not copy the object
            // furthermore we have lost the object created called myclasscopyS
            myClassCopy = myClassObj;


            /// cannot do this because MemberwiseClone is a protected member of Object
            //myClassCopy = myClassObj.MemberwiseClone(); //can't access it outside the family tree but could access it in parent and the children if it was defined in**
            //parent but if it was only in child then it would only be in child**(do we usually create cloning methods in the parent??)**
            Object obj;

            // this only copies highest value value fields from the source to the copy (which means only the value types which are the fields??)**
            myClassCopy = (MyClass)myClassObj.Clone(); //memberwise clone uses object so we have to cast the class we want to clone
            //we have to create  2 instances (1 we want to clone(myclassobj)) and 1 we want to copy (myclasscopy)
            //and we set that variable that we want to have cloned equal to the explicit cast of the other class we want to copy
            //memberwise clone always returns an object

            //anything above a class is more general and as we go down its more specific so anything on the bottom has to be explicitly casted
            //to reference a top (we can do top reference to bottom implicitly)
            //object is always on the top of everything and has to be explicitly casted since a class below the object it has to be explicitly casted




            //classes are reference variables so that means that whenever we look at a class variable its pointing to an object not holding it and we are looking at it
            //through a mirror and any changes we made are made to that object and we can have mutltiple variables point to the same thing and can manipulate** it but for
            //structures we cant do that and we are holding the value so we can only change that thing the variable points and its not an object type (not a miror)**

            //if we set a = b we have overridden the content of a with b because its a structure and now a.val is now 5 instead of 4 (b is 5) then we can change b.val to
            //1 and a.val is still equal to 5 while b.val was changed (val is the int field defined in the struct)**
            //when we have a string equal to david for x and make string y sue if we do x = y then x = sue and all of our primtive datatypes work the same way as a structure

            //in order to make copies of methods we need to use special methods**
            //MyClass contains a mycontent object (instance) which is a class object and a mystruct structure (call by value)
            //Create a new object of my class and set the members of the class equal to a different value so we have a string names my string and 
            //my content is an object in MyClass and when we create a new class object it creates a new content object within the class and we can set**
            //the string in mycontent to the content string** (basically defining a class instance within a class instance by using*
            //outerclass instance.inner class instance.field in the innerclass = something;*
            //and we are setting thr structure member val to 42**

            //now we want to make a copy of Myclass (myclasscopy) and we create a anew myclass object in there and we make
            //myclasscopy = myclassobj (myclassobj was filled in above)
            //set a breakpoint in that line and it says that everything from myclassobj is in myclasscopy but when we creates the myclass objects (2)
            //now we have 2 objects memeory (it still counts as 2 instances if one is removed after we set it equal to another instance but before it was 2 objects in memory)**
            //the old and new object and we have 2 reference variables in memory (myclassobj and myclasscopy that holds the instances)**
            //each varibale points to their instances**
            //we have 4 different variables (2 objects instances and the 2 variables that refernce the instances (objects) when we create our object instances)**
            //we took myclasscopy and we pointed it from myclasscopy to myclassobj and now myclasscopy is gone forever and we cant get it back
            //since we set myclasscopy equal to one before now its completely lost because we set myclasscopy equal to myclassobj 
            //double == sign would not make it lose data because its jsut a comparison and it would not chnge any code and we would get an error because**
            //we need an if statement or a boolean overloaded operator**

            //we can check if classes if class instances are equal to each other and we can do if(myclasscopy == myclassobj) and it checks if they point to the same thing and**
            //its false right now because they are seperate things but if we set them equal to each other then it would return true and they are equal to each other and now**
            //the copy is lost forever since it gets equal to the mycallobj**

            //if we change values in myclasscopy and change the string to david for example in myclasscopy and now in myclassobj it changed it to david as well because they
            //point to the same thing because they are set equal to eachother and both point to myclassobj**

            //for thestructures in both if we change the structure in the class object it will also change because everything in classes even if they are a value type,**
            //can also be changed because they both point to the myclassobj now**

            //how we actually create a copy is by using the myclasscopy = myclassobj.memberwiseclone() (use memberwisse clone method)
            //and its a member of the object class and its protected(it can be accessed from any child in the family tree but it can't be accessed outside the family tree)
            //(but we can do it with parent)(cant do it with instances because its outside family tree)
            //we have to implement a method called clone in the class to call the memberwise clone so we can access it from outside the classes and in order
            //to inherit the ICloneable method(interface)??* and it means our class supports cloning and is requirede to have a clone method
            //and our clone method could do anything but by definition it calls memberwise clone (this always returns an object data type and does not return the** 
            //data type of the class)**(its the most generic datatype and we can set anything equal to an objet type in c# because its so generic)(and the memberwiseclone
            //will return a new copy of our class object)**
            //(if we dont use memberwise within the Clone() method would we get an error because we could have the method do anythng)**

            //memberwiseclone is used to make a shallow copy which means its going to do all of the value datatype variables that are in our class so the shallow**
            //copy of myclass makes a copy of our int string and struct because they are value dataetyopes and mycontent is a reference type so memberwiseclone will not**
            //copy the contents of mycontent and only copies a reference which means that when we reference the reference type in the class (myclasscopy)**
            //it will also change it in the**
            //class that it was cloned as(the myclassobj)**

            //in c# we can right click and do peek definition and it shows us how its defined in c# library
            //myclasscopy = (myclass)myclassobj.clone(); which returns the shallow of myclassobj and we have to cast the call the clone with the name
            //of the class clone method is in (myclass) because**

            //the clone only covers the value datatypes (highest level value fields which are the value fields directly assocated with the class like
            //the struct int and string,etc.)**
            //and now the reference datatypes only has the pointer to that value in the class so if we change one class**
            //reference variable, then both reference types changes**

            //myclassopy is now seperate from myclassobj because we did the clone even though the objects are reference types when it gets copied**
            //when we change the david string to sue now it does not change it in the other class and now if we change the int to 34 in myclasscopy is does not
            //change it in original and it stays at 1 because those are value types**
            //mycontent is shared though because it was a reference type so when we change the reference in myclassobj, it changes in myclasscopy because they point**
            //to the same reference type and its only 1 thing there not copies, so they point to the same thing**

        }
    }
}
