using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Salary_structs2
{
    //struct for Employee inform.
    struct Employee
    {
        public string sName;
        public double dSalary;
    }

    // Class: Program
    // Author: Kashaf Ahmed
    // Purpose: We make a new employee object and we ask for their name and read it in. After,
    //we call the GiveRaise() method with a reference to the employee object so that GiveRaise() can
    //have access to the employee object we had created in main (points in the same location in memory).
    //If the name == "kash" when we do .toLower, then we incrase their salary and tell them they got a raise
    //otherwise we display to the console that they did not get a raise 
    // Restrictions: Nonee
    static internal class Program
    {

        // Method: Main
        // Author: Kashaf Ahmed
        // Purpose: Create the employee object and ask the user for their name
        //and call the GiveRaise(), with a reference to the employee object so that
        //the method and the object from main point to the same place in memory.
        //if the GiveRaise return true we tell them they got a raise otherwise we say they
        //did not get a raise
        // Restrictions: None
        static void Main(string[] args)
        {
            Employee employee = new Employee();

            Console.WriteLine("What is your name?");
            employee.sName = Console.ReadLine();


            if (GiveRaise(ref employee)) //dont need true since we compared already
            {
                Console.WriteLine("Congrats! Your got a raise!");
            }
            else
            {
                Console.WriteLine("Imagine not getting a raise....");
            }
        }


        // Method: GiveRaise
        // Author: Kashaf Ahmed
        // Purpose: Ref. the Employee object we had made in main and we check if the name == "kash"
        //in .toLower, and if its is we increase their salary and return true, otherwise return false
        // Restrictions: None
        static bool GiveRaise(ref Employee employee) //gives us access to the employee object in main 
        {
            if (employee.sName.ToLower() == "kash")
            {
                employee.dSalary += 19999.99;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
