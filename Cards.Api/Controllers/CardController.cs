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
    using Cards.Api.Services;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class CardController : ControllerBase
    {
        private readonly DeckService service;

        public CardController(DeckService deckService)
        {
            service = deckService;
        }

        
        /// <summary>
        /// Gets a shuffled deck of cards.
        /// </summary>
        /// <returns>A shuffled deck of cards.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Card>))]
        public List<Card> Get()
        {
            return service.GetCards(1).ToList();
        }
    }
}
