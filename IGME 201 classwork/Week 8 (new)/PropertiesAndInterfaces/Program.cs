using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//on exam when it says to make an interface do we create the properties and methods as well or just make it empty like the make our own shumul part**
//properties and interfaces
//interfaces are handles we can use to access classes and they allow us to access different objects that share the same members and those members could
//be shared property names (used to access any class that had a name property in it and we know its a property because it has a get nd a set)**
//we could have an interface that also has a read only which is get and in our class we have a read write property but if we want to access the name property from**
//the class we could define the interface that only defines the read (get) only which we have done**
//(Inamereadonly read = new Building() then do read.Name(no () because its a prop.) this was if the obj method was not there and it inherits the interface
//**(can do this because building inherits from**
//the interface otheriwse explicitly cast by doing Building build = new Building() then Inamereadonly read = (Inamereadonly)build** (usually the case for explicit casting)
//for classes and interfcaes??**
//but how would it work since the interface is only a reference and building does not implement it since it did not inherit (if this was the case)**
//interfaces can use properties to access other property values based on what class inherited it or if we exlicitly casted (same for methods)**
//in the train class we have our value type string and it cant be used by an interface because it can only access PROPERTIES AND METHODS NOT FIELDS**
//when we ues properties (public) to access a private field we could access and manipulate the private fields like pet and how we had the public name prop.
//to access the private name field and the private field is in the parent (pet) so the private name field was not accesibl but the dog and cat
//could access the name property (public) and it acted like an intermediary to access the parent (allows us to hide data from the user)**



namespace PropertiesAndInterfaces
{
    // interfaces give us access to classes that inherit from them
    // so that we can access the Name property of any class that inherits IName
    public interface IName
    {
        string Name { get; set;  } //other than the private prop. we can just have it with the semi-colon
    }


    // we can limit this interface to only have read-only access to Name by only including the get function in the property definition in the interface
    public interface INameReadOnly
    {
        string Name { get; }

        // we can also add methods to interfaces
        // so we can call the Build() method in any class that inherits this interface
        void Build();
    }

    // because Building inherits from IName and INameReadOnly, we need to implement the read/write Name property and the Build() method
    public class Building : IName, INameReadOnly //if it was from readonly could we have also had a get or would it only have to be a set**
    {
        public string Name
        {
            get; set;
        }

        public void Build()
        {

        }
    }


    // Train class also inherits from IName and INameReadOnly so it must implement the read/write Name property and the Build() method
    public class Train : IName, INameReadOnly
    {
        // here's a simple public string variable field
        public string type;

        // here's the simplest implementation of a property with the default get and set functions
        // Name is a read/write property
        // if we omit the get function, then it's a write-only property
        // if we omit the set function, then it's a read-only property
        // Name behaves just like a simple string field** (since it technically has no get and set its**
        // considered somewhat a field but if they had something it would be a prop.)**
        // but we can access Name using the interfaces
        // we cannot access non-property fields via interfaces
        public string Name
        {
            get;
            set;
        }

        // here's a private passsword string variable field
        private string password;

        // we can use a public property to access private fields
        // and our get and set code blocks can do anything like in the Person class where the LicenseId property verifies the person's age before setting it
        public string Password
        {
            get { return password; }
            set { this.password = value; }
        }

        List<string> myStringList = new List<string>();

        // if we have an array or list in our class
        // we can use an indexer property to access the array or list
        // indexer properties use the "this" keyword (example of using it with an instance)****
        // and are accessed via the class object
        // see code below 
        //this is a one to many relationship right so if a parent had a one to many then how would that work****
        // the indexer property returns the type of data in the array and indexes via the index type
        // myStringList is a list of strings and is indexed via an integer
        // (in the case of a class we would be indexing on the string or int or whatever defines it and in the method signatire the class would be in place of string and the**
        //int or string woukd be in the [] with the variable of that type)**
        // therefore the indexer property signature must match that

        //indexer property so if we have an array or list** in our class we can use an indexer property to access the array or list and in this case we use the indexer**
        //property to index by an integer and we can have multipe indexer properties in a class but they have to have different signatues and if we had another list in our
        //class like the trains we can have another indexer property that references the train list (always name indexer proeprty by class we are indexing by)**
        //if we had another string list it would not work because signature would be the same**
        //once we add a constructor that takes para. then the default constrcutor dispears and by default we have a default vonstructor and if we dont add anything
        //then we could still access the default constructor with .notation and access anything we want from that class or the parent class with .noation if it**
        // had a parent** but if we do
        //define our own constructor, we have to explicitly create a default constructor (we would need a default to maybe access with dot notation and we would put in shumul
        //as +() but in general dont if we did not define anything else)**



        public string this[int indexEl]
        {
            // get returns the string at the requested indexEl
            get
            {
                return myStringList[indexEl];
            }

            // set adds the value to the list
            set
            {
                //myStringList[indexEl] = value; we could also do this right to access they key by and int and the value would be an instance of the object??**
                //is this usually the case for indexer properties and how we can only access the instances of a class in the list by the key which is usually the property**
                //in the class (can we have multiple classes in there as well as non inherited ones how would we access it)**
                myStringList.Add(value);
            }
        }

        List<string> myStringList2 = new List<string>(); //one indexer property per type of list 

