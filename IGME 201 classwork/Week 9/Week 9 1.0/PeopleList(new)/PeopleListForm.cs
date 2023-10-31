using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PeopleAppGlobals;
using PeopleLib;


//people app globals is our database of our people and our courses lists

//we delete the control and make a windows form by going to solution then press add then form (we can delete it)
//listview control is used for the class libraries we use and
//the resulting product is a list of people with teachers and students and we can add people and if we press
//enter on one of the people then we can edit the person

//the list view control allows us to view by list, icons, detailed view (we will be using),etc.
//we have a listview control with peole listview and the name of the columns are the name of the field in the class(peoplelist) (in the documentation)
//columns for the name, email, etc. (stroed in columns prop. of the list view) (if we click on dots to look at the collection
//for the columns we can see the headers for each and always look at prop. in alphabetical order)

//for each of our column headers we have the name of the header (field) and the name of the actual box and the alignement
//of the columns

//to add a new column header we do the add we are still where the 3 dots tab (edit columns) is in column and we
//can add a major header for the student and if we wanted to show it as the second instead of 5th then we can change the index in the fields
//part where we type it in to move it up
//and when we click ok, it moves the header

//we always add text so we can see the label and we change the name in the text field to show on our form
//we can also press remove in the 3 dots tab as well to remove the column if we want
//how to display the width in the list view control like we did with the columns (width element in the columns)
//outside of the 3 dots in the actual properties, we can have gridlines or not (we have gridliens) and we can allow multi select but for now we 
//want them to select one person at a time

//the view property allows us to change the icons and by default it gives us large icon and we need to set it to detaiils
//to get icons to show (the headings for the columns)

namespace PeopleList
{
    public partial class PeopleListForm : Form
    {

        //we want to be able to create our sample code (our sample data) and to do that we want another dll
        //people class global dll will contain the list of actual people and peopleapp still needs access to our people so we need to put
        //it there (this only gives us the list of people and not the course information thats why we dont put it here)

        //and we put using statement above for the peopleappglobals and the peoplelib before didnt it do it automatialcally why do
        //we have to do it automatically

        //if we add the reference for the dll and it could add it sometimes or not but the using statement has to be there 

        public PeopleListForm()
        {
            InitializeComponent(); //put all code below this

            Globals.AddPeopleSampleData(); //in the class globals from the peopleappglobals  

            //we also need buttons to add and remove a person in the designer
            //now set up delegate methods for list view


            // 1. use the PeopleListView__KeyDown delegate
            this.peopleListView.KeyDown += new KeyEventHandler(PeopleListView__KeyDown); 
            //keydown handles enter on the list and the itemactivate is if we double click with mouse and it allows us to change an object
            //listview is called peopleListView

            //the this. refers to the form1.designer??** the objectName (control name) is the field name in the we set in the "Name" field within
            //the form and then another . for the event then after the += its the new event then in () the name of the delegate
            //so basically the buttons and toolstrips we create are the properties and the things we set within them are the fields??**

            // 2. use the PeopleListView__ItemActivate delegate
            this.peopleListView.ItemActivate += new EventHandler(PeopleListView__ItemActivate);

            // 3. use the AddButton__Click delegate
            this.addButton.Click += new EventHandler(AddButton__Click);

            // 4. use the RemoveButton__Click delegate
            this.removeButton.Click += new EventHandler(RemoveButton__Click); //gives us our buttons in the bottom of the form

            // 5. use the ExitButton__Click delegate
            this.exitButton.Click += new EventHandler(ExitButton__Click);
            //when they exit the form they will be exitng our application

            PaintListView(null); 
            
        }


        //the columns property order has nothing to do with the order on the form and the order on the form is by the displayIndex not just moving around
        //the blocks for the index
        //the order of columns is displayed by displayindex
        //for each column we can set width and alignedment and order it displays in 




