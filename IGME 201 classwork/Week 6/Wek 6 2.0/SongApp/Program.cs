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

//Creates a private field called parentString and we can access the private
//string via a property when we create an instance of a child so it can inherit the property and be able to access the
//private property.*******

//songlib
//generates a dll file and now we can use it in our application 
//in the bin folder and the debug there should be a dll called songlib and it contains the dll and now if we create an application that uses the dll we can use all
//of the data types across different applicatinos and we dont have to recreate them
//and we have to have the same namespace though to access the same dll (they dont have to but its good practice and one project = same namespace name throughouht)

//now we want to create our song application to work with that dll and it will be a standard console applciaton

//if we want to sort a list of songs by the song name then we can have all of our different song types and sort them by name**
//we need to an inherit an interface called ICompareable<Song> and we specify what the class its going to ues for comparison which is the song class (usually same class*
//that we are using the interface for reference like Song)**
//

namespace SongApp
{
    internal class Program
    {
        public int CompareTo(Song s) //we use the list inherited from the parent class that was in the interface** (songlib)
        {
            return this.Name.CompareTo(s.Name); //compare to is string comparison and it returns -1,0,1 which means**
        }
        static void Main(string[] args)
        {
            List<Song> songs = new List;
            songs.Sort(); //now it will use the compare to method of the class to compare the objects and sort them instead of the default method??**
            //sort songs the songs list in place and ti will change the order of items in the list whereas the order by sorts in the way that we want and both**
            //usually create a copy**

            //we can also sort lists by any other field by using the order by method**
            //
            songs = songs.OrderBy(OrderByName).ToList(); //we need to pass a delegate or method for the order by**
            //returns an enumerable type which is just an internal type and we have to convert that back to a list again**
            //what does order by do again**
            //always convert back to a list for order by**
            //since it expects a delegate or a method we could do:
            songs = songs.OrderBy(delegate(Song song1) { return song1.Name; }); //this takes a song paraemeter and returns the song name and we can simplify it further**
            songs = songs.OrderBy((song1) => { return song1.Name; }); //remove delegate and lambda expression
            songs = songs.OrderBy((Song song1) => { return song1.Name; });
            songs = songs.OrderBy((song1) => {song1.Name;}); //we have to put.ToList at the end of each** (simplify the delegates)**
            songs = songs.OrderBy((song1) => {song1.Name; });

            //we can implemeent the compare to method which we can specify which field or fields we can use to compare and we are comparing a string right now
            //but we might want to compare or return their rating so we can do a return this.nRating.CompareTo(s.nRating); compare to is a member of every data type
            //to allow us to do compare to but its only used for fields within an object and CompareTo usually takes in an object and compares each object based on a field
            //and sorts it based on**

            //we can also use orderby and they create seperate lists whereas compare to does not??**



            //classes are reference variables so that means that whenever we look at a class variable its pointing to an object not holding it and we are looking at it
            //through a mirror and any changes we made are made to that object and we can have mutltiple variables point to the same thing and can manipulate it but for
            //structures we cant do that and we are holding the value so we can only change that thing the variable points and its not an object type (not a miror)**

            //if we set a = b we have overridden the content of a with b because its s structure and now a.val is now 5 instead of 4 (b is 5) then we can change b.va to
            //1 and a.val is still equal to 5 while b.val was changed (val??)**
            //when we have a string equal to david for x and make string y sue if we do x = y then x = sue and all of our primtive datatypes work the same way as a structure

            //in order to make copies of methods we need to use special methods**
            //MyClass contains a mycontent object which is a class object and a mystruct structure (call by value)
            //Create a new object of my class and set the members of the class equal to a different value so we have a string names my string and 
            //my content is an object in MyClass and when I create a new class object it creates a new content object within the class and we can set
            //the string in mycontent to the content string 
            //and we are setting thr structure members value to 42

            //now we want to make a copy of Myclass (myclasscopy) and we create a anew myclass object in there and we make
            //myclasscopy = myclassobj (obj was filled in above)**
            //set a breakpoint in that line and it says that everything from myclassobj is in myclasscopy but when we creates the myclass objects now we have 2 objects memeory
            //the old and new object and we have 2 reference variables in memory (myclassobj and myclasscopu that holds the instances)
            //each varibale points to their instances 
            //we have 4 different variables (2 objects and the 2 variables that refernce thenm when we create our object)
            //we took myclasscopy and we pointed it from myclasscopy to myclassobj and now myclasscopy is gone forever and we cant get it back
            //since we set myclasscopy equal to one before now its completely lost because we set myclasscopy equal to myclassobj 
            //double == would not make it lose data because its jsut a comparison and it would not chnge any code and we would get an error because 
            //we need an if statement or a boolean overloaded operator 

            //we can check if classes if class instances are equal to each other and we can do if(myclasscopy == myclassobj) and it checks if they point to the same thing and
            //its false right now because they are seperate things but if we set them equal to each other then it would return true and they are equal to each other and now
            //the copy is lost forever since it gets equal to the mycallobj**

            //if we change values in myclasscopy and change the string to david for example in myclasscopy and now in myclassobj it changed it to david as well because they
            //point to the same thing because they are set equal to eachother and both point to myclassobj**

            //for thestructures in both if we change the structure in the class object it will also change because everything in classes even if they are a value type,
            //we can also be changed because they both point to the myclassobj now

            //how we actually create a copy is by using the myclasscopy = myclassobj.memberwiseclone() (use memberwisse clone method)
            //and its a member of the object class and its protected(it can be accessed from any child in the family tree but it can't be accessed outside the family tree)
            //(but we can do it with parent)(cant do it with instances because its outside family tree)
            //we have to implement a method called clone in the class to call the memberwise clone so we can access it from outside the classes and in order
            //to implement the clone method, we have to inherit the ICloneable method and it means our class supports cloning and is requirede to have a clone method
            //and our clone method could do anything by definition it calls memberwise clone (this always returns an object data type and does not return the 
            //data type of the class)(its the most generic datatype and we can set anything equal to an objet type in c# because its so generic)(and the memberwiseclone
            //will return a new copy of our class object)**
            //memberwiseclone is used to make a shallow copy which means its going to do all of the value datatype variables that are in our class so the shallow
            //copy of myclass makes a copy of our int string and struct because they are value dataetyopes and mycontent is a reference type so memberwiseclone will not
            //copy the contents of mycontent and only copies a reference which means that
            //in c# we can right click and do peek definition and it shows us how its defined in c# library
            //myclasscopy = (myclass)myclassobj.clone(); which returns the shallow of myclassobj and we have to cast it to myclass because**

            //the clone only covers the value datatypes (highest level value fields which are the value fields directly assocated with the class like
            //the struct int and string,etc.)
            //and now the reference datatypes only has the pointer to that value in the class so if we change one class
            //reference variable, then both reference types changes**

            //myclassopy is now seperate from myclassobj because we did the clone even though the objects are reference types when it gets copied**
            //when we change the david string to sue now it does not change it in the other class and now if we change the int to 34 in myclasscopy is does not
            //change it in original and it stays at 1 
            //mycontent is shared though because it was a reference type so when we change the reference in myclassobj, it changes in myclasscopy because they point
            //to the same reference type and its only 1 copy, so they point to the same thing

            //deep copy copies all of the value and reference types compared to only the reference types in the cloning methods**
            //in order to do a deep copy of our MyClass class type when we do the clone we first create a copy of our object within the clone method but in the shallow
            //copy our original clone only returned the memberwiseclone() which only returned our value types (shallow copy lso creates a new instance same for deep copy but the
            //reference types point to the same thing as original and copy)**
            //we start by making our new myclass object from the mmeberwise clone then we need to set the mycontent in the cloned object into the cloned content in my object
            //and we need a meberwiseclone() method within the child class mycontent (my content before just had the string but now it has the clone method in it) and now
            //we can call the clone method of the mycontent class which will return an object (ne object) that has the contents of its value type fields and cast
            //that as a mycontent and set that to the mycontent field of our new copy and object are reference variables same for arraya and lists so if we have
            //a list in a class then we need to do a deep copy on that list so when we cloned our myclass object we want to set our names of our cloned objects equal
            //to the sourcce (original range list) and we get all of thoese values and it gets a copy of the list and does not point to the original
            //after we return the myclonedclass in the end


            //do we usually make the clone method in the parent and the class will usually inherit the interface**
            //any value types in our class we need to do it manually and we usually clone parent or can we do**
            //children as well what if we had a unique reference we wanted to clone**




            //getrange tells ut the index to start from (0) and then the number of items to extract
            //getrange from a list returns a new list of a subset of that list (some or all) and if we want copy of whole list we go from
            //0 to the number of items in list.Count
            //if we wanted the last 5 items in the list we would do this.names.count-5, 5 so it gets the last 5 items of the list**


            

        }

