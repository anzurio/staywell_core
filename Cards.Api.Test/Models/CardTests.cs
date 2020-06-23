// <copyright file="CardControllerTest.cs" company="Staywell">
// Copyright (c) Staywell. All rights reserved.
// </copyright>

namespace Cards.Api.Test.Models
{
    using Cards.Api.Models;
    using NUnit.Framework;

    public class CardTests
    {
        private Card card;
        private readonly int cardId = 1000;
        private readonly Suit cardSuit = Suit.Diamond;
        private readonly Value cardValue = Value.Two;

        [SetUp]
        public void Setup()
        {
            this.card = new Card()
            {
                Id = this.cardId,
                Suit = this.cardSuit,
                Value = this.cardValue,
            };
        }

        [Test]
        public void GetId_Invoked_RetunsExpectedValue()
        {
            // Arrange

            // Act

            // Assert
            Assert.AreEqual(this.card.Id, this.cardId);
        }

        [Test]
        public void GetSuit_Invoked_RetunsExpectedValue()
        {
            // Arrange

            // Act

            // Assert
            Assert.AreEqual(this.card.Suit, this.cardSuit);
        }

        [Test]
        public void GetValue_Invoked_RetunsExpectedValue()
        {
            // Arrange

            // Act

            // Assert
            Assert.AreEqual(this.card.Value, this.cardValue);
        }

        [Test]
        public void GetSuitName_Invoked_RetunsExpectedValue()
        {
            // Arrange

            // Act

            // Assert
            Assert.AreEqual(this.card.SuitName, "Diamond");
        }

        [Test]
        public void GetValueName_Invoked_RetunsExpectedValue()
        {
            // Arrange

            // Act

            // Assert
            Assert.AreEqual(this.card.ValueName, "Two");
        }

        [Test]
        public void GetCardName_Invoked_RetunsExpectedValue()
        {
            // Arrange

            // Act

            // Assert
            Assert.AreEqual(this.card.CardName, "Two of Diamonds");
        }
    }
}
