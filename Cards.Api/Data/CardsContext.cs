// <copyright file="CardsContext.cs" company="Staywell">
// Copyright (c) Staywell. All rights reserved.
// </copyright>

namespace Cards.Api.Data
{
    using Cards.Api.Models;
    using Microsoft.EntityFrameworkCore;

    public class CardsContext : DbContext
    {
        public CardsContext(DbContextOptions<CardsContext> options)
            : base(options)
        {
        }

        public DbSet<Card> Cards { get; set; }
    }
}
