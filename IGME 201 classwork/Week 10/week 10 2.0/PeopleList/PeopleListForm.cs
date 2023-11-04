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
using EditPerson;

// needed for sorting ListView by column
using System.Collections;



namespace PeopleList
{
    public partial class PeopleListForm : Form, IListView
    {

        //which index our listview is sorted on and we start with the email column which is the first index*************
        private int columnIndex = 1;  // default to email column
        //ascending order of the column and descending would be negative 1*************
        private int columnSortOrder = 1; // default to ascending order

        public PeopleListForm()
        {
            InitializeComponent();

            Globals.AddPeopleSampleData();

            // 1. use the PeopleListView__KeyDown delegate
            this.peopleListView.KeyDown += new KeyEventHandler(PeopleListView__KeyDown);

            // 2. use the PeopleListView__ItemActivate delegate
            this.peopleListView.ItemActivate += new EventHandler(PeopleListView__ItemActivate);

            // 3. use the AddButton__Click delegate
            this.addButton.Click += new EventHandler(AddButton__Click);

            // 4. use the RemoveButton__Click delegate
            this.removeButton.Click += new EventHandler(RemoveButton__Click);

            // 5. use the ExitButton__Click delegate
            this.exitButton.Click += new EventHandler(ExitButton__Click);


            //we want to execute our new code to sort our list on that column by setting up an event handler on the column click event**********
            this.peopleListView.ColumnClick += new ColumnClickEventHandler(PeopleListView__ColumnClick);

            //we want to update the column appearence and whatever column is sorted on it will show a diamond based on which column is sorted on rahter in a or d order****
            UpdateColumnAppearance(columnIndex);

            PaintListView(null);
        }


        //go over all below*******

        //which column is sorted on which is the column index in the class defintion and a or d order (-1 for d and 1 for a ) in class def. for the sortorder variable******
        //and the listview contorl has
        //a column click event so we have it so when the click on the column in our method below if its the same column we are sorting on
        //then we want to reverse it (plus or minus 1) otherwise they clicked on a new column then we want to set our column index to which column we are indexing on
        //and the sort order which is ascending by default*********

        //our lv contorl has the listview item sorter and it has a class that defines how to sort the columns and the requirement for the class*********
        //is the compare method that compares the items as we move on in the columns and we need to associate a class object with our column sorter in the people
        //listview method then sort
        //the list then added a method to put the dismaonds to show which is being sorted

        //whenever we want to sort on a listview we need the class class ListViewItemComparer : IComparer with that exact signature with the interafce
        //that contains a constructor to take in the values of the current column and the order we want to sort on from when we call it in the people
        //listview item sorter then we also want to have a compare method to compare each thing in the column and do a or d order based on the columnindex
        //that was passed in from the peoplelistview__columnclick method (when we call if we do e.column to represent the column thats clicked then the order to sort it on
        //based on if the column was clicked once before then we do the oppossite sort a or d or if they clicked on it the first time (the else statement
        //then we want to set the sort order to 1 (ascending) then set the index column to sort on)**(for the first if statement when its selected again for the row
        //it knows it was selected again because the first time (else statement)
        //it set the index to the column we clicked on (the e.column) then it goes to the if statement to see if the current column selected equals the
        //columnindex that was stored from the elese statement and if it did
        //that means we just change the order again but in the oppossite dierection (a or d)***********
        //then after that we do lv.sort() because**
        //then we call the updatecolumn appearence with the 1 or -1 for ascesnidn for descednign order for the arrows**

        //and the default is the email column to a order

        private void PeopleListView__ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListView lv = (ListView)sender;

            if( e.Column == columnIndex)
            {
                columnSortOrder *= -1;
            }
            else
            {
                columnIndex = e.Column;
                columnSortOrder = 1;
            }

            // need to include the System.Collections namespace
            //defines what to use for sorted the columns in the listview and we need to pass a class defintiion that defines that sorting logic
            //so we have the class below for it and now we want to create a new object to sort the columns*****
            lv.ListViewItemSorter = new ListViewItemComparer(e.Column, columnSortOrder);
            lv.Sort(); //sorts our list and puts it on the list based on our column (how does it know what to sort by)**

            //call this after they have clicked on the header and everything has been sorted**
            UpdateColumnAppearance(columnIndex);
        }

        private void UpdateColumnAppearance(int column)
        {
            //takes an index of the column that we are now sorting on******
            foreach (ColumnHeader columnHeader in this.peopleListView.Columns)
            {
                columnHeader.Text = columnHeader.Text.Replace(" ▲", "").Replace(" ▼", ""); //why so we do replace even though there is no check for the index until
                //down below wouldnt the text be changed without a check**
                //if its a order then we show up diamond otherwise we do down arrow for d order
            }//go through all columns of our listvieww and for each of those we want to set the column header with null characters****

            //if the column order is 1 set the up arrow otherwise the down array****

            string arrow = (columnSortOrder == 1) ? " ▲" : " ▼";
            //then we set the text of our column we are currentyl sorting on to the arrow (adds it as a suffix to the etxt in that column)*******

            this.peopleListView.Columns[column].Text += arrow; //for that specific column we index by in the listview (the index we passed in) set the arrow
            //if its a plus one up arrow for a order or if its minus one a down arrow for a order****
        }

