using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//take away the x button on top left of screen at the end**

//why is my webbrowser have empty space when we change the postition of the bars**
//the site is different on the top is that ok ow which link should I use**

//if we change the radio button after we get everything correct is it ok 
//if it navigates to their wikepedia site or should the gif always be there after
//they guess everything right regardless of it they change the radio button same for
//the party radio buttons**

//check to see if everything is met when we enter everything correctly**
//and we don't do validation but we can still enter just numbers when it's correct right and that when we type in 34
//the results for when everything is correct don't show but if we type in 3 for last value then it shows up**


namespace Presidents
{
    // Class: Form1
    // Author: Kashaf Ahmed
    // Purpose: Create a presidents application that shows information about a certain president when the radio button is 
    // clicked and when we start to input the number president the timer starts and we have to input the numbers before the timer
    // ends otherwise we can't exit the application and the timer restarts and our progress is lost. The constructor sets up the delegate methods
    // to validate the textboxes and set up their tooltips to say "which number president?" I also set up the tags for each president so we can ensure
    // the user enters the correct values as well as set the default president to be selected and the delegates for the images if they are hovered over or not.
    // I also set the checkchanged for if a radio button was selected for each president and party and set up the delegate for when the web browser
    // is done loading. Finally, I set up the delegates for the timer and exit button and disabled the exit button.
    // Restrictions: None
    public partial class PresidentsForm : Form
    {
        bool timerStartEnd = false; //boolean to see if we can start timer or not based on if user starts typing into any one of the textboxes
        public PresidentsForm()
        {
            InitializeComponent();


            try
            {
                // Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.2; WOW64; Trident / 7.0; .NET4.0C; .NET4.0E; .NET CLR 2.0.50727; .NET CLR 3.0.30729; .NET CLR 3.5.30729; wbx 1.0.0)
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(
                    @"SOFTWARE\\WOW6432Node\\Microsoft\\Internet Explorer\\MAIN\\FeatureControl\\FEATURE_BROWSER_EMULATION",
                    true);
                key.SetValue(Application.ExecutablePath.Replace(Application.StartupPath + "\\", ""), 12001, Microsoft.Win32.RegistryValueKind.DWord);
                key.Close();
            }
            catch
            {

            }


            this.webBrowser.ScriptErrorsSuppressed = true;

            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    control.TextChanged += new EventHandler(TxtBoxEmpty__TextChanged);
                    control.Validating += new CancelEventHandler(TxtBoxEmpty__Validating);
                    control.KeyPress += new KeyPressEventHandler(TxtBoxNum__KeyPress);
                    control.Leave += new EventHandler(TxtBox__Leave);
                    toolTip.SetToolTip(control, "Which # President?");

                }
            }

            harrisonTextBox.Tag = 23; 
            rooseveltTextBox.Tag = 32;
            clintonTextBox.Tag = 42;
            buchananTextBox.Tag = 15;
            pierceTextBox.Tag = 14;
            bushTextBox.Tag = 43;
            obamaTextBox.Tag = 44;
            kennedyTextBox.Tag = 35;
            mckinleyTextBox.Tag = 25;
            reaganTextBox.Tag = 40;
            eisenhowerTextBox.Tag = 34;
            vanburenTextBox.Tag = 8;
            washingtonTextBox.Tag = 1;
            adamsTextBox.Tag = 2;
            rooseveltTextBox2.Tag = 26;
            jeffersonTextBox.Tag = 3;

            this.harrisonButton.Checked = true;
            this.pictureBox.ImageLocation = "https://people.rit.edu/dxsigm/BenjaminHarrison.jpeg";
            this.allButton.Checked = true;
            this.webBrowser.Navigate("https://en.wikipedia.org/wiki/Benjamin_Harrison");
            this.browserGroupBox.Text = "https://en.wikipedia.org/wiki/Benjamin_Harrison";
            

