using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Votaciones.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Votaciones.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EleccionController : ControllerBase
    {
        private readonly MyDBContext _context;

        public EleccionController(MyDBContext context)
        {
            _context = context;
        }

        // GET: api/<EleccionController>
        [HttpGet("elections")]
        public async Task<ActionResult<IEnumerable<Eleccion>>> GetElections()
        {
            try
            {
                return await _context.Eleccion.ToListAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<EleccionController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EleccionController>/createeleccion
        [HttpPost("createelection")]
        public async Task<ActionResult<Eleccion>> PostCreateElection([FromBody] Eleccion request)
        {
            try
            {
                _context.Eleccion.Add(request);
                await _context.SaveChangesAsync();
                return new JsonResult(new { message = "Creacion de Eleccion Exitosa" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<EleccionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EleccionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
