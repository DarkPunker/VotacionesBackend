using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Votaciones.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Votaciones.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolAndPermisoController : ControllerBase
    {
        private readonly MyDBContext _context;

        public RolAndPermisoController(MyDBContext context)
        {
            _context = context;
        }

        // GET: api/<RolAndPermisoController>
        [HttpGet("roles")]
        public async Task<ActionResult<IEnumerable<Rol>>> GetRoles()
        {
            try
            {
                return await _context.Rol.ToListAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<RolAndPermisoController>/5
        [HttpGet("rol/{id}")]
        public async Task<ActionResult<Rol>> GetRol(int id)
        {
            try
            {
                var data = await _context.Rol.FindAsync(id);
                if (data == null) return new JsonResult(new { error = "Rol no encontrado" });
                return data;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<RolAndPermisoController>/createrol
        [HttpPost("createrol")]
        public async Task<ActionResult<Rol>> PostCreateRol([FromBody] Rol request)
        {
            try
            {
                _context.Rol.Add(request);
                await _context.SaveChangesAsync();
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/<RolAndPermisoController>/permisos
        [HttpGet("permisos")]
        public async Task<ActionResult<IEnumerable<Permiso>>> GetPermisos()
        {
            return await _context.Permiso.ToListAsync();
        }

        // GET api/<RolAndPermisoController>/5
        [HttpGet("permiso/{id}")]
        public async Task<ActionResult<Permiso>> GetPermission(int id)
        {
            try
            {
                var data = await _context.Permiso.FindAsync(id);
                if (data == null) return new JsonResult(new { error = "Permiso no encontrado" });
                return data;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<RolAndPermisoController>/createpermission
        [HttpPost("createpermission")]
        public async Task<ActionResult<Permiso>> PostCreatePermission([FromBody] Permiso request)
        {
            try
            {
                _context.Permiso.Add(request);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetPermisos", new { id = request.idpermiso });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        // POST api/<RolAndPermisoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<RolAndPermisoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RolAndPermisoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