        // notice that we are making PaintListView public so that it can be called from other classes
        public void PaintListView(string firstEmail) //accepts the first email to be shown in the list view and the first time we come in we want to start from
            //the first email in our people list and set null as the first email**
            //items prop. in peeopleslistview and every items prop. has a list view item and its each row thats in the list view
            //the text (shows up in first column of row), subitems (stores data for each additional column in the row so if we had 5 columns in our list view
            //we will have 1 text and 4 sublist view items)**
            //each row will consist of 1 person from our people list in our form**
        {
            // a ListView contains an Items field, which is an array of the rows in the ListView.**
            // Items is an array of ListViewItem**(where was this in our controls and which control would it usually be in)**
            ListViewItem lvi = null; //listviewitem is our ref. variable then our subitem and we view it like this to access each and we initally set it to null**

            // ListViewItem contains the details of the first column in a row
            // and an array of ListViewSubItems for all additional columns in the row
            ListViewItem.ListViewSubItem lvsi = null;

            // we can also set the first ListViewItem to show in the list
            // which is preferable if a person was just edited, the list
            // should draw with that person at the top
            // the firstEmail function parameter is the email that should show at the top
            ListViewItem firstLVI = null; //save the first list view item**

            // nStartEl is the SortedList index element that the ListView should start with
            // based on firstEmail which was passed to our PaintListView() function
            // default to start with the first Person in the SortedList
            int nStartEl = 0; //if we pass in an email we want to know which index was the starting element so we can get the index of
            //the email that was passed into our method (if email was passed in then we can check the index down below in the if statement)**

            // clear the ListView Items
            this.peopleListView.Items.Clear(); //clear all items in our list view so its empty before we populate then line below we lock it 
            //because we may have multiple processes accessing the list view at the same time and if one process is updating the list already,
            //then another process is being done as well there could be a conflict because 2 things are being done at one time 
            //so we want to do one at a time (like a queue)**

            // lock the ListView to begin updating it
            this.peopleListView.BeginUpdate();

            // if an email was passed in for us to display as the first Person in the ListView
            if (firstEmail != null)
            {
                // fetch the index of the SortedList
                nStartEl = Globals.people.sortedList.IndexOfKey(firstEmail); //get the starting index element of the email that was passed into our method
                //indexofkey is the method for the sorted list structure thtat returns the index of a key (value) in the sorted lust**
            }

            // use a cntr to check against nStartEl and to enable us to change the
            // background color of each row to make the SortedList more readable
            int lviCntr = 0; //allowes us to change the colors of the colors of our rows**

            // loop through all people in the SortedList and insert them into the ListView
            // notice how we access the People class via the Globals class we created in PeopleAppGlobals
            foreach (KeyValuePair<string, Person> keyValuePair in Globals.people.sortedList) //insert each person into the list view and we are
                //accessing our sorted list based on our globals then the people variable object which was the list then access the lust from
                //the people and each entry ni our list is a key value pair and the key s email and the object is a peson**
            {
                // 6. declare a Person variable called thisPerson and set it to the current keyValuePair Value
                //not creating new object just a varuble that points to the object that is in the key value pair**
                Person thisPerson = keyValuePair.Value;

                // 7. set lvi equal to a new ListViewItem object
                // this will be the new row we are adding to the ListView for this specific person we are on**
                lvi = new ListViewItem();//**

                // alternate row color
                if (lviCntr % 2 == 0) //depending on our row number variable here if its an even number the color will be light blue or beiege based on our rows
                {
                    lvi.BackColor = Color.LightBlue;
                }
                else
                {
                    lvi.BackColor = Color.Beige;
                }

                // 8. lvi.Text is the text that shows in the first column of the row
                // set it equal to the person's name
                //text in first column is persons name**
                lvi.Text = thisPerson.name;



                // since the email address is the key into the SortedList
                // let's save that in the general purpose Tag field
                //store each key for that person so we can access it easier (the email address is the key)**
                //save it in the tag field for the current list item**
                lvi.Tag = thisPerson.email;
                //when we select a row from our list we will immediately know email address and************************************************

                // 9. all additional columns are stored in the lvi.SubItems array
                // set lvsi equal to a new ListViewItem.ListViewSubItem object
                //create our first listview sub item which is the daat from the second column***********
                lvsi = new ListViewItem().ListViewSubItem();

                // 10. lvsi.Text is the text that shows in each subsequent column
                // set it equal to the person's email********************

                // add the ListViewSubItem to the lvi.SubItems array****************
                lvi.SubItems.Add(lvsi);

                // 11. we need another column to show the person's age
                // set lvsi equal to a new ListViewItem.ListViewSubItem object (follow these same steps to populate the list view for the people)******
                lvsi = new ListViewItem().ListViewSubItem();

                // 12. set lvsi.Text equal to the person's age
                // note that age is an int, so you will need to convert it to a string
                // you can use Convert.ToString(int) or the ToString() method of the integer
                lvsi.Text = thisPerson.age.ToString(); //convert to string because we are storing it as a string

                // 13. add the ListViewSubItem to the lvi.SubItems array
                lvi.SubItems.Add(lvsi);

                // 14. we need another column to show the person's License Id
                // set lvsi equal to a new ListViewItem.ListViewSubItem object
                lvsi = new ListViewItem().ListViewSubItem();

                // 15. set lvsi.Text equal to the person's License Id
                // note that license id is an int, so you will need to convert it to a string
                lvsi.Text = thisPerson.LicenseId.ToString();

                // 16. add the ListViewSubItem to the lvi.SubItems array
                lvi.SubItems.Add(lvsi);

                // 17. we need another column to show the person's GPA if they are a Student
                // or Specialty if they are a Teacher
                // set lvsi equal to a new ListViewItem.ListViewSubItem object
                lvsi = new ListViewItem().ListViewSubItem();

                // 18. if thisPerson is a Student then declare student variable then declare the text to tbe the students gpa for that column**
                // refer to class code examples for how to use GetType() and typeof()
                // "is" checks for relationship
                //if( thisPerson is Student )
                // GetType() / typeof() checks for specific data type, not relationship
                if(thisPerson.GetType() == typeof(Student)) //if the object we are currently on is from the student class then we want to have a ref. variable of the student class**
                {

                    // 19. declare a Student variable set to thisPerson cast as a (Student)*********
                    Student student = new Student() thisPerson;

                    // 20. set lvsi.Text equal to the student's GPA
                    // note that gpa is a double, so you will need to convert it to a string
                    lvsi.Text = student.gpa.ToString(); 
                }
                else
                {
                    // 21. declare a Teacher variable set to thisPerson cast as a (Teacher) (otherwise its a teacher so use a teacher variable)**
                    Teacher teacher = new Teacher() thisPerson;

                    // 22. set lvsi.Text equal to the teacher's Specialty
                    lvsi.Text = teacher.specialty;
                }

                // 23. add the ListViewSubItem to the lvi.SubItems array (why do we need to add)****
                lvi.SubItems.Add(lvsi);


                // if this row is the first email that should be shown
                if (firstEmail == thisPerson.email)
                {
                    // set this row as being currently selected
                    lvi.Selected = true; //it will be highligeted**

                    // set this ListViewItem to be focused upon (otherwise the current focus defaults to the first in the list)
                    //want to focus on this item otherwise the listview focus is to the first thing in the list (the top)******
                    lvi.Focused = true; //will be shown on the current screen**

                    // save a reference to this ListViewItem object
                    firstLVI = lvi;
                }

                // we completed 1 row of the ListView
                // we can finally add this ListViewItem to the Items array
                this.peopleListView.Items.Add(lvi); //the whole list to the items prop. of the listview item of everything we added for that row*****

                // increment our row counter (used for alternating between the colors****
                ++lviCntr;
            }

            // EndUpdate() unlocks the ListView
            this.peopleListView.EndUpdate();

            // set the Top ListViewItem of the list to show on the screen
            this.peopleListView.TopItem = firstLVI;
        }

