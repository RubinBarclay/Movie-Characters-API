using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie_Characters_API.DTOs.DTOsCharacter;
using Movie_Characters_API.DTOs.DTOsFranchise;
using Movie_Characters_API.DTOs.DTOsMovie;
using Movie_Characters_API.Exceptions;
using Movie_Characters_API.Models;
using Movie_Characters_API.Services.FranchiseDataAccess;
using Movie_Characters_API.Services.MovieDataAccess;

namespace Movie_Characters_API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class FranchisesController : ControllerBase
    {
        private readonly IFranchiseService _franchisecontext;
        private readonly IMapper _mapper;
        private readonly IMovieService _moviecontext;

        public FranchisesController(IFranchiseService context, IMapper mapper,IMovieService movieContext)
        {
            _franchisecontext = context;
            _mapper = mapper;
            _moviecontext = movieContext;
        }

        /// <summary>
        /// List of franchises
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DTOGetFranchise>>> GetAllFranchises()
        {
            return Ok(_mapper.Map<IEnumerable<DTOGetFranchise>>(await _franchisecontext.ReadAll()));
        }

        /// <summary>
        /// Franchise by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<DTOGetFranchise>> GetFranchiseById(int id)
        {
            try
            {
                return Ok(_mapper.Map<DTOGetFranchise>(await _franchisecontext.ReadById(id)));
            }
            catch (FranchiseNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }
        }

        /// <summary>
        /// Get all the movies in a franchise
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("movies/{id}")]
        public async Task<ActionResult<IEnumerable<DTOGetMovie>>> GetMoviesInFranchiseWithFranchisId(int id)
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<DTOGetMovie>>(await _franchisecontext.ReadAllMoviesInFranchise(id)));
            }
            catch (FranchiseNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }
        }
        /// <summary>
        /// Get all the Characters in a franchise
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("character/{id}")]
        public async Task<ActionResult<IEnumerable<DTOGetCharacter>>> GetCharacterInFranchiseWithFranchisId(int id)
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<DTOGetCharacter>>(await _franchisecontext.ReadAllCharactersInFranchise(id)));
            }
            catch (FranchiseNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }
        }


        /// <summary>
        /// Edit a franchise
        /// </summary>
        /// <param name="id"></param>
        /// <param name="franchise"></param>
        /// <returns></returns>
        [HttpPut("{id}")]

        public async Task<IActionResult> PutFranchise(int id, DTOPutFranchise franchise)
        {
            if (id != franchise.Id)
            {
                return BadRequest();
            }
            var obj = _mapper.Map<Franchise>(franchise);
            try
            {
                await _franchisecontext.Update(obj);
            }
            catch (FranchiseNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }


            return NoContent();
        }



        /// <summary>
        /// Update movies in a franchise
        /// </summary>
        /// <param name="franchiseid"></param>
        /// <param name="movieID"></param>
        /// <returns></returns>
        [HttpPut("update/{franchiseid}")]
        public async Task<IActionResult> UpdateMoviesInFranchise(int franchiseid, [FromBody] int[] movieID)
        {
            Franchise franchisebyId;
            try
            {
                franchisebyId = await _franchisecontext.ReadById(franchiseid);
                franchisebyId.MovieList.Clear();
                await _franchisecontext.Update(franchisebyId);

            }
            catch (MovieNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }


            for (int i = 0; i < movieID.Length; i++)
            {

                try
                {
                    var movie = await _moviecontext.ReadById(movieID[i]);
                    movie.FranchiseId = franchiseid;
                    await _moviecontext.Update(movie);

                }
                catch (CharacterNotFoundException ex)
                {
                    return NotFound(new ProblemDetails
                    {
                        Detail = ex.Message
                    });
                }
                if (i == (movieID.Length - 1))
                {
                    return NoContent();
                }
            }
            return BadRequest();

        }


        /// <summary>
        /// Create a franchise
        /// </summary>
        /// <param name="createFranchiseDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Franchise>> PostFranchise(DTOPostFranchise createFranchiseDto)
        {
            var franchise = _mapper.Map<Franchise>(createFranchiseDto);
            await _franchisecontext.Create(franchise);
            return CreatedAtAction(nameof(GetFranchiseById), new { id = franchise.Id }, franchise);

        }

        /// <summary>
        /// Delete a franchise
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFranchise(int id)
        {
            try
            {
                await _franchisecontext.Delete(id);
            }
            catch (FranchiseNotFoundException ex)
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
