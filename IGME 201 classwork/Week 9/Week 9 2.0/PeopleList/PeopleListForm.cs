using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PeopleAppGlobals; //list of people (student and teachers) and courses**
using PeopleLib; //the student and teacher  and person objects**
using EditPerson; //personeditform?? 


//the wdinwos forms contorl document has a summary of all of the controls we will be using this semester 
//we need to have courselib and peoplelib (here specifiacally or in peopleappglobals)**
//because they define the student,teacher,and course,and courses class we need for our program
//we checked to make sure if a field was empty and numeric fields were numeric for the editperson.dll
//we will refer to people list steps to create a form
//for the courses**


//I am still confused on why we have to create a reference to peoplelib because we already have our person being accessed in the peopleappglobals 
//is it because in peeoplelistview__keydown we have to point to a a new person and make it equal to the person
//we pressed enter on when we got their email from the list which returned a person object then create a new form with that person we are on so we can edit them??**

//we had to have a using statement for peoplelib in personlistform because
//we wanted to create a variable (a reference) to the Person class in PeopleListView__KeyDown right?********************************************(1.0)

//how do we know whether to make a windows control.vs.a windows form?************************(2.0)

//so basically when we add a control the Name field is the name we access it with in the code and the text is what shows up on the form right**
//we have a class which is the form, the prop. which is the control but within that prop., we have fields within it to name our control and customize it**

//tag gets or sets with whatever control we use with the . notation**


//In terms of the interface IListView we had created, I just wanted to know why we specifically created it within the PeopleAppGlobals file?
//Was it because it was accessible to both personeditform and personlistform so it was kind of like a bridge between the two files
//so that personeditform could have access to personlistform?************************(3.0)

//We had to make personlistform inherit the interface so the interface was able to use that specific method (paintlistview()) within personlistform right?
//Do we have to do these with all classes that have the same method as the interface so the interface can access those methods?******(4.0)

//I am confused on why we needed an interface and had to cast it when we accessed paintlistview() in personeditform because couldnt we just have had a reference to
//personlistform in personeditform and do PeopleListForm.paintlistview() by itself?*****************(5.0)

//when we have references to other classes we usually just use the class name.whatever method or variable we want to access right we don't access by the namespace
//name within the code unless it's the using statement?************(6.0)

//in terms of making a class definition, I know we would want to do that because then our varaibles would only be accessible within the constructor but
//would the class defined variables be accessible within other files if we had a reference to them via a using statement and the class.whatever we want to access
//in the code, whereas the things we define in the constructor would not be accessible in other files regardless?************(7.0)

//In terms of interfaces I was still a bit confused so basically within the interfaces we have to have the fucntionName(); or functionName(para.); (depends on method signature)
//right and not just functionName; to reference a function?*****************(8.0)

//When we created a new person the only thing that defaults is the person being a student right the rest it blank?*******(9.0)

//by default windows forms attaches a forms inheritence to our cs files that have the desinger within it right it basically says there
//a form attached to this cs file right?**************(10.0)

//the this. in the form refers to the current form right? Like if we did this. in personedit form it would reference personeditform right
//not the parent file which is personlistform?*************(11.0)

//we wanted to make an interface available to the whole application and if we want accessible to the whole application we want it in a global class
//and we define it in the globals because we know its shared across everythign and we want to call pintalistview method for the people list so we chanfe people list
//to inherit that interface and so now anywhere that has acccess to the peoplelistform they can now call the paintlistview with the interface because the personeditform
//can have access to it so we can repaint the list view and move the person to the top (after we finish editing the person)**
//so basically since the personeditform inherits peopleappglobals we can use the Ilistview interface there but why do we put it here does it have something to do**
//with the this.owner** what does this.owner do**
//we can have para. in the interface (its the method signature so we have to copy it as is)**
//(how comes person editform does not inherit instead because it needs to be inherited there)**


