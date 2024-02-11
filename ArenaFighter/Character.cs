namespace ArenaFighter
{
    /// <summary>
    /// The class for information of character in this game
    /// </summary>
    public class Character
    {
        // Some properties for information of character
        public string Name { get; set; }
        public int Strength { get; set; }
        public int Health { get; set; }

        public int Score { get; set; }
        public bool IsAlived { get; set; }
        public bool IsRetired { get; set; }


        /// <summary>
        /// Create new character
        /// </summary>
        /// <param name="initName">The name of the new character</param>
        public Character(string initName)
        {
            // Set the name of character
            Name = initName;

            // Set some other proerties start values
            Strength = Program.random.Next(1,10);
            Health = Program.random.Next(1,100);

            Score = 0;

            IsAlived = true;
            IsRetired = false;
        }
    }
}
