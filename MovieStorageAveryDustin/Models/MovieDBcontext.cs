using System;
using Microsoft.EntityFrameworkCore;

namespace MovieStorageAveryDustin.Models
{
    public class MovieDBcontext :DbContext
    {
       public MovieDBcontext(DbContextOptions<MovieDBcontext> options): base(options)
        {

        }

        public DbSet<MovieResponse> Movies { get; set; }
    }
}

