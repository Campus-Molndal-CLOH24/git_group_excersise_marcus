using GuessingGame.Interfaces;
using System.Xml.Linq;

namespace GuessingGame.Opponents;

internal class Spock : IOpponent
{
    private int def_max = 1000;
    private int def_min = 0;
    private int _max = 1000;
    private int _min = 0;
    private int _guesses = 0;
    private string _name;

    public Spock(int min, int max, string name = "")
    {
        SetMax(max);
        SetMin(min);
        Reset();
        _name = name.Length > 0 ? name : GetType().Name;
    }
    public int Guess()
    {
        _guesses++;
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

    public string Name
    {
        get
        {
            return _name;
        }
    }


    public int Guesses => _guesses;

    public string IWon()
    {
        return "It was simple!";
    }
}