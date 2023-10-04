using ElonsolMovies.DAL.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ElonsolMovies.PL.Models
{
    public class MovieViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string genre { get; set; }

        public string Poster { get; set; }
        public IFormFile PosterImage { get; set; }
        public string Cover { get; set; }
        public IFormFile CoverImage { get; set; }
        public string Description { get; set; }

        public string Director { get; set; }

        public string Writer { get; set; }

        public int PublishYear { get; set; }

        public string TrailerLink { get; set; }
    }
}
