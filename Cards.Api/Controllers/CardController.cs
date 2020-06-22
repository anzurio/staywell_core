// <copyright file="CardController.cs" company="Staywell">
// Copyright (c) Staywell. All rights reserved.
// </copyright>

namespace Cards.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Cards.Api.Data;
    using Cards.Api.Models;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class CardController : ControllerBase
    {
        private readonly CardsContext cardsContext;
        private static Random rng = new Random(0);

        public CardController(CardsContext context)
        {
            cardsContext = context;
        }

        [HttpGet]
        public List<Card> Get()
        {
            rng = new Random(0);

            IList<Card> deck = cardsContext.Cards.ToList();

            return Shuffle(deck).ToList();
        }

        private static IList<Card> Shuffle(IList<Card> list)
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

            return list;
        }
    }
}
