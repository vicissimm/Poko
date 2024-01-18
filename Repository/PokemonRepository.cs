using PokemonReviewApp.Data;
using PokReview.Interfaces;
using PokReview.Models;

namespace PokReview.Repository
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly DataContext context;

        public PokemonRepository(DataContext context)
        {
            this.context = context;
        }

        public Pokemon GetPokemon(int id)
        {
            return context.Pokemon.Where(p => p.Id == id).FirstOrDefault();
        }

        public Pokemon GetPokemon(string name)
        {
            return context.Pokemon.Where(p => p.Name == name).FirstOrDefault();
        }
            
        public decimal GetPokemonRating(int pokeId)
        {
            var review = context.Reviews.Where(p => p.Pokemon.Id  == pokeId);
            if(review.Count() <= 0)
                return 0;
            return ((decimal)review.Sum(r => r.Rating) / review.Count());

        }
        public bool PokemonExists(int pokeID)
        {
            return context.Pokemon.Any(p => p.Id == pokeID);
        }

        public ICollection<Pokemon> GetPokemons()
        {
            return context.Pokemon.OrderBy(p => p.Id).ToList();
        }

    }
}
