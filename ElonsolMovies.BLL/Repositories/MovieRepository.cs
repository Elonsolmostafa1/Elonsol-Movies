using ElonsolMovies.BLL.Interfaces;
using ElonsolMovies.DAL.Contexts;
using ElonsolMovies.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElonsolMovies.BLL.Repositories
{
    public class MovieRepository: GenericRepository<Movie> , IMovieRepository
    {
        private readonly ElonsolMovieDbContext dbContext;

        public MovieRepository(ElonsolMovieDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public IQueryable<Movie> SearchMovieByName(string name)
        {
            return dbContext.Movies.Where(m=>m.Name.ToLower().Contains(name.ToLower()));
        }

        public void AddActorToMovie(Actor actor, Movie movie)
        {
            if (movie != null && actor != null && !movie.Actors.Contains(actor))
            {
                movie.Actors.Add(actor);
            }
        }

        public Movie GetMovieWithActors (int id)
        {
            return dbContext.Movies.Include(m => m.Actors).FirstOrDefault(m => m.Id == id);
        }
    }
}
