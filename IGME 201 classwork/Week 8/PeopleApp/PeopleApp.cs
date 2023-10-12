using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using PeopleLib;

//copy the.cs file into our folder so we can add an existing item and can only be in the folder*****
//we then add a reference of people lib by adding the reference then after we right click the actual project then add the existing project then we add
//the people lib 
//the project in bold is the run it will run****
//we go on solution then dependeices then do people app depends on people lib and people lib takes priority and gets build first
//because people app depends on it and it changes the build order****

//person classes contains student and teachers and person child that inherits from the parent and it has interfaces as well but the methods should be in the second part
//the student adds gpa field and the teacher class adds thespeciality field and the children inherit the fields from the parent and the licenseID is a private field but**** 
//public constructor is available*****

namespace PeopleApp
{
    class PeopleApp
    {
        static void Main(string[] args) //people app is the only one that has main so its the only one that runs****
        {
            Courses courses = new Courses(); //we should have 100 classes in there*****

            // create our People SortedList!
            People people = new People();

            // create and initialize our person object
            Person person = null;
            
            string sAction = null;
            while (sAction != "quit")
            {
                Console.WriteLine();

                Console.Write("Add, Edit, Delete, List, Live, Quit => "); //lets us do things to our database 
                sAction = Console.ReadLine().ToLower();

                string email = null;

                switch (sAction)
                {
                    case "add": //add people to our data base**
                        person = null;

                        Console.Write("Person type (student/teacher) => "); //add a student or teacher object and we use the parent class as our variable or as our
                        //new person and our parent class is Person (Person people = new People())*****
                        //we can use a generic person variable to point to our new student or teacher class and gives us access to common things within teacher and whatever
                        //class was chosen****
                        string sType = Console.ReadLine();

                        // create the person object depending on the type they selected
                        // note that an object of the Person class can point to either a Student or Teacher
                        if (sType.ToLower().StartsWith("s"))
                        {
                            person = new Student();
                        }
                        else
                        {
                            person = new Teacher();
                        }

                        // edit the new person
                        EditPerson(ref person); //we want to edit that person in this method (we could eleave out ref and it would work the same****

                        // add the new person to the SortedList array using the email as index
                        // note that this uses the index property in the class which does additional exception handling
                        // to catch the case of a duplicated email index
                        people[person.email] = person;

                        // we could have done
                        //       people.sortedList.Add(email, person);
                        // but then we would need to add the exception handling here

                        break;

                    case "edit": //we can edit a person by putting in their email which is the indexer below**** 
                        Console.Write("Email of person to edit => ");
                        email = Console.ReadLine();

                        person = people[email]; //using the indexer property to fetch the person object from the People class object (instance)****

                        // if this email was not found in the list, the get property operator returns null
                        // note that because we overloaded the == operator, 
                        // we need to cast null as (object) to ensure that the signature does not match the existing overload
                        // otherwise it tries to treat null as a Person and raises an exception trying to access null.age
                        // test it yourself without the (object) cast!
                        if (person == (object)null) //if person = null and if we say just null then it calls the overloaded operator in our person class and it will
                                                    ////try to say if person (p1 in our overload and compares to p2 for age) and p2 would be passed as null
                                                    //this results in a runtime exception because it runs to boolean over load for ==
                                                    //and there is no null.age for p2)(to fix that we need to cast the null as an object type which causes 
                                                    //it to not match the method signature of our boolean operator (person on the left side then object on the left side
                                                    //so it does not match method signature for the boolean overloaded method)*****
                        {
                            Console.WriteLine("That email does not exist."); //if its null email does not exist
                        }
                        else
                        {
                            // because there cannot be duplicates in the Sorted List
                            // remove the existing entry from the list
                            people.Remove(email); //if its valid then we remove the existing item within the email before we edit then readd it to the sorted list because****

                            // edit the selected person
                            EditPerson(ref person);

                            // re-add the updated person to the list
                            people[person.email] = person; //we add the edited person into the sorted list**
                        }
                        break;

                    case "delete": //we can delete a person****
                        Console.Write("Email of person to delete => ");
                        email = Console.ReadLine();

                        people.Remove(email);

                        break;

                    case "list": //we can read through the list of out people with all of their prop****
                        int i = 0;

                        // list each person in the collection
                        // iterating through a Sorted List uses a special type called KeyValuePair
                        // each list entry has a Key and a Value
                        foreach (KeyValuePair<string,Person> thisEntry in people.sortedList)
                        {
                            // thisEntry.Key contains the email index
                            // and thisEntry.Value contains the Person object
                            // declare a Person reference variable to access all of the common fields of the derived classes
                            Person thisPerson = (Person)thisEntry.Value;

                            Console.Write($"{i + 1}: {thisPerson.email} | {thisPerson.name} | {thisPerson.age} | {thisPerson.LicenseId} | ");

                            if (thisPerson.GetType() == typeof(Student))
                            {
                                // gpa only belongs to Student, so we need a Student reference variable to output that
                                Student student = (Student)thisPerson;
                                Console.WriteLine($"{student.gpa}");
                            }

                            if (thisPerson.GetType() == typeof(Teacher))
                            {
                                // specialty only belongs to Teacher, so we need a Teacher reference variable to output that
                                Teacher teacher = (Teacher)thisPerson;
                                Console.WriteLine($"{teacher.specialty}");
                            }
                            ++i;
                        }

                        break;

                    case "live": //how long they will live****
                        Console.Write("Email of person to live for a day => ");
                        email = Console.ReadLine();

                        person = people[email];

                        if (person != (object)null)
                        {
                            LiveADay(person);
                        }
                        break;
                }
            }
        }

