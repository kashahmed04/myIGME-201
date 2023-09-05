using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_2_1._0
{
    static internal class Program
    {
        static void Main(string[] args) 
        {
            //double is used for converting numbers into decimals** and its the fastest data type to used for numeric calculations (usually use round though)
            //theres a math static class which has all our math operations in it plus conversions**
            //we are going to use double though because**
            //deciaml also exists but use double**
            //long decimal type means that**
            //which conversions do we have to worry about**
            //we can implicitely set data equal to a lesser type (less percise type)**


            //implicit casting (setting data type equal to another one without any instructions on how to do so)**
            longInt = shortInt;
            uintNum = byteNum;

            //problem 
            byteNum = shortInt;
            //cant implicitly convert because 

            //explicit casting
            //we lose data from this because**
            byteNum = (byte)shortInt; //we can do this because** 



        }
    }
}
