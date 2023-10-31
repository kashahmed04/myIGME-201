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
using EditPerson;

/*
 * Controls
 * TeacherButton
 * StudentButton
 * ImageList the buttons pull the image from this list
 * SplitContainer
 * FlowLayoutPanel
 * within the flow layout panel we have individual panels (create one flowlayout panel then use that as a ref. to make copies of 
 * panels for each person)(use panel down below)
 * Panel
 * we want to have a panel then within each one have a toolstrip with a linkedlabel and a tool strip button to minimize and 
 *maximize individual panels
 *ToolStrip - the toolstrip itself
 *ToolStripLinkLabel1 - the linked label for persons name to access their inform. (from edit person file)
 *ToolStripButton - button for individual panel
 *EmailLabel for the email within the dropdown menu
 *PhotoGroupBox and within it we have the PhotoPictureBox for the box in the dropdown menu (does the groupbox basically give the label "photo" and the
 *actual picturebox is the picture itself)??**(1)
 *Plus and minus images associated with toolstrip button (PlusImage and MinusImage)
 *It references the peopleglobals dll in order to access all of the people(PeopleGlobals.dll)
 *It also calls the edit person dll (EditPerson.dll)
 *These two are references within the main file which will be opened from the main application.run() and the references will be opened
 *with the .show() right?? (2)**
 *why do we have to access peoplelib and courselib if the editperson and peopleappglobals already reference them??(3)**
 *
 * 
*/

