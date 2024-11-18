using GuessingGame.Interfaces;
using System.Xml.Linq;

namespace GuessingGame.Opponents;

internal class Kirk : IOpponent
{
    int def_max = 1000;
    int def_min = 0;
    int _max = 1000;
    int _min = 0;
    int _guesses = 0;
    string _name;

    public Kirk(int min, int max, string name = "")
    {
        SetMax(max);
        SetMin(min);
        Reset();
        _name = name.Length > 0 ? name : GetType().Name;
    }

    public int Guess()
    {
        _guesses++;
        if (_guesses == 1)
        {
            var rnd = new Random();
            return rnd.Next(_min, _max + 1);
        }
        
        var guess = _min + (_max - _min) / 2;
        return guess;
    }

    public void SetMax(int max)
    {
        def_max = max;
        _max = max;
    }
    public void SetMin(int min)
    {
        def_min = min;
        _min = min;
    }
    public void Reset()
    {
        _guesses = 0;
        _max = def_max;
        _min = def_min;
    }
    public string Name { get; }
    public int Guesses { get; }

    public string IWon()
    {
        return "Piece of cake!";
    }
}