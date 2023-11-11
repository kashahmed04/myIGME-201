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

//NEW NOTES
//when we do windows forms its all about the namespaces and we need to know the namepsaces to access the classes
//like we did with system.collections
//by default we sort by email 

namespace PeopleList
{
    public partial class PeopleListForm : Form, IListView
    {
        //*****************************************************************************************************************************GO OVER
        //which index our listview is sorted on and we start with the email column which is the first index*************
        private int columnIndex = 1;  // default to email column
        //ascending order of the column and descending would be negative 1*************
        private int columnSortOrder = 1; // default to ascending order
        //so as soon as we start the form it does the email by default and organizes it in a order**
        //*****************************************************************************************************************************GO OVER

        public PeopleListForm()
        {
            InitializeComponent();

            //Globals.AddPeopleSampleData(); dont need to call addpeoplesample data again in the listform because we did in the main form

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

            //SLACK QUESTIONS:
            //in order to access anything from the person class we need to include the peoplelib dll in our project because peoplelist needs
            //to know what the person class looks like because when we click on one of the items
            //like our item activate we need to fetch the person object from our sorted list and we use the indexer property to get the email key to get the person**
            //and we need to add the peoplelib and we have the have the using peoplelib directive otherwise we would have to use peoplelib.person
            //which gives us access to those class definitions to access the indexer property

            //we always make windows forms because windows controls are more generic containers which we dont learn about 
            //and when we create a windows forms application we select the windows forms app .NET framework and
            //it starts with a windows form by defult when we make the file 
            //and it names it form 1 and gives us the template code to write our app
            //if we want to create a form dll we use the windows forms control library and what it creates for our first control is a user control
            //so we want to use a dll to display forms within a parent form**
            //always choose windows forms to create dll and the windows forms control library and not use the control and add a form to our project**

            //we can create a project that has an executable and if we do windows forms app that creates an executable file and it can only run itself
            //and if we want to add to our executable (more modules) then we need to create dll files and in our solution we have 
            //windowspeopleapp which is our windows forms app and peoplelist is a windows forms control library because its a dll then it lets
            //us call peoplelist from an executable and windowspeopleapp in the main creates a new peoplelistform class the peoplelistform
            //is defined in the peoplelist project which is a windows forms control library 
            //when we create windows forms control library we dont get a form we get a user control and we dont know how to use those
            //so we need to add a form to it and now we havea  form and now we can use it and now on our form we can add our controls
            //windows control makes our code modular and if we each have a dll we are writing and one executable and 5 dlls we can each work on our projecy
            //seperately (modular means so we can work independently as much as possible)
            //so we create dlls for the different parts of our application

            //for the interface IListView in the peopleappglobals so it could be accessible across our whole project because peopleappglobals stores
            //all of our data and is accessible everywhere since we referecnced it everywhere like peoplelistform and personeditform
            //and by defining the interface its able to be accessed across the application
            //in order to have other classes to have access to the paintlistview we made personlistform inherit the listview so its accessible everywhere and the
            //interface has access to the paintlistview method**
            //in our personedit form when we click ok we want to update the list with the updated person with the data of the person we jsut edited 
            //we know that the owner is the peoplelistform and we want to call the paintlistview for the details
            //to use the form itself to call the method then we do
            //we have to cast the listview because owner is a form and its above IListView and owner is a peoplelistform but that inherits from form class
            //so owner has been set to a form type so we have to cast it because form is less generic than IListView 

            //the owner is the parent form which is the peoplelistform**
            //PeopleListForm(name of class) personListForm = (PeopleListForm)this.owner;
            //personListForm.PaintListView;
            //we get erros because personeditform does not know what a personlistform is and in order to have access to that class in personeditform
            //we have to add personlistform reference to the personedit form
            //and right click on solution exploerer then go to dependencies and peoplelist depends on edit person dll 
            //and it needs to know the form its going to create when we select a person but now we make edit person depend on peoplelist because
            //in order to call paintlist view using the peoplelistform class it will rquire
            //people list to be compiled first then it will create a circular dependency (we cant have 2 modules depend on each other so thats
            //why we use an interface)**
            //perosonlistform already depends on personedit form and we cant have personeditform depend on personlist form (circular depencdency)**
            //we dont have depencdecy with interface and it only needs to knwo that whatever class owner is inherits from that interface
            //and .NET takes care of all of that for us and all that the interface says is that we have access to this method
            //if there was no circular dependency we could have used personedit form variable but we would have had to add a reference
            //to the class and the using statement

            //*****************************************************************************************************************************GO OVER

            //how high are forms when we need to cast (how do we know when to cast)
            //are forms right below objects or where are they in the hierarchy**

            //so windows forms is the main executable where we put our projects together and the windows control
            //is where the dll's will be and those are the things that will be added on to the main form for functionality**

            //we want to execute our new code to sort our list on that column by setting up an event handler on the column click event**********
            //is it one click or double for the column and does it matter where on the column we click**
            this.peopleListView.ColumnClick += new ColumnClickEventHandler(PeopleListView__ColumnClick);

            //we want to update the column appearence and whatever column is sorted on it will show a diamond based on which column is sorted on rahter in a or d order****
            UpdateColumnAppearance(columnIndex);

            PaintListView(null);
            //*****************************************************************************************************************************GO OVER
        }

