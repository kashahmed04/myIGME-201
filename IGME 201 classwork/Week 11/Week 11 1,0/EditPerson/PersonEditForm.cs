﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PeopleLib;
using CourseLib;
using PeopleAppGlobals;
using System.Runtime.CompilerServices;


/*
 * Exam:
 * Presidents executable and we have to recreate 
 *has radio buttons and 16 preseidents and when we change the president the portrait changes and when we hover over it then it increases in size
 *and textbox and if we hover over it asks which number presdient and the group box on the right is the webbrowser
 *control and it loads wikepedia article for the presdident and we can read which number president to fill it in
 *once we start typing in a textbox the progressbar starts counting down (3 minutes) to entrer all of the numbers of the presidents 
 *if we type wrong number and try to leave we get an error and cant leave the textbox and if we
 *fill in all correctly we get exit button enabled and we get a prompt that we did it correctly
 *and there is not x or minimize button or anything
 *we can also filter the presidents based on their party
 *we have to list every control in the app and psuedocode for the bahvior of those controls and what event handlers we have to define and what it has
 *to do and make it as detailed as possible because in step 2 we are going to recreate the executable and we 
 *want to disable the page preview feature by hovering over a link in the browser control and when we hover a link it comes up with a tooltip (president shuch for president)
 *and we make the page preview disabled that way and we intercept the anchor tags and make it with our own title**
 *
 *question 3 is to create a user interface that will make the user as miserable as possible and there are requirements for 5 types of controls and at least
 *1 thread (like with discord tutorial and it needs to interact with one of the controls to change appearence of one of the controls)**
 *we need to have 3 different windows or forms that communicate with each other and we need to have theme and that crashing is not part
 *of a bad interface and there has to be a way to go to main application and kill it 
 *
 *go over the threading and the third questions as well as the timing lines for the presidents application and wikepedia page preview disabled**\
 *how many controls should there be exactly with the unit test or is it only a range**
 *for number 3 we should have 1 main form the 2 dlls right for the 3 windows**
 */

/*
 a;l courseslistview is the list of all of our courses in the sorted list and when they enter text in the searchtextbox we want to filter 
 all of the courses if its the coursecode or the desceription in the search box and when we doulbe click or press etner in all courses we want to add
that course in the top listview but if its already in the top listview when we press enter or double click then we remove it from the selexted list
*/



