using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TvGenreShUMLToC_
{
    // Interface: IReaction
    // Author: Kashaf Ahmed
    // Purpose: Implements shUML to C# and this references the Reaction() method
    //that will be used in our classes
    // Restrictions: None
    public interface IReaction 
    {
        void Reaction();
    }

    // Interface: IRating
    // Author: Kashaf Ahmed
    // Purpose: Implements shUML to C# and this references the Reaction() method
    //that will be used in our classes
    // Restrictions: None
    public interface IRating
    {
        void Rating();
    }

    // Class: TvGenre
    // Author: Kashaf Ahmed
    // Purpose: Implements shUML to C# and this class has a string
    //representing the tv show (field) and a property to get and set the name
    //as well as an abstract method for the children to inherit as well
    //as a virtual method just incase the child classes don't implement the method
    //but still want to use it (default method to tell the location of where
    // the show will be watched)
    // Restrictions: None
    public abstract class TvGenre
    {
       public string tvShow; 
        
        public string GetShow
        {
            get
            {
                return this.tvShow;
            }
            set
            {
                this.tvShow = value;
            }
        }

        public abstract void GetSnacks();
        public virtual void LocationToWatch()
        {
            Console.WriteLine("Watch tv in the living room");
        }
    }

    // Class: Comedy
    // Author: Kashaf Ahmed
    // Purpose: Implements shUML to C# and this class inherits from the
    //parent TvGenre as well as the two interfaces above and implements each
    //method from the parent class and the interface so the interface can point
    //to that specific method
    // Restrictions: None
    public class Comedy: TvGenre, IReaction, IRating
    {
        public override void GetSnacks()
        {
            Console.WriteLine("Get some chips");
        }
        public override void LocationToWatch()
        {
            base.LocationToWatch();
        }

        public void Reaction()
        {
            Console.WriteLine("That was funny");
        }

        public void Rating()
        {
            Console.WriteLine("10/10");
        }
    }

    // Class: Action
    // Author: Kashaf Ahmed
    // Purpose: Implements shUML to C# and this class inherits from the
    //parent TvGenre as well as the two interfaces above and implements each
    //method from the parent class and the interface so the interface can point
    //to that specific method
    // Restrictions: None
    public class Action: TvGenre, IReaction, IRating
    {
        public override void GetSnacks()
        {
            Console.WriteLine("Get some popcorn");
        }

        public override void LocationToWatch()
        {
            Console.WriteLine("Watch at a friends house");
        }

        public void Reaction()
        {
            Console.WriteLine("That was quite eventful");
        }

        public void Rating()
        {
            Console.WriteLine("9/10");
        }
    }



    // Class: Program
    // Author: Kashaf Ahmed
    // Purpose: Creates instances of the derived classes and calls MyMethod()
    //which takes an object and sees which type of object it is and explcitly casts
    //it based on which object we passed in so we can use the methods according to the
    //object that was passed in 
    // Restrictions: None
    static internal class Program
    {
        // Method: Main
        // Author: Kashaf Ahmed
        // Purpose: Creates instances of the two derived classes and calls the 
        //MyMethod() with those objects passed in 
        // Restrictions: None
        static void Main(string[] args)
        {
            Comedy comedy = new Comedy();
            Action action = new Action();

            MyMethod(comedy);
            MyMethod(action);
        }

        // Method: MyMethod()
        // Author: Kashaf Ahmed
        // Purpose: Based on the object it explicitly casts the object to that
        //type and calls the correct method based on the cast like it did 
        //with the interfaces and the parent class (calls the correct method
        //because the child inherits from the parent and can use their own methods
        //if they override what's in the parent and the correct method will
        //be called based on the object)
        // Restrictions: None
        static void MyMethod(object obj)
        {
            if(obj is IRating)
            {
                IRating castRating = (IRating)obj;
                castRating.Rating();
            }

            if(obj is IReaction)
            {
                IReaction castReaction = (IReaction)obj;
                castReaction.Reaction();
            }

            if(obj is TvGenre) 
            {
                TvGenre castTv = (TvGenre)obj;
                castTv.GetSnacks();
                castTv.LocationToWatch();
            }
        }
    }
}
