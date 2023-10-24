using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StructToClass
{

    // Class: Friend
    // Author: Kashaf Ahmed
    // Purpose: Converts the structure into a class. I create the fields which were in the structure and create
    //a constructor for those fields. I also make it a cloneable class with the ICloneable interface and using the 
    //Clone() method which uses MemberwiseClone(); so we can clone the class down below
    // Restrictions: None
    public class Friend: ICloneable
    {
        public string name;
        public string greeting;
        public DateTime birthdate;
        public string address;
    
        public Friend(string name,string greeting,DateTime birthdate,string address)
        {
            this.name = name;
            this.greeting = greeting;
            this.birthdate = birthdate;
            this.address = address;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }

    //struct Friend
    //{
    //    public string name;
    //    public string greeting;
    //    public DateTime birthdate;
    //    public string address;
    //}

    static class Program 
    {


        // Method: Main
        // Author: Kashaf Ahmed
        // Purpose: Create a friend and enemy object and put in the values into the friend object
        //from the constructor that was created above. After, we clone the friend object into the enemy
        //object so now enemy can use the same values as the friend object and they won't change each other's
        //values. After, we print to the console with values from the freidn and enemy object.
        // Restrictions: None
        static void Main(string[] args)
        {
            Friend friend = new Friend("Charlie Sheen", "Dear Charlie", DateTime.Parse("1967-12-25"), "123 Any Street, NY NY 12202");
            Friend enemy;
            enemy = (Friend)friend.Clone();

            // create my friend Charlie Sheen
            //friend.name = "Charlie Sheen";
            //friend.greeting = "Dear Charlie";
            //friend.birthdate = DateTime.Parse("1967-12-25");
            //friend.address = "123 Any Street, NY NY 12202";

            // now he has become my enemy
            //enemy = friend;

            // set the enemy greeting and address without changing the friend variable
            enemy.greeting = "Sorry Charlie";
            enemy.address = "Return to sender.  Address unknown.";

            Console.WriteLine($"friend.greeting => enemy.greeting: {friend.greeting} => {enemy.greeting}");
            Console.WriteLine($"friend.address => enemy.address: {friend.address} => {enemy.address}");


        


        }

    }
}





