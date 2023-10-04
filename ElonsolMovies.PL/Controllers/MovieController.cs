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
using System.Linq;

namespace ElonsolMovies.PL.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MovieController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public MovieController(IUnitOfWork unitOfWork , IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public IActionResult Index(string? SearchValue)
        {
            if (string.IsNullOrEmpty(SearchValue))
            {
                var movies = unitOfWork.MovieRepository.GetAll();
                var mappedMovie = mapper.Map<IEnumerable<Movie>, IEnumerable<MovieViewModel>>(movies);
                return View(mappedMovie);
            }
            else
            {
                var movies = unitOfWork.MovieRepository.SearchMovieByName(SearchValue);
                var mappedMovies = mapper.Map<IEnumerable<Movie>, IEnumerable<MovieViewModel>>(movies);
                return View(mappedMovies);
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(MovieViewModel movieViewModel)
        {
            if (ModelState.IsValid)
            {
                movieViewModel.Poster = DocumentSetting.UploadFile(movieViewModel.PosterImage, "Images\\MovieImages");
                movieViewModel.Cover = DocumentSetting.UploadFile(movieViewModel.CoverImage, "Images\\MovieImages");
                var mappedMovie = mapper.Map<MovieViewModel,Movie>(movieViewModel);
                unitOfWork.MovieRepository.Add(mappedMovie);
                unitOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }
            // return to the same view with the same data
            return View(movieViewModel);
        }

        public IActionResult Details (int? id, string viewName = "Details")
        {
            // check if the id is null return bad request
            if (id is null)
                return BadRequest();
            // else store the movie details in movie variable
            var movie = unitOfWork.MovieRepository.Get(id.Value);
            // check if the returned movie is null return not found
            if (movie is null)
                return NotFound();
            // else return the view and bind the movie
            var mappedMovie = mapper.Map<Movie, MovieViewModel>(movie);
            return View(viewName, mappedMovie);
        }

        public IActionResult Update(int? id)
        {
            return Details(id, "Update");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update([FromRoute] int id, MovieViewModel movieViewModel)
        {
            var movie = unitOfWork.MovieRepository.Get(id);
            if (id != movie.Id)
                return BadRequest();
            
            if (ModelState.IsValid)
            {
                try
                {
                    movie.Name = movieViewModel.Name;
                    movie.genre = movieViewModel.genre;
                    movie.Writer = movieViewModel.Writer;
                    movie.Director = movieViewModel.Director;
                    movie.TrailerLink = movieViewModel.TrailerLink;
                    movie.Description = movieViewModel.Description;

                    unitOfWork.Complete();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(movieViewModel);
        }

        public IActionResult Delete(int id)
        {
            return Details(id, "Delete");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            var movie = unitOfWork.MovieRepository.Get(id);
            var mappedMovie = mapper.Map<Movie, MovieViewModel>(movie);
            try
            {
                unitOfWork.MovieRepository.Delete(movie);
                int count = unitOfWork.Complete();
                if (count > 0)
                {
                    DocumentSetting.DeleteFile(mappedMovie.Poster, "Images\\MovieImages");
                    DocumentSetting.DeleteFile(mappedMovie.Cover, "Images\\MovieImages");
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(mappedMovie);
        }


        public IActionResult MovieActors (int id)
        {
            var movie = unitOfWork.MovieRepository.GetMovieWithActors(id);
            var movieActors = (IEnumerable<Actor>)movie.Actors;
            ViewBag.MovieActors = movieActors;
            var mappedMovie = mapper.Map <Movie , MovieViewModel>(movie);
            return View(mappedMovie);
        }

        public IActionResult AddMovieActor(int id)
        {
            var movie = unitOfWork.MovieRepository.GetMovieWithActors(id);
            var mappedMovie = mapper.Map<Movie, MovieViewModel>(movie);

            var allActors = unitOfWork.ActorRepository.GetAll().ToList();

            var availableActors = allActors.Where(actor => !movie.Actors.Contains(actor)).ToList();

            ViewBag.AvailableActors = availableActors;
            var viewModel = new MovieActorViewModel { MovieId = id };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddMovieActor(int actorId, int movieId)
        {
            var movie = unitOfWork.MovieRepository.Get(movieId);

            if (ModelState.IsValid)
            {
                var actor = unitOfWork.ActorRepository.Get(actorId);
                unitOfWork.MovieRepository.AddActorToMovie(actor, movie);
                int count = unitOfWork.Complete();
                if (count > 0)
                {
                    // Redirect to MovieActors with movieId as a route parameter
                    return RedirectToAction("MovieActors", new { id = movieId });
                }
            }

            return View("Index");
        }

        [HttpPost]
        public IActionResult DeleteMovieActor (int actorId, int movieId)
        {
            var movie = unitOfWork.MovieRepository.GetMovieWithActors(movieId);
            var actor = unitOfWork.ActorRepository.Get(actorId);

            if (movie == null || actor == null)
            {
                // Handle the case where the movie or actor is not found
                return NotFound();
            }

            // Remove the actor from the movie's list of actors
            movie.Actors.Remove(actor);

            // Save changes to your data source
            unitOfWork.Complete();

            return RedirectToAction("MovieActors", new { id = movieId });
        }



    }
}
