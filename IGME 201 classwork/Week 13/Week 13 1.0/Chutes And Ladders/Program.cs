using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chutes_And_Ladders
{
    public class Cell
    {
        // each Cell for each space on the gameboard
        // can have a link to another node in the LinkedList 
        // (the result of there being a chute or ladder on this space)**

        //each space is a cell on our gameboared**
        //we have a reference variable pointing to a shortcut cell**
        //our chutes and ladders have a shortcut to go from cell to cell
        public LinkedListNode<Cell> shortcut;

        // booleans for whether this cell has a powerup or penalty on it

        
        public bool hasPowerUp;
        public bool hasPenalty;

        // internal reference id or index

        //when we layout the gameboard we want to keep track of the number cell they are on based on the board because the board is a multiple of 7
        //across and we need to know if they are moving up if there is a staircase**
        public int nNumber;
    }

    public class Player
    {
        // each player has the LinkedList Node of the current gameboard cell they are occupying**
        public LinkedListNode<Cell> currentCell;

        // and a score
        public int score;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();

            bool bGameOver = false;

            //start of level 1 and have our vaariables for chutes,ladders,oenalites, and powerups**
            int level = 1;
            int nLadders;
            int nChutes;
            int nPenalties;
            int nPowerUps;

            Player player1 = new Player();
            Player player2 = new Player();

            while (!bGameOver)
            {
                // create our game board
                //we have a c# datatype called linked list and it's a generic data type because in the <> we can put a datatype
                //which we put the Cell class which then points to the shortcut nodes and the rest of the information from the class****
                LinkedList<Cell> board = new LinkedList<Cell>();

                // Lists to hold the list of id's of the cells to contain game artifacts**
                //lists to hold the ids of our artifcats on the gameboards and they are a list of integers because we are going off the ID for each cell**
                List<int> lLadders = new List<int>();
                List<int> lChutes = new List<int>();
                List<int> lPowerUps = new List<int>();
                List<int> lPenalties = new List<int>();

                // dictionaries to link cell id's to nodes of our linked list
                // so that we can access the cells connected by chutes and ladders to set their shortcut field**
                //basically it gives each cell a powerup or not??** how does it know which one to give powerup to**

                //each data element in our linked list is a node 
                Dictionary<int, LinkedListNode<Cell>> dLadders = new Dictionary<int, LinkedListNode<Cell>>();
                Dictionary<int, LinkedListNode<Cell>> dChutes = new Dictionary<int, LinkedListNode<Cell>>();

                Cell cell = null;

                // number of game artifacts based on the current level**
                //each thing is the level plus 1 but the chutes will only be 1 for level 1 and increases by the level increase**
                nPenalties = level + 1;
                nPowerUps = level + 1;
                nLadders = level + 1;
                nChutes = level;

                // analysing the board layout to deduce a formula to calculate the "upstairs" cell
                // of 2 cells connected by a ladder or chute (0 is the starting cell, 22 is the finish):
                //   15 16 17 18 19 20 21 22
                //   14 13 12 11 10  9  8
                // 0  1  2  3  4  5  6  7
                //  
                // upstairs cell id = 2 * ((n + 7) / 7) * 7 - (n - 1)
                //calculates the relstionships between cells to put a ladder or chute at a cell**

                // populate our Ladders list of cell id's
                // no ladder on the cells with stairs (multiples of 7)
                while (nLadders > 0)
                {
                    int thisEl = rand.Next(1, (level + 1) * 7); //number of cells on the gameabord at the sepecific level**
                    if (thisEl % 7 == 0 || lLadders.Contains(thisEl))
                    {
                        continue;
                    }

                    lLadders.Add(thisEl);
                    --nLadders;
                }

                // add the "upstairs" cell for each cell id in our list
                int nLength = lLadders.Count;
                for( int i = 0; i < nLength; ++i)
                {
                    lLadders.Add(2 * ((lLadders[i] + 7) / 7) * 7 - (lLadders[i] - 1));
                    //use formula to add uppstairs ID to list of ladders**
                }

                // populate our Chutes list of cell id's
                // no chute on the cells with ladders or stairs (multiples of 7)
                while (nChutes > 0)
                {
                    int thisEl = rand.Next(1, (level + 1) * 7); //pick random number and don't pick the same cell as another chute or same cell as a 
                    //ladder then we add to list of chites**
                    if (thisEl % 7 == 0 || lLadders.Contains(thisEl) || lChutes.Contains(thisEl))
                    {
                        continue;
                    }

                    lChutes.Add(thisEl);
                    --nChutes;
                }

                // add the "upstairs" cell for each cell id in our list
                //add related cell to chute suing the formuka**
                nLength = lChutes.Count;
                for (int i = 0; i < nLength; ++i)
                {
                    lChutes.Add(2 * ((lChutes[i] + 7) / 7) * 7 - (lChutes[i] - 1));
                }

                // populate our Powerups list of cell id's
                // powerups can be on any cell
                while (nPowerUps > 0)
                {
                    int thisEl = rand.Next(1, (level + 2) * 7 + 1);
                    if (thisEl % 7 == 0 || lPowerUps.Contains(thisEl))
                    {
                        continue;
                    }

                    lPowerUps.Add(thisEl);
                    --nPowerUps;
                }

                // populate our Penalties list of cell id's
                // penalties can be on any cell without powerups
                while (nPenalties > 0)
                {
                    int thisEl = rand.Next(1, (level + 2) * 7 + 1);
                    if (thisEl % 7 == 0 || lPenalties.Contains(thisEl) || lPowerUps.Contains(thisEl))
                    {
                        continue;
                    }

                    lPenalties.Add(thisEl);
                    --nPenalties;
                }


                // insert starting cell

                //create a new cell and set the index of the cell to 0 then 
                //add the cell to our linked list which is our board and addLast adds new nodes to the end of the linked list**
                cell = new Cell();
                cell.nNumber = 0;
                board.AddLast(cell);

                int cntr = 0;

                // number of gamespaces is a multiple of 7 based on the level
                for (cntr = 1; cntr < (level + 2) * 7 + 1; ++cntr)
                    //number of gamespaces is multiple of 7 based on the level and the cntr adds each cell on
                    //our gameboard 
                {
                    // create a new cell for each game space
                    cell = new Cell();
                    cell.nNumber = cntr; //set its cell number (the ID) the the current cntr**

                    // if this cell index is in the list of powerups
                    if( lPowerUps.Contains(cntr)) //if the cell has a powerup or penality we set the boolean to true**
                    {
                        // set the flag
                        cell.hasPowerUp = true;
                    }

                    // if this cell index is in the list of penalties
                    if ( lPenalties.Contains(cntr))
                    {
                        // set the flag
                        cell.hasPenalty = true;
                    }

                    // add the cell to the board
                    board.AddLast(cell); //add the cell to the board**

                    // if this cell has a reference to a ladder (either the bottom or top)

                    //we use the dictionary to link the the top or bottom cell to it's related cell 
                    //and we check to see if the current cell we are on contains a ladder then we want to have
                    //our ladder of this index equal to the node we just added**
                    if( lLadders.Contains(cntr) )
                    {
                        // add this Node (the Last one we added) to the dictionary using this cell id
                        // we need to reference it later to set the Cell.shortcut
                        dLadders[cntr] = board.Last;
                    }

                    // if this cell has a reference to a chute (either the bottom or top)

                    //same thing for chutes as ladder and gives us relationship between node and index that contains the chute or ladder**
                    if (lChutes.Contains(cntr))
                    {
                        // add this Node (the Last one we added) to the dictionary using this cell id
                        // we need to reference it later to set the Cell.shortcut
                        dChutes[cntr] = board.Last;
                    }
                }

                //after the above loop we have created our gameboard**

                // look at each cell id in our list of ladders
                //set the shortcut of the cells that have a chute or a ladder
                //go through list of ladders and we need to calculate upstairs cell of that ladder then take dictionary of the upstairs element
                //then save the node we saved in dicitonary to the shortcut in the bottom cell of the ladder (lets us gp up the ladder)**
                foreach( int nBottomEl in lLadders )
                {
                    // calculate the "upstairs" cell at the top of the ladder
                    int nTopEl = 2 * ((nBottomEl + 7) / 7) * 7 - (nBottomEl - 1);

                    // if this upstairs cell id is also in our list
                    if ( dLadders.Keys.Contains(nTopEl))
                    {
                        // set the shortcut of the bottom cell to link to the upstairs Node
                        // Value is the Cell contained in this LinkedListNode
                        Cell bottomCell = dLadders[nBottomEl].Value;
                        bottomCell.shortcut = dLadders[nTopEl];
                        // this could also have been written as:
                        //     dLadders[nBottomEl].Value.shortcut = dLadders[nTopEl];
                    }
                }

                //lets us go down the cute**
                // look at each cell id in our list of chutes
                foreach (int nBottomEl in lChutes)
                {
                    // calculate the "upstairs" cell at the top of the chute
                    int nTopEl = 2 * ((nBottomEl + 7) / 7) * 7 - (nBottomEl - 1);

                    // if this upstairs cell id is also in our list
                    if (dChutes.Keys.Contains(nTopEl))
                    {
                        // set the shortcut of the top cell to link to the bottom Node
                        // Value is the Cell contained in this LinkedListNode
                        Cell topCell = dChutes[nTopEl].Value;
                        topCell.shortcut = dChutes[nBottomEl];
                    }
                }

                // add the finish cell
                cell = new Cell();
                cell.nNumber = cntr;
                board.AddLast(cell);

                // set both players to start at the start of the board
                player1.currentCell = board.First; //node in the first part of linked list and Last is the last aprt of the linked list and to access any node
                //in between we need to go through the whole linked list like we do in the game and walk to the item in the list to get the powerup**
                //always have a reference to first and last thing in the linked list but nothing in the middle and we can only walk forward
                //or backwards in the linked list**
                player2.currentCell = board.First;

                // thisPlayer is the current player
                Player thisPlayer = player1;

                // while neither player won yet

                //game keeps going while neither player has not reached the end of our gamebaored**
                //when either player reaches the last node in our linked list we stop the loop**
                while (player1.currentCell != board.Last &&
                       player2.currentCell != board.Last)
                {
                    // print the board
                    Console.WriteLine();
                    PrintBoard(board, player1, player2);

                    // ask the current player for their desired direction (default to +)
                    if( thisPlayer == player1)
                    {
                        Console.Write("Player 1: Which direction to move (-/+): "); //ask player if they want to move forwards or backwards for powerup or ladder**
                    }
                    else
                    {
                        Console.Write("Player 2: Which direction to move (-/+): ");
                    }

                    string sDirection = Console.ReadLine();

                    // default to "+"
                    if( sDirection.Length == 0 )
                    {
                        sDirection = "+";
                    }

                    // roll the die
                    int nRoll = rand.Next(1, 7);
                    Console.WriteLine("You rolled a " + nRoll);

                move:
                    // while we have spaces to move and our player is on a valid Node of the LinkedList
                    while( nRoll > 0 && thisPlayer.currentCell != null) //have the player next by setting their current cell to the current cell.next 
                        //and there is a property in nodes called .next which points to next node in the linked list and if they pick + to move forward
                        //we want them to move forward but we check to make sure it's not null (they are at the end of the level)**
                    {
                        // moving forward
                        if( sDirection == "+" )
                        {
                            // if there is a Next cell
                            if( thisPlayer.currentCell.Next != null )
                            {
                                // move the player to the next Node in the LinkedList
                                thisPlayer.currentCell = thisPlayer.currentCell.Next;
                            }
                            else
                            {
                                // otherwise we are at an end of the board
                                break;
                            }
                        }
                        else
                        //this lets us walk backwards in our gameboard and the null is it they move before the start of the gamebaord**
                        {
                            // else moving backwards
                            // if there is a Previous Node
                            if(thisPlayer.currentCell.Previous != null)
                            {
                                // move the player to the Previous Node
                                thisPlayer.currentCell = thisPlayer.currentCell.Previous;
                            }
                            else
                            {
                                // otherwise we are at an end of the board
                                break;
                            }
                        }

                        // decrease the number of spaces left to move
                        --nRoll;
                    }

                    // the current player is now on the final destination
                    if(thisPlayer.currentCell.Value.hasPenalty )
                        //if the current cell that the player is on has a penalty 
                        //each node in our linked list is a cell class object 
                        //and we have a property called value and the linked list node and the data in our node
                        //will be pointed to by the value property**
                        //value is pointing to our cell object thats stored in our linked list node then we can access the members of our cell class and
                        //we can check if the cell has a epnalty and if it does we clear the cell and print the board to not have to penalty anymore**
                    {
                        // if the current cell has a penalty
                        // clear the penalty flag
                        thisPlayer.currentCell.Value.hasPenalty = false;

                        // print the new state of the board
                        PrintBoard(board, player1, player2);

                        // set die and direction to move the player back 2 spaces
                        //roll 2 and make the player go backwards**
                        nRoll = 2;
                        sDirection = "-";

                        // go back to move to move the player again
                        //moves our player 2 spaces backwards**
                        goto move;
                    }

                    if (thisPlayer.currentCell.Value.hasPowerUp)
                        //if they have powerup we show new state of baord to hsow powerup has been moved and move 2 spaces forward 
                        //and increment their score 
                    {
                        // if the current cell has a powerup
                        // clear the penalty flag
                        thisPlayer.currentCell.Value.hasPowerUp = false;

                        // print the new state of the board
                        PrintBoard(board, player1, player2);

                        // set die and direction to move the player forward 2 spaces and increment the player's score
                        nRoll = 2;
                        sDirection = "+";
                        ++thisPlayer.score;

                        // go back to move to move the player again
                        goto move;
                    }

                    // if there is a shortcut for the cell attached to the current Node of the player's position
                    if(thisPlayer.currentCell.Value.shortcut != null)
                        //if they land on a node where the cell in that node has a shortcut to another node then we set their current cell
                        //to the shortcut which moves the player to that new cell and we dont want to move anymore and we want them to stay there
                        //and we go back to move because our players position has changed and it's possible there was a new penalty or powerup on their new cell**
                    {
                        // print the board
                        PrintBoard(board, player1, player2);

                        // set the player's current cell to the shortcut Node value
                        thisPlayer.currentCell = thisPlayer.currentCell.Value.shortcut;

                        // no more spaces to move, but since the position has changed loop back to check for powerups and penalties
                        nRoll = 0;
                        goto move;
                    }

                    // switch player
                    //switch each player per turn**
                    if ( thisPlayer == player1)
                    {
                        thisPlayer = player2;
                    }
                    else
                    {
                        thisPlayer = player1;
                    }
                }

                // if we get here, there is a winner!

                //print out which player won and this game keeps leveling up 
                //and there is no ending point**
                //each space on our gamebaord has brackets around the ID and 1 has a penalty
                //which id the ! and the powerup is the $ and there is a ladder with the =>**
                //and there is a chute that goes from 9 to 10 => (both use the =>)**
                if( player1.currentCell == board.Last)
                {
                    Console.WriteLine("Player 1 you Won!!!");
                }
                else
                {
                    Console.WriteLine("Player 2 you Won!!!");
                }

                // Level Up!
                ++level;
                Console.WriteLine("Moving up to Level " + level);
            }
        }

        //go over**
        public static void PrintBoard(LinkedList<Cell> board, Player player1, Player player2 )
        {
            LinkedListNode<Cell> linkedListNode = board.First;

            while( linkedListNode != null )
            {
                Cell thisCell = linkedListNode.Value;
                Cell thisShortcut = null;
                if (thisCell.shortcut != null)
                {
                    thisShortcut = thisCell.shortcut.Value;
                }
                
                Console.Write($"[{thisCell.nNumber}" +
                    $"{(player1.currentCell == linkedListNode ? "^P1^":"")}" +
                    $"{(player2.currentCell == linkedListNode ? "^P2^" : "")}" +
                    $"{(thisCell.hasPowerUp ? "$":"")}" +
                    $"{(thisCell.hasPenalty ? "!" : "")}" + 
                    $"{(thisShortcut != null ? "=>" + thisShortcut.nNumber : "")}]");

                linkedListNode = linkedListNode.Next;
            }

            Console.WriteLine();
        }
    }
}


