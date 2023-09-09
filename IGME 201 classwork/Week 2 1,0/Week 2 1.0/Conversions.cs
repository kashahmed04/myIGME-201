using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_2_1._0
{
    static internal partial class Program
    {

        //when we call methods they are specific to the datatypes being passed into them
        //whenever we call myAdder, depending on what we put in as an argument it will go to the right version we made
        static double myAdder(double a, double b)
        {
            return 1;
        }

        static int myAdder(int a, int b)
        {
            return 1;
        }
        static void Main(string[] args)
        {
            //go over implicit and explicit casting**
            //theres a math static class which has all our math operations in it plus conversions**
            //which conversions do we have to worry about**
            // we will use double for all of our floating point numbers
            // because that is the type used by most of the Math functions
            // but because it is base-2, it is prone to rounding errors
            double doubleNum = 9999.999;

            float floatNum = 999.9F;

            // decimal uses base 10 arithmetic but is not widely supported by the Math functions
            decimal decimalNum = 1234.5678M;

            long longInt = -12345678;   // Int64 (64-bit)
            ulong ulongInt = 12345678;  // UInt64
            int intNum = -786;          // Int32
            uint uintNum = 786;         // UInt32
            short shortInt = -789;      // Int16
            ushort ushortInt = 456;     // UInt16
            byte byteNum = 254;         // 8-bit unsigned //how to know which one to use the unsigned or signed** (unsigned means we cant store negatives there right)**
                                        //but we can in signed**
            sbyte sbyteNum = -123;      // 8-bit signed

            string myString;
            bool myBool;

            //when we create our own data types, its usually pascal case 
            // you can implicitly set a data type equal to a less precise type
            longInt = shortInt;  // 16 bits can be copied into 64 bits
            uintNum = byteNum;   // 8 bits can be copied into 32 bits

            // you cannot implicitly set a data type equal to a more precise type
            //byteNum = shortInt;  // 16 bits cannot implicitly be copied into 8 bits

            // but you can explicit cast 16 bits as 8 bits 
            // this will only copy the lower 8 bits of shortInt
            // so data may be lost without your knowing it
            byteNum = (byte)shortInt;

            try //need this try catch or the program will crash and if we convert less to more percise then it would crash if the data type would not fit**
                //usually use try catch when converting**
                //if we explicitly do it though like above, then it wont crash and we wont need try catch, but we would lose data (logic error)**
                //run time error without the try catch**
            {
                // checked() and Convert will raise an exception if data will be lost(true or false)**  (need this and the conversion in try)**
                byteNum = checked((byte)shortInt);

                // we saw Convert.ToInt32(), there are conversions for all data types!**
                // convert the shortInt to a byte
                byteNum = Convert.ToByte(shortInt);

                //convert class, parse(only works if we are converting from a string to the data type we want), as well as try parse is used to convert in c#
                byteNum = byte.Parse(shortInt.ToString()); //we would need to convert our things into. strings to use parse if they are not strings (parse only works on strings)

                bool bValid = byte.TryParse(shortInt.ToString(), out byteNum); //even with tryparse we need to convert to a string if its not a string to convert
                //data types (parse means to take string and convert to another data type)

                

            }
            catch
            {
                // output message that data will be lost
                Console.WriteLine("Data was lost!");
            }

            //int/int = int (even though we stores the int into a double it will still be treated as an int)
            doubleNum = longInt / shortInt; //double num was a double but since we divided whole int. then the answer is an int.**
            //we cant initizalize and int. to a double, we can only initiazlize and int. to an int. but, we could do double to int.**
            shortInt = (short)3.14; //explicitly cast into an int.** shortInt = 3

            //if we multiply by 1.00, then it would be promoted to be a float (a decimal)** (bottom part instead of double put 1.00 and does same
            //thing**

            doubleNum = (double)longInt / shortInt;//if we cast the first thing as a double then the result will be a double (the deicmal)

            //double/int = double 

            //double,float,and decimal are ways to convert to decimals, but most of C# uses double so usually use double
            //using float and decimal will reuquire us to convert back to double if we wanted to use other math functions**

            

            myAdder(shortInt, shortInt); //chooses method based on what para. were put in (double.vs.int.)**
            myAdder(doubleNum, shortInt); //will call the method with the two doubles and convert shortInt into a double**

            doubleNum = shortInt; //**

            //press the project not the solution, then right click, then add a new class 
            //rename files by right clicking and rename then press no 



            MyDivider(byteNum, shortInt); //we can access the mydivider method within here because we changed the class to the class we created in the first class
            //within the second file
            //and made sure to put static in front of the class and added partial before the keyword class in both files(does this go for multiple files this rule** 
        }
    }
}
