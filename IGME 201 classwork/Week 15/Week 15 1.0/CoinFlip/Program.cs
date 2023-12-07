/// enabled which adjacency test to use: matrix or list
//#define USE_MATRIX

// represent game as directed graph (for AI version) or not (for human player)
#define DIGRAPH //use this to define a symbol and it will enable the code**

//do we have to use the # on the exam or not since we only have a directed graph and we are not doing any AI**
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
using System.Threading;

namespace CoinFlip
{
    enum ECoinState //enumerated type for each state of the coin**
    {
        TTT,
        TTH,
        THT,
        THH,
        HTT,
        HTH,
        HHT,
        HHH
    }

    static class Program
    {

#if DIGRAPH

        //each row corresponds to a certain state and go from 0-7 so it corresponds to state of the coin** 
        //for the final exam instead of something logical like numbers then we would make enumerated type list of colors thne we
        //have to know yellow might be 0th row in our array and orange might be 1 and we need to map those in a logical way**
        //if we have weights on our graph we need to have a way to add weight information to an array and make our array integers
        //and make intersection the number of the edge**
        //use minus 1 as the wight as long as there are no negative wieghts in the graph**

        //this is our directed graph**


        //this shows us where we can walk to and the source is the row and the target is the column and if the intersection of the source
        //and target is true then we can walk that path and the edge is available to us

        //ASK:
        //this basically shows whatever possible paths we can take in our graph (where the arrows point to)**
        //so basically in terms of the exam each row and column would corresspond to a row and color and we would use**
        //the arrows to set it true or false for if it connected to a certain color or not and if it's double arrows we count it both ways**
        //do we do anything with the weights for the adjacency matrix and adjacency lists for the exam or is it just by color and arrow**
        //and the weights are for dikstjras shortest path algoritm**
        //how would we do the adjacency matrix and adjacency list as wighted**
        //for the exam we can make it any order for example we can start at red for row 0 column 0 then move on like that but colors
        //have to be consistent for the row and column number right**
        //if the node does not point to anything we would still include it in our adjacency matrix right but the whole row would be false like
        //it was for the destination (HTH)**
        // the adjacency values for the directed graph version.  
        // Only allow the paths that reach the goal
        static bool[,] mGraph = new bool[,]
        //this is the same order as the undirected graph right in terms of the rows and columns**
        {
                    // "TTT"     "TTH"    THT       THH       HTT      HTH        HHT       HHH
           /* TTT */ { false   , true    , false   , false   , true    , false   , false   , false },
           /* TTH */ { false   , false   , false   , true    , false   , false   , false   , false },
           /* THT */ { true    , false   , false   , false   , false   , false   , false   , false },
           /* THH */ { false   , false   , false   , false   , false   , false   , false   , true },
           /* HTT */ { false   , false   , false   , false   , false   , false   , true    , false },
           /* HTH */ { false   , false   , false   , false   , false   , false   , false   , false },
           /* HHT */ { false   , false   , false   , false   , false   , false   , false   , true },
           /* HHH */ { false   , false   , false   , false   , false   , true    , false   , false }
        };

        static int[][] lGraph = new int[][]

        
            //this is the adjacency list** and we make it a jagged array to make it easier to read through**
            //initialize all of our array elements in one code block**
            //new int[] { 1, 2, 4 }, //these are verticies attached to the vertex thats associated to the row 
            //each row is the verticies that are attached to the vertex that is represented by that row
            //the first row in our array is TTT

            //ASK: 
            //use enumerated type as intengers and if we had our colors then our colors would be enumerated type and we can access them as integers
            //by casting them as an int. like we did here**

            //jagged array and the first dimension is each row and its the source vertex from the adjacency matrix and our list of adjacent verticies are
            //the verticies (for each source or row thats the verticies connected to it)**

            //for each row associated in the adjacency matrix above, we create a new array and use the enumerated types to show for that specific
            //row this vertex is in** what vertcicies by the enumerated number instead of letters are attached to**
            //(only use the attched enumerated values for arrows that go to a vertex not arrows that come into the current**
            //vertex only the ones coming out of the current vertex)**

            //for adjacency matrix and list we only count it when the arrow is coming out of the current vertex not the arrows coming into the vertex**

            //why would we want to use the integer values here instead of the name**

