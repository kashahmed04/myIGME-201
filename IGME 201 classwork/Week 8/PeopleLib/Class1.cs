using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * each source file (each class source file should contain only one class but if the classes are really tiny like PE11 its ok to have multiplt classes in one file)
 * If we need more class files we right click on the project then add an existing item, new item, or class which means******(
 */
namespace People.Lib
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}

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
            get;
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
        public DateTime dateOfBirth;

        private int licenseId;

        public int LicenseId
        {
            get
            {
                // get will simply return licenseId but it can do any logic
                return licenseId;
            }

            set
            {
                // we will only set the licenseId if the person is older than 16
                if (age > 16)
                {
                    licenseId = value;
                }
            }
        }

        public static bool operator <(Person p1, Person p2)
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

        public static bool operator <(Student s1, Student s2)
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
            Console.WriteLine("Order a pizza!");
        }

        public void Party()
        {
            Console.WriteLine("Party on dude");
        }

    }

    //for the license ID the field is available within the class its defined in but the property is inherited because its not private 
    //we can over ride how classes are compared by using boolean overloaded methods and it uses the Person class to compare and
    //when we compare 2 person objects it uses their age to compare them but in the student definition it only takes the Student objects and compares them by their GPA'S****

    //the teacher over rides to work method and talks all about their speciciality and has a list of courses they teach*****

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

    // [+People|sortedList:SortedList<string, Person>|this:email|+Remove(email: string)]
    public class People
    {
        // the generic SortedList class uses a template <> to store indexed data
        // the first type is the data type to index on
        // the second type is the data type to store in the list
        // create a Sorted List indexed on email (string) and storing Person objects
        public SortedList<string, Person> sortedList = new SortedList<string, Person>();

        public void Remove(string email)
        {
            if (email != null)
            {
                sortedList.Remove(email); //if they pass a valid email then******
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
        public Person this[string email] //the indexer property is defined as having a return type and it returns a person objtec and we use the this keyword
                                         //and like an array we put the value we are indexing on in the [] brackets 
                                         //when we create a people object we can access their email by using people[email]
                                         //is the this[] usually used with properties or*****
                                         //its a property that has get and set methods and it has the square bracket and it uses the this keyword so now we can
                                         //access our class instance and index our class instance to access their specific email (key) within the list to get their
                                         //certain instance****
                                         //each entry in our list is a person object and reading the objtec out of our sorted list based on the email which was
                                         //the key****

        //we are getting a person instance and setting a person instance for the email which is the key*****
        //to access we can just do people[email] (get)
        //but to set we do people[email] = person; (value is the variable is on right of equal sign which is the person instance****

        //people[email] = person; is what gets put into this[string email] and gets used in the property****
        //rrturn val is basically the object that was taken based on the email****

        //now we create this into a dll by doing build but its bettwr to do rebuild so it does it all knew and we know it has built*****
        //we would want to rebuild the whole solutino if we have many projects in our solution and we changed a lot of files and we want to make sure everything is up to 
        //date (even with source files it will update if there are multiple files in one application or dll)****
        {
            get
            {
                Person returnVal; //returns a person objtec and we put it in a try catch because we dont want our program to crash if the email
                                  //is not in the sorted list****
                                  //when we try to read a value that does not exist(the key) it returns a run time error****
                try
                {
                    returnVal = (Person)sortedList[email]; //reads the email out of the Person sorted list ****
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
                    //      sortedList.Add(email, value);
                    sortedList[email] = value; //we create a new value for an object that was created (a new key which is the email for the person)(the value is the
                                               //person instance and the key is the email and we are adding to the sorted list*****
                }
                catch
                {
                    // an exception will be raised if an entry with a duplicate key is added
                    // duplicate key handling (currently ignoring any exceptions)
                }
            }
        }
    }

}
