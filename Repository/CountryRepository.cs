using Microsoft.EntityFrameworkCore;
using PokemonReviewApp.Data;
using PokReview.Interfaces;
using PokReview.Models;

namespace PokReview.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DataContext context;

        public CountryRepository(DataContext context)
        {
            this.context = context;
        }

        public ICollection<Country> GetCountries()
        {
            return context.Countries.ToList();
        }

        public Country GetCountry(int id)
        {
            return context.Countries.Where(c => c.Id == id).FirstOrDefault();
        }

        public Country GetCountryByOwner(int ownerId)
        {
            return context.Owners.Where(o => o.Id == ownerId).Select(c => c.Country).FirstOrDefault();
        }

        public ICollection<Owner> GetOwnersFromACountry(int countryId)
        {
            return context.Owners.Where(c => c.Country.Id == countryId).ToList();
        }
        public bool CountryExists(int countryId)
        {
            return context.Countries.Any(c => c.Id == countryId);
        }
    }
}