/*
 * when they click the schedule tab we want to load the schedule they have and its a css grid page so we now want to write that code
 */

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
            InitializeComponent();

            //in terms of setting the registry do we usually put it directly after initalize component to have the most recent broswer implentation

            
            //set registry setting so the applicaition uses a more recent browser implementation** (always put it after intializecompetment)**
            try
            {
                // Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.2; WOW64; Trident / 7.0; .NET4.0C; .NET4.0E; .NET CLR 2.0.50727; .NET CLR 3.0.30729; .NET CLR 3.5.30729; wbx 1.0.0)
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(
                    @"SOFTWARE\\WOW6432Node\\Microsoft\\Internet Explorer\\MAIN\\FeatureControl\\FEATURE_BROWSER_EMULATION",
                    true);
                key.SetValue(Application.ExecutablePath.Replace(Application.StartupPath + "\\", ""), 12001, Microsoft.Win32.RegistryValueKind.DWord);
                key.Close();
            }
            catch
            {

            }


            //foreach (Control control in this.Controls)
            foreach (Control control in this.detailsTabPage.Controls)
            {
                // use Tag property to indicate valid state
                control.Tag = false;
            }

            if( parentForm != null ) 
            {
                this.Owner = parentForm;
                this.CenterToParent();
            }

            this.formPerson = person;


            // all form configuration should be done first
            // before working with the form's data
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

            this.editPersonTabControl.SelectedIndexChanged += new EventHandler(EditPersonTabControl__SelectedIndexChanged);

            this.typeComboBox.SelectedIndexChanged += new EventHandler(TypeComboBox__SelectedIndexChanged);

            this.cancelButton.Click += new EventHandler(CancelButton__Click);
            this.okButton.Click += new EventHandler(OkButton__Click);

            this.greatRadioButton.CheckedChanged += new EventHandler(RatingRadioButton__CheckedChanged);
            this.okRadioButton.CheckedChanged += new EventHandler(RatingRadioButton__CheckedChanged);
            this.mehRadioButton.CheckedChanged += new EventHandler(RatingRadioButton__CheckedChanged);

            this.photoPictureBox.Click += new EventHandler(PhotoPictureBox__Click);

            this.birthDateTimePicker.ValueChanged += new EventHandler(BirthDateTimePicker__ValueChanged);

            this.homepageWebBrowser.ScriptErrorsSuppressed = true;

            this.FormClosing += new FormClosingEventHandler(PersonEditForm__FormClosing);

            this.allCoursesListView.ItemActivate += new EventHandler(AllCoursesListView__ItemActivate);
            this.allCoursesListView.KeyDown += new KeyEventHandler(AllCoursesListView__KeyDown);
            this.courseSearchTextBox.TextChanged += new EventHandler(CourseSearchTextBox__TextChanged); 
            //each time they search something in textbox we want to redraw allcourseslistview filtered on whatever is in tetbox
            //we know to use generic eventhandler or a specific one based one based on when we hover over the event after the this.control.

            // after all contols are configured then we can manipulate the data

            this.nameTextBox.Text = person.name;
            this.emailTextBox.Text = person.email;
            this.ageTextBox.Text = person.age.ToString();
            this.licTextBox.Text = person.LicenseId.ToString();

           

            //we need to trap when the content is finished rendernig on the screen 
            //everything in windows is multi processing and the broswer does its own thing while the rest of the tabs are running**
            //document completeed event tells us when the document is complete rendergin
            //we use this deleagate type to handle this**
            //once the document is completeed loading we can change th content of the html elements and style, etc.**
            this.homepageWebBrowser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(HomepageWebBrowser__DocumentCompleted);

            if( person.name == "" )
            {
                person.eFavoriteFood = EFavoriteFood.pizza;
            }
            else
            {
                if( person.dateOfBirth > this.birthDateTimePicker.MinDate)
                {
                    this.birthDateTimePicker.Value = person.dateOfBirth;
                }

                this.homepageTextBox.Text = person.homePageURL;
            }

            this.birthDateTimePicker.Value = this.birthDateTimePicker.MinDate;

            switch( person.eFavoriteFood)
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

            this.photoPictureBox.ImageLocation = person.photoPath;


            if( person.GetType() == typeof(Student) )
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

                if( person.name == "")
                {
                    teacher.eRating = ERating.ok;
                }

                switch( teacher.eRating )
                {
                    case ERating.great:
                        this.greatRadioButton.Checked = true;
                        break;
                    case ERating.ok:
                        this.okRadioButton.Checked = true;
                        break;
                    case ERating.meh:
                        this.mehRadioButton.Checked = true;
                        break;
                }
            }


            this.Show();
        }
        //want to populate the students schedule tab page with css grid and if we left click on a class then we can remove it or we can edit it
        //and we can edit description and enter review of the course but first we want to do gomepage and show some dom manipulation
        //if we enter a persons homepage and when we hover over the h2 element it toggles over the kitten and puppy age and theres a link
        //when we press on the link to take them to kittens of puppys.com 
        //if we look at the source we can see that its a generic source and we have h tags and p tags 
        //and none of the source matches whats on the page because our application changes the content itself (in terms of colors
        //and images,etc.)** we do DOM manipulation in c# now 

        private void HomepageWebBrowser__DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //object sender will be the web browser control that just completeed the rendering 
            //and we only want to do DOM manipulation if the title of our document is DOM-3 because thats what has the eexact structure we want to
            //manipulate
            WebBrowser wb = (WebBrowser)sender;
            if(wb.Document.Title == "DOM-3")
            {
                HtmlElement htmlElement; //the HtmlElement htmlElement let us target html elements to point to our docuemnts body tag while the 
                                         //HtmlElementCollection htmlElementCollection let us target the elements in the array by index when we did 
                                         //the get element by tag name right**
                                         //I was just a bit confused on the get elements by tag name. So basically I know it returns an array of all
                                         //of the tags with that specific name, but even if it was only 1 element did you say it would return an array still with that 1 item
                                         //in it**
                HtmlElementCollection htmlElementCollection; //list of the elements in our web browser

                //now we want to change the appearence of things on our page like text colors and text sizes,etc. (change the embedded css)
                htmlElement = wb.Document.Body; //So for htmlElement = wb.Document.Body; I know the wb gets us the web browser we are currently in and the body
                                                //gets us all the tags only in the body but why do we need the document in the middle**
                htmlElement.Style += "font-family: sans-serif; color: #a000a0;";

                //we have a method that will return ana array of html elements below and we get all of the hl elements
                //tag name always returns an array even if its one item
                htmlElementCollection = wb.Document.GetElementsByTagName("h1");
                htmlElement = htmlElementCollection[0]; //gets the first h1 (noly 1 int he array)

                htmlElement.InnerHtml = "My Kitten Page";

                htmlElement.MouseOver += new HtmlElementEventHandler(Example__H1__MouseOver); //name of delegate method is that they are only hanling example docuemnt
                //and only applies to h1 tags when we hover over the html elemtn which is the h1****

                //we have to set up an image on the page
                //we can create new elements in the code as well
                //first h2 to say meow and the second one to have a link to kittens.com and the third h2 is an empty string
                //get collection of h2 elements
                htmlElementCollection = wb.Document.GetElementsByTagName("h2");
                htmlElementCollection[0].InnerText = "Meow!";
                //I know the innertext sets the text of the element but in terms of the innterhtml does that set a tag within the tag we had in the collection 
                //(ex. when we got the secong h2 we basically put an a tag in the h2)**
                htmlElementCollection[1].InnerHtml = "<a href='http://www.kittens.com'>Kitties!</a>"; //copy from code*****
                htmlElementCollection[2].InnerText = "";

                //now we want to insert an image element by grabbing the last element that has an id of lastparagraph and 
                //we make the image the first child of that element
                //get elements by id returns only one element but are you saying if last paragraph has more elements within it then it would
                //still return the first element in that id**
                htmlElement = wb.Document.GetElementById("lastParagraph");
                //now we want to create an image element for the lastparagrpah id area
                HtmlElement htmlElement1 = wb.Document.CreateElement("img");
                htmlElement1.SetAttribute("src", "https://en.bcdn.biz/Images/2018/6/12/27565ee3-ffc0-4a4d-af63-ce8731b65f26.jpg"); //copy url and put here*****
                //we then set the src which is the link for the attribute within the image tag

                //for an image tag if we wanted to have an alt attribute how would we do that because in our img tag we only had an src**

                //for the tooltip we always want to have the title attribute and the text for that image but is there a tooltip property
                //in the designer and is that only used for images or other stuff too**

                //now we set the title for the image
                //we set the image to have a tooltip to say the thing down below
                //the title attribute for the image tag is a tooltip for when we hover over it
                htmlElement1.SetAttribute("title", "awwww");

                //is it prefferable to create new elements within our code and add from there or have an html already set up because we did both**

                //when we click the image we get the youtube link
                htmlElement1.Click += new HtmlElementEventHandler(Example_IMG_Click);

                //now we have to image element but we need to insert it in our document (we always do this for new html elements we create in our code)
                //insert the element in the beginning of the id element above (lastparagrpha) as the first child of that elemtn**
                //we can insert it at the end of the children in that id (beforeend) we can do it after begin which is the first child of the lement
                //we can insert it after the end which is the next following element but not the child of the id
                //or we can put it before the id element in its own seperate elemet**

                //why would we want to insert as the first child can we do it anywhere since it was empty or were there more things in the ID*

                //here we insert our new element into the DOM as the first child of the id
                htmlElement1.InsertAdjacentElement(HtmlElementInsertionOrientation.AfterBegin, htmlElement1);

                //we now create a footer element then we set the innerhtml of that footer(we can create new elements with the same variable woukdnt it get replaced**
                htmlElement1 = wb.Document.CreateElement("footer");

                htmlElement1.InnerHtml = "&copy;2023 <a href='http://www.nerdtherapy.org'>D. Schuh</a>"; //copy link from notes**

                //we now insert an element at the very end of the web broswer** by using the append child method
                wb.Document.Body.AppendChild(htmlElement1); //cant we just say htmlElement.AppendChild(htmlElement 1) in our delegate for when they web broswer loads
                                                            //because htmlElement is equal to wb.Document.Body in the begnning of the method but is it because it
                                                            //for overridden by the last paragrph element
                //why do we do wb. here cant we just say htmlElement since thats what we set it equal to up above or was that for something different**

            }
        }

        private void Example_IMG_Click(object sender, EventArgs e)
        {
            //we want to navigate to the youtube url when we click on the image of the kitten or dog?**
            this.homepageWebBrowser.Navigate("http://m.youtube.com/watch?v=oHg5SJYRHA0"); //pass in url*****
                //for the navigate we basically put in a link then when something happens it takes us there right but we are still within our browser
                //it does not open a new window or anything*
        }

        private void Example__H1__MouseOver(object sender, HtmlElementEventArgs e)
        {
            //this toggles between kitten and puppy when we toggle over the h1
            HtmlElement htmlElement = (HtmlElement)htmlElement;
            HtmlElementCollection htmlElementCollection;
            if(htmlElement.InnerText.ToLower().Contains("kitten")) //when we hover over and it currently includes kitten in all lowercase then then we change it 
                //to the puppy page but how does it know to target the h1 specifially because we did not specify anywhere?**
            {
                htmlElement.InnerText = "My Puppy Page"; //if its a puppy page we want to first h2 to say woof we want the second h2 to have a link to 
                //puppues.com 
                
                //this gets all the h2's from our docuemnt
                htmlElementCollection = this.homepageWebBrowser.Document.GetElementsByTagName("h2")
                htmlCollection[0].InnerText = "Woof!";
                htmlCollection[1].InnerText = "<a href='http://www.puppies.com'>Puppies!</a>"; //get anchor tag from code****
                
                //now get the image tag by getting the element collection and now get the image tags and theres only one
                //and we can access the previous image tag even though its in another method (same for all other elements that we create in another method??)**
                //the image click method will still work since we are using the same elemtn**

                //So I was confused when we were doing
                //the mouseover event because we created tags in the home page document completed method but
                //in our mouseover were you saying that if we created tags in another method we could use them in other methods and would not have to make a new one?**
            }
            else
            //copy original code and just change the innertext, change the h2's, set the meow and anchor tag and we dont need tog et last paragraph anymore and we need to
            //get image tag and change the source for that (copy from notes)
            
            //we need to reference the class varible for the this.homepagewebbrwoser instead of wb.docuemnt.
            //because****
            //and the htmlelement collection gets the array of the elements and we can index the elemtns and set the attributes of them??**
            {
                htmlElement.InnerText = "My Kitten Page";

                htmlElementCollection = this.homepageWebBrowser.Document.GetElementsByTagName("h2");
                htmlElementCollection[0].InnerText = "Meow!";
                htmlElementCollection[1].InnerHtml = "<a href='http://www.kittens.com'>Kitties!</a>";

                htmlElementCollection = this.homepageWebBrowser.Document.GetElementsByTagName("img");
                htmlElementCollection[0].SetAttribute("src", "https://en.bcdn.biz/Images/2018/6/12/27565ee3-ffc0-4a4d-af63-ce8731b65f26.jpg");
            }
        }

        private void CourseSearchTextBox__TextChanged(object sender, EventArgs e)
        {
            PaintListView(this.allCoursesListView);
            //this allows us to filter the textbox based on if the coursecode or description was in the textbox 
            //how does it know to filter all of the text and not just beginning letters*********
            //CHECK ANSWER****
        }

        private void AllCoursesListView__KeyDown(object sender, EventArgs e)
        {
            Course course;
            ListView lv = (ListView)sender;

            string courseCode = null;
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                courseCode = lv.SelectedItems[0].Tag.ToString();

                course = Globals.courses[courseCode]; //get the courseobject based on the corursecode

                ICourseList iCourseList = (ICourseList)formPerson; //get the person and point to their courselist


                //if its in their coursecode we remove it from their list of courses
                //otherwise we add it if they dont already have it within their list
                if (course != null)
                {
                    if (iCourseList.CourseList.Contains(course.courseCode))
                    {
                        iCourseList.CourseList.Remove(course.courseCode);
                    }
                    else
                    {
                        iCourseList.CourseList.Add(course.courseCode);
                    }
                }

                //we repaint the list with the student
                PaintListView(this.selectedCoursesLiew);

        }
            

        private void AllCoursesListView__ItemActivate(object sender, EventArgs e)
        {
            //this accounts for any key that is pressed so we want to only account for when they press enter
            //we dont want windows to process the enter key so we want to suppress the keypress because we handle it 
            Course course;
            ListView lv = (ListView)sender;

            string courseCode = null;

             
            e.SuppressKeyPress = true; //wouldnt we set it to false so it shows on the browser because if it was false
            //it shows on the broswer but if its true then it is not supposed to??** (for handled and suppresskeypress)

            courseCode = lv.SelectedItems[0].Tag.ToString();

            course = Globals.courses[courseCode]; //get the courseobject based on the corursecode

            ICourseList iCourseList = (ICourseList)formPerson; //get the person and point to their courselist

            if (course != null)
            //if its in their coursecode we remove it from their list of courses
            //otherwise we add it if they dont already have it within their list
            {
                if (iCourseList.CourseList.Contains(course.courseCode))
                {
                    iCourseList.CourseList.Remove(course.courseCode);
                }
                else
                {
                    iCourseList.CourseList.Add(course.courseCode);
                }

                //we repaint the list with the student
                PaintListView(this.selectedCoursesListView);
            }
                
        }

        private void PaintListView(ListView lv)
        {
            //lets us populate allcourseslistview or selctedlistview and we pass in the exact listview we are repainting**
            ListViewItem lvi = null;
            ListViewItem.ListViewSubItem lvsi = null;


            // 12. clear the listview items
            lv.Items.Clear();

            // 13. lock the listview to begin updating it
            lv.BeginUpdate();

            int lviCntr = 0;

            // 14. loop through all courses in Globals.courses.sortedList and insert them in the ListView
            foreach (KeyValuePair<string, Course> keyValuePair in Globals.courses.sortedList)
            {
                Course thisCourse = null;

                // 15. set thisCourse to the Value in the current keyValuePair
                thisCourse = keyValuePair.Value;


                //icourselist is defined in the courselib class and both of our teacher and students have the list of coursecodes which
                //is the reference in the interface**
                if (lv == selectedCoursesListView)
                {
                    ICourseList iCourseList = (ICourseList)formPerson;
                    //we need to cast because our object is more specific than the interface and the interface is the parent of the class
                    //and anything thats inherited that datatype needs to be casted because that object is more specific than the datatype of
                    //the targert**

                    if (!iCourseList.CourseList.Contains(thisCourse.courseCode))
                    {
                        //if the course is not in the list for the person then we skip the class and go back to the loop otherwise 
                        //we are filtering all courses based on the textbox for the searchbar**
                        continue;
                    }
                }
                else
                {
                    if (courseSearchTextBox.TextLength > 0)
                    {
                        if (!thisCourse.courseCode.Contains(courseSearchTextBox.Text) &&
                            !thisCourse.description.Contains(courseSearchTextBox.Text))
                        {
                            continue;
                        }
                    }
                }


                // 16. create a new ListViewItem named lvi
                lvi = new ListViewItem();

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
            }


            // 37. unlock the ListView since we are done updating the contents
            lv.EndUpdate();
        }


        private void PersonEditForm__FormClosing( object sender, FormClosingEventArgs e )
        {
            if( this.Owner != null)
            {
                this.Owner.Enabled = true;
            }
        }

        private void EditPersonTabControl__SelectedIndexChanged(object sender, EventArgs e)
        {
            TabControl tc = (TabControl)sender;

            if(tc.SelectedTab == this.detailsTabPage )
            {
                this.AcceptButton = this.okButton;
                this.CancelButton = this.cancelButton;
            }
            else if( tc.SelectedTab == this.homePageTabPage)
            {
                this.AcceptButton = null;
                this.CancelButton = null;

                this.homepageWebBrowser.Navigate(this.homepageTextBox.Text);
            }
            else if( tc.SelectedTab == this.coursesTabPage)
            {
                this.AcceptButton = null;
                this.CancelButton = null;

                PaintListView(this.allCoursesListView);
                PaintListView(this.selectedCoursesListView);
            }
            else if(tc.SelectedTab = this.scheduleTabPage)
            {
                    this.AcceptButton = null;
                    this.CancelButton = null;
                    this.scheduleWebBrowser.Navigate(); //get link to put grid on the webbrowser and its a browser control** (put in link from code)
                    //we have one row for hour of the day and for the columns we have one row for each day of the week 
                    //and the rest of the styles for the grid and how each cell is going to look in our grid then we define our buttons with each
                    //of the ids for each day of the week and the hour**


            }

            }

        private void BirthDateTimePicker__ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker dtp = (DateTimePicker)sender;

            if( dtp.Value == dtp.MinDate )
            {
                dtp.CustomFormat = " ";
            }
            else
            {
                dtp.CustomFormat = "MMM d, yyyy";
            }
        }

        private void PhotoPictureBox__Click(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;

            if( this.openFileDialog.ShowDialog() == DialogResult.OK )
            {
                pb.ImageLocation = this.openFileDialog.FileName;
            }
        }

        private void RatingRadioButton__CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;

            if( rb.Checked )
            {
                if( rb == this.greatRadioButton)
                {
                    this.ratingLabel.Text = "sign me up";
                }

                if( rb == this.okRadioButton)
                {
                    this.ratingLabel.Text = "ok";
                }

                if( rb == this.mehRadioButton)
                {
                    this.ratingLabel.Text = "run away!";
                }
            }
        }

        private void OkButton__Click(object sender, EventArgs e)
        {
            Student student = null;
            Teacher teacher = null;
            Person person = null;

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
            person.dateOfBirth = this.birthDateTimePicker.Value;
            person.homePageURL = this.homepageTextBox.Text;
            


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

            person.photoPath = this.photoPictureBox.ImageLocation;

            if ( person.GetType() == typeof(Student))
            {
                student.gpa = Convert.ToDouble(this.gpaTextBox.Text);
            }
            else
            {
                teacher.specialty = this.specTextBox.Text;

                if( this.greatRadioButton.Checked)
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

            if( this.Owner != null)
            {
                this.Owner.Enabled = true;
                this.Owner.Focus();

                // redraw the people listview with the updated details
                IListView listView = (IListView)this.Owner;
                listView.PaintListView(person.email);

                // cannot use PeopleListForm because it would create a circular dependency
                // PeopleList.dll depends on EditPerson.dll
                // we would now need EditPerson.dll to depend on PeopleList.dll
                //PersonListForm personListForm = (PeopleListForm)this.Owner;
                //personListForm.PaintListView();
            }

            this.Close();
            this.Dispose();
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

                this.gpaTextBox.Tag = (this.gpaTextBox.Text.Length > 0);

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

                this.ratingGroupBox.Visible = true;

                if( !this.greatRadioButton.Checked && !this.okRadioButton.Checked && !this.mehRadioButton.Checked)
                {
                    this.okRadioButton.Checked = true;
                }
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
                e.Handled = false;
                tb.Tag = true;
            }
            else
            {
                e.Handled = true;

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
