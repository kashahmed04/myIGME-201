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
