using ElonsolMovies.BLL.Interfaces;
using ElonsolMovies.BLL.Repositories;
using ElonsolMovies.DAL.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElonsolMovies.BLL
{
    public class UnitOfWork : IUnitOfWork , IDisposable
    {
        private readonly ElonsolMovieDbContext dbContext;

        public IMovieRepository MovieRepository { get ; set; }
        public IActorRepository ActorRepository { get; set; }

        public UnitOfWork(ElonsolMovieDbContext dbContext)
        {
            // I know there is an issue here as I create object from all repositories each time I ask CLR to generate object from UOW
            // but I don't really need all objects each time
            //  ====> to be solved in Web Apis app (next version) 
            // (Solution) to make dictionary and push required objects into it at runtime

            MovieRepository = new MovieRepository(dbContext);
            ActorRepository = new ActorRepository(dbContext);
            this.dbContext = dbContext;
        }


        // I need Complete to be here to use it in controller to save changes one time only although making more that one
        // opration per request like (add - update - delete ....) it's better than saveChanges after each action in generic repository
        public int Complete()
        {
            return dbContext.SaveChanges();
        }

        // implementing Dispose as part of IDisposable to tell CLR to automatically call this mehod after the object goes out
        // of scope to close connection with database as UnitOfWork lifetime is scoped (which means it's alive in heap per request)
        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}
