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


/*
 * Unit 4: Data structures
 * For the final exam it covers what we do in this unit and question 1 is writing our own stack class
 * that implements a stack and question 2 is making our own queue class that implements a queue 
 * and question 2 is taking a digraph (wieghted directed graphs) and we will learn how to represent this graph
 * by using adjacency matrix or graph
 * using the console application in 3 we are going to write a depth first search which goes through
 * the graph and writes the values from the start to finish in order and we will use 
 * diskjstras shortest path algorithm and most of it will be code provided to implement the questions 
 * create a console class with a singleton class to load some game settings for a player
 * what 2 specific tarvaeral method question
 * true or false whether the code will copy the node to the end of a linked list
 * complete the code to have a delegate method point to the math.round method and also give all
 * abriviated lambda expressions and only have to write one delegate method example but for each additional one there
 * are extra points 
 * questions 10 is true or false questions 
 * 
 * 
 * 
 * we will be using JS visualization page and for a homework we will be given windows forms application and 
 * make buttons that do different assignements (create a linked list for digits 1-10 and once we have written it and run it
 * we have an excersize which launches our web browser control and shows us the linked list with the data we have filled in)
 * 
 * 
 * Stack data type:
 * provided to use by c# and it's an array except it's a very restricted array and only specific functionality of an array
 * and in an array we can have a list of values in the array and access any one of those values by index and for stacks
 * we can only access the last or most recent item addes to an array (last in first out LIFO) tower or hanoi is like a stack
 * if we have n disks it takes 2 to the n - 1 moves to solve the puzzle**
 * solution of tower of hanoi is recursive solutions and we take each collection of disks and for ecach set of 3 disks we can define
 * how those 3 disks are solved and with any number of disks we can do it recursively**
 * we can specify how many blocks are on the first post and we can have program autosolve and see the output and it will take 31 moves which is 
 * 2 to the 5 minus 1 (16 moves)**
 * we start with 5 disks on first post then move the first 2 disks onto our spare post B then we want to get 3 disks moved onto post C which is out destination then
 * 4 didks onto post B then 5 disks onto our destination post C (3 disks at a time)
 * 
 * the stack datatype in c# is defined by new Stack<datatype the stack holds (only 1 datatype)>();**
 *in our case its the number of disks so its an int**
 *can we have collections in a stack like an array being stack values or linked lists**
 *for each post we have a stack of integers within the dictionary we have the**
 *
 *with a stack we can push data onto the top of the stack and peek at the data thats on the top of the data and there is a pop method that removes the method off
 *the top of the stack and when we start our game we push all of our disks onto post A 
 *
 *we have 3 didks on post A and start from A (souce post) and move to post C (destination post) and keep doing recursively and if we try to move
 *a disk thats too large like moving 3 to a one then we say they cant do that because 3 is larger than 1 and the source and destination post is sotred
 *and to see for that we can peek at the stack at the source and destination post and if the top disk on the source post is less than the destionation post
 *it knows its bigger and lets us know we cant move it otherwise if we can move it we pop from that post and push it onto the new post (where does it 
 *tell us that a value is bigger thsn the other and that we cant move**
 *
 *all the disks need to be moved to post C and the count tells us how many elements are in our stack (stack has a count property to tell us length of stack)**
 *put a floor on a stack and if we have 3 disks on our post (blocks) then we put block 4 as a floor on the bottom of the post so that
 *we always have 1 block on each post so we dont have to worry about empty stack because we cant read data in it and we cant peek then if its empty because
 *there would be a null value** (the base for each post counts as 1 block)**
 *
 *we can solve the tower of hanoi by using a queue (first in first out FIFO) the first person at the cashier gets served and everyone bheind first person has to wait
 *and the person has to work with first person in the line at any time we define a queue in c# by using the Queue<string[]> name or vairbale which is the list**
 *of the moves to solve the puzzle and it will contain the source and destination post whihc is a 2D array)**
 *(does it have to take a list or an array every time or can it take only one value for stacks and queues)**
 *to add items to our queue we use enqueue (adds it to the back) to remove items from a queue dequeue (removes from the front (the item that has been in the queue
 *the longest)
 *
 *stack is like brwoser history when we press back button we are going to the most recent oage we are at and it pops off the last link we were at to go back 
 *(last in first out in our list of urls) and a queue is a multiplayer game and if we are in the waiting room the person who waited the longest will get in first
 *queue also has a peek method and peek at the first item in the queue and it also had a count property that returns the total number of items in the queue**
 *to populate our queue with out moves to solve the game we pass the user if they want to autosolve and if they say yes we call the gamesolver method where we pass
 *in our disks (blocks) and all of the posts and in our gamaesolver we want to recursivley for our 3 possiblities from a to c and we can move from 
 *a to c using b as spare or a to b using c as spare and going frmo b to c using a as the spare (3 possbilities)  and each time along the way we add
 *the from and the to as the strings as the commands of moving from which post to the destination post and adding that as the post in our queue 
 *
 *linked lists:
 *another generic data type LinkedList<object> name (it uses <> for generic datatype)**
 *with an array when we added elements to an array we had to create a new array that had 11 numbers that copied our 10 numbers then added our new number if we wanted
 *to add a new number to our array and same thing to remove and create ana rray with one less number we have to recreate the array as well
 *for linked list they are a chain of data and if we want to insert a new piece of data we break the chain where we want to insert it and 
 *add it to the chain in a linked list each data in the linked list is a node and the node contains the data stored and pointers that point to the next node
 *and the previous node (double linked list with link to next and orevious node) our node that has 12 is poiintng to node that has 99 and if we want to put a new node**
 *then we change 12 node point to node 37 and have our 37 point to node 99 and all we need to do is insert wherever we want to the new piece of data**
 *readings through the list we can only read through the start to end and its ineffeicent because for arrays we could just index but for linked lists**
 *we have to go through everything** linked lists are efficient for adding and removing but inefficent for accessing specific data (have to go
 *through everything) while array is good for**
 *getting specici data but ineffiencet for adding and removing (have to make new array each time we want to add or remove)**
 *
 *to create a lninked list of strings we say LinkedList<string> sentence  = new LinkedList<string>(); (can we make linked lists, stacks, and queues
 *lists and arrays or is it only one datatype like int or string) linked list is a class so we have to do the new operator
 *and have an equal sign we could also have a linked list based on our array of strings by passing the array in the constructor in the () ater ther = sign**
 *we can add new strings to end of linked list by using .addlast to add the node at the end of the linked list**
 *to add to beginning we do .addfirst which adds new node to beginning of node**
 * 
 * 
 */