            this.harrisonButton.CheckedChanged += new EventHandler(PresidentButton__CheckedChanged);
            this.rooseveltButton.CheckedChanged += new EventHandler(PresidentButton__CheckedChanged);
            this.clintonButton.CheckedChanged += new EventHandler(PresidentButton__CheckedChanged);
            this.buchananButton.CheckedChanged += new EventHandler(PresidentButton__CheckedChanged);
            this.pierceButton.CheckedChanged += new EventHandler(PresidentButton__CheckedChanged);
            this.bushButton.CheckedChanged += new EventHandler(PresidentButton__CheckedChanged);
            this.obamaButton.CheckedChanged += new EventHandler(PresidentButton__CheckedChanged);
            this.kennedyButton.CheckedChanged += new EventHandler(PresidentButton__CheckedChanged);
            this.mckinleyButton.CheckedChanged += new EventHandler(PresidentButton__CheckedChanged);
            this.reaganButton.CheckedChanged += new EventHandler(PresidentButton__CheckedChanged);
            this.eisenhowerButton.CheckedChanged += new EventHandler(PresidentButton__CheckedChanged);
            this.vanburenButton.CheckedChanged += new EventHandler(PresidentButton__CheckedChanged);
            this.washingtonButton.CheckedChanged += new EventHandler(PresidentButton__CheckedChanged);
            this.adamsButton.CheckedChanged += new EventHandler(PresidentButton__CheckedChanged);
            this.rooseveltButton2.CheckedChanged += new EventHandler(PresidentButton__CheckedChanged);
            this.jeffersonButton.CheckedChanged += new EventHandler(PresidentButton__CheckedChanged);

            this.pictureBox.MouseEnter += new EventHandler(PictureBox__MouseEnter);
            this.pictureBox.MouseLeave += new EventHandler(PictureBox__MouseLeave);

            this.allButton.CheckedChanged += new EventHandler(PartyButton__CheckedChanged);
            this.democratButton.CheckedChanged += new EventHandler(PartyButton__CheckedChanged);
            this.republicanButton.CheckedChanged += new EventHandler(PartyButton__CheckedChanged);
            this.democraticRepublicanButton.CheckedChanged += new EventHandler(PartyButton__CheckedChanged);
            this.federalistButton.CheckedChanged += new EventHandler(PartyButton__CheckedChanged);

           
           
            this.webBrowser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(WebBrowser__DocumentCompleted);

            this.exitButton.Click += new EventHandler(ExitButton__Click); 
            this.exitButton.Enabled = false;

            this.timer1.Interval = 1000;
            this.timer1.Tick += new EventHandler(Timer1__Tick); //check interval**

