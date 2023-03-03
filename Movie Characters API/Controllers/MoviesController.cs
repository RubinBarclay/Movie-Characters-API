using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Movie_Characters_API.DTOs.DTOsFranchise;
using Movie_Characters_API.DTOs.DTOsMovie;
using Movie_Characters_API.Exceptions;
using Movie_Characters_API.Models;
using Movie_Characters_API.Services.CharacterDataAccess;
using Movie_Characters_API.Services.MovieDataAccess;

namespace Movie_Characters_API.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly ICharacterService _characterService;
        private readonly IMovieService _moviecontext;
        private readonly IMapper _mapper;

        public MoviesController(IMovieService context, IMapper mapper, ICharacterService charactercontext)
        {
            _moviecontext = context;
            _mapper = mapper;
            _characterService = charactercontext;
        }

        // GET: api/v1/movies/getallmovies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DTOGetMovie>>> GetAllMovies()
        {
            return Ok(_mapper.Map<IEnumerable<DTOGetMovie>>(await _moviecontext.GetAll()));
        }

        // GET: api/v1/movies/getmoviebyid/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DTOGetMovie>> GetMovieById(int id)
        {
            try
            {
                return Ok(_mapper.Map<DTOGetMovie>(await _moviecontext.GetById(id)));
            }
            catch (MovieNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }
        }

        // PUT: api/v1/movies/putMovie/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, DTOPutMovie movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }
            var obj = _mapper.Map<Movie>(movie);
            try
            {
                await _moviecontext.Update(obj);
            }
            catch (MovieNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }

            return NoContent();
        }
        // PUT: api/v1/movies/putMovie/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharactersInMovie(int id, [FromBody] DTOPutCharactersInMovie characterList)
        {
            
            try
            {
                var movie = await _moviecontext.GetById(id);
                if (movie.Characters != null)
                    movie.Characters.Clear();
                if (characterList.CharacterIds != null)
                    foreach (var characterId in characterList.CharacterIds)
                    {
                        var character = await _characterService.GetById(characterId);
                        character.MoviesList.Add(movie);
                        try
                        {
                            await _characterService.Update(character);
                        }
                        catch (CharacterNotFoundException ex)
                        {
                            return NotFound(new ProblemDetails
                            {
                                Detail = ex.Message
                            });
                        }
                    }
            }
            catch (MovieNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }
            return NoContent();
        }

        // POST: api/v1/movies/PostMovie
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(DTOCreateMovie createMovieDto)
        {
            var movie = _mapper.Map<Movie>(createMovieDto);
            await _moviecontext.Create(movie);
            return CreatedAtAction(nameof(GetMovieById), new { id = movie.Id }, movie);
        }

        // DELETE: api/v1/movies/deleteMovie/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            try
            {
                await _moviecontext.Deletes(id);
            }
            catch (MovieNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }

            return NoContent();
        }

        
    }
}
