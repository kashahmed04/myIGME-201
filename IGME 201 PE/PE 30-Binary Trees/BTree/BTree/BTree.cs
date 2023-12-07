using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BinaryTreeVisualizer;

namespace BTree
{
    public partial class BTreeForm : Form
    {
        public BTreeForm()
        {
            try
            {
                // Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.2; WOW64; Trident / 7.0; .NET4.0C; .NET4.0E; .NET CLR 2.0.50727; .NET CLR 3.0.30729; .NET CLR 3.5.30729; wbx 1.0.0)
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(
                    @"SOFTWARE\\WOW6432Node\\Microsoft\\Internet Explorer\\MAIN\\FeatureControl\\FEATURE_BROWSER_EMULATION",
                    true);
                key.SetValue(Application.ExecutablePath.Replace(Application.StartupPath + "\\", ""), 11001, Microsoft.Win32.RegistryValueKind.DWord);
                key.Close();
            }
            catch
            {
            }

            InitializeComponent();

            this.randomButton.Click += new EventHandler(RandomButton__Click);
            this.unbalancedButton.Click += new EventHandler(UnbalancedButton__Click);
            this.primedButton.Click += new EventHandler(PrimedButton__Click);
            this.button1.Click += new EventHandler(Exercise1__Click);
            this.button2.Click += new EventHandler(Exercise2__Click);
            this.button3.Click += new EventHandler(Exercise3__Click);
            this.button4.Click += new EventHandler(Exercise4__Click);
            this.button5.Click += new EventHandler(Exercise5__Click);
            this.button6.Click += new EventHandler(Exercise6__Click);
            this.button7.Click += new EventHandler(Exercise7__Click);
            this.exitButton.Click += new EventHandler(ExitButton__Click);

            // give the BTree class objects access to Form1
            BTree.bTreeForm = this;
        }

        private void ExitButton__Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void RandomButton__Click(object sender, EventArgs e)
        {
            // load a tree with random numbers
            BTree root = null;
            BTree node;
            Random random = new Random();

            this.richTextBox.Clear();

            for (int i = 0; i < 10; ++i)
            {
                node = new BTree(random.Next(100), root);

                if (i == 0)
                {
                    root = node;
                }
            }

            this.richTextBox.Text += "\nAscending order:";
            BTree.TraverseAscending(root);

            this.richTextBox.Text += "\nDescending order:";
            BTree.TraverseDescending(root);


            VisualizeBinaryTree visualizeBinaryTree = new VisualizeBinaryTree(root);
        }

        private void UnbalancedButton__Click(object sender, EventArgs e)
        {
            // load a tree in data-ascending order, 
            // which will cause it to be unbalanced and poor-performing
            BTree root = null;
            BTree node;

            this.richTextBox.Clear();

            for (int i = 0; i < 10; ++i)
            {
                node = new BTree(i, root);

                if (i == 0)
                {
                    root = node;
                }
            }

            this.richTextBox.Text += "\n";
            BTree.TraverseAscending(root);

            VisualizeBinaryTree visualizeBinaryTree = new VisualizeBinaryTree(root);
        }

        private void PrimedButton__Click(object sender, EventArgs e)
        {
            // Prime a tree to hold alphabetical information
            //why would this be considered primed if isData is set to true by default for all values**

            this.richTextBox.Clear();

            BTree node = null;
            BTree root = null;
            
            node = new BTree("M", null); 
            root = node;

            node = new BTree("F", root);
            node = new BTree("C", root);
            node = new BTree("B", root);
            node = new BTree("A", root);
            node = new BTree("E", root);
            node = new BTree("D", root);

            node = new BTree("J", root);
            node = new BTree("I", root);
            node = new BTree("H", root);
            node = new BTree("G", root);
            node = new BTree("L", root);
            node = new BTree("K", root);

            node = new BTree("P", root);
            node = new BTree("O", root);
            node = new BTree("N", root);
            node = new BTree("T", root);
            node = new BTree("S", root);
            node = new BTree("R", root);
            node = new BTree("Q", root);

            node = new BTree("W", root);
            node = new BTree("V", root);
            node = new BTree("U", root);
            node = new BTree("X", root);
            node = new BTree("Y", root);
            node = new BTree("Z", root);

            this.richTextBox.Text += "\n";            
            BTree.TraverseAscending(root);

            this.richTextBox.Text += "\n";
            BTree.TraverseDescending(root);

            VisualizeBinaryTree visualizeBinaryTree = new VisualizeBinaryTree(root);
        }

