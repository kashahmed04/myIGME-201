using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongLib
{
    public interface ISong
    {
        string Name
        {
            get;
            set;
        }

        void Play();
        void Sing();
        void Dance();
        void Copy();
    }

    public interface IPlay
    {
        string Name
        {
            get; set;
        }

        void Play();
    }

    public abstract class Song : ISong, IPlay, IComparable<Song> //c# gives us a while bunch of interfaces already that we dont have to make ourelves which is the IComparable
        //interfce but we need to inherit it for the sort method to work in the list object and within the <> we put the datatype its comparing which is the song class
        //and it forces us to implement a compareto method and it compares fields to sort the list and in the same way we inherit the iclone interface because
        //its built in 
    //if we want to sort a list of songs by the song name then we can have all of our different song types and sort them by name
    //we need to an inherit an interface called ICompareable<Song> and we specify what the class its
    //going to use for comparison which is the Song class (usually use the same class
    //that we are using the interface for reference like Song and it would usually go in the parent so each child can inherit it)
    {
        public int year;
        public string lyrics;
        public string composer;
        public string artist;
        public int nRating;
        public int nCopies;

        public string Name //it acts just like a normals string but we can use an interface to access it 
            //we can have properties act like fields just so we can use interfaces with it 
        {
            get; set;
        }

        //we dont specifically tell it to do the compareto automatically because its a list and the list does it automatically 
        //and when we call the .sort with the list so it goes to this compareto and sorts them based on this field we define below 
        //and we usually follow exactly this convention and create the list in the main and it only sorts by 1 field though
        //when we call list.sort() it sorts the list in place and changes the list to be ordered by whatever the compareto() is 
        //when we do songs.sort() its now sorted in the order we put it
        //if we did orderby with songs it makes a copy of songs and then sorts it and the original songs string still remains 

        //but orderby allows us to do by any number of fields in the same list (it makes a copy of the list for each time we do the orderby)
        public int CompareTo(Song s) 
        {
            //return this.Name.CompareTo( s.Name );
            //compareto is a string comparison and it returns -1,0,1 which means (if the current string is less than the other string its -1 if it greater than 1 if its
            //equal to then its 0)
            string thisCompareValue = this.artist + this.nRating.ToString(); //the ranks are converted
            //into a string and its just to build a comparison value and we are building 1 string
            //to compare them and we want to compare by artist and rating so we create a string of those values
            //and then we compare (it just compares the strings for example it will be Taylor Swift then the rating)
            string sCompareValue = s.artist + s.nRating.ToString();
            return thisCompareValue.CompareTo(sCompareValue);

            //for each artist they have a rating and the thisCompareValue
            //and it takes their name and their rating and it will rank
            //the artists rating and for the current instance with this.
            //and then this.artist if the current song and the
            //s.artist is the other songs and compares those 
                 
            //we could pass in a song instance and 
            //return this.nRating.CompareTo(s.nRating); //this.nRating is the current song we are on and compares each value with each other values (like 1,1 2,2, 3,3, 4,4 etc.)
            //and it compares it to the next song in the list

        }

        public abstract void Play();
        public void Sing()
        {
            // la la la
        }
        public void Dance()
        {
            // bust out my moves
        }

        public virtual void Copy()
        {
            // default code to copy a song
        }
    }

    public class TapeSong : Song
    {
        public string tapeName;
        public int side;
        public int counter;

        public override void Play()
        {
            // load the tape on the correct side
            // fast forward to the counter
            // press the play button
        }
    }

    public class VinylSong : Song
    {
        public string recordName;
        public int side;
        public int track;

        public override void Play()
        {
            // turn on the turntable
            // put the record on the correct side
            // drop the needle on the correct track
        }

    }

    public class CDSong : Song
    {
        public string cdName;
        public int track;
        public override void Play()
        {
            // insert the cd
            // forward to the track
            // press the play button
        }

    }

    public class MP3Song : Song
    {
        public string fileName;
        public override void Play()
        {
            // double-click the filename
        }

        public override void Copy()
        {
            // do step 1

            base.Copy(); 

            // copy and paste the mp3 file
        }

    }

    public class Game : IPlay
    {
        public int players;

        public string Name
        {
            get; set;
        }

        public void Play()
        {
            // how to play the game
        }
    }
}
