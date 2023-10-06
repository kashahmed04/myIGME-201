using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Vehicles
{
    // Class: Vehicle
    // Author: Kashaf Ahmed
    // Purpose: Vehicle abstract class thats a parent to the child vehicles down below
    //that had a method called LoadPassanger()
    // Restrictions: None
    public abstract class Vehicle
    {
        public virtual void LoadPassanger() //if we make it virtual how can it be empty doesnt it have 
                                            //to be abstract? What is the difference between an empty virtual and empty abstract method?(1)*******
        {

        }
    }

    // Class: Car
    // Author: Kashaf Ahmed
    // Purpose: Inherits from the vehicle parent class 
    // Restrictions: None
    public abstract class Car : Vehicle
    {

    }

    // Interface: IPassangerCarrier
    // Author: Kashaf Ahmed
    // Purpose: References the LoadPassanger method 
    // Restrictions: None
    public interface IPassangerCarrier
    {
        void LoadPassanger();
    }

    // Interface: IHeavyLoadCarrier
    // Author: Kashaf Ahmed
    // Purpose: Interface that has nothing in it
    // Restrictions: None
    public interface IHeavyLoadCarrier
    {

    }

    // Class: Train
    // Author: Kashaf Ahmed
    // Purpose: Abstract class that has nothing in it but is a parent to certain classes
    // Restrictions: None
    public abstract class Train
    {

    }

    // Class: Compact
    // Author: Kashaf Ahmed
    // Purpose: Inherits from the Car class and the interface
    // Restrictions: None
    public class Compact : Car, IPassangerCarrier
    {
        public void LoadPassanger() //would we override from the parent here or******
                                    //just make a new LoadPassanger method per child (unique) because theres no :o in the shumul. Is that allowed?(2)******
        {

        }
    }


    // Class: SUV
    // Author: Kashaf Ahmed
    // Purpose: Inherits from the Car class and the interface
    // Restrictions: None
    public class SUV : Car, IPassangerCarrier
    {
        public void LoadPassanger() //only refernce the prop. and methods common in classes within the interface and the interface points to the classes*****
                                    //that has everything common within the interface*****
                                    //(AN INTERFACE IT NOT A CLASS/INSTANCE CANT HAVE OVERRIDES OR THEY CANT INHERIT)(other*******
                                    //classes can inherit from it though?)(is this definition correct of interfaces)(3)********
                                    
        {

        }
    }


    // Class: Pickup
    // Author: Kashaf Ahmed
    // Purpose: Inherits from the Car class and the interfaces
    // Restrictions: None
    public class Pickup : Car, IPassangerCarrier, IHeavyLoadCarrier
    {
        public void LoadPassanger()
        {

        }
    }


    // Class: PassangerTrain
    // Author: Kashaf Ahmed
    // Purpose: Inherits from the Train class and interface
    // Restrictions: None
    public class PassangerTrain : Train, IPassangerCarrier //Why do we always have to put classes before interfaces when we list them here(4)********
    {
        public void LoadPassanger()
        {

        }
    }

    // Class: FreightTrain
    // Author: Kashaf Ahmed
    // Purpose: Inherits from Train class and interface
    // Restrictions: None
    public class FreightTrain : Train, IHeavyLoadCarrier
    {

    }

    // Class: _424DoubleBogey
    // Author: Kashaf Ahmed
    // Purpose: Inherits from Train class and interface
    // Restrictions: None
    public class _424DoubleBogey : Train, IHeavyLoadCarrier
    {

    }


    // Class: Class1
    // Author: Kashaf Ahmed
    // Purpose: Does nothing (default for dll)
    // Restrictions: None
    public class Class1 //should we leave this as Class1 in the dll's? what does it do?(5)******
                        //dll files dont usually have a main right(6)******
                        
    {

    }
}

