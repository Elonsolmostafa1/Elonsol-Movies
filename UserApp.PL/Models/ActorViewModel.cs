using ElonsolMovies.DAL.Models;
using System.Collections.Generic;

namespace UserApp.PL.Models
{
    public class ActorViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public string Biography { get; set; }

        public string ActorImage { get; set; }

        public virtual ICollection<Movie> Movies { get; set; } = new HashSet<Movie>();
    }
}
