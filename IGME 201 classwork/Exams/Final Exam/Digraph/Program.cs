using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;



namespace Digraph
{
    //Enumerated type to hold the colors
    enum EColor
    {
       Red,
       Darkblue,
       Gray,
       Lightblue,
       Orange,
       Yellow,
       Purple,
       Green
    }

    // Class: Program
    // Author: Kashaf Ahmed
    // Purpose: Creates the adjacency matrix, and lists for the nodes and their edges connections then implement Dijkstra's shortest
    // path algorithm and do a depth first search. I had two adjacency lists, one for the specific connections for each node and the weights associated
    // with the nodes. I also create the game list which will hold the nodes.
    // Restrictions: None
    internal class Program
    {
        
        //extra adjacency matrix 
        //static bool[,] colorsGraph = new bool[,]
        //{
        //            // Red     Darkblue   Gray    Lightblue    Orange    Yellow    Purple    Green
        //   /* Red */ { false  , true    , true   , false   , false   , false   , false   , false },
        //   /* Darkblue */ { false, false, false   , true    , false   , true   , false   , false },
        //   /* Gray */ {false   , false   , false   , true  , true   , false   , false   , false },
        //   /* Lightblue*/ { false , true   , true   , false   , false   , false   , false   , false },
        //   /* Orange*/ { false   , false   , false   , false   , false   , false   , true    , false },
        //   /* Yellow */ { false   , false   , false   , false   , false   , false   , false   , true },
        //   /* Purple */ { false   , false   , false   , false   , false   , true  , false   , false },
        //   /* Green*/ { false   , false   , false   , false   , false   , false    , false   , false }
        //};

        static int[,] weightedGraph = new int[,] { 
            


                     //Red  Darkblue Gray Lighblue Orange Yellow Purple Green
           /* Red */ { -1  , 1   , 5   , -1   , -1   , -1   , -1   , -1 },
           /* Darkblue */ { -1, -1, -1   , 1    , -1   , 8   , -1   , -1 },
           /* Gray */ {-1   , -1   , -1   , 0  , 1   , -1   , -1   , -1 },
           /* Lightblue*/ { -1 , 1   , 0   , -1   , -1   , -1   , -1   , -1 },
           /* Orange */ { -1   , -1   , -1   , -1   , -1   , -1   , 1   , -1 },
           /* Yellow*/ { -1   , -1   , -1   , -1   , -1   , -1    , -1   , 6 },
           /*Purple*/ { -1   , -1   , -1   , -1   , -1   , 1   , -1    , -1 },
           /* Green */ { -1   , -1   , -1   , 1   , -1   , -1  , -1   , -1 }

        };

        static int[][] connectColor = new int[][] { 
            //The adjacency lists in in accordance to the order I add 
            //the nodes in my game list
            new int[] { (int)EColor.Darkblue,(int)EColor.Gray },
            new int[] { (int)EColor.Yellow, (int)EColor.Lightblue },
            new int[] { (int)EColor.Lightblue,(int)EColor.Orange },
            new int[] { (int)EColor.Darkblue, (int)EColor.Gray },
            new int[] { (int)EColor.Purple },
            new int[] { (int)EColor.Green },
            new int[] { (int)EColor.Yellow },
            null


        };

        static int[][] numColor = new int[][] {
            //2D array for the weights associated with each vertex
            new int[] { 1,5 },
            new int[] { 8, 1 },
            new int[] { 1, 0 },
            new int[] { 0, 1 },
            new int[] { 1 },
            new int[] { 6 },
            new int[] { 1 },
            null



        };

        static List<Node> game = new List<Node>();

        // Method: Main
        // Author: Kashaf Ahmed
        // Purpose: First, add the nodes to the game list, then for each node add the edges associated with that node and their weights, then sort
        // the edges for each node. After, we create a shortest path list which calls the GetShortestPathDijkstra() method, then go through each node 
        // in the shortest path list we got back from the method to show the shortest path. After, we set each node to not be visited so we can do 
        // our depth first search as well as call the depth first search method with the red node.
        // Restrictions: None
        static void Main(string[] args)
        {
            //Checks if connections are correct
            //check for jagged array to go through enumerated type
            //for(int i = 0; i < numColor.Length; i++)
            //{
            //   
            //    Console.WriteLine("\n" + i + ": ");
            //    for(int j = 0; j < numColor[i].Length; j++)
            //    {
            //        Console.Write(numColor[i][j] +",");
            //    }
            //}

            //check for 2D array
            //for(int i = 0; i < colorsGraph.GetLength(0); i++)
            //{
            //   
            //    Console.WriteLine("\n" + i + ": ");
            //    for(int j = 0; j < colorsGraph.GetLength(1); j++)
            //    {
            //        Console.Write(colorsGraph[i,j] +",");
            //    }
            //}

            game.Add(new Node((int)EColor.Red));
            game.Add(new Node((int)EColor.Darkblue));
            game.Add(new Node((int)EColor.Gray));
            game.Add(new Node((int)EColor.Lightblue));
            game.Add(new Node((int)EColor.Orange));
            game.Add(new Node((int)EColor.Yellow));
            game.Add(new Node((int)EColor.Purple));
            game.Add(new Node((int)EColor.Green));

            //Red
            game[(int)EColor.Red].AddEdge(1, game[(int)EColor.Darkblue]);
            game[(int)EColor.Red].AddEdge(5, game[(int)EColor.Gray]);
            game[(int)EColor.Red].edges.Sort();


            //Darkblue
            game[(int)EColor.Darkblue].AddEdge(8, game[(int)EColor.Yellow]);
            game[(int)EColor.Darkblue].AddEdge(1, game[(int)EColor.Lightblue]);
            game[(int)EColor.Darkblue].edges.Sort();


            //Gray
            game[(int)EColor.Gray].AddEdge(0, game[(int)EColor.Lightblue]);
            game[(int)EColor.Gray].AddEdge(1, game[(int)EColor.Orange]);
            game[(int)EColor.Gray].edges.Sort();


            //Yellow
            game[(int)EColor.Yellow].AddEdge(6, game[(int)EColor.Green]);
            game[(int)EColor.Yellow].edges.Sort();

            //Green
            game[(int)EColor.Green].edges.Sort();


            //Lightblue 
            game[(int)EColor.Lightblue].AddEdge(1, game[(int)EColor.Darkblue]);
            game[(int)EColor.Lightblue].AddEdge(0, game[(int)EColor.Gray]);
            game[(int)EColor.Lightblue].edges.Sort();


            //Orange
            game[(int)EColor.Orange].AddEdge(1, game[(int)EColor.Purple]);
            game[(int)EColor.Orange].edges.Sort();


            //Purple
            game[(int)EColor.Purple].AddEdge(1, game[(int)EColor.Yellow]);
            game[(int)EColor.Purple].edges.Sort();


            List<Node> shortestPath = GetShortestPathDijkstra();


            //red, darkblue, lightblue, gray, orange, purple, yellow, green
            Console.WriteLine("Dijkstra's Shortest Path: ");
            foreach (Node spNode in shortestPath)
            {
                Console.WriteLine((EColor)spNode.nState);

            }
            Console.WriteLine();
            Console.WriteLine("Depth First Search: ");

            foreach (Node node in game)
            {
                node.visited = false;
            }

            DepthFirstPreOrderTraversal(game[0]);

           

        }

