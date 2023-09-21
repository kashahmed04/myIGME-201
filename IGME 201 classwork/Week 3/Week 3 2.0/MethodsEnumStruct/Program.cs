using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace MethodsEnumStruct
{
    // enums can be declared in namespace or within class (declare it in a namespace or in a class but not a method)
    // these enums are accessible to all code in the namespace (why because its in a sep. code block)** unless we make it public then we can access it anywhere**
    //even different namespaces**
    //differences between enums and structs and similarities and classes****
    // private by default(only for enums or structs as well)**
    enum EGenderPronoun // : int by default**
    {
        him,  // 0
        her,   
        them
    }
    //enumerates types give us data types that we can read in enlish (human readable), they always break down to just a number (just an index) and they
    //are a list of possible of values, and we can have an enumerated type that contains gender and by default they are stored as integers which means they can hold values
    //minus 2 billion to 2 billio (4 billion values by default) for an int. and we can do other datatype by using a : datatype but it has to be a number and make sure
    //it does not go beyond the data type(for indexes) 

    // can specify public accessibility
    public enum ECollegeYear : byte //we can add the : dataetype exactly like this or can we have no spcaes too 
    {
        freshman = 27, //can override the indexes by putting our values there and we can have 2 values equal to 27
        sophomore = 26,
        junior = 25,
        senior = 24
    }

    //structures are just blocks of data like strings doubles or ints or delegates 
    //and we cant change them like we do with classes 
    struct StudentStruct
    {
        public string sName; //public: field available outside the strucuture or namespcace
        string password;  // private by default and available inside the structure only and if it says private also its only defined within the structure
        //private means its only available within the structure and only availabel within the structure code block (we can ref. it in the property 
        //password because its within the structure
        public EGenderPronoun eGender; //we can use enums in structs and structures can contain any data type within them and even delegate data types
        public ECollegeYear eCollegeYear;
        public double dGrade;
        //the things above here are the fields 

        // property = meth-ield (combination of a method and a field)
        //are structures classes how are they different because structures are value data types and classes are ref. data types 
        // student.Password = "password1234";  // this will call Password.set(value = "password1234") (if we created student variable (a student structure),
        //and we set the password to this password as a string, it will call the set method in the password property and pass whats on the right side of the ewuals
        //sign as this sepecial para. called value (for set we use value so we can set the method)

        //properties can contain up to 2 methods (a get and set method)(a property is like a smart field because it can have code or rules in it)
        public string Password  // read-write property with complex get/set methods
        {
            get
            {
                return (Decrypt(this.password)); //use return with get always because it means return soemthing 
            }

            set
            {
                this.password = Encrypt(value); //we dont have to use this if we have no code blocks  like we did with the age 
            }
        }

        private string Decrypt(string pw) 
        {
            string decryptedValue = "";
            char[] cPassword;

            cPassword = pw.ToCharArray();//what does tochararray do**
            foreach (char c in cPassword)
            {
                decryptedValue += (c + 1); //does it add each element consecutively next to each other or is it actual addition of each elemtn**
            }

            return decryptedValue;
        }

        private string Encrypt(string pw) //what does this do**
        {
            string decryptedValue = ""; //why are we using the decrypted string here**
            char[] cPassword;

            cPassword = pw.ToCharArray();
            foreach (char c in cPassword)
            {
                decryptedValue += (c - 1); //why are we using it here as well because we are encrypting**
            }

            return decryptedValue;
        }

        // int nAge
        //a strcuture could even contain a class and the other way around 
        public int Age  // read/write property with only the default get/set methods, so it acts just like an int field because age is an int
            //properties are pascalcase here but the actual values fields are camelcase
            //enums are pascalcase but the list in the enumerated type can be any case but usually camelcase 
        {
            get; //if we want a property to act just like a field then use the get and set methods
            set;
        } //enums only hold human readable code (list) while structs have properties and fields 
        //the age prop. works like a normal integer field  and we are not doing anything extra but when we add code, then its a property (use pascalcase)

        public double Grade  // read-only property because it only has a get method
        {
            get
            {
                return (this.dGrade); //alawys need a return in the get (always put get and set its not under the good) (we can only get their grade
                //not set it so others cant change it)
            }
        }

        public ECollegeYear PCollegeYear  // write-only property because it only has a set method
            //in which case would we have to have both get and set and when can we only use one of them
            //

        {
            set
            {
                this.eCollegeYear = value; //we can only set it and not allowed to read it but an example would be private information that we can store it but 
                //cant read it because its private and restricts access to data 
            }
        }


        // int s = studentStruct.SelfRefProperty;
        // AVOID SELF-REFERENTIAL PROPERTIES!!!
        // this will infinitely recurse!
        public int SelfRefProperty //when we write code to access this field and when we want to return a value, and if we return itself it will keep going and going
            //and it would be an infinite loop because it refers back to itself 
        {
            get
            {
                return (this.SelfRefProperty); //just use get; so it can return itself 
            }

            set //when we use default get use default set (always) (bohth have to have code blocks or not have code blocks)
            {
                this.SelfRefProperty = value;
            }
        }

        public StudentStruct(string sName, double dGrade) //why can strcutues have para. but enums cant**
        {
            this.eCollegeYear = ECollegeYear.freshman; //are we creating a property for an object in the struct with a this. keyword for the current object
            //then within that we are saying in this enumerator its equal to a freshman
            this.eGender = EGenderPronoun.them;
            this.sName = sName; //a constructor for a strcuture has the same name as the structure and it does not have a return type because**
            //they only have to accessibility level of publix or rpivate then the name of the constructure then the para. we want to define our new constructure variiable**
            this.dGrade = dGrade;
            password = "";
            Age = 0;
            // don't have to initialize Properties that have code blocks (go over these)/
            // are these prop. or constructors**
        }

        public StudentStruct(string sName)//go over**
            //
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
        // enums can be declared for use within a class as well but what about structs**
        public enum ClassEnum
        {
            IGME_200,
            IGME_201,
            IGME_202
        }

        public struct ZFunction //go over all of this**
        {
            public double dX;
            public double dY;
            public double dZ;

            public ZFunction(double dX, double dY) //public what??**
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
                StudentStruct student = new StudentStruct(); //can we mix enums and structs** how**
                student.Password = "pass1234";
                StudentStruct maxStudent = new StudentStruct("Max Lama"); //basically we call the structures and within the () are the values for the 
                //properties we set up and based on which information we put in, it would go to a different strucutre**
                //can we have very similar structures like we can with methods like we did with myAdder**
                StudentStruct maxGStudent = new StudentStruct("Max Lama", 3.5);
                maxStudent.dGrade = 3.5;
                maxStudent.PCollegeYear = ECollegeYear.senior; //we rather create properties by doing . notation in any order or within the ()
                //within the struct declaration in order to the way we defined the properties within the struct**
                maxStudent.SelfRefProperty = 42;

            }

            {
                // 3-d formula example with rectangular array

                // implement the code to calculate: z = 2x ^ 3 + 3y ^ 3 + 6
                // for -4 <= x <= 4 in 0.1 increments: there are 81 values of x (what does this mean**)
                // for -2 <= y <= 5 in 0.2 increments: there are 36 values of y

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
                ZFunction[] zArray = new ZFunction[81 * 36];

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

                        // zArray[dataPointCntr++] = new ZFunction(x,y);
                    }
                }
            }

        }
    }
}