        private void Exercise1__Click(object sender, EventArgs e)
        {
            // Exercise #1
            // insert 30 random numbers between 1 and 51

            BTree root = null; //we need a root node 
            BTree node; //node we are adding 
            Random random = new Random();

            this.richTextBox.Clear(); //clear the rich textbox 

            // Your code here

            for (int i = 0; i < 30; ++i)
            {
                node = new BTree(random.Next(51) + 1, root); 

                if (i == 0)
                {
                    root = node; 
                }
            }

            this.richTextBox.Text += "\n";

            BTree.TraverseAscending(root); //print our our tree in ascending order from low to high**

            VisualizeBinaryTree visualizeBinaryTree = new VisualizeBinaryTree(root);
        }

        private void Exercise2__Click(object sender, EventArgs e)
        {
            // Exercise #2
            // prime the tree for numbers between 1 and 51
            // with 7 optimally distributed data points (setting isData = false) 
            // then insert 30 random numbers between 1 and 51

            //insert 7 data points that are not data and it's just used to create skeleton of tree and we want to know our 7 data points
            //we want to have value in the middle of 1 and 51 (25 or 26) that would be the root of our tree then between 1 and 25 the middle number would be 12
            //and the middle between 25 and 51 would be 37 and between 1 and 12 would be 6 and between 12 and 25 would be 18 between 25 and 37 would be 31 and between
            //37 and 51 would be 43 (gets us log2(N) performance)

            BTree root = null;
            BTree node;
            Random random = new Random();

            this.richTextBox.Clear();


            // Your code here
            //create our root node which is median between 1-51
            node = new BTree(25, root, false); //we pass in a tree node as the root**
            root = node; //create the node and set the root to our node**
                         //pass in root to each of those new nodes**
            node = new BTree(12, root, false);
            node = new BTree(37, root, false); 
            node = new BTree(6, root, false);
            node = new BTree(18, root, false); //is this median value of 25 and 12 now for the right child** (how does it work)
            node = new BTree(31, root, false); //is this the median value between 25 and 37 for the left child** (how does it work)
            node = new BTree(43, root, false); //we want to create our tree so it's going to perform for those random numbers**
                                               //and thsee are the children of the root node and we set the is data to false because we don't want to use those nodes for data and
                                               //we inster those 30 random numbers**

            //our data is a phone book but M is not an entry in our phonebook and we will eventually add the data in them eventually and each entry has data in it
            //but its not the data in the phone book 
            //when its an unbalanced tree we populate tree without priming it first but for primed trees there is no data and we sort first then
            //add the data** 

           

            for (int i = 0; i < 30; ++i)
            {
                node = new BTree(random.Next(1, 52), root); //how does this know to add the values in accordance to the median node and 
                //how does it work when isData is true and not false**
            }

            this.richTextBox.Text += "\n";

            BTree.TraverseAscending(root);

            VisualizeBinaryTree visualizeBinaryTree = new VisualizeBinaryTree(root);
        }

        private void Exercise3__Click(object sender, EventArgs e)
        {
            // Exercise #3
            // insert 15 random uppercase strings

            BTree root = null;
            BTree node;
            Random random = new Random();

            this.richTextBox.Clear();

            // Your code here
            node = new BTree("THE", root); 
            root = node; 
            node = new BTree("AT", root);
            node = new BTree("IN", root);
            node = new BTree("OUT", root);
            node = new BTree("YES", root);
            node = new BTree("NO", root);
            node = new BTree("ZEBRA", root);
            node = new BTree("EGGS", root);
            node = new BTree("MONKEY", root);
            node = new BTree("CAT", root);
            node = new BTree("DOG", root);
            node = new BTree("FISH", root);
            node = new BTree("TIGER", root);
            node = new BTree("LION", root);
            node = new BTree("PIZZA", root);



            this.richTextBox.Text += "\n";

            BTree.TraverseAscending(root); //calling the in order traversal and prints out tree
            //and first line is the order which we are writing the data to the tree and the line above is the next line 

            VisualizeBinaryTree visualizeBinaryTree = new VisualizeBinaryTree(root);
        }

