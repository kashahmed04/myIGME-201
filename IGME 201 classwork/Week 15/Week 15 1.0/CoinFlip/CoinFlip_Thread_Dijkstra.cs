/// enabled which adjacency test to use: matrix or list
//#define USE_MATRIX

// represent game as directed graph (for AI version) or not (for human player)
//#define DIGRAPH

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using System.Threading;



/*
 * Big O Notation:
 * 
 * way we can represent complexity of algorithms and big O means order of complexitity so all data types we have looked at are in here and some we have not
 * looked at, and to access data it's O(1) adn we do one read and we get our data we need for a regular array and it's O(N) to find data in the stack, queue, or linked
 * list so it takes longer to find the thing we are looking for in the list, and the binary search tree its o(log(N)) and if its balanced then its the best performing
 * data structure and for inserting stacks and queues and linked lists are efficient because we just insert rather than creating a new array and copying the contents
 * of the old array into the new one** and deletion is the same concept as insertion and binary search is the most efficient because the O(log(N)) graph
 * is not linear and our O(N) is linear and the more items the more time it takes but for the O(log(N)) it cuts the search in half so the more items there are 
 * its not a linear structure of the time 
 * 
 * Singleton classes:
 * specific way to define a class so only one object of that class can ever be created and its a way that we only ever have access to only one instance
 * of the class and we would want that if our application had to write a log then we would want to have access to a log file from everywhere in our application
 * and it would be more useful to have one handle to our log file and we could just that instance to add things into that instance (easier to have a single handle
 * to an instance)**
 * 
 * we can have an eager loading singleton and its creates as soon as the application starts and dont have to worry about if its there or not and less
 * resource efficient and its always availble even though our appliciton does not use this class (takes up memeory)**
 * 
 * our constructor for the logging class is private and if the constructor is private then we can't create an object of that class because we cant use that
 * constructor anywhere except for our class** and in our main we wont be able to create any objects of our class then we create an instance of this class that is private
 * and static and that instance calls the private constructor thats in the class**
 * 
 * there is then a pubic method that returns the private instance so we can have access to that private instance variable and thats the only instance that will
 * exist in our applucation**
 * 
 * we can define a log class varibale and set it equal to the logging class name. get instance and we are never using new in our main for our singleton**
 * and we only use new once within the class to create the object in the singleton**
 * 
 * within the logger variable we can open the log file and write to the log and anywhere in our code we can access the class
 * object by passing that object around and dont have to worry if it has been created or not** and singleton gives us global access to 1 object
 * without worrying if its the exact object we need because there is only 1 class**
 * 
 * there is also a lazy loading singleton and its only created when we access it and not when the application starts not like the
 * eager loaeding as soon as appliction starts** and it also has a private instance and constructor of itself but the different is that it has an instance property
 * with a get and a set  anc checks if the instance field if null then instantiate (make) it otherwise dont make it and down in our main we can say
 * boss create variable and get the instance property then it checks if it was created or not and if it has not then we create the new object and return it**
 * 
 * 
 * our class has an interface to write to the log file**
 * 
 * Newtonsoft JSON:
 * go to tools then nuget package manager then manage nuget packages for solution then search for the newtonsoft.JSON then press the our project then install then
 * that gives us the package in our code (have to search newton then download it though) and we add the using statement for the newtonsoft.JSON)
 * 
 * 
 * 
 */


namespace CoinFlip

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

