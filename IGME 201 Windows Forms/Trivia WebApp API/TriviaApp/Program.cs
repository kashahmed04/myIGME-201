using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net; //need this to to HTTP request and response
using Newtonsoft.Json;
using System.IO; //I was confused if you said this was used for our streamreaders or stringreaders in the video (1)**
using System.Web; //decode any HTML encoding used in the strings (add system.web via solution exploerer then
using System.Web.Management;
//go to project references then add a reference from the assemb. thats system.web

namespace TriviaApp
{
    //contains the fields in our trivia results
    class TriviaResult
    {
        public string category;
        public string type;
        public string difficulty;
        public string question; //need to have the same exact name as tag in the JSON otherwise our deserializer wont know where
        //to put our fields
        public string correct_answer;
        public List<string> incorrect_answers;
    }

    
    class Trivia
    {
        //make public because JSON deserializer needs to access members of our class when it accesses the objects 
        public int response_code;
        public List<TriviaResult> results; //why is triviaresult not working**(2)

    }
    //{
    //"response_code": 0,
    //"results": [
        //{
          //  "category": "Science: Computers",
            //"type": "multiple",
            //"difficulty": "medium",
            //"question": "When was the programming language &quot;C#&quot; released?",
            //"correct_answer": "2000",
            //"incorrect_answers": [
              //  "1998",
                //"1999",
                //"2001"
//            ]
//}
  //  ]



    internal class Program
    {
        static void Main(string[] args)
        {
            string url = null; //url that we are going to query

            //string s response from our query to url
            string s = null;

            //http web request
            HttpWebRequest request;

            //need a http web response
            HttpWebResponse response;

            //use a streamreader to read from out connection
            StreamReader reader;

            //url is the one that was in our web page
            url = "https://opentdb.com/api.php?amount=1&type=multiple";

            //now create the http web request object
            //create reference to url
            request = (HttpWebRequest)WebRequest.Create(url); //why do we have to cast the request here?**(3)

            //get response (sends request to url)
            response = (HttpWebResponse)request.GetResponse();

            //read the data from the response
            //so basically this gets our response data?**(4)
            reader = new StreamReader(response.GetResponseStream());

            //read the json string from the trivia api site
            s = reader.ReadToEnd();

            //always close the resource so its not tying up memory
            reader.Close();

            //we now have our json string now we deserialize it into a triva object
            Trivia trivia = JsonConvert.DeserializeObject<Trivia>(s);

            //decode any of the html encoded characters that are in the questions string, correct answers string, or incorrect answers strings

            //so basically here we are getting our string from the json and from the first index (which is one
            //json object since its only 1 question) we basically decode the question and correct answer
            //based on that one string and do . notation to access a certain field in that string?**(5)
            //is is a string of an object?**(6)
            //how do we know when to decode or encode?**(7)
            trivia.results[0].question = HttpUtility.HtmlDecode(trivia.results[0].question);
            trivia.results[0].correct_answer = HttpUtility.HtmlDecode(trivia.results[0].correct_answer);
            for (int i = 0; i < trivia.results[0].incorrect_answers.Count; ++i)
            {
                trivia.results[0].incorrect_answers[i] = HttpUtility.HtmlDecode(trivia.results[0].incorrect_answers[i]);
            }

            Console.WriteLine(trivia.results[0].question);
            Random randomAnswer = new Random();
            List<string> tempList = new List<string>();
            tempList.AddRange(trivia.results[0].incorrect_answers); //goes through incorrect answers an adds all the values from the list (only used with list types)
            tempList.Add(trivia.results[0].correct_answer);
            for(int i = 0; i < 4; i++) //go through the templist of correct and incorrect values and print them out for the list choices
            {
                int j = randomAnswer.Next(0, tempList.Count);
                Console.WriteLine(tempList[j]);
                tempList.Remove(tempList[j]);
            }

            Console.WriteLine("What is the correct answer?");

            string answer = Console.ReadLine();

            if(answer.Trim().ToLower() == trivia.results[0].correct_answer.ToLower()) //if they answer correct tell them they are correct
                //and give them the correct answer otherwise tell them they are incorrect and give them the correct answer
            {
                Console.WriteLine("Correct the answer is: " + trivia.results[0].correct_answer);
            }
            else
            {
                Console.WriteLine("Incorrect the answer is: " + trivia.results[0].correct_answer);
            }


            


        }
    }
}





