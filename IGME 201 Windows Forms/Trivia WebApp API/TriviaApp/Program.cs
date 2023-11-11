using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net; //need this to to HTTP request and response
using Newtonsoft.Json;
using System.IO; //I was confused if you said this was used for our streamreaders or stringreaders in the video (1)**
using System.Web; //decode any HTML encoding used in the strings (add system.web via solution exploerer then
//go to project references then add a reference from the assemb. thats system.web

namespace TriviaApp
{
    //contains the fields in our trivia results
    class TrviaResult
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
            url = "https://opendb.com/api.php?amount=1";

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



        }
    }
}
