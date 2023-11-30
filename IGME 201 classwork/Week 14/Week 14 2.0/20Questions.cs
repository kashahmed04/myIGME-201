using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Net;

// be sure to add the System.Web assembly as a reference
using System.Web;

//1 So for binary trees I wanted to make sure so for the traversals you said that the pre-order is good for making an exact copy of a binary tree,
//post-order is good for deleting nodes from a binary tree, and in order was good for reading trees in ascending or descending order and it's also good
//for making an exact copy of a binary tree too right? I just want to make sure I am not missing anything**

/*
 * Binary tree guessing game:
 * The guessing game is modeled on how a binary tree works and a binary tree always checks to see if the value is greater than or less
 * than the node in the tree but and array is just a list of values unless we specifically put that array in order (go through all array and sort each time
 * we add a value and we ahve to create a new array to insert a new value) and the sorted list is a binary tree under the hood in the way it stores it data 
 * to find the data very quickly. An array is not like a binary tree and we would not use an array to store the values (not preferable) The guessing game is like binary
 * tree in reverse so we can remove half of our numbers every time we guess** If we had unsorted array to guess and we had 100 numbers in our array then
 * on average it would take 100 guesses to find number in the array because we have to look through every number** if we sort the array then the performance will
 * be very fast but inserting into array will be very slow because we have to make a new array and add new value then sort it 
 * 
 * Tree data structure PDF:
 * So far we have been looking at linear data structures like stacks, lists, arrays, queues, and linked lists and they are stored as lines of data (list of strings,
 * queues, stacks, etc.) and if we want to establish relationships with the data then we need to use data structure that can reprsent those relationships (trees)
 * we might have a talen tree in a game and tmagic might be a skill we have and the relationship is the fire skill and ice skill and those skills can be further
 * broken down and trees can store parent child relationships and file systems (windows exploerer is a tree data structure because we have parent nodes becuase we have
 * folders then within those folders we have files)**
 * We can have general trees with any number of children and we will be using binary tree which only takes 2 child nodes and quad trees is used for loctational
 * trees**
 * 
 * A tree has a root which is the only way to access the root (very top or bottom of tree depending on if its right sid eup or upside down) and off of the root
 * we have edges which lead to nodes and at the end of all the branches of the tree we have leaves (root is the parent top node and the edges connect each
 * nodes of the tree and each node holds the data and the leaves are the nodes that do not ahve any children and are at the very bottom of the tree)
 * 
 * To traverse through the tree we have to go through the top to the bottom node (depth is the maximum height of a tree and level 0 is always the root node and
 * we always start counting from 0)**
 * 
 * Binary search tree is used because it's quick to search and quick to update and disadvantages are that it is not built into C# and we have to build it ourselves
 * while stacks, queues, linked lists, arrays, etc. are built in for us already 
 * A tree is a collection of nodes and binary search trees have rules and the way data is stored has to follow specific rules from any node lower values much branch off
 * to the node to the left (lowest value is always the left most node) and higher or equal values always go to thr right of the binary search tree**
 * 
 * Binary search trees can be very fast for searching for data because we always know higher values are always to the right we can ignore the valeus to the left
 * if we need to search for a higher number than the root node**
 * 
 * Binary search tree is only efficient if it's balanced and that means we need to understand data in the tree and if its numeric data then we would have to populate tree 
 * so data is balanced in the tree and if a tree is unbalanced it is not going to perform in an efficient way and there are algotirhms for searching through
 * binary trees and the in order traversal is reading the data out of the tree by ascending or descending order (if its numerical)** the other option is pre order
 * and post order traveral 
 * 
 * Pre order traversal is the traversal we would use to duplicate a binary tree (make an exact copy) and with each number we read we put that into a new tree and get
 * an exact copy**
 * 
 * post order traversal is good for deleting nodes from a tree from bottom to top and we might want to remove a whole level of a tree so we use post order**
 * 
 * In order traversals is for reading trees in the lowerest to highest order or the oppossite** to do it we first go to the left node then process
 * the node then we go to the right node and it will return the data in sorted order from lowest to highest order if we want to do the other way around (High to low) 
 * we go to thr right most node to the left node
 * 
 * if we do this recursively it goes all to the left most nodes then goes to parent node then the right most data**
 * 
 * pre order duplictates the tree we preocess to currnt node then left and right child and it processes all the non-leaf nodes (have children) before the leaf nodes(
 * the children)**
 * 
 * post order traversal to delete tree from bottom up we prrocess the left then right child then the current (exploers all leaf nodes before non-leaf nodes)**
 * 
 * 
 * 
 */
namespace _20Questions
{
    class BTNode
    {
        // message will either be an object or a question
        // if noNode and yesNode are null then message is an object and this node is a leaf of the tree
        // if noNode and yesNode are not null then message is a question and there are child nodes
        public string message; //within our node we have the message for the node which will rather be an object or a question 
        //if message is a questinos then no node will be the answer to that question if the answer is no but if its yes then the answer would be in that node**
        //but if yes and no is null then**
        public BTNode noNode;
        public BTNode yesNode;

