using ElonsolMovies.BLL.Interfaces;
using ElonsolMovies.DAL.Contexts;
using ElonsolMovies.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ElonsolMovies.BLL.Repositories
{
    public class ActorRepository:GenericRepository<Actor> , IActorRepository
    {
        private readonly ElonsolMovieDbContext dbContext;

        public ActorRepository(ElonsolMovieDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public IQueryable<Actor> SearchActorByName(string name)
        {
            return dbContext.Actors.Where(a => a.Name.ToLower().Contains(name.ToLower()));
        }

        public Actor GetActorWithMovies(int id)
        {
            return dbContext.Actors.Include(a => a.Movies).FirstOrDefault(m => m.ID == id);
        }


    }
}
