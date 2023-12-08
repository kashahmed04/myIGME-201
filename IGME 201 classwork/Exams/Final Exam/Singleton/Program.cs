using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Activation;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Singleton
{
    public interface IPlayerInfo
    {
        void LoadPlayerSettings();
        void SavePlayerSettings();
    }

    public class PlayerInfo : IPlayerInfo 
    {
        private static PlayerInfo instance = new PlayerInfo();

        public static Info info = new Info("dschuh",4, 99, ["spear","water","bottle","hammer","sonic screwdriver","cannonball","wood","Scooby snack","Hydra","poisonous potato","dead bush","repair powder"],"DFGU99-1454");

        public static PlayerInfo GetInstance()
        {
            return instance;
        }

        private PlayerInfo()
        {

        }

        public void LoadPlayerSettings()
        {
            //string p = JsonConvert.SerializeObject();

        }

        public void SavePlayerSettings()
        {

        }

        public class Info
        {
            string player_name; //are the names ok 
            int level;
            int hp;
            List<string> inventory;
            string license_key;

            public Info(string player_name, int level, int hp, List<string> inventory, string license_key)
            {
                this.player_name = player_name;
                this.level = level;
                this.hp = hp;
                this.inventory = inventory;
                this.license_key = license_key; 

            }


        }


    }

    internal class Program
    {
        static void Main(string[] args)
        {
            PlayerInfo player = PlayerInfo.GetInstance();
            IPlayerInfo iPlayer = player;

            iPlayer.LoadPlayerSettings();
            iPlayer.SavePlayerSettings();

        }
    }
}
