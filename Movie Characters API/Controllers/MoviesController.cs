﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
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
        /// <param name="id"></param>
        /// <param name="characterList"></param>
        /// <returns></returns>
        [HttpPut("update/{id}")]
        public async Task<IActionResult> PutCharactersInMovie(int id, [FromBody] DTOPutCharactersInMovie characterList)
        {
            try
            {
                var movie = await _moviecontext.ReadById(id);
                if (movie.Characters != null)
                    movie.Characters.Clear();
                if (characterList.CharacterIds != null)
                    foreach (var characterId in characterList.CharacterIds)
                    {
                        var character = await _characterService.ReadById(characterId);
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

        /// <summary>
        /// Create a movie
        /// </summary>
        /// <param name="createMovieDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(DTOPostMovie createMovieDto)
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