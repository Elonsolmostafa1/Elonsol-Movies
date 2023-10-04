using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElonsolMovies.DAL.Models
{
    public class Actor
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public string Biography { get; set; }

        public string ActorImage { get; set; }

        // Movies will be represented as a collection of Movie objects
        public virtual ICollection<Movie> Movies { get; set; } = new HashSet<Movie>();
    }
}
