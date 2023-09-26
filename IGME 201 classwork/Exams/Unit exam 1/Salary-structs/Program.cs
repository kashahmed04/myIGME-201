using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salary_structs
{
    // Class: Program
    // Author: Kashaf Ahmed
    // Purpose: Ask the user for their name and if they get the name right ("KASH" in all toUpper when it gets converted,
    //then we increase their salary and tell them they got a raise, otherwise we tell them they did not get a raise
    // Restrictions: None
    static internal class Program
    {

        // Method: Main
        // Author: Kashaf Ahmed
        // Purpose: Creates the name and salary variables then we go into GiveRaise() and check if true was returned if the name was
        // equal to "KASH" in .toUpper, and if it was we say that they got a raise otherwise we say that they did not get a raise
        // Restrictions: None
        static void Main(string[] args)
        {
            string sName;
            double dSalary = 30000;

            Console.WriteLine("What is your name?");
            sName = Console.ReadLine();

            if(GiveRaise(sName, ref dSalary)) //so computer does not have to compare twice since it already does in the function
            {
                Console.WriteLine("Congrats! Your got a raise!");
            }
            else
            {
                Console.WriteLine("Imagine not getting a raise....");
            }

        }

        // Method: GiveRaise()
        // Author: Kashaf Ahmed
        // Purpose: Checks if user input == "KASH" with .toUpper and if it is we return true otherwise we return false
        // Restrictions: None

        static bool GiveRaise(string name,ref double salary) //call by ref. so it changes the salary variable directly 
        {
            if(name.ToUpper() == "KASH")
            {
                salary += 19999.99;
                return true;
            }

            else
            {
                return false;
            }
        }
    }
}
