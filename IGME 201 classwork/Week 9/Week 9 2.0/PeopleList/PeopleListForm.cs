using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PeopleAppGlobals; //list of people (student and teachers)**
using PeopleLib; //the student and teacher  and person objects**
using EditPerson; //personeditform?? (allows us to edit a person when we double click or press enter on any of their entries or only their email)??**

//I am still confused on why we have to create a reference to peoplelib because we already have our person being accessed in the peopleappglobals 
//and in personeditform is it because in peeoplelistview__keydown we have to create a new person and make it equal to the person
//we pressed enter on when we got their name from the list then create a new form with that person we are on so we can edit them??**

namespace PeopleList
{
    public partial class PeopleListForm : Form //does it automatically inherit form or do we put it ourselves what does it mean and when do we know to put it**
                                                //we need partial in all of our classes because they are being shared with each other in one application**
    {
        public PeopleListForm()
        {
            InitializeComponent(); //always goes on the top and it initializes all of our things we put in our forms like buttons,etc. and puts it in the form1desginer.cs
                                    //file that we don't interact with and it's usually hidden** and we put all code below this 

            Globals.AddPeopleSampleData(); //we created a people class instance which the list is stored in peoplelib then we created a reference
                                            //to the person class or indexer prop.??**
                                            //in peoplelib which is the indexer prop. to put things within the list and get things within
                                            //the list based on a person object email (teacher or a student)**
                                            //the key is the email to get things and put things within the list and the value is a person object (teacher or a student usually)**
                                            //how can we edit a person then??)**

            // 1. use the PeopleListView__KeyDown delegate
            this.peopleListView.KeyDown += new KeyEventHandler(PeopleListView__KeyDown);

            // 2. use the PeopleListView__ItemActivate delegate
            this.peopleListView.ItemActivate += new EventHandler(PeopleListView__ItemActivate);
            //the object name refers to whatever we put in the name section in the properties right**
            //when we press enter or double click we can do it anywhere right but it has to be in the same
            //row as the person we want to edit on**

            // 3. use the AddButton__Click delegate
            //this.addButton.Click += new EventHandler(AddButton__Click); //why did we comment these out**
            //are we going to use these soon because these are supposed to be the buttons at the bottom of
            //the form**

            // 4. use the RemoveButton__Click delegate
            //this.removeButton.Click += new EventHandler(RemoveButton__Click);

            // 5. use the ExitButton__Click delegate
            //this.exitButton.Click += new EventHandler(ExitButton__Click);

            //the this. refers to the form1.designer in windows forms usually why
            //would we want to use it when creating delegates but nowhere else??**
            //the objectName is the field
            //name in the we set in the "Name" field within
            //the form property and then another . for the event then after the += its the
            //new eventhandler or another event handler then in () the name of the delegate**

            //so basically the buttons and toolstrips we create are the properties
            //and the things we set within them are the fields in the designer??**

            PaintListView(null); //why do we pass null into here and how does it work**
        }

        //the columns property order has nothing to do with the order on the form and the order on the form is by the displayIndex not just moving around
        //the blocks for the index
        //the order of columns is displayed by displayindex
        //for each column we can set width and alignedment and order it displays in 

        private void PeopleListView__KeyDown(object sender, KeyEventArgs e) //object is the list view we pressed enter on****
        {
            ListView lv = (ListView)sender;
            //explicitly cast because its an object(higher than anything in c#)**
            //key code is the key they pressed and we check if they pressed enter**

            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                //this is like the handled and basically it tells us that the developer wants to handle it instead of windows**
                //if they press enter we dont want windows to do anything with that key so we suppress it**


                //we will now try to get email associated with the line that they selected**
                //saved email in tag prop. in the lvi.Tag = thisperson.email**** (global even though
                //its defined in a function)**
                //and we can use that to get the person our of our sorted list**

                try
                {
                    //get the email from the list view itme
                    //whichever item is current selected and multiple can be when we set multi selct was set to true in the peopleslistview (if it was true)
                    //but we only allow user to edit one person at a time so we set it to false 
                    //we only access the 0th index for the current item we are in and the tag is what we are accessing which is the email and we make it s
                    //cast to string because tag is an object??**
                    string email = (string)lv.SelectedItems[0].Tag;
                    //string email = lv.SelectedItems[0].Tag.ToString();

                    //we do this in a try because there could be no item selected and somebody deleted our list of people and theres nothing in our list so we
                    //make sure (how do we make sure is it just when theres nothing the catch will run but theres nothign in it)**

                    Person person = null; //person object 
                    person = Globals.people[email]; //goes to the globals then goes to the people
                    //list we had created them references the value which is the person based on the email**


                    //we now want to disable the people ls=ist form (mina form in designer)
                    //so we set this so we can set enabled to false
                    //and prevents us from editing two people at once
                    //and disbales the rest of the document**** (once we choose a
                    //person to edit we disable the form**
                    this.Enabled = false;

                    PersonEditForm epf = new PersonEditForm(person, this);
                    //epf.Show();
                    //why remove the show here because it's not in the constructor**

                    //above creates edit person form and here we want to show it and it handles all of the events against it** 
                    //when we create forms we need to show them and have them process the user interaction with them**

                    //in personeditform we built it as an executable and we can run it 
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

        private void PeopleListView__ItemActivate(object sender, EventArgs e)
        {
            ListView lv = (ListView)sender;

            try
            {
                string email = (string)lv.SelectedItems[0].Tag; //gets the email 
                //then we have a person then get the objecy based on the email
                //then ew set enabled to false so that we can disbale the rest of the form to edit
                //one person then we make the new form for that person based on
                //the perosn objecy and this whic is **

                Person person = null;

                person = Globals.people[email];

                this.Enabled = false;

                // only use this method if the Show() is at the end of the constructor!
                new PersonEditForm(person, this);
            }
            catch
            {

            }
        }


        // notice that we are making PaintListView public so that it can be called from other classes'
        //why do we need to call it from the other classes

        //accepts the first email to show in the list view and the first
        //time we come in we want to start from
        //the first email in our people list and set null as the first email (why??)**
        //items prop. in peeopleslistview and every items prop. has a list
        //view item and its each row thats in the list view (where)****
        //the text (shows up in first column of row), subitems (stores data
        //for each additional column in the row so if we had 5 columns in our list view
        //we will have 1 text and 4 sublist view items)**
        //each row will consist of 1 person from our people list in our form**
        public void PaintListView(string firstEmail)
        {
            // a ListView contains an Items field, which is an array of the rows in the ListView.
            // Items is an array of ListViewItem
            ListViewItem lvi = null; //this gives us the first thing in the row which is the name??**
                                     //this gives us an array of all the names??**

            // ListViewItem contains the details of the first column in a row
            // and an array of ListViewSubItems for all additional columns in the row
            ListViewItem.ListViewSubItem lvsi = null; //this gives us everything else in that row
                                                        //not including the name because the listviewitem
                                                        //was the name and gives us an array
                                                        //off the details within the specific row
                                                        //for one person (student of teacher usually)**


            // we can also set the first ListViewItem to show in the list
            // which is preferable if a person was just edited, the list
            // should draw with that person at the top (so basically if we edit a person
            // it brings them to the top of the list once we edit them??)**
            // the firstEmail function parameter is the email that should show at the top**
            //whats the difference between this listvieeitem we declared and the one at the top**
            //if we put the email at the top only how would it add the items at the top??**
            ListViewItem firstLVI = null;

            // nStartEl is the SortedList index element that the ListView should start with
            // based on firstEmail which was passed to our PaintListView() function
            // default to start with the first Person in the SortedList
            int nStartEl = 0;

            //this basically gets the index of the person based on their email within our sortedlist??**
            //(if email was passed in then we can check the index down below in the if statement)**

            // clear the ListView Items
            //where did ser set this in designer because there is a differnt name we put in the name section**
            this.peopleListView.Items.Clear();

            //clear all items in our list view so its empty before we populate then line below we lock it 
            //because we may have multiple processes accessing the list
            //view at the same time and if one process is updating the list already,
            //then another process is being done as well there could be
            //a conflict because 2 things are being done at one time 
            //so we want to do one at a time (like a queue)**

            // lock the ListView to begin updating it (what does this and line above do**
            this.peopleListView.BeginUpdate();

            // if an email was passed in for us to display as the first Person in the ListView
            if (firstEmail != null) //what if its not null and it goes through here and the email was not valid**
            {
                // fetch the index of the SortedList
                nStartEl = Globals.people.sortedList.IndexOfKey(firstEmail);
                //tells us the index based on the key for indexofkey within the sortedlist**
                //only used with sortedlists??**
            }

            // use a cntr to check against nStartEl and to enable us to change the
            // background color of each row to make the SortedList more readable
            int lviCntr = 0; //changes colors of rows??**

            // loop through all people in the SortedList and insert them into the ListView
            // notice how we access the People class via the Globals class we created in PeopleAppGlobals

            //insert each person into the list view and we are
            //accessing our sorted list based on our globals then the people
            //variable object which was the list then access the lust from
            //the people and each entry ni our list is a key value pair and the
            //key is email and the object is a peson**
            foreach (KeyValuePair<string, Person> keyValuePair in Globals.people.sortedList)
            {
                // 6. declare a Person variable called thisPerson and set it to the current keyValuePair Value
                Person thisPerson = keyValuePair.Value;
                //variable that points to a key value pair of that type of object** (not a new instance)**

                // 7. set lvi equal to a new ListViewItem object
                // this will be the new row we are adding to the ListView
                lvi = new ListViewItem();

                // this will be the new row we are adding to the ListView for
                // this specific person we are on (I thought this only stored the name??)**

                // alternate row color
                if (lviCntr % 2 == 0) //depending on our row number variable here if its an even number
                                      //the color will be light blue or beiege based on our rows
                {
                    lvi.BackColor = Color.LightBlue;
                }
                else
                {
                    lvi.BackColor = Color.Beige;
                }

                // 8. lvi.Text is the text that shows in the first column of the row
                // set it equal to the person's name
                lvi.Text = thisPerson.name;

                // since the email address is the key into the SortedList
                // let's save that in the general purpose Tag field

                //store each key that we are currently adding into our listview (current person we are adding)
                //so we can access it easier (the email address is the key)**
                //save it in the tag field for the current list item (could we have used another varible
                //other than the tag and how many tags can we have)**(when do we usually use tags)**
                //when we select a row from our list we will immediately know email address and**
                lvi.Tag = thisPerson.email; //tag is basically a property then right**
                //and its usually used for lists to get and set right??**

                // 9. all additional columns are stored in the lvi.SubItems array
                // set lvsi equal to a new ListViewItem.ListViewSubItem object
                //create our first listview sub item which is the daat from the rest of the columns other than
                //then name which was the main listviewitem we defined right above here**
                //could we have also intizlized up there instead of null why did we set it to null**
                lvsi = new ListViewItem.ListViewSubItem();

                // 10. lvsi.Text is the text that shows in each subsequent column
                // set it equal to the person's email
                lvsi.Text = thisPerson.email; //this is basically the second column and we are setting
                //it as a sub item as a new column (how does it know to make a column)**

                // add the ListViewSubItem to the lvi.SubItems array
                //add the email column to the subiteems (array or list??)**
                lvi.SubItems.Add(lvsi);

                // 11. we need another column to show the person's age
                // set lvsi equal to a new ListViewItem.ListViewSubItem object
                //(follow these same steps to populate the list view for the people(the columns))**
                //and add the columns for the people)**
                lvsi = new ListViewItem.ListViewSubItem();

                // 12. set lvsi.Text equal to the person's age
                // note that age is an int, so you will need to convert it to a string
                // you can use Convert.ToString(int) or the ToString() method of the integer
                //so basically anything that has to show on form should be a string like how it was
                //with console**
                lvsi.Text = thisPerson.age.ToString();

                // 13. add the ListViewSubItem to the lvi.SubItems array
                //since we are using the same variable once we add it do we override it with a new**
                //listview item them set the text for whatever column then add it then repeat the process**
                //for each column??** how does it know to make it a colunm does listview and listviewsubitem**
                //already know to do that**
                lvi.SubItems.Add(lvsi);

                // 14. we need another column to show the person's License Id
                // set lvsi equal to a new ListViewItem.ListViewSubItem object
                lvsi = new ListViewItem.ListViewSubItem();

                // 15. set lvsi.Text equal to the person's License Id
                // note that license id is an int, so you will need to convert it to a string
                lvsi.Text = thisPerson.LicenseId.ToString();

                // 16. add the ListViewSubItem to the lvi.SubItems array
                lvi.SubItems.Add(lvsi);

                // 17. we need another column to show the person's GPA if they are a Student
                // or Specialty if they are a Teacher
                // set lvsi equal to a new ListViewItem.ListViewSubItem object
                lvsi = new ListViewItem.ListViewSubItem();

                // 18. if thisPerson is a Student
                // refer to class code examples for how to use GetType() and typeof()
                // "is" checks for relationship
                //if( thisPerson is Student )
                // GetType() / typeof() checks for specific data type, not relationship
                //its more safer to use gettype and typeof right**
                if (thisPerson.GetType() == typeof(Student))
                //if the object we are currently on is from the student class then we want to have a ref.
                //variable of the student 
                {
                    // 19. declare a Student variable set to thisPerson cast as a (Student)
                    //because we are accessing from low to high (thisperson is higher than student and teacher)**
                    Student student = (Student)thisPerson;

                    // 20. set lvsi.Text equal to the student's GPA
                    // note that gpa is a double, so you will need to convert it to a string
                    lvsi.Text = student.gpa.ToString();
                }
                else
                {
                    // 21. declare a Teacher variable set to thisPerson cast as a (Teacher)
                    Teacher teacher = (Teacher)thisPerson;

                    // 22. set lvsi.Text equal to the teacher's Specialty
                    lvsi.Text = teacher.specialty;
                }

                // 23. add the ListViewSubItem to the lvi.SubItems array
                lvi.SubItems.Add(lvsi);

                // if this row is the first email that should be shown
                //go over this conditonal**
                if (firstEmail == thisPerson.email)
                {
                    // set this row as being currently selected
                    lvi.Selected = true;

                    // set this ListViewItem to be focused upon (otherwise the current focus defaults to the first in the list)
                    lvi.Focused = true;

                    // save a reference to this ListViewItem object
                    firstLVI = lvi;
                }

                // we completed 1 row of the ListView
                // we can finally add this ListViewItem to the Items array
                //why do we do this. here is it because we are now actually adding to the deisgner it self
                //is that what this. means**
                this.peopleListView.Items.Add(lvi);

                // increment our row counter
                ++lviCntr;
            }

            // EndUpdate() unlocks the ListView
            this.peopleListView.EndUpdate(); 
            //why would we wnant to lock the whole form if we are just creating the form**

            // set the Top ListViewItem of the list to show on the screen
            this.peopleListView.TopItem = firstLVI;
            //this sets the current person we had made to be the first thing on the list in our whole
            //for because of this.**
            //how would it know though because we ser firstLVI = lvi so wouldnt the fistLVI be lost
            //and it is now set to the current position of them item**
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

    }
}
