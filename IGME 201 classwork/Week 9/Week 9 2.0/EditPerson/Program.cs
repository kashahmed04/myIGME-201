using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditPerson
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new PersonEditForm()); //we still have a main in our editperson which was the original code that was written when we created
            //out aplpiction and even though we converted it to dll it has a main so one solution is to comment out the line because the only main that
            //will be called is inside of peopleapp and one main per application** (only one main in the startup applicaiton and the bolded thing in solution
            //explorerer is the windows peopleapp in this case)*********************
            
        }
    }
}
