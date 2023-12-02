using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Question_2__Bad_Interface
{
    public partial class Form3 : Form
    {


        // Class: Form3
        // Author: Kashaf Ahmed
        // Purpose: When the radio button is checked we open this form and it displays cursed flamingo
        //images and I set the image location for each picture box and event handlers for when we hover over
        //each image so it changes the color of the background. User can press the x button at the top of
        //the screen on the left to exit this form. (You can only press the radio button once though and when you
        //exit that form you can't get back to it unless you restart the application)
        // Restrictions: None
        public Form3()
        {
            InitializeComponent();

            this.pictureBox1.ImageLocation = "https://i.pinimg.com/564x/1f/fa/3b/1ffa3b617df01b290fa2d19ae076f507.jpg";
            this.pictureBox2.ImageLocation = "https://i.pinimg.com/564x/19/2d/da/192dda595ed1b0a53cbe7cac63f5eca7.jpg";
            this.pictureBox4.ImageLocation = "https://i.pinimg.com/564x/10/70/3a/10703a25245f17c7f92a343add74b2c3.jpg";
            this.pictureBox5.ImageLocation = "https://i.pinimg.com/564x/00/64/ec/0064ec06d4c85a6e1e7063bd1a74a5ab.jpg";
            this.pictureBox3.ImageLocation = "https://i.pinimg.com/564x/d6/da/7e/d6da7e02dbf6fa0b1a8a55bcc5bdc709.jpg";
            this.pictureBox6.ImageLocation = "https://i.pinimg.com/564x/06/df/6e/06df6e53fbeac2ed5dda79424d515bff.jpg";

            this.pictureBox1.MouseEnter += new EventHandler(PictureBox1__MouseEnter);

            this.pictureBox2.MouseEnter += new EventHandler(PictureBox2__MouseEnter);

            this.pictureBox4.MouseEnter += new EventHandler(PictureBox3__MouseEnter);

            this.pictureBox5.MouseEnter += new EventHandler(PictureBox4__MouseEnter);

            this.pictureBox3.MouseEnter += new EventHandler(PictureBox5__MouseEnter);

            this.pictureBox6.MouseEnter += new EventHandler(PictureBox6__MouseEnter);

            this.FormClosing += new FormClosingEventHandler(Form__FormClosing);
        }

        // Method: Form__FormClosing
        // Author: Kashaf Ahmed
        // Purpose: Closes the form when the user wants to exit the current form
        // Restrictions: None
        private void Form__FormClosing(object sender, FormClosingEventArgs e)
        {
           
            this.Dispose(); 
        }

        // Method: PictureBox1__MouseEnter
        // Author: Kashaf Ahmed
        // Purpose: Changes the background color to yellow when
        // the first image is hovered over
        // Restrictions: None
        private void PictureBox1__MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.Yellow;
        }


        // Method: PictureBox2__MouseEnter
        // Author: Kashaf Ahmed
        // Purpose: Changes the background color to cyan when
        // the second image is hovered over
        // Restrictions: None
        private void PictureBox2__MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.Cyan;
        }


        // Method: PictureBox3__MouseEnter
        // Author: Kashaf Ahmed
        // Purpose: Changes the background color to lime green when
        // the third image is hovered over
        // Restrictions: None
        private void PictureBox3__MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.LimeGreen;
        }

        // Method: PictureBox4__MouseEnter
        // Author: Kashaf Ahmed
        // Purpose: Changes the background color to orange when
        // the fourth image is hovered over
        // Restrictions: None
        private void PictureBox4__MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.Orange;
        }

        // Method: PictureBox5__MouseEnter
        // Author: Kashaf Ahmed
        // Purpose: Changes the background color to red when
        // the fifth image is hovered over
        // Restrictions: None
        private void PictureBox5__MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.Red;
        }

        // Method: PictureBox6__MouseEnter
        // Author: Kashaf Ahmed
        // Purpose: Changes the background color to hot pink when
        // the sixth image is hovered over
        // Restrictions: None
        private void PictureBox6__MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.HotPink;
        }

    }
}
