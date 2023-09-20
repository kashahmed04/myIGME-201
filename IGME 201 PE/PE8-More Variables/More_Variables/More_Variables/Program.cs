using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace More_Variables
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Question 5:
            double x = 0; 
            double y = 0;
            double z = 0;

            int nX = 0;
            int nY = 0;

            double[,,] zFunc = new double[21,31,3];
            //(0) there are to questions down below*****
            //we have 21 because we count an extra value for the 0 
            //and we have 31 because we start at 1 and we count the extra value of 
            //getting to 4 from?

            for (x = -1; x <= 1; x += 0.1, nX++)
            {
                x = Math.Round(x, 1);

                nY = 0;

                for (y = 1; y <= 4; y += 0.1, ++nY)
                {
                    y = Math.Round(y, 1);

                    z = 2 * Math.Pow(x, 3) + 3 * Math.Pow(y, 3) + 6;

                    z = Math.Round(z, 3);

                    zFunc[nX, nY, 0] = x;
                    zFunc[nX, nY, 1] = y;
                    zFunc[nX, nY, 2] = z;
                }

            }


            //Question 7:
            Console.WriteLine("Please enter a word");
            string word = Console.ReadLine();
            char[] arrayWord = word.ToCharArray(); 
            //(1)if we dont put anything in the split does it just do it 
            //by space for default or just by every other character******
            //(2)how is char. different than a string? and how could we have used split for
            //splitting each char if we wanted or is split not part of char.?******
            //(3)is it still and array but in this case its just characters****
            string reverseWord = ""; //(3)I tried to use char. here but when I tried to add the 
            //values into the reverseWord it was not working so does it not work the same as a string******
            for(int i = arrayWord.Length - 1; i >= 0; i--) //(4) is this ok could we have done a foreach because foreach does
                //not edit the array contents so I was wondering if we could do that****
            {
                reverseWord += arrayWord[i]; 
            } 

            Console.WriteLine("Reversed Word: " + reverseWord);


            //Question 8:
            Console.WriteLine("Please enter a sentence containing the words yes and/or no");
            string answer = Console.ReadLine();
            answer.ToLower().Replace("yes", "no");
            answer.ToLower().Replace("no","yes");
            Console.WriteLine(answer);



            Console.WriteLine("Please enter a random sentence");
            string output = Console.ReadLine();
            string[] outputArray = output.Split(' ');
            string newString = "";
            for (int i = 0; i < outputArray.Length; i++)
            {
                newString += "\"" + outputArray[i] + "\"";
            }
            Console.WriteLine(newString); //(5)is there an easier way to add quotes around
                                          //an element and can we do what we did above or is it good****
                                          //(6) Is it ok if we did everything in one step in terms of adding to the string is this allowed****

        }
    }
}