        // Method: DepthFirstPreOrderTraversal
        // Author: Kashaf Ahmed
        // Purpose: If the node is node null, write our nodes into the console as we go through the digraph and set the nodes to be visited
        // then grab all of its conection points and if there is connection points starting from its left most node check if it has not
        // been visited and its not null. If so, call the method recursively until a null node is found on that side, and repeat until every node is visited.
        // Restrictions: None
        public static void DepthFirstPreOrderTraversal(Node node) 
        {

            if (node != null)
            {

                Console.WriteLine((EColor)node.nState);
                node.visited = true;

                int[] connections = connectColor[game.IndexOf(node)];

                if (connections != null)
                {
                    for (int i = 0; i < connections.Length; i++)
                    {
                        if (game[connections[i]] != null && game[connections[i]].visited != true)
                        {
                            DepthFirstPreOrderTraversal(game[connections[i]]);
                        }
                    }

                }

            }
        }


        // Method: GetShortestPathDijkstra
        // Author: Kashaf Ahmed
        // Purpose: This is called when we create the shortest path list and it goes through and calls the build shortest path method
        // then after the shortest path is built, we reverse the list then return it
        // Restrictions: None
        static public List<Node> GetShortestPathDijkstra()
        { 
            DijkstraSearch();
            List<Node> shortestPath = new List<Node>();
            shortestPath.Add(game[(int)EColor.Green]);
            BuildShortestPath(shortestPath, game[(int)EColor.Green]);
            shortestPath.Reverse();
            return (shortestPath); 
        }

        // Method: BuildShortestPath
        // Author: Kashaf Ahmed
        // Purpose: Builds the shortest path based on the list that was passed in and the last node which is the green node
        // and if the nearest to start variable is null we don't do anything and exit the method, otherwise, we add the nearest to start node to
        // the list and keep calling the function recursively
        // Restrictions: None
        static private void BuildShortestPath(List<Node> list, Node node)
        {
          
            if (node.nearestToStart == null)
            {
                return;
            }

            list.Add(node.nearestToStart);
            BuildShortestPath(list, node.nearestToStart);
        }

        // Method: DijkstraSearch
        // Author: Kashaf Ahmed
        // Purpose: Goes through and searches for the cheapest connections associated with a node
        // and once we are at the end of the path (the green node because there are no connections),
        // then we exit the method
        // Restrictions: None
        static private void DijkstraSearch()
    
        {
            Node start = game[(int)EColor.Red]; 


            start.minCostToStart = 0;

            List<Node> prioQueue = new List<Node>();
        

            prioQueue.Add(start);
            do
            {
                prioQueue.Sort();

                Node node = prioQueue.First();
                prioQueue.Remove(node);

                foreach (Edge cnn in node.edges)
                {
                    Node childNode = cnn.connectedNode; 
                    if (childNode.visited)
                    {
                        continue;
                    }

                    if (childNode.minCostToStart == int.MaxValue ||
                        node.minCostToStart + cnn.cost <= childNode.minCostToStart)
                    {
                        childNode.minCostToStart = node.minCostToStart + cnn.cost;
                        childNode.nearestToStart = node;
                        if (!prioQueue.Contains(childNode))
                        {
                            prioQueue.Add(childNode);
                        }
                    }
                }

                node.visited = true; 

                if (node == game[(int)EColor.Green]) 
                {
                    return;
                }
            } while (prioQueue.Any()); 
        }
    }


    // Class: Node
    // Author: Kashaf Ahmed
    // Purpose: Creates the state of the node, the edges list, the costs of each edge, and if they 
    // have been visited or not. Theres also an add edge method and compare to method which we use above with our nodes
    // Restrictions: None
    public class Node : IComparable<Node>
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

    // Class: Edge
    // Author: Kashaf Ahmed
    // Purpose: For each edge there is a cost and the node connected to the edge,
    // and it has a compare to method which compares the costs of the edges
    // Restrictions: None
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