namespace DynamicPeople
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent(); //creates our form objects

            //create our people sample data
            Globals.AddPeopleSampleData();

            //we have 2 buttons to handle (from our name that we named the two buttons in the property for (Name)
            //(Name) changes the name for us to access in code while the text is actually on the form right??(4)****
            this.teacherButton.Click += new EventHandler(TeacherButton__Click);
            this.studentButton.Click += new EventHandler(StudentButton__Click);

            //why did we want to make panel1 not visible(5)****
            this.panel1.Visible = false;
        }


        //first we want to clear out anything thats inside of the flow layout panel (not the panels itself
        //because we are going to recreate it with
        //the list of the teachers same for students if we click the corresponding icons associated with the lists (so basically for example if we click
        //student we get a refreshed list full of students now and if we reclick students it will still be refreshed??(5)**)
        //to clear a container we use this.flowLayoutPanel1.Controls.Clear(); (this clears the array of values which are the student
        //objects) when you said array of values does that mean we clear out the panels as well with the student objects in them??(6)**
        //(why do we need to do controls.clear() what is the points of controls??)(7)**
        private void TeacherButton__Click(object sender, EventArgs e)
        {
            this.flowLayoutPanel1.Controls.Clear();

            //now we want to go through the sorted list of people (use a key value pair to go through list of people)
            //(key is based on email string and value is the person object)
            //basically we are saying in the globals class in PeopleAppGlobals grab the people object we made and in that people object specifically grab
            //the sortedlist right??(8)**
            foreach (KeyValuePair<string, Person> keyValuePair in Globals.people.sortedList)
            {
                //if the current entry value which is the object is the list and if that type is a type of teacher
                //then we want to add a panel for that person(call addpanel)
                //we can access just teacher because we have a reference to our people from peoplelib
                if (keyValuePair.Value.GetType() == typeof(Teacher))
                {
                    AddPanel(keyValuePair.Value); //now we add the whole value which is the person object to the panel right(9)**

                }

                //now we want to put how many teachers there are on the top right corner of the images
                //so we set the button equal to the count of the panels in the flowlayoutpanel1.controls.count (why do we have to say
                //controls cant we just say the flowlayoutpanel1.count??(9.5)*****
                //we need to convert that integer to a string so we can actually display it (in the forms we usually make it
                //a string to display just like console??(10))*****
                teacherButton.Text = this.flowLayoutPanel1.Controls.Count.ToString();

            }

        }

        //do same thing for student button but in this case we want to make it a student
        private void StudentButton__Click(object sender, EventArgs e)
        {
            this.flowLayoutPanel1.Controls.Clear();

            foreach (KeyValuePair<string, Person> keyValuePair in Globals.people.sortedList)
            {

                if (keyValuePair.Value.GetType() == typeof(Student))
                {
                    AddPanel(keyValuePair.Value);

                }


                studentButton.Text = this.flowLayoutPanel1.Controls.Count.ToString();

            }
        }

        //write click methods for other two events we want to handle and they are the toolstripbutton click and the tool
        //strip label click we dont add these in the form constructor because they are being dynamically added(associated with
        //each panel that we dynamically add) (what does this mean exactly when you said dynamically added??)(11)**
        //we add event handlers when we write the add panel method

        //when they click this button this is what expands or contracts our panel with the photo and changing the
        //button image to be a plus or minus when it exapnds or contracts
        private void ToolStripButton1__Click(object sender, EventArgs e)
        {
            ToolStripButton tsb = (ToolStripButton)sender; //we have to explicitly cast the toolstrip button to the object
            //because the sender is usually the thing the user interacts with and that gets sent in while the event is whatever
            //event we had set it to in the constructor usually right??(12)**

            //we have to know what panel is associated with that button because that specific panel is being resized when the
            //button is clicked
            //we know we have tag field so we can use that to associate it with the toolstripbutton to store a reference
            //to the parent panel for the toolstripbutton so it knows which panel to expand or contract

            Panel p = (Panel)tsb.Tag; //why do we want to cast the tag as a panel (13))****

            //our toolstripbuttons can be checked or unchecked so we check if its currently checked then 
            //we would want the button image to be a minus so it contracts because it was already opened initially and
            //now we interacted with it to close it 
            //but if it's not checked that means it's contracted initially
            //and now we want to expand it because it's being interacted with (these statements are correct right (the 4 above) (14)****

            if (tsb.Checked)
            {
                //what did you mean by the images are in the resource for this control?? did you mean we have to copy and paste from .NET??(15)**
                //why and when do we have to copy and paste from the .NET??(16)**
                //in the .NET (Form1.Designer.cs) we see how windows wrote it for us and we expand the code
                //and go down to the toolstripbutton and we copy that so we now have access to the image
                //we want to use the actual toolstripbutton that was clicked thats casted because if we did the original
                //that was there when we pasted it in from the .NET then (why dont we need this. when we paste the code from .NET because arent we
                //technically accessing the form to edit it in both situations with and without the this.??)(17)**

                //here we want to shrink it so we set it to plus because now it's closing we want
                //to have a symbol to say we can open the panel
                //we also have to change the panel size as well (shown in the second line)
                //we are resizing the parent panel which is the big panel that contains all the information
                //we use p.size because we want to reference the current panel that we are on not all of the panels??(18)**
                tsb.Image = global::DynamicPeople.Properties.Resources.plus;
                p.Size = new System.Drawing.Size(189, 25); //bring it back to it's original size because we want to contract
                //we want to make it unchecked now so that it won't stay at the same state when we click again right(19)**
                tsb.Checked = false;

            }
            else
            {
                tsb.Image = global::DynamicPeople.Properties.Resources.minus; //we set it to minus because
                //its opened right now so that we can give the open to close the panel
                p.Size = new System.Drawing.Size(189, 159);
                //we are now expanding the panel it's maximum size

                //because we pressed the minus and now it goes from unchecked to check and it goes to the plus symbol for the button right
                //I just wanted to make sure I understood the logic(20)****

                //we want to make it checked now so that it won't stay at the same state when we click again
                tsb.Checked = true;
            }

            //refresh the panel so that it will be redrawn according to the new size and it will also refresh all the controls in it
            //and the toolstripbutton will be refreshed with the new plus or minus image (only the specific panel we are
            //on right not all of them that was taken care of above with the student and teacher lists right??)(21)**
            p.Refresh();
        }

        //what if they click the toolstriplabel this is where we want to call editperson so edit the person
        //associated with the panel
        private void ToolStripLabel1__Click(object sender, EventArgs e)
        {
            //first thing we want to do is get the toolstrip label that was clicked 
            ToolStripLabel tsl = (ToolStripLabel)sender;

            //just like we did with toolstripbutton above we want to have the parent panel which is associated with the label
            //stored somewhere so we can have access to it (why explicitly cast the panel??)(22)**
            //when you say parent panel are you refeerring to the current panel that was clicked or all of the panels in the form**
            //tag field is the best way to do it like we did in the method above with the toolstripbutton

            Panel p = (Panel)tsl.Tag; //when we dynamically create our objects we need to remember to set these tags fields for
            //the parent panel for these controls (so basically does this mean we get the current toolstriplabel we are
            //on and get the panel that has that toolstriplabel we clicked??)(23)**

            //now we want to create the person edit form for the person associated with that panel 
            //so basically over here we created a personeditform and we basically create a new form with the current person we are on and passed into
            //the new object form we have created??(24)**
            //personeditform takes 2 arguments so:
            //cast the p.tag as a person we are currently on in the list and then the second argument is the parent form
            //which is this (what is "this" exactly in the parent form when we create a new PersonEditForm)(25)**
            //the problem now is that when we create a new person edit form right at the end of the constrcutor
            //it calls the show command in the personeditform and it shows the personeditform as a non modal dialogue meaning
            //as an active form thats active at the same time in the dynamicpeolpe form because of the showmethod thats called
            //.show() makes it an active form and the parent form that called it will also remain active
            //but .showdialouge() makes it so that our parent class will pause until the child form is done being interacted with
            //because we need to fetch the updated details for the person for the parent form once they press ok so it updated
            //and we can only do one person at a time so we need to disable the parent form so multiple people cant be edited at the same
            //time**
            PersonEditForm pef = new PersonEditForm((Person)p.Tag, this);

            //we created the person editform so they popup window to edit a person is automatically activated and we dont want that
            //when this new personedit form is created its immediately activated and processing input and we dont want that

            //so basically we can override that by just making the form invisble so the child form in personeditform won't
            //show up as soon as the parent form (dynamic person) loads in and instead we make it so it loads in
            //when we click on the actual persons name for the editpersonform right??(26)**
            pef.Visible = false;

            //so basically right now we want to show the personeditform in a modal way which means only one form is active at a time and it
            //will pause the parent form (dynamic form) so that the personedit form can run when we click on a persons name
            ////while we are editing a person right??(27)**
            //this is important because we want to next get the updated person object that the person edited out of the form
            //at the end of the ok method in the personedit form we set the formperson var. equal to the updated person
            //and we made formperson a global varible so we can now access it here
            pef.ShowDialog();

            Person person = pef.formPerson; //we create a new person and get that updated person global variable from the ok
            //method in personeditform

            //if we have children forms we usually want to pause the parent form so then we can get the data
            //from the child form then update it in the parent form (prevents multiple things from being edited at the same time)(28)**

            //we have now edited the person and have a reference to the panel assocaiated with that person
            //we now want to clear the controls within the panel
            //this clears only the controls within the panel associated with the person and we want to do that
            //because they may have changed the persons name which is in toolstriplabel1 or may have changed the email for the person
            //which is label1 of have changed the photo
            p.Controls.Clear();

            //now after all the changes have been made to a person and we cleared the panel we now want a method to add
            //a person to a panel with the updated information
            AddPersonToPanel(ref p, person); //this takes a panel as a reference because we want to
                                             //change the current panel we are for that person not make a copy
                                             //and the second para. is the edited person from the people
                                             //list we are adding to the current panel we are on

            //now we want to refresh the panel after we added the person to the panel so the new information displays
            //but it only refreshes the specific panel and it's children not all of the panels right??**(29)
            //(does refresh,clear,show,and showdialouge
            //usually also include the parent control and their children controls within it?? In this case it would be the panel
            //and everything inside of it??)(30)**
            p.Refresh();

            //now we need a method to add a person to a panel and a method to add a panel for each person within the list
            //so these methods can be used based on if a panel is clicked and what aspect was clicked

            //we have the code that .NET generated for us (in our panel we have the code to create the new panel and the things
            //within the label like the photo toolstripbutton1,toolstriplabel1,emaillabel,photogroupbox, and photopicturebox
            //how do we know when to copy from the .NET generated code??****(31) I know we need to copy the things in the panel
            //to create new panels for every person but I am confused as to how to know when to go to .NET and copy and paste(32)**


        }

        //takes in a person because each person represents a panel
        //here we are creating panels initially for each person right (33)**
        private void AddPanel(Person person)
        {
            //we won't say this.panel because we have to create a new panel and this.panel refers to 
            //the object that was created in initialize component and we are creating a new panel for each person 
            //so in our addpanel method we need to create a new panel method each time a person is added

            //if we used this.panel what would happen because I am still confused about the "this." would it just add everything in that
            //panel in initialize component we have set up??****(34) why would we not want to do this because don't we technically have to edit the form
            //and the "this." references the form??(35)**
            Panel panel1 = new System.Windows.Forms.Panel();

            //this panel refers to each person but these controls need to updated if a person is updated so these controls need to
            //be part of addpersontopanel method (we need to seperate what needs to go where)


            //we need to call addpersontopanel 
            //we put the current panel we are on (why would we need to call this here because in this method
            //we are creating a person but in the second method we are editing a person so how can we edit a person that we just created??)(36)**
            AddPersonToPanel(ref panel1, person);


            //the last thing that needs to happen when the panel is fully created is adding the panel control to the flowlayoutpanel
            //so we have all of our people on the flowpanel

            //access the controls then add panel1 to the flowlayoutpanel container

            //why can't we just say flowLayoutPanel1.Add(panel1) what does Controls exactly do??(37)**
            this.flowLayoutPanel1.Controls.Add(panel1);

            //we also want to make sure they appear in the right order so in the controls collection theres a method called
            //setchildindex and we want to access the controls in flowlayoutpanels1 and set the child index of the panel we just
            //added and we want to set it to be an incremenetal number so we ensure it appears in the sequential order we added them
            //because we don't have total control on how .NET allocates memory and when we add items to collections or arrays it's
            //never completly guarenteed that the things will be fetched in the order we added them
            this.flowLayoutPanel1.Controls.SetChildIndex(panel1, flowLayoutPanel1.Controls.Count);
            //we increment the count of the
            //panels in the flowlayoutpanel1
            //(so basically the first para. is the child of the flowlayout panel
            //and the second para. is the count of the panels we have to far??)(38)**
            //(here again I am confused on why we need .controls)(39)**
            //how do we know when to use .controls with the things in our forms(40)**


        }

        //here we are updating a panel based on what person is changed
        //this takes in the panel we are updating and a person object from the people list we are editing
        private void AddPersonToPanel(ref Panel panel1, Person person) //we need to reference the panel because we are actually changing it
                                                                       //not making a copy
        {
            //because each of the controls in the panel is associated with the person in the panel we have the child contorls of the
            //panel here (these are the child controls of the panel right)**(41)
            //we dont use this. because they all need to be their own variables (why dont we use this. though I am still confused)(42)**
            //(why do these need to go in addpersontopanel and not addpanel because we technically need these to make a new panel)(43)****
            ToolStrip toolStrip1 = new System.Windows.Forms.ToolStrip();
            ToolStripButton toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            ToolStripLabel toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            Label emailLabel = new System.Windows.Forms.Label();
            GroupBox photoGroupBox = new System.Windows.Forms.GroupBox();
            PictureBox photoPictureBox = new System.Windows.Forms.PictureBox(); //we are creating each of these controls which
                                                                                //is going to be contined within the panel

            //now we need to look at what .NET did for us to create all of these objects 
            //we see our panel there and we copy all of the properties for those controls in the panel and copy and paste them here
            //so are w creating each of these properties now based on the controls we created above??(44)**

            panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            panel1.Controls.Add(emailLabel);
            //do we always remove this. when copying code from the .NET??(45)**
            panel1.Controls.Add(photoGroupBox);
            panel1.Controls.Add(toolStrip1);
            panel1.Location = new System.Drawing.Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(189, 25); //when the panel is first created we don't want it to be the full size
                                                            //we only want it to be a height of 25 (closed form right??)(46)**
            panel1.TabIndex = 0;

            //we want to attach a reference to the person associated with the panel in the panels tag field
            //this basically says this person is in the current panel right?? why would we want to do this if we already passed a person
            //instance in the method??(46)**
            panel1.Tag = person;

            // 
            // toolStrip1 (adds our button and label)
            // 
            toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            toolStripButton1,
            toolStripLabel1});
            toolStrip1.Location = new System.Drawing.Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            toolStrip1.Size = new System.Drawing.Size(185, 27);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1 (we know we need a click event for our button so we add it below the .Text line)
            // 
            toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            toolStripButton1.Image = global::DynamicPeople.Properties.Resources.plus;
            toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new System.Drawing.Size(29, 24);
            toolStripButton1.Text = "toolStripButton1";
            toolStripButton1.Click += new EventHandler(ToolStripButton1__Click);
            //for each panel we have the toolstrip button

            //and for each toolstrip button on our form we can add the click event

            //we also want to add the parent panel in the tag field of the toolstripbutton 

            toolStripButton1.Tag = panel1; //same situation here why use the tag if we have the panel referenced already in the method(47)****

            // 
            // toolStripLabel1 (needs to have the persons name and thats also clickable) (change text to persons name)
            // 
            toolStripLabel1.AutoSize = false;
            toolStripLabel1.IsLink = true;
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            toolStripLabel1.Size = new System.Drawing.Size(140, 22);
            toolStripLabel1.Text = person.name; //the current person we are on, change their name
            toolStripLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            toolStripLabel1.Click += new EventHandler(ToolStripLabel1__Click); //we want to call this if the name
                                                                               //was clicked for the specific panel we are on in this
                                                                               //toolstriplabel right so we can edit a person??(48)**

            toolStripLabel1.Tag = panel1; //when its clicked we can refernce back to which panel the toolstriplabel1 belongs to
            // 
            // emailLabel
            // 
            //should be set to email of the person and make the text person.email
            emailLabel.Location = new System.Drawing.Point(12, 38);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new System.Drawing.Size(158, 23);
            emailLabel.TabIndex = 1;
            emailLabel.Text = person.email;
            // 
            // photoGroupBox
            // 
            photoGroupBox.Controls.Add(photoPictureBox); //we want to get rid of the this. here so 
                                                         //it adds the local picturebox we created and not the global one to the form

            //arent we technically editing the form so why would it not make sense
            //to use this. here in the .Add??(49)**
            photoGroupBox.Location = new System.Drawing.Point(4, 65);
            photoGroupBox.Margin = new System.Windows.Forms.Padding(4);
            photoGroupBox.Name = "photoGroupBox";
            photoGroupBox.Padding = new System.Windows.Forms.Padding(4);
            photoGroupBox.Size = new System.Drawing.Size(137, 86);
            photoGroupBox.TabIndex = 52;
            photoGroupBox.TabStop = false;
            photoGroupBox.Text = "Photo";
            // 
            // photoPictureBox
            // 
            //set the image location to the persons photopath because we need to have the image that put in from the user for the person
            //when they are editing so it can show on the form??(50)**
            photoPictureBox.BackColor = System.Drawing.Color.LightGray;
            photoPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            photoPictureBox.Location = new System.Drawing.Point(4, 19);
            photoPictureBox.Margin = new System.Windows.Forms.Padding(4);
            photoPictureBox.Name = "photoPictureBox";
            photoPictureBox.Size = new System.Drawing.Size(129, 63);
            photoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            photoPictureBox.TabIndex = 0;
            photoPictureBox.TabStop = false;
            photoPictureBox.ImageLocation = person.photoPath;

            //if someone edits a person all of these changes will be applied and updates all their
            //details in the panel associated with them    

        }


    }




}
