using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE16__Classiest
{
    // Class: HotDrink
    // Author: Kashaf Ahmed
    // Purpose: Implements shUML to C#
    // Restrictions: None
    public abstract class HotDrink
    {
        public bool instant;
        public bool milk;
        private byte sugar;
        public string size;
        public Customer customer;

        public virtual void AddSugar(byte amount)
        {

        } //the methods defined in the shumul if theres something in the () in the method we define it in c# in the opposite order 
          //than the shumul
          //if there is a return type would there be another ":" before the :v saying the reutrn type for methods

        public abstract void Steam(); //since there is no ":" before the accessiblity it uses void for return type

        public HotDrink() //accessibility is usually public if theres nothing defined
        {

        }

        public HotDrink(string brand)
        {

        }
    }

    // Interface: ITakeOrder
    // Author: Kashaf Ahmed
    // Purpose: Implements shUML to C#
    // Restrictions: None
    public interface ITakeOrder
    {
        void TakeOrder(); //dont put accessiblity with anything within an interfcae
        //because its only a reference for things within it 
        //and properties would only be get and set with a ";" 
    }

    // Class: IMood
    // Author: Kashaf Ahmed
    // Purpose: Implements shUML to C#
    // Restrictions: None
    public interface IMood
    {
        string Mood
        {
            get; //Acts like a string field)
        }
    }

    // Class: Waiter
    // Author: Kashaf Ahmed
    // Purpose: Implements shUML to C#
    // Restrictions: None
    public class Waiter : IMood
    {
        public string name;

        public string Mood
        {
            get; //the get in this case has a read only but we put a ";" because
            //theres no private field to access from and its being treated just as
            //a string field (yes)
        }

        public void ServeCustomer(HotDrink cup)
        {

        }
    }

    // Class: Customer
    // Author: Kashaf Ahmed
    // Purpose: Implements shUML to C#
    // Restrictions: None
    public class Customer : IMood
    {
        public string name;
        public string creditCardNumber;

        public string Mood //since customer inherits from the interface it must take in 
                           //the property which is acting like a field same for if it was referencing a method
        {
            get;
        }
    }

    // Class: CupOfCoffee
    // Author: Kashaf Ahmed
    // Purpose: Implements shUML to C#
    // Restrictions: None
    public class CupOfCoffee : HotDrink, ITakeOrder
    {
        public string beanType;

        public override void Steam()
        {

        }

        public void TakeOrder() //no return type but it inherits from the interface so it must implement it
        {

        }
        public CupOfCoffee(string brand) : base(brand)

        {

        }
    }

    // Class: CupOfTea
    // Author: Kashaf Ahmed
    // Purpose: Implements shUML to C#
    // Restrictions: None
    public class CupOfTea : HotDrink, ITakeOrder
    {
        public string leafType;
        public bool customerIsWealthy; //we define it in child because its only defined in here
        public override void Steam()
        {

        }

        public void TakeOrder()
        {

        }

        public CupOfTea(bool customerIsWealthy)
        {
            this.customerIsWealthy = customerIsWealthy; //we can define customerIsWealthy because 
            //its part of the child only 
        }

    }

    // Class: CupOfCocoa
    // Author: Kashaf Ahmed
    // Purpose: Implements shUML to C#
    // Restrictions: None
    public class CupOfCocoa : HotDrink, ITakeOrder
    {
        public static int numCups;
        public bool marshmallows;
        private string source;

        public string Source
        {
            set
            {
                this.source = value;
            }

        }

        public override void Steam()
        {

        }

        public override void AddSugar(byte amount)
        {

        }

        public void TakeOrder()

        {

        }

        public CupOfCocoa() : this(false)
        {
            //this(false) calls the constructor that takes the boolean value within the same class and it refers to constructor within that class only
            //which then calls the base after when it reference it in this case which is the constructor down below 
        }

        public CupOfCocoa(bool marshmallows) : base("Expensive Organic Brand")
        {

        }
    }





    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}

