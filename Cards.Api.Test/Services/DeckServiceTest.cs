namespace Cards.Api.Services.Test
{
    using System.Linq;
    using Cards.Api.Test;
    using NUnit.Framework;

    public class DeckServiceTest : BaseContextTests
    {
        protected override void AfterSetup()
        {
        }

        public void GetCards_InvokedTwice_ReturnsDifferentResults()
        {
            // Arrange
            var randomNumber = rnd.Next(1, 10);

            // Act
            var hand1 = deckService.GetCards(randomNumber);
            var hand2 = deckService.GetCards(randomNumber);

            // Assert
            Assert.NotNull(hand1);
            Assert.NotNull(hand2);
            Assert.AreNotEqual(hand1, hand2);
        }

        [Test]
        public void GetCards_Invoked_ReturnsCorrectNumberOfCards()
        {
            // Arrange
            var randomNumber = rnd.Next(1, 10);

            // Act
            var hand1 = deckService.GetCards(randomNumber);

            // Assert
            Assert.AreEqual(randomNumber * 52, hand1.Count());
        }

        [Test]
        public void GetCards_Invoked_ReturnsCorrectCards()
        {
            // Arrange
            var randomNumber = rnd.Next(1, 10);

            // Act
            var hand1 = deckService.GetCards(randomNumber);
            var groups = hand1.GroupBy(x => x.CardName);

            // Assert
            Assert.AreEqual(52, groups.Count(), "Distinct cards");
            Assert.True(groups.All(x => x.Count() == randomNumber), "Every card is repeated exactly as many time the number of decks requested");
        }

        [Test]
        public void GetCards_InvokedWithZero_ReturnEmpty()
        {
            // Act
            var hand1 = deckService.GetCards(0);

            // Assert
            Assert.NotNull(hand1);
            Assert.AreEqual(0, hand1.Count());
        }

    }
}
