using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace PE_14_Classy
{
    // Class: Classy
    // Author: Kashaf Ahmed
    // Purpose: Creates a private field called parentString and we can access the private
    //string via a property when we create an instance of a child so it can inherit the property and be able to access the
    //private property.
    // Restrictions: None
    public abstract class Classy
    {
        private string parentString;
        public string RandomString //gives us access to the parentString (common to access private field via a proeprty in the
            //class the private field is defined in(1)****
        {
            get
            {
                return this.parentString; 
            }
            set
            {
                this.parentString = value; //sets the value based on user input or what we code in when
                //we create an instance
            }
        }
    }

    // Class: IGiveString
    // Author: Kashaf Ahmed
    // Purpose: Interface that references the Strings() method and if any class inherits an interface
    //it needs to also implement all of it's properties and values
    // Restrictions: None
    public interface IGiveString
    {
        void Strings(); //have to always put void then name of method to reference a method in interfaces right(2)****
    }

    // Class: InheritInterface
    // Author: Kashaf Ahmed
    // Purpose: Inherits from the interface and implements the method in it
    // Restrictions: None
    public class InheritInterface: IGiveString 
    {
        public void Strings()
        {
            Console.WriteLine("InheritInterface class");
        }
    }


    // Class: InheritFace
    // Author: Kashaf Ahmed
    // Purpose: Inherits from the interface and implements the method in it
    // Restrictions: None
    public class InheritFace: IGiveString
    {
        public void Strings()
        {
            Console.WriteLine("InheritFace class");
        }
    }



    // Class: Program
    // Author: Kashaf Ahmed
    // Purpose: Has the method MyMethod and it uses the interface reference 
    //to call the Strings() method based on the instance that's passed in from the main
    // Restrictions: None
    internal class Program
    {
        // Class: Main
        // Author: Kashaf Ahmed
        // Purpose: Creates the instance of both classes and calls MyMethod and passes in the instances
        //so it can reference the correct method based on the instance
        // Restrictions: None
        static void Main(string[] args)
        {
            InheritInterface inherits1 = new InheritInterface();
            InheritFace inherits2 = new InheritFace();
            MyMethod(inherits1);
            MyMethod(inherits2); //we can't use instance.mymethod because thats to access, not to put a value in
        }

        public static void MyMethod(object myObject)
        {
            if(myObject is IGiveString)
            {
                IGiveString ref_variable = (IGiveString)myObject; //explicitly cast because we are
                //going from a more specific (IGiveString) thing into a less specific (myObject) thing (same for if we wanted to cast a parent instance 
                //to a child class instance)
                ref_variable.Strings();
            }
        }
    }
}
