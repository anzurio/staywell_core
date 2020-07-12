// <copyright file="Card.cs" company="Staywell">
// Copyright (c) Staywell. All rights reserved.
// </copyright>

namespace Cards.Api.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Suits of a 52 card deck.
    /// </summary>
    public enum Suit
    {
        /// <summary>
        /// Represents the Spade suit.
        /// </summary>
        Spade,
        /// <summary>
        /// Represents the Heart suit.
        /// </summary>
        Heart,
        /// <summary>
        /// Represents the Club suit.
        /// </summary>
        Club,
        /// <summary>
        /// Represents the Diamond suit.
        /// </summary>
        Diamond,
    }

    /// <summary>
    /// Values or figures of a 52 card deck.
    /// </summary>
    public enum Value
    {
        /// <summary>
        /// Represents the value 2.
        /// </summary>
        Two,
        /// <summary>
        /// Represents the value 3.
        /// </summary>
        Three,
        /// <summary>
        /// Represents the value 4.
        /// </summary>
        Four,
        /// <summary>
        /// Represents the value 5.
        /// </summary>
        Five,
        /// <summary>
        /// Represents the value 6.
        /// </summary>
        Six,
        /// <summary>
        /// Represents the value 7.
        /// </summary>
        Seven,
        /// <summary>
        /// Represents the value 8.
        /// </summary>
        Eight,
        /// <summary>
        /// Represents the value 9.
        /// </summary>
        Nine,
        /// <summary>
        /// Represents the value 10.
        /// </summary>
        Ten,
        /// <summary>
        /// Represents a Jack.
        /// </summary>
        Jack,
        /// <summary>
        /// Represents a Queen.
        /// </summary>
        Queen,
        /// <summary>
        /// Represents a King.
        /// </summary>
        King,
        /// <summary>
        /// Represents the Ace.
        /// </summary>
        Ace,
    }

    /// <summary>
    /// Represents a card from 52 card deck.
    /// </summary>
    public class Card
    {
        /// <summary>
        /// An uniquely identifying number for this card.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The suit of the card.
        /// </summary>
        public Suit Suit { get; set; }

        /// <summary>
        /// The value of the card.
        /// </summary>
        public Value Value { get; set; }

        /// <summary>
        /// This card's suit name.
        /// </summary>
        [NotMapped]
        public string SuitName
        {
            get
            {
                return Enum.GetName(typeof(Suit), Suit);
            }
        }

        /// <summary>
        /// This card's value as a string.
        /// </summary>
        [NotMapped]
        public string ValueName
        {
            get
            {
                return Enum.GetName(typeof(Value), Value);
            }
        }

        /// <summary>
        /// The complete name of this card composed by its value and its suit.
        /// </summary>
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
