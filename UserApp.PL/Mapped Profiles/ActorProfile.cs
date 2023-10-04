using AutoMapper;
using ElonsolMovies.DAL.Models;
using UserApp.PL.Models;

namespace UserApp.PL.Mapped_Profiles
{
    public class ActorProfile : Profile
    {
        public ActorProfile()
        {
            CreateMap<ActorViewModel, Actor>().ReverseMap();
        }
    }
}
