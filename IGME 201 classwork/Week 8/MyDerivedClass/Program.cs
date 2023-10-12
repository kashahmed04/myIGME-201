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

        public string MyString
        {
            set
            {
                myString = value; //what is value used for again*****
            }
        }

        //derive a class means a child class*****
        public class MyDerivedClass: MyClass
        {
            public override string GetString() //when we override we have to same exact signature as virtual
                //or abstract but we have to say over ride instead of abstract or virtual******
            {
                return base.GetString();
            }
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            MyDerivedClass derived = new MyDerivedClass();//*****
            string newStr = derived.GetString();
            Console.WriteLine(newStr);//is this how we do it****
        }
    }
}
