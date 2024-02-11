using System;
using System.Collections.Generic;

namespace ArenaFighter
{
    /// <summary>
    /// The class for the battle itself
    /// </summary>
    public class Battle
    {
        // Properties for character information in this battle
        public Character Player { get; set; }
        public Character Opponent { get; set; }

        private IList<string> _log;

        /// <summary>
        /// Create new battle by two character
        /// </summary>
        /// <param name="player">The player character in this battle</param>
        /// <param name="opponent">The opponent character in this battle</param>
        public Battle(Character player, Character opponent)
        {
            // Set character for this battle
            Player = player;
            Opponent = opponent;

            // Create battle log as a list of string type
            _log = new List<string>();

            // Start the battle itself
            GoBattle();
        }

        /// <summary>
        /// The battle itself
        /// </summary>
        private void GoBattle()
        {
            Console.WriteLine("********** The battle are started! **********");

            
            do
            {
                // Start a new round in this battle
                Round round = new Round(this);

                // Check character health 
                if (Player.Health < 1)
                    Player.IsAlived = false;
                if(Opponent.Health < 1)
                    Opponent.IsAlived = false;

            } while (Player.IsAlived == true && Player.IsRetired == false && Opponent.IsAlived == true);

            Console.WriteLine("********** The battle are ended! **********");

            // Write a last message to the log then show the battle log
            WriteToLog($"The score for {Player.Name} are {Player.Score} and for {Opponent.Name} are {Opponent.Score}.");
            ShowTheLog();
        }

        /// <summary>
        /// Write a message to battle log
        /// </summary>
        /// <param name="message">The message that write to battle log</param>
        public void WriteToLog(string message) => _log.Add(message);

        /// <summary>
        /// Show the battle log in console window
        /// </summary>
        private void ShowTheLog()
        {
            Console.WriteLine("********** Battle log *********");
            foreach(string item in _log) 
                Console.WriteLine(item);
        }
    }
}