//peoplelist when we add a new person or edit and existing a person it calls editperson and it calls it with the person that was the existing person that was
//selectoed or create the new person and everything is blank initially except that its a student by default

//basically we use the interhitence here of the interface so the interface has access to the paintlistview since its defined here and since personeditform
//has a reference to peopleappglobals when we call the paintlistview via the interface from personeditform then it goes to the peoplelistform from there
//because the interface has access because of the inheritence in the people listfomr***********************(26) and we have to cast the interface to the owner form
//which is peoplelistform (why because if peoplelistform inherits from the listview cant we just call it idriectly from this.owner)********************(27)
//basically peopleappglobals is like a bridge from personedit form to peoplelistform to get to the paintlistview method*******(28)

namespace PeopleList
{
    public partial class PeopleListForm : Form, IListView //does it automatically inherit form or do we put it ourselves what does it mean and when do we know to put it**
                                                //we need partial in all of our classes because its a windows forms and it retuqires it to be partial
                                                //bcause its designer extends the code defintion and it's shared code between the designer and our .cs file**
                                                //by default windows forms attaches a forms inheritence to our cs files that have the desinger within it**************(14)

        //we can now use the interface to call the paintlistview to redraw itself from the email address that the person just edited** (why do we have an inheritence of it i
        //this form
       
