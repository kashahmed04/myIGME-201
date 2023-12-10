using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Activation;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Singleton
{
    // Interface: IPlayerInfo
    // Author: Kashaf Ahmed
    // Purpose: Use the interface to call the methods to load and save the players data 
    // from the PlayerInfo class.
    // Restrictions: None
    public interface IPlayerInfo
    {
        void LoadPlayerSettings();
        void SavePlayerSettings();
    }

    // Class: PlayerInfo
    // Author: Kashaf Ahmed
    // Purpose: First, we create and object for the playerInfo so we can serialize and deserialize it 
    // then we set a private static instance of the class to guarantee we only get one instance, then have
    // a method to return that instance as well as a private constructor to make sure we only get one instance
    // of the object. The two method deserialize and serialize the player object from a text file within the 
    // project folder
    // Restrictions: None
    public class PlayerInfo : IPlayerInfo
    {
        object playerInfo;
        private static PlayerInfo instance = new PlayerInfo();

        public static PlayerInfo GetInstance()
        {
            return instance;
        }

        private PlayerInfo()
        {

        }

        // Method: LoadPlayerSettings
        // Author: Kashaf Ahmed
        // Purpose: Read in the data from the JSON file, then do the ReaderToEnd and close the reader,
        // then deserialize the string we read in and write the info. to the console.
        // Restrictions: None
        public void LoadPlayerSettings()
        {
            StreamReader reader = new StreamReader(System.IO.Path.GetFullPath("../../player-info.JSON"));
            string p = reader.ReadToEnd();
            reader.Close();
            playerInfo = JsonConvert.DeserializeObject<object>(p);
            Console.WriteLine(playerInfo); //are these ok and this is ok if we write out to the console**
            
            //deserialize converts into a JSON object and serialize converts into a string right**


        }

        // Method: SavePlayerSettings
        // Author: Kashaf Ahmed
        // Purpose: Serialize the playerInfo and write it into string format then close the writer.
        // Restrictions: None
        public void SavePlayerSettings()
        {
            string s = JsonConvert.SerializeObject(playerInfo);
            StreamWriter writer = new StreamWriter(System.IO.Path.GetFullPath("../../player-info2.JSON"));
            writer.Write(s);
            writer.Close();
            

        }


    }


    // Class: Program
    // Author: Kashaf Ahmed
    // Purpose: Gets the player instance and IPlayerInfo interface, then
    // calls the methods from the class to load and save the player settings.
    // Restrictions: None
    internal class Program
    {
        // Method: Main
        // Author: Kashaf Ahmed
        // Purpose: Gets the player instance and IPlayerInfo interface, then
        // calls the methods from the class to load and save the player settings.
        // Restrictions: None
        static void Main(string[] args)
        {
            PlayerInfo player = PlayerInfo.GetInstance();
            IPlayerInfo iPlayer = player;

            iPlayer.LoadPlayerSettings();
            iPlayer.SavePlayerSettings();

        }
    }
}
