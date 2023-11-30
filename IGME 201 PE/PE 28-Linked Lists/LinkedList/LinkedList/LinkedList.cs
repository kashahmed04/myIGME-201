using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using LinkedListVisualizer;




namespace LinkedList
{
    public partial class LinkedList : Form
    {
        public LinkedList()
        {
            try
            {
                // Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.2; WOW64; Trident / 7.0; .NET4.0C; .NET4.0E; .NET CLR 2.0.50727; .NET CLR 3.0.30729; .NET CLR 3.5.30729; wbx 1.0.0)
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(
                    @"SOFTWARE\\WOW6432Node\\Microsoft\\Internet Explorer\\MAIN\\FeatureControl\\FEATURE_BROWSER_EMULATION",
                    true);
                key.SetValue(Application.ExecutablePath.Replace(Application.StartupPath + "\\", ""), 11001, Microsoft.Win32.RegistryValueKind.DWord);
                key.Close(); //we are going to be using the web browser control and the web brwoser control is built into the library that was included
                //and it was a linked list visualizer and the dll contains the visualizelinkedlist class and that class will launch the visualizer for us in the 
                //web brwoser control to show our linked list for us and we pass in the linked list to the constructor and it will show it for us
                //run this file as administrator for the first time
            }
            catch
            {

            }

            InitializeComponent();

            button1.Click += new EventHandler(Button1__Click);
            button2.Click += new EventHandler(Button2__Click);
            button3.Click += new EventHandler(Button3__Click);
            button4.Click += new EventHandler(Button4__Click);
            button5.Click += new EventHandler(Button5__Click);
            button6.Click += new EventHandler(Button6__Click);
        }

