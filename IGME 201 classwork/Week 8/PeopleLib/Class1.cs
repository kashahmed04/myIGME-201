using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * each source file (each class source file should contain only one class but if the classes are really tiny like PE11 its ok to have multiplt classes in one file)
 * If we need more class files we right click on the project then add an existing item, new item, or class which means******
 */

namespace PeopleLib
{
    public enum genderPronoun
    {
        him,
        her,
        them
    }
    public enum collegeYear : byte
    {
        freshman = 23,
        sophomore = 22,
        junior = 21,
        senior = 20
    }

    public interface ICourseList
    {
        List<string> CourseList
        {
            get; //what is this interface doing how does it work**
            set;
        }
    }

    public abstract class Person
    {
        public string name;
        public int age;
        public genderPronoun eGender;
        public string email;

        public string photoPath;
        public string homePageURL;
        public DateTime dateOfBirth; //can we change the date time or is it only the current date** how can we change it**

        private int licenseId;

        public int LicenseId
        {
            get
            {
                // get will simply return licenseId but it can do any logic** but its a private field so how can children access it (will it work if in a get and set??)**
                return licenseId;
            }

            set
            {
                // we will only set the licenseId if the person is older than 16 (use this.age)**
                if (this.age > 16)
                {
                    licenseId = value; //so basically does value use whatever the user enters if it was a instance.licenseID = consoel.readline(some input)**
                                       //and it could also be**
                                       //if we set it in our code as well like setting licenseID equal to soemthing when we create an instance of the children**
                }
            }
        }

        public static bool operator <(Person p1, Person p2) //boolean overloaded has to always go in parent class or the actual struct itself right**
        {
            return (p1.age < p2.age);
        }

        public static bool operator >(Person p1, Person p2)
        {
            return (p1.age > p2.age);
        }

        public static bool operator <=(Person p1, Person p2)
        {
            return (p1.age <= p2.age);
        }

        public static bool operator >=(Person p1, Person p2)
        {
            return (p1.age >= p2.age);
        }

        public static bool operator ==(Person p1, Person p2)
        {
            return (p1.age == p2.age);
        }

        public static bool operator !=(Person p1, Person p2)
        {
            return (p1.age != p2.age);
        }

        public virtual void Work()
        {
            Console.WriteLine("work work work");
        }
    }

    public interface IStudent
    {
        void Party();
    }

    public interface IPerson
    {
        void Eat();
    }

    public class Student : Person, IPerson, IStudent, ICourseList
    {
        public double gpa;
        public collegeYear eCollegeYear;
        public List<string> courseCodes = new List<string>(); //what the point of creating this if weare accessing courseList**

        //is this how we reference the list from the interface**
        public List<String> CourseList //this goes through the list of CourseList from the interface and and does the get and set to add or get a value from
                                        //the course codes, but why do we have to access from the interface if we already have a list of courseCodes** It
                                        //can access the courseList because the interface is public and we put it after the ":" so now it can access the interface??**
        {
            get
            {
                return this.courseCodes; //this is the list of courses they take while for the teacher its the ones they teach but how would it work are they limited
                                            //to only getting and setting certain things for a teacher and a student (each instance is a different list?? even when we
                                            //access CourseList would it be different or the same list for the instances)**
            }

            set
            {
                this.courseCodes = value;
            }
        }

        public static bool operator <(Student s1, Student s2) //do we create a seperate overloaded operation for each class if we want to use something unique in the child**
                                                                //like over here with gpa**
        {
            return (s1.gpa < s2.gpa);
        }

        public static bool operator <=(Student s1, Student s2)
        {
            return (s1.gpa <= s2.gpa);
        }

        public static bool operator >(Student s1, Student s2)
        {
            return (s1.gpa > s2.gpa);
        }

        public static bool operator >=(Student s1, Student s2)
        {
            return (s1.gpa >= s2.gpa);
        }

        public static bool operator ==(Student s1, Student s2)
        {
            return (s1.gpa == s2.gpa);
        }

