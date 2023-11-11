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
using CourseLib;
//go over how to do loading screen on the bottom of the screen for a prompt and a timer to enter something (for exam)*****************
//go over how to set an image automatically and not have the user set it*******
//in terms of timer how do we know how long it is for presidents application could we guess**


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



//WE NOW WANT TO ADD RADIO BUTTONS TO OUR PERSON EDIT FORM
//always use the name of the control within the name when we name it specifically in the Name property in our designer to access in our code*************
//only one radio button can be selected at a time but if we want multiple to be selected at the same time we use the groupbox
//so it lets us organize things on the form (put them in their own container)********
//groupboxes allow us to put title on the boxes*****
//and they allow us to selected multiple radio buttons at a time*****
//thats only if they are contained in seperate group boxes if they are in the same groupbox we can only select one at a time within that groupbox**

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
            //this will cause a runtime error if we put anything on top of this because this initializes (loads in) all of our controls in the designer then we
            //can do stuff with those controls below**
            InitializeComponent();

            //foreach (Control control in this.Controls)
            foreach (Control control in this.detailsTabPage.Controls)
                //why did we have to go through all of the controls here but not people list is it beccaise we wanted to 
                //
            {
                // use Tag property to indicate valid state
                //*****************************************************************************************************************************GO OVER
                //so cant we just say control.tag = true for the ok button instead of going through all controls or do we have to be specific because
                //we are only setting some of them true (out of all controls because we are looping through all controls)*******
                //*****************************************************************************************************************************GO OVER
                control.Tag = false;
            }
            //*****************************************************************************************************************************GO OVER
            //if the parent form is not blank then we want to set the parent form (or is it if it exists)*****************************
            if ( parentForm != null) 
                
            {
                this.Owner = parentForm;
                this.CenterToParent();
            }

            this.formPerson = person;
            //if the parent form is not blank then we want to set the parent form (or is it if it exists)*****************************
            //*****************************************************************************************************************************GO OVER


            // all form configuration should be done first
            // before working with the form's data
            //couldnt we have just done a validateall() right after the for loop and it would have worked the same**
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
            //we can use the same delegate for all of our buttons because they all do the same thing if they are checked or not (changed)**************
            this.greatRadioButton.CheckedChanged += new EventHandler(RatingRadioButton__CheckedChanged);
            this.okRadioButton.CheckedChanged += new EventHandler(RatingRadioButton__CheckedChanged);
            this.mehRadioButton.CheckedChanged += new EventHandler(RatingRadioButton__CheckedChanged);
            //whenever an event has to change a label like here we have to have an event on when the check was changed (if the button was changed)
            //(and we have to set text if the radio button was changed)
            //but for the food we did not because there was no label or anything we had change do when we clicked a button****
            //if there was a label on food would we utilize same method or make different ones based on the groupboxes******

            //do we usually use EventHandler for shared methods like this or when do we usually use it beccause couldnt we have used a specific event
            //or is that only when its for one control**

            //first set up all eventhandlers then manipukate controls******
            //we want them to be able to click the picture and have a open file disologue control so that they can add their own photo*****
            this.photoPictureBox.Click += new EventHandler(PhotoPictureBox__Click);


            //*****************************************************************************************************************************GO OVER
            //whenever an event has to change a label like here we have to have an event on when the check was changed (if the button was changed)
            //(and we have to set text if the radio button was changed)
            //but for the food we did not because there was no label or anything we had change do when we clicked a button****
            //if there was a label on food would we utilize same method or make different ones based on the groupboxes (look above for the radiobutton comments)******

            //use eventhandler when its used generically and shared across controls(when to use) do we specify then when for it to activate in the
            //method because its a generic event handler******

            //datetime picker is from January 1 1753 and if we go lower then it throws an error*****
            //so we need to have it so if their birthdate is before 1753 it won't throw an error******
            //the contorl date has a minimum date and the default will be January 1 1753 
            //we want to show the date portion only not the time portion (miutes,seconds, hours, etc.) and we use a custom format (in the prop window where the date is)
            //and the customformat is then unlocked for our custom date and year within the same properties window for that control (do we have to do
            //anything specific to unlock the custom date control)******************************

            //have an event handler assocaited with the birthdatetimepicker (which is the date part in the designer and we named it
            //birthdatetimepicker) to have default blank date for January first 1753****
            //the birthdate which is the default min date then we want to show it as blank rather than the Jnauary 1 1753**
            //so that when someone opens a person to edit, and we did not set a birthdte for thm before the default would be January 1 1753 but it**
            //would show up as blank and if we had edited them before their data will show up for the date and we defined that in the ok button??******
            this.birthDateTimePicker.ValueChanged += new EventHandler(BirthDateTimePicker__ValueChanged);

            //any time the date changes we want to call this event handler**
            //how do we know to use a generic eventhandler here or can we use a specific one**

            //set up for web browser control**
            this.homepageWebBrowser.ScriptErrorsSuppressed = true; //this does**
                                                                   //show the webpage and we can intercept the web page and we can change it by doing DOM manipulation
                                                                   //we want to load the homepage from an exisintg person (not a new person we just created)**
                                                                   //whats the default if a person is created do we just leave the texbox blank and we can fill
                                                                   //it in and it would be saved (we did not default for when we save a person and if that part is
                                                                   //left blank)****

            this.FormClosing += new FormClosingEventHandler(PersonEditForm__FormClosing);//the this referes to personedit form
                //as the form is closing we want to**


            //set event handlers for clicking the tab controls**
            //the editpersonTabControl property in the designer we want to know**
            //the selectedindexchanged event (the tab contorl and combobbox have those prop.)**
            //and this works when the tabs have been changed on the tab control prop. in the deisnger)**

            //we also want to add shortcuts on the form and when they press enter that means ok and if they press escape that means cancel for the details tab on the form**
            //do the things on the form (the properrties for the ok and cancel button)*************************
            //we only want the controls to be enabled on the first (details tab) for the shortcuts**
            //by default its accessible on every tab even though the buttons dont show there so we want to disbale it every time the selected index
            //changes like we did in the delegate method??**
            //what did we do in the designer for the ok and cancel button**
            
            
            this.editPersonTabControl.SelectedIndexChanged += new EventHandler(EditPersonTabControl__SelectedIndexChanged);

            this.allCoursesListView.ItemActivate += new EventHandler(AllCoursesListView__ItemActivate);
            //this.allCoursesListView.KeyDown += new EventHandler(AllCoursesListView__KeyDown);
            //handle when they douvle click or rpess enter on a course to add it to the added course list**

            //we want a paintlistview for the courses as well to repaint the list when they add a course to their courses**
            //because it pulls informstion from the lists and to know which listview its populating**
            //so when they double click on all of the courses part with 1 course then it gets that and puts it within their own courselist
            //but does it remove it from the all courses tab or does the class still remain there**

         


            // after all contols are configured then we can manipulate the data
            //get the stored data for that specific person to show up on the new form we have opened
            //how does it know to open a new personeditform*****
            this.nameTextBox.Text = person.name;
            //these go to the delegate method we set for the textboxes because the values are getting changed or are they empty and we are putting them in**
            //initiallity*****
            //this.nameTextBox.TextChanged += new EventHandler(TxtBoxEmpty__TextChanged); or this.nameTextBox.Validating += new EventHandler(TxtBoxEmpty__Validating);****
            this.emailTextBox.Text = person.email;
            this.ageTextBox.Text = person.age.ToString();
            this.licTextBox.Text = person.LicenseId.ToString();


            //we want to start by setting the actual date of our control to be the minimum date
            //we want to show the date blank by default and we use the 1753 as the blank date when nothing is entered******
            //are we setting the default value to the minimum date of 1753**
            this.birthDateTimePicker.Value = this.birthDateTimePicker.MinDate; //we set the default vlaue here for the value but our delegate handles if
            //that default method has changed**
            //is it ok if we did this before the else above**

            //initialize date to be minimum if a new person was passed in and we set the value changed method and we//
            //we changed the value so it gets our method down below to change the value and it makes the minimum date the 
            //empty string

            if ( person.name == "")//if their name is empty then we know its a new person being added so we set their food to a default value******
                //this is when we first open the form of the person if no data was previously stored in?? (when we press add in the peoplelistform only
                //but not the edit of an existing person since the name was already input for it**
                //what if the name was not empty but the radio button was when we want to edit a current person because only the ok button**
                //deletes the current peroson then we can add a new one but when we open and exitign person it then it deos not account for that (the defult radio button
                //if one was not selected already if a name was entered (a person exists)******
            {
                person.eFavoriteFood = EFavoriteFood.pizza; //by default it will say their favorite food is broccolli so we change that*****
                //so if we edit a current person and they did not choose any food then it would default to brocolli right because we only accounted
                //for adding a new person to the form and not editing an existing one**
            }
            else
            {
                //the name being blank is the definer if we are adding a new person or editing a current one (could we have done the same
                //for email or age bacause those were empty as well to define a new peron)**
                //if its not a new person then we want to set their date of birth to**
                if(person.dateOfBirth > this.birthDateTimePicker.MinDate) //if their birth is less than the mindate field then we dont want to try and load it into
                    //the date time picker because then it would cause run time exceptin so we check if its greater than the min date then if it is we save that
                    //date as the value** (min date is built in and tells the default Janiary first 1753 date ruught)**
                {
                    this.birthDateTimePicker.Value = person.dateOfBirth; //if the name is not blank (the person was already exisitng when we padd it into the personeditform)**
                }
                //if the persons date is greater than minimum date then we set the time 

                this.homepageTextBox.Text = person.homePageURL; //load their url if they exist**
                                                                //(their name is not blank)**(thats what the big else statement is saying)**
                                                                //sets the personsurl when we load them in to edit them
            }


          
            //*****************************************************************************************************************************GO OVER


            //RADIO BUTTONS (set it as their favorite food)
            //we want to see what the enumrerated type is set to**
            switch (person.eFavoriteFood)
                //gets the food that they set to be their favorite from the perosn object we passed in from personlist form**
                //(in the ok button method in personedit form thats when we set the persons favorite food based on the raio button clicked**
                //and how we are checking when we retirve the data which one to make clicked so the person can edit the existing information)**
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
            //*****************************************************************************************************************************GO OVER

            //load the picturebox here now*****
            this.photoPictureBox.ImageLocation = person.photoPath; //basically here is displays the photo the person saved originally and now they are editing the person
            //again while the on in the ok button is setting the image we put from the photopicturebox click method??**
            //do we have a photopath field in  the person class thats why we can retireve this data from the person that was passed in**

            //string that contains path to their photo so we can load it onto the picturebox*****
            //when we retirve the person from the listform when we display all of their saved information we also want to get their**
            //saved photo that they put for the user before and display it on the form as well so they can edit that as well**

            //here we are using the picutebox on the form itself but when we are in the method we use the picturebox (pb) that was passed in whch was the sender
            //para. (cant we just use this. as well because there is only one pictrebox on that form or do we have to use sender**
            //how does it know to do something when the picture box is clicked because its only a generic event handler**
            //*****************************************************************************************************************************GO OVER


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

                    //this does not account for the case when a teacher name was entered already but no radio button selection was amde right**
                }

                switch( teacher.eRating ) //we basically check stored data for teacher specific items and set the stored radio button based 
                    //on what the rating was stored as from when we pressed ok after editing the person before (the ok button method)**
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

        //*****************************************************************************************************************************GO OVER
        //look at docuement outline and we can see on our editpersontabcontrol we have the tab pages and in the tab control is a property called selected tab
        //and it will be the tab page thats selected**
        //and we should tab document outline on our solution exploererer and its helpful to find our controls (right click then press prop. to access it)
        //*****************************************************************************************************************************GO OVER


        //for our courseslistview we want to handle doble click or enter on a course to add it to the added courselistview from all courses list**

        //*****************************************************************************************************************************GO OVER


        private void PaintListView(ListView lv)
        {

            ListViewItem lvi = null;
            ListViewItem.ListViewSubItem lvsi = null;

            // 13. lock the listview to begin updating it
            //we would want to lock it to prevent user from adding new courses or removing right
            //like we did so a person could not be added or edited while the list was being reaponted**
            //could not exit the form either while it was being repainted or could we**
            //every windows application is a multi threaded application and when we interact with a listview there could be another
            //process accessing that same form and that same control and we cant assume when we access a control that we are the only one using so
            //when we fill in the list view with data we need to lock it because there could be another process that accesses the same control
            //and wanting to update the data in the courselistview and it could take a long time updating the data in the listview and 
            //another process may want to change the data at the same time we are so we lock it so no other process can change the data in
            //the courselistview at thr same time and we dont assyme this is the only process thats updating the listview so
            //we put begin update to make sure
            //we should always have beginupdate before we edit a listview
            lv.BeginUpdate();


            // 12. clear the listview items
            //if it was before the begin update after we clear is another process could try to change the data in it before we had locked the listview
            //so this should go after the begin update
            lv.Items.Clear();

            int lviCntr = 0;

            // 14. loop through all courses in Globals.courses.sortedList and insert them in the ListView
            foreach (KeyValuePair<string, Course> keyValuePair in Globals.courses.sortedList)
            {
                Course thisCourse = null;

                // 15. set thisCourse to the Value in the current keyValuePair
                //key is course code and value is the course name as a string?? (the course code is a string too right not an int.)**
                //
                thisCourse = keyValuePair.Value;

                //*****************************************************************************************************************************GO OVER
                //we are using this one method to fill in the data for both listviews (the top listview is called selectedcourses listview)(and the bottom is called
                //allcourseslistview) both are in the prop. in the designer
                //if we want to fill all courses listview then we want to show all the courses we ahve in our sample database
                //but if anything in search textbox then we want to filter based on the thing in the searchbox for our allcourses listview
                //and for the selected courses we want to show our selected courses (for student and teacher in courselib we have a list of strings for 
                //the ccourses the person is registered for so the seleted courses list should contain the registered clases
                //we pass in the listview as the argument in the paintlistview
                //so we say if the listviw is the selected courseslistview then we want to access the formPerson (the person we are editing we set up in
                //the contrustor) then we want to see if the person is regustered for the current course we are on
                //and if the current person we are editing (formperson) if their course list contains the current course code
                //then we want the course code to show up in the list
                //
                //and if the current course is not in courselist then go back to the top of the loop and move on to the next course (we use the icourselist interface
                //which lets us look at that speciifc persons courselist)and in our peoplelib teacher inherits icourselist as well as a student
                //so we can point to the person via an interface
                //and we have the children inherit the interface to access the property whcih is the course list
                //now we use the interfaec to access the courselist
                //the formPerson is rather a student or teacher and it would work because they inherit the icourselist
                //but if they did not inherit then it would not work (we would get run time error)(code assumes its a student or a teacher because
                //its the two types of people that exists right now)
                if (lv == selectedCoursesListView)
                {
                    ICourseList iCourseList = (ICourseList)formPerson; //where was icourselist defined and waht do these do**

                    if (!iCourseList.CourseList.Contains(thisCourse.courseCode))
                    {
                        continue;
                    }
                }

                //the else is for the all courses listview and we want to filter our the courses that dont contain the coursetext
                //and first we see if theres anything in the course search box and if it is then we check if the course does not contains
                //the coursecode text or description in the searchbar then we just leave it and dont populate the all courses based on a search
                //when we repaint it then
                else
                {
                    if (courseSearchTextBox.TextLength > 0) //having searchbox check coursecode or description to see if course
                        //text is contained in there 
                        //and this checks for the coursecode and the description and accounts for both cases
                        //so if one of the things code or description was entered we keep that thing on the listview and keep going
                        //otherwise if the searchbox contains none of them the coursecode and description then we skip over that and dont add that
                        //on the listview
                    {
                        if (!thisCourse.courseCode.Contains(courseSearchTextBox.Text) &&
                            !thisCourse.description.Contains(courseSearchTextBox.Text))
                        {
                            continue;
                        }
                    }
                }
                //*****************************************************************************************************************************GO OVER


                // 16. create a new ListViewItem named lvi
                //each row of our listview 
                lvi = new ListViewItem(); //continues here is the searchtextbox and selected listcourse is valid 
                //and it adds the coursecode as the main column
                //and the decription as a subitem

                // 17. set the first column of this row to show thisCourse.courseCode
                lvi.Text = thisCourse.courseCode;

                // 18. set the Tag property for this ListViewItem to the courseCode
                lvi.Tag = thisCourse.courseCode;

                // alternate row color
                if (lviCntr % 2 == 0)
                {
                    lvi.BackColor = Color.LightBlue;
                }
                else
                {
                    lvi.BackColor = Color.Beige;
                }


                // 19. create a new ListViewItem.ListViewSubItem named lvsi for the next column
                //data in each subsequent column and we add that item to the list item subitems prop.
                //the lvi is the data in the first column and the subitems are the aditional columns in that row 
                lvsi = new ListViewItem.ListViewSubItem();

                // 20. set the column to show thisCourse.description
                lvsi.Text = thisCourse.description;

                // 21. add lvsi to lvi.SubItems
                lvi.SubItems.Add(lvsi);


                // 22. create a new ListViewItem.ListViewSubItem named lvsi for the next column
                lvsi = new ListViewItem.ListViewSubItem();

                // 23. set the column to show thisCourse.teacherEmail
                lvsi.Text = thisCourse.teacherEmail;

                // 24. add lvsi to lvi.SubItems
                lvi.SubItems.Add(lvsi);


                // 25. create a new ListViewItem.ListViewSubItem named lvsi for the next column
                lvsi = new ListViewItem.ListViewSubItem();

                // 26. set the column to show thisCourse.schedule.DaysOfWeek()
                // note that thisCourse.schedule.DaysOfWeek() returns the string that we want to display
                
                lvsi.Text = thisCourse.schedule.DaysOfWeek();

                // 27. add lvsi to lvi.SubItems
                lvi.SubItems.Add(lvsi);


                // 28. create a new ListViewItem.ListViewSubItem named lvsi for the next column
                lvsi = new ListViewItem.ListViewSubItem();

                // 29. set the column to show thisCourse.schedule.GetTimes()
                // note that thisCourse.schedule.GetTimes() returns the string that we want to display
                lvsi.Text = thisCourse.schedule.GetTimes();

                // 30. add lvsi to lvi.SubItems
                lvi.SubItems.Add(lvsi);

                // 35. lvi is all filled in for all columns for this row so add it to courseListView.Items
                lv.Items.Add(lvi);

                // 36. increment our counter to alternate colors and check for nStartEl
                ++lviCntr;

                //are we doing anything with adding the list to the top of the view for both lists**
                //are we deleting from the all courses when we put into selected courses or is it still there**
            }


            // 37. unlock the ListView since we are done updating the contents
            lv.EndUpdate();

            //if its the selected course listview then it looks at the courses within the person (from peolpelib the array or list?? of courses)**'
            //its the same code from the peoplelist but with different data in the different columns (same steps from peoplelist)
            //we want to first clear the items in the listview items (in both lists??)**
            //then we lock both the lists to begin updating both lists**
            //we add the courselist reference with a using statement and in our solution exploerer in personeditform
            //and we go through our sample courses and we use the foreach to go through all of that then grab the course
            //from the keyvakuepair property whcih is the courseobject (we use a reference courseobject to access the course name which is the value based on
            //the course code)**
            //since we have a teacher or student and an interface that lets us access a property of a string list and both our student and teacher
            //inherit that interface and they both have that public property of the list of courses so we use that interface to access both
            //the student and teacher list of courses (interface name??)**
            //we then mae=ke a variable of the interface and we cast it to the person we passed in and (go over condtionsla in the foreach loop)**
            //we create the listview item and save the coursecode in the text and the tag field to access the coursecode for each student
            //and for each additonal column create the listview stubitems for the rest of the course attributes
            //listveiwitem is each row in list and listviewsubitem is each aditional column in that row**
            //
        }
        private void PersonEditForm__FormClosing(object sender, EventArgs e)
        {
            if(this.Owner != null)
            {
                this.Owner.Enabled = true; //in the personedit form in the designer in the prop. there is there a control box and if its false then
                //the x and minimize are taken off of the control but if its true it sets the x and minimize or we could do this method
                //instead and say that if the owner is not null meaning that the parent form exists then enable it once we close this personeditform
                ////and still keep the exist and minimize buttons on the top right of the screen**

                //we use partial to spread across multiple files and we have the same namespace and define the same exact class defintion but wtih partial
                //so we can spread our file across other files (like put our constructor in one file and our web browser stuff in one file,etc)**
            }
        }

        //ASK************************************************************************************

        //ASK************************************************************************************

        //ASK************************************************************************************

        //ASK************************************************************************************BELOW
        private void EditPersonTabControl__SelectedIndexChanged(object sender, EventArgs e)
        {
            //we pass in the tab control so we have to cast it (sender)**
            TabControl tc = (TabControl)sender;
            if(tc.SelectedTab == this.detailsTabPage) //if the tab we selected is the detailstab then we want to make sure that the accept button is set to ok
                //and the cancel is set to cancel button 
            {
                this.AcceptButton = this.okButton;
                this.CancelButton = this.cancelButton; //our prop. we set up for enter for ok and our escape for cancelled in the prop only for the details tab**
            }
            else if(tc.SelectedTab == this.homePageTabPage)
            {
                this.AcceptButton = null;
                this.CancelButton = null;
                this.homepageWebBrowser.Navigate(this.homepageTextBox.Text); //navigates us to the url in the textbox when we type it in the textbox
                //then when we go to the homepage tab it shows the url (no need to press anything it loads when we put it in the url and goes to the hompage tab)**

            } //even though ok and cancel button is not available on homepage then when we press enter or cancel we
              //would press the ok on the details page or cancel on the details page and we have to set eneabled to false otherwise its always active even if the button
              //is invisible**
            else
            {
                //if the selcted tab then we want to disable the ok button and cancel button again (have to do for each tab??)****
                if(tc.SelectedTab == this.coursesTabPage)
                {
                    this.AcceptButton = null;
                    this.CancelButton = null;

                    //now we want to paint the listview for both of the courses lsits 
                    //why would we want to repaint if we are just getting on the tab shouldnt the data be the same since we are getting on the tab from
                    //a different one and data would not be changed**
                    PaintListView(this.allCoursesListView);
                    PaintListView(this.selectedCoursesListView); //repaint the all and selected course listsviews
                }
            }  

        }


        //now on the coursestab page we want to fill in all of the courses in the all courses and the ones they have selected in the 2 listviews
        //and it has a searchtextbox and the allcourses will filter based on the search string**
        


        //now write the delegate methods for pressing enter or double clicking a course to add to our selected courses**
        private void AllCoursesListView__ItemActivate(object sender, EventArgs e)
            //this is only when we double click on the allcourselistview
        {
            //basically when we double click a course in the allcourselistview then we get a reference to the course which is their coursecodes
            //then we get the coursecode from the selected items from the alcourselistview that we have selected
            //then we go to the courses list then get the course object based on the coursecode then if the course is not null and
            //the persons list alrrady has the courselist we want to reomve it from their list otherwise we want to add it to their list
            //and respint the listview 
            Course course;
            ListView lv = (ListView)sender; //our listview item (the course) that was double clicked on**

            string courseCode = null;
            courseCode = lv.SelectedItems[0].Tag.ToString(); //this is the courselist we selected
            //get the course name and cast it to a string because its an object then
            //we grab the course object from the sortedlist indexed on the coursecode and if we have clicked on a course we want to add
            //it to the persons  list of courses they are regustered for and we grab the form person and cast the interface as that person
            //and if we have a valid course object and if they person is currently registered for that course (if the courselist contains
            //the coursecode then we want to remove it from the courselist  otherwise we want to add it to their added list**
            //then we want to repaint the selected courseslistview                                                 


            //when we double click on our all courses it adds it to the top on the added courses otherwise if its in the added courses then
            //we double click on that then we put it back in all courses**
            course = Globals.courses[courseCode];
            //course = Globals.courses.sortedList[couresCode] to access without sorted list

            ICourseList iCourseList = (ICourseList)formPerson;

            if (course != null) //if we got a course from the indexer prop. by the course code
            {
                if (iCourseList.CourseList.Contains(course.courseCode)) //if the persons crouselist contains the coursecode we remove it
                    //otherwise if it does not contain the coursecode for that current person then we add it to their list of courses
                    //from allcourselistview 
                {
                    iCourseList.CourseList.Remove(course.courseCode); //our course list wont be in aplhabetical order 
                    //but when we reapint then it puts it in order in alphabetical order (we add or remove from that specific persons courselist
                    //and to add and remove we double click the control from the all courses list)

                    //right after we remove it from the courselist from the all course list then we call
                    //paintlistview to repaint the selectedcourses listview 
                    //and when we paint that lsitview it checks if the current course is in the courselist for the person
                    //the courselist represents the persons courselist that we are on for their selectedlistview 

                    //icourselist points to the person and if the person like a teacher is there they have a prop. and the i courselist points
                    //to teacher and icourselist.courselist points to the teachers courselist (the prop. within the teacher which is generic list fo strings
                    //for the course code)(all we need to access the course object is the course code and the course object has the time of class dow of class
                    //and all the other information)
                    //we use interface to point to person

                    //the indexer prop. allows us to get an object based on the string which is the coursecode from the sorted list of the keys as strings and values 
                }
                else
                {
                    iCourseList.CourseList.Add(course.courseCode);
                }

                PaintListView(this.selectedCoursesListView); // 1 course change = repaints the list
                //now we reapint the selectedcourseslistview
                
            }

        }

        private void AllCoursesListView__KeyDown(object sender, EventArgs e)
        {

        }

        //NEWEST NOTES:
        //limitation to dates so we need to code to support dates before 1753 and the datetimepicker shows minutes and seconds as well
        //so we do custom format (we can press f1 on any property to show which property it is and what it does)**
        //and we set it to every month then the day then year 
        //we first have to change the format to custom then custom format becomes unlocked**

        //by default we need to default a birthdate we cant set it to blank so we can write code that causes our datetime pciker to show blank if 
        //the date is some specific date (we want to make it blank if the data is January first 1753??)**

        private void BirthDateTimePicker__ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker dtp = (DateTimePicker)sender;
            if(dtp.Value == dtp.MinDate) //if the date we send in is equal to the min date (January first 1753)**
            {
                dtp.CustomFormat = " "; //if the minimum date is chosen then make it blank
                //otherwise give the date 
                //we always need the space so its blank when we have the date there for when a person sets the minimum date
                //
            }
            else
            {
                dtp.CustomFormat = "MMM d, yyyy"; //otherwise we want to set the date they put in this format**
            }
        }

        //the group box just gives us the label and the caption for the picturebox thats why we have the picturebox clicked to go to our files then add the hpoto
        // with open dialooge****
        private void PhotoPictureBox__Click(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;

            //we want to pop up the open file dislouge 
            //gets the filepath and when we press ok the image shows up on the photobox
            //and we store it in the picturebox and not the person until the ok button click
            if ( this.openFileDialog.ShowDialog() == DialogResult.OK)//if the result fo showing openfilediglogue (they clciked ok) then we set the picturebox
                                                                    //image location equal to the filename that they chose to display the photo****
                                                                    //basically the pop up window to their file exploerer shows up and once they select and
                                                                    //image and press ok we set the image location in the picture box
                                                                    //to be the filename (the photo) that the
                                                                    //user passed in****
            {
                pb.ImageLocation = this.openFileDialog.FileName; //here we open the file and put it on the cpiturebox??**
                //for the current picturebox it sets the location so we can**
                //set the image when it was changed and we rather get it in the constructor when we retrirve a person or set it in the ok button clicked**
            }
        }
        //*****************************************************************************************************************************GO OVER
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
                    //we need to default our radio button so it does not show label2 by default**
                    //when we press great it calls the meh radio button to unchecked then calls it again to hve the great button checked**

                    //by default we can multiseclted checkboxes not radiobuttons though its only one at a time so thats why we made a groupbox
                    //can we make it so we can select multiple at one time without a groupbox*****
                }
            }
        }

        private void OkButton__Click(object sender, EventArgs e)
        {
            Student student = null;
            Teacher teacher = null;
            Person person = null; //why is this necessary if we dont use it**

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

            //*****************************************************************************************************************************GO OVER
            //savethe persons date of birth so from the constructor when we load the person we make sure that therir date is more than the mindate then show it
            //on the form and the mindate method was when the value of the date box changed**
            person.dateOfBirth = this.birthDateTimePicker.Value;

            //save text that they put in if they change url** always save and get value (if person exists) at the same time so we dont forget
            person.homePageURL = this.homepageTextBox.Text;

            //for homepage we want to be able to fill in their homepageurl and want to load that from the person when we crate our form**
            //and we want it linked to the homepage tab (homepageWebBrowser control in the designer)
            //when they click on the homepage we want to load the homepage tab**

            //*****************************************************************************************************************************GO OVER
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
            //*****************************************************************************************************************************GO OVER
            person.photoPath = this.photoPictureBox.ImageLocation; //the image location is their fileapath and we can put url in there too
            //and the path can also be a url when we pull up a photo and change the file path to a url
            //so when we go back in constructor when a person is passed in, we use their photopath as the image location (what to display) of the photo they had passed in
            //when they had pressed ok when they edited the person before**
            //this implements our pgoto picturebox****************** 
            //*****************************************************************************************************************************GO OVER

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
                    //if it was a teacher and basically over here this handles when the person is editing the form****
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

            if( this.Owner != null) //again if the parent form is not null?? why would we need it twice**
            {
                this.Owner.Enabled = true;
                this.Owner.Focus();

                IListView listView = (IListView)this.Owner; //couldnt we just added a reference to peoplelistform and just have done Paintlistview(person.email)**
                listView.PaintListView(person.email); //this is where we pass the email and now it knows the person so it can get their email 
                //index from the condtional before the loop and when it gets to the condtional within the loop it checks if the current index we are on is that
                //person based on their email index we want to store that person as the first index then when we add all of our people we want to make that person
                //the top person on our list based on the variable we had used to store the email**
                //why do we have to cast it**
            }

            this.Close();
            this.Dispose(); //do we always use close and dispose with children form within the main form**
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

                this.gpaTextBox.Tag = (this.gpaTextBox.Text.Length > 0);//I am still confused about why we need this here because if its empty it still has the data
                //from the teacher if we changed it so even if we pass nothing it would be true so cant we just say true instead of this comparison in the
                //gpatextbox in the main form**
                //do we also have to account for when we add a person thats why and it would be empty in this case and nothing would be stroed since there was no teacher
                //beforehand**

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

                //*****************************************************************************************************************************GO OVER
                //once we set the deafult its still stored for the teacher when we edit it
                //this basically says that when we have a teacher set then it makes the deafult the ok button
                if ( !this.greatRadioButton.Checked && !this.okRadioButton.Checked && !this.mehRadioButton.Checked)
                {
                    this.okRadioButton.Checked = true;
                }
                //*****************************************************************************************************************************GO OVER
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
                e.Handled = false; //false for key suppress and handled means windows handles it and true means we handle it and at the end of the method
                //if it checks if its true it does not display on the form but if its false then it displays on the form**
                //if it allows a backspace then if we remove evertthing how does it know the form is empty or not is it because of our validating states
                //and if its empty it calls the emoty method while if we are chaning something thats existing it calls that as well (how does it know
                //we are editing something and that its not empty is it built into the event handler)**
                tb.Tag = true; 
            }
            else
            {
                e.Handled = true; //how does it get to the else statement if it already takes care of the numbers above**

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
