using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//forgot to add static to internal class program is that ok or should I go back and redo it in exam because by default it was not defined there**

//if we look in the designer and the combobox in window is a textbox that has a limited amount of options
//and for our person type we want that to be limited to a student and teacher and to define what the available options are we click on the items prop.
//and its a collection which is just a list and each line is an option in the combobox and the first item is student and the second is teacher
//and when we check to see which one is selected in c# we count that from the 0th index

//the & is for a menu item to make it an underlined letter so we can use the keyboard instead of mouse to use the menu

//every one of these controls has a name and its (Name) because we use that name to access the fields in our code we usually put the name of how we want to access
//something in this .cs file in the "Name" property within our designer 

//the form is the class and the fields are whatever we name the things in the form is the field (pascalcase for the form but camelcase for the fields)


//change the "Name" of the form in the Form1 property and its pascalcase because the form itself is the name of our class and the other things within that
//class in camelcase
//each form in windows form is a class and each control is a member of that class
//the form designer generates our controls and puts it as the intiializecmponent which is build in (we put all of our code below the initizlizecomponent usually)

//whenever we do windows forms development we must make it partial because the class is used between files and visual studi creates code for us in the designer.cs
//file and in the forms.cs that we edit we continue to define the class and its because the class is spread across multiple classes we have to use partial with it 
//and we need to use partial in each file because its spread across multiple files 

//the designer.cs adds the things we put within our form into the designer.cs file and the code along with it (the prop.) to set the button or textbox or whatever
//thing we set and we write event handlers explicitly for all of the objects rather than writing the method then going over to grid and filling it in with the methods
//if we double click on something and it creates a method in the form1.cs and we should just leave it 

//our form is the this keyword and the controls is used for all of the controls on the form and its built in for all of our controls
//this is in the form.designer.cs and its hidden from us and we dont modify at all because its automatically built in

//when we run a winsows application, all of the controls are interactive and triggeres events on that control that are calling delagte methods that
//lets us do what we want with the menu for exameple
//windows forms is all delegates and in the windows forms control document in the textbox category control, and it tells us the important properties
//and fields we need to work with and the validating event and the deleate method signature is also given there and in the code we wrote in the
//validating event it we hover over the validating event it tells us it's a cancel event handler type (delegate method type)(like when we wrote our own method to round)
//and here we do new canceleventhandler delegate datatype and it gives us the method signature for it and when we write our method to handle the event, our method
//needs to match the method signature that is written when we hover over the delegate method
//when we wrote out txtboxempty__validating it followed that delegate method signature and it also tells us in the documentation for windows forms controls)
//the delegate methods are defined for us already in windows forms

//we want to do specific code when the user changes a value and we use events associated with that contorl and in properties theres an evenet icon and for the combobox
//control we have 100 possible events that could be triggered and we can add methods in here to be called in here when events are triggered but
//the mapping is hid in the lightning
//panel


//to know what the method needs to look like its in the windows forms control documentation
//and we go to the combobox secttion and it tells us the metho signature it needs to have
//and it needs to accept and object and an eventargs and if we need to create a method we deleted by accident,
//we go to the windows forms control document and recreate
//the name of the method(we need to have all the methods assocated with each thing in the deisnger)
//we always do the thing (fields) we are doing the event on __ the event for the method signtaure
//not every contorl needs to have a delegate with it like the container control for the mdi

//if we double click a control and it makes a method in the form1.cs, then we just leave it as an empty method even if we dont do anything
//we are going to use our own names for delegate methods and we will add them within the code ourself

//the intializecomponent must be the first function call in our form1 and dont put anything above it

//every control has a tag property and when we look at the properties(wrench icon)(look at everything in alpabetical order with the a z icon)
//tag is of the object datatype and we can use it to attach any kind of data to the control
//and we want to know if there is valid daat that has been entered in every field and
//we do for each (control in this.controls) (the list of all of the controls in designer)

//go to toolbix then add error provuder by dragging it to the form and it does not show on the form usually but its associated with the form so we can display error messages
//on the form like we had done if one of the fields were not filled in 

