using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CourseLib; //the refference is alrrady in personeditform and our form is in there so all we need is the usng statement**
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

namespace EditPerson
{
    public partial class EditCourseForm : Form
    {
        Course formCourse;
        public EditCourseForm(string courseCode) //add courseCode to the para. and after initialize componenet set the controls and events
        {
            InitializeComponent();

            courseTextBox.Text = courseCode;

            formCourse = Globals.courses[courseCode];

            descTextBox.Text = formCourse.description;
            revRichTextBox.Text = formCourse.review;

            updateButtonntntn.Click += new EventHandler(); //copy from code**
            exitButton.Click += new EventHandler(ExitButton__Click);

        }


        private void UpdateButton__Click(object sender, EventArgs e)
        {
            formCourse.description = descTextBox.Text; //change the textboxes for when we press the update button 
            formCourse.review = revRichTextBox.Text;

            Globals.courses.remove(formCourse.courseCode); //dont let them edit the coursecode**
            Globals.courses[formCourse.courseCode] = formCourse; //update the database in people app globals 

            this.Close(); //close the form and clean up memory (do we do dispoase for applciation.exit for main form)
            this.Dispose();

        }

        private void ExitButton__Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();//**see on code 
        }


    }
}
