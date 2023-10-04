using AutoMapper;
using ElonsolMovies.BLL.Interfaces;
using ElonsolMovies.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UserApp.PL.Models;

namespace UserApp.PL.Controllers
{
    [Authorize]
    public class UserHomeController : Controller
    {
        private readonly ILogger<UserHomeController> _logger;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UserHomeController(IUnitOfWork unitOfWork , IMapper mapper, ILogger<UserHomeController> logger , IWebHostEnvironment webHostEnvironment)
        {
            this.unitOfWork = unitOfWork;
            _logger = logger;
            this.webHostEnvironment = webHostEnvironment;
            this.mapper = mapper;
        }
        

        public IActionResult Index()
        {
            
            var movies = unitOfWork.MovieRepository.GetAll();
            var mappedMovie = mapper.Map<IEnumerable<Movie>, IEnumerable<MovieViewModel>>(movies);
            return View(mappedMovie);
        }

        public IActionResult Details(int? id)
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
            return View(mappedMovie);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