namespace EditPerson
{
    public partial class PersonEditForm : Form //partial class for personeditform and we need to use partial because we are using multiple files with each other
    {
        public PersonEditForm()
        {
            /******************************************************************************************
             **************THIS MUST BE THE FIRST FUNCTION CALL IN YOUR FORM CONSTRUCTOR **************
             ******************************************************************************************/
            InitializeComponent();

            foreach (Control control in this.Controls) //explicitly to keep track of whether the data on the form is valid but there may be other forms where
                //they can keep things blank (the form has a property called controls that has the list of all the controls on the list
                //the Control is the parent class of the controls on our form (the list of the this.Controls is also made for us)
            {
                // use Tag property to indicate valid state
                //explicitly write delegate method for the event handlers for validation (we have to say it explicitly for validation)
                //in windows forms control documentation the tag is an object prop. (variable attached to control to use for whatever we want any data type)
                //the tag prop. is like a generic field for anything we want and it's built into every control
                //way to save any information we want
                //this means everything on the form starts off as invalid 
                control.Tag = false;
            }

            //each of our textboxes we want to make sure they are not blank as we submit the form
            this.okButton.Enabled = false;
            //if its set to true it will allow the user to press ok
            //the this keyword allows the user to do stuff
            //use += for what(for delegate methods)(we pass in method name for the delegate (the two __) then name of method
            //when we click the ok button if we dont have any delegate method assigned to it 

            //we can add as many delegate methods we want but we do += here

            this.nameTextBox.Validating += new CancelEventHandler(TxtBoxEmpty__Validating); //makes sure no textbox is empty(go over)
            this.emailTextBox.Validating += new CancelEventHandler(TxtBoxEmpty__Validating); //the validating methods prevent them from leaving box empty so we can
            //use the same exact method for all of our textboxes because we want the same rule to apply and we used a generic first part txtboxempty
            //and we can apply it to all of the controls so we dont have to write method for same thing over and over so in this case
            //we can do generic name otherwise follow coding standards
            this.ageTextBox.Validating += new CancelEventHandler(TxtBoxEmpty__Validating); //numeric type 
            this.specTextBox.Validating += new CancelEventHandler(TxtBoxEmpty__Validating);
            this.gpaTextBox.Validating += new CancelEventHandler(TxtBoxEmpty__Validating); //numeric type 
            this.licTextBox.Validating += new CancelEventHandler(TxtBoxEmpty__Validating); //numeric type 

            this.nameTextBox.TextChanged += new EventHandler(TxtBoxEmpty__TextChanged); //eventhandler is more grneric because it applies to a whole bunch of a events
            //and event handlers is more generic because its a method that handles events with no event data associated with it (appleis to many events)
            //on the windows forms control documentation 

            //only use prop. panel not the events lighting handle 
            this.emailTextBox.TextChanged += new EventHandler(TxtBoxEmpty__TextChanged);
            this.ageTextBox.TextChanged += new EventHandler(TxtBoxEmpty__TextChanged); //numeric type
            this.specTextBox.TextChanged += new EventHandler(TxtBoxEmpty__TextChanged);
            this.gpaTextBox.TextChanged += new EventHandler(TxtBoxEmpty__TextChanged); //numeric type
            this.licTextBox.TextChanged += new EventHandler(TxtBoxEmpty__TextChanged); //numeric type 

            this.ageTextBox.KeyPress += new KeyPressEventHandler(TxtBoxNum__KeyPress); //makes sure numeric value is passed in
            this.licTextBox.KeyPress += new KeyPressEventHandler(TxtBoxNum__KeyPress);
            this.gpaTextBox.KeyPress += new KeyPressEventHandler(TxtBoxNum__KeyPress);

            //delegate method for everytime a key is pressed the user presses a key and make sure they type a numbers
            //ensure they can only type numbers in those numeric fields 

            //selectedindexchanged for the combobox will check if its a student and show the gpa field as well

            this.typeComboBox.SelectedIndexChanged += new EventHandler(TypeComboBox__SelectedIndexChanged); //if we have eventhandler attached to this
            //it should match the name of the event we are handling

            this.cancelButton.Click += new EventHandler(CancelButton__Click);//aways define our events dont do it in designer otherwise
            //it goes into hidden designer code and its hard to find
            this.okButton.Click += new EventHandler(OkButton__Click);

          
            //we use += not = like we usually did because windows has a default method associated with controls and it has code under the hood
            //and does not throw an error and all of the events have a default method already so what we need to do is add to it already
            //because windows has its own stuff already that it needs to do and we can contiue adding and we can add multiple methods to
            //one event like clicked and stuff as well as the fields 

            //we can also add and remove event handlers as well with += and -=

            //this. field. event then the this. is optional 

            //write all event handlers in constructor so we cna see them and write the methods below

            //we can now change contents of the textbixes (first set up all event handling then load the textboxes with the data we need
            //pass a person variable in our form to the constructor but it does now know what a person class is because we did not
            //include peoplelib into our project yet (we need to do that)



        }

