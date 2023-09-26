using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

/////if we convert and it does not convert does th value get set to null if its in a try catch*******

//everything we can do in a structure, we can do in a class
//structures are ind of object oriented because we can include methods within the structrues like encrypt and decrypt
namespace MethodsEnumStruct
{
    // enums can be declared in namespace or within class
    // these enums are accessible to all code in the namespace

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

    //strucures are value datatypes and can contain filds,prop.,methods, and sttaic members
    //sttaic members are that we have to**
    //instance mmebers are that we have to** 
    struct StudentStruct //when we create a structure by default it****
    {
        public string sName;
        string password;  // private by default
        public EGenderPronoun eGender;
        public ECollegeYear eCollegeYear;
        public double dGrade;

        static public int enrollment;
        //static varuable that is for the students # of enrollment and applies to all of our students (objects)****
        //we use static when we want to apply it to all members or variables of this data type (same value for it and we cant change it)**

        //boolean ovelroaded oeperators can be public or private*****(alwayw hsva eot be static and boolean daattype)****
        //use keyword operator to tell it its an opertator****
        public static bool operator == (StudentStruct left, StudentStruct right)
        {
            return left.Age == right.Age;
        }//we give the para. that are being compred (the two student structs)****we check if the ages are equal or not and we always have to do the oppsite boolean type or matching
         //set of operators****

        public static bool operator !=(StudentStruct left, StudentStruct right)
        {
            return left.Age != right.Age;
        }//we give the para. that are being compred (the two student structs)****we check if the ages are equal or not and we always have to do the oppsite boolean type or matching
         //set of operators****

        public static bool operator >=(StudentStruct left, StudentStruct right)
        {
            return left.Age >= right.Age;
        }//we give the para. that are being compred (the two student structs)****we check if the ages are equal or not and we always have to do the oppsite boolean type or matching
        //set of operators****

        public static bool operator <=(StudentStruct left, StudentStruct right)
        {
            return left.Age <= right.Age;
        }//we give the para. that are being compred (the two student structs)****we check if the ages are equal or not and we always have to do the oppsite boolean type or matching
         //set of operators**** (why woukd we do this)**** when would we want to use this only within stucts****

        public static bool operator <(StudentStruct left, StudentStruct right)
        {
            return left.Age < right.Age;
        }//we give the para. that are being compred (the two student structs)****we check if the ages are equal or not and we always have to do the oppsite boolean type or matching
         //set of operators**** (why woukd we do this)**** when would we want to use this only within stucts****

        public static bool operator >(StudentStruct left, StudentStruct right)
        {
            return left.Age > right.Age;
        }//we give the para. that are being compred (the two student structs)****we check if the ages are equal or not and we always have to do the oppsite boolean type or matching
         //set of operators**** (why woukd we do this)**** when would we want to use this only within stucts****
         //alows us to encapsulate and****

        public static void SetEnrollment(int enrollment)//how does this work****
        {
            StudentStruct.enrollment = enrollment;
        }


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

        private string Decrypt(string pw)
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
        //we can make memebers of a structure public so we can access those methods from the outside like this one
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
            //chaing this field in the current structure we are working on but if we are on the outside we have to create a constructor then do the . notiation**
            //this this. when within sruct and want to change a field****
            return (100); //score
        }

        // int nAge
        public int Age  // read/write property with only the default get/set methods, so it acts just like an int field
        {
            get;
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
        
        public StudentStruct(string sName, double dGrade) //we can define our own constructor that takes a string and double and initizilize the things**
            //within the sturcture and we can change the values of the fields of the structure with this object**
            //structures require that we initiialize every field but we dont have to do it with properties because they are code blocks**
            //in c# a code block is anything with the {}
            //but in this case the age does not have any code blocks because the get and set dont have the {} but its the get and set that has to have the code block to see
            //if a prooerty has a code block and if we have to initizlize it or not***
            //we have to initialize everything that does not have a code block in c# for structures and****
            //why dont we have to intialize properties how would it work then****
            //if we dont initizlaize all fields then we will get a compile time error****(the field must be fully intizilized by the constructor)**
            //strucures have this rule because they are a value data type but for classes we dont need all fields because its a ref. data type**
            //structures copy the fields into the structure then give them values within that code block only but since its ublic we can use them anywhere****
            //overloaded means that the method has the same name but the method will be called based on the context***
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

            public ZFunction(double dX, double dY)  //and we could have to constructure for our funciton and have it inisitlaize our x and y and do the calculation for z
                //when we pass in the dx and dy****
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
                StudentStruct student = new StudentStruct();  //the constructor lets us create a new structre vaurbale like lthis**
                //by default we get a consturctor wuth no para. when we make a structure****
                //int.,doubles,strings,enums are all objects but, they have a different way the variable behaves (value of ref type) (primitives, int.,doubles,strings)
                //(ref.,array) but eveyrthing is an object in c# thats a ref. or primitive datatype**
                //new keyword creates objects in c# and by default its set to nothing if we only declare****
                //student varuable is instance of student struct (object)***

                //what we have in our phone is a built in keyboard and its like our phone is a structure and we have a method in our code for keyboard functionality
                //instead of plugging a keyboard in over and over again to access a keyboard*****
                //we should have funcitonality within the strucure and not on the outside so we can pack it as one unit and use it in all of our appliactions more easier
                //rather than haveing methods on the outside then keep doing stuff with different methods outside the strcuture****


                student.GivesTest("math"); //we can call any public method to act on that structure variable**

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
                //instance fields and methods we can change like givestest and password, but static methods and varable we cant change***
                //does not matter what order we do for public or static***
                //sttaic memebers which are only associated with the data type itself which means****
                //we made our program static class because we want our methods and variables so we dont have to create an instance or object of a****
                student.Password = "pass1234";
                StudentStruct maxStudent = new StudentStruct("Max Lama");
                //we can create a new student structure with the max student with passing in his name and we can also create another one below
                //by usiing his name and grade and the different constructors will be called according to what is put in the arguments****
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
                //if we set 1 values data type equal to another in terms of structs it gets overridden on the left*** what about regular datatypes like ints.****

                //classes have all features of a struct but add on even more fucntionality and structures have a subset of the fatures of a class and everything in a 
                //struct is in a class, but not eveyerthing in a class is in a struct*****



                //delegates are a ref. data type
                //a delegate lets us point to a method but structs is a daattype that lets us define an entity that can contain different fields and methods and behaviors*****
                //they are very different data types 
                //delegates cant hold data they just point thats why we need variables while structs hold all the data in it and when we make an object it copies those
                //fields and properties into it as we initalize the fields and properties go in themselevs and we dont have to initialize****

                //comparison between structs**** (or objects of structs)*****
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

                //to figure out how many values are in that range we take the difference of the ending-start range then (ending range minus starting range times the
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

                for (x = -4; x <= 4; x += 0.1, nX++)
                {
                    x = Math.Round(x, 1);

                    // start with the 0'th "y" bucket for this value of x
                    nY = 0;

                    for (y = -2; y <= 5; y += 0.2, ++nY)
                    {
                        y = Math.Round(y, 1);

                        ZFunction thisDataPoint = new ZFunction(x, y);
                        zArray[dataPointCntr++] = thisDataPoint;

                        //once we look at our zArray it tels us each of the x and y coord. and structs strucutre our data for us in an organzied way**

                        // zArray[dataPointCntr++] = new ZFunction(x,y);
                        //what does this mean****
                    }
                }
            }

        }
    }
}
