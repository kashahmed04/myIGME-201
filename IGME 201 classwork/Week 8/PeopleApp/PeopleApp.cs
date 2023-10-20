using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using PeopleLib;
using CourseLib;

//ASK AFTER CLASS TOMORROW**********************************************
//how to know when to use dll and a main file when it does not say
//for PE14 is it reffering to a dll and a main(it will say create a class library)
//for shumul how do we know when to assume a method will be empty or a property for the get and set within the {}(it will be exlpitily said)
//how early can we get started on exam and how to know when to do error checking or create a seperate dll for the classes and when will we know all the content for exam(yes)

//Shapes applciation**

//abstraction is using encapsulation and abstracts the functionality for us so we dont have to know the details of how it works**(phone ex.)*****************

//  if(shape is IDrawOjbect)
//{
//    IDrawOjbect drawOjbect = (IDrawOjbect)shape; //explicitly casting the shape which is a rectangle now to an idrawibject interface(why because its inherited already
//    from the parent)
//}


//copy the.cs file into our folder so we can add an existing item and can only be in the folder*****
//we then add a reference of people lib by adding the reference then after we right click the actual project then add the existing project then we add
//the people lib 
//the project in bold is the run it will run
//we go on solution then dependeices then do people app depends on people lib and people lib takes priority and gets build first
//because people app depends on it and it changes the build order(before what does it usually build if we dont have a dependancy (default))****

//person classes contains student and teachers and a person child that inherits from the parent and it has interfaces as well but the methods should be in the second part**
//the last aprt of the classes usually??**
//the student adds gpa field and the teacher class adds thespeciality field and the children inherit the fields from the parent and the licenseID is a private field but**
//when we use this. to reference it within the parent in the child then it works because it goes back up to the parent and uses the property for it that was defined
//for the private field* (is this how to usually access private fields or can we also use methods)**

