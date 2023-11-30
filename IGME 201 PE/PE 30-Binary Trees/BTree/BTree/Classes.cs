using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//c# does not give us tree class and we have to write is ourselves 

namespace BTree
{
    /// 
    ///  Our Binary Tree Class
    ///
    public class BTree
    {
        //////////////////////////////////////////////////////////
        ///  The most important 3 fields of any Binary Search Tree

        //this is the tree (branch) to the left which is the less than child**
        // the "less than" branch off of this node
        public BTree ltChild;

        //this is a tree (branch) to the right which is greater than or equal to the child**
        // the "greater than or equal to" branch off of this node
        public BTree gteChild;

        //the data in our tree for each node or our whole tree**
        // the data contained in this node
        public object data;
        //////////////////////////////////////////////////////////


        // a boolean to indicate if this is actual data or seed data to prime the tree**
        public bool isData;

        // internal counter which is needed by the visualizer
        public int id;

        // access to Form1 to write to the RichTextBox
        public static BTreeForm bTreeForm;

        // keep track of last counter to set this.id
        private static int nLastCntr;


        //////////////////////////////////////////////////////////
        // The constructor which will add the new node to an existing tree
        // if a non-null root is passed in
        // isData defaults to true, but can be set to false if seed data is being added to prime the tree

        //we can pass in the data stored into this node and the root is it exists yet and if the node
        //contains data or not and if we populate tree in a random way (random button does it with values from 1 and 100 and each time its going to add
        //a new value to a tree and it adds then as it gets the values and it follows the rule of the tree and less numbers than the current node go to left but
        //if its greater than or equal to the node then we go to the right**)

        //first number added was 57 which is the root node of our tree and the next number that was added was 64 then it goes to the root and it says its greater
        //than 57 so it goes to the right branch because its greater than 57 next it was 57 so its less than 57 so it goes to the less than branch of the
        //57 and 8 is greater than 7 so it goes to the right of 7 because its less than 57 and for 87 it goes to right of 64 because its greater than 64 and 57
        //we can only create balances tree by inserting numbers in optimal order and it means that the root of the tree should be the median value of our data which
        //is the middle most value in our data so our root node shoud be 50 because it's the middle most value and each node should be the median value 
        //as we move down (we can either sort our data before we insert into tree or instead what is recommended is to add a flag to see if it's data or not
        //and its a way of priming the tree so it performs in an optimal way)**

        //if we want to use a primed tree we want to have our tree structured in a way so that when we do alphabetical search it performs as best as it can 
        //populate middle letter first then F is between A and M and we get the median value each time we move down**

        //if we insert data in our tree we want to insert it in the tree but when we do that we end up with unbalanced tree and if we search for the number 61 its
        //not going to be efficient because root node is 11 and in our game the best guess was 50 to eliminate half of the possibilites (middle range or the data)
        //and in this case the root is 11 which is useless because it's unbalanced and the isData boolean lets us build the tree withour any data and these nodes
        //or not data and they are all set as not data and the tree has no data in it yet  but it has a skeletal structure and it allows us to create our tree
        //in a balanced order then when we put data in the tree will still be balanced so we can exclude half of our tree from our searches when we want to search
        //for specific data (if we dont make it balanced we dont get log(N) performance)**

        //so basically without data stored in the nodes it makes the tree balanced (skeleton) otherwise if theres data it would be unbalanced**

        //the random tree we built because we inserted the random data it was not balanced**
        public BTree(object nData, BTree root, bool isData = true) //if the node contains data or a seed node (skeleton node)** (is this a check or a initialization)**
        {
            //we pass in the data we add to our tree and our root and it cretes a new BTree node and if the root is not null then we 
            //add the node to our root of our tree**
            this.ltChild = null;
            this.gteChild = null;
            this.data = nData;
            this.isData = isData;

            // set internal id which is used by the visualizer
            this.id = nLastCntr;
            ++nLastCntr;

            PrintThisNode(this);

            // if a tree exists to add this node to
            if (root != null)
            {
                AddChildNode(this, root);
            }
        }
        //////////////////////////////////////////////////////////


        //////////////////////////////////////////////////////////
        // overload all operators to compare BTree nodes by int or string data

        //if we wnt to compare 2 nodes we use boolean operators and checks the types of data in the tree so if its an int. then we compare
        //their integers but itf its a string when we compre their strings and if its a person we compare their ages**
        public static bool operator ==(BTree a, BTree b)
        {
            bool returnVal = false;

            try
            {
                if (a.data.GetType() == typeof(int))
                {
                    returnVal = ((int)a.data == (int)b.data);
                }

                if (a.data.GetType() == typeof(string))
                {
                    returnVal = ((string)a.data == (string)b.data);
                }

                if (a.data.GetType() == typeof(Person))
                {
                    Person ap = (Person)a.data;
                    Person bp = (Person)b.data;

                    returnVal = (ap.age == bp.age);
                }
            }
            catch
            {
                returnVal = (a == (object)b);
            }

            return (returnVal);
        }

