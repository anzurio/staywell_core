// <copyright file="CardControllerTest.cs" company="Staywell">
// Copyright (c) Staywell. All rights reserved.
// </copyright>

namespace Cards.Api.Controllers.Test
{
    using System;
    using System.Collections.Generic;
    using Cards.Api.Controllers;
    using Cards.Api.Data;
    using Cards.Api.Models;
    using Cards.Api.Services;
    using Microsoft.EntityFrameworkCore;
    using NUnit.Framework;

    public class CardControllerTests
    {
        private CardController cardsController;
        private DeckService deckService;
        private CardsContext cardsContext;

        [SetUp]
        public void Setup()
        {
            var rnd = new Random(DateTime.UtcNow.Millisecond);
            this.cardsContext = new CardsContext(new DbContextOptionsBuilder<CardsContext>()
                .UseInMemoryDatabase(databaseName: $"Cards_{rnd.Next()}")
                .Options);

            DataGenerator.Initialize(this.cardsContext);

            this.deckService = new DeckService(cardsContext);
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