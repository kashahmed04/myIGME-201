﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


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

//every control has a tag property and when we look at the properties(wrench icon)(look at everything in alpabetical order with the a z icon)**
//tag is of the object datatype and we can use it to attach any kind of data to the control* 
//and we want to know if there is valis daat that has been entered in every field and**
//we do for each control in this.controls (the list of all of the controls in designer)**
//and we want to set the tag proeprty to false**
//and for the accept and cancel button in the main form1 of editperson property we can set it ok to cancelbutton****(usually will be there??)**

//go to toolbix then add error provuder by dragging it to the form and it does not show on the form usually but its associated with the form so we can display error messages
//on the form****
//we only want to show the ok button if all of the data is valid on the form and we start by initializing our enabled state of our ok button to be false**

namespace EditPerson
{
    public partial class PersonEditForm : Form //contrusctor for person editform**
    {
        public PersonEditForm()
        {
            /******************************************************************************************
             **************THIS MUST BE THE FIRST FUNCTION CALL IN YOUR FORM CONSTRUCTOR **************
             ******************************************************************************************/
            InitializeComponent();

            foreach (Control control in this.Controls)
            {
                // use Tag property to indicate valid state
                //explicitly write delegate method for the event handlers for validation**
                control.Tag = false;
            }

            //each of our textboxes we want to make sure they are not blank as we subtit the form**
            this.okButton.Enabled = false;
            //if its set to true it will call this*******
            //use += for what(for delegate methods)**(we pass in method name for the delegate (the two __) methods**

            this.nameTextBox.Validating += new CancelEventHandler(TxtBoxEmpty__Validating); //makes sure no textbox is empty**
            this.emailTextBox.Validating += new CancelEventHandler(TxtBoxEmpty__Validating);
            this.ageTextBox.Validating += new CancelEventHandler(TxtBoxEmpty__Validating); //numeric type 
            this.specTextBox.Validating += new CancelEventHandler(TxtBoxEmpty__Validating);
            this.gpaTextBox.Validating += new CancelEventHandler(TxtBoxEmpty__Validating); //numeric type 
            this.licTextBox.Validating += new CancelEventHandler(TxtBoxEmpty__Validating); //numeric type 

            this.nameTextBox.TextChanged += new EventHandler(TxtBoxEmpty__TextChanged); //makes sure textbox is empty to set status**
            this.emailTextBox.TextChanged += new EventHandler(TxtBoxEmpty__TextChanged);
            this.ageTextBox.TextChanged += new EventHandler(TxtBoxEmpty__TextChanged); //numeric type
            this.specTextBox.TextChanged += new EventHandler(TxtBoxEmpty__TextChanged);
            this.gpaTextBox.TextChanged += new EventHandler(TxtBoxEmpty__TextChanged); //numeric type
            this.licTextBox.TextChanged += new EventHandler(TxtBoxEmpty__TextChanged); //numeric type 

            this.ageTextBox.KeyPress += new KeyPressEventHandler(TxtBoxNum__KeyPress); //makes sure numeric value is apssed in**
            this.licTextBox.KeyPress += new KeyPressEventHandler(TxtBoxNum__KeyPress);
            this.gpaTextBox.KeyPress += new KeyPressEventHandler(TxtBoxNum__KeyPress); //where is the naming convention for delegates**

            //delegate method for everytime a key is pressed the user presses a key and make sure they type a numbers**
            //ensure they can only type numbers in those numeric fields** 

            //we call this method for all of our fields so we can validate so we make sure nothing is left blank**

            //selectedindexchanged for the combobox will check if its a student and show the gpa field as well**

            this.typeComboBox.SelectedIndexChanged += new EventHandler(TypeComboBox__SelectedIndexChanged);

            this.cancelButton.Click += new EventHandler(CancelButton__Click);//aways define our events dont do it in designer otherwise
            //it goes into hidden designer code and its hard to find**

            //write all event handlers in constructor so we cna see them and write the methods below**

            //we can now change contents of the textbixes (first set up all event handling then load the textboxes with the data we need**
            //pass a person variable in our form to the constructor but it does now know what a person class is because we did not
            //include peoplelib into our project yet (we need to do that)



        }

        private void CancelButton__Click(object sender, EventArgs e)
        {
            this.Close(); //closes the widnow**
            this.Dispose(); //gets rid of everythig input in the textboxes**
        }


