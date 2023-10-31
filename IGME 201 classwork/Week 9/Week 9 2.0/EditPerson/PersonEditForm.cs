using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using PeopleLib;
using PeopleAppGlobals;

//our form is the this keyword and the controls is used for all of the controls on the form and its built in for all of our controls (this.Controls??)**
//this is in the form1.designer.cs and its hidden from us and we dont modify at all because its automatically built in****

//we want to do specific code when the user changes a value and we use events associated with that contorl and in properties theres an evenet icon and for the combobox
//control we have 100 possible events that could be triggered and we can add methods in here to be called in here when events are triggered but
//the mapping is hid in the lightning
//panel(dont use lightning panel)(prop.panel)**



//we noe need to load the data from the person that was passed in and load it onot to the form and save it back to the person object
//that was being edited**(save whatever the user edits)**

namespace EditPerson
{
    public partial class PersonEditForm : Form //so basically we use partial inonly the things that will show in the form right not peopleappglobals since its only a list
                                                //and the list is accessed from these classes so theres no need to use partial**(is it ok if we use partial in all of the things
                                                //involved in one application though or does it mess with the applicatino)**

        //here we pass in the person and the parent form**

        //public Person formPerson; //make a person object thats class scoped becase**(******
    {
        public Person formPerson;
        public PersonEditForm(Person person, Form parentForm )
        {


            /******************************************************************************************
             **************THIS MUST BE THE FIRST FUNCTION CALL IN YOUR FORM CONSTRUCTOR **************
             ******************************************************************************************/
            InitializeComponent();

            foreach (Control control in this.detailsTabPage.Controls) //these controls not longer exist directly in the form they are not in the details tab page that we created
                //so we need to modify the foreach loop to look at the details view tab controls rather than the main
                //form because thres not main form anymore they are contrainers**
            {
                // use Tag property to indicate valid state
                //if the tag is used to store any type of data how does it know that the form starts off as invalid**
                control.Tag = false;
            }

            //check to see before working with variables that get passed in if they are valid or not**
            if(parentForm != null)
            {
                //a form has a [rp[erty called owner and its used to save the owning form (the form that called the current form)
                //and this way the varuable will be availabel throughough the class**
                //person and parent form are only in this code block not anywhere else and if we need to access it somewhere else then we need to**
                this.Owner = parentForm;

                //we now center the current form to the parent form and what it does is that it centers the parent form to the owner form thats unerlaying it at the moment
                //makes it appear nice**
                this.CenterToParent();




            }

            this.formPerson = person; //what does this do**

            //this should be false right because then the user could press ok even though the form is blank**
            //this does not need a delegate method because we have a vlidateall which sets the ok button
            //enabled based on if everything is filled in or not can we also do a delegate method here or how do we know when not to**
            this.okButton.Enabled = true;

            this.nameTextBox.Validating += new CancelEventHandler(TxtBoxEmpty__Validating);
            this.emailTextBox.Validating += new CancelEventHandler(TxtBoxEmpty__Validating);
            this.ageTextBox.Validating += new CancelEventHandler(TxtBoxEmpty__Validating);
            this.specTextBox.Validating += new CancelEventHandler(TxtBoxEmpty__Validating);
            this.gpaTextBox.Validating += new CancelEventHandler(TxtBoxEmpty__Validating);
            this.licTextBox.Validating += new CancelEventHandler(TxtBoxEmpty__Validating);
            //generic methods that are used for many controls but for 1 specific control we use that specific contorl name__the event**

            this.nameTextBox.TextChanged += new EventHandler(TxtBoxEmpty__TextChanged);
            this.emailTextBox.TextChanged += new EventHandler(TxtBoxEmpty__TextChanged);
            this.ageTextBox.TextChanged += new EventHandler(TxtBoxEmpty__TextChanged);
            this.specTextBox.TextChanged += new EventHandler(TxtBoxEmpty__TextChanged);
            this.gpaTextBox.TextChanged += new EventHandler(TxtBoxEmpty__TextChanged);
            this.licTextBox.TextChanged += new EventHandler(TxtBoxEmpty__TextChanged);
            //I know that eventhandler is generic but how do we know when to use it .vs.using a more speciifc eventhandler
            //like cancel or keypress event handlers could we have used eventhandler for those too??**

            this.ageTextBox.KeyPress += new KeyPressEventHandler(TxtBoxNum__KeyPress);
            this.licTextBox.KeyPress += new KeyPressEventHandler(TxtBoxNum__KeyPress);
            this.gpaTextBox.KeyPress += new KeyPressEventHandler(TxtBoxNum__KeyPress);

            this.typeComboBox.SelectedIndexChanged += new EventHandler(TypeComboBox__SelectedIndexChanged);

            this.cancelButton.Click += new EventHandler(CancelButton__Click);
            this.okButton.Click += new EventHandler(OkButton__Click); //we need to update database wuth the person once they edit the form and press ok**
            //all fields are camelcase not pascale case like the okbutton here


            //we want to set all of the event handlers above (form configurations) should be done first in our constructor before working
            //with the forms data like we did below with our methods**
            //once we configured the controls anytime we change the data it will trigger the event of the controls**
            //after all contorls are configured then we can manipulate the data like we did down below in our methods**


            //we do the fields that are common to both sutdent and tacher now**
            this.nameTextBox.Text = person.name;
            this.emailTextBox.Text = person.email;
            this.ageTextBox.Text = person.age.ToString(); //we need to cast the age to a string so for that person we pass in their data gets stored as a string**
            this.licTextBox.Text = person.LicenseId.ToString(); //saves the data in these variables for the teacher and student person we pass in (which ever one it was)*8


            //we need to know what type of person was passed in so we know what fields will show like gpa or specifalty for the teacher**
            //the person object that was passed in at the top was rather a student or a teacher and we can implicitly pass variables with the parent type (high to low)**
            if(person.GetType() == typeof(Student)) //if its a student (look at prop. of combobox and look at the items then collection) we see that its the 0th index
                //so we want to make the selected index that index in the collection
            {
                this.typeComboBox.SelectedIndex = 0; //when this is executed it will call out selectedindexchanged method we have down below here**
                //and when we progamatically write code that maniupulates data is also calls the trigger for the event its not just the user who does the event**
                //once we manipulate data it triggeres the selectedindexchanged event because we changed the index and even if it didnt change if we explicitly set it
                //to something it will call the event because we set something**
                //now in our selectedindexchanged it says we have our index equal to 0 in the first conditional and now displays the gps fields and checks
                //if there is any data in the texbox and calls validate all to see if ok button can be clicked**

                //useful because we dont have to write extra code to go back to call the rules again because the event
                //handling was set up first and we maniupluated code that
                //triggerede the event that does that work for us**

                //get student specific fields now**
                Student student = (Student)person;
                this.gpaTextBox.Text = student.gpa.ToString();
            }
            else
            {
                //set the teacher specific fields**
                this.typeComboBox.SelectedIndex = 1;

                Teacher teacher = (Teacher)person;
                this.specTextBox.Text = teacher.specialty; //this sets all of our fields to whatever person was passed in**
            }

          

            this.Show();

        }


        private void OkButton__Click(object sender, EventArgs e)
        {

            //we can also change email address and it will also change in this method for the ok button the ok button handles all the changes applied**

            //tab page is a container we can put any contorl now (ex webbrowser contorl on homrpge tab and 2 list view controls on our courses and our
            //web browser control for our schedule)**

            Student student = null; //we set a student pointer and teacher and person pointer to nul(why)**
            Teacher teacher = null;
            Person person = null;

            //when we click ok we have some ref. variables above**
            //we want to remove the person they edited from the database and theres only one entry per 
            //data base (one email per person if we do same email we will get an error)**
            Globals.people.Remove(this.formPerson.email); //form object is the person we initially passed in from peoplelistform**

            //remove object from databasse first then re added it from the type that was reflected from the form(the things we have edited)**

            //we want to check what the combobox of person is set to when we inisiallty pass the person object in**
            //we can check the type of person we are editing
            if(this.typeComboBox.SelectedIndex == 0)
            {
                student = new Student();
                person = student; //now here we want to see if they set our object we passed in to a teacher of a student (they changed it)**
                //if the person passed in is a student then the code in the constructor will be a student so it will cause our combobox to say student when we first pass it in**
            }
            else
            {
                teacher = new Teacher();
                person = teacher; //we know its a teacher and now we know person is a teacher we are editing when we click ok
                //when we press ok we check what is the type of person that was defined by the combobox and the best thing to do is that before we try to update it
                //delete the original entry like we did above because we dont know whether the person is still a teacher or a student and their other fields would probably
                //end up being changed
                //then we check to see accoding to the form is this a student or teacher and we know that from the combobox and now we can create the approptirate type
                //and now read in data from the form into our new object and set the new fields to what we set it to
                //the original person in the constructor is not releveant anymore expcept for the email because it was the intiail key and we can use the email to remove
                //them then we need to recreate the object of the right type and fill in theit details**
            }

            person.name = this.nameTextBox.Text;
            person.email = this.emailTextBox.Text; 
            person.age = Convert.ToInt32(this.ageTextBox.Text); //we should check user input with a while loop usually but we made sure that with our method which
            //makes sure a number is only entered**
            person.LicenseId = Convert.ToInt32(this.licTextBox.Text);

            if(person.GetType() == typeof(Student))
            {
                student.gpa = Convert.ToDouble(this.gpaTextBox.Text); //save the data based on the object and it knows its a person so it will store along with the shared fields**
            }
            else
            {
                teacher.specialty = this.specTextBox.Text;
            }

            Globals.people[person.email] = person; //we now use our original email to store our new person object based on the student or teacher type we just edited**

            if(this.Owner != null)
            {
                this.Owner.Enabled = true;
                this.Owner.Focus(); //what do these do**

                IListView listView = (IListView)this.Owner; //our owner inherits from the interface**
                listView.PaintListView(person.email); //we pass in the current email we have to repaint the list so we can add the person at the top of the list
                //we have edited**
            }

            this.Close();
            this.Dispose();

            //now we want to call the paintlistview method and pass in the email address of the person we just edited so it adds it to the top of the form**
            //
              
        }


        private void CancelButton__Click(object sender, EventArgs e)
        {
            //before we leave the form we need to reenable the parent form (when we left personlist
            //we disabled the form so we had not multiple forms active at the same time)**
            //we should see if there is an owner for the form**
            if(this.Owner != null)
            {
                this.Owner.Enabled = true; //peoplelistform will be enabled again** (what does this do)**

                this.Owner.Focus(); //foccuses application on that form because it does not put the peoplelistform back in scope if we press cancel to edit a person**
                //focus method transitions to the form we specify (we did not specify a form though)**
                //when and what is focus and when to use it**
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

                this.specTextBox.Tag = true; //I thought tag just stored data how does it know to fill in the context of the hidden box so we can press ok**

                this.gpaLabel.Visible = true;
                this.gpaTextBox.Visible = true;

                this.gpaTextBox.Tag = (this.gpaTextBox.Text.Length > 0); //why did we set it valid here if a teacher specifalty was sotred
                //and we changed it to a student so that the speciality could still be stored when it was GPA??**
                //why did we not just set it equal to false so that they input a GPA rather than having a teacher speciality stored in it so that we can
                //press ok when the GPA was entered instead of storing teacher specialty**
            }
            else
            {
                this.specialtyLabel.Visible = true;
                this.specTextBox.Visible = true;

                this.gpaTextBox.Tag = true;

                this.gpaLabel.Visible = false;
                this.gpaTextBox.Visible = false;

                this.specTextBox.Tag = (this.specTextBox.Text.Length > 0);
            }

            ValidateAll(); //why do we have to call validate here as well because it's not a bool. value so how does it check it in terms of the statements
            //at the very end with the comparions (it basically checks if they length is greater than 0 (true) which will usually be the case since when we convert
            //between people the old data will be stored so why do we need it**)
        }

        private void TxtBoxEmpty__TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if( tb.Text.Length == 0)
            {
                this.errorProvider1.SetError(tb, "This field cannot be empty");
                tb.Tag = false;//why do we do this here if we already have the error set up**
                //are tags usuually going to be bool. values** (are all these tags related to validate all how does it know which texbox to reference is it because**
                //sender gets casted and whatever the textbox as sent in it knows which texbox to fill in)**
            }
            else
            {
                this.errorProvider1.SetError(tb, null);
                tb.Tag = true;
            }

            ValidateAll();
        }

