﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.CodeDom;

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
    // Class Program
    // Author: Kashaf Ahmed
    // Purpose: Ask a user to pick a mad lib and tell them
    //to fill in the blanks, then fill in the blanks based on what
    //the user had put in and output the mad lib to them.
    // Restrictions: None
    static class Program
    {
        // Method: Main
        // Purpose: Read the mad libs file and count the number of mad libs there are
        //in the file, then ask the user if they want to play or not, if they said something other than
        //yes or no, we tell the user to keep entering until they say yse or no, if they enter no we
        //dont do anything and just say "goodbye", otherwise if they say yes, then we ask them to choose
        //a mad lib between 1 and 6 and if they dont input correctly we ask them to input a value from 1 to 6,
        //then we tell them to fill in the blanks based on the mad lib and put it together and output it to
        //the console based on what they had put in.
        // Restrictions: Could not get error checking correct so I just commented out what I had done.
        //There were also about 6 questions on here as well if you could answer them whenever you were free
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
                                                      //as long as the line is not equal to null (not at the end of the file yet)
            {
                ++numLibs; //increment how many mad libs are in the file (increments each mad lib itself)
            }

            // close it**
            input.Close();

            // only allocate as many strings as there are Mad Libs
            string[] madLibs = new string[numLibs]; //make an array to hold the amount of mad libs within the text file

            // read the Mad Libs into the array of strings
            input = new StreamReader("c:\\templates\\MadLibsTemplate.txt"); //open the file again 
            //(0)Why do we have to open the streamreader twice here and why do we set it to a new variable and say new each time**********************
            line = null;
            while ((line = input.ReadLine()) != null) //want to read each line again until we reach the end of the file 
            {
                // set this array element to the current line of the template file
                madLibs[cntr] = line; //and how our cntr is initizialized to 0, and each array element would be equal to the line we are on

                // replace the "\\n" tag with the newline escape character
                madLibs[cntr] = madLibs[cntr].Replace("\\n", "\n"); //we can use replace method of the string type to replace the \\ with a escape character
                //the \n (if we want to replace the \n with a newline character and in c# we need to say the \\ so it gets converted into \n
                //which is not the newline charatcer, but the new line character is a \n)
                //(1)so basically, in this case it checks for a physical \n character so we ref. it with two \\, then when it actually replaces it,
                //its an actual space character*******************

                ++cntr;
            }

            input.Close();//(2) Closes the file for us once we are done reading it and the information for that file is
            //gone except for whatever we store in variables (why would we want to close it usually and we only usuually open and close the same file once per file
            //right or is there another case for that)**********

            string userInput = null;
            int tries = 0;
            Console.WriteLine("Would you like to play? (Reply yes or no)");
            userInput = Console.ReadLine();
            while(!userInput.ToLower().StartsWith("y") && !userInput.ToLower().StartsWith("n")) { //(3)can we still include the conditionals inside of the loop
                //when we fix it or should we put it outside since the while loop checks if y or n was entered*********
                    tries++;
                    if (tries >= 3)
                    {
                        Console.WriteLine("Just type yes or no how hard can that be?");
                    }
                    Console.WriteLine("Would you like to play? (Reply yes or no)");
                userInput = Console.ReadLine();
                
            }
            if(userInput.ToLower().StartsWith("n")) {
                Console.WriteLine("Goodbye!");
                goto end;
            }
            start:
            // prompt the user for which Mad Lib they want to play (nChoice) (do ask them a numebr from 1-6 but its 0 based so we shuld add a plus 1 to our output)
            Console.WriteLine("Choose a mad lib from 1-6!");
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
                    continue;
                }
                if(nChoice == 0)
                {
                    Console.WriteLine("Please enter a valid choice between 1-6!");
                    libChoice = Console.ReadLine(); //(4)is it necessary to put continue here because it would go back to the while loop regardless*******
                    
                }
                //try
                //{
                //
                //    if (nChoice >= 7)
                //    {
                //        throw new Exception();
                //
                //    } //(5) I am a bit confused here for checking if the value entered was greater than or equal to 7 because
                //      //I tried to do a try catch but I was a bit confused about what to do after I threw the exception because I went to the
                //      catch and tried to actually catch the exception but it was not working out for me so I deleted it and I was confused on how
                //      to do this part. I was also confused if it was ok to leave the () blank or actually do an index exception*****

                //}     //(6) if there is another try catch within this while loop, if theres a catch happens does it go back to
                //      //the top of the loop, or does it still go all the way through??*********************************
                //catch
                //{
                //    Console.WriteLine("Please enter a valid choice between 1-6!");
                //    libChoice = Console.ReadLine();
                //    nChoice = 0;
                //
                //}
            }

            // split the Mad Lib into separate words
                --nChoice; //have to do this because its 0 based and it would go to 2 instead if we chose option one so we have to subtract
                string[] words = madLibs[nChoice].Split(' '); //seperate that story into indiviidual words and look for the words that have the {} around them
                                                              //so they can be reapcled (we want to split our story based on spaces so it creates an array of strings where each string is a word in our story
            foreach (string word in words) //loop thourgh all words in our story and check if the first character is a {, then if it is we want to prompt the
                                           //user to enter the replacement and usr the token subs. with the token with the replaced word and we add what they types to our final sotry
                                           //if the word is not a placeholder, we just add it to the final story and that is our story
            {
                // if word is a placeholder
                if (word[0] == '{')
                {
                    string unknownWord = word.Replace("{", "").Replace("}", "").Replace("_", " "); 
                    //replace the {} with nothing and take them out,
                    //and the _ will get rid of the _ and add a space
                    // prompt the user for the replacement (this is how the replace works right)
                    Console.Write("Input a {0}: ", unknownWord);

                    // and append the user response to the result string
                    finalStory += " ";
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
            while (!userInput.ToLower().StartsWith("y") && !userInput.ToLower().StartsWith("n"))
            { 
                Console.WriteLine("Would you like to play? (Reply yes or no)");
                userInput = Console.ReadLine();
            }
            if (userInput.ToLower().StartsWith("n"))
            {
                Console.WriteLine("Goodbye!");
                goto end;
            }
            if (userInput.ToLower().StartsWith("y"))
            { 
                goto start;
            }
        end:;
            
        }
       
    }
}