            //for the enumerated types that do not have any arrows coming out of it (can have arrows coming into it though) in the adjacency matrix
            //we would make the whole row false but still include the row but in the adjacency list, we would just say null for that current row 
            //so we dont have to make an array for it**

            //how would we account for weights here as well as in the adjacency matrix**

            //for adjacency matrix and list it has to be the same number of arrays corresponding to the rows of the adjacency matrix and same order as the rows
            //in the adjacenecy matrix within the adjacency list right** so thats why we have to say null for HTH for the adjacency list**


        {
            //does it matter which order we put it if one vertex connects to 2 or more different verticies like here or can we put it in any order
            //for all the entries or should we stay consistent**
            new int[] { (int)ECoinState.TTH,(int)ECoinState.HTT },
            new int[] { (int)ECoinState.THH },
            new int[] { (int)ECoinState.TTT },
            new int[] { (int)ECoinState.HHH },
            new int[] { (int)ECoinState.HHT },
            null,
            new int[] { (int)ECoinState.HHH },
            new int[] { (int)ECoinState.HTH }

            //ASK: HOW DO WE CHECK IF OUR DATA IS CORRECT DO WE JUST DO CONSOLE STATEMENTS OR HOW DOES THAT WORK**
        };
#else
        // the adjacency values for the non-directed graph version.  
        // Allow all possible paths

        //ASK: 
        //the verticies go both ways here whereas the one above that was directed it only goes according to the arrows**
        static bool[,] mGraph = new bool[,]
        {
                   // "TTT"     "TTH"    THT       THH       HTT      HTH        HHT       HHH
         /* TTT */  { false   , true    , true    , false   , true    , false   , false   , false },
         /* TTH */  { true    , false   , false   , true    , false   , false   , false   , false },
         /* THT */  { true    , false   , false   , false   , false   , false   , false   , false },
         /* THH */  { false   , true    , false   , false   , false   , false   , false   , true  },
         /* HTT */  { true    , false   , false   , false   , false   , false   , true    , false },
         /* HTH */  { false   , false   , false   , false   , false   , false   , false   , true  },
         /* HHT */  { false   , false   , false   , false   , true    , false   , false   , true  },
         /* HHH */  { false   , false   , false   , true    , false   , true    , true    , false }
        };

        static int[][] lGraph = new int[][]
        {
            /* TTT */ new int[] { (int)ECoinState.TTH, (int)ECoinState.THT, (int)ECoinState.HTT },
            /* TTH */ new int[] { (int)ECoinState.TTT, (int)ECoinState.THH },
            /* THT */ new int[] { (int)ECoinState.TTT },
            /* THH */ new int[] { (int)ECoinState.TTH, (int)ECoinState.HHH },
            /* HTT */ new int[] { (int)ECoinState.TTT, (int)ECoinState.HHT },
            /* HTH */ new int[] { (int)ECoinState.HHH },
            /* HHT */ new int[] { (int)ECoinState.HTT, (int)ECoinState.HHH },
            /* HHH */ new int[] { (int)ECoinState.THH, (int)ECoinState.HTH, (int)ECoinState.HHT }
        };
#endif

        static List<Node> game = new List<Node>();

        // variable to request DFS() AI for next move
        static bool bWaitingForMove = false;

        // the current numeric representation of the coin state
        //ASK: why would we want to access via the enumerated type integer from the user input (convert user input to the enumerated type number)**
        static int nState = 0;

        // the user-entered string representation of the desired coin state
        static string sUserState;

        // mutex (mutual exclusive lock) which will give exclusive access to bWaitingForMove
        //ASK: we dont have to use this on the exam right all we have to do is the adjecncy matrix, list, depth first method,
        //and diksjras shortest path right**
        static object lockObject = new object();

