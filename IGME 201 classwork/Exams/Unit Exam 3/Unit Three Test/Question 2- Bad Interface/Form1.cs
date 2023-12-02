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


namespace Question_2__Bad_Interface
{
    public delegate void ChangeTextBoxDelegate();

    // Class: Form1
    // Author: Kashaf Ahmed
    // Purpose: Main form for Flamingo interface that sets up delegates (events) for if the radio button was
    //checked, if the search button was clicked, and if the exit button was clicked. Also, I set up the thread
    //here for if anything is typed, make it say flamingo instead within the textbox. When the user tries to type something
    //in the textbox it always will say flamingo, when the user presses search it will take them to another form which is a 
    //web browser control that shows a flamingo video, when the user presses the radio button it will take them to a form full
    //of images where they can hover over the images to change the background color of the form (user can only press the radio button once
    //and once they exit that form they can't press the radio button to access it again and they have to restart the application),
    //and for each form we can exit with the bar on the top of the screen with the x button but on the main form the user has
    //to guess which button is the real exit button.
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

            this.exitButton.Click += new EventHandler(ExitButton__Click);

            this.FormClosing += new FormClosingEventHandler(Form__FormClosing);

            this.Show();

            thread.Start();

        } 


        // Method: Form__FormClosing
        // Author: Kashaf Ahmed
        // Purpose: Aborts the thread
        // Restrictions: None
        private void Form__FormClosing(object sender, FormClosingEventArgs e)
        {
           
            thread.Abort();
        }
        // Method: ExitButton__Click
        // Author: Kashaf Ahmed
        // Purpose: Closes the application when the user presses the exit button (you have to find the right
        //button to exit the form though)
        // Restrictions: None
        private void ExitButton__Click(object sender, EventArgs e)
        {
            
            Application.Exit();
            
        }

        // Method: SearchButton__Click
        // Author: Kashaf Ahmed
        // Purpose: If the search button was clicked we want to show a new form which is a flamingo video
        // Restrictions: None
        private void SearchButton__Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        // Method: RadioButton__CheckedChanged
        // Author: Kashaf Ahmed
        // Purpose: If the radio button was checked we want to show a new form with images 
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
        //all the time
        // Restrictions: None
        public void ChangeTextBox()
        {
            if(this.textBox.Text != "flamingo")
            {
                this.textBox.Text = "flamingo";

            }
          
        }


         //Method: TextBoxListener
         //Author: Kashaf Ahmed
         //Purpose: Sets up the delegate method for the thread 
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
