using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PeopleAppGlobals;
using PeopleList;

namespace WindowsPeopleApp
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Globals.AddCoursesSampleData(); //we have to reference the lists (one for courese and one for people)
                                            //we created in peopleappglobals (why do we need to reference it here in the main because
                                            //peolelistform already has access to the lists to create the entries in the form)**
        
            Globals.AddPeopleSampleData();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //we need to make a new peoplelistform to represent a new form being created and this will be the main form
            //so thats why we put it in the application.run in the main program so that it will run as the main program**
            //so we need to have a seperate console application like this to run the main form then do .show() for the rest of the things we want to do 
            //in the peoplelistform which is the main form that will run and the other forms are bsically support for the main form**
            //why did we have another .cs program that had personeditform as the main program do we deleet that??** we cant have 2 main forms

            //the main form only has this within it right**
            Application.Run(new PeopleListForm());
        }
    }
}

//personeditform designer
//tabcontrol has a tab pages which defined the different tabs on the tabs control and we have the different tabs sa we can see when
//we press the 3 dots since its a collection
//and we can add the same way as the listview control like we did with those collections**
//the order that these are based on the arrow and not displayindex like listview item with their collection**
//we can also set name and text of the control 
//in the courses tab theres a selected courses and all courses listview and we have event handlers to press enter on each course and
//populating the listview based on what we selected**

//our details tab page has our cancel ok button and our texboxes and everything and we changed it in the loop in the personedit form to go through the container rather
//than the main form which does not exist anymore because the container is there**
//the fields are still members of our form though because and not moved to the details page tab because**
//controls are now in a container**
