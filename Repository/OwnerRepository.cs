﻿using Microsoft.EntityFrameworkCore;
using PokemonReviewApp.Data;
using PokReview.Interfaces;
using PokReview.Models;

namespace PokReview.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly DataContext context;
        public OwnerRepository(DataContext context)
        {
            this.context = context;
        }
        public Owner GetOwner(int ownerId)
        {
            return context.Owners.Where(o => o.Id == ownerId).FirstOrDefault();
        }

        public ICollection<Owner> GetOwnerOfAPokemon(int pokeId)
        {
            return context.PokemonOwners.Where(p => p.Pokemon.Id == pokeId).Select(o => o.Owner).ToList();
        }

        public ICollection<Owner> GetOwners()
        {
            return context.Owners.OrderBy(p => p.Id).ToList();
        }

        public ICollection<Pokemon> GetPokemonByOwner(int ownerId)
        {
            return context.PokemonOwners.Where(p => p.Owner.Id == ownerId).Select(p => p.Pokemon).ToList();
        }

        public bool OwnerExists(int ownerId)
        {
            return context.Owners.Any(o => o.Id == ownerId);
        }
    }
}
