using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PeopleLib;
using PeopleAppGlobals;


//all courses listview has all courses from 200-299 and the top listview for the courses contains the selected courses for the students
//on the details page we have a lot more controls and now we want to do the picturebox control
//picturebox lets us show images on our form and we can customize the shape to have any shape we want and the picturebox is inside the groupbox
//and the groupbox allows us to give the caption and border around the picture itself******


//when our application runs we want to be able to click the photo and what image we want to put for the student*********
//and it stores the imave that we have put in the photobox for the student****
//we first want to handle when they click the picture box (clicked event in constructor)*****
//for exam 3 we will be writing president application

//whatever contorl shows up on the bottom of the designer its not visual and opens seperately or its not associated with any specific location
//on the form*********************************
//the openddialouge allowws us to open the file exploerer functinoality*****

//datetime picker is from January 1 1753 and if we go lower then it throws an error*****
//so we need to have it so if their birthdate is before 1753 it won't throw an error******
//the contorl date has sa minimum date and the default will be January 1 1753 
//we want to show the date portion only not the time portion and we use a custom format (in the prop window where the date is)
//and the customformat is then unlocked for our custom date and year******************************



//WE NOW WANT TO ADD RADIO BUTTONS TO OUR PERSON EDIT FORM
//always use the name of the control within the name when we name it specifically in the Name property in our designer to access in our code*************
//only one radio button can be selected at a time but if we want multiple to be selected at the same time we use the groupbox
//so it lets us organize things on the form (put them in their own container)********
//groupboxes allow us to put title on the boxes*****
//and they allow us to selected multiple radio buttons at a time*****
//thats only if they are contained in seperate group boxes if they are in the same groupbox we can only select one at a time within the groupbox**



namespace EditPerson
{
    public partial class PersonEditForm : Form
    {
        public Person formPerson;

        public PersonEditForm(Person person, Form parentForm )
        {
            /******************************************************************************************
             **************THIS MUST BE THE FIRST FUNCTION CALL IN YOUR FORM CONSTRUCTOR **************
             ******************************************************************************************/
            InitializeComponent();

            //foreach (Control control in this.Controls)
            foreach (Control control in this.detailsTabPage.Controls)
            {
                // use Tag property to indicate valid state
                control.Tag = false;
            }

            if( parentForm != null ) 
            {
                this.Owner = parentForm;
                this.CenterToParent();
            }

            this.formPerson = person;


            // all form configuration should be done first
            // before working with the form's data
            this.okButton.Enabled = false;

            this.nameTextBox.Validating += new CancelEventHandler(TxtBoxEmpty__Validating);
            this.emailTextBox.Validating += new CancelEventHandler(TxtBoxEmpty__Validating);
            this.ageTextBox.Validating += new CancelEventHandler(TxtBoxEmpty__Validating);
            this.specTextBox.Validating += new CancelEventHandler(TxtBoxEmpty__Validating);
            this.gpaTextBox.Validating += new CancelEventHandler(TxtBoxEmpty__Validating);
            this.licTextBox.Validating += new CancelEventHandler(TxtBoxEmpty__Validating);

            this.nameTextBox.TextChanged += new EventHandler(TxtBoxEmpty__TextChanged);
            this.emailTextBox.TextChanged += new EventHandler(TxtBoxEmpty__TextChanged);
            this.ageTextBox.TextChanged += new EventHandler(TxtBoxEmpty__TextChanged);
            this.specTextBox.TextChanged += new EventHandler(TxtBoxEmpty__TextChanged);
            this.gpaTextBox.TextChanged += new EventHandler(TxtBoxEmpty__TextChanged);
            this.licTextBox.TextChanged += new EventHandler(TxtBoxEmpty__TextChanged);

            this.ageTextBox.KeyPress += new KeyPressEventHandler(TxtBoxNum__KeyPress);
            this.licTextBox.KeyPress += new KeyPressEventHandler(TxtBoxNum__KeyPress);
            this.gpaTextBox.KeyPress += new KeyPressEventHandler(TxtBoxNum__KeyPress);

            this.typeComboBox.SelectedIndexChanged += new EventHandler(TypeComboBox__SelectedIndexChanged);

            this.cancelButton.Click += new EventHandler(CancelButton__Click);
            this.okButton.Click += new EventHandler(OkButton__Click);


            //add the checked changed for all 3 teacher buttons since their rating buttons have change so the text also needs to change******
            //we can use the same delegate for all of our buttons because they all do the same thing is they are checked or not (changed)**************
            this.greatRadioButton.CheckedChanged += new EventHandler(RatingRadioButton__CheckedChanged);//use eventhandler when its used generically and shared across controls******
            this.okRadioButton.CheckedChanged += new EventHandler(RatingRadioButton__CheckedChanged);
            this.mehRadioButton.CheckedChanged += new EventHandler(RatingRadioButton__CheckedChanged);
            //whenever an event has to change a label like here we have to have an event on when it was clicked (and we have to set text if it was clicked)
            //but for the food we did not because there was no label or anything we had to do when we clicked a button****

            //do we usually use EventHandler for shared methods like this or when do we usually use it beccause couldnt we have used a click event**

            //first set up all eventhandlers then manipukate controls******
            //we want them to be able to click the picture and have a open file disologue control so that they can add their own photo*****
            this.photoPictureBox.Click += new EventHandler(PhotoPictureBox__Click);

            //have an event handler assocaited with it now to have default blank date****
            //if the birthdate which is the default min date then we want to show it as blank rather than the Jnauary 1 1753
            //this.birthDateTimePicker.ValueChanged += new EventHandler();





            // after all contols are configured then we can manipulate the data

            this.nameTextBox.Text = person.name;
            this.emailTextBox.Text = person.email;
            this.ageTextBox.Text = person.age.ToString();
            this.licTextBox.Text = person.LicenseId.ToString();

            if( person.name == "")//if their name is empty then we know its a new person being added so we set their food to a default value******
                //this is when we first open the form of the person if no data was previously stored in??**
            {
                person.eFavoriteFood = EFavoriteFood.pizza; //by default it will say their favorite food is broccolli so we change that*****
            }


            //we want to start by setting the actual date of our control to be the minimum date
            //we want to show the date blank by default and we use the 1753 as the blank date when nothing is entered******
            this.birthDateTimePicker.Value = this.birthDateTimePicker.MinDate;


            //RADIO BUTTONS (set it as their favorite food)
            //we want to see what the enumrerated type is set to
            switch ( person.eFavoriteFood)
            {
                case EFavoriteFood.brocolli:
                    this.brocolliRadioButton.Checked = true;
                    break;

                case EFavoriteFood.pizza:
                    this.pizzaRadioButton.Checked = true;
                    break;

                case EFavoriteFood.apples:
                    this.applesRadioButton.Checked = true;
                    break;
            }

            //load the picturebox here now*****
            this.photoPictureBox.ImageLocation = person.photoPath;
            //string that contains path to their photo so we can load it onto the picturebox*****


            if ( person.GetType() == typeof(Student) )
            {
                this.typeComboBox.SelectedIndex = 0;

                Student student = (Student)person;
                this.gpaTextBox.Text = student.gpa.ToString();
            }
            else
            {
                this.typeComboBox.SelectedIndex = 1;

                Teacher teacher = (Teacher)person;
                this.specTextBox.Text = teacher.specialty;

                //set up teacher radio button*****
                if ( person.name == "")
                {
                    teacher.eRating = ERating.ok; //when we are first in the constructor it checks for stored data to pull up radio buttons that were submitted previously
                    //like favorite foods up top as well**
                }

                switch( teacher.eRating )
                {
                    case ERating.great:
                        this.greatRadioButton.Checked = true;
                        break;
                    case ERating.ok:
                        this.okRadioButton.Checked = true;
                        break;
                    case ERating.meh:
                        this.mehRadioButton.Checked = true; //when we check a radio button it unchecks all the others in the same container****
                        //only one favorite food and one erating can be checked so we put a group box so it wont do one or the other******
                        break;
                }
            }


            this.Show();
        }

