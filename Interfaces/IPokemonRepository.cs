﻿using PokReview.Models;

namespace PokReview.Interfaces
{
    public interface IPokemonRepository
    {
        ICollection<Pokemon> GetPokemons();
        Pokemon GetPokemon(int id);
        Pokemon GetPokemon(string name);
        decimal GetPokemonRating(int pokeId);
        bool PokemonExists(int pokeID);
    }
}
