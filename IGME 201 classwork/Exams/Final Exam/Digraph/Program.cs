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

        static int[][] numColor = new int[][] {
            new int[] { (int)EColor.Darkblue,(int)EColor.Gray },
            new int[] { (int)EColor.Yellow, (int)EColor.Lightblue },
            new int[] { (int)EColor.Lightblue,(int)EColor.Orange },
            new int[] { (int)EColor.Green },
            null,
            new int[] { (int)EColor.Darkblue,(int)EColor.Gray },
            new int[] { (int)EColor.Purple },
            new int[] { (int)EColor.Yellow }, 


        };
        public static void DepthFirstPreOrderTraversal(Node node)
        { 
            if (node != null)
            {
                DepthFirstPreOrderTraversal(node.leftVertex);
                DepthFirstPreOrderTraversal(node.rightVertex);
            }
        }


        public class Node
        {
            public EColor color;
            public Node leftVertex;
            public Node rightVertex;
            public bool vistedLeftVertex;
            public bool visitedRightVertex;

            public Node(EColor color)
            {
                this.color = color;
            }
        }


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

            List<Node> allColors = new List<Node>();

            //Red  Darkblue Gray Yellow Green Lightblue Orange Purple
            allColors.Add(new Node(EColor.Red));
            allColors.Add(new Node(EColor.Darkblue));
            allColors.Add(new Node(EColor.Gray));
            allColors.Add(new Node(EColor.Yellow));
            allColors.Add(new Node(EColor.Green));
            allColors.Add(new Node(EColor.Lightblue));
            allColors.Add(new Node(EColor.Orange));
            allColors.Add(new Node(EColor.Purple));

            //red
            allColors[0].leftVertex = allColors[1];
            allColors[0].rightVertex = allColors[2];



        }
    }
}
