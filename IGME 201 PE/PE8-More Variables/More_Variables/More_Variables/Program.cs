using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace More_Variables
{
    // Class: Program
    // Author: Kashaf Ahmed
    // Purpose: Questions for PE8
    // Restrictions: None
    static internal class Program
    {
        // Method: Main()
        // Purpose: Build a 3D array based on conditions given, get a string from a user
        //and display it backwards by going backwards in a loop and adding to a new string and
        //returning it. We also check a new string input from the user and if the word contains "yes"
        //we replace it with "no" and vice versa. The last part is geting the string from the user and displaying every
        //word with quotes around them
        // Restrictions: None

        static void Main(string[] args)
        {

            //Question 5:
            double x = 0;
            double y = 0;
            double z = 0;

            int nX = 0;
            int nY = 0;

            double[,,] zFunc = new double[21, 31, 3];
            //we have 21 because we count an extra value for the 0 
            //and we have 31 because we start at 1 and we count the extra value of (its usually 30 because we dont have 30 in the middle)
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
            //by space for default or just by every other character (we have to include something in the ' ' for the single characters
            ////and the " " for a string)
            //(2)how is char. different than a string? and how could we have used split for
            //splitting each char if we wanted or is split not part of char. (a character is just one character and a string is multiple characters)
            //we can use split with strings but not characters 
            string reverseWord = ""; 
            for (int i = arrayWord.Length - 1; i >= 0; i--) 
            {
                reverseWord += arrayWord[i]; 
            }

            Console.WriteLine("Reversed Word: " + reverseWord);


            //Question 8:

            //when we use .reaplce().replaec(), etc. then it goes through all the replace to check
            //if the instance is in the string and goes through the whole string over and over again after each replace 
            //(1) this was not working unless I had to conditionals so I was wondering why that was the reason and it did not work if I did not
            ////have a new string to add to so I was confused about that as well****************************
            Console.WriteLine("Please enter a sentence containing the words yes and/or no");
            string answer = Console.ReadLine();
            string newAnswer = "";
            if(answer.ToLower() == "yes"){
               newAnswer += answer.ToLower().Replace("yes", "no").Replace("YES", "no").Replace("Yes", "no").Replace("yes!", "no").Replace("yes?", "no").Replace("yes,", "no");

            }
            else if(answer.ToLower() == "no")
            {
                newAnswer += answer.ToLower().Replace("no", "yes").Replace("NO", "YES").Replace("No", "yes").Replace("no!", "yes").Replace("no?", "yes").Replace("no,", "yes");
            }
            
            Console.WriteLine(newAnswer);



            Console.WriteLine("Please enter a random sentence");
            string output = Console.ReadLine();
            string[] outputArray = output.Split(' ');
            string newString = "";
            for (int i = 0; i < outputArray.Length; i++)
            {
                newString += "\"" + outputArray[i] + "\" ";
            }
            Console.WriteLine(newString); 
                                        


        }

    }
}