{
    static class Program
    {

#if DIGRAPH
        // the adjacency values for the directed graph version.  
        // Only allow the paths that reach the goal
        static bool[,] mGraph = new bool[,]
        {
           { false   , true    , false   , false   , true    , false   , false   , false },
           { false   , false   , false   , true    , false   , false   , false   , false },
           { true    , false   , false   , false   , false   , false   , false   , false },
           { false   , false   , false   , false   , false   , false   , false   , true },
           { false   , false   , false   , false   , false   , false   , true    , false },
           { false   , false   , false   , false   , false   , false   , false   , false },
           { false   , false   , false   , false   , false   , false   , false   , true },
           { false   , false   , false   , false   , false   , true    , false   , false }
        };

        static int[][] lGraph = new int[][]
        {
            new int[] { 1, 4 },
            new int[] { 3 },
            new int[] { 0 },
            new int[] { 7 },
            new int[] { 6 },
            null, //has no neighbors so the array was set to null for HTH and the DFS utils method did not check if the statelist was null to create the crash
            //always make sure we check if thre is a null value for the neighbors**
            new int[] { 7 },
            new int[] { 5 }
        };
#else
        // the adjacency values for the non-directed graph version.  
        // Allow all possible paths
        static bool[,] mGraph = new bool[,]
        {
           { false   , true    , true    , false   , true    , false   , false   , false },
           { true    , false   , false   , true    , false   , false   , false   , false },
           { true    , false   , false   , false   , false   , false   , false   , false },
           { false   , true    , false   , false   , false   , false   , false   , true  },
           { true    , false   , false   , false   , false   , false   , true    , false },
           { false   , false   , false   , false   , false   , false   , false   , true  },
           { false   , false   , false   , false   , true    , false   , false   , true  },
           { false   , false   , false   , true    , false   , true    , true    , false }
        };

        static int[][] lGraph = new int[][]
        {
            new int[] { 1, 2, 4 },
            new int[] { 0, 3 },
            new int[] { 0 },
            new int[] { 1, 7 },
            new int[] { 0, 6 },
            new int[] { 7 },
            new int[] { 4, 7 },
            new int[] { 3, 5, 6 }
        };
#endif

        static List<Node> game = new List<Node>();
        //create game list which will contain all of our nodes for the game**

        //instead of having true false in our adjacency matrix we would have numbers for the exam
        //and use -1 to show there is not a connection with an adjacency list we would have a parallel array 
        //and for the adjacency list we would have cost of edge instead of the non-weighted graph**

        static bool bWaitingForMove = false;

        // the current numeric representation of the coin state
        static int nState = 0;

        // the user-entered string representation of the desired coin state
        static string sUserState;

        static void Main(string[] args)
        {
            Random rand = new Random();
            Node node;

            node = new Node(0);
            game.Add(node);

            node = new Node(1);
            game.Add(node);

            node = new Node(2);
            game.Add(node);

            node = new Node(3);
            game.Add(node);

            node = new Node(4);
            game.Add(node);

            node = new Node(5);
            game.Add(node);

            node = new Node(6);
            game.Add(node);

            node = new Node(7);
            game.Add(node);

            //add our 8 game nodes above


            //go to each node and add their edges 
            //then sort the edges for that one specific node**
            //in the edges we inherit the icomparaable then use that method and sort by cost for each node**
           
            game[0].AddEdge(1, game[1]);
            game[0].AddEdge(2, game[2]);
            game[0].AddEdge(4, game[4]);
            game[0].edges.Sort();

            game[1].AddEdge(1, game[0]);
            game[1].AddEdge(3, game[3]);
            game[1].edges.Sort();

            game[2].AddEdge(2, game[0]);
            game[2].edges.Sort();

            game[3].AddEdge(3, game[1]);
            game[3].AddEdge(7, game[7]);
            game[3].edges.Sort();

            game[4].AddEdge(4, game[0]);
            game[4].AddEdge(6, game[6]);
            game[4].edges.Sort();

            game[5].AddEdge(7, game[7]);
            game[5].edges.Sort();

            game[6].AddEdge(6, game[4]);
            game[6].AddEdge(7, game[7]);
            game[6].edges.Sort();

            game[7].AddEdge(7, game[3]);
            game[7].AddEdge(7, game[5]);
            game[7].AddEdge(7, game[6]);
            //go over**
            game[7].edges.Sort();

            List<Node> shortestPath = GetShortestPathDijkstra();

            foreach(Node spNode in shortestPath)
            {
                Console.WriteLine((ECoinState)spNode.nState);  //write our the state of each node in our shortest path**
                                                               //and this is the shortest path is came up with**

            }

            //list of nodes for the shortest path 

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
                if (nState != 5)
                {
                    break;
                }
            }

            Thread t = new Thread(DFS);
            t.Start();

            // while not a winner
            while (nState != 5)
            {
                // convert the current numeric state to a string
                sState = NState2SState(nState);

                // output the current state
                Console.WriteLine("Current coin state: " + sState);

                // prompt for the desired state
                Console.Write("Enter the desired state: ");
                //sUserState = Console.ReadLine().ToUpper();

                bWaitingForMove = true;
                while (bWaitingForMove) ;

                nUserState = SState2NState(sUserState);
                Console.WriteLine(sUserState);

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
            t.Abort();
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

        // A function used by DFS 
        static void DFSUtil(int v, bool[] visited)
        {
            while (!bWaitingForMove) ;

            // Mark the current node as visited 
            // and print it 
            visited[v] = true;

            //depth first
            //go to deepest level of the tree and walk its way back up for each left and right side 
            //our pre order, post order, and in order traversals are all depth first traversals and go down to the leaves then work their
            //way back up to hit every node in the tree 
            //the pre order traversal is one way to make a copy of the tree but theres also bredeath first and it will go one level at a time
            //and if we read the data left to right acorss each level of the tree then we output M,F,P, etc. and goes in order to list the values 
            //of the nodes of the tree and in order to do breadth first search we use a queue

            //dijskras shortest path:
            //most useful for wirghted graph (edges have costs associated with them) and those costs are the distance between 2 verticies
            //tic tac toe game and each move has a relative string (the moves that get us to winning position have more weight than the moves
            //that the lowest weight)(when we are sunig a map we want the lowest wieght because we want the shortest path to get to another city)
            

            sUserState = NState2SState(v);
            //Console.Write(v + " ");

            bWaitingForMove = false;

            // Recur for all the vertices 
            // adjacent to this vertex 
            int[] thisStateList = lGraph[v];
            foreach (int n in thisStateList)
            {
                if (!visited[n])
                {
                    DFSUtil(n, visited);
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
        
        /****************************************************************************************
        The Dijkstra algorithm was discovered in 1959 by Edsger Dijkstra.
        This is how it works:
        
        1. From the start node, add all connected nodes to a priority queue.
        2. Sort the priority queue by lowest cost and make the first node the current node.
           For every child node, select the best that leads to the shortest path to start.
           When all edges have been investigated from a node, that node is "Visited" 
           and you don´t need to go there again.
        3. Add each child node connected to the current node to the priority queue.
        4. Go to step 2 until the queue is empty.
        5. Recursively create a list of each nodes node that leads the shortest path 
           from end to start.
        6. Reverse the list and you have found the shortest path
        
        In other words, recursively for every child of a node, measure its distance to the start. 
        Store the distance and what node led to the shortest path to start. When you reach the end 
        node, recursively go back to the start the shortest way, reverse that list and you have the 
        shortest path.


        start from the start node then add connected nodes to queue then sort queue by lowest cost and see closeest node first and mak the
        //first node to be the clocest node and every child of that node take the shortest path and have cvistied nods and add each child ndoe to the
        //queue then go bsck to step 2 then sort queue by lowest cost then move to cloeslt node then until we have gone through every node (queue is empty)
        //them recursively**

        //walk back to starting node then make list of those nodes then reverse the list for the shortest path**

        ******************************************************************************************/

        static public List<Node> GetShortestPathDijkstra()
        {
            //analyze the graph and set up distances from start to destination vertex**
            DijkstraSearch();
            //list of nodes of our shortest path and its like a linked list so we add our target node to our shortest path list don below
            List<Node> shortestPath = new List<Node>();
            shortestPath.Add(game[5]);
            //build the shortest path from HTH and we pass in the node we are starting on (target to start)** 
            BuildShortestPath(shortestPath, game[5]);
            //reverse the shortest path list and return it**
            shortestPath.Reverse();
            return( shortestPath );
        }

        static private void BuildShortestPath(List<Node> list, Node node)
        {
            //recursive method that traces its way back to starting node**
            //base case is if**
            if (node.nearestToStart == null)
            {
                return;
            }

            //add each nearest to start element to our list then recursively call it**
            list.Add(node.nearestToStart);
            BuildShortestPath(list, node.nearestToStart);
        }

        static private int NodeOrderBy(Node n)
        {
            return n.minCostToStart; //returns field we are comparing**
        }

        static private void DijkstraSearch()
            //under instructions we can just copy and paste code and just change the start and end nodes**
        {
            Node start = game[2]; //change start game here for exam**
            //set starting node to start from the THT and find shortest path to get to our goal which is HTH 
            

            start.minCostToStart = 0;
            //minimum cost is 0**

            List<Node> prioQueue = new List<Node>();
            //list for our nodes**

            prioQueue.Add(start);
            //add our node into the queue**

            do
            {
                // sort our prioQueue by minCostToStart
                // option #1, use .Sort() which sorts in place
                // and uses the overloaded Node.CompareTo() method

                //sort nodes by minimum cost to start from our queue (list) which is the list of nodes and we need to have compareto in our node class
                //to sort the data from the list**
                prioQueue.Sort();

                // option #2, use .OrderBy() with a delegate method or lambda expression 
                // to indicate which field to sort by
                // the next 5 lines are equivalent from descriptive to abbreviated:
                prioQueue = prioQueue.OrderBy(delegate (Node n) { return n.minCostToStart; }).ToList();
                prioQueue = prioQueue.OrderBy((Node n) => { return n.minCostToStart; }).ToList();
                prioQueue = prioQueue.OrderBy((n) => { return n.minCostToStart; }).ToList();
                prioQueue = prioQueue.OrderBy((n) => n.minCostToStart ).ToList();
                prioQueue = prioQueue.OrderBy( n => n.minCostToStart ).ToList();

                Node node = prioQueue.First(); //set node variable to first item in our queue then remove it then
                //look at all the edges of our node
                prioQueue.Remove(node);
                foreach (Edge cnn in node.edges)
                //if we did not sort each list of edges after populating them for a node, we can create a trmporary sorted list for this loop
                //.OrderBy(delegate(Edge n) { return n.cost; }))
                {
                    Node childNode = cnn.connectedNode; //look at each neighbor connected to this edge and if we visited it alrrady we skip it but
                    //if the cost is infinity or 2 billion in this case or if this node is closer than the neighboring node we are looking at then
                    //we want to update the cost to start and we want to nearest to start to our node and add it to our queue 
                    //and when we go next to process in our queue we look at this neighbor node and trace from there
                    //and this will give us our ndoes with their costs and a path using the nearest to start node that will take us from the starting node
                    //to the target node **
                    if (childNode.visited)
                    {
                        continue;
                    }
                      
                    if (childNode.minCostToStart == int.MaxValue ||
                        node.minCostToStart + cnn.cost < childNode.minCostToStart)
                    {
                        childNode.minCostToStart = node.minCostToStart + cnn.cost;
                        childNode.nearestToStart = node;
                        if (!prioQueue.Contains(childNode))
                        {
                            prioQueue.Add(childNode);
                        }
                    }
                }

                node.visited = true; //set the node to visited and if we reach
                //the target node (HTH) then we are done processing 

                if (node == game[5]) //change this to the green node**
                {
                    return;
                }
            } while (prioQueue.Any()); //what does this do**
        }
    }

    public class Node : IComparable<Node>

    //have a node and edges class and the edges are the cost of the edge and whatever node is at the end of that edge and we need to store
    //the minimum cost back to the start from the node class and we need to store the minimum cost of the node to another node 
    //and we have a constructor where we pass in the state and we want to initialize our minimum cost and we have our 
    //constrcuctor and we can add new edges on our node 

        //we have data in our node (nstate)
        //we have the list of edges for each node and each node is connected to another node and each node has a cost edge and the node
        //on the other side of the edge (edge class fields)** what is the minimum cost back to starting node and which node is nearestostart and
        //if we have viststed that node** initialize minimum cost to infinity for the constructor and if we need to go higher than 2 billion we can 
        //use int-64 than int-32 and we have a method to add an edge and pass the cost and the node thats connected to the other side of the edge**
        //comparetomethod for sorting**
    {
        public int nState; //state is the color which is the enumerated type of colors for our graph instead of an int.**
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
            //pass values from node class into construcotr here**
            this.cost = cost;
            this.connectedNode = connectedNode;
        }

        public int CompareTo(Edge e) //compre the edges to sort the connected ndoes 
            //by their lowest cost**
        {
            return this.cost.CompareTo(e.cost);
        }
    }
}
