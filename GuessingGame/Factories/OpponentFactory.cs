// Importerar nödvändiga namespaces och interfaces
using GuessingGame.Interfaces;
using GuessingGame.Opponents;

namespace GuessingGame.Factories
{
    // En statisk fabriksklass för att skapa motståndare (IOpponent).
    public static class OpponentFactory
    {
        /// <summary>
        /// Hämtar en motståndare baserat på ett ID.
        /// </summary>
        /// <param name="id">Ett heltals-ID som identifierar vilken motståndare som ska skapas.</param>
        /// <returns>En instans av en klass som implementerar IOpponent, eller null om ID:t inte matchar någon motståndare.</returns>
        public static IOpponent? GetOpponent(int id)
        {
            // Minsta och största värden som används av motståndarna.
            int min = 0;
            int max = 1000;

            // Skapar en motståndare baserat på ID med hjälp av en switch-uttryck.
            return id switch
            {
                1 => new Spock(min, max), // Skapar en Spock-motståndare om ID är 1.
                2 => new Kirk(min, max),  // Skapar en Kirk-motståndare om ID är 2.
                _ => null,               // Returnerar null om ID inte är känt.
            };
        }

        /// <summary>
        /// Hämtar en motståndare baserat på ett namn.
        /// </summary>
        /// <param name="name">Ett namn som representerar vilken motståndare som ska skapas.</param>
        /// <returns>En instans av en klass som implementerar IOpponent, eller null om namnet inte matchar.</returns>
        public static IOpponent? GetOpponent(string name)
        {
            // Lista över giltiga namn för motståndare.
            string[] names = { "spock", "kirk" };

            // Letar upp namnets position i arrayen och konverterar till ett motsvarande ID (index + 1).
            int pos = Array.IndexOf(names, name.ToLower()) + 1;

            // Återanvänder GetOpponent-metoden för att skapa motståndaren med ID.
            return GetOpponent(pos);
        }
    }
}
