using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie_Characters_API.DTOs.DTOsCharacter;
using Movie_Characters_API.DTOs.DTOsFranchise;
using Movie_Characters_API.Exceptions;
using Movie_Characters_API.Models;
using Movie_Characters_API.Services.CharacterDataAccess;
using Movie_Characters_API.Services.FranchiseDataAccess;

namespace Movie_Characters_API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly ICharacterService _charactercontext;
        private readonly IMapper _mapper;

        public CharactersController(ICharacterService context, IMapper mapper)
        {
            _charactercontext = context;
            _mapper = mapper;
        }

        // GET: api/v1/characters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DTOGetCharacter>>> GetAllCharacters()
        {
            return Ok(_mapper.Map<IEnumerable<DTOGetCharacter>>(await _charactercontext.GetAll()));
        }

        // GET: api/characters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DTOGetCharacter>> GetCharacterById(int id)
        {
            try
            {
                return Ok(_mapper.Map<DTOGetCharacter>(await _charactercontext.GetById(id)));
            }
            catch (CharacterNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }
        }

        // PUT: api/characters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharacter(int id, [FromBody] DTOPutCharacter character)
        {

            if (id != character.Id)
            {
                return BadRequest();
            }
            var obj = _mapper.Map<Character>(character);
            try
            {
                await _charactercontext.Update(obj);
            }
            catch (CharacterNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }

            return NoContent();
        }

        // POST: api/Characters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Character>> PostCharacter(DTOCreateCharacter createCharacterDto)
        {
            var character = _mapper.Map<Character>(createCharacterDto);
            await _charactercontext.Create(character);
            return CreatedAtAction(nameof(GetCharacterById), new { id = character.Id }, character);
        }

        // DELETE: api/Characters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacter(int id)
        {
            try
            {
                await _charactercontext.Deletes(id);
            }
            catch (CharacterNotFoundException ex)
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
