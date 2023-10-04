using ElonsolMovies.BLL.Interfaces;
using ElonsolMovies.DAL.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElonsolMovies.BLL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ElonsolMovieDbContext _dbContext;

        public GenericRepository(ElonsolMovieDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(T item)
        {
            _dbContext.Set<T>().AddAsync(item);
        }

        public void Delete(T item)
        {
            _dbContext.Set<T>().Remove(item);
        }

        public T Get(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        public void Update(T item)
        {
            _dbContext.Set<T>().Update(item);
        }
    }
}
