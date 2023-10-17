using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//in our application we have to reference the dll we just created we go to reference in solution explorerer and we need to 
//right click and browse and find the dll in the bin and debug and check it off so we can work now and refernece
//whatever we need to (always do build in the dll then we an do this)
//solutions can contain multiple projects and we can right click on solution and do add then existing project so we can reference the dll (always do these 2 steps to make
//sure the updates are seen within the other application) 
//only put the c# application when we add an existing project not the whole folder(only the cs project)

//we put the dll project as a reference in the solutaiton and when we added the song lib project to out songapp solutaiton and the song lib is its in its own folder 
//the songapp solution had the song app project by default then we added the song lib project to its solution if we right click on the solution for song app and do add exiting 
//project and this lets us go to the song lib folder and add the song lib c# application only 
//so now whatever we do and if we go into songlib source code and 
//add soemthing to a class for example, and we go to the song app now and call it in the name we can access it within the class code because its in the same solution 
//so its seen by the application code (song app) and if we kept song lib, seperatly, then any changes we made then we need to rebuilt it whereas if we have it in the same
//solution then it would update automatically (we can right click and put set as starting project then we could do that but its not really common)

//in the main application we usualy create instances and access them and we can call new methods to do things as well 

//this basically brings in all the dlls together and we can crete instances and use them together here(yes)

//we do build name of appliaction right not build solutation are they the same thing(both work)

//does namespace have to be same for this what has to stay constant when doing dll(no)

//for dependence it knows it has to build something first because it depends on it (dependancy) (priority over it because it depends on it)



//songlib
//generates a dll file and now we can use it in our application 
//in the bin folder and the debug there should be a dll called songlib and it contains the dll and now if we create an application that uses the dll we can use all
//of the data types across different applicatinos and we dont have to recreate them
//and we have to have the same namespace though to access the same dll (they dont have to but its good practice and one project = same namespace name throughouht)

//now we want to create our song application to work with that dll and it will be a standard console applciaton
namespace SongApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
