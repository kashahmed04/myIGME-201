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

        1. So when we created a linked list from an array of strings I just wanted to make sure but each node in the linked list
        is written according the order of how the strings were written out in the array right?
        2. So I just wanted to make sure but when we want to add nodes you said that we can't have repeating nodes otherwise we would get a run time error and circular dependency,
        but for the datatype (if we use .value) we could have repeats of those and we can just do sentence.Last.Value("word") twice and that would not throw an error?
        I was a bit confused because wouldnt that technically create the same node with same values twice causing an error then?
        3. Could we use .value with all the built in methods with linked lists to add, remove, or get certain values from them or is there a restriction 
        to when we can use .value with these built in methods
        4. In order to reference a node we have to say it's a linkedlistnode and we need to specify the datatype of that node from that specific linked list right? 
        If the linked list had the object data type and if we wanted to reference a node from that list that was a string would we say it's a string in the <>
        or an object or would both work?
        5. In example 5 of the linked list examples, when we remove the first node in the linked list the stored value does not get removed completely from memory
        because it was declared before we removed the first node right?
        6. AddAfter and AddBefore take in the targetted value and the value to insert if we want to put something in the middle of the linked list right? And
        would we usually target a node in the linked list to do AddAfter or AddBefore and not a .value (datatype)?
        7.  6. Change the last node to 'yesterday'
           sentence.RemoveLast(); 
           sentence.AddLast("yesterday");

           //sentence.Last.Value = "yesterday" 
            For this example here basically the first part was talking about changing the node based on the identifier which used to be away and now we set it to yesterday
            whereas the second part was just changing what was contained
            in the node right (the value)?
        8. For step 9 does it find the first occurrence of a node in a linked list whereas the FindLast finds the last occurrence of the node
           and they both go through whole linked list to get the node right?
        9. For example 11 could we have also stored linked list node reference to be a carNode.Next since the nodes in the linked list points in both directions
        10. For example 14 don't we have to remove the current node though so no values repeat because nodes can't repeat or does the AddAfter and AddBefore automatically 
        remove the node for us and move it to the specified area whereas the AddFirst and 
        AddLast does not remove the node?
        11. For example 16 I wanted to make sure but we have our sentence linked list and we have access to the count which is the number of things in our linked list
        and we store how many items (the index) will be in our sArray then we do copyTo to copy all of our things from our linked list to our array starting from index 0 in sArray right?
        12. To remove the first occurrence of something from a linked list I know we talked about using the linked list name.remove(something) but if we wanted to remove
        something from the middle of a linked list would first have a linkedlistnode reference then we can do a linked list name.remove(the name of the node)? I was confused
        on how we could remove something specifically from the middle of a linked list.

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

            //sentence.Last.Value = "yesterday" //change the data in the last node the yesterday instead of changing the actual node itself like we did above**
            //can we do addlast and addfirst and last and first with .value or are some only node specific and data specific**

       7. Move the last node to be the first node.
           LinkedListNode<string> lastNode = sentence.Last;
           sentence.RemoveLast();
           sentence.AddFirst(lastNode); //inserts new node as the first node and the previous first node becomes the second node

       8. Find the last occurence of 'the'.
           LinkedListNode<string> target = sentence.FindLast("the"); 
            //finds the last occurrance of the data in the linked list (can we do .value for data
            //or is this only specifically for nodes only)**
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
        //if we know whats in our linked list is it still necessary to have a try catch and if we know we are not going to have repeating nodes or is it common
        //to have try and catch when adding and removing nodes from linked lists**
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
       before the node referred to by current. instead of having it after current like we did before**
           sentence.Remove(carNode);
           sentence.AddBefore(current, carNode);
        


       14. Add the 'current' node after the node referred to by mark2
           sentence.AddAfter(mark2, current);

       15. The Remove method finds and removes the
       first node that that has the specified value.
           sentence.Remove("red"); //find and remove the first node that has the specified data in it**

       16. Create an array with the same number of
       elements as the linked list.
           string[] sArray = new string[sentence.Count];
           sentence.CopyTo(sArray, 0); //why do we put 0 is this the starting index value and the first parameter is the array we are copying from**(6)
        //why do we have to copy it if we already created the array above with everything from the linked list is it because the first line
        //creates the array with the index number but the second line is actually putting the items in the array** (7)

        //we get out linked list and copy it to the array starting at index 0 for the linked list or the array?**(7.5)

       17. Walk through a Linked List in forward order

        //if we want to walk through the linked list in forward order then we have the linked list pointing to the first thing in our list
        //and while the linkedlist is not equal to null then we set the linkedlistnode to the linkedlistnode.next 
        //set the node variable equal to itself.next**
           LinkedListNode<object> linkedListNode = linkedList.First;

           while( linkedListNode != null )
           {
               linkedListNode = linkedListNode.Next; //how does it know there is a .next if above we only declared it with 1 item being the first item**(8)
           }

       18. Walk through a Linked List in reverse order
        //set the node equal to itself.previous to move in backwards order in the linked list while the linkedlist is not null**
           LinkedListNode<object> linkedListNode = linkedList.Last; //how does it know it has a .previous if we just say .last that means we would only have 1 item
                                                                    //in our linked list**(9)

           while( linkedListNode != null )
           {
               linkedListNode = linkedListNode.Previous;
           }

       19. Change the Value of a node
        //the value property would be the cell object class in chutes and ladders**
           linkedListNode.Value = "new value";

       20. Release all the nodes.
           sentence.Clear();

       */



        private void Button1__Click(object sender, EventArgs e)
        {
            // 1. create a LinkedList which contains the digits 1 through 10
            //linkedlist is a list of objects and thats because the visualizer class can render strings or intergs in the linked list so we 
            //need to make it an object so support both the data types**
            LinkedList<object> linkedList = new LinkedList<object>();

            // 2. Your code here
            for(int i = 1; i <= 10; i++)
            {
                //add each number to the end of the linked list**
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
                //add each number to the end of the linked list**
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
            //we can only add data from node to another linked list when we are getting values from one linked list to another**
            //we are breaking the link and adding new link in the middle and are very efficient for adding data but with arrays and stacks and queues
            //to add data to an array in general though we need to create new array and copy but for stacks and queues we dont**
            //linked lists we have to walk through the whole list so it's not efficient for getting data while arrays are**

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
            //what was the other way to declare the array**

            // 2. Your code here
            linkedList = new LinkedList<object>(sentence); //why did we do object if its a string**

            // 3. add "quick" and "brown" before "fox"
            linkedListNode = linkedList.Find("fox");
            linkedList.AddBefore(linkedListNode,"quick");
            linkedList.AddBefore(linkedListNode, "brown");
            //wouldnt it be brown quick fox since we added it before**

            // 4. Your code here

            // 5. using example #8, add "lazy" after the last "the"
            linkedListNode = linkedList.FindLast("the"); //would be null if there was no "the" so we would want to have an error check**
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
            string[] s = null;

            // 2. Your code here


            // 3. replace "sad" with "happy"
            // and "sadness with "happiness"
            // note that because Value is an object 
            // you will have to cast Value as a string as follows:
            //     if( (string)linkedListNode.Value == "sad"

            // 4. Your code here


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
            string[] s = null;

            // 2. Your code here


            // 3. manipulate the list using Find(), Remove(), AddBefore() and/or AddAfter() to result in
            // "The rain in Spain falls mainly on the plain"
            // your Add methods must use 2 LinkedListNode arguments like examples #13 and #14 
            // you may not use string arguments in your Add method calls

            // 4. Your code here


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

            // Your code here

            // then call the visualizer
            VisualizeLinkedList visualizeLinkedList = new VisualizeLinkedList(anagram);
        }
    }
}