using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Digraph
{
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
    internal class Program
    {
        

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
            
          //          // Red     Darkblue   Gray    Lightblue    Orange    Yellow    Purple    Green
          // /* Red */ { -1  , 1   , 5   , -1   , -1   , -1   , -1   , -1 },
          // /* Darkblue */ { -1, -1, -1   , 1    , -1   , 8   , -1   , -1 },
          // /* Gray */ {-1   , -1   , -1   , 0  , 1   , -1   , -1   , -1 },
          // /* Lightblue*/ { -1 , 1   , 0   , -1   , -1   , -1   , -1   , -1 },
          // /* Orange*/ { -1   , -1   , -1   , -1   , -1   , -1   , 1    , -1 },
          // /* Yellow */ { -1   , -1   , -1   , -1   , -1   , -1   , -1   , 6 }, //put in left to right order (is this ok)**
          // /* Purple */ { -1   , -1   , -1   , -1   , -1   , 1  , -1   , -1 },
          // /* Green*/ { -1   , -1   , -1   , -1   , -1   , -1    , -1   , -1 }

                     //Red  Darkblue Gray Yellow Green Lightblue Orange Purple
           /* Red */ { -1  , 1   , 5   , -1   , -1   , -1   , -1   , -1 },
           /* Darkblue */ { -1, -1, -1   , 8    , -1   , 1   , -1   , -1 },
           /* Gray */ {-1   , -1   , -1   , -1  , 1   , 0   , 1   , -1 },
           /* Yellow */ { -1   , -1   , -1   , -1   , 6   , -1   , -1   , -1 },
           /* Green*/ { -1   , -1   , -1   , -1   , -1   , -1    , -1   , -1 },
           /* Lightblue*/ { -1 , 1   , 0   , -1   , -1   , -1   , -1   , -1 },
           /* Orange*/ { -1   , -1   , -1   , -1   , -1   , -1   , -1    , 1 },
           /* Purple */ { -1   , -1   , -1   , 1   , -1   , -1  , -1   , -1 }

        };

        static int[][] connectColor = new int[][] {
            new int[] { (int)EColor.Darkblue,(int)EColor.Gray },
            new int[] { (int)EColor.Yellow, (int)EColor.Lightblue },
            new int[] { (int)EColor.Lightblue,(int)EColor.Orange },
            new int[] { (int)EColor.Green },
            null,
            new int[] { (int)EColor.Darkblue,(int)EColor.Gray },
            new int[] { (int)EColor.Purple },
            new int[] { (int)EColor.Yellow },
            
            //would we have weight here for the colors instead of the colors themselves
            //an array for connections and an array for the weights and just replace connections with weights with each spot in the array
            //(2 arrays)


        };

        static int[][] numColor = new int[][] {
            //2D array for the weights associated with each vertex
            new int[] { 1,5 },
            new int[] { 8, 1 },
            new int[] { 0, 1 },
            new int[] { 6 },
            null,
            new int[] { 1, 0 },
            new int[] { 1 },
            new int[] { 1 },
 


        };

        //public static void DepthFirstPreOrderTraversal(Node node)
        //{ 
        //    if (node != null)
        //    {
        //        DepthFirstPreOrderTraversal(node.leftVertex);
        //        DepthFirstPreOrderTraversal(node.rightVertex);
        //    }
        //}


        //public class Node
        //{
        //    public EColor color;
        //    public Node leftVertex;
        //    public Node rightVertex;
        //    public bool vistedLeftVertex;
        //    public bool visitedRightVertex;
        //
        //    public Node(EColor color)
        //    {
        //        this.color = color;
        //    }
        //}

        static List<Node> game = new List<Node>();

        static void Main(string[] args)
        {
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

            //Red  Darkblue Gray Yellow Green Lightblue Orange Purple
            game.Add(new Node((int)EColor.Red));
            game.Add(new Node((int)EColor.Darkblue));
            game.Add(new Node((int)EColor.Gray));
            game.Add(new Node((int)EColor.Yellow));
            game.Add(new Node((int)EColor.Green));
            game.Add(new Node((int)EColor.Lightblue));
            game.Add(new Node((int)EColor.Orange));
            game.Add(new Node((int)EColor.Purple));

            //Red
            game[(int)EColor.Red].AddEdge(1, game[(int)EColor.Darkblue]);
            game[(int)EColor.Red].AddEdge(5, game[(int)EColor.Gray]);
            game[(int)EColor.Red].edges.Sort();
            //game[(int)EColor.Red].edges.Sort((e1, e2) => e1.cost.CompareTo(e2.cost));


            //Darkblue
            game[(int)EColor.Darkblue].AddEdge(8, game[(int)EColor.Yellow]);
            game[(int)EColor.Darkblue].AddEdge(1, game[(int)EColor.Lightblue]);
            game[(int)EColor.Darkblue].edges.Sort();
            //game[(int)EColor.Darkblue].edges.Sort((e1, e2) => e1.cost.CompareTo(e2.cost));


            //Gray
            game[(int)EColor.Gray].AddEdge(0, game[(int)EColor.Lightblue]);
            game[(int)EColor.Gray].AddEdge(1, game[(int)EColor.Orange]);
            game[(int)EColor.Gray].edges.Sort();
            //game[(int)EColor.Gray].edges.Sort((e1, e2) => e1.cost.CompareTo(e2.cost));


            //Yellow
            game[(int)EColor.Yellow].AddEdge(6, game[(int)EColor.Green]);
            game[(int)EColor.Yellow].edges.Sort();
            //game[(int)EColor.Yellow].edges.Sort((e1, e2) => e1.cost.CompareTo(e2.cost));

            //Green
            //game[(int)EColor.Green].edges.Sort();
            game[(int)EColor.Green].edges.Sort((e1, e2) => e1.cost.CompareTo(e2.cost));


            //Lightblue 
            game[(int)EColor.Lightblue].AddEdge(1, game[(int)EColor.Darkblue]);
            game[(int)EColor.Lightblue].AddEdge(0, game[(int)EColor.Gray]);
            game[(int)EColor.Lightblue].edges.Sort();
            //game[(int)EColor.Lightblue].edges.Sort((e1, e2) => e1.cost.CompareTo(e2.cost));


            //Orange
            game[(int)EColor.Orange].AddEdge(1, game[(int)EColor.Purple]);
            game[(int)EColor.Orange].edges.Sort();
            //game[(int)EColor.Orange].edges.Sort((e1, e2) => e1.cost.CompareTo(e2.cost));


            //Purple
            game[(int)EColor.Purple].AddEdge(1, game[(int)EColor.Yellow]);
            game[(int)EColor.Purple].edges.Sort();
            //game[(int)EColor.Purple].edges.Sort((e1, e2) => e1.cost.CompareTo(e2.cost));


            List<Node> shortestPath = GetShortestPathDijkstra();

            // Sort the shortestPath list based on the nState variable
            //shortestPath = shortestPath.OrderBy(node => node.nState).ToList();


            //red, darkblue, lightblue, gray, orange, purple, yellow, green
            foreach (Node spNode in shortestPath)
            {
                Console.WriteLine((EColor)spNode.nState);

            }



        }

        static public List<Node> GetShortestPathDijkstra()
        { 
            DijkstraSearch();
            List<Node> shortestPath = new List<Node>();
            shortestPath.Add(game[(int)EColor.Green]);
            BuildShortestPath(shortestPath, game[(int)EColor.Green]);
            shortestPath.Reverse();
            return (shortestPath);
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
            Node start = game[(int)EColor.Red]; 


            start.minCostToStart = 0;

            List<Node> prioQueue = new List<Node>();
        

            prioQueue.Add(start);

            //bool hitEnd = false;
          

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
                    //hitEnd = true;
                    return;
                }
                //||hitEnd == false;
            } while (prioQueue.Any()); 
        }
    }

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
