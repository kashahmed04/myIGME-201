using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace EditPerson
{
    public partial class PersonEditForm : Form
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

            this.okButton.Enabled = false;


            //each of our textboxes we want to make sure they are not blank as we subtit the form**
            this.nameTextBox.Validating += new CancelEventHandler(TxtBoxEmpty__Validating);
            //if its set to true it will call this*******
            //use += for what(for delegate methods)**(we pass in method name for the delegate (the two __) methods**

            this.emailTextBox.Validating += new CancelEventHandler(TxtBoxEmpty__Validating);//makes sure no textbox is empty**
            this.ageTextBox.Validating += new CancelEventHandler(TxtBoxEmpty__Validating); //numeric type 
            this.specTextBox.Validating += new CancelEventHandler(TxtBoxEmpty__Validating);
            this.gpaTextBox.Validating += new CancelEventHandler(TxtBoxEmpty__Validating); //numeric type
            this.licTextBox.Validating += new CancelEventHandler(TxtBoxEmpty__Validating); //numeric type 

            this.emailTextBox.TextChanged += new EventHandler(TxtBoxEmpty__TextChanged);//makes sure textbox is empty to set status**
            this.ageTextBox.TextChanged += new EventHandler(TxtBoxEmpty__TextChanged); //numeric type 
            this.specTextBox.TextChanged += new EventHandler(TxtBoxEmpty__TextChanged);
            this.gpaTextBox.TextChanged += new EventHandler(TxtBoxEmpty__TextChanged); //numeric type
            this.licTextBox.TextChanged += new EventHandler(TxtBoxEmpty__TextChanged); //numeric type 

            this.ageTextBox.KeyPress += new KeyPressEventHandler(TxtBoxNum__KeyPress); //makes sure numeric value is apssed in**
            this.gpaTextBox.KeyPress += new KeyPressEventHandler(TxtBoxNum__KeyPress);
            this.licTextBox.KeyPress += new KeyPressEventHandler(TxtBoxNum__KeyPress);//where is the naming convention for delegates**
            //delegate method for everytime a key is pressed the user presses a key and make sure they type a numbers**
            //ensure they can only type numbers in those numeric fields** 

            //we call this method for all of our fields so we can validate so we make sure nothing is left blank**

            //selectedindexchanged for the combobox will check if its a student and show the gpa field as well**

            this.typeComboBox.SelectedIndexChanged += new EventHandler(TypeComboBox__SelectedIndexChanged);

            this.cancelButton.Click += new EventHandler(CancelButton__Click); //aways define our events dont do it in designer otherwise
            //it goes into hidden designer code and its hard to find**

            //write all event handlers in constructor so we cna see them and write the methods below**

            //we can now change contents of the textbixes (first set up all event handling then load the textboxes with the data we need**
            //pass a person variable in our form to the constructor but it does now know what a person class is because we did not
            //include peoplelib into our project yet (we need to do that)

            //


        }


        private void CancelButton__Click(object sender, EventArgs e)
        {
            this.Close(); //closes the window**
            this.Dispose(); //gets rid of everything input in the textboxes**
        }
        private void TypeComboBox__SelectedIndexChanged(object sender, EventArgs e) //object is a combobox
            //student is element 0 and teacher is 1 so we use index 0 we want speciality label to hide and show the gpa there**
        {
            ComboBox cb = (ComboBox)sender;
            if(cb.SelectedIndex == 0)
            {
                this.specialtyLabel.Visible = false; //hides teachers specifciality**
                this.specTextBox.Visible = false;

                this.specTextBox.Tag = true; //we can set the box to valid so we dont have to input anything and we can still press ok to submit the form**

                this.gpaLabel.Visible = true;
                this.gpaTextBox.Visible = true; //set the label and texbox to true so its visible to user
                this.gpaTextBox.Tag = (this.gpaTextBox.Text.Length > 0);//what does this do**
            }
            else
            {
                this.specialtyLabel.Visible = true;
                this.specTextBox.Visible = true;

                this.gpaTextBox.Tag = true; 

                this.gpaLabel.Visible = false;
                this.gpaTextBox.Visible = false; 

                this.specTextBox.Tag = (this.specTextBox.Text.Length > 0);//what does this do**
            }
            ValidateAll();

        }
        private void TxtBoxEmpty__TextChanged(object sender, EventArgs e) //this makes sure the textbox is empty to put something in
        {
            TextBox tb = (TextBox)sender;
            if (tb.Length)
            {
                this.errorProvider1.SetError(tb, "This field cannot be empty");
                tb.Tag = false;
            }
            else
            {
                
            }
            ValidateAll();
        }
        private void TxtBoxNum__KeyPress(object sender, KeyPressEventArgs e) //why did we make private**
        {
            TextBox tb = (TextBox)sender;
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == '\b'){ //check if something is a digit by using char and the \b does**
                e.Handled = false; //handled means if we handle it or not but if we set it to true it means we are doing special but if we
                //set it to false, then we want windows to do their defulat for keypressed*****
                tb.Tag = true;
            }
            else //does not let letters show up and we can type numbers (where is it in the code)**
            {
                e.Handled = true; //windows will not handle it and will not show up in the textbox**
                if(tb == this.gpaTextBox) //check if something is typed in the textbox**
                {
                    if(e.KeyChar == '.' && !tb.Text.Contains(".")) //if they typed in a point and there was not a point there already
                        //then we let windows take care of it with their own method(default)**
                    {
                        e.Handled = false;
                        tb.Tag = true;
                    }
                }
            }

            ValidateAll();//why and where do we need this**
        }

        //delegates can be public or private does not matter**
        public void TxtBoxEmpty__Validating(object sender, CancelEventArgs e) //what does this do again**(sees if textbox is empty for each textbox)
        {
            TextBox tb = (Textbox)sender; //what does this do**

            if(tb.Length == 0)
            {
                this.errorProvider1.SetError(tb, "This field cannot be empty");
                e.Cancel = true;
                tb.Tag = false;
            }
            else
            {
                this.errorProvider1.SetError(tb, null);
                e.Cancel = false;
                tb.Tag = true; //we can always set ibject variable to a more specific type (like obj to class
                //but not class to obj because we are going from lower to higher so we need to cast it explicitly)**s
            }
            //need to point to textbox and we need to cast object sender as a textbox (explicitly cast because its an object)
            //ibject is higher and we are accessing from lower**

            ValidateAll();
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
    }
}