        static void Main(string[] args)
        {
            Random rand = new Random();
            Node node;

            //node = new Node((int)ECoinState.TTT);
            //game.Add(node);
            //
            //node = new Node((int)ECoinState.TTH);
            //game.Add(node);
            //
            //node = new Node((int)ECoinState.THT);
            //game.Add(node);
            //
            //node = new Node((int)ECoinState.THH);
            //game.Add(node);
            //
            //node = new Node((int)ECoinState.HTT);
            //game.Add(node);
            //
            //node = new Node((int)ECoinState.HTH);
            //game.Add(node);
            //
            //node = new Node((int)ECoinState.HHT);
            //game.Add(node);
            //
            //node = new Node((int)ECoinState.HHH);
            //game.Add(node);
            //
            //game[(int)ECoinState.TTT].AddEdge(1, game[(int)ECoinState.TTH]);
            //game[(int)ECoinState.TTT].AddEdge(2, game[(int)ECoinState.THT]);
            //game[(int)ECoinState.TTT].AddEdge(4, game[(int)ECoinState.HTT]);
            //game[(int)ECoinState.TTT].edges.Sort();
            //
            //game[(int)ECoinState.TTH].AddEdge(1, game[(int)ECoinState.TTT]);
            //game[(int)ECoinState.TTH].AddEdge(3, game[(int)ECoinState.THH]);
            //game[(int)ECoinState.TTH].edges.Sort();
            //
            //game[(int)ECoinState.THT].AddEdge(2, game[(int)ECoinState.TTT]);
            //game[(int)ECoinState.THT].edges.Sort();
            //
            //game[(int)ECoinState.THH].AddEdge(3, game[(int)ECoinState.TTH]);
            //game[(int)ECoinState.THH].AddEdge(7, game[(int)ECoinState.HHH]);
            //game[(int)ECoinState.THH].edges.Sort();
            //
            //game[(int)ECoinState.HTT].AddEdge(4, game[(int)ECoinState.TTT]);
            //game[(int)ECoinState.HTT].AddEdge(6, game[(int)ECoinState.HHT]); //5 not 6 right**
            //game[(int)ECoinState.HTT].edges.Sort();
            //
            //game[(int)ECoinState.HTH].AddEdge(7, game[(int)ECoinState.HHH]);
            //game[(int)ECoinState.HTH].edges.Sort();
            //
            //game[(int)ECoinState.HHT].AddEdge(6, game[(int)ECoinState.HTT]); //5 not 6 right**
            //game[(int)ECoinState.HHT].AddEdge(7, game[(int)ECoinState.HHH]);
            //game[(int)ECoinState.HHT].edges.Sort();
            //
            //game[(int)ECoinState.HHH].AddEdge(7, game[(int)ECoinState.THH]);
            //game[(int)ECoinState.HHH].AddEdge(7, game[(int)ECoinState.HTH]);
            //game[(int)ECoinState.HHH].AddEdge(7, game[(int)ECoinState.HHT]);
            //game[(int)ECoinState.HHH].edges.Sort();
            //
            //List<Node> shortestPath = GetShortestPathDijkstra();

            // the current string representation of the coin state
            string sState;
            
            // the user-entered numeric representation of the desired coin state
            int nUserState;

            // count how many moves to win
            int nMoves = 0;

            // start with a random state that is not HTH (the goal)
            while (true)
            {
                nState = rand.Next(0, 8);

                // don't start with HTH
                if (nState != (int)ECoinState.HTH)
                {
                    break;
                }
            }

            // create thread running DFS() for AI fetching the next move
            Thread t = new Thread(DFS);
            t.Start();



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



            // while not a winner
            while (nState != (int)ECoinState.HTH)
            {
                //ASK: convert the current numeric state to a string that we got from our while loop above**
                sState = ((ECoinState)nState).ToString();

                // output the current state
                Console.WriteLine("Current coin state: " + sState);

                // prompt for the desired state
                Console.Write("Enter the desired state: ");
                sUserState = Console.ReadLine().ToUpper();

                //ASK: GO OVER THIS BELOW**
                // set mutex to give exclusice access to changing shared variable
                lock(lockObject)
                { 
                    // lock acquired, change the variable to indicate we are waiting for next move
                    bWaitingForMove = true;
                }
                
                // wait until bWaitingForMove is set to false by DFS()
                while (bWaitingForMove) ; //just waiting and there is nothing to do in the loop so we dont put anything in and wait**

                nUserState = (int)Enum.Parse(typeof(ECoinState),sUserState);
                Console.WriteLine(sUserState); //this is when we are not waiting for the move anymore and we convert the state we had gotten back**

#if USE_MATRIX
                //ASK: row is what we are currently on in the adjacency matrix and we compare that to what the user put in (go through the columns for that row 
                //we are currently on) and if the row and column entry is true we increase the moves to count how many moves they have taken
                //to solve the coin flip otherwise if its false we say the move is invalid**
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
                //ASK: this is the second method we can use instead of the first where we get the state based on the number (why would we do it based on number though
                //is it because we are indexing via a number so we need the enumerated type value and by default the enumerated type starts at 0 and incrases**
                int[] thisStateList = lGraph[nState];
                bool valid = false;

                if (thisStateList != null) //if the index we have was no null (rather true or false)**
                {
                    foreach (int n in thisStateList) //ASK: we go through the list and if the numeric value the user entered for the coin flip
                        //equals our array value then we make the valid state true, change the state, and increase the moves then leave the method
                        //otherwise we say it was an invalid move**
                        //why do we have to go through integers here is it because we are going through the array of the enumerated type numbers
                        //that connect each vertex**

                        //ASK: the thisstatelist is basically going to get 1 single array based on the index we padd in because it goes through the array of arrays
                        //to get 1 array for a vertex to see what its connected to**

                        //we got the nusertstate from the above loop**
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
            t.Abort();
        }

        //GO OVER ALL BELOW**
        //is this depth or breadth search**
        // A function used by DFS 
        static void DFSUtil(int v, bool[] visited)
        {
            // wait for the request for the next move
            while (!bWaitingForMove) ;
            //while (bWaitingForMove == false) ;

            // Mark the current node as visited 
            visited[v] = true;

            sUserState = ((ECoinState)v).ToString();

            // print the current node 
            //Console.Write(v + " ");

            // lock the mutex to change the shared boolean variable
            lock (lockObject)
            {
                // no longer waiting for move
                bWaitingForMove = false;
            }

            // Recur for all the vertices 
            // adjacent to this vertex if there are any
            int[] thisStateList = lGraph[v];
            if (thisStateList != null)
            {
                foreach (int n in thisStateList)
                {
                    if (!visited[n])
                    {
                        DFSUtil(n, visited);
                    }
                }
            }
        }

        // The function to do DFS traversal. 
        // It uses recursive DFSUtil() 
        static void DFS( )
        {
            // Mark all the vertices as not visited 
            // (set as false by default in c#) 
            bool[] visited = new bool[lGraph.Length];

            // Call the recursive helper function 
            // to print DFS traversal 
            DFSUtil(nState, visited);
        }
        
        //ASK: we are going over all of this next class right because I was a bit confused when we talked about it since it was at the end of class
        //and it was rushed**
        /****************************************************************************************
        The Dijkstra algorithm was discovered in 1959 by Edsger Dijkstra.
        This is how it works:
        
        1. From the start node, add all connected nodes to a priority queue.
        2. Sort the priority queue by lowest cost and make the first node the current node.
           For every child node, select the shortest path to start.
           When all edges have been investigated from a node, that node is "Visited" 
           and you don´t need to go there again.
        3. Add each child node connected to the current node to the priority queue.
        4. Go to step 2 until the queue is empty.
        5. Recursively create a list of each node that defines the shortest path 
           from end to start.
        6. Reverse the list and you have found the shortest path
        
        In other words, recursively for every child of a node, measure its distance to the start. 
        Store the distance and what node led to the shortest path to start. When you reach the end 
        node, recursively go back to the start the shortest way, reverse that list and you have the 
        shortest path.
        ******************************************************************************************/

        static public List<Node> GetShortestPathDijkstra()
        {
            // set up all distances from every vertex to the start vertex
            DijkstraSearch();

            // the list of nodes that will be the shortest path from the start
            List<Node> shortestPath = new List<Node>();

            // add the target node
            shortestPath.Add(game[(int)ECoinState.HTH]);

            // populate the List of nodes from the target node back to the start
            BuildShortestPath(shortestPath, game[(int)ECoinState.HTH]);

            // reverse the List to give the path from the start to the finish
            shortestPath.Reverse();

            return( shortestPath );
        }

        static private void BuildShortestPath(List<Node> list, Node node)
        {
            if (node.nearestToStart == null)
            {
                return;
            }

            list.Add(node.nearestToStart);
            BuildShortestPath(list, node.nearestToStart);
        }

        static private int NodeOrderBy(Node n)
        {
            return n.minCostToStart;
        }

        static private void DijkstraSearch()
        {
            Node start = game[(int)ECoinState.THT];

            start.minCostToStart = 0;
            List<Node> prioQueue = new List<Node>();
            prioQueue.Add(start);

            //Func<Node, int> nodeOrderBy = new Func<Node, int>(NodeOrderBy);
            Func<Node, int> nodeOrderBy = NodeOrderBy;

            do
            {
                // sort our prioQueue by minCostToStart
                // option #1, use .Sort() which sorts in place
                prioQueue.Sort();

                // option #2, use .OrderBy() with a delegate method or lambda expression 
                // the next 5 lines are equivalent from descriptive to abbreviated:
                prioQueue = prioQueue.OrderBy(nodeOrderBy).ToList();
                prioQueue = prioQueue.OrderBy(delegate (Node n) { return n.minCostToStart; }).ToList();
                prioQueue = prioQueue.OrderBy((Node n) => { return n.minCostToStart; }).ToList();
                prioQueue = prioQueue.OrderBy((n) => { return n.minCostToStart; }).ToList();
                prioQueue = prioQueue.OrderBy((n) => n.minCostToStart ).ToList();
                prioQueue = prioQueue.OrderBy( n => n.minCostToStart ).ToList();

                Node node = prioQueue.First();
                prioQueue.Remove(node);
                foreach (Edge cnn in node.edges)
                // if we do not sort each list of edges after populating them for a node,
                // we can create a temporary sorted list for this loop
                //.OrderBy(delegate(Edge n) { return n.cost; }))
                {
                    // look at the neighbor connected to this edge
                    Node neighborNode = cnn.connectedNode;
                    if (neighborNode.visited)
                    {
                        // skip if we already visited this neighbor
                        continue;
                    }
                      
                    // if this neighbor has not been evaluated yet or
                    // it is closer than the current path to start
                    if (neighborNode.minCostToStart == int.MaxValue ||
                        node.minCostToStart + cnn.cost < neighborNode.minCostToStart)
                    {
                        // update the cost to start
                        neighborNode.minCostToStart = node.minCostToStart + cnn.cost;

                        // set the node heading back to start from this neighbor to the 
                        // node we got here by
                        neighborNode.nearestToStart = node;

                        // if we don't have this neighbor in our queue
                        if (!prioQueue.Contains(neighborNode))
                        {
                            // add it
                            prioQueue.Add(neighborNode);
                        }
                    }
                }

                // set this node as visited
                node.visited = true;

                // if we reached the target node
                if (node == game[(int)ECoinState.HTH])
                {
                    // we're done!
                    return;
                }

            // stay in this loop while there are any items left in our queue
            } while (prioQueue.Any());
        }
    }

    public class Node : IComparable<Node>


    /*
     * set he starting vertex to 0 then it gives us the shortest path from 0 to each other node in our graph 
     * we need to create a queue and from our starting node we add all the connected nodes to a queue then sort it by the lowest cost back to the node
     *we started at and make the first node to our current node and finds shortest path from start node to each of the ndoes back to the starting node**
     *and when all of our edges are gone through and set the node as visited and dont need to go there again then add those child nodes to our queue and do the same thing
     *until the queue is empty then recursively create a list of the nodes from the shortest path and we check if we got to our ending node and at that point we 
     *have the shortest path from the starting node to the starting node then reverse the list to get the shortest path**
     *
     *walk all the way from graph in every possible way and save the shortest path and just follow the shorter distances back to start and we have to visit every
     *vertex in the graph and save the distances on the way**
     */
    {
        public int nState;
        public List<Edge> edges = new List<Edge>();

        public int minCostToStart;
        public Node nearestToStart;
        public bool visited;

        public Node(int nState)
        {
            this.nState = nState;
            this.minCostToStart = int.MaxValue;
        }

        public void AddEdge(int cost, Node connection)
        {
            Edge e = new Edge(cost, connection);
            edges.Add(e);
        }

        public int CompareTo(Node n)
        {
            return this.minCostToStart.CompareTo(n.minCostToStart);
        }
    }

    public class Edge : IComparable<Edge>
    {
        public int cost;
        public Node connectedNode;

        public Edge(int cost, Node connectedNode)
        {
            this.cost = cost;
            this.connectedNode = connectedNode;
        }

        public int CompareTo(Edge e)
        {
            return this.cost.CompareTo(e.cost);
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