using AutoMapper;
using ElonsolMovies.BLL;
using ElonsolMovies.BLL.Interfaces;
using ElonsolMovies.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using UserApp.PL.Models;

namespace UserApp.PL.Controllers
{
    public class ActorController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ActorController(IUnitOfWork unitOfWork , IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public IActionResult Index(string SearchValue)
        {
            if (string.IsNullOrEmpty(SearchValue))
            {
                var actors = unitOfWork.ActorRepository.GetAll();
                var mappedActors = mapper.Map<IEnumerable<Actor>, IEnumerable<ActorViewModel>>(actors);
                return View(mappedActors);
            }
            else
            {
                var actors = unitOfWork.ActorRepository.SearchActorByName(SearchValue);
                var mappedEmpolyees = mapper.Map<IEnumerable<Actor>, IEnumerable<ActorViewModel>>(actors);
                return View(mappedEmpolyees);
            }
        }

        public IActionResult Details(int? id)
        {
            // check if the id is null return bad request
            if (id is null)
                return BadRequest();
            // else store the actor details in actor variable
            var actor = unitOfWork.ActorRepository.GetActorWithMovies(id.Value);
            // check if the returned actor is null return not found
            if (actor is null)
                return NotFound();
            // else return the view and bind the actor
            var mappedActor = mapper.Map<Actor, ActorViewModel>(actor);
            return View(mappedActor);
        }
    }
}