//is it necessary to have a constructor or call the base constructor or even use base in classes because in this case we didnt but you said in shape that we had to**
//how big are constructors usually**
namespace PeopleApp
{
    class PeopleApp
    {
        static void Main(string[] args) //people app is the only one that has main so its the only one that runs****
        {
            Courses courses = new Courses(); //we should have 100 classes in there from class1.cs*****

            // create our People SortedList!
            People people = new People();

            // create and initialize our person object (when and why would we want to initialize our instances to null why cant we just say new classname())**
            Person person = null;
            
            string sAction = null;
            while (sAction != "quit")
            {
                Console.WriteLine();

                Console.Write("Add, Edit, Delete, List, Live, Quit => "); //lets us do things to our database (lets us access the dll's??)**
                sAction = Console.ReadLine().ToLower();

                string email = null;

                switch (sAction)
                {
                    case "add": //add people to our data base**
                        person = null;

                        Console.Write("Person type (student/teacher) => "); //add a student or teacher object and we use the parent class as our variable or as our
                        //new person and our parent class is Person (Person people = new Person())*****
                        //we can use a generic person variable to point to our new student or teacher class and gives us access to common things within teacher and whatever
                        //class was chosen**** (what if we wanted to access a students GPA or a teachers speciality)**
                        string sType = Console.ReadLine();

                        // create the person object depending on the type they selected
                        // note that an object of the Person class can point to either a Student or Teacher
                        if (sType.ToLower().StartsWith("s"))
                        {
                            person = new Student();
                        }
                        else
                        {
                            person = new Teacher(); //even if they dont type a t and type some other letter it makes a teacher by default then if its anythign other than s**
                        }

                        // edit the new person
                        EditPerson(ref person); //we want to edit that person in this method (we could eleave out ref and it would work the same)****

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

            //Person persn = new Student();
            //Student a = (Student)persn.Eat(); //why doesnt this cast because I tried to access it but it eas gvng me an error 
        }

        public static void EditPerson(ref Person thisPerson) //passing in the Person as a ref. variable (we dont need ref. because clas variables are ref. types
            //by default but its recommented to make it as explicit as possible*****
            //if we change anything to the variable within the method it will change the variable back in the calling code*****
            //we reference the Person object we created by putting the Person reference in the para.)**
        {
            // for each field, display the current value, if any (basically they see the email that it was set to beofre and they can edit it but if the email was never
            //existing intitally then it does not show up and it just does the => with no space before it??)**
            // only replace the value if a new value was entered

            Console.Write($"Email ({thisPerson.email}) => "); //set their email to what they set it to (in the console how does thisPerson.email show up)**
                                                                //the email can contain anything we want but if its nothing or a bunch of spaces will it just skip it**
            string sEmail = Console.ReadLine();
            if (sEmail.Length > 0)
            {
                thisPerson.email = sEmail;
            }

            Console.Write($"Name ({thisPerson.name}) => "); //set the name to what they said (con contain anything in it as well**
            string sName = Console.ReadLine();
            if (sName.Length > 0)
            {
                thisPerson.name = sName;
            }

            do
            {
                Console.Write($"Age ({thisPerson.age})=> "); //same for age but it needs to be checked if it can be parsed into a number first**
                string sAge = Console.ReadLine();
                if (sAge.Length > 0)
                {
                    if( int.TryParse(sAge, out thisPerson.age ) ) //if the input is entered wrong it breaks regardless (no try catch)**
                                                                  //and it does not keep looping so why would we need a loop**
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
                Console.Write($"Drivers License ID ({thisPerson.LicenseId}) => "); //their drivers license ID which is an integer (was the main reason we needed
                                                                                    //to access (have a) person object was because of the license ID)(is this always true
                                                                                    //or could we also have a child access the property)**
                string sLicenseID = Console.ReadLine();
                if (sLicenseID.Length > 0)
                {
                    int nLicenseId;
                    if ( int.TryParse(sLicenseID, out nLicenseId) )
                    {
                        // note that we cannot pass an operator field to int.TryParse()**
                        // we need to use a temporary int variable to parse into** *why could we just use age but here we cant)**
                        // the LicenseId property applies additional rules to setting the licenseId field
                        thisPerson.LicenseId = nLicenseId; //the license ID 
                        //why cant we just put in this.LicenseID??** do we do this for all private fields or when should we do this**
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
                Student thisStudent = (Student)thisPerson; //to set a more percise to less percise then we have to epxlicitly cast it** (usually the less pericse is parent
                                                           //nd more percise is the child right)****
                //to set student to parent type we set it as a student (we can have parent to child because its more to less generic)
                //and this is only defined in this conditional unless we defined it outside which means then it would be accessible in the whole code block*****

                do
                {
                    Console.Write($"GPA ({thisStudent.gpa})=> "); //we have additinonal field for student which we populate and if they are a student we create a reference
                    //variable to cast the parent as a student** and we create a studetn variable to do it via above and now we can
                    //enter their GPA and if its a teacher then we can access their specicialty field and do that by explicitly csting to a teacher instead**
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

            Console.Write($"Course Code=> ({((Student)thisPerson).courseCodes}) => ");
            string code = Console.ReadLine();
            while(code.Length > 0)
            {
                ((Student)thisPerson).courseCodes.Add(code); //do we have to explicitly cast every single time like this unless we make a variable out of it**
                //is this how we do it**
                Console.Write($"Course Code=> ({((Student)thisPerson).courseCodes}) => "); //I am very confused on steps 7C,7D, and, 7E
                //I tried to implement as best as I could but I was just so confused I did not know what to do......
                code = Console.ReadLine();
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
            IPerson iPerson = (IPerson)obj;  //cast this because parent does not see interface but children do**

            // declare IStudent interface reference variable
            // initialize to null because we do not know if obj is Student or Teacher
            IStudent iStudent = null;

            // notice how we can use the IPerson interface to call Eat() for both Student and Teacher
            // because that method is defined in the shared interface
            iPerson.Eat();

            // notice how we can use a Person reference to call Work()
            // because the virtual method is defined in the shared Person class**
            // even though the method implementation is different between the 2 classes**
            //it calls the correct one based on whatever class is passed in since its shared with the parent**
            //and for student it calls the default one in parent because it does not have the override method in it**
            person.Work(); //cals the one in parent instead because we ref. the parent so if a student or teacher is called it uses the parent here (work work work work)**

            // but because Party() is only a member of Student
            // as a result of inheriting IStudent
            // we need to ensure obj is a Student
            //what is obj. here**
            if( obj.GetType() == typeof(Student)) //if a student object is put in, we check if they are indeed a student then we cast iStudent**
                //to the person object we passed in (in this case it was set to the parent) and set that variable equal to that then cal the party method**
                //we need to cast because it was a person variable which only holds the parent**
            {
                // we use an IStudent reference to call Party()
                iStudent = (IStudent)person; //have to cast it since person does not see interface only child does (how can it see its type of student when its the parent
                                             //and it can only see specific thingd whereas "is" is similar so shouldnt we use "is"**
                iStudent.Party(); //call the party for the student**
            }
        }
    }

}