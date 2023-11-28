using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;


//I tried using the thread to make the textbox always say "flamingo" whenever we type something in and my program closes every time I start it without the 
//debugger so I am confused on why that's the case?(1)
//For my link in my form2 I am trying to put a link to the youtubers channel but it's not working when I want to show it possibly because
//the web browser is too old so I was wondering if it was still possible to show the youtube channel or would I have to do something else when the
//user clicks the search button?(2)
//do we need application.exit delegate if we have the x button enabled on the top left for form2 and form3 (3)
//is it ok if my documentation is within my comments in C# because on the exam it says to submit a document(4)
//I know that the button, searchbox, radio button, and pictureboxes count as a control but the web browser would also still count as 1 control right? (5)

//should we have mouse leave as well in form3 because it works when we only have mouse enter so I was just wondering if it's necessary or not(6)
//should we still do a document completeed for navigating to a browser or is it ok to just navigate within the constructor(7)

namespace Question_2__Bad_Interface
{
    public delegate void ChangeTextBoxDelegate();

    // Class: Form1
    // Author: Kashaf Ahmed
    // Purpose: Main form for Flamingo interface that sets up delegates (events) for if the radio button was
    //checked, if the search button was clicked, and if the exit button was clicked. Also, I set up the thread
    //here for if anything is typed, make it say flamingo instead within the textbox**
    //Why I chose this theme: I like watching flamingo and I thought why not there was not really much of a reason
    //as to why I chose this theme other than that.
    // Restrictions: None
    public partial class Form1 : Form
    {
        Thread thread;
        public Form1()
        {
            InitializeComponent();

            this.radioButton.CheckedChanged += new EventHandler(RadioButton__CheckedChanged);
            this.searchButton.Click += new EventHandler(SearchButton__Click);

            ThreadStart threadStart = new ThreadStart(TextBoxListener);
            thread = new Thread(threadStart);
            thread.Start();

            this.exitButton.Click += new EventHandler(ExitButton__Click);

            this.Show();

        }

        // Method: ExitButton__Click
        // Author: Kashaf Ahmed
        // Purpose: Closes the application when the user presses the exit button and closes the thread (you have to find the right
        //button to exit the form though)
        // Restrictions: None
        private void ExitButton__Click(object sender, EventArgs e)
        {
            //thread.Abort();
            Application.Exit();
        }

        // Method: SearchButton__Click
        // Author: Kashaf Ahmed
        // Purpose: If the search button was clicked we want to show a new form
        // Restrictions: None
        private void SearchButton__Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        // Method: RadioButton__CheckedChanged
        // Author: Kashaf Ahmed
        // Purpose: If the radio button was checked we want to show a new form
        // Restrictions: None
        private void RadioButton__CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked)
            {

                Form3 form3 = new Form3();
                form3.ShowDialog();

            }
        }


        // Method: ChangeTextBox
        // Author: Kashaf Ahmed
        // Purpose: Delegate method for the thread so that whenever the user types something the text will say flamingo 
        //all the time**
        // Restrictions: None
        public void ChangeTextBox()
        {
            this.textBox.Text = "flamingo";
        }


         //Method: TextBoxListener
         //Author: Kashaf Ahmed
         //Purpose: Sets up the delegate method for the thread**
         //Restrictions: None
        public void TextBoxListener()
        {
            ChangeTextBoxDelegate changeTextBoxDelegate;
            changeTextBoxDelegate = new ChangeTextBoxDelegate(ChangeTextBox);
        
            while (true)
            {
                Invoke(changeTextBoxDelegate);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
