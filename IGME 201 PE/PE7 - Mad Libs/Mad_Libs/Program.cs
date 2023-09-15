using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

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
                //the \n (if we want to replace the \n with a newline character and in c# we need to say the \\ so it gets converted into \n
                //which is not the newline charatcer, but the new line character is a \n)
                //(1) I am still kind of confused about the \\n and \n so I was wondering if you could explain again?*************

                ++cntr;
            }

            input.Close();//(2) what does intput.Close() do? And also are my names ok for my mad libs or were there certain naming
                          //conditions*****************

            string userInput = null;
            int tries = 0;
            Console.WriteLine("Would you like to play? (Reply yes or no)");
            userInput = Console.ReadLine();
            while(userInput != null) {
                if (userInput.ToLower().StartsWith("y"))
                {
                    break;
                }
                else if (userInput.ToLower().StartsWith("n")){
                    Console.WriteLine("Goodbye!");
                    goto end;
                    
                }
                else
                {
                    tries++;
                    if (tries >= 3)
                    {
                        Console.WriteLine("Just type yes or no how hard can that be?");
                    }
                    Console.WriteLine("Would you like to play? (Reply yes or no)");
                    userInput = Console.ReadLine();
                    continue;
                }
                //(3)is this ok or should I try to simplify it even more*******************
            }
            start:
            // prompt the user for which Mad Lib they want to play (nChoice) (do ask them a numebr from 1-6 but its 0 based so we shuld add a plus 1 to our output)
            Console.WriteLine("Choose a mad lib from 1-5!");
            Console.WriteLine("1. Chinese resturant");
            Console.WriteLine("2. Whacky Recipe");
            Console.WriteLine("3. Health Inspection");
            Console.WriteLine("4. Flying through a storm");
            Console.WriteLine("5. Summer camp");
            Console.WriteLine("6. Lucy in the Sky With Diamonds");
            string libChoice = Console.ReadLine();

            while (nChoice == 0)
            {
                try
                {
                    nChoice = Convert.ToInt32(libChoice);
                }
                catch
                {
                    Console.WriteLine("Please enter a valid choice between 1-6!");
                    libChoice = Console.ReadLine();
                }
                if(nChoice == 0)
                {
                    Console.WriteLine("Please enter a valid choice between 1-6!");
                    libChoice = Console.ReadLine(); //(4) is it ok if the user enters a number bigger than 6 and the index
                    //error occurs or should we account for that too
                    //because I tried to account for that and I ended up getting an infinite
                    //loop in for the WriteLine statement saying to choose a number between 1-6***************
                    continue;
                }
            }

            // split the Mad Lib into separate words
                --nChoice;
                string[] words = madLibs[nChoice].Split(' '); //seperate that story into indiviidual words and look for the words that have the {} around them
                                                              //so they can be reapcled (we want to split our story based on spaces so it creates an array of strings where each string is a word in our story
            foreach (string word in words) //loop thourgh all words in our story and check if the first character is a {, then if it is we want to prompt the
                                           //user to enter the replacement and usr the token subs. with the token with the replaced word and we add what they types to our final sotry
                                           //if the word is not a placeholder, we just add it to the final story and that it our story
            {
                // if word is a placeholder
                if (word[0] == '{')
                {
                    string unknownWord = word.Replace("{", "").Replace("}", "").Replace("_", " "); 
                    //(5)replace the {} with nothing and take them out,
                    //and the _ will get rid of the _ and add a space
                    // prompt the user for the replacement (this is how the replace works right)************
                    Console.Write("Input a {0}: ", unknownWord);

                    // and append the user response to the result string
                    finalStory += " "; //(6)is this ok to apply the space here for the output because it puts a space between the periods as well
                    //or should I have a conditional for that*****************
                    //(7)how would we use split because even if we did put the final story into an array, we cant
                    //really split because there is a charatcer (a space per word) to split by (this was my alternative idea
                    //if my current one was not allowed************
                    
                    //(8)on a side note, for the chinese resturant story the comma gets inserted when it asks the user for a pop star I think it was
                    //so is that ok?**************8
                    finalStory += Console.ReadLine();
                }
                // else append word to the result string
                else
                {
                    finalStory += " ";
                    finalStory += word;
                }
            }

            Console.WriteLine("Choice #" + (nChoice + 1) + ":" + "\n"+ finalStory);
            
            Console.WriteLine("Would you like to play again? (Reply yes or no)");
            userInput = Console.ReadLine();
            while (userInput != null)
            {
                if (userInput.ToLower().StartsWith("y"))
                {
                    goto start;
                }
                else if (userInput.ToLower().StartsWith("n"))
                {
                    Console.WriteLine("Goodbye!");
                    goto end;

                }
                else
                {
                    Console.WriteLine("Would you like to play? (Reply yes or no)");
                    userInput = Console.ReadLine();
                    continue;
                }
                //(9)is this ok in terms of having the goto statements "end" and "start" also was it a requirement to make our
                ////own mad lib as well or optional************
                //(10)finally should I also have another counter and statement here
                //to account if the user has not answered the right way more than 3 times like I did above?***************
            }
        end:;
        }
    }
}

