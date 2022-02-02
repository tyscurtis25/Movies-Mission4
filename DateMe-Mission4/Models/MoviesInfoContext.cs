using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DateMe_Mission4.Models
{
    public class MoviesInfoContext : DbContext
    {
        //Constructor
        public MoviesInfoContext(DbContextOptions<MoviesInfoContext> options) : base(options)
        {
            //leave blank for now
        }

        public DbSet<Movies> Responses { get; set; }
        public DbSet<Category> Categories { get; set; }

        //seed data
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryID=1, CategoryName="Action/Adventure"},
                new Category { CategoryID=2, CategoryName="Family" },
                new Category { CategoryID=3, CategoryName="Drama" },
                new Category { CategoryID=4, CategoryName="Comedy" }
            );

            mb.Entity<Movies>().HasData(

                new Movies
                {
                    MovieID = 1,
                    Title = "The Dark Knight",
                    Year = 2008,
                    Director = "Christopher Nolan",
                    Rating = "PG-13",
                    Edited = false,
                    Lent_to = "yeah",
                    Notes = 10,
                    CategoryID = 1

                },

                new Movies
                {
                    MovieID = 2,
                    Title = "Spider-Man 2",
                    Year = 2004,
                    Director = "Sam Raimi",
                    Rating = "PG-13",
                    Edited = false,
                    Lent_to = "yeah",
                    Notes = 10,
                    CategoryID = 1
                },

                new Movies
                {
                    MovieID = 5,
                    Title = "The Incredibles",
                    Year = 2004,
                    Director = "Brad Bird",
                    Rating = "PG",
                    Edited = false,
                    Lent_to = "yeah",
                    Notes = 10,
                    CategoryID = 2
                }
            );
        }
    }
}