        //*****************************************************************************************************************************GO OVER
        //go over all below*******

        //which column is sorted on is the column index in the class defintion above and columnsortorder is a or d order (-1 for d and 1 for a )
        //and the listview contorl (only??)** has
        //a column click event so we have it so when the click on the column in our method below if its the same column we are sorting on
        //then we want to reverse it (plus or minus 1) otherwise they clicked on a new column then we want to set our column index to which column we are indexing on
        //and the sort order which is ascending by default*********

        //our lv contorl in the columnclick method has the listview item sorter and it has a class that defines
        //how to sort the columns and the requirement for the class*********
        //is the compare method that compares the items as we move on in the columns and the Icomparer interfcae****
        //and we need to associate a class object with our column sorter in the people**
        //listview method then sort**
        //the list then added a method to put the dismaonds to show which is being sorted**

        //whenever we want to sort on a listview we need the class "class ListViewItemComparer : IComparer" with that exact signature with the interafce
        //that contains a constructor to take in the values of the current column and the order we want to sort on from when we call it in the people
        //listview item sorter then we also want to have a compare method to compare each thing in the column and do a or d order based on the columnindex
        //that was passed in from the peoplelistview__columnclick method (when we call it we do e.column to represent the column thats clicked then the order to sort it on
        //based on if the column was clicked once before then we do the oppossite sort a or d or if they clicked on it the first time (the else statement
        //then we want to set the sort order to 1 (ascending) then set the index column to sort on)**(for the first if statement when its selected again for the row
        //it knows it was selected again because the first time (else statement)
        //it set the index to the column we clicked on (the e.column) then it goes to the if statement to see if the current column selected equals the
        //columnindex that was stored from the elese statement and if it did
        //that means we just change the order again but in the oppossite dierection (a or d)***********
        //then after that we do lv.sort() because**
        //then we call the updatecolumn appearence with the 1 or -1 for ascesnidn for descednign order for the arrows**

        //whats required all the time for sorting a column in terms of the class**

        //and the default is the email column to a order so basically when the program first runs it does the email in the default a order**

        private void PeopleListView__ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListView lv = (ListView)sender;

            if( e.Column == columnIndex) //e.column is built in and gets the column that we are indexing on (the one we clicked on)**
            {
                columnSortOrder *= -1; //if the column that we clicked on was the same as our column index which we set in the else
                //then we reverse the oritenaton**
            }
            else
            {
                columnIndex = e.Column; //set the current column we are indexing on if we did not have it selected already**
                columnSortOrder = 1; //set it to 1 by default because above we had manipulated the sortorder so we have to set it back when we are on a new column**
            }

