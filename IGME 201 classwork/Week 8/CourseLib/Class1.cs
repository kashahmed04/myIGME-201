using CourseLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace CourseLib
{
    public class Courses //this is going to have a sorted list for the string which is the course
                         //code and the Course object (instance) which is the value (1) (this is a dictionary right even though its labeled as sorted list
                         //can we do the same with just a list or not)**
    {
        public SortedList<string, Course> sortedList = new SortedList<string, Course>(); //is default public for lists and sorted lists**
        public void Remove(string courseCode)
        {
            if (courseCode != null)
            {
                sortedList.Remove(courseCode); // does this get the string which is thr key and remove it if it exists aont with the value?? (2)
                                               // coursecode is one entry in the list right which is the code as a string and the object****
                                               //what is coursecode we did not define it anywhere**
            }
        }

        public Course this[string courseCode] //indexer property 
        {
            get
            {
                Course returnVal;
                try
                {
                    returnVal = (Course)sortedList[courseCode]; //why do we have to explicitly cast here(3)***** 
                }
                catch
                {
                    returnVal = null; //return null if they kye does not exist**
                }

                return (returnVal); //if it does not work is returns null otherwise it returns the course instance based on the string course code if it exists(4)??*****
            }

            set
            {
                try
                {
                    sortedList[courseCode] = value;
                }
                catch
                {
                     //what would we put in catch?? It does not specify(1)**
                     //when we dont put in a key or a key thats not a string or did not put in the value of being a person object it would come here**
                }
            }
        }



        public Courses()
        {
            Course thisCourse;
            Schedule thisSchedule;

            Random rand = new Random();

            // generate courses IGME-200 through IGME-299
            for (int i = 200; i < 300; ++i)
            {
                // use constructor to create new course object with code and description
                thisCourse = new Course(($"IGME-{i}"), ($"Description for IGME-{i}")); //so it puts the same number for the name of the course and the description(ex.200)**
                //creates a new course instance with the course code as a string and the course description as a string)**

                // create a new Schedule object
                thisSchedule = new Schedule(); //the scdule class we created (does not matter where it is in the code even if its below it then it can be accessed)**
                for (int dow = 0; dow < 7; ++dow)
                {
                    // 50% chance of the class being on this day of week
                    if (rand.Next(0, 2) == 1)
                    {
                        // add to the daysOfWeek list
                        thisSchedule.daysOfWeek.Add((DayOfWeek)dow); //based on the new schedule instance we created it calls the days of week list and adds** 
                        //the specific day of the week to that list only for that specific instance**
                        //(DayOfWeek)dow how does it know what day to add**

                        // select random hour of day
                        int nHour = rand.Next(0, 24);

                        // set start and end times of minute duration
                        // select fixed date to allow time calculations
                        thisSchedule.startTime = new DateTime(1, 1, 1, nHour, 0, 0); //for the instances we want to access the start and end times and create a new**
                                                                                        // a new date time instance because we just defined the data type in schedule**
                        thisSchedule.endTime = new DateTime(1, 1, 1, nHour, 50, 0); //what are the para. saying here and what does it output**
                    }
                }

                // set the schedule for this course
                thisCourse.schedule = thisSchedule; //it sets our schedule field for the course class instance (below) equal to thisSchedule**

                // add this course to the SortedList
                this[thisCourse.courseCode] = thisCourse; //how does this work do we always have to put the actual word "this" then the [] for indexer properties**
                //get the coursecode string as the key and the actual thisCourse instance it the value**
                //in this case it uses the set because we are setting it equal to a value (the value keyword in the set)**
                //how to know when to use set**
                //make the coursecode string as they key and the value as the whole thiscourse with everything in it**
                

                //how do we know when to use the actual word this.vs.the instance (is it because we are in a dll and not in a main)(but usually instead of this**
                //ourside of a dll in main we would use the instance of the class that holds the indexer property)**
            }
        }





    }
    public class Schedule 
    {
        public DateTime startTime; //only setting the variable to a datatype and we have to use the new keyword to define a new DateTime because its a class\
                                   //usualy use new for classes)??**
        public DateTime endTime;
        public List<DayOfWeek> daysOfWeek = new List<DayOfWeek>(); //creates a new list of the dayofweek type and it takes our schedule instance above and adds the specific
        //day of the week based on the daysOfWeek variable (dont have to create a new instance with the new keyword like we did for date and time**
        //why do we need a list if we are just putting them equal to coursecode and putting it in a list since its already stored**
    }

    public class Course //why do we need this here**
    {
        public string courseCode; //these were in backwards order its not courseCode string we make a new Course instance and the first string in the new condition 
                                    //is the course code and the second is the description of the course
        public string description;
        public string teacherEmail; //where is this defined**
        public Schedule schedule; //this is used with thisCourse to set the schdule to the scheuld object we had created**
        //we create a schedule class called schedule (ref. the class above it??)**

       
        public Course(string courseCode, string description) //why do we have to do this here**
        {
            this.courseCode = courseCode;
            this.description = description;
        }

        public Course()
        {

        }

    }
}


