using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Profile_Display
{
    public partial class DisplayProfile : Form
    {
        public DisplayProfile()
        {
            //get the listview fixed because there is an extra column****
            InitializeComponent();

            this.dmButton.Click += new EventHandler(DmButton__Click); //go to their chat from the message class (inherit from this class only)
                                                                      //and access the users time,rank,games,username,bio,
                                                                      //and profile picture from the list (data base)
           // this.statsListView.MouseEnter += new EventHandler(StatsListView__MouseEnter);//when the hover on the stats maybe make it bigger
           // this.statsListView.MouseLeave += new EventHandler(StatsListView__MouseLeave);//when the user stops hovering make the listview go back to it's orignial size 

            //display all info. from the lists here

        }

        private void DmButton__Click(object sender, EventArgs e)
        {
            //open the chat for the specific form
            //maybe close this form completely or just disbale it until the user closes out of the message class 
        }

        //private void StatsListView__MouseEnter(object sender, EventArgs e)
        //{
        //    this.statsListView.Width *= 2;
        //    this.statsListView.Height *= 2;
        //}
        //
        //private void StatsListView__MouseLeave(object sender, EventArgs e)
        //{
        //    this.statsListView.Width /= 2;
        //    this.statsListView.Height /= 2;
        //}




        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void photoGroupBox_Enter(object sender, EventArgs e)
        {

        }

        private void gameListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void peopleListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void statsListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dmButton_Click(object sender, EventArgs e)
        {

        }
    }
}