            // need to include the System.Collections namespace
            //defines what to use for sorted the columns in the listview and we need to pass a class defintiion that defines that sorting logic
            //so we have the class below for it and now we want to create a new object to sort the columns*****
            lv.ListViewItemSorter = new ListViewItemComparer(e.Column, columnSortOrder); //could we have also put columnIndex because its equal to e.column**
            //lsitview item sorter is a prop. that tells the listview how to sort the columns
            //and its defined as taking in a Icomparer interface and we need to create class that inherits from icompaerer

            lv.Sort(); //sorts our list and puts it on the list based on our column (it knows to sort by the class we made how??)**

            //call this after they have clicked on the header and everything has been sorted so we can display the diomand shape on the header**
            UpdateColumnAppearance(columnIndex);
        }

        private void UpdateColumnAppearance(int column)
        {
            //takes an index of the column that we are now sorting on******
            foreach (ColumnHeader columnHeader in this.peopleListView.Columns)
            {
                columnHeader.Text = columnHeader.Text.Replace(" ▲", "").Replace(" ▼", ""); //goes through all the columns and resets them if they had an
                                                                                           //arrow to not having one**
                //if its a order then we show up diamond otherwise we do down arrow for d order
            }//go through all columns of our listvieww and for each of those we want to set the column header with null characters****
            //this goes through all of the columnheaders only not the column entries themselves**

            //if the column order is 1 set the up arrow otherwise the down arrow****

            string arrow = (columnSortOrder == 1) ? " ▲" : " ▼";
            //then we set the text of our column we are currentyl sorting on to the arrow (adds it as a suffix to the etxt in that column)*******
            //how does it know what columns to do it on since its not in the loop**
           
            //add the arrow to the column we sort 
            this.peopleListView.Columns[column].Text += arrow; //for that specific column we index by in the listview (the index we passed in) set the arrow
            //if its a plus one up arrow for a order or if its minus one a down arrow for a order****
            //does it put it at the top of the column (the header) by defult how does it know where to put it**
            //we then add the arrow to the text in the column in the listview based on the column we indexed from the whole list view**
        }

        class ListViewItemComparer : IComparer //built in interface and requires us to implement a method that compares two objects**
            //the column click also requires us to have this class if we want to sort by column (what else??)**
            //IComparerer is in the systems namespace so we need to include it in our code and by default its systems.collectiongens.genric (child namespace) which
            //is a subspace of the systems.collections so we have to include this parent namespace so now it works**

            //class needs to have the column we are sorting on and if its a or d order from the call in the peolplelistview column click method
            //and the class has access to those and the construcor briings in the values from the class call then puts it in the class so we can use it
            
