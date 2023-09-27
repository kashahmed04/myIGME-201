using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

/////if we convert and it does not convert does the value get set to null if its in a try catch or does it depend on the data type*****

//everything we can do in a structure, we can do in a class
//structures are kind of like or is it actually object oriented because we can include methods within the structrues like encrypt and decrypt****
namespace MethodsEnumStruct
{
    // enums can be declared in namespace or within class (is there a case where we would define them somewhere else****
    // these enums are accessible to all code in the namespace because we declared it in an outer block so all inner blocks like class and main
    //get access to it****

    // private by default
    enum EGenderPronoun // : int by default
    {
        him,  // 0
        her,
        them
    }

    // can specify public accessibility
    public enum ECollegeYear : byte
    {
        freshman = 27,
        sophomore = 26,
        junior = 25,
        senior = 24
    }

    //strucures are value datatypes and can contain fields,prop.,methods, and sttaic members
    //sttaic members are when we cant change the value by making an object out of the structure and the only way to change it is a method
    // so basically if we want something to stay common within all the instances of the objects we create for a struct we make a static member of the struct**
    //instance mmebers are that we have to change or make equal to a value when we create an instance of that object and we can change it whenver
    // we want by jsut ref. that property within the object (is it called a property)**
    // are properties different in structs and classes.vs.objects (instances of that struct or class)****
    struct StudentStruct //when we create a structure by default it****
                         //when we create an instance of the struct or an object?? then by default it**
    {
        public string sName;
        string password;  // private by default
        public EGenderPronoun eGender;
        public ECollegeYear eCollegeYear;
        public double dGrade;

        static public int enrollment;
        //static varuable that is for the students # of enrollment and applies to all of our students (objects)****
        //we use static when we want to apply it to all members or variables of this data type (the object or the instance or are they the same thing??**
        //(same value for it and we cant change it unless we use a method??)**

        //boolean ovelroaded oeperators can be public or private*****(alwayw have it be static and boolean daattype)****
        //are there other overloaded data types we should know or is bool. the only one**
        //use keyword operator to tell it its an opertator****
        public static bool operator == (StudentStruct left, StudentStruct right)
        {
            return left.Age == right.Age;
        }//we give the para. that are being compred (not the instances but the actual struct so it knows its an instance
         // of the struct** (the two student structs)**** we check if the ages are equal or not and we
         //always have to do the oppsite boolean type or matching
         //set of operators****

        //when would we want to use this and why is it requires for comparison for structs, is it required for any other comparisons like in classes
        //for example**

        public static bool operator !=(StudentStruct left, StudentStruct right)
        {
            return left.Age != right.Age;
        }

        public static bool operator >=(StudentStruct left, StudentStruct right)
        {
            return left.Age >= right.Age;
        }

        public static bool operator <=(StudentStruct left, StudentStruct right)
        {
            return left.Age <= right.Age;
        }

        public static bool operator <(StudentStruct left, StudentStruct right)
        {
            return left.Age < right.Age;
        }

        public static bool operator >(StudentStruct left, StudentStruct right)
        {
            return left.Age > right.Age;
        }
        //alows us to encapsulate and****

        public static void SetEnrollment(int enrollment)//how does this work****
        {
            StudentStruct.enrollment = enrollment;
        }

        //do we usually make our methods as well as the objects or instances of the struct within the struct or is there a case where we would not do that**

        // property = meth-ield
        // student.Password = "password1234";  // this will call Password.set(value = "password1234")
        public string Password  // read-write property with complex get/set methods
        {
            get
            {
                return (Decrypt(this.password));
            }

            set
            {
                this.password = Encrypt(value);
            }
        }

        private string Decrypt(string pw) //how do these work**
        {
            string decryptedValue = "";
            char[] cPassword;

            cPassword = pw.ToCharArray();
            foreach (char c in cPassword)
            {
                decryptedValue += (c + 1);
            }

            return decryptedValue;
        }

        private string Encrypt(string pw)
        {
            string decryptedValue = "";
            char[] cPassword;

            cPassword = pw.ToCharArray();
            foreach (char c in cPassword)
            {
                decryptedValue += (c - 1);
            }

            return decryptedValue;
        }
        //we can make memebers of a structure public so we can access those methods from the outside like this one (we usually want to encapsulate
        //everything invlving a struct like the fields,methods,properties,instances (objects??)** then we could make them public to further use
        //then outside of the code block but within the namespace and different code blocks within the namepscae like main and program**
        public double GivesTest(string subject) //gives a test based on the subject
        {
            switch (subject) //should have the {} on their own like like this when we code
            {
                case "math":
                    break;

            }
            this.dGrade = 100; //dGrade variable is a douvble so we can use it here**
            //this method within the stuedent allows us to act on that variable 
            //we are going to set their grade which is the dGrade towards the top of the program (the field) we set it to the grade
            //they got on their test 
            //when we are acting on fields in structures its a good idea to use the this. keyword within the strucure beause it says we are**
            //chaing this field in the current structure we are working on (we use this.)**
            //but if we are on the outside we have to create a constructor then do the . notiation**
            //this. when within sruct and want to change a field****
            return (100); //score
        }

        // int nAge
        public int Age  // read/write property with only the default get/set methods, so it acts just like an int field
        {
            get; //here since there is no code block we have to define it within our object (or is it an instance)**
            set;
        }

        public double Grade  // read-only property because it only has a get method
        {
            get
            {
                return (this.dGrade);
            }
        }

        public ECollegeYear PCollegeYear  // write-only property because it only has a set method
        {
            set
            {
                this.eCollegeYear = value;
            }
        }


        // int s = studentStruct.SelfRefProperty;
        // AVOID SELF-REFERENTIAL PROPERTIES!!!
        // this will infinitely recurse!
        public int SelfRefProperty
        {
            get
            {
                return (this.SelfRefProperty);
            }

            set
            {
                this.SelfRefProperty = value;
            }
        }


        //constructors dont have a return type****
        //this method returns a student struct*****

       //we can never override default    for strucutres but we can for classes****

        //constructor is the same name as the struct or class (only used within those 2)** then after we make the constructor (the initialization of the values
        //for the object we want to make out of the struct consturctor as shown below here**) 
        //whatever we make the studentstruct call(dataatype) variable eual to in terms of a constructor, it then goes to that constructor and intiailizes the value**

        //objects are the actual strcuture or class itself

        //and instances of objects refer to datatypes rather value of ref. in this case structs are value and classes are ref
        //the object fir  student struct woukd new studentstruct variable = new studentctruct() and if the struct has para. we also
        //put those in as well or do we do that after we create the instance of the object with . notation based on the variable**
        
        //first comes object, then comes constructor, and finally instance of that object with the use of a constructor**
        public StudentStruct(string sName, double dGrade) //we can define our own constructor that takes a string and double and initizilize the things**
            //within the sturcture and we can change the values of the fields of the structure with this object**
            //structures require that we initiialize every field but we dont have to do it with properties because they are code blocks**
            //in c# a code block is anything with the {}
            //but in this case the age does not have any code blocks because the get and set dont have the {} but its the get and set that has to have the code block to see
            //if a property has a code block and if we have to initizlize it or not***
            //we have to initialize everything that does not have a code block in c# for structures and classes and??****
            //why dont we have to intialize properties how would it work then****
            //if we dont initizlaize all fields then we will get a compile time error****(the field must be fully intizilized by the constructor)**
            //strucures have this rule because they are a value data type but for classes we dont need all fields because its a ref. data type**
            //for classes if we dont use all the fields then what is the default value or does it depend on their data type**
            //structures copy the fields into the structure then give them values within that code block only but since its public we can use them anywhere (the object
            ////or the struct, or both)****
            //overloaded means that the method as well as struct and classes and what else**
            //has the same name but the method will be called based on the context for then we create the instance of the object)***
            //if we call strucdent struct with just a string the bottom constructor will be called but if we use a string and a double, this one will be called
            //based on the arguments we put in**
        {   
            this.eCollegeYear = ECollegeYear.freshman;
            this.eGender = EGenderPronoun.them;
            this.sName = sName;
            this.dGrade = dGrade;
            password = "";
            Age = 0;
            // don't have to initialize Properties that have code blocks
        }

        public StudentStruct(string sName)
        {
            this.eCollegeYear = ECollegeYear.freshman;
            this.eGender = EGenderPronoun.them;
            this.sName = sName;
            this.dGrade = 4;
            password = "";
            Age = 0;
        }

    }