        //the group box just gives us the label and the caption for the picturebox that why we have the picturebox clicked to go to our files then add the hpoto
        // with open dialooge****
        private void PhotoPictureBox__Click(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;

            //we want to pop up the open file dislouge 
            if ( this.openFileDialog.ShowDialog() == DialogResult.OK)//if the result fo showing openfilediglogue (they clciked ok) then we set the picturebox
                                                                    //image location equal to the filename that they chose to display the photo****
            {
                pb.ImageLocation = this.openFileDialog.FileName; //here we open the file??**
            }
        }

        private void RatingRadioButton__CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;

            if( rb.Checked) //checkchanged unchecks another radio button first if another one was selected initially*****
                            //it will call checked change twice to uncheck previous button and check the one we just clicked on when we check another radio button*****
            {
                if ( rb == this.greatRadioButton)
                {
                    this.ratingLabel.Text = "sign me up";
                }

                if( rb == this.okRadioButton)
                {
                    this.ratingLabel.Text = "ok";
                }

                if( rb == this.mehRadioButton)
                {
                    this.ratingLabel.Text = "run away!"; //each time a radio button is changed it updates the label for the teacher
                    //we need to default our radio button so it does not show label2 by default
                    //when we press great it calls the meh radio button to unchecked then calls it again to hve the great button checked

                    //by default we can multiseclted checkboxes not radiobuttons though its only one at a time so thats why we made a groupbox*****
                }
            }
        }

