using Cards.Api.Data;
using Cards.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cards.Api.Services
{
    public class DeckService
    {
        private readonly CardsContext cardsContext;
        private static Random rng = new Random(DateTime.UtcNow.Millisecond);
        
        public DeckService(CardsContext context)
        {
            cardsContext = context;
        }

        public IEnumerable<Card> GetCards(int deckCount)
        {
            throw new NotImplementedException();
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
