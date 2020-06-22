// <copyright file="DataGenerator.cs" company="Staywell">
// Copyright (c) Staywell. All rights reserved.
// </copyright>

namespace Cards.Api.Data
{
    using System;
    using System.Linq;
    using Cards.Api.Models;

    public class DataGenerator
    {
        public static void Initialize(CardsContext context)
        {
            if (context.Cards.Any())
            {
                return;
            }

            foreach (Suit suit in (Suit[])Enum.GetValues(typeof(Suit)))
            {
                foreach (Value value in (Value[])Enum.GetValues(typeof(Value)))
                {
                    context.Cards.Add(new Card() { Suit = suit, Value = value, });
                }
            }

             context.SaveChanges();
        }
    }
}
