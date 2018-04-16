using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MoviesRESTfulAPI.Core;
using MoviesRESTfulAPI.Dtos;
using MoviesRESTfulAPI.Models;

namespace MoviesRESTfulAPI.Controllers
{
    [Route("/api/movies")]
    public class MovieController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public MovieController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<List<MoviesDto>> GetMovies()
        {
            if (!ModelState.IsValid)
                BadRequest();

            var moviesQuery = await _unitOfWork.Movies.GetAllMovies();

            var moviesDto = _mapper.Map<List<Movies>, List<MoviesDto>>(moviesQuery);

            #region Without using AutoMapper the output will be the same, but way tedious
            //var listDto = new List<MoviesDto>();
            //foreach (var movies in moviesQuery)
            //{
            //    var movieDto = new MoviesDto()
            //    {
            //        Id = movies.Id,
            //        AvailableInStock = movies.AvailableInStock,
            //        DateAdded = movies.DateAdded,
            //        Name = movies.Name,
            //        NumberInStock = movies.NumberInStock,
            //        ReleaseDate = movies.ReleaseDate,
            //        GenreId = movies.GenreId,
            //        Genre = new GenreDto()
            //        {
            //            Id = movies.Genre.Id,
            //            Name = movies.Genre.Name
            //        }
            //    };
            //    listDto.Add(movieDto);
            //}
            //return listDto;
            #endregion

            return moviesDto;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovie(int id)
        {
            if (!ModelState.IsValid)
                BadRequest();

            var movie = await _unitOfWork.Movies.GetMovie(id);

            if (movie == null)
                NotFound();

            var movieDto = _mapper.Map<Movies, MoviesDto>(movie);
            return Ok(movieDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMovie([FromBody] MoviesDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var movie = _mapper.Map<MoviesDto, Movies>(movieDto);
            movie.DateAdded = DateTime.Now;

            _unitOfWork.Movies.Add(movie);
            
            await _unitOfWork.SaveChangesAsync();

            //return the DTO not the model
            movie = await _unitOfWork.Movies.GetMovie(movie.Id);

            var result = _mapper.Map<Movies, MoviesDto>(movie);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovie(int id, [FromBody] MoviesDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var movie = await _unitOfWork.Movies.GetMovie(id);

            if (movie == null)
                return NotFound("I couldn't find your movie");

            _mapper.Map(movieDto, movie);
            movie.DateAdded = DateTime.Now;

            await _unitOfWork.SaveChangesAsync();

            //display the updated result (as a DTO)
            movie = await _unitOfWork.Movies.GetMovie(movie.Id);

            //it shouldn't fail, but just to make sure
            if (movie == null)
                return NotFound("No movie found");

            var result = _mapper.Map<Movies, MoviesDto>(movie);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie =  _unitOfWork.Movies.SingleOrDefault(m=>m.Id==id);

            if (movie == null)
                return NotFound("No movie found");

            _unitOfWork.Movies.Remove(movie);
            await _unitOfWork.SaveChangesAsync();

            return Ok("Successfuly deleted");
        }

        [HttpPatch("update/{id}")]
        public async Task<IActionResult> PatchMovie(int id, [FromBody]JsonPatchDocument<MoviesDto> moviePatch)
        {
            var movie = await _unitOfWork.Movies.GetMovie(id);

            if (movie == null)
                return NotFound("Movie not found");

            var movieDto = _mapper.Map<Movies, MoviesDto>(movie);  

            moviePatch.ApplyTo(movieDto); //Apply the patch to the DTO. 

            _mapper.Map(movieDto, movie); 

            await _unitOfWork.SaveChangesAsync();
            return Ok(movieDto);
        }
    }
}
