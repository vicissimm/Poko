﻿namespace PokReview.Models
{
    public class PokemonOwner
    {
        public int PokemonId { get; set; }
        public int OwnerId { get; set; }
        public Pokemon Pokemon { get; set; } = default!;
        public Owner Owner { get; set; } = default!;
    }
}
