/// enabled which adjacency test to use: matrix or list
//#define USE_MATRIX

// represent game as directed graph (for AI version) or not (for human player)
//#define DIGRAPH use this to define a symbol and it will enable the code**

//do we have to use the # on the exam or not since we only have a directed graph**
//how would we do this if it was wieghted what would be the main difference**

//if we want to search our graph to find nodes in our graph like our binary search tree we can do it with graphs and we can search in a depth first way (search
//all the way down a path or up) and a bredth first way (it would go from each level and it would go from TTT to TTH then TTT to HTT for one level then do the same thing
//going back to TTT to go to the next level nodes)


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace CoinFlip
{
    class Program
    {

#if DIGRAPH //enable and disable code blocks use #if
        // the adjacency values for the directed graph version.  
        // Only allow the paths that reach the goal
        static bool[,] mGraph = new bool[,]
        {
        //if its a directied graph our adjacnecy matrix will be different but if is was undirected then we could move in either direction
        //and it foreces player tog et to answer with directed graph**
           { false   , true    , false   , false   , true    , false   , false   , false },
           { false   , false   , false   , true    , false   , false   , false   , false },
           { true    , false   , false   , false   , false   , false   , false   , false },
           { false   , false   , false   , false   , false   , false   , false   , true },
           { false   , false   , false   , false   , false   , false   , true    , false },
           { false   , false   , false   , false   , false   , false   , false   , false },
           { false   , false   , false   , false   , false   , false   , false   , true },
           { false   , false   , false   , false   , false   , true    , false   , false }
        };

        static int[][] lGraph = new int[][] //go over**
        {
            new int[] { 1, 4 },
            new int[] { 3 },
            new int[] { 0 },
            new int[] { 7 },
            new int[] { 6 },
            null,
            new int[] { 7 },
            new int[] { 5 }
        };
#else
        // the adjacency values for the non-directed graph version.  
        // Allow all possible paths
        static bool[,] mGraph = new bool[,]
        //each row corresponds to a certain state and go from 0-7 so it corresponds to state of the coin** 
        //for the final exam instead of something logical like numbers then we would make enumerated type list of colors thne we
        //have to know yellow might be 0th row in our array and orange might be 1 and we need to map those in a logical way**
        //if we have weights on our graph we need to have a way to add weight information to an array and make our array integers
        //and make intersection the number of the edge**
        //use minus 1 as the wight as long as there are no negative wieghts in the graph**

        //this is our undirected graph**
        {
           { false   , true    , true    , false   , true    , false   , false   , false },
           { true    , false   , false   , true    , false   , false   , false   , false },
           { true    , false   , false   , false   , false   , false   , false   , false },
           { false   , true    , false   , false   , false   , false   , false   , true  },
           { true    , false   , false   , false   , false   , false   , true    , false },
           { false   , false   , false   , false   , false   , false   , false   , true  },
           { false   , false   , false   , false   , true    , false   , false   , true  },
           { false   , false   , false   , true    , false   , true    , true    , false }

            //this shows us where we can walk to and the source is the row and the target is the column and if the intersection of the source
            //and target is true then we can walk that path and the edge is available to us
        };

        static int[][] lGraph = new int[][]
        {
            //use enumerated type as intengers and if we had our colors then our colors would be enumerated type and we can access them as integers
            //by casting them as an int. like we did here**

            //this is the adjacency list** and we make it a jagged array to make it easier to read through**
            //initialize all of our array elements in one code block**
            new int[] { 1, 2, 4 }, //these are to verticies attached to the vertex thats associated to the row 
            //each row is the verticies that are attached to the vertex that is represented by that row
            //the first row in our array is TTT

            //jagged array and the first dimension is each row and its the source vertex from the adjacency matrix and our list of adjacent verticies are
            //the verticies (for each source or row thats the verticies connected to it)**
            new int[] { 0, 3 },
            new int[] { 0 },
            new int[] { 1, 7 },
            new int[] { 0, 6 },
            new int[] { 7 },
            new int[] { 4, 7 },
            new int[] { 3, 5, 6 }
        };
#endif

        static void Main(string[] args)
        {
            Random rand = new Random();

            // the current string representation of the coin state
            string sState;

            // the current numeric representation of the coin state
            //convert the string to the integer equivilent which will be 0-7 for enumerated type**
            int nState = 0;
            
            // the user-entered string representation of the desired coin state
            //so the user can say how they want to flip the coin**
            string sUserState;

            // the user-entered numeric representation of the desired coin state
            int nUserState;

            // count how many moves to win
            int nMoves = 0;

            // start with a random state that is not HTH (the goal)
            //while loop to pick starting vertex we are on and as long as it didnt pick HTH we are good then**
            while (true)
            {
                nState = rand.Next(0, 8);

                // don't start with HTH
                if (nState != 5)
                {
                    break;
                }
            }

            // while not a winner
            //convert the current state to a string and we can take the current state and cast it as an enumerated type then convert it into a string 
            //and it converts our code into a ebunerated type so it's easier to read and it tells the state we are currently in (english word we defined in the
            //enumerated type)**
            //write our the current state and enter what state they want to move to and read their state from the console as a string then set the integer
            //value to what they typed into an enumerted type which is the integer equivilent to the english version and write our what they typed in
            //and check what they entered is a valid state and #if use_matrix and we can use the matrix to do our check or we can use our adjacency list and
            //the gray part is easier because we read the source and target state and the source state is the rows and the target state is the columns and if we 
            //want to go from HTT and the suer types HTH and we say we are at HTT and the users move to HTH is false so they can't move there and it lets us
            //determine if its the right move**
            //if the intersection fo the current state in the game and the state the user wants to move to it tell them its not a vlaid move 
            //because its false in the adjacency matrix otherwise we**

            //we need through jagged array and set array of integers equal to the array at the current state of our coins 
            //nState is our current state and lGraph is the entry of our jagged array which is the row entry and if HTT and if they wanted to move to THT and THT is not
            //in the array assocated in that row so we need to grab that array and iterate through the array of our row and we point to the array at that row 
            //and we need to make sure the array has values (if there were no connections we need to support that as well) and  iterate through the array and if we 
            //find an entry that matches the state the user entered we can then set a boolean and say it's a valid move and set our new game state to the valid state 
            //and break out of our loop and if valid is still false tell them its an invalid loop
            //and everything is in a while loop while we have not reached the target state which is HTH and we end if they had won the game**

            //the thread is used to have 0 player game for the computer to play the game for us**

            //current coin state is TTH and we cna move in any direction in this program specifically or**
            //we enter TTT and if we move to that state and if we say HTH it will be wrong because there was no link
            //and we are stuck at TTT now and now we move to HTT then THT then go to HTH 
            while (nState != 5)
            {
                // convert the current numeric state to a string
                sState = NState2SState(nState);

                // output the current state
                Console.WriteLine("Current coin state: " + sState);

                // prompt for the desired state
                Console.Write("Enter the desired state: ");
                sUserState = Console.ReadLine().ToUpper();

                nUserState = SState2NState(sUserState);

#if USE_MATRIX
                if (mGraph[nState, nUserState])
                {
                    nState = nUserState;
                    ++nMoves;
                }
                else
                {
                    Console.WriteLine("That is an invalid move.");
                }
#else
                int[] thisStateList = lGraph[nState];
                bool valid = false;

                if (thisStateList != null)
                {
                    foreach (int n in thisStateList)
                    {
                        if (n == nUserState)
                        {
                            valid = true;
                            nState = nUserState;
                            ++nMoves;
                            break;
                        }
                    }
                }

                if (!valid)
                {
                    Console.WriteLine("That is an invalid move.");
                }
#endif
            }

            Console.WriteLine($"You won in {nMoves} moves!");
        }

        // convert the string to the equivalent 2-based integer
        static int SState2NState(string sState)
        {
            int nState = 0;

            // HHT should be converted to 6
            for(int i = 0; i < 3; ++i )
            {
                if( sState[i] == 'H')
                {
                    nState += (1 << (2 - i));
                }
            }

            return (nState);
        }

        // convert the 2-based integer to the equivalent string
        static string NState2SState( int nState)
        {
            string r = null;

            // 6 should be HHT
            for (int i = 0; i < 3; ++i)
            {
                if( (nState & (1 << (2 - i))) != 0 )
                {
                    r += "H";
                }
                else
                {
                    r += "T";
                }
            }

            return (r);
        }
    }
}