/*
 * Exam 3:
 * Could set the minimum and maximum of the form so it's fixed and they won't be able to resize the screen**
 * 
 *If we click on stack it gives us stack implementation on how to pop and push things on the stack and same for queues
 *and a stack is a last in first out array and we can only access the last item in the array and the queue is a first in first out array
 *and we can only access the older items in the array**
 *the undo in a word processor is a stack because it's our most recent data we are removing and waiting in a queue or a line 
 *is a queue and the first person in the line will get met first then it goes from there**
 *We have used sorted lists, lists, and simple arrays and they all have their pros and cons**
 *Linked Lists and Chutes and Ladders:
 *number of chutes and ladders is based on your level and adds another layer based on the level we are on and the red jacks
 *send us back 2 spaces (penealities) and th gold nuggets are powerups and add points to our player and they send us forward 2 spaces 
 *and when we roll the dice is moves our player and they picked up the powerup which sent them forward 2 and picked up penalty so they went back 2
 *our spots are a linked list of nodes (our green spots on the game board)
 *
 *if we always know the order of items in the linked list then we can check to see if we are looking for things in the beginning or the end of the linked list
 *and we can make it more efficient from rather going from the start of the linked list or the end of the linked list**
 *we can also break up the linked lists and we might want to have multiple linked lists to make getting data more efficient
 *linked lists are more efficient for adding and removing rather than arrays 
 *
 *Binary trees:
 * we want our game to guess between 1-100 and we want to guess what the value is 
 * best approach is to pick number in the middle and just by guessing number in the middle we have cut the possibilities in half so we know its 1-50
 *so now we guess 25 and we know 25 and 50 and we guess 47 and we got it in 5 guesses and its efficient and we have cut the possible number of values in half
 *and binary trees are useful for searching for data and binary trees is the most efficient for searching for data because each time it searches it cuts down
 *the possible data it needs to look for in half
 *if this was an array instead it could take 47 guesses if they were stores in an array from 1-100 because we would have to look through each
 *array element to figure it out and we are not able to split out or discard the items and an array we look through one item at a time**
 *binary trees uses log2(100) (the 100 is the size of our data from our guessing game) and it splits the binary tree in half as we move on in our guesses**
 *
 *
 *
 */