        {
            private int columnIndex;
            private int sortOrder;

            public ListViewItemComparer(int column, int order) //we have to initialize our passed in values we passed in within
                                                               //the constructor so they are accessible within the
                //class otherwise we won't be able to use them (main point of constructor)**
            {
                columnIndex = column;
                sortOrder = order;
            }



            //compare method that gets called by lv.sort() (this is what calls the method)
            //to comapre all items in list and we tell is how to compare it 
            //and we compare the text in eaech column in the current column index which we passed in the constrcutro
            //and we multilpe the result by the sort order and if its 1 its a order if its -1 then its d order
            //there is no default sort and we have to make our own class to set up the item sort and if we just do lv.sort() is does not
            //do anything and it sorted by the email address because our paintlistview is going in alphabetical order
            //through our sorted list by email address thats why the email is only sorted

            public int Compare(object x, object y)
            {
                ListViewItem itemX = (ListViewItem)x; //how does it know to use the compare method with the things from the column if we don't specifally tell it 
                //to call this method when we created the instance** (is it because we made a variable for the class that does the sort and now when we 
                //call lv.sort in the peoplelist method
                //it does it based on the class??)**(is this always the case if we want to do custom sorting or can there be a defualt)**

                //we cast our 2 column values that we want to sort as a listviewitem and we cast it because we are casting objects and objects
                //are the highest type in c#**
                //we do the item and not subitems becuase**
                ListViewItem itemY = (ListViewItem)y;

                if( itemX == null || itemY == null )
                {
                    return 0; //it skips over the values that are null
                    //null items wont show up in list 
                    //and if item x is a null then there will be no subitems of it because x and y are the 
                    //email and the subitems are the columns after that representing that specific person
                    //the listviewitem is the column we clicked on and when we called lv.sort it looks at every row in our listview
                    //and it looks at every row in listview and compare each row with another to see which row is the lowest
                    //value and it needs to access 2 different rows and the rows are the person object itself and their things
                    //but when we get the subitems of the columnindex thats when we start sorting the things in that specific column
                    //which is the subitems of the listviewitem
                }

                //if they aboth arent null we grab the text property from those two items which are the text or that current column***********
                //our listviewitems contains our main column array and our subitems array is contained within the listviewitems (listviewitem?? or just our
                //listview in general) and it contains the additonal colum data*****
                //how does it know not to compare heading with something from the listviewitem up above**

                //here subitems of 0 is the name column
                //so it gets each item from the subitems which is the name if the name column was selected
                //and the listview item is all the columns of the person
                //easier because it puts all the items as the subitems
                string textX = itemX.SubItems[columnIndex].Text; //this gets our 2 items from the column and then we return
                //the compare method called with those 2 items from the list times the sort order rather a or d order**
                string textY = itemY.SubItems[columnIndex].Text;
                //but for the pinatlistview then the listviewitm is the name and the other information for the person and the subitems if everything else in those columns
                //when we created listview the listview only contained the name column and now each aditonal column was a subitem but after we are done creating it
                //it moved the first column into the subitems 

                //does this keep callign itself until it reaches the end of the list and it starts from the top by default right**
                //when we initiallaly enter the class does it basically set our 2 first items for the column then at the end we call the compare then comprees then it does
                //that over and over and calls itself to sort the next 2 items when we go back ti these above 2 lines**


                //now we compare these two using the string.Compare method()*********
                 //comapres the two strings then muktiplying it by sort order
                //and its -1 is x is less than y and 1 is x is greater than y then we sort by a or d and its based on whether x is greater than or less than y and
                //its from things that were greater than or less than our things from our list (basically it always determines what to do based on the first item and the
                //sortorder)**
                //what does the lv.sort() do in our method when we create a new instance of the class**
                return string.Compare(textX, textY) * sortOrder; //does this return one comparison at a time then puts that on the top or bottom based on the order**
                                                                 //comapres the two strings then muktiplying it by sort order**
            }
        }

        //the columns property order has nothing to do with the order on the form and the order on the form is by the displayIndex not just moving around
        //the blocks for the index
        //the order of columns is displayed by displayindex
        //for each column we can set width and alignedment and order it displays in 

        //person is an absrtac class so we cant create a person object (instabce) we can have a pointer though for the student or teacher objects
        //which are children of the person class(we can
        //create instances of it because its not abstract)**