    static internal class Program
    {
        // enums can be declared for use within a class as well
        public enum ClassEnum
        {
            IGME_200,
            IGME_201,
            IGME_202
        }

        public struct ZFunction //we could define a structure called 
        {
            public double dX; //all elements of the 3D array (x,y,z)
            public double dY;
            public double dZ;

            public ZFunction(double dX, double dY)  //and we could have a constructure for our funciton and have it inisitlaize our x and y and do the calculation for z
                //when we pass in the dx and dy from****
            {
                this.dX = dX;
                this.dY = dY;
                this.dZ = 2 * Math.Pow(dX, 3) + 3 * Math.Pow(dY, 3) + 6;
                this.dZ = Math.Round(this.dZ, 3);
            }
        }


       
        static void Main(string[] args)
        {
            int i = (int)ConsoleColor.Black;

            {
                StudentStruct student = new StudentStruct();  //the constructor lets us create a new instance of a
                                                              //structre vaurbale like lthis (the instance of the object, and the object
                                                              //itself, structure or class can ref, or value**
                //by default we get a consturctor wuth no para. when we make a structure if we only initialize a sruct instance or****
                //int.,doubles,strings,enums are all objects but, they have a different way the variable behaves (value or ref type) (primitives, int.,doubles,strings)
                //(ref.,array) but eveyrthing is an object in c# thats a ref. or primitive datatype**
                //new keyword creates objects in c# and by default its set to nothing if we only declare (instance of an object or the object itself because isnt the class
                //or the strcut itself the actual object****
                //student varuable is instance of student struct (object)***

                //what we have in our phone is a built in keyboard and its like our phone is a structure and we have a method in our code for keyboard functionality
                //instead of plugging a keyboard in over and over again to access a keyboard*****
                //we should have funcitonality within the strucure and not on the outside so we can pack it as one unit and use it in all of our appliactions more easier
                //rather than having methods on the outside then keep doing stuff with different methods outside the strcuture****


                student.GivesTest("math"); //we can call any public method to act on that structure variable(what does it do)**

                StudentStruct.enrollment = 10000;
                StudentStruct.SetEnrollment(20000);

                //new operator works for arrays
                int[] aInt = new int[23];
                int[] bInt = aInt;  //(2 varibales point to the same block of 23 integers)(b is not a new object, but its pointing at the same object and the block
                //of 23 ints)

                //we can create a variable for an object and an object varabke can point to any varibale at all
                object myObject; //ref. data type
                myObject = aInt; //we can make objects be made into any shape because it can hold any datatype as well as a mix of datatypes***
                myObject = student;
                
                //this is the way we can change the static method??**
                //sttaic variables apply to all instabnces of a structure datatype so we have to define it for all the objects we make out of ut***
                //instance, fields, and methods, we can change like givestest and password, but static methods and varables we cant change***
                //does not matter what order we do for public or static***
                //sttaic memebers are only associated with the data type itself which means****
                //we made our program static class because we want our methods and variables so we dont have to create an instance or object of a****
                student.Password = "pass1234";
                StudentStruct maxStudent = new StudentStruct("Max Lama");
                //we can create a new student structure with the max student with passing in his name and we can also create another one below
                //by usiing his name and grade and the different constructors will be called according to what is put in the arguments****

                //if no para. for a structure constructor then we use . noation but if there is a para. then can we still use .noation and not put it anything in
                //the para. or do we have to still**
                StudentStruct maxGStudent = new StudentStruct("Max Lama", 3.5);
                maxStudent.dGrade = 3.5;
                maxStudent.PCollegeYear = ECollegeYear.senior;
                
                //maxStudent.SelfRefProperty = 42; 
                //if we want to debug properties (in this case the selfrefproperty), then we follow below steps and can step into the get
                //and set now 
                //by default we cant step into get and set so we need to go to debug menue, then options, then in the debug category we
                //go to general dection then there will be a checkbox for the defauly for step over properties and operators so we uncheck that so we can
                //step into instead of step over (do we have to reset it each applicaiton)****
                //it shows we are in an infinite loop when we step in and eventually will get a runtime error whihc will give us a stack overflow****
                //never have property refer to itself otherwise it will be an infinite loop****

                student = maxStudent; //we have overridden the contents for student variable with the contents of maxStudent**
                //the contents of student will contin contents of maxStudent**** differnt from ref. datatype because the student is copying all of the content into it***
                //if we set 1 value data type equal to another in terms of structs it gets overridden on the left*** but if it was ref. it would look
                //in the same place in memeory**

                //classes have all features of a struct but add on even more fucntionality and structures have a subset of the features of a class and everything in a 
                //struct is in a class, but not eveyerthing in a class is in a struct*****



                //delegates are a ref. data type
                //a delegate lets us point to a method but structs is a value daattype that lets us define an entity that can contain different fields and methods and behaviors*****
                //they are very different data types 
                //delegates cant hold data they just point thats why we need variables to hold the inform.**
                //while structs hold all the data in it and when we make an instance of the struct object it copies those**
                //fields and properties into it as we initalize the fields and properties go in themselevs and we dont have to initialize****

                //comparison between structs**** (or objects instances of structs)*****
                if(student < maxStudent) //now we can compre our structs once we do the statements above with the operator****(when can do we usually do that)****
                {
                    //if we put breakpoint in our statment then it goes into the operator in the top we defined if we use the debug settings as described above****
                }

            }

            {
                // 3-d formula example with rectangular array

                // implement the code to calculate: z = 2x ^ 3 + 3y ^ 3 + 6
                // for -4 <= x <= 4 in 0.1 increments: there are 81 values of x
                // for -2 <= y <= 5 in 0.2 increments: there are 36 values of y

                //to figure out how many values are in that range we take ending range minus starting range times the
                ////incremener plus 1 (always)****
                //always add one if its less than or equal to 0 or in the range*****

                double x = 0;
                double y = 0;
                double z = 0;

                int nX = 0;
                int nY = 0;

                // we declare our 3 dimensional array to hold:
                //        81 values of x
                //        36 values of y for each value of x
                //        3 values for each data point: the x, y and z
                //double[,,] zFunc = new double[81, 36, 3];
                ZFunction[] zArray = new ZFunction[81 * 36]; // instead of this comment above we will have a 1 dimension with all of the combinations of x and y (81 *36)
                //then we loop through all of our values of x and round it because*****
                //then loop through our y's for each x then all we need to do is call zFnction and make a new struct for it then after
                //add the values into the array****
                //make structs organized instead of the rectanular array in the above comment 

                int dataPointCntr = 0;

                for (x = -4; x <= 4; x += 0.1, nX++) //how does this work**
                {
                    x = Math.Round(x, 1);

                    // start with the 0'th "y" bucket for this value of x
                    nY = 0;

                    for (y = -2; y <= 5; y += 0.2, ++nY)
                    {
                        y = Math.Round(y, 1);

                        ZFunction thisDataPoint = new ZFunction(x, y);
                        zArray[dataPointCntr++] = thisDataPoint;
                        //why do we incrememnt here wouldnt it not start at the 0th index then**

                        //once we look at our zArray it tels us each of the x and y coord. and structs strucutre our data for us in an organzied way**

                        // zArray[dataPointCntr++] = new ZFunction(x,y);
                        //what does this mean****



                        //why can we make an array out of ZFuntction and do this here as well**
                    }
                }
            }

        }
    }
}