        public static bool operator !=(BTree a, BTree b)
        {
            bool returnVal = false;

            try
            {
                if (a.data.GetType() == typeof(int))
                {
                    returnVal = ((int)a.data != (int)b.data);
                }

                if (a.data.GetType() == typeof(string))
                {
                    returnVal = ((string)a.data != (string)b.data);
                }

                if (a.data.GetType() == typeof(Person))
                {
                    Person ap = (Person)a.data;
                    Person bp = (Person)b.data;

                    returnVal = (ap.age != bp.age);
                }
            }
            catch
            {
                returnVal = (a != (object)b);
            }

            return (returnVal);
        }

        public static bool operator <(BTree a, BTree b)
        {
            bool returnVal = false;

            try
            {
                if (a.data.GetType() == typeof(int))
                {
                    returnVal = ((int)a.data < (int)b.data);
                }

                if (a.data.GetType() == typeof(string))
                {
                    returnVal = (((string)a.data).CompareTo((string)b.data) < 0);
                }

                if (a.data.GetType() == typeof(Person))
                {
                    Person ap = (Person)a.data;
                    Person bp = (Person)b.data;

                    returnVal = (ap.age < bp.age);
                }
            }
            catch
            {
                returnVal = false;
            }

            return (returnVal);
        }

        public static bool operator >(BTree a, BTree b)
        {
            bool returnVal = false;

            try
            {
                if (a.data.GetType() == typeof(int))
                {
                    returnVal = ((int)a.data > (int)b.data);
                }

                if (a.data.GetType() == typeof(string))
                {
                    returnVal = (((string)a.data).CompareTo((string)b.data) > 0);
                }

                if (a.data.GetType() == typeof(Person))
                {
                    Person ap = (Person)a.data;
                    Person bp = (Person)b.data;

                    returnVal = (ap.age > bp.age);
                }
            }
            catch
            {
                returnVal = false;
            }

            return (returnVal);
        }

        public static bool operator >=(BTree a, BTree b)
        {
            bool returnVal = false;

            try
            {
                if (a.data.GetType() == typeof(int))
                {
                    returnVal = ((int)a.data >= (int)b.data);
                }

                if (a.data.GetType() == typeof(string))
                {
                    returnVal = (((string)a.data).CompareTo((string)b.data) >= 0);
                }

                if (a.data.GetType() == typeof(Person))
                {
                    Person ap = (Person)a.data;
                    Person bp = (Person)b.data;

                    returnVal = (ap.age >= bp.age);
                }
            }
            catch
            {
                returnVal = false;
            }

            return (returnVal);
        }

        public static bool operator <=(BTree a, BTree b)
        {
            bool returnVal = false;

            try
            {
                if (a.data.GetType() == typeof(int))
                {
                    returnVal = ((int)a.data <= (int)b.data);
                }

                if (a.data.GetType() == typeof(string))
                {
                    returnVal = (((string)a.data).CompareTo((string)b.data) <= 0);
                }

                if (a.data.GetType() == typeof(Person))
                {
                    Person ap = (Person)a.data;
                    Person bp = (Person)b.data;

                    returnVal = (ap.age <= bp.age);
                }
            }
            catch
            {
                returnVal = false;
            }

            return (returnVal);
        }
        //////////////////////////////////////////////////////////


        //////////////////////////////////////////////////////////
        /// Recursive AddChildNode method adds BTree nodes to an existing tree
        public static void AddChildNode(BTree newNode, BTree treeNode)
            //we pass in root node and new node thats being added and is this new node greater than or equal to the root node 
            //and we need to check the greater than or equal to child (if there is no branch to the right) then we set the branch
            //equal to the new node otherwise we call addchild node to add to a branch to the right (it adds our node all the way to the right if its greater than the
            //current node)**
        {
            // if the new node >= the tree node
            if (newNode >= treeNode)
            {
                // if there is not a child node greater than or equal to this tree node
                if (treeNode.gteChild == null)
                {
                    // set this node's "greater than or equal to" child to this new node
                    treeNode.gteChild = newNode;
                }
                else
                {
                    // otherwise try to add the new node to the "greater than or equal to" branch
                    AddChildNode(newNode, treeNode.gteChild);
                }
            }
            else
            {
                //if our root node does not have a less than branch we set it equal to the new node otherwise we go through again to go to the left node
                //add that if there is nothing there anymore**
                //does root node refer to parent or children can be a root node too**
                // the new node < this tree node
                if (treeNode.ltChild == null)
                {
                    // set this node's "less than" child to this new node
                    treeNode.ltChild = newNode;
                }
                else
                {
                    // otherwise try to add the new node to the "less than" branch
                    AddChildNode(newNode, treeNode.ltChild);
                }
            }
        }
        //////////////////////////////////////////////////////////


