namespace Cards.Api.Controllers.Test
{
    using System;
    using System.Collections.Generic;
    using Cards.Api.Models;
    using Cards.Api.Test;
    using NUnit.Framework;
    public class DeckControllerTests : BaseContextTests
    {
        private DeckController deckController;

        protected override void AfterSetup()
        {
            deckController = new DeckController(deckService);
        }

        [Test]
        public void Get_Invoked_ReturnsResults()
        {
            // Arrange
            var numberOfDecks = rnd.Next(1, 10);

            // Act
            List<Card> cards = this.deckController.Get(numberOfDecks);

            // Assert
            Assert.NotNull(cards);
            Assert.NotZero(cards.Count);
        }

        [Test]
        public void Get_InvokedTwice_ReturnsDifferentResults()
        {
            // Arrange
            var numberOfDecks = rnd.Next(1, 10);

            // Act
            List<Card> hand1 = this.deckController.Get(numberOfDecks);
            List<Card> hand2 = this.deckController.Get(numberOfDecks);

            // Assert
            Assert.NotNull(hand1);
            Assert.NotNull(hand2);
            Assert.AreNotEqual(hand1, hand2);
        }

        [Test]
        public void Get_InvokedWithNegativeNumber_ThrowsArgumentException()
        {
            // Assert
            Assert.Throws<ArgumentException>(() => deckController.Get(-1));
        }
    }
}