        private void ExitButton__Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AddButton__Click(object sender, EventArgs e)
        {
            Person newPerson = new Student();

            this.Enabled = false;


            new PersonEditForm(newPerson, this); //we have to pass the current form (epoplelistform)into**
                                                 //the personedit form because we want to make this specific form we pass in
                                                 //the owner
            //form as well as center the personedit form to the parent which is the peoplelistform (we have to pass peoplelistform so
            //it knows thats the owner which is reffered to as the parent when we do the center to parent)**
        }
        // e.SuppressKeyPress = true; for keypressed and handled for the events (e) basically it checks at the end of the function only 
        //not a loop and it makes sure that if its false windows displays it on the form but if its true it does not because we did not display it ourselves
        //(is there a way to display it ourselves)*********
        //*****************************************************************************************************************************GO OVER
        private void PeopleListView__KeyDown(object sender, KeyEventArgs e)
        {
            ListView lv = (ListView)sender;

            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                try
                //*****************************************************************************************************************************GO OVER
                {
                    string email = (string)lv.SelectedItems[0].Tag;
                    //string email = lv.SelectedItems[0].Tag.ToString();
                    //when we do this.peopleListView.Items.Add(lvi); in the paintlist view it adds our person and the email stored in the lvi.tag so basically 
                    //we can access the email because the items in the items.add above here has an array of the rows as well as the selected row and what else**
                    //and basically we get the selecteditems at index 0 because we only have 1 person we can select at a time since
                    //multiselect it turned off and for that person thats selected we get their tag which is their email we stored for each person**\
                    //we couldnt have accessed person without the .tag because we needed the email key to retriveve the person**
                    //for the person we currently have selected get their email**

                    //will we not deal with multiselect in this class**
                    //we then have to cast it as a person because it was in an array format so we need
                    //to actually get the person object based on the email*******

                    Person person = null;
                    person = Globals.people[email]; //cant we set this directly equal to the Person person or should we make it null first then pass it in**
                    

                    this.Enabled = false;
                    //we have to pass in this current form into personedit form so it knwos what to make the owner and so we can center to parent so it knows
                    //what the parent is****
                    PersonEditForm epf = new PersonEditForm(person, this);
                    epf.Show();
                    //*****************************************************************************************************************************GO OVER
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

        //*****************************************************************************************************************************GO OVER
        // notice that we are making PaintListView public so that it can be called from other classes why do we need an interface
        //so if a method or variable in a class is public if we add a reference to that class in another class we can access the public method or varible
        //within that other class** 
        //with classname or variable name.method(para.)** (same for its a pubic class scoped variable or method??)*****
        //but for private variables (class scoped and not) (and things in the constructor?? or if its in the constructor with public we can still access it?? how??)**
        //we can only acess it within the class and nowerhe else even though there is a reference**
        //*****************************************************************************************************************************GO OVER
        public void PaintListView(string firstEmail)
        {
            // a ListView contains an Items field, which is an array of the rows in the ListView.
            // Items is an array of ListViewItem
            ListViewItem lvi = null;

            // ListViewItem contains the details of the first column in a row
            // and an array of ListViewSubItems for all additional columns in the row

            //*****************************************************************************************************************************GO OVER
            //for the listviewitem its 1 array for column details(names) then another for the subitems are for each addtional columns and
            //in the column array we have an array for the details of the person
            //(the columns after the name column for that specific person (basically the row)**
            //*****************************************************************************************************************************GO OVER
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

            //*****************************************************************************************************************************GO OVER
            // clear the ListView Items**
            this.peopleListView.Items.Clear();

            // lock the ListView to begin updating it**
            this.peopleListView.BeginUpdate();
            //do we lock to prevent user from doing any edits as we repaint the listview (like pressing a person, or add, or edit, or exit)**
            //*****************************************************************************************************************************GO OVER
            // if an email was passed in for us to display as the first Person in the ListView
            if (firstEmail != null)
            {
                // fetch the index of the SortedList
                //*****************************************************************************************************************************GO OVER
                //we can index a list and it would return the index for where that key value pair is stored
                //*****************************************************************************************************************************GO OVER
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
                //*****************************************************************************************************************************GO OVER
                //which one is preferable**
                //*****************************************************************************************************************************GO OVER
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
            //*****************************************************************************************************************************GO OVER

            // EndUpdate() unlocks the ListView**
            this.peopleListView.EndUpdate();

            // set the Top ListViewItem of the list to show on the screen
            //why do we want to do this after we unlock the listview**
            this.peopleListView.TopItem = firstLVI;
            //*****************************************************************************************************************************GO OVER
        }

        // handle clicking the Remove button
        private void RemoveButton__Click(object sender, EventArgs e)
        {
            try
            {
                string email;

                //*****************************************************************************************************************************GO OVER
                // 24. The ListView has a SelectedItems array field
                // which is the array of ListViewItems which are currently selected
                // Since we have MultiSelect set to false, only one row can be selected
                // so we only check SelectedItems[0]
                // In line #107 above we set the lvi.Tag = the email
                // Set email = the email address saved in the Tag field for SelectedItems[0]
                // Since Tag is a System.Object,
                // use the ToString() method to convert the object to a string
                email = this.peopleListView.SelectedItems[0].Tag.ToString(); //we can access the selecteditems prop. because its part of the peoplelistview
                //and theres no scope for it within classes or anything its just part of the listview and built in**
                //*****************************************************************************************************************************GO OVER

                // 25. if email is not equal to null
                if ( email != null )
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
