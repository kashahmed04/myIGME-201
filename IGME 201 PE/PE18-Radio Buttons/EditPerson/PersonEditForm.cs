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
using PeopleAppGlobals;

//changes I made on form are not showing up when I launch program
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
            this.okButton.Enabled = true;

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

            this.typeComboBox.SelectedIndexChanged += new EventHandler(TypeComboBox__SelectedIndexChanged);

            this.cancelButton.Click += new EventHandler(CancelButton__Click);
            this.okButton.Click += new EventHandler(OkButton__Click);

            this.freshmanRadioButton.CheckedChanged += new EventHandler(ClassRadioButton__CheckedChanged); 
            this.sophomoreRadioButton.CheckedChanged += new EventHandler(ClassRadioButton__CheckedChanged);
            this.juniorRadioButton.CheckedChanged += new EventHandler(ClassRadioButton__CheckedChanged);
            this.seniorRadioButton.CheckedChanged += new EventHandler(ClassRadioButton__CheckedChanged); 




            // after all contols are configured then we can manipulate the data

            this.nameTextBox.Text = person.name;
            this.emailTextBox.Text = person.email;
            this.ageTextBox.Text = person.age.ToString();
            this.licTextBox.Text = person.LicenseId.ToString();

            if (person.GetType() == typeof(Student))
            {
                this.typeComboBox.SelectedIndex = 0;

                Student student = (Student)person;
                this.gpaTextBox.Text = student.gpa.ToString();

                if(person.name == "") //when we initially have a person we are adding and not editing they
                                      //dont have a name (defulat name was not set) so we want a default year since noththing will be selected**
                {
                    student.eCollegeYear = collegeYear.senior; //we can't use person because it's only in a student enumerated type**
                }

                switch (student.eCollegeYear) //we set the college year in the ok button click method so now if we want to edit the same person
                    //again and we reload the person then we have their collegeyear that we stored so we can check which one it was from the switch statement**
                {
                    case collegeYear.freshman:
                        this.freshmanRadioButton.Checked = true; //we have to specifically access from the enumerated
                        //type to see which of the 4 options it was because student only contains one of those options
                        //which was chosen and we need to have all 4 options to see which one was selcted
                        //this is only when we first enter the form though in the ok button is where
                        //we edit it*****
                        break;

                    case collegeYear.sophomore:
                        this.sophomoreRadioButton.Checked = true;
                        break;

                    case collegeYear.junior:
                        this.juniorRadioButton.Checked = true;
                        break;

                    case collegeYear.senior:
                        this.seniorRadioButton.Checked = true;
                        break;
                }


            }
            else
            {
                this.typeComboBox.SelectedIndex = 1;

                Teacher teacher = (Teacher)person;
                this.specTextBox.Text = teacher.specialty;
            }


            

            if(person.name == "")
            {
                person.eGender = genderPronoun.them; //is this how we access because it's used in teacher
                    //and student so we have to use person for both cases**
            }

            switch(person.eGender)
            {
                case genderPronoun.him:
                    this.himRadioButton.Checked = true;
                    break;

                case genderPronoun.her:
                    this.herRadioButton.Checked = true;
                    break;

                case genderPronoun.them:
                    this.themRadioButton.Checked = true;
                    break;
            }
           

            this.Show();

        }

        private void ClassRadioButton__CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked)
            {
                if(rb == this.freshmanRadioButton)
                {
                    this.classLabel.Text = "Class of 2024";
                }

                if (rb == this.sophomoreRadioButton)
                {
                    this.classLabel.Text = "Class of 2023"; //how does this work when we seelct radio
                    //buttons because for senior it displays class of 2020 and not 2024**
                }

                if (rb == this.juniorRadioButton)
                {
                    this.classLabel.Text = "Class of 2022";
                }

                if (rb == this.seniorRadioButton)
                {
                    this.classLabel.Text = "Class of 2021";
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

            if (this.himRadioButton.Checked)
            {
                person.eGender = genderPronoun.him; //now we set the actual radio button to what was selected
                //when we press ok so it gets saved when we save the person as well as when we are editing it selects
                //what we have currently selected*****
            }

            if (this.herRadioButton.Checked)
            {
                person.eGender = genderPronoun.her;
            }

            if (this.themRadioButton.Checked)
            {
                person.eGender = genderPronoun.them;
            }

            if (person.GetType() == typeof(Student))
            {
                student.gpa = Convert.ToDouble(this.gpaTextBox.Text);

                if (this.freshmanRadioButton.Checked)
                {
                    student.eCollegeYear = collegeYear.freshman;
                }


                if (this.sophomoreRadioButton.Checked)
                {
                    student.eCollegeYear = collegeYear.sophomore;
                }



                if (this.juniorRadioButton.Checked)
                {
                    student.eCollegeYear = collegeYear.junior;
                }



                if (this.seniorRadioButton.Checked) //can we also do else if instead of doing if over and over**
                {
                    student.eCollegeYear = collegeYear.senior;
                }


            }
            else
            {
                teacher.specialty = this.specTextBox.Text;
            }

            Globals.people[person.email] = person;

            if( this.Owner != null)
            {
                this.Owner.Enabled = true;
                this.Owner.Focus();

                IListView listView = (IListView)this.Owner;
                listView.PaintListView(person.email);
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

                this.classGroupBox.Visible = true; //sets the groupbox and radio buttons to
                //be shown if its a student**

                if (!this.freshmanRadioButton.Checked && !this.sophomoreRadioButton.Checked && !this.juniorRadioButton.Checked && !this.seniorRadioButton.Checked)
                {
                    this.seniorRadioButton.Checked = true;
                    //for this part does it just make it so that if the index is changed to student and nothing is seclted
                    //we want to make a default**
                    //also if we had a student before and set their year to freshman then we changed the selected index to a teacher then when we switch back
                    //to student again would the student freshman radio button we selected still be selected or would no**
                }

            }
            else
            {
                this.specialtyLabel.Visible = true;
                this.specTextBox.Visible = true;

                this.gpaTextBox.Tag = true;

                this.gpaLabel.Visible = false;
                this.gpaTextBox.Visible = false;

                this.specTextBox.Tag = (this.specTextBox.Text.Length > 0);

                this.classGroupBox.Visible = false; //if its a teacher we dont want it to show**
            }

            ValidateAll();
        }

        private void TxtBoxEmpty__TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if ( tb.Text.Length == 0)
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
            if (tb.Text.Length == 0)
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