        /* Linked List Examples        

       1. Create a Linked List of strings
           LinkedList<string> sentence = new LinkedList<string>(); //in the <> it stores the data type of each node

       2. Create a Linked List from an array of strings
           string[] words =
               { "the", "red", "car", "speeds", "away" };
           LinkedList<string> sentence = new LinkedList<string>(words); 
        //we can directly create linked list form an array and if we pass array in the constructor in the () then it populates the linked list with each node
        //in the order of the words written in the array (each word is a different node)

       3. Add new strings to the end (tail) of the Linked List (either add a node directly to end of the list or the datatype
        and it will make the node for us)
           sentence.AddLast("word");

       4. Add the word 'today' to the beginning (head) of the linked list.
           sentence.AddFirst("today");

       5. Move the first node to be the last node.
           
            //in order to reference a node we have to say it's a linkedlistnode and we need to specify the datatype in that node from that specific linked list 
            //then we point to the first node in our list and we can't have multiple copies of our node in our linked list
            //and if we want to move a node from going to first to last then we need to remove the node from the linked list from the begginning 
            //and add it to the end because values in linked lists cant repeat
            //if we did not do the remove first (the second line) then we would get a run time error because we are trying to add the same exact node in different locations
            //of our linked list and linked lists can't have the same exact node existing in the linked list at the same time because it creates
            //circular dependency and causes and error (only for nodes) but for actual data we would do the firstnode.Value and it will create a new node
            //with the value in our first node and we can always do that and have copies of the same data (the .value) but we can't add the same node multiple times
            //so when we add with nodes if its already in the list remove it then add it back otherwise if its a .value we can repeat the data values
           LinkedListNode<string> firstNode = sentence.First;
                                                              
           sentence.RemoveFirst();
           sentence.AddLast(firstNode); 

            //sentence.AddLast(firstNode.Value);
       6. Change the last node to 'yesterday'
           sentence.RemoveLast(); 
           sentence.AddLast("yesterday");

            //sentence.Last.Value = "yesterday" //change the data in the last node the yesterday instead of changing the actual node itself like we did above
       

       7. Move the last node to be the first node.
           LinkedListNode<string> lastNode = sentence.Last;
           sentence.RemoveLast();
           sentence.AddFirst(lastNode); //inserts new node as the first node and the previous first node becomes the second node

       8. Find the last occurence of 'the'.
           LinkedListNode<string> target = sentence.FindLast("the"); 
            //finds the last occurrance of the data in the linked list 
           if (target == null)
           {
               // "the" is not found
           }
           else
           {
               // Add 'bright' and 'red' after 'the' (the LinkedListNode named target).
               sentence.AddAfter(target, "bright"); 
               sentence.AddAfter(target, "red");
        //adds nodes after the specificed node
           }

       9. Find the 'car' node (does this find the first occurrance of something in a linked list whereas the FindLast finds the last occurrence)
        //find and findlast goes through whole linked list to get data and this finds the first occurance
           LinkedListNode<string> target = sentence.Find("car");

       10. Add 'sporty' and 'red' before 'car':
           sentence.AddBefore(target, "sporty");
           sentence.AddBefore(target, "red");

       11. Keep a reference to the 'car' node
       and to the previous node in the list this is the node previous to car
        //we can save nodes and each node has a next and previous property and we can find the car node and set another node variable to the carnode.previous
        //to get the previous node from the carnode
           carNode = sentence.Find("car");
           LinkedListNode<string> current = carNode.Previous;

       12. The AddBefore method throws an InvalidOperationException
       if you try to add a node that already belongs to a list.

        //if we try to add a node thats already in the list we will get an exception so we can use a try catch to prevent application from crashing
        
           try
           {
               // try to add carNode before current
               sentence.AddBefore(current, carNode);
           }
           catch (InvalidOperationException ex)
           {
               Console.WriteLine("Exception message: {0}", ex.Message);
           }


       13. Remove the node referred to by carNode, and then add it
       before the node referred to by current. 
           sentence.Remove(carNode);
           sentence.AddBefore(current, carNode);
        


       14. Add the 'current' node after the node referred to by mark2
           sentence.AddAfter(mark2, current);

       15. The Remove method finds and removes the
       first node that that has the specified value.
           sentence.Remove("red"); //find and remove the first node that has the specified data in it

       16. Create an array with the same number of
       elements as the linked list.
           string[] sArray = new string[sentence.Count];
           sentence.CopyTo(sArray, 0); //this is the starting index value and the first parameter is the array we are putting the copied values from the linked list
        //into
        //the first line
        //creates the array with the index number but the second line is actually putting the items in the array

        //we get our linked list and copy it to the array starting at index 0 for the array

       17. Walk through a Linked List in forward order

        //if we want to walk through the linked list in forward order then we have the linked list pointing to the first thing in our list
        //and while the linkedlist is not equal to null then we set the linkedlistnode to the linkedlistnode.next 
        //set the node variable equal to itself.next
           LinkedListNode<object> linkedListNode = linkedList.First;

           while( linkedListNode != null )
           {
               linkedListNode = linkedListNode.Next; //In example 17, how does it know there is a .next for the node in the loop
                                                       //if above we only declared the linked list node
                                                       //with 1 item being the first item in the linked list we also had the same case in example 18
                                                        //but it was with linkedlist.last and linkedlistnode.previous

                                                       //this basically goes to the linked list and goes to the preivous value since
                                                       //we set the linked list node equal to the last value in the linked list in the above statement
           }

       18. Walk through a Linked List in reverse order
        //set the node equal to itself.previous to move in backwards order in the linked list while the linkedlist is not null
           LinkedListNode<object> linkedListNode = linkedList.Last; 

           while( linkedListNode != null )
           {
               linkedListNode = linkedListNode.Previous;
           }

       19. Change the Value of a node
        //For example 19 I was a bit confused when you said 
        //"the value property would be the cell object class in chutes and ladders." So basically each node was an instance of the cell class (each
        //green block on the gameboard) and to access the node itself we would have to use the .Value to see what's inside the node

        //what happens if we say the node itself and not the value would it still give us the contents of the node regardless or is there a distinction
        //from getting the node itself and the .Value
           linkedListNode.Value = "new value";

       20. Release all the nodes.
           sentence.Clear();

       */



        private void Button1__Click(object sender, EventArgs e)
        {
            // 1. create a LinkedList which contains the digits 1 through 10
            //linkedlist is a list of objects and thats because the visualizer class can render strings or intergs in the linked list so we 
            //need to make it an object so support both the data types

            //In the linked list methods you said that we needed to have the linked list be defined as the object data type because our visualizer 
            //uses both integers and strings based on the method right? Why can't we declare different types of linked lists for each method because it's rather a string
            //or an integer and not both so there would be no conflict then?
            LinkedList<object> linkedList = new LinkedList<object>();

            // 2. Your code here
            for(int i = 1; i <= 10; i++)
            {
                //add each number to the end of the linked list
                linkedList.AddLast(i);
            }


            // 3. then call the visualizer
            VisualizeLinkedList visualizeLinkedList = new VisualizeLinkedList(linkedList);
        }

