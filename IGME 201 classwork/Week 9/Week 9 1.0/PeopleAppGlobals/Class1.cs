using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//we put using people lib and using course lib above here so we can access it (does it do it automatically like we did before)**

//why do we need this again**
//it needs to access our people lib and course lib to create the list and we copy and paste the folders into the same folder as the dll and where all of our files are**
//in people lib we want to rebuild the solution and inside of peoplelib inside are the definitions of the peoplelib and inside are the student and teacher objects we create
//and we have a peolpe class**
//in course lib we also want to rebuild solution so we can make people lib and course lib both dll's and we want to add references to the peopleglobal windows form
//and we go to debug in course lib and people lub and add that as a reference**

//
namespace PeopleAppGlobals
{
    public static class Globals //making this static because** 
    {
        public static People people = new People();
        public static Course course = new Course(); 

        //we have a method for adding the courses and people so and we create the people and courses variables
        //(objects) that contains the list of our people(student and teacher)
        //and courses
    }
}