//write utility method for our breadth first search and a DFS parent method which does the search and the utility method which is the recusrive method which
//is a helper and we set up a boolean array to tell us if we visited**
//we have the number of nodes in our graph and if we had visited that node yet and we create and array of the lGraph then call the recursive method from the current
//state and pass in the visited array by reference and by default arrays are referecnce variables and we want to mark each node whether we visited the ndoe or not
//and we pass in the vertex and the array and we set the array element to true then we want to recurse through the method for each of the verticies adjacent to the
//vertex list and it fets the list of verticies adjacent to current vertex and if we had not visited that vertex yet we call our utility method again with that specific
//and passing in the visited array**

//we can use this bredth first search to play a game and it can find the next move for the computer and we would have the computer look through the next vertex to find
//the next best move and it's done for us with our graph because we have it directional so we enable to digraph version and define it and it endables the digraph code 
//and our graph only has the valid moves as described by the logical representation where the arrays are on our edges (we unclocked the defintion on the top of the
//program) and we have a boolean to wait to see if the computer made a move and we want to call a depth first search and wait for it to return the next move

//and in order to communicate with depth first search we use waiting for move boolean and we have a thread for the DFS (deapth irst search) method and we want to start
//the thread when the application starts which is the AI part of the game and we want it to find next move to find valid answer and we only want to get a move
//when our boolean waiting for move is set to true and while be waiting for move is false and while we are not waiting for a move we want to wait and once
//be waiting for move is set to true we get the next move by going to the next vertex of the current state and setting our user state string and have the computer
//set the suerstate instead and because we have 2 processes looking at the same varible it's called a mutex which is a mutally lock**
//if we have 2 programs accessing the same varible we can run into a problem where one application tried to change a varible at the same time as the other which
//we dont want to happen and we want to stay in the loop in our main until the DFS has found the next move and we output the coin state and set the waitign for move to true
//so it triggers our DFS thread to leave the loop because waiting for move is true then we get our move then set waiting for move to false and its waiting for
//DFS thread to set the waiting to move to false and we want to set a lock that only allows only one change at a time**
//we use an object to do that and use the class scoped object and it's just used for setting up a lock and with that object we call
//the lock command and it will only call the waiting for move to true once it locks the object so we cna only edit that varible then so nothing else can
//change the varible at the same time** in our thread when we chose our move we can lock our mutex and change our varuble to false**

//we initialize waiting for move to false and we have suserstate as a class scoped varible because we need it in DFS method and the main**


//breadth search and it goes by each level and it goes one level deep at a time then it goes down to each node 1 level deep 
//and it always goes down 1 level at a time whereas the the depth first search goes down a path as far at it can and it goes down each path as far as it can
//each time it goes back to the original node then goes to the max depth then the next level**

//breadth first search uses queue and depth uses stack
//the queue is used by diksjras shortest path algorithm and it recursively goes down through the graph and its recursive and
//for our binary search tree it uses a queue and it loads the queue in a way so it goes across each 
//level  of the tree and it would not go down all the branches and it loads them into the queue and loads only one level at a time by just loading each less than 
//child branch and greather than or equal to branch