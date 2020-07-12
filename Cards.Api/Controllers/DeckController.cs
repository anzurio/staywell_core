namespace Cards.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Cards.Api.Models;
    using Cards.Api.Services;
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

        [HttpGet]
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
