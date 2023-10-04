using AutoMapper;
using ElonsolMovies.BLL;
using ElonsolMovies.BLL.Interfaces;
using ElonsolMovies.DAL.Models;
using ElonsolMovies.PL.Helpers;
using ElonsolMovies.PL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ElonsolMovies.PL.Controllers
{
    [Authorize(Roles = "Admin")]
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
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ActorViewModel actorViewModel) {
            if (ModelState.IsValid)
            {
                actorViewModel.ActorImage = DocumentSetting.UploadFile(actorViewModel.Image, "Images\\ActorImages");
                var mappedActor = new Actor()
                {
                    Name = actorViewModel.Name,
                    Biography = actorViewModel.Biography,
                    ActorImage = actorViewModel.ActorImage,
                };
                unitOfWork.ActorRepository.Add(mappedActor);
                unitOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }
            // return to the same view with the same data
            return View(actorViewModel);
        }

        public IActionResult Details(int? id, string viewName = "Details") {
                // check if the id is null return bad request
                if (id is null)
                    return BadRequest();
                // else store the actor details in actor variable
                var actor = unitOfWork.ActorRepository.Get(id.Value);
                // check if the returned actor is null return not found
                if (actor is null)
                    return NotFound();
                // else return the view and bind the actor
                var mappedActor = mapper.Map<Actor, ActorViewModel>(actor);
                return View(viewName, mappedActor);
        }

        [HttpPost]
        
        public IActionResult Delete([FromBody] int id)
        {
            try
            {
                // Validate that id is greater than 0 (assuming IDs are positive) before querying the database
                if (id <= 0)
                {
                    return Json(new { success = false, message = "Invalid actor ID" });
                }

                var actor = unitOfWork.ActorRepository.Get(id);

                // Check if the actor with the specified id exists
                if (actor == null)
                {
                    return Json(new { success = false, message = "Actor not found" });
                }

                var mappedActor = mapper.Map<Actor, ActorViewModel>(actor);

                unitOfWork.ActorRepository.Delete(actor);
                int count = unitOfWork.Complete();

                if (count > 0)
                {
                    DocumentSetting.DeleteFile(mappedActor.ActorImage, "Images\\ActorImages");
                    return Json(new { success = true, message = "Actor deleted successfully" });
                }
                else
                {
                    return Json(new { success = false, message = "Failed to delete actor" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }


        public IActionResult Update(int? id)
        {
            return Details(id , "Update");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update([FromRoute] int id , ActorViewModel actorViewModel)
        {
            var actor = unitOfWork.ActorRepository.Get(id);
            if (id != actor.ID)
                return BadRequest();
            if (ModelState.IsValid)
            {
                //var mappedEmployee = _mapper.Map<Employee, EmployeeViewModel>(employee);
                try
                {
                    actor.Name = actorViewModel.Name;
                    actor.Biography = actorViewModel.Biography;

                    unitOfWork.Complete();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(actorViewModel);
        }

    }
}


