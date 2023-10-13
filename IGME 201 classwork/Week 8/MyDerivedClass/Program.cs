using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyDerivedClass
{

    public class MyClass
    {
        private string myString = "random string"; //we cant define private wtihin
        //the method but its only accessible within the class*****
        public virtual string GetString()
        {
            return myString;
        }

        public string MyString //is this ok because accessibility was not defined as well**

        {
            set
            {
                myString = value; //value is used for whatever we put in or whatever the user puts in (basically
                                    //the input)
                //is this ok or should we get input from the user****
            }
        }
    }

    //derive refers to creating a child class 
    public class MyDerivedClass: MyClass
    {
        public override string GetString() //when we override we have to same exact signature as virtual
            //or abstract but we have to say over ride instead of abstract or virtual******
        {
            return base.GetString() + " output from derived class";
            //when we use it here the stirng also outputs with it
            //but if its just parent only the getstring will get printed out 

        }
    }
    


   static internal class Program
   {
       static void Main(string[] args)
       {
           MyDerivedClass derived = new MyDerivedClass();//create instance of the child
           string newStr = derived.GetString(); //the instance of the child calls its own overridden method
           Console.WriteLine(newStr);//outputs the getstring from the from the child
       }
   }
}