        private void Button2__Click(object sender, EventArgs e)
        {
            // 1. using Button1__Click() create a LinkedList which contains the digits 1 through 10
            LinkedList<object> linkedList = new LinkedList<object>();

            // 2. Your code here
            for (int i = 1; i <= 10; i++)
            {
                //add each number to the end of the linked list
                linkedList.AddLast(i);
            }

            // 3. using example #18, copy the linkedList to reverseLinkedList in reverse order
            // so that reverseLinkedList goes from 10 to 1
            LinkedList<object> reverseLinkedList = new LinkedList<object>();
            LinkedListNode<object> linkedListNode;

            // 4. Your code here
            linkedListNode = linkedList.Last;
            while(linkedListNode != null)
            {
                reverseLinkedList.AddLast(linkedListNode.Value);
                linkedListNode = linkedListNode.Previous; 
            }
            //we have linked list and reverse linked list (2 linked lists)
            //we can only add the datatype (the current node .Value) to copy a node to go into another linked list
            //we are breaking the link and adding new link in the middle and are very efficient for adding data but with arrays 
            //to add data to an array in general we need to create new array and copy but for stacks and queues we dont because they have built in methods?
            //isn't searching also limited with stacks and queues or can we still go through the whole thing since they are technically arrays?
            //linked lists we have to walk through the whole list so it's not efficient for getting data while arrays are efficient for getting data because
            //we can get data by index

            // 5. then call the visualizer
            VisualizeLinkedList visualizeLinkedList = new VisualizeLinkedList(reverseLinkedList);
        }

        private void Button3__Click(object sender, EventArgs e)
        {
            // 1. create a LinkedList which contains the words
            // "the", "fox", "jumped", "over", "the", "dog"
            LinkedList<object> linkedList = null;
            LinkedListNode<object> linkedListNode;
            string[] sentence = { "the", "fox", "jumped", "over", "the", "dog" };
            //what was the other way to declare the array and adding the values(1)**

            // 2. Your code here
            linkedList = new LinkedList<object>(sentence); 

            // 3. add "quick" and "brown" before "fox"
            linkedListNode = linkedList.Find("fox"); 
            linkedList.AddBefore(linkedListNode,"quick");
            linkedList.AddBefore(linkedListNode, "brown");
            //it would be the quick brown fox because when we do AddBefore with the "brown" the "quick" and all the nodes before
            //the target node gets pushed back one space so we are able to 
            //add "brown" before the "fox" node

            // 4. Your code here

            // 5. using example #8, add "lazy" after the last "the"
            linkedListNode = linkedList.FindLast("the"); //would be null if there was no "the" so we would want to have an error check and these two statements
                                                         //would be in a try block and the catch would be if it was null do something else
            linkedList.AddAfter(linkedListNode, "lazy");

            // 6. Your code here

            // 7. then call the visualizer
            VisualizeLinkedList visualizeLinkedList = new VisualizeLinkedList(linkedList);
        }

        private void Button4__Click(object sender, EventArgs e)
        {
            // 1. create a LinkedList which contains the words
            // Because I'm sad Clap along if you feel like a room without a roof
            // Because I'm sad Clap along if you feel like sadness is the truth sad
            LinkedList<object> linkedList = null;
            LinkedListNode<object> linkedListNode;
            string[] s = { "Because", "I'm", "sad", "Clap", "along", " if", "you", "feel", "like", "a", "room", "without", "a", "roof",
                "Because", "I'm", "sad", "Clap", "along", " if", "you", "feel", "like","sadness", "is", "the", "truth"};

            // 2. Your code here
            linkedList = new LinkedList<object>(s);


            // 3. replace "sad" with "happy"
            // and "sadness with "happiness"
            // note that because Value is an object 
            // you will have to cast Value as a string as follows:
            //     if( (string)linkedListNode.Value == "sad"

            // 4. Your code here
            linkedListNode = linkedList.Find("sad"); //is it ok if we did it like this or is there an alternative way to do it to account for all values of sad**(2)
                                                     //would it be faster to target specific values then change them like it is here
                                                     //or just go through the whole linked list and change
                                                     //them as we go**(3)
            if ((string)linkedListNode.Value == "sad") 
            {
                linkedListNode.Value = "happy";
            }

            linkedListNode = linkedList.FindLast("sad");
            if ((string)linkedListNode.Value == "sad")
            {
                linkedListNode.Value = "happy";
            }

            linkedListNode = linkedList.Find("sadness");
            if ((string)linkedListNode.Value == "sadness")
            {
                linkedListNode.Value = "happiness";
            }



            // 5. then call the visualizer
            VisualizeLinkedList visualizeLinkedList = new VisualizeLinkedList(linkedList);
        }

