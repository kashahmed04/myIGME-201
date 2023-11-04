using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dyscord
{
    public partial class SettingsForm : Form
    {
        public int myPort;
        public SettingsForm(Form owner, int nport)
        {
            InitializeComponent();

            this.Owner = owner;
            this.CenterToParent();
            this.myPort = nport;
            this.portTextBox.Text = nport.ToString();

            this.startButton.Click += new EventHandler(StartButton__Click);
            this.portTextBox.KeyPress += new KeyPressEventHandler(PortTextBox__KeyPress);



        }

        private void StartButton__Click(object sender, EventArgs e)
        {
            this.myPort = Int32.Parse(this.portTextBox.Text);
            this.Close();
        }

        private void PortTextBox__KeyPress(object sender, KeyPressEventArgs e)
        {
            if(char.IsDigit(e.KeyChar) ||  e.KeyChar == '\b')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true; //do we always have an if or else for the handled and suppress** (prevents the text from not being put on
                //the form if a number is not put in**

                //how do we know when to add another form in our file did we do the same thing for edit person and people list
                //because we were adding something to the main form (person list and we were adding person edit form so we made a new form
                //within that file??)**

            }
        }


    }
}