        private void TxtBoxNum__KeyPress(object sender, KeyPressEventArgs e) //make methods public if need to be seen in other classes**
        {
            TextBox tb = (TextBox)sender;
            //whatever textbox was sent in because we only used it with the age, license ID, and GPA, it uses those textbox then does the below**

            if( Char.IsDigit(e.KeyChar) || e.KeyChar == '\b') //why do we check for the backspace character** case because it means still means no number is there right**
                                                              //do we have to do single
                                                              //quotes for tabs and stuff like this**
            {
                e.Handled = false;
                tb.Tag = true;
            }
            else
            {
                e.Handled = true; //why do we have to do 2 handled statements here and what is the windows basically doing when we let them handle it**

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


        public void TxtBoxEmpty__Validating(object sender, CancelEventArgs e) //why do we have to have 2 methods for changed and if its empty
                                                                               //can't we just reuse the one for textbox text changed??**
        {
            TextBox tb = (TextBox)sender;

            if(tb.Text.Length == 0)
            {
                this.errorProvider1.SetError(tb, "This field cannot be empty.");
                e.Cancel = true;    //so basically textboxes have a cancel property (field??) that allows the current box to be in focus if something is not passed in
                                    //and by default its false so the causesvalidation will not run and user won't have to fill out everything but if its true
                                    //like this then it does causesvalidation and makes sure something is put in the texbox so we can move on otherwise it locks
                                    //us in that textbox** (do we usually use it with the event para. (e)**)
                tb.Tag = false; //how does this know to not let us leave if something is not filled in because this only stores data**
            }
            else
            {
                this.errorProvider1.SetError(tb, null);
                e.Cancel = false; //this allows us to move on because something is in the textbox and causesvcliadtion will not be called (only when its true like above)**
                tb.Tag = true;
            }

            ValidateAll();
        }

        private void ValidateAll()
        {
            this.okButton.Enabled =
                (bool)this.nameTextBox.Tag && //basically based on the textbox(tb) variable we used in our methods if it's all true we can press ok otherwise we can't**
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
