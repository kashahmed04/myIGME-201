using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

/////if we convert and it does not convert does the value get set to null if its in a try catch or does it depend on the data type
///its whatever the variable was before it tried to parse it if the parse does not work

//everything we can do in a structure, we can do in a class
//structures are kind of like object oriented but are not object oriented (does not support OOP)(like inheritence etc.)
//(classes are object oriented and encapsulate functionality
//into one space for objects)(and structtures are objects but they are
//value types) because we can include methods within the structrues like encrypt and decrypt

//classes allow us to reuse different types of code/methods and structs can too but its by value
//classes inherit from each other  (super to inherit from the parent within the child)
//if we have class called shape, circles,triangles,andsqiares, can access the shape class from super
//and we can share the methods like a method from the shape class into the circles,triangles,etc. to be used 
//general class for all shared prop. and the child class we would have to call a specific formula based on the methods in the parent class
//and it will use the correct method based on the class we are accessing 
//we can basically write the same code to write the area of any shape because the code will know autoatmically which method to call because it knows
//what the child class is (will call the appropriate child method if we have it in the child otherwise it calls the parent)
//since the formula is different for each class, in the shape class the parent shape class has a method to calculate the area and each of the child classes
//will tell us how to calculate it but the main shape class we have access to that method 
//the child class with the circle will inherit an area method and we can calculate the area for that specific shape and in the parent we can have a default area 
//put in that method and in the child we can ovwer ride it within the child and make a new one for the child or we can make it empty in the parent and make it
//an abstract method whihc means its just a placeholder (empty method) and the child needs to provide the actual formula
//if the child does not implement its own version of the method then it will use the parents version
namespace MethodsEnumStruct
{
    // enums can be declared in namespace or within class 
    // these enums are accessible to all code in the namespace because we declared it in an outer block so all inner blocks like class and main
    //get access to it
    //if we have a public within the internal class program and want to access the public within another code block above the public then we can do
    //Program.ClassEnum eClass; to access the classEnum enum
    //but if it was private we would not 
    //we would say eclass = Program.ClassEnum.IGME_201; to access to it via the variable 

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
    //sttaic members are when we cant change the value by making an object out of the structure and the only way to change it is a method or incremement via calling the
    //StudentStruct or whatever datatype we decalred . the field and change it that way
    // so basically if we want something to stay common within all the instances of the objects we create for a struct we make a static member of the struct
    //instance mmebers are that we have to change or make equal to a value when we create an instance of that object and now we can access the fields from
    //the constructors and not the struct down here because its the datatype (depends on the signature for whatever constructor it needs to go into)
    //and if we want custom information we could just make a new instance of the object and use the . notation after the object ref. (new) and put our own values within those 
    //fields 
    
    //for the studentstruct we created a datatype a template a design basically for doing something but we did not create an object and we create an object with the new
    //keyword
    //we initialize different fields in the constructor and if we wanted to do something special we set some special things within the constructor
    //the constructor allows us to wirte code that will be used everytime we create a new student based on which para. we put in 
    //if we did not create a consturctor then we have to initialize with . notation for each field within the struct when we create an instance of the object 
    //we created the data type here of the struct and we have given it their own name and we make prop. and fields here and within the constructor we initialize these
    //fields and construcotrs have the same name as the struct always 

    //for sttaic member its shared among all of the instances of the structure that we have 
    //any static varibale always instizalizes to its default value and for an int its 0 unless we set seomthing equal to it
    //to access enrollment we need to use the daat type itself to access it 
    //in our constructors we can increment the enrollment of a student but always access the static with the structname then . enollment 
    //same if we want to access static methods that the strucure gives us
    struct StudentStruct //when we create a structure by default it sets its members to their default values like all the numeric values to 0 and all the strings
                            //to empty strings (when we use default constructor)(or we could initizliaze like we do with constructors)
                    
