using PokemonReviewApp.Data;
using PokReview.Interfaces;
using PokReview.Models;

namespace PokReview.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext context;

        public CategoryRepository(DataContext context)
        {
            this.context = context;
        }
        public ICollection<Category> GetCategories()
        {
            return context.Categories.OrderBy(c => c.Id).ToList();
        }

        public Category GetCategory(int id)
        {
           return context.Categories.Where(c => c.Id == id ).FirstOrDefault();   
        }

        public ICollection<Pokemon> GetPokemonByCategory(int categoryId)
        {
            return context.PokemonCategories.Where(e => e.CategoryId == categoryId).Select(c => c.Pokemon).ToList();
        }

        public bool CategoryExists(int id)
        {
            return context.Categories.Any(c => c.Id == id);
        }

        
    }
}
