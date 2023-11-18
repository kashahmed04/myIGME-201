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
using CourseLib;
using PeopleAppGlobals;


//go over tag and is it global scoped no matter where we defined it like we did for the courses and email within the 
//personedit form and peoplelistform**

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

            this.homepageWebBrowser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(HomepageWebBrowser__DocumentCompleted);

            //event handlers for the edit and remove button for the course in the css grid
            //we put them in the constructor because they wont change
            //when the document completed event happens we go and change the html document and we add new elements and change the content
            //those changes remain after the document completed is done and all of those changes stay there 
            //all of the changes we make in document stays there after the document completed (like inserting an image tag or
            //footer tag for example) (we have to create new elements in delegate completed method deleagte because we dont know
            //then its done loading)

            this.editToolStripMenuItem.Click += new EventHandler(EditToolStripMenuItem__Click);
            this.removeToolStripMenuItem.Click += new EventHandler(RemoveToolStripMenuItem__Click);
            //we want to call this when they press the remove or edit in our context tool strip and when
            //the edit or remove button is clicked then we have an eveent handler for when its clicked


            //have the schedule ewb broswer completed delegate method so we can edit the css to show thr schdule
            //when the web browser is done loading because everything loads at the same time and we dont know when somehing will
            //finish updating
            //why did we not do it for the rest of the pages like our personeditform and our editcourseform but we had to do it with browsers
            //since we dont know when things will load on our form(all of these validating and textchanged delegates and all of the form delegates
            //will happen once the forms loads and by default and all of our delegates attached to form itself are only accessible and a called when
            //the form is done loading and the web browser control we need to do an additional step because we dont know when its done loading)
            //we could put the navigate in the constructor so navigate browser to site but we dont know when its done loading (we cant assume
            //anything about the webbrowser like if its done loading or not)
            //we can basically do a navigate for the webbrowser to have a certain page but for adding elements and other things
            //we need a delegate method for the web browser when its done loading)



            //in GIF finder when we do a new search we show the search form if the clicked ok then 
            //we set the search term in the js and set the limit in the js and we get the html elements then get the 
            // gifs and we have the time ticker and every time the timer ticks we look for an element in the docuement called
            //last element and once last element is in the document then we know its done loading the image 
            //and we call the js searchbutton clicked form the gif finder js method
            //and we load the data from the js from gif finder
            //and then it adds a last element div and when we finish and add the last element to the end
            //and the timer checks 10 times a second to see if last element tag got added
            //for all our gifs

           

            this.scheduleWebBrowser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(ScheduleWebBrowser__DocumentCompleted);

            // after all contols are configured then we can manipulate the data

            this.nameTextBox.Text = person.name;
            this.emailTextBox.Text = person.email;
            this.ageTextBox.Text = person.age.ToString();
            this.licTextBox.Text = person.LicenseId.ToString();


            this.birthDateTimePicker.Value = this.birthDateTimePicker.MinDate; //default the date to be the minimum date and if there is a person
            //with birthdate greater than the minimum date then we change the date based on the person passed in 

            if ( person.name == "" )
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

        //SLACK QUESTIONS:
        //use wb.Document.Body no matter what the name of the file is

        //and we can have tooltips with any HTML element and in our code we creates an img
        //element and we set the source to the picture we want and all the attributes and we would not
        //insert the element again (we can insert element to end by append child to end of our html docuement like we did with footer)

        //
        private void ScheduleWebBrowser__DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser webBrowser = (WebBrowser)sender;
            HtmlElement htmlElement;
            Course course;
           
            string htmlId = null; //go over**
            ICourseList iCourseList = (ICourseList)formPerson; 
            //person has a string of coursecodes so we take the coursecode and get the course object from the courses sorted list

            foreach (string courseCode in iCourseList.CourseList) //for each course in the list of the courses referenced in the interface as CourseList
                                                                  //for that specific person we are on
            {
                course = Globals.courses[courseCode]; //go into the globals class and go to the courses list we defined in the class scope and get the 
                //course object based on the course code we defined in the add courses sample data (at the end of that method when we create one whole course)
                //this gets each course object based on the students coursecode which was what the list in the interface contained (the course codes)

                //go through days of week this course meets for each course for that student
                foreach(DayOfWeek dayOfWeek in course.schedule.daysOfWeek)
                    //for each course object in the globals data then in the schdeule field of that course we want to specifically get
                    //the days of week from that schedule field or object (we have a schedule class as well)
                {
                    switch (dayOfWeek)
                    {
                        case DayOfWeek.Sunday: //we just need first letter of day of week name if its these days of weeks 
                        case DayOfWeek.Monday:
                        case DayOfWeek.Tuesday:
                        case DayOfWeek.Wednesday:
                        case DayOfWeek.Friday:
                            htmlId = (dayOfWeek.ToString())[0].ToString(); //whatever day of week it was if it was this case  
                            break;                                          //get the string of the day of week and the first character and it
                                                                            //returns a single character and we copy that character 
                                                                           //into a string because char. is a different datatype than string and we need a string
                                                                          //to display data on our form**
                                                                          //theres no tag so how would we be able to access it in other methods**

                        case DayOfWeek.Thursday:
                            htmlId = "R";
                            break;
                        case DayOfWeek.Saturday:
                            htmlId = "S";
                            break;
                    }

                    //get the hour that the class starts and we get it from the start time field from the courses**
                    //after colon gives us format from 00 to 23 for hours
                    //and this gets the time of the courses for the person we are on
                    htmlId += $"{course.schedule.startTime:HH}";

                    

                    //f its noon on Monday it creates an ID of M12 
                    htmlElement = webBrowser.Document.GetElementById(htmlId); 
                    //ID is made up of day and hour
                    //its set in the html so we get the element by id
                    //and for every id we have to styles for it (its the day and the time like M01)

                    if(htmlElement != null)
                    {
                        htmlElement.InnerText = course.courseCode;//we set the inner text of our day and hour ID to our course code
                        //and when we want to edit we pass that information to the edit method for the course 
                        htmlElement.Style += "background-color: red"; //always apend style text (always use += and browser usses last style attribute for any property)**

                        //set the mousedown (if we left click)**
                        //popus up our contextmnue strip which is the edit for remove**
                        htmlElement.MouseDown += new HtmlElementEventHandler(SchHtmlElement__MouseDown);
                        //sender is html element for both the mousedown and mouseover right**
                        //htmlekment is passed in as a courescode fro each course we go through and if we hover or click over it 
                        //it rather shows a tooltip or allows us to edit or remove a course**

                        //this is only available for html not other windows forms**
                        //this is more preffereable than doing the property though for a tooltip like we did for our css
                        //it was just called the tooltip property for our form right that we edited or where did we do that**
                        //we need to do this in exam 3 to show every anchor control in the web browser for the wikepedia********
                        //so basically we would target the anchor elements on the pge by collection or is there an id we can do it by then
                        //set the attribute for the a tags for exam 3**
                        //html.SetAttribute("title", $"Description: {course.description}\nReview: {course.review}";

                        //we set up the tooltip if we hover over a course**
                        htmlElement.MouseOver += new HtmlElementEventHandler(SchHtmlElement__MouseOver);

                        //remove eventhandlers because there is no longer a course with the html element when we remove so in the removetoolstrip we do  -=
                        //with delegate event there**

                        //how does it know what element to target**
                    }

                }
            }
        }

        //the htmlelemnt has an ID of day and time and has an innertext of the coursecode so we can access it to change data 

        private void SchHtmlElement__MouseOver(object sender, HtmlElementEventArgs e) 
        {
            //html element being hovered over is our sender**
            HtmlElement htmlElement = (HtmlElement)sender;
            //HtmlElement htmlElement = sender as HtmlElement; is this the same thing as the cast we did above**
            Course course; //course referecne variable equal to the courseobject from our globals database**

            course = Globals.courses[htmlElement.InnerText]; //can it also get a cours eobject by doing the innertext to get the course code 
            
            if(course != null)
            {
                //copy from code**
                this.schToolTip.Show($"Description: {course.description}\nReview: {course.review}", this.scheduleWebBrowser, e.MousePosition.X + 5, e.MousePosition.Y + 15, 1500);
                //we want our tooltip to show the string it should show and the review and descrption and we need the control to show the tooltip
                //which is in our schedulewebbrowser and the x and y locations to show** (we will only be using this type of control**
                //and the last argument is duration for the tooltip before it disapears and with the windows tooltip we have to specify how long
                //the tooltip will show but the html implementation with title shows as long as we are hovering over (htmlelement.setattribute("title", nanme to show
                //on tooltip)**
            }


        }

        private void SchHtmlElement__MouseDown(object sender, HtmlElementEventArgs e)
        {
            //whats passed in is the html element that was clicked on so we cast it**
            HtmlElement htmlElement = (HtmlElement)sender;

            if(e.MouseButtonsPressed == MouseButtons.Left) //if they left clicked then we want to save the html element that was clicked on in the
                //schedule context menu strip and every control has a tag property which is a generic onbject and we can use it to save conext data
                //is there no handled or suppress here like tere is for the keys or is it only specified with keys**
            {
                //whatever coursecode was passed in save it as an html element****
                //why do we do it in this specific method is it because we are actually going to need data to edit or delete the course
                //whereas for the mouse over we did not have to do that so we did not save the tag there**
                this.schContextMenuStrip.Tag = htmlElement; //save the htmlelement in a tag because we wll need access to the element we want to add or remove
                //and we wont have access to that furhter down if we dont get a tag equal to it (not local to the functino)**??
                //shoukdnt we have innertect here because the code is stored in the innertext of the thmlt element**

                //the controls are global on the form (all the controls on our person edit form)(defined within the class)
                //and if we have the control then the .tag then it can be seen everywhere in the class



                //show the contextmenu strip (acts like a form in itself)
                //how to know a show with para. vs. not with para. because with our forms we did not have para.
                //but here we do with the edit and remove button and the tooltip (we know to do it because we have make it relative to the page
                //control we want to show.show(form or beowser we want to shwo it on, x and y)
                //first para. put the menustrip within the control and the web brwoser control
                //will be the container for the menustrip and the x and y position will be relative to the controls
                //coordinates)
                this.schContextMenuStrip.Show(this.scheduleWebBrowser, e.MousePosition.X + 5, e.MousePosition.Y + 15);  //moves it to the right by 5 pixels and moves
                //the y down 15 pixels so when we click we can still the the button and the context menu strip**
                //show actuvates the menu strip and processes our mouseclicked within that control which means when we click edit
                //its going to call our edit tool stip menu item method and when we remove it eremoves the course**
                //we can show the conextmenustrup now and we can pass para. to show where it shows on the fomr
                //1. pass it a point on ths screen 2. the control to show within and a point on the screen 3. pass in x and y coord. 3. pass it at position and
                //direction for it to show 4. pass it the control to show within and an x and y location 5. the control a point and a toolstrip drop down direction****
                //we will be using the one where we pass in the control that our contextmneu strip should show on and the location is based on where they clciked**

            }

        }

        private void EditToolStripMenuItem__Click(object sender, EventArgs e) //sender would be the edittoolstrip control
            //we dont care about it but we only care about if it was the edittoolstrip button was clicked (we already know what it is)
            //whereas with the the keypress we dont know what it will be because its associated with 3 different controls because
            //sender could be either of them 
            //we get the edit tag if they press edit for the html element because tag is an object so we need to cast it to an html elemtn

            //we dony care about sender because that was whole tihng clicked right and we only care about which thing was clciked
            //which was the edit or remove which was in the contextmenustrip.tag from above*************
        {
            
            HtmlElement htmlElement = (HtmlElement)this.schContextMenuStrip.Tag; 

            //if they press edit option then we want to show the form we just created in the editcourseform**
            //we need to show the course code and the description in our editcourse form and it needs someway to access the course we are editing 
            //our form needs to be populated with all of the information from the course
            //and we would pass in the coursecode into editcourseform and we need to update the courseobject within the gloabls from whatever we did in that form**

            
            //we want to create a new edit course form now 
            EditCourseForm editCourseForm = new EditCourseForm(htmlElement.InnerText); 
            //from that html element we grab the inner text which is the course code and we can edit it via the editcourseform
            //when we get element by ID it gives us the exact location where to put the elements on the grid 
            //pass in the course code we saved above in the tag field 
            //we can just do new since there is show in the constructor (whenever there is a new keyword then a show in the constructor it will run)**
            //if we did not have the show method then we would need to save variable pointing to the form then do variable .show() in the same scope
            //or in a different one??**

            editCourseForm.Show(); //or we could do this if its not on the constructor and we do this way when we want to show something at certain times**

            //we can show in constructor and do this here and it still shows the form only once**




        }

        private void RemoveToolStripMenuItem__Click(object sender, EventArgs e)
        {
            //grab html element in focus and clear the innertext and it removes it frmo the schedule page only not the data 
            HtmlElement htmlElement = (HtmlElement)this.schContextMenuStrip.Tag; //color changes 3 times but the latest css setting is used**s
            //how come we dont do sender here whats sender why do we do this instead**

            htmlElement.InnerText = "";

            htmlElement.Style += "background-color: green"; //if they click remove we want to grab the html element from the tag and make the innertext to blank
            //set the background to green for no course and remove the events for the part of the grid so nothing shows up anymore

            htmlElement.MouseDown -= SchHtmlElement__MouseDown;
            htmlElement.MouseOver -= SchHtmlElement__MouseOver; //nothing will happen anymore because we removed the course from the grid not the 
            //list of courses though
        }
        private void HomepageWebBrowser__DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser wb = (WebBrowser)sender;

            if( wb.Document.Title == "DOM-3")
            {
                HtmlElement htmlElement;
                HtmlElementCollection htmlElementCollection;

                htmlElement = wb.Document.Body;
                htmlElement.Style += "font-family: sans-serif; color: #a000a0;";

                htmlElementCollection = wb.Document.GetElementsByTagName("h1");
                htmlElement = htmlElementCollection[0];

                htmlElement.InnerText = "My Kitten Page";
                htmlElement.MouseOver += new HtmlElementEventHandler(Example_H1__MouseOver);

                htmlElementCollection = wb.Document.GetElementsByTagName("h2");
                htmlElementCollection[0].InnerText = "Meow!";
                htmlElementCollection[1].InnerHtml = "<a href='http://www.kittens.com'>Kitties!</a>";
                htmlElementCollection[1].InnerText = "";

                htmlElement = wb.Document.GetElementById("lastParagraph");

                HtmlElement htmlElement1 = wb.Document.CreateElement("img");
                htmlElement1.SetAttribute("src", "https://en.bcdn.biz/Images/2018/6/12/27565ee3-ffc0-4a4d-af63-ce8731b65f26.jpg");
                htmlElement1.SetAttribute("title", "awwww");
                htmlElement1.Click += new HtmlElementEventHandler(Example_IMG__Click);

                htmlElement.InsertAdjacentElement(HtmlElementInsertionOrientation.AfterBegin, htmlElement1);

                htmlElement1 = wb.Document.CreateElement("footer"); //html element one is now pointing to footer not the image element we just made right**

                htmlElement1.InnerHtml = "&copy;2023 <a href='http://www.nerdtherapy.org'>D. Schuh</a>";

                wb.Document.Body.AppendChild(htmlElement1); //we can do append child here because its at the end of the docuemtn**

            }
        }

        private void Example_IMG__Click(object sender, EventArgs e)
        {
            this.homepageWebBrowser.Navigate("http://m.youtube.com/watch?v=oHg5SJYRHA0");
        }
        //if we right click on a project we can open it in file epxplorerer and we can go to debug and go to executable 
        //and any app that uses the web browser control we have to use registery and it should be right after the intialize componenet**
        //we set it so that windows will use the latest browser control**
        //in order for registry setting to be set we have to run applicatino as administrator only once so it knows**
        //(we set person edit form as the run as administrator)**
        //the last peiece we did was that we added the courses and we were using the form person to save the list of course codes that the persons associated with** (class
        //scoped variable to store person thats passed into constructor**)

        //we use the form person when we add and remove courses
        private void Example_H1__MouseOver(object sender, HtmlElementEventArgs e)
        {
            HtmlElement htmlElement = (HtmlElement)sender;
            HtmlElementCollection htmlElementCollection;

            if( htmlElement.InnerText.ToLower().Contains("kitten"))
            {
                htmlElement.InnerText = "My Puppy Page";

                htmlElementCollection = this.homepageWebBrowser.Document.GetElementsByTagName("h2");
                htmlElementCollection[0].InnerText = "Woof!";
                htmlElementCollection[1].InnerHtml = "<a href='http://www.puppies.com'>Puppies!</a>";

                htmlElementCollection = this.homepageWebBrowser.Document.GetElementsByTagName("img");
                htmlElementCollection[0].SetAttribute("src", "https://www.allthingsdogs.com/wp-content/uploads/2019/05/Cute-Puppy-Names.jpg");
            }
            else
            {
                htmlElement.InnerText = "My Kitten Page";

                htmlElementCollection = this.homepageWebBrowser.Document.GetElementsByTagName("h2");
                htmlElementCollection[0].InnerText = "Meow!";
                htmlElementCollection[1].InnerHtml = "<a href='http://www.kittens.com'>Kitties!</a>";

                htmlElementCollection = this.homepageWebBrowser.Document.GetElementsByTagName("img");
                htmlElementCollection[0].SetAttribute("src", "https://en.bcdn.biz/Images/2018/6/12/27565ee3-ffc0-4a4d-af63-ce8731b65f26.jpg");
            }
        }

        private void CourseSearchTextBox__TextChanged( object sender, EventArgs e )
        {
            PaintListView(allCoursesListView);
        }

        private void AllCoursesListView__KeyDown(object sender, KeyEventArgs e)
        {
            Course course;
            ListView lv = (ListView)sender;

            string courseCode = null;

            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                courseCode = lv.SelectedItems[0].Tag.ToString();

                course = Globals.courses[courseCode];

                ICourseList iCourseList = (ICourseList)formPerson;

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

                    PaintListView(this.selectedCoursesListView);
                }
            }
        }


        private void AllCoursesListView__ItemActivate(object sender, EventArgs e)
        {
            Course course;
            ListView lv = (ListView)sender;

            string courseCode = null;

            courseCode = lv.SelectedItems[0].Tag.ToString();

            course = Globals.courses[courseCode];

            ICourseList iCourseList = (ICourseList)formPerson;

            if( course != null)
            {
                if( iCourseList.CourseList.Contains(course.courseCode))
                {
                    iCourseList.CourseList.Remove(course.courseCode);
                }
                else
                {
                    iCourseList.CourseList.Add(course.courseCode);
                }

                PaintListView(this.selectedCoursesListView);
            }
        }

        private void PaintListView(ListView lv)
        {
            ListViewItem lvi = null;
            ListViewItem.ListViewSubItem lvsi = null;

            // 12. lock the listview to begin updating it
            lv.BeginUpdate();

            // 13. clear the listview items
            lv.Items.Clear();

            int lviCntr = 0;

            // 14. loop through all courses in Globals.courses.sortedList and insert them in the ListView
            foreach (KeyValuePair<string, Course> keyValuePair in Globals.courses.sortedList)
            {
                Course thisCourse = null;

                // 15. set thisCourse to the Value in the current keyValuePair
                thisCourse = keyValuePair.Value;

                if (lv == selectedCoursesListView)
                {
                    ICourseList iCourseList = (ICourseList)formPerson;

                    if (!iCourseList.CourseList.Contains(thisCourse.courseCode))
                    {
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
            else if( tc.SelectedTab == this.scheduleTabPage)
            {
                this.AcceptButton = null;
                this.CancelButton = null;

                this.scheduleWebBrowser.Navigate("https://people.rit.edu/dxsigm/schedule.html");
            }
        }

        //when we do view course in our web browser for the css grid we have an ID for each hour of everyday and we have set up css style attributes
        //for each of thise ID's for the slots and each button has an ID nad the ID can be cluclated based on day and time (button for every hour of the day 0-23)
        //and using css grid we can lay out the form to have a nce schedule formar now we want tot go through and use dom manipulation to change contents
        //of each slot to get the courses at that time**

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
            //grab person from form person and we need reference variable to point to form person courese
            //we had our formperson in course view key down**
            Student student = null;
            Teacher teacher = null;
            Person person = null;

            //grab person from form person and we need reference variable to point to form person courese
            ICourseList iCourseList = (ICourseList)formPerson;//**

            Globals.people.Remove(this.formPerson.email);

            if( this.typeComboBox.SelectedIndex == 0)
            {
                student = new Student();
                student.CourseList = iCourseList.CourseList; //we save the courselit for if its a teacher or astudent when we press ok for
                //the edit person in terms of the courselistview right??**
                person = student;
            }
            else
            {
                teacher = new Teacher(); //this basically gets our formperson variable for their list of courses and for that person
                //if they are a student or a teacher we change their course accordingly when we press ok

                //if we hover over it gives us a review and if we right click we can add a description and review of the course
                //we use tooltip control and a context menu strpi that we dynamically add to the form when we click on a course slot**
                //tooltip usually does not have location on the form**
                //we could press e or r for unerline letters when we have a context menu strip (keyboard shortcut)(put & in front of the letter
                //so we can press the key to access the option (dont have to use in front of the start of the word can be anywhere))**
                //some controls have a tooltip prperty but not many of them ad we can set the tooltip that way
                //we need to add our own tool tip for the textboxes and it will hint us to which # president
                //and we have to add our own tool tip and we will do that today (we did that by /
                //html.SetAttribute("title", $"Description: {course.description}\nReview: {course.review}"; or in the properties window which we did (and
                //tool tip is defined for what controls))**
                teacher.CourseList = iCourseList.CourseList;

                //when the edit tool strip menu item is clicked then we want to edit the current selected course
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