        private void CancelButton__Click(object sender, EventArgs e)
        {
            this.Close(); //closes the widnow
            this.Dispose(); //gets rid of everythig input in the textboxes (the memory the form is using)
        }


        private void TypeComboBox__SelectedIndexChanged(object sender, EventArgs e)//object is a combobox(object is usually the contol)
                                                                                    //student is element 0 and teacher is 1 so we use index 0 and we want
                                                                                    //speciality label to hide and show the gpa theres
                                                                                    //how do we know where the indexes are how do we create them
                                                                                    //(its in the list defined in the designer)
        {
            ComboBox cb = (ComboBox)sender;

            if( cb.SelectedIndex == 0 ) //this index is the student because of the combobox 
            {
                this.specialtyLabel.Visible = false; 
                this.specTextBox.Visible = false; 

                this.specTextBox.Tag = true; //we can set the specialty teacher
                                             //box to valid so we dont have to input anything and we can still press ok to submit the form
                                             //when we just have a gpa field and hide the specialty text box (nothing can be put in there since it was hidden
                                             //if it was false the ok button would never be enabled

                this.gpaLabel.Visible = true;
                this.gpaTextBox.Visible = true; //set the label and texbox to true so its visible to user

                this.gpaTextBox.Tag = (this.gpaTextBox.Text.Length > 0); //this delegate method is for changing the type and when select the combobox
                //this method gets called (and if we have the gpa set and make it a teacher the gpa is still stored that's why we check for length greater than 0)
                //still valid since previous data will be stored if we dont put anything
            }
            else //otherwise we know it's a teacher that's selected
            {
                this.specialtyLabel.Visible = true;
                this.specTextBox.Visible = true;

                this.gpaTextBox.Tag = true;

                this.gpaLabel.Visible = false; 
                this.gpaTextBox.Visible = false;

                this.specTextBox.Tag = (this.specTextBox.Text.Length > 0); 
            }

            ValidateAll(); //validates our data
        }

        private void TxtBoxEmpty__TextChanged(object sender, EventArgs e) 
                                                                  
        {
            TextBox tb = (TextBox)sender;
            if( tb.Text.Length == 0) //if the textbox is empty we set an error on our errorprovider and say that the specific textbox cant be empty 
            {
                this.errorProvider1.SetError(tb, "This field cannot be empty");
                tb.Tag = false; //if its empty we set an error and make the field empty
            }
            else
            {
                this.errorProvider1.SetError(tb, null); //we set it equal to null so it clears the error if it was there otherwise it does not do anything if there
                //was no error initially
                tb.Tag = true;
                //makes the control true and its filled in so it validates
            }

            ValidateAll();

       
        }

