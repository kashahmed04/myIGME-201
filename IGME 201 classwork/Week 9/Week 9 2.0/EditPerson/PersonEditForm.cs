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

//TOMORROW GO OVER THE LISTVIEW INTERFACE****************************(16.0)

//how can we change the email address in personedit form if we have to access by the key (deleted the person so now we cant access by email)
//aso basically we deleted the person and created a new person with a new email then stored that email in the people list by the email being the key
//then repainted the listview??**************(17.0)

//our form is the this keyword and the controls is used for all of the controls on the form and its built in for all of our controls (this.Controls??)**
//this is in the form1.designer.cs and its hidden from us and we dont modify at all because its automatically built in****
//so basically if we use this. within the current form it will do stuff to that form only not the parent form that will******
//actually run when we run the applciation***********(18.0)

//we want to do specific code when the user changes a value and we use events associated with that contorl and in properties theres an evenet icon and for the combobox
//control we have 100 possible events that could be triggered and we can add methods in here to be called in here when events are triggered but
//the mapping is hid in the lightning
//panel(dont use lightning panel)(prop.panel)**



//we noe need to load the data from the person that was passed in and load it onot to the form and save it back to the person object
//that was being edited when the person presses ok when they are finished editing a person**(save whatever the user edits then add it back to the list
//on the top of the list with paintlistview function)**

namespace EditPerson
{
    //START HERE*******
    public partial class PersonEditForm : Form //use partial in windows forms**

        //here we pass in the person and the parent form so we can edit a person that was double clicked or pressed enter on**
        //for windows forms do we usually put inheritence of Form after ":" for the class that has the designer attached to it**************(19.0)

