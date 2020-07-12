namespace Cards.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Cards.Api.Models;
    using Cards.Api.Services;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class DeckController : ControllerBase
    {
        private readonly DeckService service;
        public DeckController(DeckService deckService)
        {
            service = deckService;
        }

        /// <summary>
        /// Gets a shuffled collection of cards from <paramref name="count"/> decks.
        /// </summary>
        /// <param name="count">The numbers of decks to get.</param>
        /// <returns>The collection of cards.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Card>))]
        public List<Card> Get(int count)
        {
            if (count < 0)
            {
                throw new ArgumentException($"{nameof(count)} must be greater or equal to zero.");
            }
            return service.GetCards(count).ToList();
        }
    }
}
