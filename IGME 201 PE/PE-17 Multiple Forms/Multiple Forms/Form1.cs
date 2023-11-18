using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multiple_Forms
{
    // Class: Form1
    // Author: Kashaf Ahmed
    // Purpose: Takes in user input for the range of numbers
    //they want to guess from so we can pass it into the GameForm class
    //for them to guess a number
    // Restrictions: None
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.startButton.Click += new EventHandler(StartButton__Click);
            this.lowTextBox.KeyPress += new KeyPressEventHandler(LowTextBox__KeyPress);
            this.highTextBox.KeyPress += new KeyPressEventHandler(HighTextBox__KeyPress);

        }


        // Method:  LowTextBox__KeyPress
        // Author: Kashaf Ahmed
        // Purpose: Makes sure the user enters a whole number
        // Restrictions: None
        private void LowTextBox__KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            e.Handled = true;
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == '\b')
            {
                e.Handled = false;
               
            }
           

        }

        // Method: HighTextBox__KeyPress
        // Author: Kashaf Ahmed
        // Purpose: Makes sure the user enters a whole number
        // Restrictions: None
        private void HighTextBox__KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            e.Handled = true;
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == '\b')
            {
                e.Handled = false;
               
            }
            

        }


        // Method: StartButton__Click
        // Author: Kashaf Ahmed
        // Purpose: We convert their numbers and see if it's within the default
        //range and if it is we pass those numbers into the GameForm and show the GameForm,
        //otherwise we tell them the numbers are invalid
        // Restrictions: None
        private void StartButton__Click(object sender, EventArgs e)
        {
            bool bConv;
            int lowNumber = 0;
            int highNumber = 0;

            // convert the strings entered in lowTextBox and highTextBox
            // to lowNumber and highNumber Int32.Parse
            lowNumber = Int32.Parse(this.lowTextBox.Text);
            highNumber = Int32.Parse(this.highTextBox.Text);


            // if not a valid range
            if (lowNumber < 1 || highNumber > 100)
            {
                // show a dialog that the numbers are not valid
                MessageBox.Show("The numbers are invalid.");
            }
            else
            {
                // otherwise we're good
                // create a form object of the second form 
                // passing in the number range
                GameForm gameForm = new GameForm(lowNumber, highNumber);

                // display the form as a modal dialog, 
                // which makes the first form inactive
                gameForm.ShowDialog();
            }
        }

    }

}
