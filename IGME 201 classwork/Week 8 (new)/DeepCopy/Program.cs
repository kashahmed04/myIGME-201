using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepCopy
{
    struct MyStruct
    {
        public int val;
    }

    class MyContent : ICloneable
    {
        public string contentString;

        public object Clone()
        {
            return MemberwiseClone();
        }
    }

    class MyClass : ICloneable
    {
        public int val;
        public string myString;

        public MyStruct structVal;

        public MyContent myContent = new MyContent();

        public List<string> names = new List<string>();

        //SHALLOW COPY:
        //all we did in shallow copy was have a clone method and it returned the memberwise clone and only
        //makes a copy of the value type fields (struct as well) and the references like the MyContent class
        //is just a pointer and does not get copied 

        //if prop. are in interfaces as just get; and set; would we have to do the same
        //in the class if it inherits it or could we change the get and set since
        //classes inherit everything from properties**

        //properties are value data types

        //memberwiseclone creates a new object and copies all of the value fields in it
        //and we have to clone the references in that class if needed and create the clone method
        //within the class that needs to be cloned

        //we now want to copy the whole thing (first we make a shallow copyby calling memberwise
        //clode and set that equal to our copy and now we have the clonedmyclass which is not
        //the shallow copy like we had in our application)(lists are also reference types and not by value)
        //and now we need to look at each item in our class like MyContent which is a reference variable
        //and make a copy of that class and in the MyContentClass we implement a memeberwiseclone of that class
        //so then we can clone that has well and in the clonedmyclass we have a mycontent but now we want to
        //copy it into clonedmyclass because now its a cloned version of mycontent and we need to cast it to mycontent 
        //because clone returns and object 
        public object Clone()
        {
            MyClass clonedMyClass = (MyClass)this.MemberwiseClone(); 
            
            clonedMyClass.myContent = (MyContent) this.myContent.Clone();

            clonedMyClass.names = this.names.GetRange(0,this.names.Count); //copies the list into
            //the clone method by using GetRange

            return clonedMyClass;
        }

        //deep copy copies all of the value and reference types compared to only the reference types in the cloning method from the shallow copys**
        //in order to do a deep copy of our MyClass class type when we do the clone we first create a copy of our object within the clone method but in the shallow**
        //copy our original clone only returned the memberwiseclone() which only returned our value types** (shallow copy also creates a new instance same for deep copy but the**
        //reference types point to the same thing as original and copy but its its own type it wont change the original)**
        //we start by making our new myclass object from the mmeberwise clone then we need to set the mycontent in the cloned object into the cloned content in my object**
        //and we need a meberwiseclone() method within the child class mycontent** (my content before just had the string but now it has the clone method in it)** and now
        //we can call the clone method of the mycontent class which will return an object (ne object)** that has the contents of its value type fields and cast**
        //that as a mycontent and set that to the mycontent field of our new copy and object are reference variables same for arraya and lists so if we have**
        //a list in a class then we need to do a deep copy on that list so when we cloned our myclass object we want to set our names of our cloned objects equal**
        //to the sourcce (original range list) and we get all of thoese values and it gets a copy of the list and does not point to the original**
        //after we return the myclonedclass in the end**
        //do we always explicitly class the reference types like we did my content or (same for lists and arrays or)**


        //do we usually make the clone method in the parent and the class will usually inherit the interface (is this interface built in)**
        //any value types in our class we need to do it manually and we usually clone parent or can we do**
        //children as well what if we had a unique reference we wanted to clone in the child or if we wanted to make a clone within the child**


        //getrange tells ut the index to start from (0) and then the number of items to extract
        //getrange from a list returns a new list of a subset of that list (some or all) and if we want copy of whole list we go from
        //0 to the number of items in list.Count**
        //if we wanted the last 5 items in the list we would do this.names.count-5, 5 so it gets the last 5 items of the list**

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            MyStruct a;
            MyStruct b;

            a.val = 4;
            b.val = 5;
            a = b;
            b.val = 1;

            string x = null;
            string y = null;

            x = y;

            MyClass myClassObj = new MyClass();

            myClassObj.myString = "myString";
            myClassObj.val = 4;
            myClassObj.myContent.contentString = "my content's string";
            myClassObj.structVal.val = 42;

            MyClass myClassCopy = new MyClass();

            myClassCopy.val = 1;

            // does not copy the object
            // furthermore we have lost the object created at line #51
            myClassCopy = myClassObj;


            /// cannot do this because MemberwiseClone is a protected member of Object
            //myClassCopy = myClassObj.MemberwiseClone();

            // this only copies the value fields from the source to the copy
            myClassCopy = (MyClass)myClassObj.Clone(); //why do we have to explicitly cast(obj. is the highest datatype in c#)

            myClassCopy.names.Add("david");






       
        }
    }
}
