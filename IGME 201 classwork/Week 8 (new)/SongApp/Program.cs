using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SongLib;

namespace SongApp
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Song song;
            VinylSong song2 = new VinylSong();
            song2.Play();
            song2.Sing();
            song2.Dance();


            //VinylSong song3 = new VinylSong() 
            //song3.Name = "1"
            //songs.Add(song3)
            //song3 = new VinylSong()
            //song3.Name = "2"
            //songs.Add(song3)
            //song3 = new VinylSong()
            //song3.Name = "3"
            //songs.Add(song3)
            //song3 = new VinylSong()
            //song3.Name = "4" ///add 4 songs to our list and when we call the sort it starts
            //at 1 and comapres it with 2,3,4,5 and in the background it starts with song1 and calls compareto()
            //and calls song 1's value (thisCompareValue) and song 2's with sCompare value then
            //compres those then returns the greater rank song 1 and compares song 1 throuought
            //the list as we go through (and it compares each item to each other like 1,2,3,4 compares
            //to each other and after each thing is compared with everything else then we move on)
            //songs.Add(song3)
            List<Song> songs = new List<Song>(); //this is the list that has the instance of song 

            //now it will use the compare to method of the class to compare the objects and sort them instead of the default method**
            //songs.sort() sorts the songs list based on a field put in with the compareto() and it
            //change the order of items in the list whereas the orderby
            //sorts in the way it does it by multiple fields whereas compareto is only 1
            //usually create a copy of the lists for orderby while the compareto does not

            //is this how we would usually implement just a list.vs.a sortedlist (yes)

            songs.Sort(); //songs.sort() keeps our original object and does not create a new list
            //it takes original list and makes them in a new order

            // we can specifically sort by other field by using the OrderBy() method
            //what is the main difference between sortedlist,list, and orderby

            // pass a method that returns the field to sort by**
            //we can also sort lists by any other field by using the order by method**

            //we create orderby ourselves right**
            //for comparing list values as well for compareto**
            //how would we know which methods to put in a class or not since we put the compareto in a class**
            //and the orderby we did not**
           
            songs = songs.OrderBy(OrderByName).ToList(); //use this way to use order by or first delegate method
            //created a list that contrains our songs and we want to order the list by the song game
            //so we have to method on the very bottom of the program and put it in the orderby built in
            //and it creates a new list based on the method and what it compares
            //and if we set songs = to the order by the original songs is gone and now points to
            //orderby

            //List<Song> songsByName we can use this and set it equal to the songs. above here 
            //and now this object points to that order by which created a new list and set it equal
            //to that list and songs by name points at orderby and songs points to the compareto()


            //since it expects a delegate or a method we could do:

            // use delegates and lambda expressions
            //we can do any of these methods below to do the same thing and it basically returns the
            //song.Name
            songs = songs.OrderBy(delegate (Song song1) { return song1.Name; }).ToList();//this takes a song paraemeter and
                                                                                         //returns the song name and we can simplify it further
            songs = songs.OrderBy((Song song1) => { return song1.Name; }).ToList(); //take away keyword delegate and add lambda 
                                                                                    //since we dont have delegate anymore
            songs = songs.OrderBy((song1) => { return song1.Name; }).ToList();//now we have removed the delegate
                                                                                //and the Song type for the para.(how does it know what type it is then
                                                                                //is it because we alrady defined it to be a type of song

            songs = songs.OrderBy((song1) => song1.Name).ToList(); //takes away delegate keyword and the Song type from the para. and the word "return"
            songs = songs.OrderBy(song1 => song1.Name).ToList(); //takes away delegate keyword, Song type, return, and the extra () around the song1
        }

       

        static string OrderByName(Song song)
        {
            //return song.artist + song.nRating.ToString() //this cwould use the song list
            //and it would convert it all to the strings because it does not sort by -1 0 or 1 like
            //compareto does
            return song.Name; //just returns the name and sorts the name
            //does the sorting by itself
        }
    }
}