        private void Exercise4__Click(object sender, EventArgs e)
        {
            // Exercise #4
            // prime the tree using the code in Button3_Click()
            // then insert the 15 random uppercase strings from Exercise #3

            this.richTextBox.Clear();

            BTree node = null;
            BTree root = null;

            // Your code here
            
            //node = new BTree("MONKEY", root, false); 
            //root = node;
            //node = new BTree("FISH", root, false);
            //node = new BTree("CAT", root, false);
            //node = new BTree("AT", root, false);
            //node = new BTree("EGGS", root, false);
            //node = new BTree("DOG", root, false);
            //node = new BTree("IN", root, false);
            //node = new BTree("LION", root, false);
            //node = new BTree("PIZZA", root, false);
            //node = new BTree("OUT", root, false);
            //node = new BTree("NO", root, false);
            //node = new BTree("THE", root, false);
            //node = new BTree("TIGER", root, false);
            //node = new BTree("YES", root, false);
            //node = new BTree("ZEBRA", root, false);
            ////add letters in the right order otherwise we get unbalanced tree 
            ////root node needs to be median then get median of each half of the data 
            //node = new BTree("JUGGLING", root, false);
            //node = new BTree("ICE", root);
            //node = new BTree("GAMES", root);
            //node = new BTree("SKATEBOARD", root);
            //node = new BTree("RAMP", root);
            //node = new BTree("CAR", root);
            //node = new BTree("HAMMOCK", root);
            //node = new BTree("CHICKEN WINGS", root);
            //node = new BTree("LOOK", root);
            //node = new BTree("FIFA", root);
            //node = new BTree("ZELDA", root);
            //node = new BTree("MARIO", root);
            //node = new BTree("LUIGI", root);
            //node = new BTree("ANIMAL CROSSING", root);
            //node = new BTree("SUMMER", root);

            node = new BTree("M", null);
            root = node;

            node = new BTree("F", root, false);
            node = new BTree("C", root, false);
            node = new BTree("B", root, false);
            node = new BTree("A", root, false);
            node = new BTree("E", root, false);
            node = new BTree("D", root, false);

            node = new BTree("J", root, false);
            node = new BTree("I", root, false);
            node = new BTree("H", root, false);
            node = new BTree("G", root, false);
            node = new BTree("L", root, false);
            node = new BTree("K", root, false);

            node = new BTree("P", root, false);
            node = new BTree("O", root, false);
            node = new BTree("N", root, false);
            node = new BTree("T", root, false);
            node = new BTree("S", root, false);
            node = new BTree("R", root, false);
            node = new BTree("Q", root, false);

            node = new BTree("W", root, false);
            node = new BTree("V", root, false);
            node = new BTree("U", root, false);
            node = new BTree("X", root, false);
            node = new BTree("Y", root, false);
            node = new BTree("Z", root, false);
            //false because they are seed nodes and not actual data then add actual data after which (then add previous strings from above)

            node = new BTree("THE", root);
            node = new BTree("AT", root);
            node = new BTree("IN", root);
            node = new BTree("OUT", root);
            node = new BTree("YES", root);
            node = new BTree("NO", root);
            node = new BTree("ZEBRA", root);
            node = new BTree("EGGS", root);
            node = new BTree("MONKEY", root);
            node = new BTree("CAT", root);
            node = new BTree("DOG", root);
            node = new BTree("FISH", root);
            node = new BTree("TIGER", root);
            node = new BTree("LION", root);
            node = new BTree("PIZZA", root);




            this.richTextBox.Text += "\n";
            BTree.TraverseAscending(root);

            this.richTextBox.Text += "\n";
            BTree.TraverseDescending(root);

            VisualizeBinaryTree visualizeBinaryTree = new VisualizeBinaryTree(root);
        }

        private void Exercise5__Click(object sender, EventArgs e)
        {
            // Exercise #5
            // use the code in Button3_Click to add the 26 letters to the tree
            // then remove nodes "C", "I" and "A" 
            // using this code to remove each node:
            //     // create new freestanding node for "C"
            //     nodeToDelete = new BTree("C", null);
            //     BTree.DeleteNode(nodeToDelete, root);
            // add the newline and call BTree.TraverseAscending() after each delete

            this.richTextBox.Clear();

            BTree node = null;
            BTree nodeToDelete = null;
            BTree root = null;

            // Your code here
            node = new BTree("M", null);
            root = node;

            node = new BTree("F", root); 
            node = new BTree("C", root);
            nodeToDelete = new BTree("C", null);
            BTree.DeleteNode(nodeToDelete, root);
            BTree.TraverseAscending(root);
            node = new BTree("B", root);
            node = new BTree("A", root);
            nodeToDelete = new BTree("A", null);
            BTree.DeleteNode(nodeToDelete, root);
            BTree.TraverseAscending(root);
            node = new BTree("E", root);
            node = new BTree("D", root);

            node = new BTree("J", root);
            node = new BTree("I", root);
            nodeToDelete = new BTree("I", null);
            BTree.DeleteNode(nodeToDelete, root);
            BTree.TraverseAscending(root);
            node = new BTree("H", root);
            node = new BTree("G", root);
            node = new BTree("L", root);
            node = new BTree("K", root);

            node = new BTree("P", root);
            node = new BTree("O", root);
            node = new BTree("N", root);
            node = new BTree("T", root);
            node = new BTree("S", root);
            node = new BTree("R", root);
            node = new BTree("Q", root);

            node = new BTree("W", root);
            node = new BTree("V", root);
            node = new BTree("U", root);
            node = new BTree("X", root);
            node = new BTree("Y", root);
            node = new BTree("Z", root);

            this.richTextBox.Text += "\n";
            BTree.TraverseAscending(root);

            VisualizeBinaryTree visualizeBinaryTree = new VisualizeBinaryTree(root);
        }

