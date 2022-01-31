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
    }
}
