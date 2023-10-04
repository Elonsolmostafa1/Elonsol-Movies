using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ElonsolMovies.PL.Models
{
    public class ActorViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public string Biography { get; set; }

        public string ActorImage { get; set; }
        public IFormFile Image { get; set; }
    }
}