        class ListViewItemComparer : IComparer //built in interface and requires us to implement a method that compares two objects
        {
            private int columnIndex;
            private int sortOrder;

            public ListViewItemComparer(int column, int order)
            {
                columnIndex = column;
                sortOrder = order;
            }

            public int Compare(object x, object y)
            {
                ListViewItem itemX = (ListViewItem)x;
                ListViewItem itemY = (ListViewItem)y;

                if( itemX == null || itemY == null )
                {
                    return 0; //there could be null items??**
                }

                //if they aboth arent null we grab the text property from those two items which are the***********
                //out listview items contains our main column and our subitems array it contains the additonal colum data*****

                string textX = itemX.SubItems[columnIndex].Text;
                string textY = itemY.SubItems[columnIndex].Text;


                //now we compare these two using the string.Compare method()*********
                 //comapres the two strings then muktiplying it by sort order
                //and its -1 is x is less than y and 1 is x is greater than y then we sort by a or d and its based on whether x is greater than or less than y and
                //its from things that were greater than or less than our things from our list (basically it always determines what to do based on the first item and the
                //sortorder)**
                return string.Compare(textX, textY) * sortOrder; //does this return one comparison at a time then puts that on the top or bottom based on the order**
                                                                 //comapres the two strings then muktiplying it by sort order**
            }
        }

        //the columns property order has nothing to do with the order on the form and the order on the form is by the displayIndex not just moving around
        //the blocks for the index
        //the order of columns is displayed by displayindex
        //for each column we can set width and alignedment and order it displays in 

        //person is an absrtac class so we cant create a person object (instabce) we can have a pointer though**

        private void ExitButton__Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AddButton__Click(object sender, EventArgs e)
        {
            Person newPerson = new Student();

            this.Enabled = false;

            new PersonEditForm(newPerson, this);
        }

        private void PeopleListView__KeyDown(object sender, KeyEventArgs e)
        {
            ListView lv = (ListView)sender;

            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                try
                {
                    string email = (string)lv.SelectedItems[0].Tag;
                    //string email = lv.SelectedItems[0].Tag.ToString();

                    Person person = null;
                    person = Globals.people[email]; //cant we set this directly equal to the Person person or should we make it null first then pass it in**

                    this.Enabled = false;

                    PersonEditForm epf = new PersonEditForm(person, this);
                    epf.Show();
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
                string email = (string)lv.SelectedItems[0].Tag;

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

            // clear the ListView Items**
            this.peopleListView.Items.Clear();

            // lock the ListView to begin updating it**
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
                Person thisPerson = keyValuePair.Value;

                // 7. set lvi equal to a new ListViewItem object
                // this will be the new row we are adding to the ListView
                lvi = new ListViewItem();

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
                lvi.Text = thisPerson.name;

                // since the email address is the key into the SortedList
                // let's save that in the general purpose Tag field
                lvi.Tag = thisPerson.email;

                // 9. all additional columns are stored in the lvi.SubItems array
                // set lvsi equal to a new ListViewItem.ListViewSubItem object
                lvsi = new ListViewItem.ListViewSubItem();

                // 10. lvsi.Text is the text that shows in each subsequent column
                // set it equal to the person's email
                lvsi.Text = thisPerson.email;

                // add the ListViewSubItem to the lvi.SubItems array
                lvi.SubItems.Add(lvsi);

                // 11. we need another column to show the person's age
                // set lvsi equal to a new ListViewItem.ListViewSubItem object
                lvsi = new ListViewItem.ListViewSubItem();

                // 12. set lvsi.Text equal to the person's age
                // note that age is an int, so you will need to convert it to a string
                // you can use Convert.ToString(int) or the ToString() method of the integer
                lvsi.Text = thisPerson.age.ToString();

                // 13. add the ListViewSubItem to the lvi.SubItems array
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
                if (thisPerson.GetType() == typeof(Student))
                {
                    // 19. declare a Student variable set to thisPerson cast as a (Student)
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
                if( lviCntr == nStartEl )
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

            // EndUpdate() unlocks the ListView**
            this.peopleListView.EndUpdate();

            // set the Top ListViewItem of the list to show on the screen
            //why do we want to do this after we unlock the listview**
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
                email = this.peopleListView.SelectedItems[0].Tag.ToString(); //we can access the selecteditems prop. because its part of the peoplelistview
                //and theres no scope for it within classes or anything its just part of the listview**

                // 25. if email is not equal to null
                if( email != null )
                {
                    // 26. remove the entry from Globals.people associated with the email address
                    Globals.people.Remove(email);
                }
            }
            catch
            {

            }

            // 27. repaint the ListView passing null as the email address to start from the top of the SortedList
            PaintListView(null);
        }

    }
}