    {
       

        public PeopleListForm()
        {
            InitializeComponent(); //always goes on the top and it initializes all of our things we put in our forms like buttons,etc. and puts it in the form1desginer.cs
                                    //file that we don't interact with and it's usually hidden** and we put all code below this 

            //Globals.AddPeopleSampleData(); //remove it because its done in the main already 

            // 1. use the PeopleListView__KeyDown delegate
            this.peopleListView.KeyDown += new KeyEventHandler(PeopleListView__KeyDown);

            // 2. use the PeopleListView__ItemActivate delegate
            this.peopleListView.ItemActivate += new EventHandler(PeopleListView__ItemActivate);
            //the object name refers to whatever we put in the name section in the properties right for that control and the text is what shows up on the form
            //when we press enter or double click we can do it anywhere right but it has to be in the same
            //row as the person we want to edit on (yes it can be anywhere on that row and we can select that person)
            //fullrow select basically allows us to select the whole application when we double click but we can have it not select the whole row
            //and it would let us select one cell of the listview

            // 3. use the AddButton__Click delegate
            this.addButton.Click += new EventHandler(AddButton__Click); 

            //the click method of a button control takes a delegate type of an event handler and the method signature returns void and need to have our standard method name
            //which is the contorl name we set in the Name in the properties window then __ then the event name and it takes objeect sender and event args

            // 4. use the RemoveButton__Click delegate
            this.removeButton.Click += new EventHandler(RemoveButton__Click);

            // 5. use the ExitButton__Click delegate
            this.exitButton.Click += new EventHandler(ExitButton__Click);

            //the this. refers to the form1.designer (the current instance of the class)(for the peoplelistform this. refers to the grid form
            //and the this. in personedit form refers to the pop up tab to edit a person in the designer)
            //the objectName is the field (yes)
            //name in the we set in the "Name" field within (yes)
            //the form property and then another . for the event then after the += its the
            //new eventhandler or another event handler then in () the name of the delegate method which is the control name in pascalcase__eventname (yes)

            //the control itself is the property and the things we can edit in the property are also properties (have get and set functions)      


            PaintListView(null); //why do we pass null (we pass null because it starts at the top then when we first start creating the list)
        }
     
        private void AddButton__Click(object sender, EventArgs e)
        {
            Person newPerson = new Student(); //add a new student by default in our form
                                                
            this.Enabled = false; //cant edit more than one person at the same time so this disables the main form (its confusing to do so we just disable it)
            //in visual studio we can enable multiple at the same time though like we did with properties,etc.
            new PersonEditForm(newPerson, this); //add the new peroson to the form so we can now edit them and it goes to the constructor
                                                 //and we need to see if its a student or teacher and we want the combobox to say student ot teacher
                                                 //based on the student or teacher and once we change the combobox it will call our delegate method (theselecetedindex
                                                 //method)(as soon as we change the index as soon as we enter the form and detect then it goes to the index method
                                                 //and change the textboxes based on what object it is)
                                                 //we pass in this which is the current form and it allows us enable this form at the end as well
                                                 //as set the owner of the current form and the this.owner and we set the personeditform equal to the editform
                                                 //and say that the owner of the editform is the listform and it sets a relationship between them
                                                 //and now we can center the current form personedit form to our parent form
                                                 //and it allows us to do stuff to the main form within our personeditform so that when we 
                                                 //go back to the list it has those changes by default the this.owner is null (there is no owner initially and
                                                 //we have to set it and the first form in our application will never have a parent and the main form is the one we run)
        }

        private void ExitButton__Click(object sender, EventArgs e)
        {
            Application.Exit(); //this closes the main form because it uses applcation.exit()
        }

        private void PeopleListView__KeyDown(object sender, KeyEventArgs e)

            //the sender is the listview we pressed enter on so we cast that
            //and use that list view and we index that to 0 because we can only select one thing at a time because we have multiseclt off
             
            //when we have this.show in the constructor it knows to show the form because we decalre a new instance of an object like we did
            //for personeditform right? And for application.run we dont
            //need the .show for it because it's the main form*****************(12.0)
                                                                          
        {
            ListView lv = (ListView)sender;
            //explicitly cast because its an object(higher than anything in c#)**
            //key code is the key they pressed and we check if they pressed enter on ourlistview which is anywhere on our list of people**
         

            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; 

                //handled property for the keypressed and the keydown had supresskeypress (true = windows should ignore it an we handle)
                //this is like the handled and basically it tells us that the developer wants to handle it instead of windows
                //if they press enter we dont want windows to do anything with that key so we suppress it

                try
                {
                    //get the email from the list view itme
                    //whichever item is current selected and multiple can be when we set multi selct was set to true in the peopleslistview (if it was true)
                    //but we only allow user to edit one person at a time so we set it to false (will we ever use mutiselect and make it equal to true)**
                    //we only access the 0th index for the current item we are in (why its the name in our listview))**
                    //and the tag is what we are accessing which is the email and we make it so**
                    //cast to string because tag is an object??**

                    //how does it know to get an email what is this doing**
                    string email = (string)lv.SelectedItems[0].Tag;
                    //lv is our listview and anytime there is an item selected on our listview it will be in our selected items array and its
                    //the selecteditems array we built in our paintlistview and we added each line (row) to the items array at the very end and it also
                    //has a selected items array and it contains the currently selected items and in our listview control this.personlistviw.items(lvi)
                    //multiselect was eqaul to false and
                    //we can select one person at a time and basically the selected items of 0 will be the first item we selected and we attached the email to the
                    //tag prop. of each item and when we press enter it gets the email (selected items = 1 array and 1 array for all of our items)
                    // lvi.Tag = thisPerson.email; was the email
                    //we add lvi to the items array and items is all of our people and the lvi.email has the current email stored in it

                    //so when we press enter then we get the current item we press enter on it gets that email and does what we need to do
                    //and items also has an array of the selected items and another array of all the items in the listview
                    //as well so we use that selected array and get the email from it 
                    //and the lv represents the listview so we can get the person from the listview that we added to the people listview thats
                    ////what gets referenced in the para. in the items.add and the current row thats selected from it, it gets that email that we stored in the
                    //lvi.tag because thats what we stored (lvi) when we added the this.peopleListView.Items.Add(lvi)***************************(1)

                    //this.peopleListView.Items.Add(lvi);
                    //the user may press enter and the list is empty so we have to have it in a try catch and there could be no items selected)
                    //string email = lv.SelectedItems[0].Tag.ToString();

                    //we do this in a try because there could be no item selected and somebody deleted our list of people and theres nothing in our list so we
                    //make sure (how do we make sure is it just when theres nothing the catch will run but theres nothign in it)** (how can it tell if a list is empty
                    //do we have a case for that**)

                    Person person = null; //person object pointer??**
                    //if the email is not there it wont crash because its in a try catch
                    person = Globals.people[email]; //goes to the globals then goes to the people
                    //list we had created them references the value which is the person based on the email because sorted list stores key value pair**


                    //we now want to disable the people ls=ist form as soon as the enter key is pressed and we have the email stored
                    //and we got the person based on the email (mina form in designer)
                    //so we set this so we can set enabled to false
                    //and prevents us from editing two people at once
                    //and disbales the rest of the document**** (once we choose a
                    //person to edit we disable the form then we create a new perdoneditform and show it while the main form is disabled to allow
                    //someeone to edit a person but not more than 1 person because the main form is disabled**
                    this.Enabled = false;

                    PersonEditForm epf = new PersonEditForm(person, this); //we can do the new without the varaible and it still does the .show() only if the .show()
                                                                            //is in the constructor(we can do both in the constructor and with a variable if we want)
                                                                            //we can also do .hide() to hide the form
                    //epf.Show(); (shows in the parent form**)
                    //why remove the show here because it's not in the constructor (the this.show() usually goes in constrcutor do we can create a new
                    //instance rather than the variable then the variable.show() like we have here**

                    //above creates edit person form and here we want to show it and it handles all of the events against it like blank or non numeric values entered** 
                    //when we create forms we need to show them and have them process the user interaction with them which we did in the personeditform (when they interact
                    //with the form to edit)**

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
                //then we set enabled to false so that we can disbale the rest of the form to edit
                //one person then we make the new form for that person based on
                //the perosn objecy and this which is the current parent form (the desingner) so we can show the form on the parent application**

                Person person = null;

                person = Globals.people[email]; //cant we just put the Globals.people[email] instead of the null above or is this more preffereable**

                this.Enabled = false;

                // only use this method if the Show() is at the end of the constructor! (this.show or just show() in the constructor)**
                new PersonEditForm(person, this);
            }
            catch
            {

            }
        }


        // notice that we are making PaintListView public so that it can be called from other classes'
        //why do we need to call it from the other classes (we need to call it from personeditform so that when we edit a person their data will be saved)(when we add
        //a new person because we deleted the person we wanted to edit then added the new edited person in the paintlistview)**

        //accepts the first email to show in the list view and the first
        //time we come in we want to start from
        //the first email in our people list and set null as the first email (why??)**
        //items prop. in peeopleslistview and every items prop. has a list
        //view item and its each row thats in the list view (where)****
        //the text (shows up in first column of row), subitems (stores data
        //for each additional column in the row so if we had 5 columns in our list view
        //we will have 1 text and 4 sublist view items for the rows??)**
        //each row will consist of 1 person from our people list in our form**
        public void PaintListView(string firstEmail) //pass in first email as a string

        {
            // a ListView contains an Items field, which is an array of the rows in the ListView.** (contains the whole row for that person in an array not just the name)**
            // Items is an array of ListViewItem**
            ListViewItem lvi = null; //this gives us the first thing in the row which is the name??**
                                     //this gives us an array of all the names or everything within that row??(which contorl is it usually in (listview prop.)**

            // ListViewItem contains the details of the first column in a row (name)
            // and an array of ListViewSubItems for all additional columns in the row (are these both seperate arrays)**(how would it look)**(how does this work)**
            //it gets the listview which is the name then sets the subitems for that secific name**
            //which are the rest of the items that go along with the object we are currently on**
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
            //if we put the email here how would it add the items at the top??**(go over)**
            ListViewItem firstLVI = null;

            // nStartEl is the SortedList index element that the ListView should start with
            // based on firstEmail which was passed to our PaintListView() function
            // default to start with the first Person in the SortedList
            //index it should start at based on the email that was passed in**
            int nStartEl = 0; 

            //this basically gets the index of the person based on their email within our sortedlist?? (we can index in a sortedlist??)**
            //(if email was passed in then we can check the index down below in the if statement)**

            // clear the ListView Items
            //why do we want to clear in the whole form if theres nothing there inititally**
            this.peopleListView.Items.Clear();
            //clear the whole form to repaint the list if someone was edited*************(13.0)

            //clear all items in our list view so its empty before we populate then line below we lock it 
            //because we may have multiple processes accessing the list
            //view at the same time and if one process is updating the list already,
            //then another process is being done as well there could be
            //a conflict because 2 things are being done at one time 
            //so we want to do one at a time (like a queue)**

            // lock the ListView to begin updating it (we want to lock the list so the user does not have access to edit the list while
            // its being repainted??)***************(14.0)
            this.peopleListView.BeginUpdate();

            // if an email was passed in for us to display as the first Person in the ListView (basically when we edit a person this makes it so that person shows
            //on top of the list when we refresh the page??)**
            if (firstEmail != null) //what if its not null and it goes through here and the email was not valid**
            {
                // fetch the index of the SortedList
                nStartEl = Globals.people.sortedList.IndexOfKey(firstEmail);
                //indexofkey returns index of that email
                //tells us the index based on the key for indexofkey within the sortedlist**
                //only used with sortedlists?? why would we use it cant we just user the indexer property I though sorted lists did not allow indexing**
                //why do we specificlaly need the index here**

                //this gets the person index to put it at the top of the list
            }

            // use a cntr to check against nStartEl and to enable us to change the
            // background color of each row to make the SortedList more readable
            int lviCntr = 0; //change color of rows as we go through

            // loop through all people in the SortedList and insert them into the ListView
            // notice how we access the People class via the Globals class we created in PeopleAppGlobals

            //insert each person into the list view and we are
            //accessing our sorted list based on our globals then the people
            //variable object which was the list then access the lust from
            //the people and each entry ni our list is a key value pair and the
            //key is email and the object is a peson**
            foreach (KeyValuePair<string, Person> keyValuePair in Globals.people.sortedList)
                //when we iterate through when we reach the one we want to start on in the conditional then we set that listviewitem to be selected and focussed
                //on and set a reference to it (those are two prop. the selected and focus on)** and at the end we set the item we have added
            {
                // 6. declare a Person variable called thisPerson and set it to the current keyValuePair Value
                Person thisPerson = keyValuePair.Value;
                //variable that points to a value of that type of object** (not a new instance)**

                // 7. set lvi equal to a new ListViewItem object
                // this will be the new row we are adding to the ListView (adds the whole row or only one column entry for the name**)
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
                // set it equal to the person's name**
                lvi.Text = thisPerson.name;

                // since the email address is the key into the SortedList
                // let's save that in the general purpose Tag field

                //store each key that we are currently adding into our listview (current email of that person**)
                //so we can access it easier (the email address is the key)**
                //save it in the tag field for the current list item (could we have used another varible
                //other than the tag and how many tags can we have)**(when do we usually use tags)**
                //when we select a row from our list we will immediately know email address (how)**
                lvi.Tag = thisPerson.email; //tag is basically a property (it had get and set) then right**
                //and its usually used for lists to get and set right??**

                // 9. all additional columns are stored in the lvi.SubItems array
                // set lvsi equal to a new ListViewItem.ListViewSubItem object
                //create our first listview sub item which is the daat from the rest of the columns other than
                //then name which was the main listviewitem we defined right above here**
                //could we have also intizlized up there instead of null why did we set it to null**
                lvsi = new ListViewItem.ListViewSubItem(); //this adds to the current listviewitem array with the subitems??**

                // 10. lvsi.Text is the text that shows in each subsequent column
                // set it equal to the person's email
                lvsi.Text = thisPerson.email; //this is basically the second column and we are setting
                //it as a sub item as a new column (how does it know to make a column)**

                // add the ListViewSubItem to the lvi.SubItems array
                //add the email column to the subiteems (array??)**
                lvi.SubItems.Add(lvsi); //why do we do lvi. here instead of lvsi is it because we are adding the subitem to the array we created
                                        //listviwitem array??(how would it look)**

                // 11. we need another column to show the person's age
                // set lvsi equal to a new ListViewItem.ListViewSubItem object
                //(follow these same steps to populate the list view for the people(the columns))**
                //and add the columns for the people) what would we do if we wanted to do rows instead of columns**
                //(oppossite like filling out name instead for each person then email**
                lvsi = new ListViewItem.ListViewSubItem(); //holds remainder of the column data**

                // 12. set lvsi.Text equal to the person's age
                // note that age is an int, so you will need to convert it to a string
                // you can use Convert.ToString(int) or the ToString() method of the integer
                //so basically anything that has to show on form should be a string like how it was
                //with console**
                lvsi.Text = thisPerson.age.ToString();

                // 13. add the ListViewSubItem to the lvi.SubItems array
                //since we are using the same variable once we add it do we override it with a new**
                //listview sub item then set the text for whatever column then add it then repeat the process**
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
                //its more safer to use gettype and typeof right to get exact relationship to check is thisPerson is the student for example**
                //if we used gettype or typeof on rectangle and shape it would be false since they were not the same but if it was an "is" it would be true**
                //because htye are simialr**
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
                
                //we pass in null because we want to start from the first person in our list and target that first person on our list (make it highlighted)
                //when we set nstartelement if its null it stays as 0 and does not enter condtional above and we just have to check
                //if the indexelement we are on is equal to the lviCntr (counts every item in the list to alternate row color) then we target
                //that element for the first email that should be shown
                if (nStartEl == lviCntr) //the first time we go through the loop
                    //if we get our start element of our person based on the key then we have that equal lvi counter which has all of the people in our list
                    //and if those are equal we want to select that and highlight it as we scroll down

                    //the first time we go through when its null it says nstartel is now equal to lviCntr and sets that as the fist personfrom the .TopItem in
                    //firstLVI thats how it knows to do the first item as for the rest of the things in the rows it knows to go through the rest
                    //of the sorted list because of the foreach loop and it looks at each person in our sortedlist and thats what makes it go to the next item
                    //lvi = new ListViewItem() adds a new row for each person name same for the subitems for the other columns
                    //and we store their details in the listviewitem object
                    //and after we have filled it we now add it to the form (the this.peoplelistview.items.Add(lvi) and the items in it is each row and each
                    //entry in that row is 1 element in an array of the items which contains a bunch of people objects)(our listview has 5 columns
                    //and each addtional columns are listviewsubitems and for each additinoal subitem we create a lvsi (new listviewsubitem() and store the
                    //corresponding column we are on)

                    //for each listviewitem (the first column) we save their email in the tag prop. (the lvi
                    //contains the rest of the columns as well and the subitems is an array of all the rest of the columns so
                    //we need to add them one at a time then we created a subitem and set the text to the email for example for the second column
                    //then add the subitem to the lvi (listview item))(all of the columns are in the listviewitem but in the subitems its an array
                    //of the aditional columns)(and the subitem and listviewitem is an array of the current row)
                   
                    //(name will be in the lvi.Text field and the
                    //email will be in the lvi.SubItems[0].text and age will be the same thing as before but index 1 and each addtional column is a subitem array element
                    //but its still in the listview item and the listviewitem is the whole row)(each time we go through and create a new listviewitem and subitem for
                    //each thing we want to add in the listview)(and the subitems is also an array of the subitems for the row)(every row has its own array)

                    //listviewitem has an array of rows (going down for rows) the first row has a list view item and the list view item has whats stored in the
                    //first column and the other things within the row other than the first thing is the subitem 
                    //there are two arrays and the first array is the list of each row (if we have 10 people then we have 10 rows and each row has an array
                    //of the additional columns within each person (each person has their own array of columns and the array is contained within the persons
                    //listviewitem))(each item has an array within it like for each row item it contains the array of the columns)

                    //so basically for each person stored in which is the "name" in the
                    //listview thats the array but within each person it stores the rows (the 1 person data)
                    //for that person which is the rest of their items (listsubitem)
                    //and basically each row is the name for the listviewitem and the rest of the things in that row are the subitems and these
                    //are all contained in one array***************************(15.0)

                    //and now we can use the email to go through the sorted list to index by their email and get the person object based on that 
                    //ex. people[email]
                {
                    // set this row as being currently selected
                    lvi.Selected = true;

                    // set this ListViewItem to be focused upon (otherwise the current focus defaults to the first in the list)
                    lvi.Focused = true;

                    // save a reference to this ListViewItem object (we set a reference to the current person we have put into the list based on the email)??**
                    firstLVI = lvi;
                } //we set nstartel to lviCntr so thats how it knows to target that item to go on the top 

                // we completed 1 row of the ListView
                // we can finally add this ListViewItem to the Items array
                //why do we do this. here is it because we are now actually adding to the deisgner itself
                //is that what this. means**
                this.peopleListView.Items.Add(lvi); //so basically this is saying in the main form in the peoplelist add this row of
                                                    //values for one person(what does the Items do)**

                // increment our row counter (after each person it alternates from blue to beige**)
                ++lviCntr;
            }

            //in editperson when we click ok to edit person in sorted list its going to save the person back into the sorted list with the Globals.
            //and its going to repaint the list view with the current person we have edited and we pass in their email to have them be the first person to show
            //when we repaint the form
            //and when we enable the personedit form it goes back to people list then will handle everything we put into that person

            // EndUpdate() unlocks the ListView
            this.peopleListView.EndUpdate(); 
            //we unlock the form once we edit the whole list (repaint it)********(16.0)

            // set the Top ListViewItem of the list to show on the screen
            this.peopleListView.TopItem = firstLVI; //based on the email that was stored for the current person because it was equal to the para. in the condtional**
            //we make that the top item in our listview**
            //this sets the current person we had made to be the first thing on the list in our whole
            //form because of this.**
            //how does it know to get the specific value from the condtional above**

            //we set the top item as the fistLVI and it makes the person display at the top of the page
        }

        // handle clicking the Remove button
        private void RemoveButton__Click(object sender, EventArgs e)
        {
            try
            {
                //we have a string email thats saved to the tag for the seclted item
                //so we access the email from the peoplelistview selected items tag and turn it into a string**
                string email;

                // 24. The ListView has a SelectedItems array field
                // which is the array of ListViewItems which are currently selected
                // Since we have MultiSelect set to false, only one row can be selected
                // so we only check SelectedItems[0]
                // In line #107 above we set the lvi.Tag = the email
                // Set email = the email address saved in the Tag field for SelectedItems[0]
                // Since Tag is a System.Object,
                // use the ToString() method to convert the object to a string
                email = this.peopleListView.SelectedItems[0].Tag.ToString(); //we make this a string so it will conver the object to our string for us
                                                                             //we have to make it a string because the indexer property takes in the string
                                                                             //which is the email

                // 25. if email is not equal to null
                if (email != null)
                {
                    // 26. remove the entry from Globals.people associated with the email address
                    Globals.people.Remove(email); //pass in email address to remove and now we need to repaint the listview and remove that person we removed**
                    //is .remove built in and it basically just removes it from the list and we repaint the list without that entry now**

                    //remove is built in for sorted lists 
                }
            }
            catch
            {

            }

            // 27. repaint the ListView passing null as the email address to start from the top of the SortedList
            PaintListView(null); //we want to redo the list once we remove the person
        }

    }
}

