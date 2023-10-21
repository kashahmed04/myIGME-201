using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace shUMLToC_
{
    // Interface: IPhoneInterface
    // Author: Kashaf Ahmed
    // Purpose: Implements shUML to C# by created a reference (pointer) to these methods
    //shown below
    // Restrictions: None
    public interface IPhoneInterface //should we include the I even if not specified in shUML
    {
        void Answer();
        void MakeCall();
        void HangUp();

    }

    // Class: Phone
    // Author: Kashaf Ahmed
    // Purpose: Implements shUML to C# and a private and public field are created
    //but the private field needs to have a get and set implemented so that the derived classes
    //can access the private field. After, we create abstract methods Connect() and Disconnect()
    //for the derived classes to inherit 
    // Restrictions: None
    public abstract class Phone
    {
        private string phoneNumber;
        public string address;

        public string PhoneNumber
        {
            get
            {
                return this.phoneNumber;
            }
            set
            {
                this.phoneNumber = value;
            }
        }

        public abstract void Connect();

        public abstract void Disconnect();
    
    }

    // Class: RotaryPhone
    // Author: Kashaf Ahmed
    // Purpose: Implements shUML to C# and this class inherits the Phone class and the
    //IPhoneInterface so it implements the methods from the interface and the abstract
    //methods from the parent class 
    // Restrictions: None
    public class RotaryPhone: Phone, IPhoneInterface
    {
        public void Answer() //we put void here since theres no return type right
        {

        }

        public void MakeCall() 
        {
            //Console.WriteLine("Make Call");
        }

        public void HangUp()
        {
            //Console.WriteLine("Hang Up");
        }

        public override void Connect() //same for the override right
        {
          

        }

        public override void Disconnect()
        {
         
        }
    }

    // Class: PushButtonPhone
    // Author: Kashaf Ahmed
    // Purpose: Implements shUML to C# and this class inherits the Phone class and the
    //IPhoneInterface so it implements the methods from the interface and the abstract
    //methods from the parent class 
    // Restrictions: None
    public class PushButtonPhone: Phone, IPhoneInterface 
    {
        public void Answer() //we put void here since theres no return type right
        {

        }

        public void MakeCall()
        {
            //Console.WriteLine("Make Call");
        }

        public void HangUp()
        {
            //Console.WriteLine("Hang Up");
        }

        public override void Connect() //same for the override right
        {


        }

        public override void Disconnect()
        {

        }
    }

    // Class: RotaryPhone
    // Author: Kashaf Ahmed
    // Purpose: Implements shUML to C# and this class inherits the RotaryPhone class
    //and creates private and public fields and the private fields have a read only
    //(get) so the derived class can get the values for the private fields.
    //After, we create a TimeTravel() method. Boolean method explanations are below.
    // Restrictions: None
    public class Tardis: RotaryPhone
    {
        private bool sonicScrewdriver;
        private byte whichDrWho;
        private string femaleSideKick;
        public double exteriorSurfaceArea;
        public double interiorVolume;

        public byte WhichDrWho
        {
            get
            {
                return this.whichDrWho;
            }
        }

        public string FemaleSideKick
        {
            get
            {
                return this.femaleSideKick; //can use this. here right
            }
        }

        public void TimeTravel()
        {
            //Console.WriteLine("Time Travel");
        }

        public static bool operator < (Tardis t1, Tardis t2) //these go in the tardis class for #5 right**
        {
            if (t1.whichDrWho == 10 && t2.whichDrWho == 10) //If both values are 10 then it's false because 10 is not less than 10
            {
                return (false);
            }
            else if (t1.whichDrWho == 10) //If t1 is 10 then we return false because 10 is supposed to be greater based on the conditons given
            {
                return (false);
            }
            else if (t2.whichDrWho == 10) //if t2 is 10 we return true because 10 would be greater than any other doctor
            {
                return (true);
            }
            else
            {
                return (t1.whichDrWho < t2.whichDrWho); //If none of the cases are met do the regular operator
                //we have to use the field right since it says whichDrWho**
            }
           
        }
        public static bool operator > (Tardis t1, Tardis t2)
        {
            if(t1.whichDrWho == 10 && t2.whichDrWho == 10) //If both are equal return false because 10 can't be greater than 10
            {
                return (false);
            }
            else if(t1.whichDrWho == 10){ //if t1 is 10 then we return true because 10 is greater than any other doctor
                return (true);
            }
            else if(t2.whichDrWho == 10) //if t2 is 10 return false because 10 has to be greater than any other doctor but the operator does not do that
            {
                return (false);
            }
            else
            {
                return t1.whichDrWho > t2.whichDrWho; //If none of the cases are met do the regular operator
            }
        }

        public static bool operator <= (Tardis t1, Tardis t2)
        {
            if (t1.whichDrWho == 10 && t2.whichDrWho == 10) //If both values are equal return true because they are equal
            {
                return (true);
            }
            else if (t1.whichDrWho == 10) //If t1 is 10 return false because it can't be less than any other doctor it has to be greater than based on the conditions
            {
                return (false);
            }
            else if (t2.whichDrWho == 10) //if t2 is 10 then we return true because 10 will be greater tahn any other doctor
            {
                return (true);
            }
            else
            {
                return (t1.whichDrWho <= t2.whichDrWho); //If none of the cases are met do the regular operator
            }
        }

        public static bool operator >= (Tardis t1, Tardis t2)
        {
            if (t1.whichDrWho == 10 && t2.whichDrWho == 10) //If both are equal return true 
            {
                return (true);
            }
            else if (t1.whichDrWho == 10) //if t1 is 10 return true because 10 is greater than any other doctor
            {
                return (true);
            }
            else if (t2.whichDrWho == 10) //if t2 is 10 return false because 10 has to be greater than any other doctor but in this case it's not true
            {
                return (false);
            }
            else
            {
                return (t1.whichDrWho >= t2.whichDrWho); //If none of the cases are met do the regular operator 
            }
        }

        public static bool operator == (Tardis t1, Tardis t2)
        {

            return (t1.whichDrWho == t2.whichDrWho); //Do regular operation since they can be the same or not
        }

        public static bool operator != (Tardis t1, Tardis t2)
        {
           
            return (t1.whichDrWho != t2.whichDrWho);//Do regular operation since they are rather the same value or not
          
        }

    }

    // Class: PhoneBooth
    // Author: Kashaf Ahmed
    // Purpose: Implements shUML to C# and this class inherits the PushButtonPhone
    // class and has private and public fields as well as 2 methods
    // Restrictions: None
    public class PhoneBooth: PushButtonPhone 
    {
        private bool superMan;
        public double costPerCall;
        public bool phoneBook;

        public void OpenDoor()
        {
            //Console.WriteLine("Open Door");
        }

        public void CloseDoor()
        {
           
        }
    }



    // Class: Program
    // Author: Kashaf Ahmed
    // Purpose: Creates objects of the Tardis and PhoneBooth class and calls the
    //UsePhone() method to call the correct method based on what type of object is passed in.
    // Restrictions: None
    internal class Program
    {
        // Method: Main()
        // Author: Kashaf Ahmed
        // Purpose: Creates instances of the Tardis and PhoneBooth classes and passes them
        //into the UsePhone() method
        // Restrictions: None
        static void Main(string[] args)
        {
            Tardis tardis = new Tardis();
            PhoneBooth phoneBooth = new PhoneBooth();
            UsePhone(tardis);
            UsePhone(phoneBooth);



        }

        // Method: UsePhone()
        // Author: Kashaf Ahmed
        // Purpose: Based on the object it explicitly casts the object to that
        //type and calls the correct method based on the cast like it did 
        //with the interface and the classes (calls the correct method
        //for the interface because the child inherits (PhoneBooth and Tardis) from the parent classes
        //(PushButtonPhone and RotaryPhone) and can use their 
        //methods and the parent classes have the methods from IPhoneInterface)
        // Restrictions: None
        static void UsePhone(object obj)
        {
            if(obj is IPhoneInterface)
            {
                IPhoneInterface castedInter = (IPhoneInterface)obj;
                castedInter.MakeCall();
                castedInter.HangUp();

            }

            if(obj is PhoneBooth)
            {
                PhoneBooth castedBooth = (PhoneBooth)obj;
                castedBooth.OpenDoor();
            }

            if(obj is Tardis)
            {
                Tardis castedTardis = (Tardis)obj;
                castedTardis.TimeTravel();
            }
        }
    }
}
