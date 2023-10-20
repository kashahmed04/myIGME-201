using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//MAKE SURE TO FIX SCALING IN WINDOWS FORMS FROM DOCUMENT****
//a combobox is a drop down menu and we can add the items in the menue and we can have the dropdown of student and teacher and textbox allows us to type text in the box****
//and there are a lot of events that can be triggered with the textbox****
//and we have an ok button and a cancel button and a erorprivoder contorl and allows us to show errors next to fields when there is a probloem with the field****
//and when we press enter we have the okbutton and the cancel button is for when we press escape****


//ask about the this in the PE 15 or 16******

//if the classes are small we can combine them into one aplpication

//2 enumerated types that have th alive and dead status of the cell and the infected state has been added to the infectedstate enumerated type
//and in another enumerator we have to direction of the cell 
//each cell has a state so we use a structure to store the current state of the cell and the next cell
//our program has to go through and look through the current state of our cell and see what the next state will be and apply that next state to the current state
//we cant apply the next state because the next state depends on every other state in the cell(has to calculaete it)
//the cellstate structure includes the infected and alive state of the cell which is private and a public property and if a public property**
//has to same name of the private field they have a relationship and the property interacts with the private fields and adds additonal logic to the field**
//our alive state returns the alive state and our set function sets the alive state to the value but then checks if the alive
//state is now dead then we want to reset the infected state to its original state which is organic (if the cell has died, its not longer infected thats why we do this)
//we are going to have 30x80 array of cells to store the organism and we want to have 50 cells that have the virus and that are vaccinated so we can cap those values (const)
//we have sttaic variables for the number of viruses and vaccines and we can calaculate how many neighbors each cells has based on our macneighbors enumerated type
//we need to array of our neughbor cells for the current cell and we also want a way to have a 1 dimensional list to go to the start of our organism to the left
//the next cell refrecnce variable to the Cell (not an instance because theres no new keyword with it so it just points to the class for now)****
//we have 2 structures to hold the current cell state and the next cell state or our organism and a random number generator and for the Cell constructor we have
//the maximum cells in our organsim and its the probablity that our cell is alive and it would be a 1 our of 4 chance it would be alive and 
//when we pass a value to a method we can set a default value and it only applies to the last parameter and we can omit the second para. in our call to the method
//the 4 would be put in automatically or if we put in something it will use what we put in**

//we calculate the probbality of living then if we have not infected all of our cells then we calculate the probablity of being infected 
//the constructor decides id the cell is alive or vacinated or infected
//and in the setnextstate lets us see the next neighbors and if they are alive or dead or vacccinates or infected and we can apply the 4 rules to the game based on that
//firt we loop through all the neighbors then we loop through how many are vaccinated,dead,or alive, or infected then we initializwe the  next state to be
//the current state of the cell for alive and dead
//and if there are 3 cells alive then the next state should be alive if it was dead already
//in the main we define static variables for the dimensions of the organism and allocate the array of cells and its not the cells themselvds 
//we have to go through each coordinate in the array and we go through each row and column and we need to call the constructor the cell at that coordinate and it creeates
//our cell object and we have to create the object which is in each of those coordinates 
//we need to go through the whole array and set the neighbors of each cell and we set the reference variables for each cell of that neighbor array
//we start with our 2 loops to go through the loop and column
//then we go through and find the neighbors of that cell and neighbor cell points to the cell thats in the direction of ncounter which is the 8 possible members
//of the current cell and makes neighborcell point in that direction (enumerated types map onto integers in c# and right is a value of 0, then thr rest goes down by index)
//when we loop through by nCounter for all of the possible values and we have to do catse (int) editecion.right to get the right value and we check to see that we are not at the end of
//the row then set our neighbor equal to the row and our next cell is our cell to the right and its a one dimensional linked list and its points to the right of it
//if we are not on the last column we can grab the row to the right as long as we are not on the last row
//at the end of the for loop for each direction we can set the neighbor of the array element to the neighboring cell in that direction and it just sets up
//the organism and now we need them to poiunt to all of their neighbors by reference
//ConsoleCancel() sets the boolean to teue meaning we want to exit the program and cancelkeypress means if the user pressed control c and we attach our method to the
//event handler and we have an infinite loop whch prints out the organism from oyr 2D array and we calculate the next generation and we pass in the top left
//cell of our organism and we pass in organism 0,0 and calucalte next generation and caclautes our next organism and for each cell it goes until it reaches our
//based cause until we get to the bottom right which is the end of the list 
//and we call ourself with the next value in the lust until we get to the very last cell and we are done recursing and now we unrsvel our recursive method and it adds
//another instance of the method added waiting for the base case and when it unravels for every cell it calls the current cell state = to the next cell state we had calculates
//goes down a rabit hole when it calls itself dor recursion and every method we called is waiting for the next method to finish then we can have each instance of the method 
//calcukate once we get to the base case 

namespace Week_8._2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
