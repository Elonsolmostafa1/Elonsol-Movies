using ElonsolMovies.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElonsolMovies.DAL.Contexts
{
    public class ElonsolMovieDbContext : IdentityDbContext<ApplicationUser>
    {
        public ElonsolMovieDbContext(DbContextOptions<ElonsolMovieDbContext> options) : base(options) { }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }

    }
}
