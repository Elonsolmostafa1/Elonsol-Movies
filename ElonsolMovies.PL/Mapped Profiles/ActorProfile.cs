using AutoMapper;
using ElonsolMovies.DAL.Models;
using ElonsolMovies.PL.Models;

namespace ElonsolMovies.PL.Mapped_Profiles
{
    public class ActorProfile:Profile
    {
        public ActorProfile()
        {
            CreateMap<ActorViewModel, Actor>().ReverseMap();
        }
    }
}
