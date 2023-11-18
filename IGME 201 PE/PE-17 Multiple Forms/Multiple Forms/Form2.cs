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
    // Class: GameForm
    // Author: Kashaf Ahmed
    // Purpose: Asks the user for input and checks if it's greater or less than
    //the bounds they put in from the main form, it also tells the user how many
    //tries they got it correct in and if they did not guess it correct in time
    //then the program stops and they have to play again
    // Restrictions: None
    public partial class GameForm : Form
    {
        private int nRandom;
        private int lowUserNumber;
        private int highUserNumber;
        private int nGuesses = 0;
        public GameForm(int lowNumber, int highNumber)
        {
            InitializeComponent();

            lowUserNumber = lowNumber;
            highUserNumber = highNumber;

            Random rand = new Random();
            nRandom = rand.Next(lowNumber, highNumber);
            this.guessTextBox.Text = nRandom.ToString();

            this.timer1.Interval = 500;
            this.timer1.Tick += new EventHandler(Timer1__Tick);

            this.progressBar1.Maximum = 45000;
            this.progressBar1.Value = this.progressBar1.Maximum;

            this.timer1.Start();

            this.guessButton.Click += new EventHandler(GuessButton__Click);

            this.guessTextBox.KeyDown += new KeyEventHandler(GuessTextBox__KeyDown);

            this.guessTextBox.KeyPress += new KeyPressEventHandler(GuessTextBox__KeyPress);


        }

        // Method: Timer1__Tick
        // Author: Kashaf Ahmed
        // Purpose: Ticks the timer down by the interval of 500 milliseconds and if the timer runs out we tell the player that
        //they have to play again
        // Restrictions: None

        private void Timer1__Tick(object sender, EventArgs e)
        {
            if (this.progressBar1.Value != 0)
            {
                this.progressBar1.Value -= this.timer1.Interval;
            }
            else if(this.progressBar1.Value == 0)
            {

                this.timer1.Stop();

                this.guessTextBox.Clear();

                this.progressBar1.Value = this.progressBar1.Maximum;

                MessageBox.Show("You have failed please try again"); //nothing runs until the message box is closed because it waits for user input
                //then it runs the rest of the code

                this.Close();

            }
        }

        // Method: GuessTextBox__KeyPress
        // Author: Kashaf Ahmed
        // Purpose: Makes sure the user only enters a whole number
        // Restrictions: None
        private void GuessTextBox__KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            e.Handled = true;
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == '\b')
            {
                e.Handled = false;

            }


        }

        // Method: GuessTextBox__KeyDown
        // Author: Kashaf Ahmed
        // Purpose: If the user presses tner we want to treat that as if they have clicked
        //the guess button
        // Restrictions: None
        private void GuessTextBox__KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GuessButton__Click(sender, e);
            }

        }

        // Method: GuessButton__Click
        // Author: Kashaf Ahmed
        // Purpose: Converts the players guess into an integer and 
        //incremements the turns they have taken and if
        //they got it right we tell them how many turns it took them and
        //we stop the timer and close the form when they close the message box
        //otherwise we check their guess and tell them if it was too high or too low and have them
        //keep guessing until the timer runs out
        // Restrictions: None
        private void GuessButton__Click(object sender, EventArgs e)
        {
            int converted = Int32.Parse(this.guessTextBox.Text);
            nGuesses += 1;
            if (converted == nRandom)
            {

                this.progressBar1.Value = this.progressBar1.Maximum;

                this.timer1.Stop();

                MessageBox.Show($"Woohoo, you got it in {nGuesses} guesses!");

                this.Close();
            }
            else if(converted != nRandom)
            {
                this.timer1.Stop();

                if (converted > this.highUserNumber)
                {
                    this.outputLabel.Text = "Your guess of " + converted.ToString() + " was HIGH";
                    MessageBox.Show("Please try again");
                }
                else if(converted < this.lowUserNumber)
                {
                    this.outputLabel.Text = "Your guess of " + converted.ToString() + " was LOW";
                    MessageBox.Show("Please try again");
                }
                else
                {
                    if(converted > nRandom)
                    {
                        this.outputLabel.Text = "Your guess of " + converted.ToString() + " was HIGH";
                        MessageBox.Show("Please try again");
                    }
                    else if(converted < nRandom)
                    {
                        this.outputLabel.Text = "Your guess of " + converted.ToString() + " was LOW";
                        MessageBox.Show("Please try again");
                    }
                   
                }

                this.timer1.Start();     
            }

        }


    }
}
