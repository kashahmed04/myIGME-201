using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_of_Hanoi
{
    class Program
    {
        static Dictionary<string, Stack<int>> post = new Dictionary<string, Stack<int>>();
        //this stores the post letter (A,B, or C) then the stack for that post which is the number of disks in the current post??** are these storing all the posts and 
        //their current number of blocks it has**

        private static Queue<string[]> _autoMoves = new Queue<string[]>();
        //this is only used for the automoves which stores the 2D array of automoves and the source post and the destination post for those specific moves**

        private static int nTurn;

        static void Main(string[] args)
        {
            int nBlocks; //our disks**

            post["A"] = new Stack<int>(); //for each post we have a stack to store our number blocks we currently have on that post**
            post["B"] = new Stack<int>(); //how does it know to add to the dictionary is it because we said the name of the dictionary (post) and set the key and value**
            post["C"] = new Stack<int>();

            Console.WriteLine("Move the blocks from post A to post C. \nYou may not put a larger block onto a smaller one.");
            Console.Write("Number of blocks on post A: ");

            while (int.TryParse(Console.ReadLine(), out nBlocks) == false) ; //if we can't convert it keeps going (returns false) otherwise if 
            //we can convert it and it returns true we exit the loop because tryParse returns true if it converted otherwise false if it did not convert**

            Console.Write("Autosolve (Y/N): ");
            string autoSolve = Console.ReadLine();

            post["A"].Push(nBlocks + 1); //we want to do plus one because we want to count the base as one block so we don't have a null value**
                                         //why would we want to account for a null value (same for the b and c posts is it because when we peek
                                         //we don't want there to be a null value and we want at least 1 block always**

            int nCntr = nBlocks;
            while( nCntr > 0 )
            {
                post["A"].Push(nCntr); //we dont want to subtract the nBlocks (total blocks) so we copy the number of blocks into another variable
                //and populate the main block with all of our blocks and subtract 1 as we add our blocks**
                //why did we have to do this if we pushed nBlocks + 1 in our above statement**
                --nCntr;
            }

            //post["A"].count = nBlocks + 1; could we have just dont this instead to set the size if that's what we were doing with the push of nBlocks + 1**

            post["B"].Push(nBlocks + 1);
            post["C"].Push(nBlocks + 1);

            string srcPost = null;
            string destPost = null;

            int nThisBlock;

            //is everything below here for automoves how does it know if we want to do it manually**
            if (autoSolve.ToLower().StartsWith("y"))
            {
                // recursively build queue of moves to solve the puzzle
                GameSolver(nBlocks, "A", "B", "C");
            }

            while ( post["C"].Count != nBlocks + 1 ) //when its equal to the total blocks plus 1 for the base we stop because we have finished the puzzle**
            {
                PrintPosts(nBlocks); //do our moves in the below condtionals then print it out when we get back to top**(how does it know to
                //print the last move then if the puzzle is done because it would exit the loop then is it because after the while loop
                //we have a print post statement so it accounts for the last values of the stack)**

            //label where we go to from the conditionals down below**
            tryAgain:

                if (autoSolve.ToLower().StartsWith("y"))
                {
                    // fetch next move from the queue (is this from the gamesolver method we called in the above condtional before we use it here)**
                    //and we can use the auto moves queue directly because it was class scoped**
                    string[] sMoves = _autoMoves.Dequeue();
                    //show the from and to 2D array we had for our queue since it took in an array and we enqueue an array within it**
                    srcPost = sMoves[0]; //from source post to destination post**
                    destPost = sMoves[1];
                }
                else
                {
                    //this is the case for if they manually want to play right**
                    Console.Write("Source Post: ");
                    srcPost = Console.ReadLine().ToUpper(); //what if they dont put in A,B, or C how does it know to throw an error**

                    Console.Write("Destination Post: ");
                    destPost = Console.ReadLine().ToUpper();
                }

                //for the value (the stack) of the source post based on the key which is the post check if the count is equal to 1**
                if (post[srcPost].Count == 1) //cant we put this within the else statement above because it goes with setting
                    //the values of src and dest. post and working with them is it because we set the automoves to
                    //the src and dest post if they chose automoves instead of doing it themselves manually so we put it after both condtionals
                    //to see if it's manually or automoves**
                {
                    Console.WriteLine("There are no disks on post " + srcPost);
                    goto tryAgain;
                }

                if (post[srcPost].Peek() > post[destPost].Peek())
                {
                    Console.WriteLine("You may not place a higher disk on a lower disk!"); 
                    //we have 2 posts and 1 for pop (source post) and one for push (destination post) that the user put in the else statement above**
                    goto tryAgain;
                }
                

                nThisBlock = post[srcPost].Pop(); //the current block we have is popped off the src post and put onto the destpost**
                //the key is the post and the value is the stack we are popping and pushing from**
                post[destPost].Push(nThisBlock); //pushing our popped value from the source stack into the destination stack**
                //when we do push and pop does it return the added and removed values same for enqueue and dequeue****
            }

            PrintPosts(nBlocks);
        }

        //go over**
        static void PrintPosts( int nBlocks )
        {
            List<int> aPost = new List<int>(post["A"].ToArray()); //we can store arrays in lists but can we do lists in arrays**
            List<int> bPost = new List<int>(post["B"].ToArray()); //and we set our value based on the key from the post dictionary to an array (the stack)**
                                                                   //stack can be any data type but only 1 right same for queue**
            List<int> cPost = new List<int>(post["C"].ToArray());

            aPost.Reverse(); //why do we reverse here**
            bPost.Reverse();
            cPost.Reverse();

            //what does this print**
            for ( int i = nBlocks; i > 0; --i)
            {
                Console.Write((aPost.Count > i ? aPost[i].ToString() : " ")); //each value in our array of the blocks in our stacks for each post**
                Console.Write("   ");

                Console.Write((bPost.Count > i ? bPost[i].ToString() : " "));
                Console.Write("   ");

                Console.Write((cPost.Count > i ? cPost[i].ToString() : " "));
                Console.WriteLine();
            }

            Console.WriteLine("A   B   C");
            Console.WriteLine("Turn #" + nTurn);
            ++nTurn; //increment the turn the user has taken if it's valid and does not cause errors** if it causes errors we don't get to this method and
            //don't increment the turns 
            Console.WriteLine();
        }

        //go over** (do we have to know all of this or is the concept of the stack ok)**
        private static void GameSolver(int nBlocks, string from, string spare, string to)
        {
            if (nBlocks == 1)
            {
                // finally move the last block from A to C
                //then store the last automove in our queue** (why do we save the moves) is it because in our loop every time we do an automove**
                //we take it out of the queue (dequeue) if the user said yes for automoves**
                //then we keep doing that and storing the source and destination post and using those values to see if we can move**
                //around the blocks (disks) in the two if statements at the end of the loop and change the values with the two blocks postion after the if statements**
                string[] moves = { from, to };
                _autoMoves.Enqueue(moves);

                return; //prevents the blocks from reaching 0 so we can stop the recursion and exit the method(base case)**
            }

            //A,C,B (why do we need this twice does the order matter here) if it does it twice how does it know to implement the
            //bottom recursion if the top one always gets met before**
            GameSolver(nBlocks - 1, from, to, spare);

            // queue the current {from, to} movement (how does it get here if above we are restarting the recursion)**
            //stores the auto moves so we can implement all of those moves in the while loop above**
            //the array stores 2 things which is the from (source) and to (destination post) for one entry making it a 2D array (an array with arrays inside that**
            //contain the from and to)**
            string[] moves1 = { from, to };
            _autoMoves.Enqueue(moves1);

            //B,A,C**
            GameSolver(nBlocks - 1, spare, from, to);
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
 * create a console application with a singleton class to load some game settings for a player
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
 * can queues be used recursively or not******
 * we can specify how many blocks are on the first post and we can have program autosolve and see the output and it will take 31 moves which is 
 * 2 to the 5 minus 1 (16 moves)**
 * we start with 5 disks on first post then move the first 2 disks onto our spare post B then we want to get 3 disks moved onto post C which is out destination then
 * 4 didks onto post B then 5 disks onto our destination post C (3 disks at a time)
 * 
 * the stack datatype in c# is defined by new Stack<datatype the stack holds (only 1 datatype)>();**
 *in our case its the number of disks so its an int**
 *so stacks, queues, and linked lists use the new keyword meaning they are objects and are they call by reference or value******
 *can we use arrays in the () for stacks and queues as well for individual entries in the stacks and queues like we did with linked lists****
 *can we have collections in a stack like an array being stack values or linked lists as stack values****
 *for each post we have a stack of integers within the dictionary we have the**
 *
 *with a stack we can push data onto the top of the stack and peek at the data thats on the top of the data and there is a pop method that removes the method off
 *the top of the stack and when we start our game we push all of our disks onto post A 
 *
 *we have 3 didks on post A and start from A (souce post) and move to post C (destination post) and keep doing recursively and if we try to move**
 *a disk thats too large like moving 3 to a one then we say they cant do that because 3 is larger than 1 and the source and destination post is sotred**
 *and to see for that we can peek at the stack at the source and destination post and if the top disk on the source post is more than the destionation post**
 *it knows its bigger and lets us know we cant move it otherwise if we can move it we pop from that post and push it onto the new post (where does it** 
 *tell us that a value is bigger thsn the other and that we cant move)**
 *
 *all the disks need to be moved to post C and the count tells us how many elements are in our stack (stack has a count property to tell us length (size) of stack)**
 *put a floor on a stack and if we have 3 disks on our post (blocks) then we put block 4 as a floor on the bottom of the post so that**
 *we always have 1 block on each post so we dont have to worry about empty stack because we cant read data in it and we cant peek then if its empty because**
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
 *to populate our queue with our moves to solve the game we pass the user if they want to autosolve and if they say yes we call the gamesolver method where we pass**
 *in our disks (blocks) and all of the posts and in our gamaesolver we want to recursivley for our 3 possiblities from a to c and we can move from**
 *a to c using b as spare or a to b using c as spare and going frmo b to c using a as the spare (3 possbilities)  and each time along the way we add**
 *the from and the to as the strings as the commands of moving from which post to the destination post and adding that as the post in our queue**
 *
 *linked lists:
 *another generic data type LinkedList<object> name (it uses <> for generic datatype)**
 *with an array when we added elements to an array we had to create a new array that had 11 numbers that copied our 10 numbers then added our new number if we wanted
 *to add a new number to our array and same thing to remove and create ana rray with one less number we have to recreate the array as well
 *for linked list they are a chain of data and if we want to insert a new piece of data we break the chain where we want to insert it and 
 *add it to the chain in a linked list each data in the linked list is a node and the node contains the data stored and pointers that point to the next node
 *and the previous node (double linked list with link to next and orevious node)** our node that has 12 is poiintng to node that has 99 and if we want to put a new node**
 *then we change 12 node point to node 37 and have our 37 point to node 99 and all we need to do is insert wherever we want to the new piece of data**
 *readings through the list we can only read through the start to end and its ineffeicent because for arrays we could just index but for linked lists**
 *we have to go through everything** linked lists are efficient for adding and removing but inefficent for accessing specific data (have to go
 *through everything) while array is good for**
 *getting specici data but ineffiencet for adding and removing (have to make new array each time we want to add or remove)**
 *
 *to create a lninked list of strings we say LinkedList<string> sentence  = new LinkedList<string>(); (can we make linked lists have stacks, and queues,
 *lists and arrays or is it only one datatype like int or string same for stacks and queues)***** linked list is a class so we have to do the new operator
 *and have an equal sign we could also have a linked list based on our array of strings by passing the array in the constructor in the () ater ther = sign and
 *it makes each array item a seperate node in the linked list right******
 *we can add new strings to end of linked list by using .addlast to add the node at the end of the linked list**
 *to add to beginning we do .addfirst which adds new node to beginning of node**
 * 
 * 
 */