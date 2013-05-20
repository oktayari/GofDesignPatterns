namespace GoFPatternsLibAdv.BehavioralPatterns
{
    //that defines the program skeleton of an algorithm in a method
    /// <summary>
    ///     the template method pattern is a behavioral design pattern that defines the program skeleton of an algorithm in a method,
    ///     called template method, which defers some steps to subclasses.[1]
    ///     It lets one redefine certain steps of an algorithm without changing the algorithm's structure
    /// </summary>
    internal class TemplateMethodPattern
    {
        public void TestTemplate()
        {
            Game game = new Chess();
            game.PlayOneGame(2);


            game = new Monopoly();
            game.PlayOneGame(4);
        }

        private class Chess : Game
        {
            /* Implementation of necessary concrete methods */

            protected override void InitializeGame()
            {
                // Initialize players
                // Put the pieces on the board
            }

            protected override void MakePlay(int player)
            {
                // Process a turn for the player
            }

            protected override bool EndOfGame()
            {
                // Return true if in Checkmate or 
                // Stalemate has been reached
                return true;
            }

            protected override void PrintWinner()
            {
                // Display the winning player
            }

            /* Specific declarations for the chess game. */

            // ...
        }

        private abstract class Game
        {
            private int PlayersCount { get; set; }

            protected abstract void InitializeGame();
            protected abstract void MakePlay(int player);
            protected abstract bool EndOfGame();
            protected abstract void PrintWinner();

            /* A template method : */

            public void PlayOneGame(int playersCount)
            {
                PlayersCount = playersCount;
                InitializeGame();
                int j = 0;
                while (!EndOfGame())
                {
                    MakePlay(j);
                    j = (j + 1)%playersCount;
                }
                PrintWinner();
            }
        }

        private class Monopoly : Game
        {
            /* Implementation of necessary concrete methods */

            protected override void InitializeGame()
            {
                // Initialize players
                // Initialize money
            }

            protected override void MakePlay(int player)
            {
                // Process one turn of player
            }

            protected override bool EndOfGame()
            {
                // Return true if game is over 
                // according to Monopoly rules
                return true;
            }

            protected override void PrintWinner()
            {
                // Display who won
            }

            /* Specific declarations for the Monopoly game. */

            // ...
        }
    }
}