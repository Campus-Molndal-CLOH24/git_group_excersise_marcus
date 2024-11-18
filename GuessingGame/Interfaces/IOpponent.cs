namespace GuessingGame.Interfaces;

public interface IOpponent
{
    public int Guess();

    public void SetMax(int max);

    public void SetMin(int min);

    public void Reset();

    public string Name { get; }
    public int Guesses { get; }

    public string IWon();

}