        //now we need to see if they press enter on a list view (keydown) if they press enter its going to call this method and the delegate method
        //returns void accepts an object and an eventargs

        private void PeopleListView__KeyDown(object sender, KeyEventArgs e) //object is the list view we pressed enter on****
        {
            ListView lv = (ListView)sender; //explicitly cast because its an object** key code is the key they pressed and we check if they pressed enter**
            if(e.KeyCode == Keys.Enter) //windows processes the keys we press and we can tell windows to suppress that keypress by using the e.supresskeypress prop.
                //if they press enter on the form we dont want windows to process the enter key*****
            {
                e.SuppressKeyPress = true; //this is like the handled and basically it tells us that the developer wants to handle it instead of windows**
                //if they press enter we dont want windows to do anything with that key so we suppress it**

                //we will now try to get email associated with the line that they selected**
                //saved email in tag prop. in the lvi.Tag = thisperson.email****
                //and we can use that to get the person our of our sorted list**
                try
                {
                    //get the email from the list view itme
                    //whichever item is current selected and multiple can be when we set multi selct was set to true in the peopleslistview (if it was true)
                    //but we only allow user to edit one person at a time so we set it to false 
                    //we only access the 0th index for the current item we are in and the tag is what we are accessing which is the email and we make it s
                    //string because****
                    string email = lv.SelectedItems[0].Tag.ToString();
                    //tag is an object and if we reference it because its an object we need to cast it to a string and we cant set a mroe specific to less specific
                    //without casting it (string is more specific than object so we do to string)(same with int.,etc.)****
                    //we could also do (string) after lv. and not do tostring();

                    //we do this in a try because there could be no item selected and somebody deleted our list of people and theres nothing in our list so we
                    //make sure******

                    Person person = null; //the person with the email its assocated with*****
                    person = Globals.people[email]; //uses our indexer prop. to read out of the email in our people class****

                    //we now want to disable the people ls=ist form so we set this so we can set enabled to false
                    //and prevents us from editing two people at once and disbales the rest of the document**** (once we choose a person to edit we disable the form**
                    this.Enabled = false;

                    //pass the person and the current form as the parent form that laucnhed our editperson form
                    //creates new edit person form and now we need to link them*****
                    
                    EditPersonForm epf = new EditPersonForm(person, this);
                    epf.Show();//above creates edit person form and here we want to show it and it handles all of the events against it 
                    //when we create forms we need to show them and have them process the user interaction with them

                    //in edit person we built it as an executable and we can run it 
                    //we never called the show command in the editperson and if we look in the solution exploerer the program.cs was written automatically
                    //writtern by c# and also added the form automatically and c# created a main method for us in the program.cs and it does
                    //application.run for us and created a new personeditform object for us (when we write our appliction the very first form
                    //thats in our application should be laucnhed from the main and we use application.run and it creates the form with the new keyword
                    //and the run method displays the form and enables all of the windows features for our applicaion****
                    
                    //in our people list since its a contrls libryary we dont have a rpogram.cs and theres no main in our dll appliction and our dll cant
                    //be run by itself and it can only be called by another executable
                    //so we are making one called windwspeopleapp
                    //only purpose of executable is to launch people list


                }

                catch
                {

                }

            }
        }

        // handle clicking the Remove button
        private void RemoveButton__Click(object sender, EventArgs e)
        {
            try
            {
                string email;

                // 24. The ListView has a SelectedItems array field
                // which is the array of ListViewItems which are currently selected
                // Since we have MultiSelect set to false, only one row can be selected
                // so we only check SelectedItems[0]
                // In line #107 above we set the lvi.Tag = the email
                // Set email = the email address saved in the Tag field for SelectedItems[0]
                // Since Tag is a System.Object,
                // use the ToString() method to convert the object to a string

                // 25. if email is not equal to null
                {
                    // 26. remove the entry from Globals.people associated with the email address
                }
            }
            catch
            {

            }

            // 27. repaint the ListView passing null as the email address to start from the top of the SortedList
        }

        private void peopleListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