        // note that if we have 2 arrays of the same type, then we cannot have 2 indexer properties with the same signature
        // C# won't know which one to call, since they have the same signature (return string, index on integer) //we can do it in different classes though right**
        // (different code blocks)**
        //public string this[int indexEl] //cant use indexer property here because its the same signature (we could use short though
        //even though its a number)
        //{
        //    get
        //    {
        //        return myStringList2[indexEl];
        //    }
        //
        //    set
        //    {
        //        myStringList2.Add(value);
        //    }
        //}


        SortedList<string, Train> trainList = new SortedList<string, Train>();

        // but we can have an indexer property on a SortedList, since it has a different signature
        // our SortedList returns Train objects and indexes on the trainName
        public Train this[string trainName]
        {
            get
            {
                return trainList[trainName];
            }

            set
            {
                trainList[trainName] = value;
            }
        }

        // once we add a constructor that takes parameters, the default constructor is no longer defined
        public Train(string password)
        {
            this.password = password;
        }

        // then we need to explicitly define the default constructor (ie. the constructor that takes no parameters)
        public Train()
        {

        }


        // a common mistake is to create an infinitely recursive property
        public string InfinitelytRecursiveName
        {
            get
            {
                // by returning itself, it will recursively call its own get function
                // and generate a stack overflow
                return InfinitelytRecursiveName;
            }

            set
            {

            }
        }

        public void Build()
        {

        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Train myTrain = new Train();
            myTrain.InfinitelytRecursiveName = "test";
            //Console.WriteLine(myTrain.InfinitelytRecursiveName);

            // access the indexer property that accesses myStringList**
            myTrain[0] = "david";

            // access the indexer property that accesses trainList**
            myTrain["freight"] = myTrain;

            Building myBldg = new Building();

            INameReadOnly inro = myBldg;
            string myName = inro.Name; //calls the read only of the class instance**
            
            // both Building and Train have Name and Build() class members**
            // so we can use the interface to access those class members even though they are completely different types of objects**
            WriteNameAndBuildUsingInterface(myTrain);
            WriteNameAndBuildUsingInterface(myBldg);

            WriteNameAndBuildUsingObject(myTrain);
            WriteNameAndBuildUsingObject(myBldg);

            // you cannot create interface objects, interfaces are only used as reference variables or pointers to class objects that inherited them
            //INameReadOnly = new INameReadOnly();
        }

        // receive the object using the interface
        static void WriteNameAndBuildUsingInterface(INameReadOnly inro)
        {
            Console.WriteLine(inro.Name);
            inro.Build();
        }

        // receive the object using the Object class
        static void WriteNameAndBuildUsingObject(Object inro)
        {
            // only attempt to access Name and Build() if inro is associated with the INameReadOnly interface
            if( inro is INameReadOnly )
            {
                // we can explicitly use the Object as INameReadOnly by explicitly casting it
                Console.WriteLine(((INameReadOnly)inro).Name); //here we are going from more specific (less generic) (INameReadOnly) to
                                                               //less specific (more generic) (inro object) so we have to explcitily**
                                                               //cast** (always the case)** like how we make Rectangle r; r = (Rectangle)shape because it was more**
                                                               //specific type rectangle, to less specific type, shape**
                ((INameReadOnly)inro).Build();

                // or we can define a reference variable
                INameReadOnly inro_ref = (INameReadOnly)inro;
                
                // this code is much easier to read than the explicit casting above
                Console.WriteLine(inro_ref.Name);
                inro_ref.Build();

                // note that we can always set a more general class type equal to a more specific class type
                // but in line #214 we need to explicitly cast the variable if we are setting a more specific type (INameReadOnly) equal to a less specific type (Object)
                Object myObject = inro_ref; //this is less specific to more specific so thats why it works but not the other away around we have to explicitly cast as shown above**
                                            //in the case of shape in shapes could we have done Rectangle rect = Rectangle(shapes) to explicity cast as well??**


                //we could use method to access the Inamereadonly interface for our mytrain and mybldg and we could also create an object as a para. then**
                //we could use that to check for instances and do specific things the methds with the object keyword do we usually use typeOf and is within the object**
                //so we can do specific things based on what the object is**

                // even though the class might have a read and write and we could only call read for the interface like we did above here by just using the read property with .**
                // noation then using it with a class instance that inherits it or could explicitly cast to do it like Builing build = new Building() then
                // inter InterfcaeName = Inerfcaename (is this how we usually access interfaces) then do inter = Interfcacename(build)**

                //we could have INameReadOnly readOnly = mybldg; then do mybldg.Name to get the read only as well**
                //we could also define a variable instead of a method then we can use sstring myName = readOnly.Name insteda of hthe method we used with the instances
                //because its read only and we cant set because theres no set**

                //if we pass the obj datatype we could have a method thats very generic and we know all of our objects have similar
                //things so passing it in as the most generic type
                //allows us to write generic code that we want to do all over the place but we only have to write it once (like the object
                //sender in windows forms and it allows the windows forms
                //methods to work with any kind of controls) we dont want to have a new method for every single
                //type of control and its much more flexible basically we can use object to call specific methods and fields and prop. based on the class**
                //that is the object** (cant we also just do the instace of the object. get something from the class)**

                //passing by a specific class or interface would restrict the code more to what it can do so we can pass similar objects
                //into the methods and we can check how different
                //classes are related then do thigs which prevent run time erros**

            }
        }
    }
}
