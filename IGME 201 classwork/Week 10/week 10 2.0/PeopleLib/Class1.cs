﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace PeopleLib
{
    //public enum EGames //we could also user enumerated type to store data from sorted lists instead (we can't add spaces to enumerated types so
    //                    //maybe sorted list would be better for the things that have spaces in between maybe?
    //{
    //  Sons_of_The_Forest,
    //  Rainbow_Six_Siege,
    //  Valorant,
    //  Counter_Strike,
    //  Roblox,
    //  VRChat
    //
    //
    //}
    //
    //public enum ETimes
    //{
    //    
    //}
    //
    //public enum ERank
    //{
    //    
    //}
    //public enum EProfilePhotos
    //{
    // 
    //}
    //
    public class User 
    {

        public string username;
        public int bioLabel;
        public bool onlineStatus;

        //sorted list that takes in the username as the key and the games as a value (could use a tuple for the value to store multiple values in)
        //of if there was an easier way of doing it not too sure 
        public SortedList<string, string> gameNames = new SortedList<string, string>();
        //username is key and the time is the value (could also use the tuple approach for the value so we could store multiple things in one value)
        public SortedList<string, int> times = new SortedList<string, int>();
        //username is key and the rank is the value(could also use the tuple approach for the value so we could store multiple things in one value)
        public SortedList<string, int> rank = new SortedList<string, int>();
        //each user (key) has an associated photopath which is the value 
        public SortedList<string, string> profilePhotos = new SortedList<string, string>();

        //implement the list in PeopleAppGlobals 


        //was not too sure if we wanted a comparison here either but kept it just in case 
        //public static bool operator <(Student s1, Student s2)
        //{
        //    return (s1.gpa < s2.gpa);
        //}
        //
        //public static bool operator <=(Student s1, Student s2)
        //{
        //    return (s1.gpa <= s2.gpa);
        //}
        //
        //public static bool operator >(Student s1, Student s2)
        //{
        //    return (s1.gpa > s2.gpa);
        //}
        //
        //public static bool operator >=(Student s1, Student s2)
        //{
        //    return (s1.gpa >= s2.gpa);
        //}
        //
        //public static bool operator ==(Student s1, Student s2)
        //{
        //    return (s1.gpa == s2.gpa);
        //}
        //
        //public static bool operator !=(Student s1, Student s2)
        //{
        //    return (s1.gpa != s2.gpa);
        //}
    }

    // [+People|sortedList:SortedList<string, Person>|this:email|+Remove(email: string)]
    public class Players //did players here instead of users so it would not be confusing 
    {
       
        // create a Sorted List indexed on username (string) and storing User objects
        public SortedList<string, User> sortedList = new SortedList<string, User>();

        public void Remove(string username)
        {
            if (username != null)
            {
                sortedList.Remove(username);
            }
        }

        // indexer property allows array access to sortedList via the class object
        // and catching missing keys and duplicate key exceptions
        //gets a player based on the username as the key and the whole object as the value 
        public Players this[string username]
        {
            get
            {
                Players returnVal;
                try
                {
                    returnVal = (Players)sortedList[username];
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
                    //we can add to the list if we want by username
                    sortedList[username] = value;
                }
                catch
                {
                    // an exception will be raised if an entry with a duplicate key is added
                    // duplicate key handling
                }
            }
        }
    }

}