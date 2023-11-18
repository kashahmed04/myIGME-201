using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CourseLib; //the refference is alrrady in personeditform and our form is in there so all we need is the usng statement**
//is this true for all forms within one file like we have with editcourseform and personedit form**
using PeopleAppGlobals;

//richtextboxes support paragrpahs (long descrptions) and textboxes are a single line 
//the accept button on the form is what the form uses when we press enter and it clicks the update button for us since we set it for accept button
//and cor the cancelbutton we set that to the exit button and when we press escape then it presses the exit button because we set that for the cancel button 

//we have a label called coursecode label we have
//coursecoee textbox the description label the dexcription texbox
//the review label and we havea richtextbox for the review to allow them to enter course review
//and we have an update and exit button 
//for our editcourseform and when we rename we press yes so it will fix all of the reference within our code**
//if we get an error then we close the project and reopen it and if it did not work delete the form then add it again 
//go over accept and the cancel button for our selected index changed**




//we would use 3 forms in same file then reference them with this.show like we did with personeditform and editcourse form
//the the timed typing in our toolbox we have a timer control and just like with back when we did memory game 
//and in the test we want to start time as soon as they type something into one of the textboxes to enter the number president then
//we want to start the time 
//its 4 minutes in milliseconds for the interval
//this.timer1.Interval = 1000 every second we want it to tick
//this.timer1.tick += new Eventhanlder(name of method)
//this.toolstripprogressbar1.value = 240
//this.toolstripprogressbar1.value = this.toolstripprogressbar1.maximum and set the value for the maximum value
//everytime the timer ticks like one second we want to progress bar to go down one value 
//this.richTextBox (or textbox for exam).TextChanged += new EventHandler(RichTextBox (or textbox for exam)__TextChanged)

//private void name of method (object sender, eventargs e)
//this.timer1.start
//when each tick of the timer happens we want  a status bar
//so we add that from the toolbox with a status strip and it goes in the bottom and we want to add a progress bar 
//and we want the properties of that and we want the size of it to be more thsn 100 probably 700,16 for the size property
//and do style continuous for the status bar and our start value
//will be 

//and set maximum to 240 so each second it will count down for the bar properties

//each time we go we want to subtrat by one second 
//private void timer1__tick
//--this.toolstripprogressbar1.value
//if(this.toolstripprogressbar1.value == 0)
////clear our textboxes and reset the toolstrip to 240 seconds then stop the timer
///this.richtextbox.clear();
///this.toolstripprogressbar1.value = this.toolstripprogressbar1.maximum; reset it back to our maximum time 
//timer1.stop();

//for the images we make the picturebox big and we make it grow when we hover over it
//and we want to change width and height of the photopicturebox
//this,textbox1.mouseenter += new eventhandler(textbo1x__mousetner)
//this,textbox1.mouseleave += new eventhandler(textbo1x__mousleave)
//private void textbox1__mousenter(object sender, eventargs e)
//this.textbox1.height *= 2;
//this.textbox1.width *= 2;


//private void textbox1__mouseleave(object sender, eventargs e) //when we enter and leave it grows then shinrks 
//this.textbox1.height /= 2;
//this.textbox1.width /= 2;
//use mouseover event handler for the photoboxes

//for each picturebox we could have 16 presidents and set the presidents images or use banjo site links 
//and have the path and we decide if we want to have them hard coded or when they click the radio button we change
//the path of the image and we could just have one picture box
//pb.imagelocation = our link
//then we would do name of the control then image location then we would change the url image
//then put it in the checkchanged and we will see which radio button they clicked 
//and see which president then change their image (like we had class radio button clicked) and set their web browser
//and their image 


namespace EditPerson
{
    public partial class EditCourseForm : Form
    {
        Course formCourse;
        public EditCourseForm(string courseCode) //add courseCode to the para. and after initialize componenet then set the controls and events
        {
            InitializeComponent();

            codeTextBox.Text = courseCode;

            formCourse = Globals.courses[courseCode]; //gets the course object based on the coursecode we passed in from personeditform
            //in our properties we set the enabled to false but the visible is true to show it and if a contorl is not eneabled then its locked 

            //most control does not have a tooltip only a couple like the context menu strip and the entries in the 
            //context menu strip (edit tool strip menu item the indiviual lines have tooltip text)
            //we can enter text in designer to what we want it to say but we dont want it to say the same thing so we do it in the code
            //we can just title attribute with the a tags and get all the anchor tags (and do get getelementbytagname then go through
            //all the anchor tags then do foreach through array then set the title attribute to the text)

            descTextBox.Text = formCourse.description; //first set all of the text to whatever it was last saved to then when we press update
            //update the current information based on what the user puts in the texboxes
            revRichTextBox.Text = formCourse.review;

            updateButton.Click += new EventHandler(UpdateButton__Click); 
            exitButton.Click += new EventHandler(ExitButton__Click);

            //why do we have to have a this.show here even though we arent showing anything on this form
            this.Show();
            
        }


        private void UpdateButton__Click(object sender, EventArgs e)
        {
            formCourse.description = descTextBox.Text; //change the textboxes for when we press the update button 
            formCourse.review = revRichTextBox.Text;

            //go over these 2 lines**
            //we go to globals then courses list then remove the curret course object we are on bsaed on the coursecode**
            Globals.courses.remove(formCourse.courseCode); //we have a method for remove in the courses so in our sorted list its indexed by the coursecode
            //and it contains a course code and we remove the course by the coursecode
            Globals.courses[formCourse.courseCode] = formCourse; //update the database in people app globals 
            //we go to globals then courseslist then the current coursecode we have to set it equal to the new course object we edited
            //so it can update on the form**

            //our formcourse is the object we are editing and its set equal to the course we are editing and we can remove course from sorted list
            //then add it back with changed we made 
            //formcourse.courseCode is the key because we get the course then get the coursecode 
            //then add or remove based on that 

            this.Close(); //close the form and clean up memory (do we do dispoase for applciation.exit for main form)
            this.Dispose();

        }

        private void ExitButton__Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}
