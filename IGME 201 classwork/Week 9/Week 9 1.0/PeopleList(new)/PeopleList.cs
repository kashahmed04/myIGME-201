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

//in forms the class is the form and the fields are what we put into the form right

//to add a new column header we do the add we are still where the 3 dots tab (edit columns)** is in column and we
//can add a major header for the student and if we wanted to show it as the second instead of 5th then we can click arrow to move it up
//and when we click ok, it moves the header

//we always add text so we can see the label and change the name field
//we can also press remove in the 3 dots tab as well to remove the column if we want
//how to display the width in the list view control like we did with the columns (width element in the columns)
//outside of the 3 dots in the actual property, we can have gridlines or not and we can allow multi select but for now we 
//want them to select one person at a time

//the view property allows us to change the icons and by default it gives us large icon and we need to set it to detaiils
//to get icons to show (what else is there is details the most common)

namespace PeopleList
{
    public partial class PeopleList : Form
    {

        //we want to be able to create our sample code (our sample data) and to do that we want another dll
        //people class global dll will contain the list of actual people and peopleapp still needs access to our people so we need to put
        //it there (this only gives us the list of people and not the course information thats why we dont put it here)

        //and we put using statement above for the peopleappglobals and the peoplelib before didnt it do it automatialcally why do
        //we have to do it automatically

        //if we add the reference for the dll and it could add it sometimes or not but the using statement has to be there 

        public PeopleList()
        {
            InitializeComponent(); //put all code below this

            Globals.AddPeopleSampleData(); //in the class globals from the peopleappglobals  

            //we also need buttons to add and remove a person in the designer
            //now set up delegate methods for list view


            // 1. use the PeopleListView__KeyDown delegate
            this.peopleListView.KeyDown += new KeyEventHandler(PeopleListView__KeyDown); 
            //keydown handles enter on the list and the itemactivate is if we double click with mouse and it allows us to change an object

            //the this. is the field name in the form and then another . for the event handler then after the += its the new event then in () the name of the delegate**

            // 2. use the PeopleListView__ItemActivate delegate
            this.peopleListView.ItemActivate += new EventHandler(PeopleListView__ItemActivate);

            // 3. use the AddButton__Click delegate
            this.addButton.Click += new EventHandler(AddButton__Click);

            // 4. use the RemoveButton__Click delegate
            this.removeButton.Click += new EventHandler(RemoveButton__Click); //gives us our buttons in the bottom of the form

            // 5. use the ExitButton__Click delegate
            this.exitButton.Click += new EventHandler(ExitButton__Click);

            PaintListView(null); 
        }

        // notice that we are making PaintListView public so that it can be called from other classes
        public void PaintListView(string firstEmail)
        {
            // a ListView contains an Items field, which is an array of the rows in the ListView.
            // Items is an array of ListViewItem
            ListViewItem lvi = null;

            // ListViewItem contains the details of the first column in a row
            // and an array of ListViewSubItems for all additional columns in the row
            ListViewItem.ListViewSubItem lvsi = null;

            // we can also set the first ListViewItem to show in the list
            // which is preferable if a person was just edited, the list
            // should draw with that person at the top
            // the firstEmail function parameter is the email that should show at the top
            ListViewItem firstLVI = null;

            // nStartEl is the SortedList index element that the ListView should start with
            // based on firstEmail which was passed to our PaintListView() function
            // default to start with the first Person in the SortedList
            int nStartEl = 0;

            // clear the ListView Items
            this.peopleListView.Items.Clear();

            // lock the ListView to begin updating it
            this.peopleListView.BeginUpdate();

            // if an email was passed in for us to display as the first Person in the ListView
            if (firstEmail != null)
            {
                // fetch the index of the SortedList
                nStartEl = Globals.people.sortedList.IndexOfKey(firstEmail);
            }

            // use a cntr to check against nStartEl and to enable us to change the
            // background color of each row to make the SortedList more readable
            int lviCntr = 0;

            // loop through all people in the SortedList and insert them into the ListView
            // notice how we access the People class via the Globals class we created in PeopleAppGlobals
            foreach (KeyValuePair<string, Person> keyValuePair in Globals.people.sortedList)
            {
                // 6. declare a Person variable called thisPerson and set it to the current keyValuePair Value

                // 7. set lvi equal to a new ListViewItem object
                // this will be the new row we are adding to the ListView

                // alternate row color
                if (lviCntr % 2 == 0)
                {
                    lvi.BackColor = Color.LightBlue;
                }
                else
                {
                    lvi.BackColor = Color.Beige;
                }

                // 8. lvi.Text is the text that shows in the first column of the row
                // set it equal to the person's name

                // since the email address is the key into the SortedList
                // let's save that in the general purpose Tag field

                // 9. all additional columns are stored in the lvi.SubItems array
                // set lvsi equal to a new ListViewItem.ListViewSubItem object

                // 10. lvsi.Text is the text that shows in each subsequent column
                // set it equal to the person's email

                // add the ListViewSubItem to the lvi.SubItems array
                lvi.SubItems.Add(lvsi);

                // 11. we need another column to show the person's age
                // set lvsi equal to a new ListViewItem.ListViewSubItem object

                // 12. set lvsi.Text equal to the person's age
                // note that age is an int, so you will need to convert it to a string
                // you can use Convert.ToString(int) or the ToString() method of the integer

                // 13. add the ListViewSubItem to the lvi.SubItems array

                // 14. we need another column to show the person's License Id
                // set lvsi equal to a new ListViewItem.ListViewSubItem object

                // 15. set lvsi.Text equal to the person's License Id
                // note that license id is an int, so you will need to convert it to a string

                // 16. add the ListViewSubItem to the lvi.SubItems array

                // 17. we need another column to show the person's GPA if they are a Student
                // or Specialty if they are a Teacher
                // set lvsi equal to a new ListViewItem.ListViewSubItem object

                // 18. if thisPerson is a Student
                // refer to class code examples for how to use GetType() and typeof()
                // "is" checks for relationship
                //if( thisPerson is Student )
                // GetType() / typeof() checks for specific data type, not relationship
                {
                    // 19. declare a Student variable set to thisPerson cast as a (Student)

                    // 20. set lvsi.Text equal to the student's GPA
                    // note that gpa is a double, so you will need to convert it to a string
                }
                else
                {
                    // 21. declare a Teacher variable set to thisPerson cast as a (Teacher)

                    // 22. set lvsi.Text equal to the teacher's Specialty
                }

                // 23. add the ListViewSubItem to the lvi.SubItems array

                // if this row is the first email that should be shown
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
                this.peopleListView.Items.Add(lvi);

                // increment our row counter
                ++lviCntr;
            }

            // EndUpdate() unlocks the ListView
            this.peopleListView.EndUpdate();

            // set the Top ListViewItem of the list to show on the screen
            this.peopleListView.TopItem = firstLVI;
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
