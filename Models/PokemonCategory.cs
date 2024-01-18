namespace PokReview.Models
{
    public class PokemonCategory
    {
        public int PokemonId { get; set; }
        public int CategoryId { get; set; }
        public Pokemon Pokemon { get; set; } = default!;
        public Category Category { get; set; } = default!;
    }
}
