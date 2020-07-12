namespace Cards.Api.Test
{
    using System;
    using Cards.Api.Data;
    using Cards.Api.Services;
    using Microsoft.EntityFrameworkCore;
    using NUnit.Framework;

    public abstract class BaseContextTests
    {
        protected DeckService deckService;
        protected CardsContext cardsContext;
        protected Random rnd;

        [SetUp]
        public virtual void Setup()
        {
            rnd = new Random(DateTime.UtcNow.Millisecond);
            this.cardsContext = new CardsContext(new DbContextOptionsBuilder<CardsContext>()
                .UseInMemoryDatabase(databaseName: $"Cards_{rnd.Next()}")
                .Options);

            DataGenerator.Initialize(this.cardsContext);

            this.deckService = new DeckService(cardsContext);
            AfterSetup();
        }

        protected abstract void AfterSetup();
    }
}
