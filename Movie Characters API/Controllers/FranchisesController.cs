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
using Movie_Characters_API.DTOs.DTOsFranchise;
using Movie_Characters_API.Exceptions;
using Movie_Characters_API.Models;
using Movie_Characters_API.Services.FranchiseDataAccess;
using Movie_Characters_API.Services.MovieDataAccess;

namespace Movie_Characters_API.Controllers
{
    [Route("api/v1/[controller]/[action]")]
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

        // GET: api/v1/franchises/GetAllFranchises
        /// <summary>
        /// Get all franchises
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DTOGetFranchise>>> GetAllFranchises()
        {
            return Ok(_mapper.Map<IEnumerable<DTOGetFranchise>>(await _franchisecontext.ReadAll()));
        }

        // GET: api/v1/franchises/GetFranchiseById/{id}
        /// <summary>
        /// Get franchise by id
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



        // PUT: api/v1/franchises/PutFranchise/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Update franchise
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


        // PUT: api/v1/franchises/putmoviesmnfranchise/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Update movies in franchise
        /// </summary>
        /// <param name="id"></param>
        /// <param name="franchiseMovieList"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMoviesInFranchise(int id, [FromBody] DTOPutMoviesInFranchise franchiseMovieList)
        {

            
            var franchise = await _franchisecontext.ReadById(id);
            if (franchise.MovieList != null)
                franchise.MovieList.Clear();


            if (franchiseMovieList.MovieIds != null)
            foreach (var movieId in franchiseMovieList.MovieIds)
            {
                var movie = await _moviecontext.ReadById(movieId);
                movie.FranchiseId = movieId;
                try
                {
                    await _moviecontext.Update(movie);
                }
                catch (MovieNotFoundException ex)
                {
                    return NotFound(new ProblemDetails
                    {
                        Detail = ex.Message
                    });
                }
            }
       
            return NoContent();
        }

        // POST: api/v1/franchises/postFranchise
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Create franchise
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

        // DELETE: api/v1/franchises/5
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
