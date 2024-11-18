using GuessingGame.Interfaces;

namespace GuessingGame.Opponents
{
    /// <summary>
    /// Representerar en motståndare med namnet "Kirk" som implementerar strategier för gissningsspelet.
    /// </summary>
    internal class Kirk : IOpponent
    {
        // Standardvärden för gissningsintervallet
        int def_max = 1000;
        int def_min = 0;

        // Nuvarande gränser för gissningsintervallet
        int _max = 1000;
        int _min = 0;

        // Räknare för antal gissningar
        int _guesses = 0;

        // Motståndarens namn
        string _name;

        /// <summary>
        /// Skapar en ny instans av Kirk med angivna min- och maxvärden.
        /// </summary>
        /// <param name="min">Minsta värdet för gissningar.</param>
        /// <param name="max">Största värdet för gissningar.</param>
        /// <param name="name">Valfritt namn på motståndaren. Om inget anges används klassens namn.</param>
        public Kirk(int min, int max, string name = "")
        {
            SetMax(max);
            SetMin(min);
            Reset();
            _name = name.Length > 0 ? name : GetType().Name;
        }

        /// <summary>
        /// Gör en gissning baserat på tidigare gissningar och intervallet.
        /// </summary>
        /// <returns>Gissat tal inom intervallet.</returns>
        public int Guess()
        {
            _guesses++; // Ökar antalet gissningar

            if (_guesses == 1)
            {
                // Första gissningen är slumpmässig inom intervallet
                var rnd = new Random();
                return rnd.Next(_min, _max + 1);
            }

            // För efterföljande gissningar används en binär sökstrategi
            var guess = _min + (_max - _min) / 2;
            return guess;
        }

        /// <summary>
        /// Sätter det maximala värdet för gissningsintervallet.
        /// </summary>
        /// <param name="max">Nytt maximalt värde.</param>
        public void SetMax(int max)
        {
            def_max = max; // Uppdaterar standardvärdet
            _max = max;    // Uppdaterar nuvarande värde
        }

        /// <summary>
        /// Sätter det minsta värdet för gissningsintervallet.
        /// </summary>
        /// <param name="min">Nytt minsta värde.</param>
        public void SetMin(int min)
        {
            def_min = min; // Uppdaterar standardvärdet
            _min = min;    // Uppdaterar nuvarande värde
        }

        /// <summary>
        /// Återställer motståndarens status, inklusive antal gissningar och intervallets gränser.
        /// </summary>
        public void Reset()
        {
            _guesses = 0;     // Nollställer gissningsräknaren
            _max = def_max;   // Återställer nuvarande maxvärde
            _min = def_min;   // Återställer nuvarande minvärde
        }

        /// <summary>
        /// Hämtar motståndarens namn.
        /// </summary>
        public string Name => _name;

        /// <summary>
        /// Hämtar antalet gissningar som motståndaren har gjort.
        /// </summary>
        public int Guesses => _guesses;

        /// <summary>
        /// Returnerar ett vinnande meddelande från motståndaren.
        /// </summary>
        /// <returns>En sträng som signalerar att motståndaren har vunnit.</returns>
        public string IWon()
        {
            return "Piece of cake!";
        }
    }
}