        private void OkButton__Click(object sender, EventArgs e)
        {
            Student student = null;
            Teacher teacher = null;
            Person person = null;

            Globals.people.Remove(this.formPerson.email);

            if( this.typeComboBox.SelectedIndex == 0)
            {
                student = new Student();
                person = student;
            }
            else
            {
                teacher = new Teacher();
                person = teacher;
            }

            person.name = this.nameTextBox.Text;
            person.email = this.emailTextBox.Text;
            person.age = Convert.ToInt32(this.ageTextBox.Text);
            person.LicenseId = Convert.ToInt32(this.licTextBox.Text);


            //when we click ok we want to store their food data and teacher data if they were a teacher based on the radio buttons******
            //store their data based on whatever they clicked******
            if ( this.brocolliRadioButton.Checked)
            {
                person.eFavoriteFood = EFavoriteFood.brocolli;
            }
            else if( this.pizzaRadioButton.Checked)
            {
                person.eFavoriteFood = EFavoriteFood.pizza;
            }
            else if( this.applesRadioButton.Checked)
            {
                person.eFavoriteFood= EFavoriteFood.apples;
            }

            person.photoPath = this.photoPictureBox.ImageLocation;
            //this implements our pgoto picturebox****************** 

            if ( person.GetType() == typeof(Student))
            {
                student.gpa = Convert.ToDouble(this.gpaTextBox.Text);
            }
            else
            {
                teacher.specialty = this.specTextBox.Text;

                //we need to explicitly check each radio button when they click ok*******
                if ( this.greatRadioButton.Checked) //now we make it so as the person is editing the form we will change the radio buttons and which
                    //forms will check or not check and this will not show up if its a student object so it would go to the sorted index and see to display the groupbox
                    //if it was a teacher and basically over here this handles when the person is editing the form
                    //and changes the text as well when we go thruogh the buttons because of our checkchanged method above whenever
                    //we click another button and when they press ok that data will be stored based on which radio button they clciked**
                {
                    teacher.eRating = ERating.great;
                }
                else if( this.okRadioButton.Checked)
                {
                    teacher.eRating = ERating.ok;
                }
                else if( this.mehRadioButton.Checked)
                {
                    teacher.eRating = ERating.meh;
                }
            }

            Globals.people[person.email] = person;

            if( this.Owner != null)
            {
                this.Owner.Enabled = true;
                this.Owner.Focus();

                IListView listView = (IListView)this.Owner;
                listView.PaintListView(person.email); //this is where we pass the email and now it knows the person so it can get their email 
                //index from the condtional before the loop and when it gets to the condtional within the loop it checks if the current index we are on is that
                //person based on their email index we want to store that person as the first index then when we add all of our people we want to make that person
                //the top person on our list based on the variable we had used to store the email**
            }

            this.Close();
            this.Dispose();
        }

        private void CancelButton__Click(object sender, EventArgs e)
        {
            if( this.Owner != null )
            {
                this.Owner.Enabled = true;
                this.Owner.Focus();
            }

            this.Close();
            this.Dispose();
        }


        private void TypeComboBox__SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;

            if( cb.SelectedIndex == 0 )
            {
                this.specialtyLabel.Visible = false;
                this.specTextBox.Visible = false;

                this.specTextBox.Tag = true;

                this.gpaLabel.Visible = true;
                this.gpaTextBox.Visible = true;

                this.gpaTextBox.Tag = (this.gpaTextBox.Text.Length > 0);

                this.ratingGroupBox.Visible = false;
            }
            else
            {
                this.specialtyLabel.Visible = true;
                this.specTextBox.Visible = true;

                this.gpaTextBox.Tag = true;

                this.gpaLabel.Visible = false;
                this.gpaTextBox.Visible = false;

                this.specTextBox.Tag = (this.specTextBox.Text.Length > 0);

                this.ratingGroupBox.Visible = true;//shows the groupbox if its a teacher for the rating
                                                   //if a container is visible or not it effects everything in that box and makes it visble or not******


                //if we show the rating groupbox we need to check and see if none of the are checked and we set a default
                //and it will automatically put the label on it because it starts off as being checked by default*******
                //why do we have another default here we took care of that up top if the name was nothing that meant it was a new form so we had a default value**
                //how do we know when to add ciontaionls for buttons like these when we make the radiobuttons why didnt we do one for food**
                if ( !this.greatRadioButton.Checked && !this.okRadioButton.Checked && !this.mehRadioButton.Checked)
                {
                    this.okRadioButton.Checked = true;
                }
            }

            ValidateAll();
        }

        private void TxtBoxEmpty__TextChanged(object sender, EventArgs e)
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

        private void TxtBoxNum__KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = (TextBox)sender;

            if( Char.IsDigit(e.KeyChar) || e.KeyChar == '\b')
            {
                e.Handled = false;
                tb.Tag = true;
            }
            else
            {
                e.Handled = true;

                if( tb == this.gpaTextBox)
                {
                    if( e.KeyChar == '.' && !tb.Text.Contains("."))
                    {
                        e.Handled = false;
                        tb.Tag = true;
                    }
                }
            }

            ValidateAll();
        }


        public void TxtBoxEmpty__Validating(object sender, CancelEventArgs e)
        {
            TextBox tb = (TextBox)sender;

            if(tb.Text.Length == 0)
            {
                this.errorProvider1.SetError(tb, "This field cannot be empty.");
                e.Cancel = true;
                tb.Tag = false;
            }
            else
            {
                this.errorProvider1.SetError(tb, null);
                e.Cancel = false;
                tb.Tag = true;
            }

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


        public void typeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