        public static void EditPerson(ref Person thisPerson) //passing in the Person as a ref. variable (we dont need ref. because clas variables are ref. types
            //by default but its recommented to make it as explicit as possible*****
            //if we change anything to the variable within the method it will change the variable back in the calling code*****
        {
            // for each field, display the current value, if any
            // only replace the value if a new value was entered

            Console.Write($"Email ({thisPerson.email}) => "); //set their email to what they set it to****
            string sEmail = Console.ReadLine();
            if (sEmail.Length > 0)
            {
                thisPerson.email = sEmail;
            }

            Console.Write($"Name ({thisPerson.name}) => "); //set the name to what they said****
            string sName = Console.ReadLine();
            if (sName.Length > 0)
            {
                thisPerson.name = sName;
            }

            do
            {
                Console.Write($"Age ({thisPerson.age})=> "); //same for age***
                string sAge = Console.ReadLine();
                if (sAge.Length > 0)
                {
                    if( int.TryParse(sAge, out thisPerson.age ) )
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            } while (true);

            do
            {
                Console.Write($"Drivers License ID ({thisPerson.LicenseId}) => "); //their drivers license ID which is an integer****
                string sLicenseID = Console.ReadLine();
                if (sLicenseID.Length > 0)
                {
                    int nLicenseId;
                    if ( int.TryParse(sLicenseID, out nLicenseId) )
                    {
                        // note that we cannot pass an operator field to int.TryParse()
                        // we need to use a temporary int variable to parse into
                        // the LicenseId property applies additional rules to setting the licenseId field
                        thisPerson.LicenseId = nLicenseId; //the license ID 
                        //we need to use an int. for try parse because it expects a variable and it expects and int. and we cant pass in thisPerson.LicenseID****
                        break;
                    }
                }
                else
                {
                    break;
                }
            } while (true);

            if (thisPerson.GetType() == typeof(Student))
            {
                Student thisStudent = (Student)thisPerson; //to set a more percise to less percise then we have to epxlicitly cast it****
                //to set student to parent type we set it as a student (we can have parent to child because its more to less generic)*****

                do
                {
                    Console.Write($"GPA ({thisStudent.gpa})=> "); //we have additinonal field for student which we populate and if they are a student we create a reference
                    //variable to cast them as a student and we create a studetn variable to do it via above and now we can
                    //enter their GPA and if its a teacher then we can access their specicialty field and do that 
                    string sGPA = Console.ReadLine();
                    if (sGPA.Length > 0)
                    {
                        if( double.TryParse(sGPA, out thisStudent.gpa ) )
                        {
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                } while (true);
            }

            if (thisPerson.GetType() == typeof(Teacher))
            {
                Teacher thisTeacher = (Teacher)thisPerson;

                Console.Write($"Specialty ({thisTeacher.specialty})=> ");
                string sSpecialty = Console.ReadLine();
                if (sSpecialty.Length > 0)
                {
                    thisTeacher.specialty = sSpecialty;
                }
            }
        }

        public static void LiveADay( object obj ) //pass in the person as an object and the object is the great great grandparent of every data type in c# and can use it always
                            //to ref. a variable then we can cast the object back to the specific reference types as we need them*****
        {
            // declare Person class reference variable
            Person person = (Person)obj; //since we are going to less specific to more specific then*****
            //how does thie woerk****

            // declare IPerson interface reference variable
            IPerson iPerson = (IPerson)obj; 

            // declare IStudent interface reference variable
            // initialize to null because we do not know if obj is Student or Teacher
            IStudent iStudent = null;

            // notice how we can use the IPerson interface to call Eat() for both Student and Teacher
            // because that method is defined in the shared interface
            iPerson.Eat();

            // notice how we can use a Person reference to call Work()
            // because the virtual method is defined in the shared Person class
            // even though the method implementation is different between the 2 classes
            person.Work();

            // but because Party() is only a member of Student
            // as a result of inheriting IStudent
            // we need to ensure obj is a Student
            if( obj.GetType() == typeof(Student))
            {
                // we use an IStudent reference to call Party()
                iStudent = (IStudent)person;
                iStudent.Party();
            }
        }
    }

}