        //////////////////////////////////////////////////////////
        // Delete a node from a tree or branch

        //always pass in the root node (treeNode)(parent on the very top) and the node we are deleting**
        //we need to have a base case which is if we reach the end of the tree and we need to traverse the tree to find the target node 
        //and if the node to delete is less than the parent node then we do recursion to the left than branch and we 
        //delete the node from the less than brannch and if its in the right branch we set our greater than or equal to child to the node to delete 
        //and the tree node (the root node)**
        public static BTree DeleteNode(BTree nodeToDelete, BTree treeNode) //any time we want to delete node use this method with a tree**
        {
            // base case: we reached the end of the tree
            if (treeNode == null)
            {
                return treeNode;
            }

            // traverse the tree to find the target node
            if (nodeToDelete < treeNode)
            {
                treeNode.ltChild = DeleteNode(nodeToDelete, treeNode.ltChild);
            }
            else if (nodeToDelete > treeNode)
            {
                treeNode.gteChild = DeleteNode(nodeToDelete, treeNode.gteChild);
            }
            else
            {
                // this is the node to be deleted  

                // case #1: treeNode has no children
                // case #2: treeNode has one child
                // set treeNode to it's non-null child (if there is one)
                if (treeNode.ltChild == null)
                {
                    return treeNode.gteChild; //if the node has no children (if theres no branch to the left then we return the branch to the right and it gets set**
                    //to the appropriate parent branch and if there is no branch to the right then we return branch to the left and it removed the node we are deleting**
                }
                else if (treeNode.gteChild == null)
                {
                    return treeNode.ltChild;
                }

                // case #3: treeNode has two children
                // Get the in-order successor (smallest value  
                // in the "greater than or equal to" branch)  

                //in order successor to the node we are deleting and walk down through the tree from the greater than or equal to child to find the node to delete 
                //and we need to delete the in order successor and we need to recursivley call the method again to delete the node we want to delete

                //if we want to delete A node then we walk down and find A node and set the less than branch of B to null and it removes the A node(case 1)**
                //if we remove the E node then we walk down to C node and replace the greater than branch to point to D(case 2)**
                //if we want to delete J we need to find F which connects to J then we need to walk down to the greater than branch and find the next value
                //from J which is K and we need to replace J with K but still keep the L off of that node(case 3)**

                // step to the next greater value
                BTree nextValNode = treeNode.gteChild;

                // while not at the end of the branch
                while (nextValNode != null)
                {
                    // replace this "deleted" node with the next sequential data value
                    treeNode.data = nextValNode.data;

                    // walk to next lower value
                    nextValNode = nextValNode.ltChild;
                }

                // delete the in-order successor (which was copied to the "deleted" node)  
                nodeToDelete.data = treeNode.data; //set node of the node we want to delete to the in order successor**
                DeleteNode(nodeToDelete, treeNode.gteChild);
            }

            return treeNode;
        }
        //////////////////////////////////////////////////////////


        //////////////////////////////////////////////////////////
        // Print the contents of this node
        public static void PrintThisNode(BTree node) 
         
        {
            string thisString = null;

            if (node.data.GetType() == typeof(int) ||
                node.data.GetType() == typeof(string))
            {
                thisString = node.data.ToString();
            }

            if (node.data.GetType() == typeof(Person))
            {
                Person person = (Person)node.data;
                thisString = $"{person.age:D03}:{person.name}";
            }

            bTreeForm.richTextBox.Text += " " + thisString;
        }
        //////////////////////////////////////////////////////////


        //////////////////////////////////////////////////////////
        // Print the tree in ascending order
        public static void TraverseAscending(BTree node)
        //to print in order we need to go to the left child then use the data in the current node and go to the right child 
        //if we want to traverse tree in ascending order we call our recursive method with the less than child then process the current node we are on
        //as long as it has data in it (if its a seed node then we don't want to print the node because its skeletal data) then we traverse through the branch
        //on the right and our base case is that if the node that we passed in is not null**
        {
            if ( node != null)
            {
                TraverseAscending(node.ltChild);

                if( node.isData)
                {
                    PrintThisNode(node);
                }

                TraverseAscending(node.gteChild);
            }
        }
        //////////////////////////////////////////////////////////
        

        //////////////////////////////////////////////////////////
        // Print the tree in descending order
        public static void TraverseDescending(BTree node)
        {
            if (node != null)
            {
                TraverseDescending(node.gteChild); //go to branch to right first, process data, then go the left branch last then do descending order

                if (node.isData)
                {
                    PrintThisNode(node);
                }

                TraverseDescending(node.ltChild);
            }

        }
        //////////////////////////////////////////////////////////
    }


    //we will be storing a person in each node and storing strings and integers**
    public class Person
    {
        public string name;
        public int age;

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
    }
}


//unbalanced tree and inserts 0-9 in our tree and it's completely unbalanced because it's ascending order and it's like a linked list because it's a 
//and we don't get any benefits of our tree**