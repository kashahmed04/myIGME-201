using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sherlock
{   //forecolor is used for textcolor**
    public partial class Sherlock : Form
    {
        public Sherlock()
        {
            InitializeComponent();

            this.refLabel.Text = "The quick brown fox jumped over the lazy dog"; //set it here instead of the text in the
            //properties window for the label

            //countdown label is not visible
            this.countdownLabel.Visible = false;

            //countdown label = 20**
            countdownLabel.Text = "20";

            //textbox.KeyPress event handler 
            this.textBox.KeyPress += new KeyPressEventHandler(TextBox__KeyPress);

            //exit button is disabled
            this.exitButton.Enabled = false;

            //timer interval = 1,000
            timer1.Interval = 1000;

            //timer tick event handler
            timer1.Tick += new EventHandler(timer1__Tick);

            //navidate web browser to url
            this.webBrowser1.Navigate("people.rit.edu/dxsigm/serhlock.html");

            //webbrowser documetn complted event handler
            this.webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(WebBrowser1__DocumentCompleted);




        }

        private void refLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