            this.progressBar.Maximum = 240;
            this.progressBar.Value = this.progressBar.Maximum;

        }

        // Method: Timer1__Tick
        // Author: Kashaf Ahmed
        // Purpose: Set up a boolean to see if all the textboxes were set to their proper values then if the progress bar 
        // is not equal to 0 then we decrement the timer and we go through each textbox and check if the textboxes are not equal
        // to their tags and if they are not we set the boolean to false. Otherwise, we check if the boolean is true and if it is we
        // stop the timer, navigate to the fireworks gif, enable the exit button, and go through all of the textboxes and disable 
        // the validation so the user can go back and enter random number if they want to. Finally, if the timer runs out then we
        // stop the timer, reset the textboes values to be 0, then reset the timer.
        // Restrictions: None
        private void Timer1__Tick(object sender, EventArgs e)
        {
            bool isAllCorrect = true;
            if (this.progressBar.Value != 0)
            {
                this.progressBar.Value--; 
                foreach (Control control in this.Controls)
                {
                    if(control is TextBox)
                    {
                        if (control.Text.ToString() != control.Tag.ToString())
                        {
                            isAllCorrect = false; 
                           
                        }
                    }
                }
                if(isAllCorrect == true)
                {
                    timer1.Stop();
                    this.webBrowser.Navigate("https://media.giphy.com/media/TmT51OyQLFD7a/giphy.gif");
                    this.browserGroupBox.Text = "https://media.giphy.com/media/TmT51OyQLFD7a/giphy.gif"; 
                    this.exitButton.Enabled = true;
                    foreach (Control control in this.Controls)
                    {
                        if (control is TextBox)
                        {
                            control.TextChanged -= TxtBoxEmpty__TextChanged;
                            control.Validating -= TxtBoxEmpty__Validating;
                            control.Leave -= TxtBox__Leave;

                           

                        }
                    }

                 


                }
            }
            else if(this.progressBar.Value == 0)
            {
                this.timer1.Stop();
                timerStartEnd = false;

                foreach(Control control in this.Controls)
                {
                    if(control is TextBox)
                    {
                        control.Text = "0";
                    }
                }

                this.progressBar.Value = this.progressBar.Maximum;

            }

        }

        // Method: ExitButton__Click
        // Author: Kashaf Ahmed
        // Purpose: Exit the application if the exit button is clicked
        // Restrictions: None
        private void ExitButton__Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Method: PresidentButton__CheckedChanged
        // Author: Kashaf Ahmed
        // Purpose: We check which radio button is selected and for each president if their radio button is changed 
        // then we change the picture to show the president, navigate to their web browser, and change the text of the web browser to 
        // the link of their page.
        // Restrictions: None
        private void PresidentButton__CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender; //does it matter if I did a bunch of if statements or is it bad**

            if (rb.Checked)
            {
                if(rb == this.harrisonButton)
                {
                    this.pictureBox.ImageLocation = "https://people.rit.edu/dxsigm/BenjaminHarrison.jpeg";
                    this.webBrowser.Navigate("https://en.wikipedia.org/wiki/Benjamin_Harrison");
                    this.browserGroupBox.Text = "https://en.wikipedia.org/wiki/Benjamin_Harrison";
                }

                if (rb == this.rooseveltButton)
                {
                    this.pictureBox.ImageLocation = "https://people.rit.edu/dxsigm/FranklinDRoosevelt.jpeg";
                    this.webBrowser.Navigate("https://en.wikipedia.org/wiki/Franklin_D._Roosevelt");
                    this.browserGroupBox.Text = "https://en.wikipedia.org/wiki/Franklin_D._Roosevelt";
                }

                if (rb == this.clintonButton)
                {
                    this.pictureBox.ImageLocation = "https://people.rit.edu/dxsigm/WilliamJClinton.jpeg";
                    this.webBrowser.Navigate("https://en.wikipedia.org/wiki/Bill_Clinton");
                    this.browserGroupBox.Text = "https://en.wikipedia.org/wiki/Bill_Clinton";
                }

                if (rb == this.buchananButton)
                {
                    this.pictureBox.ImageLocation = "https://people.rit.edu/dxsigm/JamesBuchanan.jpeg";
                    this.webBrowser.Navigate("https://en.wikipedia.org/wiki/James_Buchanan");
                    this.browserGroupBox.Text = "https://en.wikipedia.org/wiki/James_Buchanan";
                }

                if (rb == this.pierceButton)
                {
                    this.pictureBox.ImageLocation = "https://people.rit.edu/dxsigm/FranklinPierce.jpeg";
                    this.webBrowser.Navigate("https://en.wikipedia.org/wiki/Franklin_Pierce");
                    this.browserGroupBox.Text = "https://en.wikipedia.org/wiki/Franklin_Pierce";
                }

                if (rb == this.bushButton)
                {
                    this.pictureBox.ImageLocation = "https://people.rit.edu/dxsigm/GeorgeWBush.jpeg";
                    this.webBrowser.Navigate("https://en.wikipedia.org/wiki/George_W._Bush");
                    this.browserGroupBox.Text = "https://en.wikipedia.org/wiki/George_W._Bush";
               
                }

                if (rb == this.obamaButton)
                {
                    this.pictureBox.ImageLocation = "https://people.rit.edu/dxsigm/BarackObama.png";
                    this.webBrowser.Navigate("https://en.wikipedia.org/wiki/Presidency_of_Barack_Obama");
                    this.browserGroupBox.Text = "https://en.wikipedia.org/wiki/Presidency_of_Barack_Obama";
                }

                if (rb == this.kennedyButton)
                {
                    this.pictureBox.ImageLocation = "https://people.rit.edu/dxsigm/JohnFKennedy.jpeg";
                    this.webBrowser.Navigate("https://en.wikipedia.org/wiki/John_F._Kennedy");
                    this.browserGroupBox.Text = "https://en.wikipedia.org/wiki/John_F._Kennedy";
                }

                if (rb == this.mckinleyButton)
                {
                    this.pictureBox.ImageLocation = "https://people.rit.edu/dxsigm/WilliamMcKinley.jpeg";
                    this.webBrowser.Navigate("https://en.wikipedia.org/wiki/William_McKinley");
                    this.browserGroupBox.Text = "https://en.wikipedia.org/wiki/William_McKinley";
                }

                if (rb == this.reaganButton)
                {
                    this.pictureBox.ImageLocation = "https://people.rit.edu/dxsigm/RonaldReagan.jpeg";
                    this.webBrowser.Navigate("https://en.wikipedia.org/wiki/Ronald_Reagan");
                    this.browserGroupBox.Text = "https://en.wikipedia.org/wiki/Ronald_Reagan";
                }

                if (rb == this.eisenhowerButton)
                {
                    this.pictureBox.ImageLocation = "https://people.rit.edu/dxsigm/DwightDEisenhower.jpeg";
                    this.webBrowser.Navigate("https://en.wikipedia.org/wiki/Dwight_D._Eisenhower");
                    this.browserGroupBox.Text = "https://en.wikipedia.org/wiki/Dwight_D._Eisenhower";
                }

                if (rb == this.vanburenButton)
                {
                    this.pictureBox.ImageLocation = "https://people.rit.edu/dxsigm/MartinVanBuren.jpeg";
                    this.webBrowser.Navigate("https://en.wikipedia.org/wiki/Martin_Van_Buren");
                    this.browserGroupBox.Text = "https://en.wikipedia.org/wiki/Martin_Van_Buren";
                }

                if (rb == this.washingtonButton)
                {
                    this.pictureBox.ImageLocation = "https://people.rit.edu/dxsigm/GeorgeWashington.jpeg";
                    this.webBrowser.Navigate("https://en.wikipedia.org/wiki/George_Washington");
                    this.browserGroupBox.Text = "https://en.wikipedia.org/wiki/George_Washington";
                }

                if (rb == this.adamsButton)
                {
                    this.pictureBox.ImageLocation = "https://people.rit.edu/dxsigm/JohnAdams.jpeg";
                    this.webBrowser.Navigate("https://en.wikipedia.org/wiki/John_Adams");
                    this.browserGroupBox.Text = "https://en.wikipedia.org/wiki/John_Adams";
                }

                if (rb == this.rooseveltButton2) 
                {
                    this.pictureBox.ImageLocation = "https://people.rit.edu/dxsigm/TheodoreRoosevelt.jpeg";
                    this.webBrowser.Navigate("https://en.wikipedia.org/wiki/Theodore_Roosevelt");
                    this.browserGroupBox.Text = "https://en.wikipedia.org/wiki/Theodore_Roosevelt";
                }

                if (rb == this.jeffersonButton)
                {
                    this.pictureBox.ImageLocation = "https://people.rit.edu/dxsigm/ThomasJefferson.jpeg";
                    this.webBrowser.Navigate("https://en.wikipedia.org/wiki/Thomas_Jefferson");
                    this.browserGroupBox.Text = "https://en.wikipedia.org/wiki/Thomas_Jefferson";
                }

            }
            //links are a bit different but stilll wikepedia is that ok**

        }

        // Method: PartyButton__CheckedChanged
        // Author: Kashaf Ahmed
        // Purpose: If the party radio button is changed we filter the presidents according to their party and only show those presidents according to their
        // party and hide the rest of them
        // Restrictions: None
        private void PartyButton__CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;

            if (rb.Checked)
            {
                if (rb == this.allButton)
                {
                    this.harrisonButton.Visible = true;
                    this.harrisonButton.Checked= true;
                    this.rooseveltButton.Visible = true;
                    this.clintonButton.Visible = true;
                    this.buchananButton.Visible = true;
                    this.pierceButton.Visible = true;
                    this.bushButton.Visible = true;
                    this.obamaButton.Visible = true;
                    this.kennedyButton.Visible = true;
                    this.mckinleyButton.Visible = true;
                    this.reaganButton.Visible = true;
                    this.eisenhowerButton.Visible = true;
                    this.vanburenButton.Visible = true;
                    this.washingtonButton.Visible = true;
                    this.adamsButton.Visible = true;
                    this.rooseveltButton2.Visible = true;
                    this.jeffersonButton.Visible = true;
                }

                else if (rb == this.democratButton)
                {

                    this.harrisonButton.Visible = false;
                    this.rooseveltButton.Visible = true;
                    this.rooseveltButton.Checked = true;
                    this.clintonButton.Visible = true;
                    this.buchananButton.Visible = true;
                    this.pierceButton.Visible = true;
                    this.bushButton.Visible = false;
                    this.obamaButton.Visible = true;
                    this.kennedyButton.Visible = true;
                    this.mckinleyButton.Visible = false;
                    this.reaganButton.Visible = false;
                    this.eisenhowerButton.Visible = false;
                    this.vanburenButton.Visible = true;
                    this.washingtonButton.Visible = false;
                    this.adamsButton.Visible = false;
                    this.rooseveltButton2.Visible = false;
                    this.jeffersonButton.Visible = false;
                }


                else if (rb == this.republicanButton)
                {
                    this.harrisonButton.Visible = true;
                    this.harrisonButton.Checked = true;
                    this.bushButton.Visible = true;
                    this.mckinleyButton.Visible = true;
                    this.reaganButton.Visible = true;
                    this.eisenhowerButton.Visible = true;
                    this.rooseveltButton2.Visible = true;
                    this.rooseveltButton.Visible = false;
                    this.clintonButton.Visible = false;
                    this.buchananButton.Visible = false;
                    this.pierceButton.Visible = false;
                    this.obamaButton.Visible = false;
                    this.kennedyButton.Visible = false;
                    this.vanburenButton.Visible = false;
                    this.washingtonButton.Visible = false;
                    this.adamsButton.Visible = false;
                    this.jeffersonButton.Visible = false;
                }

                else if (rb == this.democraticRepublicanButton)
                {
                    this.jeffersonButton.Checked = true;
                    this.jeffersonButton.Visible = true;
                    this.harrisonButton.Visible = false;
                    this.rooseveltButton.Visible = false;
                    this.clintonButton.Visible = false;
                    this.buchananButton.Visible = false;
                    this.pierceButton.Visible = false;
                    this.bushButton.Visible = false;
                    this.obamaButton.Visible = false;
                    this.kennedyButton.Visible = false;
                    this.mckinleyButton.Visible = false;
                    this.reaganButton.Visible = false;
                    this.eisenhowerButton.Visible = false;
                    this.vanburenButton.Visible = false;
                    this.washingtonButton.Visible = false;
                    this.adamsButton.Visible = false;
                    this.rooseveltButton2.Visible = false;

                }

                else if (rb == this.federalistButton)
                {
                    this.washingtonButton.Visible = true;
                    this.washingtonButton.Checked = true;
                    this.adamsButton.Visible = true;
                    this.harrisonButton.Visible = false;
                    this.rooseveltButton.Visible = false;
                    this.clintonButton.Visible = false;
                    this.buchananButton.Visible = false;
                    this.pierceButton.Visible = false;
                    this.bushButton.Visible = false;
                    this.obamaButton.Visible = false;
                    this.kennedyButton.Visible = false;
                    this.mckinleyButton.Visible = false;
                    this.reaganButton.Visible = false;
                    this.eisenhowerButton.Visible = false;
                    this.vanburenButton.Visible = false;
                    this.rooseveltButton2.Visible = false;
                    this.jeffersonButton.Visible = false;


                }

            }

        }



        // Method: PictureBox__MouseEnter
        // Author: Kashaf Ahmed
        // Purpose: If the image of the president is hovered over then we increase the width and the height of the image by 2
        // Restrictions: None
        private void PictureBox__MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox.Width *= 2;
            this.pictureBox.Height *= 2;
        }

        // Method: PictureBox__MouseLeave
        // Author: Kashaf Ahmed
        // Purpose: If we stop hovering over the image of the president put the picture back to it's original size
        // Restrictions: None
        private void PictureBox__MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox.Width /= 2;
            this.pictureBox.Height /= 2;
        }

        // Method: TxtBoxEmpty__TextChanged
        // Author: Kashaf Ahmed
        // Purpose: If the text is equal to 0 or nothing then we don't set an error to validate the textbox, we also see if we can start the timer
        // if a textbox had text entered into it.
        // Restrictions: None
        private void TxtBoxEmpty__TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
        
            if(tb.Text == "0" || tb.Text == "")
            { 
                this.errorProvider1.SetError(tb, null);
                
            
               
            
            }
           
            else
            {
                this.errorProvider1.SetError(tb, null);
              
            }

            if (timerStartEnd == true)
            {
                this.timer1.Start(); 

            }

        }


        // Method: TxtBox__Leave
        // Author: Kashaf Ahmed
        // Purpose: If the user tries to exit the textbox and the text is empty we just reset the text to 0, otherwise if it's something else
        // and not equal to the president's tag for the textbox then we set an error.
        // Restrictions: None
        private void TxtBox__Leave(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if(tb.Text == "")
            {
                this.errorProvider1.SetError(tb, null);
                tb.Text = "0";
            }
            else if(tb.Text != tb.Tag.ToString())
            {
                this.errorProvider1.SetError(tb, "That is the wrong number.");
            }

        }


        // Method: TxtBoxEmpty__Validating
        // Author: Kashaf Ahmed
        // Purpose: If the textbox text is 0 or an empty space we let the user leave the textbox,
        // otherwise if the text does not equal the tag for the textbox then
        // we don't allow the user to leave the textbox until they get it right.
        // Otherwise we let them leave the textbox.
        // Restrictions: None
        private void TxtBoxEmpty__Validating(object sender, CancelEventArgs e)
        {
           
            TextBox tb = (TextBox)sender; 
            if(tb.Text == "0" || tb.Text == "")
            {
            
                this.errorProvider1.SetError(tb, null);
            
                e.Cancel = false;
            
                
            
                
            }
            else if (tb.Text != tb.Tag.ToString())
            {
               
                e.Cancel = true;
             
            }
            else
            {
                this.errorProvider1.SetError(tb, null);
                e.Cancel = false;
               
            }

           
        }

        // Method: TxtBoxNum__KeyPress
        // Author: Kashaf Ahmed
        // Purpose: Makes sure the user can type only numbers into the textboxes and only numbers will show up
        // Restrictions: None
        private void TxtBoxNum__KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            e.Handled = true;
            timerStartEnd = true;
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == '\b')
            {
               
                e.Handled = false;
                
            }

            
        }

        // Method:  WebBrowser__DocumentCompleted
        // Author: Kashaf Ahmed
        // Purpose: When the web brwoser is done loading we want to get all of the anchor tags and set it to "Professor Schuh for President!" 
        // We do that by getting the array of anchor tags then go through them and set the tooltip for each anchor tag.
        // Restrictions: None
        private void WebBrowser__DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser wb = (WebBrowser)sender;
            HtmlElementCollection htmlElementCollection;

            htmlElementCollection = wb.Document.GetElementsByTagName("a");
            foreach(HtmlElement htmlElement in htmlElementCollection)
            {
                htmlElement.SetAttribute("title","Professor Schuh for President!");
            }
        }

        private void PresidentsForm_Load(object sender, EventArgs e)
        {

        }
    }
}
