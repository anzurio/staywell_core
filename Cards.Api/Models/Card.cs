// <copyright file="Card.cs" company="Staywell">
// Copyright (c) Staywell. All rights reserved.
// </copyright>

namespace Cards.Api.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public enum Suit
    {
        Spade,
        Heart,
        Club,
        Diamond,
    }

    public enum Value
    {
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace,
    }

    public class Card
    {
        public int Id { get; set; }

        public Suit Suit { get; set; }

        public Value Value { get; set; }

        [NotMapped]
        public string SuitName
        {
            get
            {
                return Enum.GetName(typeof(Suit), Suit);
            }
        }

        [NotMapped]
        public string ValueName
        {
            get
            {
                return Enum.GetName(typeof(Value), Value);
            }
        }

        [NotMapped]
        public string CardName
        {
            get
            {
                return $"{ValueName} of {SuitName}s";
            }
        }
    }
}
