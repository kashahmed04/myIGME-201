using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles;

namespace Traffic
{
    // Class: Program
    // Author: Kashaf Ahmed
    // Purpose: Implements code from the vehicles application
    // Restrictions: None
    internal class Program
    {
        static void Main(string[] args)
        {
            FreightTrain train = new FreightTrain();
            AddPassanger((IPassangerCarrier)train);//cant be converted implicitly to the 
            //interface but we can fix it by this statement above (Is this correct?)(1)*****

            //but why does the () matter here why does it have to be around the interface? How do we know where to put the () when converting explicitly(2)**********

            //it makes the train variable is now accessible with the IPassangerCarrier for the method only?(3)******

            //If we had the FreightTrain and we called the LoadPassanger with explicit casting to the interface, how would it access the****
            //method since the interface is only a reference to the method within certain classes that have the method and the FreightTrain does not have it?(4)******
        }

        // Method AddPassanger
        // Author: Kashaf Ahmed
        // Purpose: Calls the LoadPassanger method when we pass in an an object that the interface references and then takes that object and does the toString() method to it
        // Restrictions: None
        static void AddPassanger(IPassangerCarrier passangerCarrier) //why do we have to convert explicitly if we are saying its this interface type in this statement(5)*****
        {
            passangerCarrier.LoadPassanger();
            Console.WriteLine(passangerCarrier.ToString()); //what happens when we make
                                                              //instances a string(6)*******
        }
    }
}
