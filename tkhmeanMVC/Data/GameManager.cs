using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tkhmeanMVC.Data.Helpers;
using tkhmeanMVC.Models;


namespace tkhmeanMVC.Data
{
    /// <summary>
    ///  Do I have to do locks handling here!?
    /// </summary>
    public static class GameManager
    {


        #region Props

        // List of the games
        public static List<Game> games = new List<Game>();
        private static object _syncLock = new object();


        #endregion

        #region Functions

        /// <summary>
        /// Create a game
        /// </summary>
        /// <param name="isPrivate"> To determine if the game is public or private</param>
        /// <returns></returns>
        public static Game createGame(bool isPrivate = false)
        {

            // If no exceptions return true, otherwise return false.
            Game game = new Game()
            {
                id = "Game" + ModelHelpers.generateUniqueId(),
                gameType = (isPrivate) ? Game.GameType.PRIVATE : Game.GameType.PUBLIC
            };

            games.Add(game);

            return game;
        }



        public static bool addUserToGame(User user, string id)
        {

            Game game = games.FirstOrDefault(g => g.id.Equals(id));
            if (game != null)
            {

                game.users.Add(user);
                return true;

            }
            else
            {

                return false;

            }


        }

        public static Game addUserToGame(User user)
        {

            Game game = getAnAvilableGame();

            if (game != null)
            {
                // I am not sure if the lock is needed, but I don't want threads to add to this list at the same time.
                lock (_syncLock)
                {
                    user.id = game.users.Count;
                    game.users.Add(user);
                    return game;
                }

            }
            else
            {

                return null;

            }


        }

        private static Game getAnAvilableGame()
        {
            // Try to find a game with a user space
            foreach (Game game in games)
            {

                // Check if there's a space
                if (game.users.Count >= game.maxNumberOfPlayers) continue;

                // return the game
                return game;

            }

            // Create a new game if there are no games with room for users
            return createGame();

        }

        #endregion
    }
}