        public static bool operator !=(Student s1, Student s2)
        {
            return (s1.gpa != s2.gpa);
        }

        public void Eat()
        {
            Console.WriteLine("Order a pizza!"); //the interfaces references (points) to**
                                                 //these methods because it's within the student and since the interface is after the ":"**
                                                 //the interface points to the method thats in student if we made a interface variable (not instance) equal to**
                                                 //an instance of the child class and we call that specific method common in both the class instance and the interface**
                                                 //interface datatype interface variable  = instance of child**
                                                 //interface varible.Eat() = order a pizza!**
                                                 //(cant set interface variable directly equal to new Student() or can we)??**
        }

        public void Party()
        {
            Console.WriteLine("Party on dude");
        }

    }

    //for the license ID the field is available within the class (or code block)**
    //its defined in but the property is inherited because its not private (should we usually create a public**
    //method or property within the classes that have a private field so its accessible to the children)**
    //when we get and set it within the parent and access it from child with this. or instance. how does it access the field if its private and actually return it**
    //we can over ride how classes are compared by using boolean overloaded methods and it uses the Person class to compare and
    //when we compare 2 person objects it uses their age to compare them but in the student definition it only takes the Student objects and compares them by their GPA'S
    //so basically if we call the comparison with 2 student instances it does the GPA because it was overidden but what if we wanted to call it specifically for the**
    //parent comparison of age would we do Person = new Student() (parent does not access GPA so it calls the age instead)??**
    //(less generic to more generic and cant do other way around unless we explisilty cast like**
    // Student instance var = Student(new Person()) or person instance variabele of person or can use both)**

    //the teacher over rides the work method and talks all about their speciciality and has a list of courses they teach (how does the get and set work here rather than
    //the student is it two seperate lists or)**(everyt tine we refrence the coureselist how does it work)**
    public class Teacher : Person, IPerson, ICourseList
    {
        public string specialty;
        public List<string> courseCodes = new List<string>();

        public List<String> CourseList
        {
            get
            {
                return this.courseCodes;
            }

            set
            {
                this.courseCodes = value;
            }
        }

        public override void Work()
        {
            Console.WriteLine($"I'll tell you all about {specialty}.");
        }

        public void Eat()
        {
            Console.WriteLine("I eat lots of apples.");
        }
    }

    // [+People|sortedList:SortedList<string, Person>|this:email|+Remove(email: string)] in the shumul its written differently for indexer property**
    //for sortedlists is it always oublic for accessibility or will it say accessivlity because here it does not**
    public class People
    {
        // the generic SortedList class uses a template <> to store indexed data
        //is the first thing in the shumul for the lists the name of the list**
        // the first type is the data type to index on
        // the second type is the data type to store in the list
        // create a Sorted List indexed on email (string) and storing Person objects (how do we check to make sure it was email or could we have entered anything)**
        //basically for an email is checks if the email matches an email in the person objects and returns that instance of Person if the email matched**

        //we create a list of person objects because its one to many relationship meaning that many person objects will be in a list in the people object
        //and thats how we reference the list of person when we create an instance** (usually create a list for one to many??)**
        //for one to one and one to many we dont do the ":" for it after the class names right**
        //how to use 1-1**
        public SortedList<string, Person> sortedList = new SortedList<string, Person>();
        //lists are cpitalized because they are a data type right**

        public void Remove(string email)
        {
            if (email != null)
            {
                sortedList.Remove(email); //if they pass a valid email then from the sorted list we use**
                                          //the built in remove which removes the key and value based on the key in the list**
                                          //if its not found it returns false but would it just not do anything in the console**
            }
        }

        // indexer property allows array access to sortedList via the class object
        // and catching missing keys and duplicate key exceptions 
        // notice the indexer property definition shows how it will be used in the calling code:
        // if we have:
        //     People people;
        // then we can call:
        //     people[email] to access the Person object with that email address
        // and value will be the Person object (person) being added to the list in the case of:
        //     people[email] = person;