        private void Button5__Click(object sender, EventArgs e)
        {
            // 1. create a LinkedList which contains the following words
            // The Spain in rain falls plain on the mainly
            LinkedList<object> linkedList = null;
            LinkedListNode<object> linkedListNode1;
            LinkedListNode<object> linkedListNode2;
            string[] s = {"The", "Spain", "in", "rain", "falls", "plain", "on", "the", "mainly"};

            // 2. Your code here
            linkedList = new LinkedList<object>(s);

            // 3. manipulate the list using Find(), Remove(), AddBefore() and/or AddAfter() to result in
            // "The rain in Spain falls mainly on the plain"
            // your Add methods must use 2 LinkedListNode arguments like examples #13 and #14 
            // you may not use string arguments in your Add method calls

            // 4. Your code here
            linkedListNode1 = linkedList.Find("Spain");
            linkedListNode2 = linkedList.Find("rain");

            linkedList.Remove(linkedListNode2);
            linkedList.AddBefore(linkedListNode1, linkedListNode2);

            linkedListNode1 = linkedList.Find("Spain");
            linkedListNode2 = linkedList.Find("in");

            linkedList.Remove(linkedListNode2);
            linkedList.AddBefore(linkedListNode1, linkedListNode2);

            linkedListNode1 = linkedList.Find("plain");
            linkedListNode2 = linkedList.Find("mainly");

            linkedList.Remove(linkedListNode2);
            linkedList.AddBefore(linkedListNode1, linkedListNode2);

            linkedListNode1 = linkedList.Find("the");
            linkedListNode2 = linkedList.Find("plain");

            linkedList.Remove(linkedListNode2);
            linkedList.AddAfter(linkedListNode1, linkedListNode2);


            // 5. then call the visualizer
            VisualizeLinkedList visualizeLinkedList = new VisualizeLinkedList(linkedList);
        }

        private void Button6__Click(object sender, EventArgs e)
        {
            LinkedListNode<object> linkedListNode1;
            LinkedListNode<object> linkedListNode2;

            string[] letters = { "D", "O", "R", "M", "I", "T", "O", "R", "Y" };
            LinkedList<object> anagram = new LinkedList<object>(letters);

            // rearrange the Nodes to spell "DIRTYROOM"
            // your Add methods must use 2 LinkedListNode arguments like examples #13 and #14 
            // you may not use string arguments in your Add method calls

            //for this code here could we have just gotten the M to the last entry where it should be 
            //then go through and do AddBefore based on that M entry so each value we add, the other nodes before the target node
            //gets pushed back and closer to the start as we
            //do AddBefore and eventually everything would be in order (Ex. doing AddBefore on M with D, then I, then the rest of the letters in order
            //from first letter to last in DIRTYROOM then it would spell it out because each time we do AddBefore everything before the target node gets pushed back 1 space
            //so theres room to add before the node for the newest value)(4)**

            //could we have also done AddLast for each value in the word starting from the D to the end of the word because then each 
            //letter would be pushed back one space when we do AddLast because we are adding a value to the end of the linked list

            //for AddAfter that pushes everything after the specificed node
            //forward 1 space right so there's room to add the new node in front of the specified linked list node and for AddBefore it would just
            //push everything back 1 space before the specified node?**(5)

            //could we have also done AddFirst here but instead it would move everything forward one space instead of back for AddLast so we would start with the last
            //letter (M) and do AddFirst with all the letters in backwards order??**(6)

            // Your code here
            linkedListNode1 = anagram.Find("I");
            linkedListNode2 = anagram.Find("D");

            anagram.Remove(linkedListNode1);
            anagram.AddAfter(linkedListNode2, linkedListNode1);

            linkedListNode2 = anagram.Find("R");

            anagram.Remove(linkedListNode2);
            anagram.AddAfter(linkedListNode1, linkedListNode2);

            linkedListNode1 = anagram.Find("T");

            anagram.Remove(linkedListNode1);
            anagram.AddAfter(linkedListNode2 , linkedListNode1);

            linkedListNode2 = anagram.Find("Y");
            anagram.Remove(linkedListNode2);
            anagram.AddAfter(linkedListNode1, linkedListNode2);

            linkedListNode1 = anagram.FindLast("R");
            
            anagram.Remove(linkedListNode1);
            anagram.AddAfter(linkedListNode2, linkedListNode1);

            linkedListNode1 = anagram.Find("M");

            anagram.Remove(linkedListNode1);
            anagram.AddLast(linkedListNode1);
            





            // then call the visualizer
            VisualizeLinkedList visualizeLinkedList = new VisualizeLinkedList(anagram);
        }
    }
}