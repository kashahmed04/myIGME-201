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

    /*
     * For exam 3 we should list all of the controls that are in the application and explanation of how they behave and the psuedocode which
     * contains the constructor then any delegate methods
     * and we take the pesudeocode and make it into an application 
     * 
     * we can also get the images from the banjo page peole.rit.edu/dxsigm/link for the president and we do the image location like we did 
     * with the happy face
     */

    //image property for picture box and we import the image 

    //size mode zoom does

    //we have 2 picture boxes on top of each other for a happy and sad face 
    //we can do document outline if there are controls that overlap ontop of each other like we have with the pictureboxes for the happy and sad face
    //anything we want to put in the properties of the designer we should hard code it here in the constructor so we can see the code 
    public partial class Sherlock : Form
    {
        public Sherlock()
        {
            InitializeComponent();

            this.happyPictureBox.ImageLocation = "https://st.depositphotos.com/1001911/1222/v/950/depositphotos_12221489-stock-illustration-big-smile-emoticon.jpg"; 
            //one way was so set it in the designer in the image and one was to set the image location with a url for an image (the image location from a web browser)

            this.refLabel.Text = "The quick brown fox jumped over the lazy dog"; //set it here instead of the text in the
            //properties window for the label

            //countdown label is not visible
            this.countdownLabel.Visible = false;

            //countdown label = 20
            countdownLabel.Text = "20";

            //textbox.KeyPress event handler 
            this.textBox.KeyPress += new KeyPressEventHandler(TextBox__KeyPress);

            //exit button is disabled
            this.exitButton.Enabled = false;

            //timer interval = 1000
            timer1.Interval = 1000;

            //timer tick event handler
            timer1.Tick += new EventHandler(Timer1__Tick);

            this.webBrowser1.ScriptErrorsSuppressed = true; //prevents us to get the locked menu that shows up when we start the program
            //we should always put this before the webbrowserdocument completed

            //navidate web browser to url
            this.webBrowser1.Navigate("people.rit.edu/dxsigm/sherlock.html");

            //webbrowser documetn complted event handler
            this.webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(WebBrowser1__DocumentCompleted);

            // picturebox is not visible
            sadPictureBox.Visible = false;

            // exit button click event handler
            happyPictureBox.Visible = false;




        }


        private void TextBox__KeyPress(object sender, KeyPressEventArgs e)
        {
            //to see that our timer has started if it is still 20 that means the timer has not started 
            //have a boolean value for when we do it in presidents then set it to false when we start the timer then set it back to true when we 
            //reset the timer**
            if(countdownLabel.Text == "20")
            {
                //start the timer and make the countdown label true 
                timer1.Start();
                countdownLabel.Visible = true;
            }

            //make sure they can only type the next character in the string so if the text at the current position in our reference label
            //we want to make sure by going through each key they pressed by the index of the string we have and makes sure it matches the key character
            if (refLabel.Text[textBox.TextLength] == e.KeyChar)
            {
                e.Handled = false; //let windows handle it since they types in correct character

                sadPictureBox.Visible = false;
                happyPictureBox.Visible = true; //set the happy picture box because they were correct 


                //windows only adds the key to the textbox when the method ends 
                //when we add the charcter they typed to the textbox we can enable the exti button
                if(textBox.Text + e.KeyChar == refLabel.Text)
                {
                    exitButton.Enabled = true;
                    textBox.KeyPress -= TextBox__KeyPress;

                }
            }
            else
            {
                //they did not type the correct character
                e.Handled = true; //we want to handle it so windows does not show the character on the screen
                sadPictureBox.Visible = true;
                happyPictureBox.Visible = false;
            }

        }

        //we want to elapse each second as they enter text in the texbox 
        private void Timer1__Tick(object sender, EventArgs e)
        {
            //if we are about the run out of time we want to stop the timer and want to clear out the progress the user had made in the textbox 
            if(countdownLabel.Text == "1")
            {
                timer1.Stop();
                this.textBox.Text = ""; //reset the textbox 
                countdownLabel.Visible = false; //take away the countdown label
                countdownLabel.Text = "20";

                sadPictureBox.Visible = false;
                happyPictureBox.Visible = false;

            }
            else
            {
                //we want to countdown from 20 as an integer then make it as a string each time the timer ticks
                countdownLabel.Text = (Int32.Parse(countdownLabel.Text) - 1).ToString();
            }
        }

        private void WebBrowser1__DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser wb = (WebBrowser)sender;
            //handle clicking on the anchor tags (2 of them)
            HtmlElementCollection htmlElementCollection = wb.Document.GetElementsByTagName("a"); //returns an array of the tags
                                                                                                 //
            foreach(HtmlElement htmlElement in htmlElementCollection)
            {
                htmlElement.Click += new HtmlElementEventHandler(Link__Click); //method for when they click on the anchor tag 
            }

            //wb is also our web browser contorl 

            wb.DocumentCompleted -= WebBrowser1__DocumentCompleted; //subtract our delegate method from this document completed 
            //because then each time we clicked a link it would call out document completed delegate method again and 
            //as another click event handler to the anchor tag (first time it adds a click to our anchor tags then if we click on link 1 it will
            //go into our document completed method again because we are on the same page and add a second click event handler to every anhor tag and each
            //anchor tag will call the link click twice and it makes 2 changes to the link when we click it)**
            //when we click it again it adds a third change instead of second so asfter we click it once we remove the delegate so it
            //only changes the elemtn the first time and not every time we click (only do this when the use the # for an anchor tag)**

            

            //anytime we browse to the web make sure to add the registry after intiialize component

        }


        //our anchor tags dont have a url they go to and if we want to stay on the same webpage and process an anchor tag we use the # symbol and it will
        //reload the docuemnt in the browser control so every time we click the link it will call the docuemnt completed evenhandler again and we dont want that to 
        //happen ebcause it will add to the click event to each of the anchor tags and it will**
        private void Link__Click(object sender, HtmlElementEventArgs e)
        {
            // fetch the element that was clicked
            HtmlElement htmlElement = (HtmlElement)sender;

            // if the current text contains "again"
            if (htmlElement.InnerText.Contains("again"))
            {
                // change the text and style to last phrase
                htmlElement.InnerText = "I asked you to stop it.";
                htmlElement.Style = "color: purple; font-size: 2.5rem;";

                // remove the click event handler from this element
                //dont want the clicked to work anymore because its the last input
                htmlElement.Click -= Link__Click;
            }
            else if (htmlElement.InnerText.Contains("clicked"))
            {
                // change the text and style to the second phrase
                htmlElement.InnerText = "You clicked me again.  Now stop it.";
                htmlElement.Style = "color: red; font-size: 2rem;";
            }
            else
            {
                // chane the text and style to the first phrase
                htmlElement.InnerText = "You clicked me!";
                htmlElement.Style = "color: blue; font-size: 1.5rem;";
            }
        }

        private void refLabel_Click(object sender, EventArgs e)
        {
            
        }
    }
}