    {
        public Person formPerson; //make a person ref. variable because we pass a person variable in the constructor that exists inside the constructor
        //only and since now we have a class scaoped varible now we have access to that person everywhere in our class and we want to make person
        //useabe outside of it because then we could access their old data from the Globals file and to create a new object to save the data form the form
        //(the most edited one)
        //so basically when a variable is class scoped that means that it can be accessed anywhere in the current file class but can also be accessed in other
        //files that have the same reference as the current file whereas if it was only in the constructor it would only be avaiblable in that
        //constructor even if it a public variable in the constructor??********(20.0) 
        public PersonEditForm(Person person, Form parentForm )
        {


            /******************************************************************************************
             **************THIS MUST BE THE FIRST FUNCTION CALL IN YOUR FORM CONSTRUCTOR **************
             ******************************************************************************************/
            InitializeComponent();

            //why do we have loop for controls here but not in the peoplelistform how do we know to have a loop for the controls**********************(15)
            foreach (Control control in this.detailsTabPage.Controls) //these controls not longer exist directly in the form this.Controls
                                                                      //and now in the details tab page that we created in the designer
                //we need to modify the foreach loop to look at the details view tab controls rather than the main
                //form because thres container within the main form now but it still counts as being in the main form but now it's just in a container (the controls
                //got moved to the continer in the desginer so we need to adjust for that)
            {
                // use Tag property to indicate valid state
                //if the tag is used to store any type of data how does it know that the form starts off as invalid (we did not put it in the validateall method)**
                control.Tag = false; //it knows to not allow user to press the ok button because of the validate all 
                //we change the controls as we move on so that we can press the ok button eventually
                //cant have loops in windows forms because everything is event driven and we needed a loop here because 

                //all controls are waiting for something to be done to it and everything is running at the same time and its being listened to and reacting to it
                //we cant have loops for how the form can work like the interactive 
                //we can have loops to access data though and set tags basically things that dont involve the interactivity 

                //this.nameTexBox = false; (do same for rest of controls) and do the same for each control manually 
            }

            //check to see before working with variables that get passed in if they are valid or not(personlistform)
            //what does null refer to in this case what is this doing is this saying if the current form is not empty then we want to set the ownre
            //and center the current form??*******(20)
            if(parentForm != null)
            {
                //a form has a property called owner and its used to save the owning form (the form that called the current form)** (we can do owner in multiple forms right
                //but only forms??******(21)
                //(the parent form?? in this case peoplelistform))*******(22)
                //and this way the varuable will be availabel throughough the class in terms of the parentform being used in this class only** (if we use this.
                //does it  matter matter about the scope it will be available through the whole file (class scoped) not whole application outside of file though
                //even though we defined the owner within a code block could we do this for owner in general??)*************(23)
                //(could we have used parentForm instead of this.Owner)**
                //person and parent form are only defined in this code block not anywhere else and if we need to access it somewhere else other than constructor
                //then we need to
                //use class scoped variables like we did for person and here we are making one for the parent form since it's this.owner??*********(24)
                this.Owner = parentForm; //refers to the personlistform that gets passed in**

                //we now center the current form to the parent form and what it does is that it centers the parent form to the owner form thats unerlaying it at the moment
                //makes it appear nice (lets this form show on top of the people list centered according to how big the list form window is**
                this.CenterToParent();




            }

            this.formPerson = person; //what does this do** (we created the reference to the person up above and it was class scoped)(why was it class scoped)**
            //we are now setting our person reference to the person that was passed in)**
            //we use this. because its class scoped and anything thats class scoped*************(21.0)
            //uses this. within the constructors even the controls (the contorls reference the designer code)??***********(22.0)

            //disable the ok button when we first come in 
            this.okButton.Enabled = false;

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
            //like cancel or keypress event handlers could we have used eventhandler for those too??****************(23.0)
            //when multiple controls access the same event and method we can name the method by whatever name related to content__control******(24.0)
            //multiple methods can run at the same time for an event right**************(25.0)

            this.ageTextBox.KeyPress += new KeyPressEventHandler(TxtBoxNum__KeyPress);
            this.licTextBox.KeyPress += new KeyPressEventHandler(TxtBoxNum__KeyPress);
            this.gpaTextBox.KeyPress += new KeyPressEventHandler(TxtBoxNum__KeyPress);

            this.typeComboBox.SelectedIndexChanged += new EventHandler(TypeComboBox__SelectedIndexChanged);

            this.cancelButton.Click += new EventHandler(CancelButton__Click);
            this.okButton.Click += new EventHandler(OkButton__Click); //we need to update database with the person once they edit the form and press ok**
            //all poperties are camelcase not pascale case like the okbutton here (only form is pascal case)


            //we want to set all of the event handlers above (form configurations) should be done first in our constructor before working
            //with the forms data like we did below with our methods**
            //once we configured the controls anytime we change the data it will trigger the event of the controls**
            //after all contorls are configured then we can manipulate the data like we did down below in our methods and it also calls event triggers like it would with
            //user interaction if we manipulated something in our code to cause an event**


            //we initialize the fields that are passed in that are common to both sutdent and tacher now**
            this.nameTextBox.Text = person.name; //when we set these variables these go to the delegate because the text is being changed as well
            //as each field 
            this.emailTextBox.Text = person.email;
            this.ageTextBox.Text = person.age.ToString(); //we need to cast the age to a string so for that person we pass in their data gets stored as a string**
            this.licTextBox.Text = person.LicenseId.ToString(); //saves the data in these variables for the teacher and student person we pass in (which ever one it was)**



            //we need to know what type of person was passed in so we know what fields will show like gpa or specifalty for the teacher**
            //the person object that was passed in at the top was rather a student or a teacher and we can implicitly pass variables with the parent type (high to low)**
            if(person.GetType() == typeof(Student)) //if its a student (look at prop. of combobox and look at the items then collection) we see that its the 0th index
                //so we want to make the selected index that index in the collection because the 0th index is a student**
                //this will add onto our current properties we have set above like name and age,etc. because its still a type of person for the student or teacher**
            {
                this.typeComboBox.SelectedIndex = 0; //when this is executed it will call out selectedindexchanged method we have down below here**
                //and when we progamatically write code that maniupulates data is also calls the trigger for the event its not just the user who does the event**

                //once we manipulate data it triggeres the selectedindexchanged event because we changed the index and even if it didnt change if we explicitly set it
                //to something it will call the event because we set something like if we set it to 0 again the selectedindex method would be called still*********(26.0)
                //now in our selectedindexchanged it says we have our index equal to 0 in the first conditional and now displays the gpa fields and checks
                //if there is any data in the texbox and calls validate all to see if ok button can be clicked in the selected index method**

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

            //we can also change email address and it will also change in this method for the ok button the ok button handles all the changes applied
            //to the peroson passed in we want to edit**

            //tab page is a container we can put any contorl now (ex webbrowser contorl on homrpge tab and 2 list view controls on our courses and our
            //web browser control for our schedule are containers within the main form because they are tabs and each tab is a container)**

            Student student = null; //we set a student pointer and teacher and person pointer to nul(why)**
            Teacher teacher = null;
            Person person = null;

            //when we click ok we have some ref. variables above**
            //we want to remove the person they edited from the database and theres only one entry per 
            //data base (one email per person if we do same email we will get an error)**
            Globals.people.Remove(this.formPerson.email); //form object is the person we initially passed in from peoplelistform
                                                          //(we stored it after the conditional in the constructor)**
                                                          //the remove is built in and removes it from the lsit itself right**
                                                          //deelte by the key which is the email then deletes by key and value**

            //so above we insiitalized values to go into the form when we first opened the form (in the constructor)
            //when we first want to edit it but then over here we delete the person
            //but the data is still shown on the form right for their previous data********************************(27.0)

            //remove from the email so it removes the person then create a new person then readd everything back and create the person again and repaint the list
            //view in our personlistform*******************(28.0)

            //we lose email here so how would we know what person it is**

            //we want to check what the combobox of person is set to when we inisiallty pass the person object in in the above condtional but here**
            //we can check the type of person we are editing as we are editing and it handles the changed we make now here
            //how does it know to keep adjusting if we only have a condtional here and not a loop like if we changed from techer to student then keep changing**
            //within the same form without pressing ok**
            if(this.typeComboBox.SelectedIndex == 0) //the conditonal in the constructor is for when we first put it into the constrcutor while here its when we edit
            {
                student = new Student();
                person = student; //now here we want to see if they set our object we passed in to a teacher of a student (they changed it)**
                //if the person passed in is a student then the code in the constructor will be a student so it will cause our combobox to say student when we first pass it in**
            }
            else
            {
                teacher = new Teacher();
                person = teacher; //we know its a teacher and now we know person here
                //when we press ok we check what is the type of person that was defined by the combobox and the best thing to do is that before we try to update it
                //delete the original entry like we did above because we dont know whether the person is still a teacher or a student and their other fields would probably
                //end up being changed
                //then we check to see accoding to the form is this a student or teacher and we know that from the combobox and now we can create the approptirate type
                //and now read in data from the form into our new object and set the new fields to what we need to set it to (creating new object based on our edits)**
                //the original person in the constructor is not releveant anymore expcept for the email because it was the intiail key and we can use the email to remove
                //them then we need to recreate the object of the right type and fill in theit details**
            }

            //we deleted the whole person now we set the email and the rest of the prop. to the new person because when we deleted it above then did the condtional**
            //it only told us what type of the person it was and ntohing else is saved so we save the rest of the fields below**

            person.name = this.nameTextBox.Text;
            person.email = this.emailTextBox.Text; 
            person.age = Convert.ToInt32(this.ageTextBox.Text); //we should check user input with a while loop usually but we made sure that with our method which
            //makes sure a number is only entered** (why do we convert to int. here but string everywhere else is it because we are storing now instead of putting onto**
            //the form so thats why we can have numbers here otherwise if its being displayed on the form make it a string)**
            person.LicenseId = Convert.ToInt32(this.licTextBox.Text); //we can convert them to integer because we know they are valid because we 
                                                                      //already have the data condtions that they will only contain integer data because the fields in our person object is integers
                                                                      //not strings so we can store the person and the data in our textboxes is string so when we put it on the form its a string
                                                                      //any time we put stuff on the form it has to be a string

           
            if (person.GetType() == typeof(Student))
            {
                student.gpa = Convert.ToDouble(this.gpaTextBox.Text); //save the data based on the object and it knows its a person so it will store along with the shared fields
                                                                      //we defined up above based on if its a teacher or student and we convert the gpa to a double because**
                                                                      //its being stored not put on the form and if it was being**
                                                                      //put on the form we would have to make it a string**
            }
            else
            {
                teacher.specialty = this.specTextBox.Text;

            }

            Globals.people[person.email] = person; //we now use our new stored email to store our new person object based on the student or teacher type we just edited
                                             

            if(this.Owner != null)
            {
                this.Owner.Enabled = true; //enable the parent form which was peoplelistform we set above in the condtional (unlock it)**
                this.Owner.Focus(); //if we dont focus then windows could switch to another application so we have to focus on the specific form
                //instead of going to another tab we have open


                //now we want to call the paintlistview method and pass in the email address of the person we just edited so it adds it to the top of the form**

                IListView listView = (IListView)this.Owner; //our owner inherits from the interface**
                listView.PaintListView(person.email); //we pass in the current email we have to repaint the list so we can add the person at the top of the list
                //we have edited**
                //if paintlistview is already in the parent form could we have just said this.Owner(or parentForm).paintlistview(person.email)**

                //we do person.email and not person[email] because the first one gets the email and the second one gets the person based on our email****************(29.0)
            }

            this.Close();
            this.Dispose();
            //cleaning up memory and when we pass in a person we set the prop. in the constructor then it fills in the file again for us to edit

            
              
        }


        private void CancelButton__Click(object sender, EventArgs e) //for owner is it usually our main form that we had in applciation.run() usually and it owns
                                                                     //all of the forms that get used within the main form or do we usually have to set it to a specfic form**
        {
            //before we leave the form we need to reenable the parent form (when we left personlist
            //we disabled (this.enabled = false in the add button click method)** the form so we had not multiple forms active at the same time)**
            //we should see if there is an owner for the form**
            if(this.Owner != null)
            {
                this.Owner.Enabled = true; //peoplelistform will be enabled again** (what does this do)**

                this.Owner.Focus(); //foccuses application on that form because it does not put the peoplelistform back in scope if we press cancel to edit a person**
                //focus method transitions to the form we specify in this case the this.owner is the parent form which is peoplelist form and we are going to
                //focus on that form now**
                //when and what is focus and when to use it**
                //we did the same for once they clikcked ok above and enabled the form again and focussed on the form then closed and disposed it like we did here**
            }
            this.Close(); //close the current person we are editing and dispose the data within the form
            this.Dispose();

            //we want to close the current form not current application and we could put application.exit() anywhere but it would exit the parent and it creates a brand
            //new form
        }


        private void TypeComboBox__SelectedIndexChanged(object sender, EventArgs e)
        {
            //if its a student we want to hide the rating radio buttons and those radio buttons are in the rating group box so we can just hide the whole groupbox****
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

            if( Char.IsDigit(e.KeyChar) || e.KeyChar == '\b') //if we only let them type in a number and they want to fix it we also want them
                //to type in the backspace character so that they can delete the number if we types something wrong
            {
                e.Handled = false;
                tb.Tag = true;
            } //for license id, age and gpa does it run two methods at once one for the number and one to see if anything is entered because it points
            //to 2 different methods if we wanted to edit or fill in an empty form**(points to multilpe methods)**
            else
            {
                e.Handled = true; //why do we have to do 2 handled statements here and what is the windows basically doing when we let them handle it**

                if( tb == this.gpaTextBox)
                {
                    if( e.KeyChar == '.' && !tb.Text.Contains("."))
                    {
                        e.Handled = false; //when we enter and they press deciaml point and we are in gpa and now we handle the gpa textbox 
                                            //and we check we have a decimal point and now windows can show the decimal point
                                            //and now handled is false and now it gets to the end and now windows displays it false
                                            //and it waits for the method to complete for supressed and handled 
                                            //for our suppressed it was true so it does not show anywhere
                                            //false then it will display but if true then it wont and it only checks at the end if it was false to display or not
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
                                    //us in that textbox** (do we usually use it with the event para. (e)**) (the cancel event handles it)
                                    //and if cancel is true then we want to cancel whatever windows would have done and we want to stay on the current field otherwise
                                    //we can move to the next field)**
                tb.Tag = false;     //how does this know to not let us leave if something is not filled in because this only stores data**
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
                (bool)this.nameTextBox.Tag && //basically based on the textbox(tb) variable we used in our methods if it's all true we can press ok otherwise we can't
                                              //and it checks for the specific textboxes we have passed in via the object sender and the event that we had done on it
                                              //to make sure its empty or not and setting the tag so we can reference the tag here to see if its full or not so we can press ok**
                (bool)this.emailTextBox.Tag &&
                (bool)this.ageTextBox.Tag && //the tag will change depending on the things we pass into the methods but when it comes into validate all
                //it checks each tag even the one we edited to see if we can go on to press ok
                (bool)this.specTextBox.Tag &&
                (bool)this.gpaTextBox.Tag;
        }


        public void typeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
