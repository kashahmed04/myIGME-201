using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


//add a reference to peoples list here so we have an executable
//so now we have access to peolpe list and put a using PeopleList;
//in our main applicaiton we want to do run new peoplelistform (the name of the class)
//and for forms we should have "form" in our class name declaration 

//we also add people app globals as a refernece because its our database and we also do a using statemnt
//and we want to add the addcoursessamepledata and the addpeoplesampledata
//this sets up our data base and launches the first form

//and now we can put all of our projects in one solution otherwise we would need to switch between solutions
//we can go to solution then add existing project
//then we go through one by one and add the actual c# files 
//and it gives us one solutions and everything depends on each other
//we also add the actual source code in the peopleappglovals even though we already added a refernce 

//now we set up dependencies  so we go to the actual solution then right clik then project depenecdies then we do that
//windowspeople app depends on peopleappfgloval and peoplelist 
//and then we go to drop down set set the dependencies 

//then when we press ok then go back and look at build order we see the order has been changed based on the dependencies

//the highlighted project is the one thats going to run when we start without debugging
//editperson is defined to create an executable not a dll so so we right lcick on edit person then change the ourput type to be a class library type
//then rebuild the solution 

//and now we have a windows people app executable and now we have our people list with our 100 sample people and we have noe finished coding that if we press
//enter we disbale the form and now we cant exit so now we have to launch the edit person form****

//our main here it launches our people list form which is in people list

//we need to go to editperon then add the dll to the peoplelist and in our people list we need to add using editperon; and
//we need to rename our source files so that they are clearer as we edit them and in edit person we edit it to be named edit person.cs
//now we included the dll within the personlist, we can now declare it and have a new object of that type and now we want to pass in the person we are editing and the
//parent form


//our constructor does not take in any para. for the personeditform so we add those para. from the contructor
//and add peoplelib as a reference to edit person (personedit form now) and now we say Form parentForm
//and we wnt to center it on the parent form when it displays and we need to know who created us and we are passing in the form that created the personeditform**

//we can call the show method based on the object to show and activate that form or in the personeditform we can call this.show() to show the form**
//how can we do show and why would we want to do show****

//always put this.show() at the end of the construtor

//in the peoplelistform we now make a method for the item activate if something is double clicked
// private void peoplelistview__itemactivate(object sender, eventargs e){
//          listview lv = (listview)sender
            //we maybe have not double clicked so we need to have a try catch for when they actually double click**
            //try{
            //     string email = (string)lv.selecteditems[0].tag
            //      Person person = null;
                    //person = Globals.peolpe[email]
                    //this.enabled = false;
                    //if the show command is in constructor then we dont have to save varible pointing to form if we dont need it
                    //new personeditform(person,tshi)
                    //if the show is not in the constructor would we have to create a varible then do .show()
            //}
//}
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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
