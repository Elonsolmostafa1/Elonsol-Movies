using ElonsolMovies.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElonsolMovies.BLL.Interfaces
{
    public interface IMovieRepository:IGenericRepository<Movie>
    {
        public IQueryable<Movie> SearchMovieByName(string name);
        public void AddActorToMovie(Actor actor, Movie movie);
        public Movie GetMovieWithActors(int id);

    }
}
