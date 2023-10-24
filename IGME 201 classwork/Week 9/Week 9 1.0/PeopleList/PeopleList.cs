using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//we delete the control and make a windows form by going to solution then press add then form**
//listview control is used for the class libraries we use and
//the resulting product is a list of people with teachers and students and we can add people and if we press
//enter on one of the people then we can edit the person
//the list view contorl is the same view the****

//the list view control allows us to view by list, icons, details view(we will be using),etc.
//we have a listview control with peole listview and the name i the prop. are the name of the field in the class**
//columns for the name, email, etc. (stroed in columns prop. of the list view) (if we click on dots to look at the collection
//for the columns we can see the headers for each and always look at prop. in alphabetical order)**

//for each of our column headers we have the name of the header (field??)** and the name of the actual box and the alignement
//of the columns**

//to add a new column header we do the add we are still where the 3 dots tab is in column and we
//can add a major header for the student and if we wanted to show it as the second instead of 5th then we can click arrow to move it up
//and when we click ok, it moves the header

//we always add text so we can see the label(what do the other two names do)**
//we can also press remove in the 3 dots tab as well to remove the column if we want
//we have to dith as well to display the width in the list view control
//outside of the 3 dots in the actual property, we can have gridlines or not and we can allow multi select but for now we 
//want them to select one person at a time**
//the view property allows us to change the icons and by default it gives us large icon and we need to set it to detaiils**
//to get icons to show**


namespace PeopleList
{
    public partial class PeopleList : Form
    {

        //we want to be able to create our sample code (our sample data) and to do that we want another dll
        //people class global dll will contain the list of actual people**

        //we now want to add peopleappglobals as a reference (rebuild solution) and we need to acccess people
        //lib again here and not courses because**

        //and we put using statement above for the peopleappglobals and the peoplelib**
        
        
        public PeopleList()
        {
            InitializeComponent(); //put all code below this**

            Globals.AppPeopleSampleData(); //this gets the sample data from**

            //pressing enter checks for keydown and when we double click it uses itemactivate eventhandler** 

            //we also need buttons to add and remove a person in the designer
            //now set up delegate methods for list view**

            this.peopleListView.KeyDown += new KeyEventHandler(PeopleListView__KeyDown);//write delegate method when we press enter
            this.peopleListView.ItemActivate += new EventHandler(PeopleListView__ItemActivate);
            this.addButton.click += new EventHandler(AddButton__Click);
            this.removeButton.Click += new EventHandler(RemoveButtom__Click);
            this.exitButton.Click += new EventHandler(ExitButton__Click); //what do these do**

        }
    }
}
