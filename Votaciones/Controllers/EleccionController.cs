using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public async Task<ActionResult<Eleccion>> GetElection(int id)
        {
            try
            {
                var data = await _context.Eleccion.FindAsync(id);
                if (data == null) return NotFound();
                return data;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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

        public class ChangeElectionRequest
        {
            [Required]
            public int ideleccion { get; set; }
            [Required]
            public string nombre_eleccion { get; set; }
            [Required]
            public DateTime fecha_inicio { get; set; }
            [Required]
            public DateTime fecha_fin { get; set; }
        }

        // PUT api/<EleccionController>/5
        [HttpPut("changeelection")]
        public async Task<ActionResult<Eleccion>> PutElection([FromBody] ChangeElectionRequest request)
        {

            var data = await _context.Eleccion.FindAsync(request.ideleccion);
            data.nombre_eleccion = request.nombre_eleccion;
            data.fecha_inicio = request.fecha_inicio;
            data.fecha_fin = data.fecha_fin;
            await _context.SaveChangesAsync();
            return new JsonResult(new { message = "Modificacion Exitosa" });
        }

        // DELETE api/<EleccionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
