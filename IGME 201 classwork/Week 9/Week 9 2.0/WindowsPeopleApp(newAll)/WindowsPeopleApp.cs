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
            //so that why we put it in the application.run in the main program that will run**
            Application.Run(new PeopleListForm());
        }
    }
}
