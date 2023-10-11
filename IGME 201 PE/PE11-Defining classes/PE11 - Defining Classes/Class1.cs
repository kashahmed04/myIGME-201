using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Vehicles 
{
    public abstract class Vehicle
    {
        public virtual void LoadPassanger() //if we make it virtual how can it be empty doesnt it have 
            //to be abstract**
        {

        }
    } 

    public abstract class Car : Vehicle
    {

    }

    public interface PassangerCarrier 
    {
        void LoadPassanger();
    }

    public interface HeavyLoadCarrier
    {

    }

    public abstract class Train 
    {
        
    }

    public class Compact: Car, PassangerCarrier
    {
        public void LoadPassanger() //would we override from the parent here or 
            //just make a new LoadPassanger method per child (unique) because theres no :o
        {
            
        }
    }

    public class SUV: Car, PassangerCarrier
    {
        public void LoadPassanger() //only create the prop. and methods common in the interface and inherit**
            //but if its from another class we just over ride**
        {

        }
    }

    public class Pickup : Car, PassangerCarrier, HeavyLoadCarrier
    {
        public void LoadPassanger() 
        {

        }
    }

    public class PassangerTrain : Train, PassangerCarrier  //always put classes before interfaces here(only here??)**
    {
        public void LoadPassanger()
        {

        }
    }

    public class FreightTrain : Train, HeavyLoadCarrier
    {
      
    }

    public class _424DoubleBogey : Train, HeavyLoadCarrier
    {
    
    }

    public class Class1 //should we leave this as Class1 what does it do**
        //dll files dont usually have a main right** do we have to have this every dll
        //or can we take it out if we dont use it**
    {

    }
}
