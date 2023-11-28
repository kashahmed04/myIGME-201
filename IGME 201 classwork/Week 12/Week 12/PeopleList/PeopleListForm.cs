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

    //do a webbrowser navigate for the gif in the web brwoser if they answered everything correctly 
{
    //why dont we need a person class variable here but we do in person edit form**

    //EXAM*****************************************
    //we should scale our computer to 100 percent not 125 in our computers settings for the exam right (yes)
    //how to make it so that if one textbox is clicked the timer starts and does not stop or reset when they go onto the next one for exam (use variable for it)
    //we need to have a flag to know the timer has been started or we could check to see what value of progress bar is and each time the timer ticks down
    //we reduce value of progress bar so we could check if the timer is at 3 or 4 minutes and if the value is 240 then we can assume the timer has not started yet
    //and once the timer starts its going to count down and we subtract 1 from the value of the timer and we would have if progress bar value is 240 then start
    //the timer and it will only do it once 
    //(what is interval and total time for timer and what we decrease by)
    //the interval defines when the timer elapses and it defined how long a tick is and every time a tick is every one second and in our tick method
    //we will have a status strip and in the statuc strip theres a dropdown to add progress bar and for the progress bar we set the maximum value for 240 seconds for 4
    //minutes and theres a value which is the current value it is and we want to start the value at 240 seconds for 4 minutes (we can also adjust the size in properties
    //the timer is milliseconds and we want the timer to tick every 1 second and we want the preogress bar to go down by one second and we want it to go from
    //4 minutes to 0 
    //our progress bar is going to countdown in seconds and we want to define the maximum time they have which is 4 minutes which is 240 seconds for the meximum value and
    //set the value for our tool strip progress bar value to be the maximum value in the contrustor 
    //then each second the timer ticks we want to subtract 1 from the tool strip value thats what makes the value go down (we do --toolstripprogressbar1.value in the timer
    //tick immediately when we enter the method)
    //so when we are in the checkchanged when we change their link to the web brwoser would we target the web browser we named in our designer and do the
    //navigate to their page and does it matter if we put it before or after the web browser document completed method for the loop through the anchor tags (does not matter)
    //when we click on their certain party does it default ti being the first one or do we have to set it ourselves
    //for the tooltip is it for every textbox or only some because the overlap is not next to the text boxes (its for all textboxes)
    //(and how long do we set the tooltip for) or can we
    //do it in designer for textboxes or would it be the this.show then the string then put it within the groupbox itself or would we put the textbox then the coordinates (we
    //have to do it in designer)
    //is there anything specical other than the exit button being unlocked and the timer being paused when the user enters everything correct (gif shows up in web brwoser)
    //can we set all textboxes to be defult as 0 in designer or so you want it in the code (designer)
    //user can only enter numbers no decimals, letters, or special characters in textboxes
    //use the this.homepageWebBrowser.ScriptErrorsSuppressed = true;  for the web browser control 
    //and do web browser document completeed to target
    //anchor tags and their tooltip
    //is there a specific naming convention for non-windows forms controls like the threading method for example within a windows form**

    //every texbox has a tooltip (use the this.show for it)
    


    //when the timer ran out nothing happened except timer resetting and texboxes values being reset to 0 
    //reset timer when timer runs out and only the textboxes reset to 0 (would we have to target all textboxes when the timer is 0 or is there
    //a way to go through all of them at once from the groupbox******* (same for other controls to access all of them)******

    //

    //error provider needed right for the texbxes if they are empty

    /*
     * 
            public void TxtBoxEmpty__Validating(object sender, CancelEventArgs e)
            {
                TextBox tb = (TextBox)sender;

                if (tb.Text.Length == 0) //do this for all textboxes and an or (||) if not the textbox tag (for whatever president it is we will set the tag
                                         //for their control)(also have to cast the tag as a string to check if it's their number not an int. because
                                         //we are in the texbox which only accepts a string)(we can set the president tag in the constructor via the textlabel or radiobutton)
                {
                    this.errorProvider1.SetError(tb, "This field cannot be empty.");
                    e.Cancel = true; //e.cancel is for every single textbox that gets passed in right for causes validation******
                    tb.Tag = false; //all have to be true for causes vaidation for exit button to be clicked and use the lebel or radio button as a tag
                                    //for the presidents number** In validate all we can then check if all of textboxes are checked then unlock the 
                                    //exit button like we did in personeditform and we can stop the timer there (pause it)*******

    //if we define a tag in the constructor its still available outside the constructor since its assocaited with a control and a contorl
    //is global to the form class right** (not other classes though unless its defined in the class)**
                }
                else
                {
                    this.errorProvider1.SetError(tb, null); //else if (textbox tag) then we want to do causes validation to be false and exit**
                    e.Cancel = false;
                    tb.Tag = true;
                }

                ValidateAll();
            }

    //how to check if all textboxes full can we use the textbox tag then do validation then for the president name (their label) have their tag as their president
    number then check if that to strning is in the texbox for causes validation for example the control in the deisnger.tag casted as a string
    would that work since the control is only defined in the constructor or could set it in another method that invloves the radio buttons
    and have that be the tag to access it here to check or how would that work because of scope*****
     */
    public partial class PeopleListForm : Form, IListView
    {
        private int columnIndex = 1;  // default to email column
        private int columnSortOrder = 1; // default to ascending order

        public PeopleListForm()
        {
            InitializeComponent();

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

            this.peopleListView.ColumnClick += new ColumnClickEventHandler(PeopleListView__ColumnClick);

            UpdateColumnAppearance(columnIndex); //why do we want to update the column appearence when we first enter is it because
            //a column that had an arrow on the heading may have been saved before so we want to clear that? What about the sort of that column
            //will that also reset when we do paintlistview below**

            PaintListView(null);
        }

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
            lv.ListViewItemSorter = new ListViewItemComparer(e.Column, columnSortOrder);
            lv.Sort();

            UpdateColumnAppearance(columnIndex);
        }

        private void UpdateColumnAppearance(int column)
        {
            foreach(ColumnHeader columnHeader in this.peopleListView.Columns)
            {
                columnHeader.Text = columnHeader.Text.Replace(" ▲", "").Replace(" ▼", "");
            }

            string arrow = (columnSortOrder == 1) ? " ▲" : " ▼";
            this.peopleListView.Columns[column].Text += arrow;
        }

        class ListViewItemComparer : IComparer
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
                    return 0;
                }

                string textX = itemX.SubItems[columnIndex].Text;
                string textY = itemY.SubItems[columnIndex].Text;

                return string.Compare(textX, textY) * sortOrder;
            }
        }

        private void ExitButton__Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AddButton__Click(object sender, EventArgs e)
        {
            Person newPerson = new Student();

            this.Enabled = false;

            //this.showdialouge(); instead of the above line and just make the new personeditform instance**

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
                    person = Globals.people[email];

                    this.Enabled = false;

                    PersonEditForm epf = new PersonEditForm(person, this);
                    epf.Show();
                    //could have done epf.ShowDialouge(); instead if we take out the this.Enabled??**
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
                email = this.peopleListView.SelectedItems[0].Tag.ToString();

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
