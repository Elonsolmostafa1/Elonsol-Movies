using ElonsolMovies.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElonsolMovies.BLL.Interfaces
{
    public interface IActorRepository: IGenericRepository<Actor>
    {
        public IQueryable<Actor> SearchActorByName(string name);
        public Actor GetActorWithMovies(int id);
    }
    
}
