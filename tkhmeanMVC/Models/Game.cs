using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tkhmeanMVC.Data.Helpers;

namespace tkhmeanMVC.Models
{
    public class Game
    {

        // Game model
        public string id { get; set; }
        public string name { get; set; }
        public int maxNumberOfPlayers { get; set; } = 10;
        public GameType gameType { get; set; }

        // List of the users in a game
        public List<User> users { get; set; } = new List<User>();

        public enum GameType
        {
            PUBLIC,
            PRIVATE
        }

    }
}