        private void TypeComboBox__SelectedIndexChanged(object sender, EventArgs e)//object is a combobox**
                                                                                    //student is element 0 and teacher is 1 so we use index 0 we want speciality label to hide and show the gpa there**
                                                                                    //how do we know where the indexes are** how do we create them**
        {
            ComboBox cb = (ComboBox)sender;

            if( cb.SelectedIndex == 0 )
            {
                this.specialtyLabel.Visible = false; //hides teachers specifciality**
                this.specTextBox.Visible = false;

                this.specTextBox.Tag = true; //we can set the box to valid so we dont have to input anything and we can still press ok to submit the form**

                this.gpaLabel.Visible = true;
                this.gpaTextBox.Visible = true; //set the label and texbox to true so its visible to user

                this.gpaTextBox.Tag = (this.gpaTextBox.Text.Length > 0); //what does this do**
            }
            else
            {
                this.specialtyLabel.Visible = true;
                this.specTextBox.Visible = true;

                this.gpaTextBox.Tag = true;

                this.gpaLabel.Visible = false;
                this.gpaTextBox.Visible = false;

                this.specTextBox.Tag = (this.specTextBox.Text.Length > 0); //what does this do**
            }

            ValidateAll(); //where did we make this and how do we know know where to put it**
        }

        private void TxtBoxEmpty__TextChanged(object sender, EventArgs e) //this makes sure the textbox is empty to put something in**
        {
            TextBox tb = (TextBox)sender;
            if( tb.Text.Length == 0)
            {
                this.errorProvider1.SetError(tb, "This field cannot be empty");
                tb.Tag = false;
            }
            else
            {
                this.errorProvider1.SetError(tb, null);
                tb.Tag = true;
            }

            ValidateAll();
        }

        private void TxtBoxNum__KeyPress(object sender, KeyPressEventArgs e) //why did we make private (why for the rest of the private as well**
        {
            TextBox tb = (TextBox)sender;

            if( Char.IsDigit(e.KeyChar) || e.KeyChar == '\b') //check if something is a digit by using char and the \b does**
            {
                e.Handled = false; //handled means if we handle it or not but if we set it to true it means we are doing special but if we
                                    //set it to false, then we want windows to do their defulat for keypressed*****
                tb.Tag = true;
            }
            else //does not let letters show up and we can type numbers (where is it in the code)**
            {
                e.Handled = true; //windows will not handle it and will not show up in the textbox**

                if ( tb == this.gpaTextBox) //check if something is typed in the textbox**
                {
                    if( e.KeyChar == '.' && !tb.Text.Contains(".")) //if they typed in a point and there was not a point there already
                                                                    //then we let windows take care of it with their own method(default)**
                    {
                        e.Handled = false;
                        tb.Tag = true;
                    }
                }
            }

            ValidateAll(); //why and where do we need this**
        }


        //delegates can be public or private does not matter**
        public void TxtBoxEmpty__Validating(object sender, CancelEventArgs e) //what does this do again**(sees if textbox is empty for each textbox)
        {
            TextBox tb = (TextBox)sender; //what does this do**

            if (tb.Text.Length == 0)
            {
                this.errorProvider1.SetError(tb, "This field cannot be empty.");
                e.Cancel = true;
                tb.Tag = false;
            }
            else
            {
                this.errorProvider1.SetError(tb, null);
                e.Cancel = false;
                tb.Tag = true; //we can always set ibject variable to a more specific type (like obj to class
                //but not class to obj because we are going from lower to higher so we need to cast it explicitly)**
            }

            //need to point to textbox and we need to cast object sender as a textbox (explicitly cast because its an object)
            //ibject is higher and we are accessing from lower**

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


        //method called validate all that will set our values to true when the ok button is pressed*****





        //validating event in windows forms control document under the textbox and what happens is that when we click on another
        //field and if the causesvalidation prop. is set to true (in prop. field in designer) and it will cause the field we left
        //to be validated by us somehow in our form1.cs when we write the code****

        //the cancel button we want causes validation to be false because we alwways want them to click cancel regardless of what there
        //is entered on the form but the ok button needs validation to mkae sure the form is not empty when we put stuff in**
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

        private void okButton_Click(object sender, EventArgs e)
        {

        }
    }
}