        private void TxtBoxNum__KeyPress(object sender, KeyPressEventArgs e) //if only defined in class make it private otherwise if it needs to be seen make it public
        {
            TextBox tb = (TextBox)sender;

            if( Char.IsDigit(e.KeyChar) || e.KeyChar == '\b') //check if something is a digit by using char.IsDigit(the thing that was clicked) and the \b does
                                                                //e.keychar is
            {
                e.Handled = false; //handled means if we handle it or not but if we set it to true it means we are doing something special for the event handler
                                   //but if we make it false windows handles it an puts it on the form
                                    //set it to false, then we want windows to do their defulat for keypressed
                                    //handled means if the develeoper is doing something or not (false the developer is not doing it and windows
                                    //should do it otherwise true and developer is doing it and windo1s leaves it)
                                  
                tb.Tag = true; //from the list of the controls, since this is filled in we are now valid for this specific textbox
            }
           
            else 
            {
                e.Handled = true; //windows will not handle it and will not show up in the textbox because we handle it

                //default is false for handled

                if ( tb == this.gpaTextBox) //when the user types something with the gpatextbox its going to call our delegate method
                                            //it passes our object in scope and object is the textbox control that they typed number in and the e will contain
                                            //the number we passed in (if its only the gpa textbox then we can pass in a decimal point otherwise no)
                                            
                {
                    if( e.KeyChar == '.' && !tb.Text.Contains(".")) //if they typed in a point and there was not a point there already
                                                                    //then we let windows take care of it with their own method(default)
                    {
                        e.Handled = false;
                        tb.Tag = true; //now the tag is set to true because now its filled in
                        //if we pass decimal points to other texboxes like license and age, then it won't work
                    }
                }
            }

            ValidateAll(); //have to do validate at the end of all methods to ensure that its true and be one step closer to unlocking ok button
        }

        public void TxtBoxEmpty__Validating(object sender, CancelEventArgs e) 
        {
            TextBox tb = (TextBox)sender;

           

            if (tb.Text.Length == 0)
            {
                this.errorProvider1.SetError(tb, "This field cannot be empty.");
                e.Cancel = true; //every control has a property called causesvalidation 
                //and what it means is that if we try to move to that field then it calls the validating for the field we just left not the one
                //we are entering (if we on name field and wanted to move to email) and if it was set to true on email field then windows calls
                //validating field on name field first and then in that way we can control if the user can leave the field or not if they entered something or not
                //(cant leave if its false) (windows should cancel moving to the next field)(e.cancel indicated whether the event can cancel or being not
                //and by default is false and if its true the current box will be in focus and if the current textbox is empty they wont be able to leave it until
                //they enter something)
                //cancel button is set to false for the causesvalidation so we can press cancel button anytime 

                //false does not allow us to leave while true does
                tb.Tag = false;
            }
            else
            {
                this.errorProvider1.SetError(tb, null);
                e.Cancel = false; 
                tb.Tag = true; //we can always set ibject variable to a more specific type (like obj to class
                //but not class to obj because we are going from lower to higher so we need to cast it explicitly)
            }

            //need to point to textbox and we need to cast object sender as a textbox (explicitly cast because its an object)
            //ibject is higher and we are accessing from lower

            ValidateAll();
        }

        private void ValidateAll()
        {
            this.okButton.Enabled =
                (bool)this.nameTextBox.Tag &&
                (bool)this.emailTextBox.Tag &&
                (bool)this.ageTextBox.Tag &&
                (bool)this.specTextBox.Tag &&
                (bool)this.gpaTextBox.Tag;
        }





        //validating event in windows forms control document under the textbox and what happens is that when we click on another
        //field and if the causesvalidation prop. is set to true (in prop. field in designer) and it will cause the field we left
        //to be validated by us somehow in our form1.cs when we write the code****

        //the cancel button we want causes validation to be false because we alwways want them to click cancel regardless of what there**
        //is entered on the form but the ok button needs validation to mkae sure the form is not empty when we press ok**
        //lightning bolt icon is for prop. and validating area dont use (where is it)**(which panel)**(Makes it hard to maintain and see the code)**
        //we wont be able to see it in our source code because we have to click our things in designer and see the events we have eneabled for**
        //the control**

        //in our windows forms it shows us method signature (delegate) to handle the event and name evenets with the object name
        //and two __ and we should use the two __ because c# names it with name of control in camelcase and it uses 1 _ then the event name
        //and it's obvious that we wrote the code (leave the code from the designer blank)** (dont remove it otherwise it will
        //cause more trouble)**

        public void typeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void OkButton__Click(object sender, EventArgs e)
        {

        }
        private void okButton_Click(object sender, EventArgs e)
        {

        }
    }
}
