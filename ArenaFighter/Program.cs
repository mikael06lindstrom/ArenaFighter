using System;

namespace ArenaFighter
{
    /// <summary>
    /// The start class for this program
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The name of this program
        /// </summary>
        public const string ProgramName = "The Arena Fighter 2000";

        /// <summary>
        /// The instans for handle and creating of randomly values
        /// </summary>
        public static Random random = new Random();

        /// <summary>
        /// The start point of this program
        /// </summary>
        /// <param name="args">Anything</param>
        static void Main(string[] args)
        {
            // Names for character in this battle game
            string[] optName = new string[6] { "Erik", "Valter", "David", "Viktor", "Gustav", "Ulrik" };
            string name;

            // Welcome the user to this program
            Console.WriteLine($"Welcome to {ProgramName}!");

            // Make a pause in this program
            Console.ReadKey();

            // Ask the user for a name of their character
            Console.Write("Write a name for your character: ");
            name = Console.ReadLine();

            // Create instans of character class for the player character
            Character player = new Character(name);

            // Run until the player not alive or the player had choise to retired
            do
            {
                // Create a opponent character to the player
                Character opponent = new Character(optName[random.Next(0, optName.Length)]);

                // Create a new battle
                Battle battle = new Battle(player, opponent);

                // Make a pause in the game
                Console.ReadKey();

            } while (player.IsAlived == true && player.IsRetired == false);
        }
    }
}
