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

        //if there is a ladder on the cell the shortcut would point to cell upstairs but if its a chute it points to node that is downstairs
        //and it is a reference to a node and allows us to jump from one floor to the next
        public LinkedListNode<Cell> shortcut;

        // booleans for whether this cell has a powerup or penalty on it

        
        public bool hasPowerUp;
        public bool hasPenalty;

        // internal reference id or index

        //when we layout the gameboard we want to keep track of the number cell they are on based on the board because the board is a multiple of 7
        //across and we need to know if they are moving up if there is a staircase for every 7 cells (spaces)**
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

            Player player1 = new Player(); //decalre 2 new players for the game 
            Player player2 = new Player();

            while (!bGameOver)
            {
                // create our game board linked list**
                //we have a c# datatype called linked list and it's a generic data type because in the <> we can put a datatype
                //which we put the Cell class which then points to the shortcut nodes and the rest of the information from the cell class****
                LinkedList<Cell> board = new LinkedList<Cell>();

                // Lists to hold the list of id's of the cells to contain game artifacts**
                //lists to hold the ids of our artifcats on the gameboard and they are a list of integers because we are going off the ID for each cell
                //and each cell could have any of these 4 possibilites so we store the id for the cell that has any one of thsee 4 possibilites**
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
                //we don't make the chutes level + 1 because it would clutter the board too much
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
                //each level has 7 nodes and it lets us calculate from any given node to what id is directly above it 
                //dictionary lets us assoiate the node with the index for each ladder and each chute then we go through and now that we hvae the node that the ladder is on
                //we have to go back to cell to set the shortcut to set the null to the shortcut
                //first time picks ladder and chutes nodes then creates the cells and assigns id's then when it creates the node it adds the node to the ladder and chute dictionaries 
                //and we have to go back and assign shortcuts for the nodes so the game knows where to go when player lands on those nodes

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

                    lLadders.Add(thisEl); //we want to add ladders to the even numbered cells and if the list of ladders already contrains the element 
                    //then move on** otherwise we add the element into our ladder**
                    --nLadders;

                    //why do we subtract nladders here is it because we want to make sure all the ladders are on the board for the level**
                }

                // add the "upstairs" cell for each cell id in our list
                int nLength = lLadders.Count;
                for( int i = 0; i < nLength; ++i)
                {
                    lLadders.Add(2 * ((lLadders[i] + 7) / 7) * 7 - (lLadders[i] - 1));
                    //use formula to add uppstairs ID to list of ladders so we can move up the ladder
                    //so now we have a list of cells for the bottom half of the ladders and we just added the upstairs cell for those ladders??**
                }

                // populate our Chutes list of cell id's
                // no chute on the cells with ladders or stairs (multiples of 7)
                while (nChutes > 0)
                {
                    int thisEl = rand.Next(1, (level + 1) * 7); //pick random number and make it even and don't pick the same cell as another chute or same cell as a 
                    //ladder then we add to list of chites**
                    if (thisEl % 7 == 0 || lLadders.Contains(thisEl) || lChutes.Contains(thisEl))
                    {
                        continue;
                    }

                    lChutes.Add(thisEl);
                    --nChutes; //why do we subtract the chutes here is iit because we want to make sure we account for all the chutes in the level to be on
                    //the board**
                }

                // add the "upstairs" cell for each cell id in our list
                //add related cell to chute suing the formuka**
                nLength = lChutes.Count;
                for (int i = 0; i < nLength; ++i)
                {
                    lChutes.Add(2 * ((lChutes[i] + 7) / 7) * 7 - (lChutes[i] - 1));
                }

                //now in the list we have the downstairs (first loop) cell and upstairs (second loop) cell for the chutes**

                // populate our Powerups list of cell id's
                // powerups can be on any cell

                //before we had to consider if it was already a chute or ladder on the same cell but now the powerup and the penalty can be anywhere but there
                //cant be more than two of them in one cell**
                while (nPowerUps > 0)
                {
                    int thisEl = rand.Next(1, (level + 2) * 7 + 1);
                    if (thisEl % 7 == 0 || lPowerUps.Contains(thisEl))
                    {
                        continue;
                    }

                    lPowerUps.Add(thisEl);
                    --nPowerUps; //we add the element to the gameboard cell if its even and it is not already in the list of powerups 
                    //we store it in the list of ints because the level number is an int.**
                    //we then subtract the powerups for the ints so we can add all of our powerups to the board**
                }

                // populate our Penalties list of cell id's
                // penalties can be on any cell without powerups
                while (nPenalties > 0)
                {
                    int thisEl = rand.Next(1, (level + 2) * 7 + 1);
                    if (thisEl % 7 == 0 || lPenalties.Contains(thisEl) || lPowerUps.Contains(thisEl)) //could we have also done this in the powerups and not have done 
                                                                                                      //here or could we have done it in both just in case**
                                                                                                      //do we need to do it in at least one of them though to make sure 
                                                                                                      //that one cell does not contain a penalty and a powerup since
                                                                                                      //we already have our cells with powerups**
                    {
                        continue;
                    }

                    lPenalties.Add(thisEl);
                    --nPenalties;
                }


                // insert starting cell

                //create a new cell and set the index (id??)** of the cell to 0 then 
                //add the cell to our linked list which is our board and addLast adds new nodes to the end of the linked list**
                cell = new Cell();
                cell.nNumber = 0;
                board.AddLast(cell);

                int cntr = 0;

                // number of gamespaces is a multiple of 7 based on the level
                for (cntr = 1; cntr < (level + 2) * 7 + 1; ++cntr)
                    //number of gamespaces is multiple of 7 based on the level and the cntr adds each cell on
                    //our gameboard**
                {
                    // create a new cell for each game space
                    cell = new Cell();
                    cell.nNumber = cntr; //set its cell number (the ID) the the current cntr because that is where our current cell will be**

                    // if this cell index is in the list of powerups (we randomly generated numbers for each cell above)**
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
                        // add this Node (the Last one we added (board.AddLast(cell))****) to the dictionary using this cell id for the current index we are on**
                        // we need to reference it later to set the Cell.shortcut

                        //how does it know to add the top or bottom cell for the current index for the chutes and ladders**
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

                //so basically in the loops above we set the numbers from the first cell to the last for the row for each powerup, penalty, and the chutes and ladders
                //then we go through here and see (each row is 7 nodes then we go up the ladder for the next 7)********
                //according to the index we are on does it have any of these 4 items then we add it to our linked list (board) which is full of Cell instances
                //then we see if there is a chute or ladder for that current index and if there is we add it to the dictionary based on the int
                //we are on as the key and the most current cell we made as the value (the board.Last targets the last element which is our most current element we 
                //added with board.AddLast)**************

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
                        bottomCell.shortcut = dLadders[nTopEl]; //find node associated with 14 as our top element 
                        //and d ladders of 14 is the node of the top of our node for our ladder
                        //and we set that shortcut equal to the cell of 14 so in our cell we have a link to another
                        //node (the dictionary allows us to associate id's with the node in the our linked list
                        //so our dictionary is a list of pointers to our linked list nodes)

                        //while we have ladders to add to our gameboard we pick random number
                        //thats the cell number we want to put ladder on and if a multiple of 7 we skip over because
                        //we dont want multiple ladders at the last node because there will be a ladder there already
                        //and for the chutes we make sure its not a ladder or a chute already 
                        //at that postion and when we add the cells in our for loop we have board linked list and
                        //we create a cell and a counter and we check if the cell has a powerup or penalty
                        //then we add the cell to gamebaored and now we want to see if the cell has a ladder
                        //or chute and we add the current node into our dictionary with the id as key and the current node
                        //as our value and now here we know where ladder and chute starts but we want to add
                        //shortcut to go above the chute or ladder
                        //and when we go through the bottom element for the ladders we calculate the upstairs cell which is
                        //the top of the ladder nTopElement and if our dictionary of ladders contrains the top element 
                        //which gets us the node thats at the top 



                        //we added the downstairs id for the ladders but then we go through list of ladders then add the upstairs
                        //id to our ladders and when we do the chutes we do the same thing and add the downstairs of the chute and add the upstairs
                        //of the chute from the formula and our lists has the upstairs and downstairs of the chutes and ladders
                        //and we go through id's for ladders and we assume they are the bottom of the ladders so we calculate upstairs of ladder
                        //and if upstais index is in our dictionary that we had calculated, and if we find upstairs cell in our dictionary
                        //then we set shortcut of bottom cell to link to upstairs node and the value in our dictionary is the cell contained in the 
                        //linked list node so we can set our bottom cell to the dictionary indexed by the bottom id and we grab the value from that 
                        //then we set the bottom cell shortcut equal to the dictionary

                        //we have a dictionary of nodes and we get the node.value which is the value of our linked list (the value of each node in our linked list
                        //is a cell) and we need to grab the cell the linked list is pointing to and with the=at cell we set the shotrcut
                        //to 

                        //our dictionary is indexed by an integer and each entry in our ditionary is a linked list node which contains
                        //a cell as a value in the node so when we look at .value here its a cell based on that key and we grab the bottom cell
                        //then set the shortcut of our bottom cell equal to the node indexed by the upstairs id and gives us the node
                    }
                }
                //for our list of ladders we created by ID with random cell numbers we get the index of the top node for the ladder
                //then we check if the dictionary has the same exact key as the one we calculated then we made the bottom
                //cell equal to the dictionaries******
                //then we set the shortcut for the bottomcell to be the whatever node value there was for out int key that had matched our calcaulated value****

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

                        //go through list of all chute id's and calculate the top element and if the
                        //list of dictionary keys contains the top elment then we grab the top cell and we set shortcut of 
                        //top cell to the node of the bottom of the chute
                        //so basically we create a link between 2 nodes and its stored in the nodes value because
                        //the cell is the data within each node
                        //the node has a next and previous but within the node is the cell which is stored as the value
                        //property and within the cell is the shortcut which can point to another node 
                    }
                }

                // add the finish cell
                cell = new Cell();
                cell.nNumber = cntr; //how does it know to use cntr if its not in a loop**
                board.AddLast(cell);

                // set both players to start at the start of the board
                player1.currentCell = board.First; //node in the first part of linked list and Last is the last aprt of the linked list and to access any node
                //in between we need to go through the whole linked list like we do in the game and walk to the item in the list to get the powerup**
                //always have a reference to first and last thing in the linked list but nothing in the middle and we can only walk forward
                //or backwards in the linked list** (so we can add and remove form aywhere in the linked list but can't reference from the middle of a linked list
                //only the start and the end??)****
                player2.currentCell = board.First; //each player has a current cell field and we set that to the first node in our board****

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
                        //we want them to move forward but we check to make sure it's not null (they are at the end of the level)*********
                    {
                        // moving forward
                        if( sDirection == "+" )
                        {
                            // if there is a Next cell
                            if( thisPlayer.currentCell.Next != null )
                            {
                                // move the player to the next Node in the LinkedList**
                                thisPlayer.currentCell = thisPlayer.currentCell.Next;
                            }
                            else
                            {
                                // otherwise we are at an end of the board
                                break;
                            }
                        }
                        else
                        //this lets us walk backwards in our gameboard and the null is it they move before the start of the gamebaord****
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

                                //why is there no print method here for when they move based don the dice*********
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
                        // if the current cell has a penalty (is this when they stop or as they are moving across the board)*****
                        // clear the penalty flag
                        thisPlayer.currentCell.Value.hasPenalty = false; //when we clear it there is no more penalty there so another player won't get the penalty anymore
                        //when they go there****
                        //if we did not use value what would it give us back (value gives us everything in the cell object
                        //and we have to use another. notation to get something specific because its a collection of data right)*****

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

                        // no more spaces to move, but since the position has changed (rather up or down)***** loop back to check for powerups and penalties
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

                linkedListNode = linkedListNode.Next; //why do we go onto next if we only show 1 linked list node (cell) where the current player is at****
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
 *and we can make it more efficient from rather starting from the start of the linked list or the end of the linked list to get data**
 *we can also break up the linked lists and we might want to have multiple linked lists to make getting data more efficient
 *linked lists are more efficient for adding and removing rather than arrays because we have to make a new array then copy the data into the new array
 *then add and remove the value we need 
 *
 *Binary trees:
 * we want our game to guess between 1-100 and we want to guess what the value is 
 * best approach is to pick number in the middle and just by guessing number in the middle we have cut the possibilities in half so we know its 1-50
 *so now we guess 25 and we know 25 and 50 and we guess 47 and we got it in 5 guesses and its efficient and we have cut the possible number of values in half
 *and binary trees are useful for searching for data and binary trees is the most efficient for searching for data because each time it searches it cuts down
 *the possible data it needs to look for in half
 *if this was an array instead it could take 47 guesses if they were stores in an array from 1-100 because we would have to look through each
 *array element to figure it out and we are not able to split out or discard the items and an array we look through one item at a time*******
 *binary trees uses log2(100) (log2(N)) (the 100 is the size of our data from our guessing game) and it splits the binary tree in half as we move on in our guesses*******
 *is log2(N) the most efficient in terms of searching right (the time complexities are used for how long it takes to search something up based
 *on the data type right)******
 *
 *
 *
 */