//JsonHtml file


 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json; //so we have to install it everytime we make a new program and use this using statement?(1)**
using PeopleAppGlobals;
using PeopleLib;
using System.IO;//for the stream writer
using System.Net;//gives us access to the http classes?(1.5)**

//serialize- machine readable code (our student and teacher classes) into human readable structure like JSON**
namespace JsonHtml
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Globals.AddPeopleSampleData(); 

            List<Teacher> teachers = new List<Teacher>();
            List<Student> students = new List<Student>();
            foreach(KeyValuePair<string,Person> keyValuePair in Globals.people.sortedList) 
                //we had to make a new loop since we dont have access to peoplelist right**(2)
            {
                if(keyValuePair.Key.GetType() == typeof(Teacher))
                {
                    //why are we remaking the list?**(3)
                    //we have to cast because we are going through a person right?**(4)
                    teachers.Add((Teacher)keyValuePair.Value);
                }
                else
                {
                    students.Add((Student)keyValuePair.Value);
                }
            }

            //when we serialize objects into JSON it creates strings
            //pass in list we want to serialize 
            //useful if we want to store data somewhere else and load it back later
            string s = JsonConvert.SerializeObject(students);
            string t = JsonConvert.SerializeObject(teachers);

            //write strings out to a file
            //save it to our temp folder with the people.json name
            StreamWriter writer = new StreamWriter("c:/temp/students.json");

            //write our students and teachers then close the file
            writer.Write(s);
            writer.Close();

            writer = new StreamWriter("c:/temp/teachers.json"); 
                //why can we use the same variable wouldnt they override eachother when we read and write in data?**(5)

            writer.Write(t);
            writer.Close();

            //when we see the temp folder we can open it and we can format the document to see the information of our
            //students and teachers

            //read the data back in but we have to have the student and teacher files sep. to do that 
            StreamReader reader = new StreamReader("c:/temp/students.json");

            //this s variable reads all of the characters from our file 
            s = reader.ReadToEnd();
            reader.Close();

            reader = new StreamReader("c:/temp/teachers.json");
            t = reader.ReadToEnd();
            reader.Close();

            //deserialize based on s string and give it generic type to be serialized to 
            //convert string back into list of student objects do same for teachers  
            students = JsonConvert.DeserializeObject<List<Student>>(s);

            teachers = JsonConvert.DeserializeObject<List<Teacher>>(t);

            //get two lists back into our sortedlist (globals people variable)
            //restore our sortedlist to what we started from in our add people sample data 
            SortedList<string, Person> people = new SortedList<string, Person>();
            foreach(Student student in students)
            {
                people[student.email] = student;
            }

           
            foreach (Teacher teacher in teachers)
            {
                people[teacher.email] = teacher;
            }


            //use http web request and web response to get external data from an API
            //define url
            string url = "http://people.rit.edu/dxsigm/json.php"; //returns a serialized representation of a list of teachers

            //this creates the request to get the data?(6)**
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            //we need a response for the request above
            //issues the http request over the web 
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //read the response from the port 80 socket
            //use streamreader to read from port
            //when we just use reader we override the above streamreader we declared right?**(7)
            //created the response created the socket and made a stream for the port 80 for the http protocol
            reader = new StreamReader(response.GetResponseStream());

            //now read our list of teachers from the socket
            t = reader.ReadToEnd();
            //I am still confused on how to know what to close and what not to close
            //when we did "close();" in dyscord and here**(8)
            reader.Close();
            response.Close();

            //t has list of teachers in serialized format from banjo site
            //now we can deserialize to make it a list of teachers
            teachers = JsonConvert.DeserializeObject<List<Teacher>>(t);




        }
    }
}