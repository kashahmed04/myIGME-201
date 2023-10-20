using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

//each of these controls is a windows control and in the properties panel we have all of the properties assocated with that control and****
//we have a typecombobox which has an items property and it has a list of possible values and it pops up a diolouge for a list of strings in the dioglouge*****
//every one of these controls has a name and its (Name) because we use that name to access the fields in our code*****
//change the name of the form in the Form1 property and its camelcase because the form itself is the name of our class and the other things within that**
//class in pascalcase**
//each form in windows form is a class and each control is a member of that class**
//the form designer generates our controls and putsit as the intiializecmponent which is build in****
//under the form1 in the solution exploerer and if we expand form1.cs we see that form1.designer is also in there thats why the class
//is partial because its added to the designer****

//it automcatically creates all of our objects in the class and it creates a new button object that cancel button points to and uses the keyword and it makes it explicit
//its then setting all the properties of those objects as they were deisnged in the property panel in the designer
//the desinger does a lot of work from us but is also hidden from us**
//our form is the this keyword and the controls is used for all of the controls on the form and its built in for all of our controls
//this is in the form.designer.cs and its hidden from us and we dont modify at all because its automatically built in*****

//when we run a winsows application, all of the controls are interactive and triggeres events on that control that are calling delagte methods that 
//lets us do what we want with the menu for examepl**
//we want to do specific code when the user changes a value and we use events associated with that contorl and in properties theres an evenet icon and for the combobox
//control we have 100 possible events that could be triggered and we can add methods in here to be called in here when events are triggered but the mapping is hid in the lightning 
//panel**

//each thing has its own evenhanlder and if we double click it in the designer makes a method for us with that control**
//the type combobox has a delgate method and the method does not exist anymore because we had deleted it and its hidden because form1designer is hidden form us
//and if we take out a method it gives us an error????(where was the error)****


//to know what the method needs to look like its in the windows forms control and we go to the combobox secttion and it tells us the metho signature it needs to have
//and it needs to accept and object and an eventargs and if we need to create a method we deleted by accident, we go to the windows forms control document and recreate
//the name of the method*****(we need to have all the methods assocated with each thing in the deisnger??)**
//we always do the thing we are doing the event on _ the event for the method signtaure*****

//if we double click a control and it makes a method in the form1 designer, then we just leave it as an empty method even if we dont do anything****
//we are going to use our own names for delegate methods and we will add them within the code ourself****

//the intializecomponent must be the first function call in our form1 and dont put anything above it*****


namespace EditPerson
{
    //every control has a tag property and when we look at the properties(wrench icon)(look at everything in alpabetical order with the a z icon)**
    //tag is of the object datatype and we can use it to attach any kind of data to the control* 
    //and we want to know if there is valis daat that has been entered in every field and**
    //we do for each control in this.controls (the list of all of the controls in designer)**
    //and we want to set the tag proeprty to false**
    //and for the accept and cancel button in the main form1 of editperson property we can set it ok to cancelbutton****(usually will be there??)**

    //go to toolbix then add error provuder by dragging it to the form and it does not show on the form usually but its associated with the form so we can display error messages
    //on the form****
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
