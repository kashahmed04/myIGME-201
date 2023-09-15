using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

//mad libs template has just 6 lines of text and ecach line is a story
//each \n means to insert a newline character within our code (replace that with an empty string character)
//we replace the tokens within the text file with the words the use puts in
//they will provide random words and have no context of the mad libs
//we need to save this template hard drive in our hard drive
//if we want to access the templates folde ri our code we wirte it as the second step last part with the two \\
//and call the text file there as well

//there is a PDF (IO) in week 1 to read in files 

namespace Madlibs
{
    class Program
    {
        static void Main(string[] args)
        {
            int numLibs = 0; //variable that has how many mad libs are in our file
            int cntr = 0; //counter
            int nChoice = 0; //ask the player which mad lib they want to play and they input a number from 1-6 or list them out by category then number them
            //tell them each story about then number them with it

            string finalStory = ""; //the string with the tokens subs. with the words the player types in for that mad lib 

            StreamReader input; //we use this to read from the file (streamreader class) (we learned console class (read/write from console),random class (random numbers generates),
            //and now the stream reader class 
            
            // open the template file to count how many Mad Libs it contains
            input = new StreamReader("c:\\templates\\MadLibsTemplate.txt"); //create a new streamreader variable to hold the text file we have
                                                                            //input = new StreamReader("c:/templates/MadLibsTemplate.txt");
                                                                            //(calls the streamreader constructor to create a new streamrreader object and just put in the file we want to read

            string line = null;
            while ((line = input.ReadLine()) != null) //read each line from the file and we can also use readline for the streamreader
                //and it reads from each line within the file sep. by the \n** (set a variable equal to the reading each line and stay in the loop
                //as long as the line is not equal to null (not at the end of the file yet)**
            {
                ++numLibs; //increment how many mad libs are in the file (increments each mad lib itself)
            }

            // close it**
            input.Close();

            // only allocate as many strings as there are Mad Libs
            string[] madLibs = new string[numLibs]; //make an array to hold the amount of mad libs within the text file

            // read the Mad Libs into the array of strings
            input = new StreamReader("c:\\templates\\MadLibsTemplate.txt"); //open the file again 

            line = null;
            while ((line = input.ReadLine()) != null) //want to read each line again until we reach the end of the file 
            {
                // set this array element to the current line of the template file
                madLibs[cntr] = line; //and how our cntr is initizialized to 0, and each array element would be equal to the line we are on

                // replace the "\\n" tag with the newline escape character
                madLibs[cntr] = madLibs[cntr].Replace("\\n", "\n"); //we can use replace method of the string type to replace the \\ with a escape character
                //the \n** (why need 2 \\)(if we want to replcae the \n with a newline character and in c# we need to say the \\ so it gets converted into \n
                //which is not the newline charatcer, but the new line character is a \n)**

                ++cntr;
            }

            input.Close();//**

            // prompt the user for which Mad Lib they want to play (nChoice) (do ask them a numebr from 1-6 but its 0 based so we shuld add a plus 1 to our output)

            // split the Mad Lib into separate words
            string[] words = madLibs[nChoice].Split(' '); //seperate that story into indiviidual words and looko for the words that have the {} around them
            //so they can be reapcled (we want to split our story based on spaces so it creates an array of strings where each string is a word in our story
            
            foreach( string word in words ) //loop thourgh all words in our story and check if the first character is a {, then if it is we want to prompt the
                //user to enter the replacement and usr the token subs. with the token with the replaced word and we add what they types to our final sotry
                //if the word is not a placeholder, we just add it to the final story and that it our story
            {
                // if word is a placeholder
                if (word[0] == '{')
                {
                    word = word.Replace("{", "").Replace("}", "").Replace("_"," "); //replace the {} with nothing and take them out,
                    //and the _ will get rid of the _ and add a space*
                    // prompt the user for the replacement (do this) 
                    Console.Write("Input a {0}: ", word);
                    // and append the user response to the result string
                    finalStory += Console.ReadLine();
                }
                // else append word to the result string
                else
                {
                    finalStory += word;
                }
            }
        }
    }
}