        static string OrderByName(Song song)
        {
            //we need to pass in a reference to a song object because thats what the list consist of and all it does is it retuds song.Name
            return song.Name;
        }
    }
}


//properties and interfaces
//interfaces are handles we can use to access classes and they allow us to access different objects that share the same members and those members could
//be shared property names (used to access any class that had a name property in it and we knows its a property because it has a get nd a set)
//we could have an interface that also has a read only which is get and in our class we have a read write property but if we want to access the name property from
//the class we could define the interface that only defines the read (get) only which we have done (Inamereadonly)
//in the class itself it has the get an set itself
//interfaces can use properties to access values 
//in the train class we have our value type string and it cant be used by an interface because it can only access PROPERTIES AND METHODS NOT FIELDS**
//when we ues properties (public) to access a private field we could access and manipulate the private fields like pet and how we had the public name prop.
//to access the private name field and the private field is in the parent (pet) so the private name field was not accesible in private field but the dog and cat
//could access the name property (public) and it acted like an intermediatary to access the parent (allowes us to hide data from the user)

//indexer property so if we have an array or list** in our class we can use an indexer property to access the array or list and in this case we ue the indexer
//property to index by an integer and we can have multipe indexer properties in a class but they have to have different signatues and if we had another list in our
//class like the trains we can have another indexer property that references the train list (always name indexer proeprty by class we are indexing by)**
//if we had another string list it would not work because signature would be the same**
//once we add a constructor that takes para. then the default constrcutor dispears and by default we have a default vonstructor if we dont add anything but if we do
//define our own constructor, we have to explicitly create a default constructor (we would need a default to maybe access with dot notation)**

//we could use method to access the Inamereadonly interface for our mytrain and mybldg and we could also create an object as a para. then
//we could use that to check for instances and do specific things**

//we can set accessiblity of the interace even though the class might have a read and write and we could only call read for the interface 

//we could have INameReadOnly readOnly = mybldg;
//we could also define a variable instead of a method then we can use sstring myName = readOnly.Name because its read only and we cant set because theres no set 

//if we pass the obj datatype is that we could have a method thats very generic and we know all of our objects have similar things so passing it in as the most generic type
//allows us to write generic code that we want to do all over the place but we only have to write it once (like the object sender in windows forms and it allows the windows forms
//methods to work with any kind of controls) we dont want to have a new method for every single type of control and its much more flexible (cant we just say the object instance.**
//method name because the classes are similar**

//passing by a specific class or interface would restrict the code more to what it can do so we can pass similar objects into the methods and we can check how different
//classes are related then do thigs which prevent run time erros**