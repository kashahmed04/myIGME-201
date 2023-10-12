using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace CourseLib
{
    public class Courses //this is going to have a sorted list for the string which is the course
                         //code and the Course object (instance)****
    {
        SortedList<string, Course> sortedList = new SortedList<string, Course>();

        public void Remove(string courseCode)
        {
            if(courseCode != null)
            {
                sortedList.Remove(courseCode);//****
            }
        }

        public Course this[string courseCode] //indexer property 
        {
            get
            {
                Course returnVal; 
                try
                {
                    returnVal = (Course)sortedList[courseCode]; 
                }
                catch
                {
                    returnVal = null;
                }

                return (returnVal);
            }

            set
            {
                try
                {
                    sortedList[courseCode] = value; 
                }
                catch
                {
                   
                }
            }
        }
    }

    //do the rest after courses parent class****
}