        //do we have to create a new person everytime we access via email or can we put in an existing thing or would it return error since**
        //its the same key**
        //would we have to set each thing in the constructor equal to something when we create the instace via the key or would we only do some like**
        //.notation or something**


        //this is used to get and set person instances in the Person list defined above. Basically when we want to get or set a value based on the email**
        //it goes to the get and check if the key exists in the sortedList and returns the person object which is the value for the key, does not return the key and value**
        // only the value, and if the key does not exist then we jsut retunr null** 
        //we set the key equal to whatever value we put in (whatever person object we put in)**
        //and put it into the list but if the email or key is invalid then it goes to catch**
        //(when would it not be valid because we dont have any cases for it unless we want to remove (when they is already in the list??))**
        //catch is empty what does it do (can it even be empty)**
        //the email is inherited by the student and teacher because its from person so thats why it can work (do we always have to have it so
        //the fields are common like email to access something could we have also done age or something since its in the parent)**(or could we have done
        //an unrelated variable thats not in the parent or child)**

        //for the name of the indexer property does it always have to be the same name of the class we are indexing on (ex. the value of the sortedlist item??)**
        public Person this[string email] //the indexer property is defined as having a return type and it returns a person objtec and we use the this keyword
                                         //and like an array we put the value we are indexing on in the [] brackets by the key**
                                         //(so is this then seperate from the list then**
                                         //based on whatever key we index on it goes to the list and gets the value??**
                                         //when we create a people object we can access their email by using People[email] (what about when we create an instance of People)**
                                         //its a property that has get and set methods and it has the square bracket and it uses the this keyword so now we can
                                         //access our list and index our class instance to access a specific instance based on the email (key)**
                                         //each entry in our list is a person object and reading the objtec out of our sorted list based on the email which was
                                         //the key****
                                         //does it create a copy when we get or does it directly take it out**

        //we are getting a person instance and setting a person instance for the email which is the key
        //to access we can just do people[email] (get)** (how to access this property in an instance)**
        //but to set we do people[email] = person;** (how to do as an instance)** (value is the variable is on right of equal sign which is the person instance****

        //people[email] = person; is what gets put into this[string email] and gets used in the property for each instance?? (only student and teacher have the propety so
        //how would it work if the Person class was not abstract and we created an instance**

        //now we create this into a dll by doing build but its bettwr to do rebuild so it does it all knew and we know it has built*****
        //we would want to rebuild the whole solutino if we have many projects in our solution and we changed a lot of files and we want to make sure everything is up to 
        //date (even with source files it will update if there are multiple files in one application or dll)****
        {
            get
            {
         
                Person returnVal; //returns a person objtec and we put it in a try catch because we dont want our program to crash if the email
                                  //is not in the sorted list****
                                  //when we try to read a value that does not exist(the key) it returns a run time error without the try and catch****
                                  //we want to make a person returnVal so it can return an actual person object** (the datatype is the Person class)**
                try
                {
                    returnVal = (Person)sortedList[email]; //reads the email (key) out of the Person sorted list and returns the value which is the person**
                                                           //instance (teacher or student) (why do we have to put person again if the sortedlist
                                                           //already contains person)**
                }
                catch
                {
                    returnVal = null;
                }

                return (returnVal);
            }

            set
            {
                try
                {
                    // we can add to the list using these 2 methods
                    //      sortedList.Add(email, value); (add always goes key then value right)**
                    sortedList[email] = value; //we create a new value for an object that was created (a new key which is the email for the person)(the value is the
                                               //person instance that we created and we are adding to the sorted list)(sorts it in aplphabetical order because its sorted
                                               //could we have also just done list or is that different)(does it have to be sorted list)**
                }
                catch
                {
                    // an exception will be raised if an entry with a duplicate key is added
                    // duplicate key handling (currently ignoring any exceptions) (would it be runtime without the try catch)**
                }
            }
        }
    }

}
