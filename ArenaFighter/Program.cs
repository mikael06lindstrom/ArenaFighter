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
            // Welcome the user to this program
            Console.WriteLine($"Welcome to {ProgramName}!");

            // Make a pause in this program
            Console.ReadKey();
        }
    }
}
