using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Votaciones.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Votaciones.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConvocatoriaController : ControllerBase
    {
        private readonly MyDBContext _context;

        public ConvocatoriaController(MyDBContext context)
        {
            _context = context;
        }
        // GET: api/<ConvocatoriaController>/positions
        [HttpGet("positions")]
        public async Task<ActionResult<IEnumerable<Cargo>>> GetPositions()
        {
            return await _context.Cargo.ToListAsync();
        }

        // GET api/<ConvocatoriaController>/5


        // POST api/<ConvocatoriaController>/createposition
        [HttpPost("createposition")]
        public async Task<ActionResult<Cargo>> CreartePosition([FromBody] Cargo request) 
        {
            var data = await _context.Cargo.Where(
                Cargo => Cargo.nombre_cargo.Equals(request.nombre_cargo)).ToListAsync();
            if (data.Count > 0)
            {
                return new JsonResult(new { error = "Cargo Existente" });
            }
            try
            {
                _context.Cargo.Add(request);
                await _context.SaveChangesAsync();
                return new JsonResult(new { message = "Creacion de Cargo Exitoso" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/<ConvocatoriaController>/requirements
        [HttpGet("requirements")]
        public async Task<ActionResult<IEnumerable<Requisito>>> GetRequirements()
        {
            return await _context.Requisito.ToListAsync();
        }

        // GET api/<ConvocatoriaController>/5


        // POST api/<ConvocatoriaController>/createrequirement
        [HttpPost("createrequirement")]
        public async Task<ActionResult<Requisito>> CrearteRequirement([FromBody] Requisito request)
        {
            var data = await _context.Requisito.Where(
                Requisito => Requisito.nombre_requisito.Equals(request.nombre_requisito)).ToListAsync();
            if (data.Count > 0)
            {
                return new JsonResult(new { error = "Requisito Existente" });
            }
            try
            {
                _context.Requisito.Add(request);
                await _context.SaveChangesAsync();
                return new JsonResult(new { message = "Creacion de Requisito Exitoso" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public class ModifyRequirementRequest
        {
            [Required]
            public int idrequisito { get; set; }
            [Required]
            public string nombre_requisito { get; set; }
        }

        [HttpPut("modifyrequirement")]
        public async Task<ActionResult<Requisito>> ModifyRequirement([FromBody] ModifyRequirementRequest request)
        {
            var dataV = await _context.Requisito.Where(
                Requisito => Requisito.nombre_requisito.Equals(request.nombre_requisito)).ToListAsync();
            if (dataV.Count > 0)
            {
                return new JsonResult(new { error = "Nombre de Requisito Existente" });
            }
            try
            {
                var data = await _context.Requisito.FindAsync(request.idrequisito);
                data.nombre_requisito = request.nombre_requisito;
                await _context.SaveChangesAsync();
                return new JsonResult(new { message = "Modificacion de Requisito Exitoso" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public class ModifyPositionRequest
        {
            [Required]
            public int idcargo { get; set; }
            [Required]
            public string nombre_cargo { get; set; }
        }

        [HttpPut("modifyposition")]
        public async Task<ActionResult<Requisito>> ModifyPosition([FromBody] ModifyPositionRequest request)
        {
            var dataV = await _context.Cargo.Where(
                Requisito => Requisito.nombre_cargo.Equals(request.nombre_cargo)).ToListAsync();
            if (dataV.Count > 0)
            {
                return new JsonResult(new { error = "Nombre de Cargo Existente" });
            }
            try
            {
                var data = await _context.Cargo.FindAsync(request.idcargo);
                data.nombre_cargo = request.nombre_cargo;
                await _context.SaveChangesAsync();
                return new JsonResult(new { message = "Modificacion de Cargo Exitoso" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<ConvocatoriaController>/createrannounament
        [HttpPost("createrannounament")]
        public async Task<ActionResult<Cargo>> CrearteAnnounamen([FromBody] Cargo request)
        {
            object data = request;
            {
                return new JsonResult(new { error = "Requisito Existente" });
            }
            try
            {
                //_context.Requisito.Add(request);
                //await _context.SaveChangesAsync();
                //return new JsonResult(new { message = "Creacion de Requisito Exitoso" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // PUT api/<ConvocatoriaController>/5


        // DELETE api/<ConvocatoriaController>/5

    }
}
