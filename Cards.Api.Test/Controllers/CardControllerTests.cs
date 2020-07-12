// <copyright file="CardControllerTest.cs" company="Staywell">
// Copyright (c) Staywell. All rights reserved.
// </copyright>

namespace Cards.Api.Controllers.Test
{
    using System.Collections.Generic;
    using Cards.Api.Models;
    using Cards.Api.Test;
    using NUnit.Framework;

    public class CardControllerTests : BaseContextTests
    {
        private CardController cardsController;

        protected override void AfterSetup()
        {
            this.cardsController = new CardController(this.deckService);
        }

        [Test]
        public void Get_Invoked_ReturnsResults()
        {
            // Arrange

            // Act
            List<Card> cards = this.cardsController.Get();

            // Assert
            Assert.NotNull(cards);
            Assert.NotZero(cards.Count);
        }

        [Test]
        public void Get_InvokedTwice_ReturnsDifferentResults()
        {
            // Arrange

            // Act
            List<Card> hand1 = this.cardsController.Get();
            List<Card> hand2 = this.cardsController.Get();

            // Assert
            Assert.NotNull(hand1);
            Assert.NotNull(hand2);
            Assert.AreNotEqual(hand1, hand2);
        }
    }
}