namespace GuessingGame.Interfaces
{
    /// <summary>
    /// Definierar ett interface för en motståndare i gissningsspelet.
    /// Ger kontrakt för att hantera gissningar och spårning av spelstatus.
    /// </summary>
    public interface IOpponent
    {
        /// <summary>
        /// Gör en gissning inom det aktuella intervallet.
        /// </summary>
        /// <returns>Det gissade talet som ett heltal.</returns>
        public int Guess();

        /// <summary>
        /// Sätter det maximala värdet för gissningsintervallet.
        /// </summary>
        /// <param name="max">Det maximala värdet.</param>
        public void SetMax(int max);

        /// <summary>
        /// Sätter det minsta värdet för gissningsintervallet.
        /// </summary>
        /// <param name="min">Det minsta värdet.</param>
        public void SetMin(int min);

        /// <summary>
        /// Återställer motståndarens interna status till ursprungsläget.
        /// </summary>
        public void Reset();

        /// <summary>
        /// Hämtar motståndarens namn.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Hämtar antalet gissningar som motståndaren har gjort.
        /// </summary>
        public int Guesses { get; }

        /// <summary>
        /// Returnerar ett meddelande som indikerar att motståndaren har vunnit.
        /// </summary>
        /// <returns>En sträng som representerar ett "Jag vann!"-meddelande.</returns>
        public string IWon();
    }
}
