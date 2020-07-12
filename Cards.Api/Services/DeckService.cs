namespace Cards.Api.Services
{
    using Cards.Api.Data;
    using Cards.Api.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DeckService
    {
        private readonly CardsContext cardsContext;
        private static readonly Random rng = new Random(DateTime.UtcNow.Millisecond);

        public DeckService(CardsContext context)
        {
            cardsContext = context;
        }

        public IEnumerable<Card> GetCards(int count)
        {
            var fullDeck = new List<Card>();
            var originalDeck = cardsContext.Cards.ToList();

            for (int i = 0; i < count; i++)
            {
                fullDeck.AddRange(originalDeck);
            }

            Shuffle(fullDeck);

            foreach (Card card in fullDeck)
            {
                yield return card;
            }
        }

        private static void Shuffle(IList<Card> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