        public BTNode(string nodeMessage)
        {
            message = nodeMessage; //node message that is stored and we set the children nodes and yes and no node is null**
            yesNode = null;
            noNode = null;
        }

        public void Query()
        {
            if (noNode != null && yesNode != null) //if both our yes and now nodes are not null then it asks the question from our message 
                //and we write yes or no and if they answered yes to the question then we walk down to the yes node and ask the question thats down there
                //and its only a question if there is a yes or no questions and if its not a question we call the onquery object method**
            {
                Console.WriteLine(message);
                Console.Write("Yes or No: ");

                string input = Console.ReadLine().ToLower();

                if (input.StartsWith("y"))
                {
                    yesNode.Query();
                }
                else
                {
                    noNode.Query();
                }
            }
            else
            {
                OnQueryObject();
            }
        }


        public void OnQueryObject()
        {
            Console.Write("Are you thinking of " + message + "? : "); //asks if we are thinking of object in that node and if we were thinkging
            //of that answer then the computer won otherwise we want to update tree with that knowledge
            string input = Console.ReadLine().ToLower();

            if (input.StartsWith("y"))
            {
                Console.WriteLine("The computer wins!");
                Console.WriteLine();
            }
            else
            {
                UpdateTree();
            }
        }

        public void UpdateTree() //ask what they were tihnking of and ask them to write a yes no question to distinguish 
            //between the object then it adds the new nodes to the tree and puts the new object into the new node for whether the answer was yes or not
            //so the tree grows and learns based on the feedback**
        {
            Console.WriteLine();
            Console.Write("You won!  What were you thinking of?  : ");
            string userObject = Console.ReadLine();

            Console.Write("Please enter a yes/no question to distinguish " + message +
                " from " + userObject + " :  ");
            string userQuestion = Console.ReadLine();

            Console.Write("If you were thinking of " + userObject + ", what would the answer to that question be? : ");
            string input = Console.ReadLine().ToLower();

            if( input.StartsWith("y"))
            {
                this.noNode = new BTNode(message);
                this.yesNode = new BTNode(userObject);
            }
            else
            {
                this.yesNode = new BTNode(message);
                this.noNode = new BTNode(userObject);
            }

            message = userQuestion;

            Console.WriteLine("Thank you, my knowledge has increased!");
            Console.WriteLine();
        }
    }

    class BTTree
    {
        public BTNode rootNode;

        public BTTree()
        {

        }

        public BTTree(string question, string yesGuess, string noGuess )
        {
            rootNode = new BTNode(question);
            rootNode.yesNode = new BTNode(yesGuess);
            rootNode.noNode = new BTNode(noGuess);
        }

        public void Query()
        {
            rootNode.Query();
        }
    }

    static class Program
    {
        static BTTree tree = null;

        static void Main(string[] args)
        {
            string s;

            HttpWebRequest request;
            HttpWebResponse response;
            StreamReader reader;
            string url;


            Console.WriteLine("Welcome to 20 Questions!");
            Console.WriteLine();

            try
            {
                url = "http://people.rit.edu/dxsigm/20q.php?get";

                request = (HttpWebRequest)WebRequest.Create(url);
                response = (HttpWebResponse)request.GetResponse();
                reader = new StreamReader(response.GetResponseStream());
                // StreamReader reader = new StreamReader("c:/temp/20q.json");
                s = reader.ReadToEnd();
                reader.Close();

                s = HttpUtility.UrlDecode(s);

                tree = new BTTree();
                tree.rootNode = JsonConvert.DeserializeObject<BTNode>(s);
            }
            catch
            {
                Console.WriteLine("Enter a yes/no question about an object: ");
                string question = Console.ReadLine();
                Console.Write("Enter a guess if the response is Yes: ");
                string yesGuess = Console.ReadLine();
                Console.Write("Enter a guess if the response is No: ");
                string noGuess = Console.ReadLine();

                tree = new BTTree(question, yesGuess, noGuess);
            }

            do
            {
                Console.WriteLine();
                tree.Query();

                Console.Write("Play again? : ");
                string input = Console.ReadLine().ToLower();

                if (input.StartsWith("n"))
                {
                    break;
                }

            } while (true);

            s = JsonConvert.SerializeObject(tree.rootNode);
            //StreamWriter writer = new StreamWriter("c:/temp/20q.json");
            //writer.Write(s);
            //writer.Close();

            s = HttpUtility.UrlEncode(s);

            url = "http://people.rit.edu/dxsigm/20q.php?set=" + s;

            request = (HttpWebRequest)WebRequest.Create(url);
            response = (HttpWebResponse)request.GetResponse();
            reader = new StreamReader(response.GetResponseStream());
            s = reader.ReadToEnd();
            reader.Close();
        }
    }
}
