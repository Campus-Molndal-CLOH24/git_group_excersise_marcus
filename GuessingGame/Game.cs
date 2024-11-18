// See https://aka.ms/new-console-template for more information

using GuessingGame.Opponents;
using GuessingGame.Interfaces;
using GuessingGame.Factories;

internal class Game
{
    public Game()
    {
    }

    internal void Start()
    {
        // Play the game
        Console.WriteLine("Do you want to play a game?");
        Console.WriteLine("First, select your opponent");
        Console.WriteLine("+-----------------+");
        Console.WriteLine("| 1. Spock        |");
        Console.WriteLine("| 2. Kirk         |");
        Console.WriteLine("+-----------------+");

        int opId = AskNumber(1, 2);
        IOpponent opponent = OpponentFactory.GetOpponent(opId);
        if (opponent == null)
        {
            Console.WriteLine("Something went wrong");
            Environment.Exit(99);
        }

        string opName = opponent.Name;
        Console.WriteLine("You chose {0}", opName);
        Console.WriteLine();
        Console.WriteLine("Now think of a number between 1 and 1000");
        Console.WriteLine("{0} try to guess it", opName);

        bool guessedRight = false;
        while (!guessedRight)
        {
            int guess = opponent.Guess();
            Console.WriteLine("{0} guesses {1}", opName, guess);
            Console.WriteLine("Is this your number?");
            Console.WriteLine("+-----------------+");
            Console.WriteLine("| 1. Too low      |");
            Console.WriteLine("| 2. Too high     |");
            Console.WriteLine("| 3. Correct      |");
            Console.WriteLine("+-----------------+");
            int response = AskNumber(1, 3);
            if (response == 3)
            {
                Console.WriteLine(opponent.IWon());
                Console.WriteLine("It took me {0} guesses", opponent.Guesses);
                guessedRight = true;
            }
            else
            {
                if (response == 1)
                {
                    opponent.SetMin(guess + 1);
                }
                else
                {
                    opponent.SetMax(guess - 1);
                }
            }
        }
    }

    private int AskNumber(int min, int max)
    {
        int num = -1;
        while (num < min || num > max)
        {
            Console.Write("Enter a number: ");
            var input = Console.ReadLine();
            if (int.TryParse(input, out num))
            {
                if (num < min || num > max)
                {
                    Console.WriteLine($"Please enter a number between {min} and {max}");
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid number");
            }
        }
        return num;
    }
}