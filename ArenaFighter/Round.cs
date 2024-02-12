using System;
using System.Text;

namespace ArenaFighter
{
    /// <summary>
    /// The round function class
    /// </summary>
    public class Round
    {
        /// <summary>
        /// Score for result of this round
        /// </summary>
        enum Score
        {
            Lost = 3,
            Tied = 5,
            Win = 20
        }

        /// <summary>
        /// A factor for real damage
        /// </summary>
        const int DAMAGE = 2;

        /// <summary>
        /// Create new round in the battle
        /// </summary>
        /// <param name="battle">The battle that own this new round</param>
        public Round(Battle battle)
        {
            // Create comparative figures for character in round
            int[] t = new int[2] { battle.Player.Strength + Program.random.Next(1, 6), battle.Opponent.Strength + Program.random.Next(1, 6) };
            int realdamage;

            // Tell the user that new round are begin
            string message = "New round in the battle are begin";
            Console.WriteLine(message);

            // Start message for battle log
            message = $"{battle.Player.Name} hit {battle.Opponent.Name} and {battle.Opponent.Name} hit {battle.Player.Name}.";

            // Check which character win this round
            if (t[0] == t[1])
            {
                // This round result were tied
                message += "This round result were tied.";
                Console.WriteLine("This round result were tied");

                // Add value into character score
                battle.Player.Score += (int)Score.Tied;
                battle.Opponent.Score += (int)Score.Tied;

            }
            else if (t[0] > t[1])
            {
                // This round result were that player win
                char answer;
                realdamage = t[0] + DAMAGE;

                // Add text to message and change the opponent health
                message += $"{battle.Player.Name} win this round and give  {realdamage} damage on {battle.Opponent.Name} health.";
                Console.WriteLine($"{battle.Player.Name} win this round and give  {realdamage} damage on {battle.Opponent.Name} health.");
                battle.Opponent.Health -= realdamage;

                // Add value into character score
                battle.Player.Score += (int)Score.Win;
                battle.Opponent.Score += (int)Score.Lost;

                // Ask the user if they will give up the battle
                Console.Write("You win this round, will you give up? Y/N ");
                answer = Console.ReadKey().KeyChar;

                Console.WriteLine();

                // Check the answer the user give
                if (answer.Equals('Y') || answer.Equals('y'))
                    battle.Player.IsRetired = true;
            }
            else
            {
                // This round result were that opponent win.
                realdamage = t[1] * DAMAGE;

                message += $"{battle.Opponent.Name} win this round give {realdamage} damage on {battle.Player.Name} health.";
                Console.WriteLine($"Your opponent win this round and give {realdamage} damage on your health.");
                
                battle.Player.Health -= realdamage;

                // Add value into character score
                battle.Player.Score += (int)Score.Lost;
                battle.Opponent.Score += (int)Score.Win;
            }
            // Send message to battle log
            battle.WriteToLog(message);
        }
    }
}
