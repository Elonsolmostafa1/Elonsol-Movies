using AutoMapper;
using ElonsolMovies.DAL.Models;
using UserApp.PL.Models;

namespace UserApp.PL.Mapped_Profiles
{
    public class MovieProfile:Profile
    {
        public MovieProfile()
        {
            CreateMap<MovieViewModel, Movie>().ReverseMap();
        }
    }
}
