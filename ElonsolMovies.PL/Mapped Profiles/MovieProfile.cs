using AutoMapper;
using ElonsolMovies.DAL.Models;
using ElonsolMovies.PL.Models;

namespace ElonsolMovies.PL.Mapped_Profiles
{
    public class MovieProfile:Profile
    {
        public MovieProfile()
        {
            CreateMap<MovieViewModel, Movie>().ReverseMap();
        }
    }
}
