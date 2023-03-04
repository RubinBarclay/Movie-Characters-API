using System.Net.Mime;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Movie_Characters_API.DTOs.DTOsCharacter;
using Movie_Characters_API.DTOs.DTOsMovie;
using Movie_Characters_API.Exceptions;
using Movie_Characters_API.Models;
using Movie_Characters_API.Services.CharacterDataAccess;
using Movie_Characters_API.Services.MovieDataAccess;

namespace Movie_Characters_API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
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

        /// <summary>
        /// List of movies
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DTOGetMovie>>> GetAllMovies()
        {
            return Ok(_mapper.Map<IEnumerable<DTOGetMovie>>(await _moviecontext.ReadAll()));
        }


        /// <summary>
        /// Movie by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<DTOGetMovie>> GetMovieById(int id)
        {
            try
            {
                return Ok(_mapper.Map<DTOGetMovie>(await _moviecontext.ReadById(id)));
            }
            catch (MovieNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }
        }

        /// <summary>
        /// Get all the characters in a movie
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Characters/{id}")]
        public async Task<ActionResult<IEnumerable<DTOGetCharacter>>> GetCharacterInMovieWithMovieId(int id)
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<DTOGetCharacter>>(await _moviecontext.ReadAllCharactersInMovie(id)));
            }
            catch (MovieNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }
        }

        /// <summary>
        /// Edit a movie
        /// </summary>
        /// <param name="id"></param>
        /// <param name="movie"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Update characters in a movie
        /// </summary>
        /// <param name="movieid"></param>
        /// <param name="characterID"></param>
        /// <returns></returns>
        [HttpPut("update/{movieid}")]
        public async Task<IActionResult> PutCharactersInMovie(int movieid, [FromBody] int[] characterID)
        {
            Movie moviebyId;
            try
            {
                moviebyId = await _moviecontext.ReadById(movieid);
                moviebyId.Characters.Clear();
                await _moviecontext.Update(moviebyId);

            }
            catch (MovieNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }

            for (int i = 0; i < characterID.Length; i++)
            {

                try
                {
                    var character = await _characterService.ReadById(characterID[i]);
                    character.MoviesList.Add(moviebyId);
                    await _characterService.Update(character);
                    
                }
                catch (CharacterNotFoundException ex)
                {
                    return NotFound(new ProblemDetails
                    {
                        Detail = ex.Message
                    });
                }
                if (i == (characterID.Length-1))
                {
                    return NoContent();
                }
            }
            return BadRequest();
        }

        /// <summary>
        /// Create a movie
        /// </summary>
        /// <param name="createMovieDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<DTOPostMovie>> PostMovie(DTOPostMovie createMovieDto)
        {
            var movie = _mapper.Map<Movie>(createMovieDto);
            await _moviecontext.Create(movie);
            return CreatedAtAction(nameof(GetMovieById), new { id = movie.Id }, movie);
        }


        /// <summary>
        /// Delete a movie
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            try
            {
                var moviebyId = await _moviecontext.ReadById(id);
                moviebyId.Characters.Clear();
                await _moviecontext.Update(moviebyId);
                await _moviecontext.Delete(id);
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
