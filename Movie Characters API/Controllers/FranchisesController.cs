using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
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

        // GET: api/v1/franchises
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DTOGetFranchise>>> GetFranchises()
        {
            return Ok(_mapper.Map<IEnumerable<DTOGetFranchise>>(await _franchisecontext.GetAll()));
        }

        // GET: api/v1/franchises/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<DTOGetFranchise>> GetFranchiseById(int id)
        {
            try
            {
                return Ok(_mapper.Map<DTOGetFranchise>(await _franchisecontext.GetById(id)));
            }
            catch (FranchiseNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }
        }



        // PUT: api/v1/franchises/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
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


        // PUT: api/v1/franchises/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMoviesInFranchise(int id, [FromBody] DTOPutMoviesInFranchise franchiseMovieList)
        {
            
            try
            {
                var franchise = await _franchisecontext.GetById(id);
                if(franchise.MovieList != null)
                foreach (var movie in franchise.MovieList)
                {
                    movie.FranchiseId = null;
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
            }
            catch (FranchiseNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }



            if (franchiseMovieList.MovieIds != null)
            foreach (var movieId in franchiseMovieList.MovieIds)
            {
                var movie = await _moviecontext.GetById(movieId);
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

        // POST: api/v1/franchises
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Franchise>> PostFranchise(DTOCreateFranchise createFranchiseDto)
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
                await _franchisecontext.Deletes(id);
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