    {
        public string sName; //if we make a blank object instance then the shoebox has all of these fields in it (makes a copy) and fills in each type we set equal to 
        string password;  // private by default
        public EGenderPronoun eGender;
        public ECollegeYear eCollegeYear;
        public double dGrade;

        static public int enrollment;
        //static varuable that is for the students # of enrollment and applies to all of our students (instance of object)
        //we use static when we want to apply it to all members or variables of this data type
        //(same value for it and we cant change it unless we use a method or we can change it by accessing the studentstruct.enrollment (always))

        //boolean ovelroaded oeperators have to be public (alwayw have it be static and boolean daattype)
        //we cant make private boolean operators 
        //overloaded are specifcally called boolean overloaded and they are used to see if they are equal to or not equal to each other,etc.
        //and put the matching boolean overload methods so it works even though we need to only use 1 and if we never use it then have it do the same thing and be sure
        //to document it (make it equal to false or something because its never used)
        //we usually write these in structs or classes so we can use it when we create the instance of the object (only used for comparing our structures or classes)
        //use keyword operator to tell it its an opertator (always)(we have to define to have comparison of the datatype so it knows which is it when doing comparison of
        // instances of objects)
        //they are both the types of strudent struct so thats why we can use it with the instance of the struct

        //and when we create the method we dont need to put anything in it because these operators do it and its called by value so it would make a copy
        //and not change anything we pass in and only make a copy and use that

        //we can use the .notation with the instance of the object so compare or have the operator without the . noation if its an overloaded operator

        //we have to say static in our boolean operators because its a method 

        //it does not access the this keyword and its passing the left and the right side and if we change anything within these operators then it wont change
        //the actual instance because it makes a copy (not by ref.) (copies everything out of thr student into the variable called left)(every field)(evyer property as well)
        //everything in the structure basically
        public static bool operator == (StudentStruct left, StudentStruct right)
        {
            return left.Age == right.Age;
        }

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

        public static void SetEnrollment(int enrollment)//we could have a ststic feidl called enrollment and a static method called setenrollment
            //and have our sttaic method change our static field (the method does not have to be static but the enrollment variable does)
            //we cant change enrollment so we make it static and we can only change it with the studentstruct (the student struct itself)
            //static does not allow us to call instances of our structure but if we want to change the instance of the structure, we have to put the instance within the para.
            //with ref. (basically static only takes in value types and if we want to have objects like structs and classes we have to put them in the para. 
            //within the static methods and put ref. to change it so it does not make a copy)
            //if we did not do it by ref., we only changed the copy of the struct and only exsts within the code block 
        {
            StudentStruct.enrollment = enrollment; //availabel everywhere we have access to student struct (in the namespace) because we used studentstruct itself 
            //which we defined in the namespace
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

        private string Decrypt(string pw) //how do these work
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
        //everything invlving a struct like the fields,methods,properties,instances and the object itself (the struct)(the datattype of the struct is the
        //name we give it and the category of the datatype is the definer like struct or enum) then we could make them public to further use
        //them outside of the code block but within the namespace and different code blocks within the namepscae like main and program
        
        //an object is any instance of a data type (the caterogies of the data types or int. and enum and structs, etc.)
        //the object would be when we create a variable of that type (ex. how we create the dGrade of the object data type and object and instance are interchangeable) 
        //instance fields are availabel when we change it in the instance of the object and the static is a just a field that does not have to get initialized
        //methods that are not static are instance methods and can only be called using the instance of the structure like instance fields (same for fields) 
        //if it does not have static then its an instance member 

        //memebers of the sturcts can be instance fields, moethds,properties, and static fields,moethdos,and prop.
        //and constructors 


        //instance member then must create an object of that data type 
        //but if its static then we access it not by an instance but the datatype itself(StudentStruct) 
        public double GivesTest(string subject) //gives a test based on the subject
        {
            switch (subject) //should have the {} on their own like like this when we code
            {
                case "math":
                    break;

            }
            this.dGrade = 100; //dGrade variable is a douvble so we can use it here
            //this method within the stuedent allows us to act on that variable 
            //we are going to set their grade which is the dGrade towards the top of the program (the field) we set it to the grade
            //they got on their test 
            //when we are acting on fields in structures its a good idea to use the this. keyword within the strucure beause it says we are
            //chaing this field in the current structure we are working on (we use this.)
            //but if we are on the outside we have to create a constructor then do the . notiation
            //this. when within sruct and want to change a field
            return (100); //score
        }

        // int nAge
        public int Age  // read/write property with only the default get/set methods, so it acts just like an int field
        {
            get; //here since there is no code block we have to define it within our instance
            //its a prop because it has get and set 
            //its an instance member because it does not have statuc so we have to initizlaize wihtin the instance of the objecy always 
            set;
        }

        public double Grade  // read-only property because it only has a get method
        {
            get
            {
                return (this.dGrade); //always have return with get 
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


        //constructors dont have a return type (yes)

        //we can never create a default constructor with no para. public studentstruct(){} and wanted to set the fields we could not for strucutres but we can for classes (make 
        //a default constrcutor)
        public StudentStruct(string sName, double dGrade) //we can define our own constructor that takes a string and double and initizilize the things
            //within the sturcture and we can change the values of the fields of the structure with this object (makes a copy though)
            //structures require that we initiialize every field but we dont have to do it with properties because they are code blocks
            //in c# a code block is anything with the {}
            //but in this case the age does not have any code blocks because the get and set dont have the {} but its the get and set that has to have the code block to see
            //we have to initialize everything that does not have a code block in c# for structures but not classes 
            //if we dont initizlaize all fields then we will get a compile time error(the field must be fully intizilized by the constructor)
            //strucures have this rule because they are a value data type but for classes we dont need all fields because its a ref. data type 
            //if its an instance type and its a code block, then we dont have to intialize
            //constructors has the same name but the method will be called based on the context for then we create the instance of the object)
            //if we call strucdent struct with just a string the bottom constructor will be called but if we use a string and a double, this one will be called
            //based on the arguments we put in
        {   
            this.eCollegeYear = ECollegeYear.freshman; //instance methods and fields and properties
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

        public struct ZFunction //we could define a structure called zfunction
        {
            public double dX; //all elements of the 3D array (x,y,z)
            public double dY;//structure that holds our x,y,z value 
            public double dZ;

            public ZFunction(double dX, double dY)  //and we could have a constructure for our funciton and have it inisitlaize our x and y and do the calculation for z
     

                //each data point is a strucure that holds each value of xyz and the constrotor stores the current value x y and calc. of z and put it in constructor
                //and each time we create a new structure for the data point (array of structures)


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
                StudentStruct student = new StudentStruct(); //instance of the object

                //what we have in our phone is a built in keyboard and its like our phone is a structure and we have a method in our code for keyboard functionality
                //instead of plugging a keyboard in over and over again to access a keyboard
                //we should have funcitonality within the strucure and not on the outside so we can pack it as one unit and use it in all of our appliactions more easier
                //rather than having methods on the outside then keep doing stuff with different methods outside the strcuture


                student.GivesTest("math"); //we can call any public method to act on that structure variable(what does it do)(gives the student the grade)

                StudentStruct.enrollment = 10000;
                StudentStruct.SetEnrollment(20000);

                //new operator works for arrays
                int[] aInt = new int[23];
                int[] bInt = aInt;  //(2 varibales point to the same block of 23 integers)(b is not a new object, but its pointing at the same object and the block
                //of 23 ints)

                //we can create a variable for an object and an object varabke can point to any varibale at all
                object myObject; //ref. data type
                myObject = aInt; //we can make objects be made into any shape because it can hold any datatype as well as a mix of datatypes if it was an array or a list
                myObject = student;
                
              
                //sttaic memebers are only associated with the data type itself which means whatever datatype it is we cant change it but we can change its value any time
                ////but the data type has to be the same 
               
                student.Password = "pass1234"; //an instance field (does not have anything in it until we initilzie)
                StudentStruct maxStudent = new StudentStruct("Max Lama");
                //we can create a new student structure with the max student with passing in his name and we can also create another one below
                //by usiing his name and grade and the different constructors will be called according to what is put in the arguments

                //if no para. (default struct) for a structure constructor then we use . noation but if there is a para. then can we still use .noation and not put it anything in
                //the para. or do we have to still
                StudentStruct maxGStudent = new StudentStruct("Max Lama", 3.5);
                maxStudent.dGrade = 3.5;
                maxStudent.PCollegeYear = ECollegeYear.senior;
                
                //maxStudent.SelfRefProperty = 42; 
                //if we want to debug properties (in this case the selfrefproperty), then we follow below steps and can step into the get
                //and set now 
                //by default we cant step into get and set so we need to go to debug menue, then options, then in the debug category we
                //go to general dection then there will be a checkbox for the defauly for step over properties and operators so we uncheck that so we can
                //step into instead of step over (do we have to reset it each applicaiton)(only change it once)
                //it shows we are in an infinite loop when we step in and eventually will get a runtime error whihc will give us a stack overflow
                //never have property refer to itself otherwise it will be an infinite loop

                student = maxStudent; //we have overridden the contents for student variable with the contents of maxStudent
                //the contents of student will contin contents of maxStudent differnt from ref. datatype because the student is copying all of the content into it
                //if we set 1 value data type equal to another in terms of structs it gets overridden on the left but if it was ref. it would look
                //in the same place in memeory

                //the value data type takes all of the fields,moethods,prop.,etc from
                //maxstudent and copies them into student and the stuff in original student is gone (identical copy of maxSudent now)

                //if it was an object we would lose the student object and the maxstudent and student points at maxstudent (the same object)

                //classes have all features of a struct but add on even more fucntionality and structures have a subset of the features of a class and everything in a 
                //struct is in a class, but not eveyerthing in a class is in a struct



                //delegates are a ref. data type
                //a delegate lets us point to a method but structs is a value daattype that lets us define an entity that can contain different fields and methods and behaviors
                //they are very different data types 
                //delegates cant hold data they just point thats why we need variables to hold the inform.
                //while structs hold all the data in it and when we make an instance of the struct object it copies those
                //fields and properties into it as we initalize 

              
                if(student < maxStudent) //now we can compre our structs once we do the statements above with the operator
                {
                    //if we put breakpoint in our statment then it goes into the operator in the top we defined if we use the debug settings as described above
                }

            }

            {
                // 3-d formula example with rectangular array

                // implement the code to calculate: z = 2x ^ 3 + 3y ^ 3 + 6
                // for -4 <= x <= 4 in 0.1 increments: there are 81 values of x
                // for -2 <= y <= 5 in 0.2 increments: there are 36 values of y

                //to figure out how many values are in that range we take ending range minus starting range divided the
                ////incremener plus 1 (always)
                //always add one if its less than or equal to 0 or in the range

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
               


                //create an array of structures and our zFunction structure (variable equal to the data type) and we do 81*36 x and y values 
                //Zfucntion is the datatype we created
                //same loops from before here now we need to keep track of the array element we are on (the int in the begging before the loop)
                //the int in the beginning is the current index we are on
                //for each value of x and y we create a new structure thne pass in the x and y after the new statement and it cals the constucture
                //and it calculates z and stores the x and y in then we just store the strucure we just made into our array at the current index 
                //and we do the ++ to go onto the next index

                //zfunctuon is a strucure that has the 3 doubkes for xyz and each time we create the structure it can hold the dx dy and dz which is the current
                //xyz and we calculate z from the constructor for our structure and we use the instance type with this. to put in the values witihn the fields
                //made a copy so the points get stored for each element in the array 

                //every time we say new it goes back up to the consturcure Zfunction because we put x and y in there 



                

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
                        //ZFunction is the datatype that we define with this variable then every time we say new it makes a copy of the struct with the current 
                        //x,y,z values, then stores it into the array in the next line
                    

                        // zArray[dataPointCntr++] = new ZFunction(x,y); //these 3 lines could be written as this one line 
                        //zArray is defined above just do new operator heere and do the new structure for that array elemtn 
                        //zarray already is a zfunction type thats why this works

                        //just write the 3 lines above (perrferred)
                        
                    }
                }
            }

        }
    }
}
