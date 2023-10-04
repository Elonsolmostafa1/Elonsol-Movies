using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ElonsolMovies.DAL.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Movie Name is required")]
        public string Name { get; set; }
        public string genre { get; set; }

        public string Poster { get; set; }

        public string Cover { get; set; }

        // Actors will be represented as a collection of Actor objects
        public virtual ICollection<Actor> Actors { get; set; } = new HashSet<Actor>();

        public string Description { get; set; }

        public string Director { get; set; }

        public string Writer { get; set; }

        [Display(Name = "Publish Year")]
        public int PublishYear { get; set; }

        public string TrailerLink { get; set; }
    }
}
