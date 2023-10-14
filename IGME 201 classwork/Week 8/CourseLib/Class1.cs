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
                         //code and the Course object (instance) which is the value (1)****
    {
        public SortedList<string, Course> sortedList = new SortedList<string, Course>(); //is default public for lists and sorted lists
        public void Remove(string courseCode)
        {
            if (courseCode != null)
            {
                sortedList.Remove(courseCode); // does this get the instance and remove it if it exists? (we are not accessing the key in this case
                                               // or does the courseCode refer to the key in this case since its a string??)(2)****
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
                    returnVal = null;
                }

                return (returnVal); //if it does not work is returns null otherwise it returns the course instance(4)??*****
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
                thisCourse = new Course(($"IGME-{i}"), ($"Description for IGME-{i}"));

                // create a new Schedule object
                thisSchedule = new Schedule();
                for (int dow = 0; dow < 7; ++dow)
                {
                    // 50% chance of the class being on this day of week
                    if (rand.Next(0, 2) == 1)
                    {
                        // add to the daysOfWeek list
                        thisSchedule.daysOfWeek.Add((DayOfWeek)dow);

                        // select random hour of day
                        int nHour = rand.Next(0, 24);

                        // set start and end times of minute duration
                        // select fixed date to allow time calculations
                        thisSchedule.startTime = new DateTime(1, 1, 1, nHour, 0, 0);
                        thisSchedule.endTime = new DateTime(1, 1, 1, nHour, 50, 0);
                    }
                }

                // set the schedule for this course
                thisCourse.schedule = thisSchedule;

                // add this course to the SortedList
                this[thisCourse.courseCode] = thisCourse;
            }
        }





    }
    public class Schedule 
    {
        public DateTime startTime; //what does DateTime refer to in this case(6)****
        public DateTime endTime;
        public List<DayOfWeek> daysOfWeek = new List<DayOfWeek>(); //how does this work****
    }

    public class Course
    {
        public string courseCode; //these were in backwards order its not courseCode string
        public string description;
        public string teacherEmail;
        public Schedule schedule;

       
        public Course(string courseCode, string description)
        {
            this.courseCode = courseCode;
            this.description = description;
        }

        public Course()
        {

        }

    }
}


