﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using PokReview.Models;
using static System.Net.Mime.MediaTypeNames;

namespace PokemonReviewApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Pokemon> Pokemon { get; set; }
        public DbSet<PokemonOwner> PokemonOwners { get; set; }
        public DbSet<PokemonCategory> PokemonCategories { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Reviewer> Reviewers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PokemonCategory>()
                    .HasKey(pc => new { pc.PokemonId, pc.CategoryId });
            modelBuilder.Entity<PokemonCategory>()
                    .HasOne(p => p.Pokemon)
                    .WithMany(pc => pc.PokemonCategories)
                    .HasForeignKey(p => p.PokemonId);
            modelBuilder.Entity<PokemonCategory>()
                    .HasOne(p => p.Category)
                    .WithMany(pc => pc.PokemonCategories)
                    .HasForeignKey(c => c.CategoryId);

            modelBuilder.Entity<PokemonOwner>()
                    .HasKey(po => new { po.PokemonId, po.OwnerId });
            modelBuilder.Entity<PokemonOwner>()
                    .HasOne(p => p.Pokemon)
                    .WithMany(po => po.PokemonOwners)
                    .HasForeignKey(p => p.PokemonId);
            modelBuilder.Entity<PokemonOwner>()
                    .HasOne(p => p.Owner)
                    .WithMany(po => po.PokemonOwners)
                    .HasForeignKey(o => o.OwnerId);


            modelBuilder.Entity<Pokemon>().HasData(new
            {
                Id = 1,
                Name = "Pikachu",
                BirthDate = new DateTime(1903, 1, 1),
            },
            new
            {
                Id = 2,
                Name = "Squirtle",
                BirthDate = new DateTime(1903, 1, 1),
            },
            new
            {
                Id = 3,
                Name = "Venasuar",
                BirthDate = new DateTime(1903, 1, 1),
            });
            modelBuilder.Entity<Reviewer>().HasData(new
            {
                Id = 1,
                FirstName = "Teddy",
                LastName = "Smith"
            },
            new
            {
                Id = 2,
                FirstName = "Taylor",
                LastName = "Jones"
            },
            new
            {
                Id = 3,
                FirstName = "Jessica",
                LastName = "McGregor"
            });
            modelBuilder.Entity<Country>().HasData(new
            {
                Id = 1,
                Name = "Kanto"
            },
            new
            {
                Id = 2,
                Name = "Saffron City"
            },
            new
            {
                Id = 3,
                Name = "Millet Town"
            });
            modelBuilder.Entity<Owner>().HasData(new
            {
                Id = 1,
                FirstName = "Jack",
                LastName = "London",
                Gym = "Brocks Gym",
                CountryId = 1

            },
            new
            {
                Id = 2,
                FirstName = "Harry",
                LastName = "Potter",
                Gym = "Mistys Gym",
                CountryId = 2
            },
            new
            {
                Id = 3,
                FirstName = "Ash",
                LastName = "Ketchum",
                Gym = "Ashs Gym",
                CountryId = 3
            });
            modelBuilder.Entity<Category>().HasData(new
            {
                Id = 1,
                Name = "Electric"
            },
            new
            {
                Id = 2,
                Name = "Water"
            },
            new
            {
                Id = 3,
                Name = "Leaf"
            });
            modelBuilder.Entity<Review>().HasData(new
            {
                Id = 1,
                Title = "Pikachu",
                Text = "Pickahu is the best pokemon, because it is electric",
                Rating = 5,
                ReviewerId = 1,
                PokemonId = 1
            },
            new
            {
                Id = 2,
                Title = "Pikachu",
                Text = "Pickachu is the best a killing rocks",
                Rating = 5,
                ReviewerId = 2,
                PokemonId = 1
            },
            new
            {
                Id = 3,
                Title = "Pikachu",
                Text = "Pickchu, pickachu, pikachu",
                Rating = 1,
                ReviewerId = 3,
                PokemonId = 1
            },
            new
            {
                Id = 4,
                Title = "Squirtle",
                Text = "squirtle is the best pokemon, because it is electric",
                Rating = 5,
                ReviewerId = 1,
                PokemonId = 2
            },
            new
            {
                Id = 5,
                Title = "Squirtle",
                Text = "Squirtle is the best a killing rocks",
                Rating = 5,
                ReviewerId = 2,
                PokemonId = 2
            },
            new
            {
                Id = 6,
                Title = "Squirtle",
                Text = "squirtle, squirtle, squirtle",
                Rating = 1,
                ReviewerId = 3,
                PokemonId = 2
            },
            new
            {
                Id = 7,
                Title = "Veasaur",
                Text = "Venasuar is the best pokemon, because it is electric",
                Rating = 5,
                ReviewerId = 1,
                PokemonId = 3
            },
            new
            {
                Id = 8,
                Title = "Veasaur",
                Text = "Venasuar is the best a killing rocks",
                Rating = 5,
                ReviewerId = 2,
                PokemonId = 3
            },
            new
            {
                Id = 9,
                Title = "Veasaur",
                Text = "Venasuar, Venasuar, Venasuar",
                Rating = 1,
                ReviewerId = 3,
                PokemonId = 3
            });
            modelBuilder.Entity<PokemonCategory>().HasData(new
            {
                PokemonId = 1,
                CategoryId = 1
            },
            new
            {
                PokemonId = 2,
                CategoryId = 2
            },
            new
            {
                PokemonId = 3,
                CategoryId = 3
            });
            modelBuilder.Entity<PokemonOwner>().HasData(new
            {
                PokemonId = 1,
                OwnerId = 1
            },
            new
            {
                PokemonId = 2,
                OwnerId = 2
            },
            new
            {
                PokemonId = 3,
                OwnerId = 3
            });

        }
    }
}