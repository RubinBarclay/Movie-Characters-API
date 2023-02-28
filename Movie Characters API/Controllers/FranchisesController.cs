using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie_Characters_API.DTOModels.DTOFranchiseModels;
using Movie_Characters_API.Models;
using Movie_Characters_API.Services.FranchiseDataAccess;

namespace Movie_Characters_API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FranchisesController : ControllerBase
    {
        private readonly IFranchiseService _franchiseService;
        private readonly IMapper _mapper;

        public FranchisesController(IFranchiseService context, IMapper mapper)
        {
            _franchiseService = context;
            _mapper = mapper;
        }

        // GET: api/Franchises
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DTOFranchise>>> GetFranchises()
        {
            return Ok(_mapper.Map<IEnumerable<DTOFranchise>>(await _franchiseService.GetAll()));
        }

        // GET: api/Franchises/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Franchise>> GetFranchise(int id)
        //{
        //    var franchise = await _franchiseService.Franchises.FindAsync(id);

        //    if (franchise == null)
        //    {
        //        return NotFound();
        //    }

        //    return franchise;
        //}

        // PUT: api/Franchises/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutFranchise(int id, Franchise franchise)
        //{
        //    if (id != franchise.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _franchiseService.Entry(franchise).State = EntityState.Modified;

        //    try
        //    {
        //        await _franchiseService.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!FranchiseExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Franchises
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Franchise>> PostFranchise(Franchise franchise)
        //{
        //    _franchiseService.Franchises.Add(franchise);
        //    await _franchiseService.SaveChangesAsync();

        //    return CreatedAtAction("GetFranchise", new { id = franchise.Id }, franchise);
        //}

        // DELETE: api/Franchises/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteFranchise(int id)
        //{
        //    var franchise = await _franchiseService.Franchises.FindAsync(id);
        //    if (franchise == null)
        //    {
        //        return NotFound();
        //    }

        //    _franchiseService.Franchises.Remove(franchise);
        //    await _franchiseService.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool FranchiseExists(int id)
        //{
        //    return _franchiseService.Franchises.Any(e => e.Id == id);
        //}
    }
}
