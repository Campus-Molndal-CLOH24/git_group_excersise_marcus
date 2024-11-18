using GuessingGame.Interfaces;
using GuessingGame.Opponents;

namespace GuessingGame.Factories;
public static class OpponentFactory
{
    public static IOpponent? GetOpponent(int id)
    {
        int min = 0;
        int max = 1000;
        return id switch
        {
            1 => new Spock(min, max),
            2 => new Kirk(min, max),
            _ => null,
        };
    }

    public static IOpponent? GetOpponent(string name)
    {
        string[] names = { "spock", "kirk" };
        int pos = Array.IndexOf(names, name) + 1;
        return GetOpponent(pos);
    }
}