        private void Exercise6__Click(object sender, EventArgs e)
        {
            // Exercise #6
            // there are operator overloads to compare 2 BTree objects for BTree.data being string or int
            // enhance the overloads to support the Person object and compare using Person.age using:                
            //     if (a.data.GetType() == typeof(Person))

           


            // create at least 15 new Person objects which correspond to members of your family
            // insert them into the tree starting with yourself (thsee start off as random then the next part is making them primed right)**
            this.richTextBox.Clear();

            BTree node = null;
            BTree root = null;

            // the Person class is defined below
            Person person = null;

            // Your code here
            person = new Person("Kash",19);
            node = new BTree(person, root);
            root = node;
            person = new Person("Violet", 19); 
            node = new BTree(person, root);
            person = new Person("Eliana", 19);
            node = new BTree(person, root);
            person = new Person("Maria", 25);
            node = new BTree(person, root);
            person = new Person("Amelia", 25);
            node = new BTree(person, root);
            person = new Person("Kayla", 30);
            node = new BTree(person, root);
            person = new Person("Linochska", 30);
            node = new BTree(person, root);
            person = new Person("Connor", 60);
            node = new BTree(person, root);
            person = new Person("Neme", 60);
            node = new BTree(person, root);
            person = new Person("Minna", 80);
            node = new BTree(person, root);
            person = new Person("Hope", 85);
            node = new BTree(person, root);
            person = new Person("Delfino", 48);
            node = new BTree(person, root);
            person = new Person("Jenson", 24);
            node = new BTree(person, root);
            person = new Person("Nicole", 19);
            node = new BTree(person, root);
            person = new Person("Rio", 30);
            node = new BTree(person, root);




            this.richTextBox.Text += "\n";
            BTree.TraverseAscending(root);

            VisualizeBinaryTree visualizeBinaryTree = new VisualizeBinaryTree(root);
        }

        private void Exercise7__Click(object sender, EventArgs e)
        {
            // Exercise #7
            // given the age range of people in Exercise #6, 
            // prime the tree with nodes containing Person objects (set isData = false for the seed nodes)
            // containing the optimal ages to balance the tree
            this.richTextBox.Clear();

            BTree node = null;
            BTree root = null;

            // the Person class is defined below
            Person person = null;

            // Your code here

            person = new Person("Delfino", 48);
            node = new BTree(person, root, false);
            root = node;
            person = new Person("Amelia", 25);
            node = new BTree(person, root, false);
            person = new Person("Rio", 30);
            node = new BTree(person, root, false);
            person = new Person("Kash", 19);
            node = new BTree(person, root, false);
            person = new Person("Neme", 60);
            node = new BTree(person, root, false);
            person = new Person("Minna", 80);
            node = new BTree(person, root, false);

            person = new Person("Nicole", 19);
            node = new BTree(person, root);
            person = new Person("Violet", 19);
            node = new BTree(person, root);
            person = new Person("Eliana", 19);
            node = new BTree(person, root);
            person = new Person("Maria", 25);
            node = new BTree(person, root);
            person = new Person("Amelia", 25);
            node = new BTree(person, root);
            person = new Person("Kayla", 30);
            node = new BTree(person, root);
            person = new Person("Linochska", 30);
            node = new BTree(person, root);
            person = new Person("Connor", 60);
            node = new BTree(person, root);
            person = new Person("Hope", 85);
            node = new BTree(person, root);
            person = new Person("Jenson", 24);
            node = new BTree(person, root);


            this.richTextBox.Text += "\n";
            BTree.TraverseAscending(root);

            VisualizeBinaryTree visualizeBinaryTree = new VisualizeBinaryTree(root);
        }
    }
}
