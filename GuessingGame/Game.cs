using GuessingGame.Factories;
using GuessingGame.Interfaces;

internal class Game
{
    public Game()
    {
        // Tom konstruktor – kan användas för framtida konfiguration eller initialisering om det behövs.
    }

    /// <summary>
    /// Startar spelet och hanterar spelets gång.
    /// </summary>
    internal void Start()
    {
        // Introduktion till spelet
        Console.WriteLine("Do you want to play a game?");
        Console.WriteLine("First, select your opponent");
        Console.WriteLine("+-----------------+");
        Console.WriteLine("| 1. Spock        |");
        Console.WriteLine("| 2. Kirk         |");
        Console.WriteLine("+-----------------+");

        // Frågar användaren vilken motståndare de vill spela mot
        int opId = AskNumber(1, 2);

        // Skapar en motståndare via OpponentFactory
        IOpponent? opponent = OpponentFactory.GetOpponent(opId);
        if (opponent == null)
        {
            // Felhantering om något går fel vid skapandet av motståndaren
            Console.WriteLine("Something went wrong");
            Environment.Exit(99);
        }

        string opName = opponent.Name;
        Console.WriteLine($"You chose {opName}");
        Console.WriteLine();
        Console.WriteLine("Now think of a number between 1 and 1000");
        Console.WriteLine($"{opName} will try to guess it");

        bool guessedRight = false;

        // Spelets huvudloop
        while (!guessedRight)
        {
            // Motståndaren gissar ett tal
            int guess = opponent.Guess();
            Console.WriteLine($"{opName} guesses {guess}");
            Console.WriteLine("Is this your number?");
            Console.WriteLine("+-----------------+");
            Console.WriteLine("| 1. Too low      |");
            Console.WriteLine("| 2. Too high     |");
            Console.WriteLine("| 3. Correct      |");
            Console.WriteLine("+-----------------+");

            // Få användarens feedback på gissningen
            int response = AskNumber(1, 3);

            if (response == 3)
            {
                // Om motståndaren gissar rätt
                Console.WriteLine(opponent.IWon());
                Console.WriteLine($"It took me {opponent.Guesses} guesses");
                guessedRight = true;
            }
            else
            {
                // Justera intervallet beroende på användarens feedback
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

    /// <summary>
    /// Frågar användaren efter ett nummer inom ett angivet intervall.
    /// </summary>
    /// <param name="min">Minsta tillåtna värde.</param>
    /// <param name="max">Största tillåtna värde.</param>
    /// <returns>Ett giltigt heltal inom intervallet.</returns>
    private int AskNumber(int min, int max)
    {
        int num = -1;

        // Fortsätt fråga tills ett giltigt nummer ges
        while (num < min || num > max)
        {
            Console.Write("Enter a number: ");
            var input = Console.ReadLine();

            // Kontrollera om inmatningen är ett giltigt heltal
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
