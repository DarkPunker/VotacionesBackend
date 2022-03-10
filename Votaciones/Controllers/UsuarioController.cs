using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Votaciones.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Web;
using Microsoft.Data.SqlClient;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Votaciones.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly MyDBContext _context;

        public UsuarioController(MyDBContext context)
        {
            _context = context;
        }



        // GET: api/<UsuarioController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            var userPerson = await (from pers in _context.Persona
                                    join user in _context.Usuario
                                    on pers.idpersona equals user.idpersona
                                    join userrol in _context.UsuarioRol
                                    on user.idusuario equals userrol.idusuario
                                    join rol in _context.Rol
                                    on userrol.idrol equals rol.idrol
                                    join rolpermiso in _context.RolHasPermiso
                                    on rol.idrol equals rolpermiso.idrol
                                    join permiso in _context.Permiso
                                    on rolpermiso.idpermiso equals permiso.idpermiso
                                    select new
                                    {
                                        user,
                                        pers,
                                        rol,
                                        permiso
                                    }).ToListAsync();
            return new JsonResult(userPerson);
            //return await _context.Usuario.ToListAsync();

        }

        // GET api/<UsuarioController>/5
        [HttpGet("{username}")]
        public async Task<IActionResult> GetUsuario(string username)
        {
            try
            {
                var userPerson = await (from pers in _context.Persona
                                        join user in _context.Usuario
                                        on pers.idpersona equals user.idpersona
                                        join userrol in _context.UsuarioRol
                                        on user.idusuario equals userrol.idusuario
                                        join rol in _context.Rol
                                        on userrol.idrol equals rol.idrol
                                        join rolpermiso in _context.RolHasPermiso
                                        on rol.idrol equals rolpermiso.idrol
                                        join permiso in _context.Permiso
                                        on rolpermiso.idpermiso equals permiso.idpermiso
                                        where user.nombre_usuario == username
                                        select new
                                        {
                                            user,
                                            pers,
                                            rol,
                                            permiso
                                        }).ToListAsync();
                return new JsonResult(userPerson);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); ;
            }
        }

        //// GET api/<UsuarioController>/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Usuario>> GetUsuario(int id)
        //{
        //    try
        //    {
        //        var data = await _context.Usuario.FindAsync(id);
        //        if (data == null) return NotFound();
        //        return data;
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}


        public class LoginRequest
        {
            [Required]
            public string Username { get; set; }
            [Required]
            public string Password { get; set; }
        }

        [HttpPost("login")]
        public async Task<ActionResult<Usuario>> Login([FromBody] LoginRequest request)
        {
            try
            {
                var username = request.Username;
                var password = request.Password;
                var data = await (from pers in _context.Persona
                                  join user in _context.Usuario
                                  on pers.idpersona equals user.idpersona
                                  join userrol in _context.UsuarioRol
                                  on user.idusuario equals userrol.idusuario
                                  join rol in _context.Rol
                                  on userrol.idrol equals rol.idrol
                                  join rolpermiso in _context.RolHasPermiso
                                  on rol.idrol equals rolpermiso.idrol
                                  join permiso in _context.Permiso
                                  on rolpermiso.idpermiso equals permiso.idpermiso
                                  where user.nombre_usuario == username &&
                                  user.contrasena == password
                                  select new
                                  {
                                      user,
                                      pers,
                                      rol,
                                      permiso
                                  }).ToListAsync();
                if (data.Count == 0) return new JsonResult(new { error = "Usuario y/o Contraseña Incorrecta" });
                if (!data[0].user.estado_usuario.Equals("activo")) return new JsonResult(new { error = "Usuario Inactivo" });
                return new JsonResult(data[0]);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public class RegisterRequest
        {
            [Required]
            public string numero_identificacion { get; set; }
            [Required]
            public string primer_nombre { get; set; }
            public string segundo_nombre { get; set; }
            [Required]
            public string primer_apellido { get; set; }
            public string segundo_apellido { get; set; }
            public string telefono { get; set; }
            public string direccion { get; set; }
            [Required]
            public string nombre_usuario { get; set; }
            [Required]
            public string contrasena { get; set; }
        }

        [HttpPost("register")]
        public async Task<ActionResult<Usuario>> Register([FromBody] RegisterRequest request)
        {
            var data = await _context.Usuario.Where(
                Usuario => Usuario.nombre_usuario.Equals(request.nombre_usuario)).ToListAsync();
            if (data.Count > 0)
            {
                return new JsonResult(new { error = "Usuario En Uso" });
            }
            var datap = await _context.Persona.Where(
               Persona => Persona.numero_identificacion.Equals(request.numero_identificacion)).ToListAsync();
            if (datap.Count > 0)
            {
                return new JsonResult(new { error = "Persona ya Registrada" });
            }

            var datar = _context.Rol.Where(
               Rol => Rol.nombre_rol.Equals("invitado"))
                .FirstOrDefault();

            Usuario user = new Usuario();
            Persona pers = new Persona();
            UsuarioRol usuarioRol = new UsuarioRol();

            try
            {
                user.nombre_usuario = request.nombre_usuario;
                user.contrasena = request.contrasena;
                pers.numero_identificacion = request.numero_identificacion;
                pers.primer_nombre = request.primer_nombre;
                pers.segundo_nombre = request.segundo_nombre;
                pers.primer_apellido = request.primer_apellido;
                pers.segundo_apellido = request.segundo_apellido;
                pers.telefono = request.telefono;
                pers.direccion = request.direccion;
                user.Persona = pers;

                _context.Usuario.Add(user);
                await _context.SaveChangesAsync();
                var id = user.idusuario;
                usuarioRol.idusuario = id;
                usuarioRol.idrol = datar.idrol;
                _context.UsuarioRol.Add(usuarioRol);
                await _context.SaveChangesAsync();
                return new JsonResult(new { message = "Registro Exitoso" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        public class ChangeStatusRequest
        {
            [Required]
            public int idusuario { get; set; }
            [Required]
            public string nombre_usuario { get; set; }
        }

        // PUT api/<UsuarioController>/
        [HttpPut("changestatus")]
        public async Task<ActionResult<Usuario>> PutUserState([FromBody] ChangeStatusRequest request)
        {
            var data = await _context.Usuario.FindAsync(request.idusuario);
            if (data == null) return new JsonResult(new { error = "Usuario no Existente" });
            switch (data.estado_usuario)
            {
                case "activo":
                    data.estado_usuario = "inactivo";
                    break;
                case "inactivo":
                    data.estado_usuario = "activo";
                    break;
            }
            await _context.SaveChangesAsync();
            return new JsonResult(new { message = "Modificacion Exitosa" });
        }

        public class ChangeRolRequest
        {
            [Required]
            public int idusuario { get; set; }
            [Required]
            public int idrol { get; set; }
        }

        // PUT api/<UsuarioController>/
        [HttpPut("changerol")]
        public async Task<ActionResult<Usuario>> PutUserRol([FromBody] ChangeRolRequest request)
        {
            var queryString = "UPDATE UsuarioRol SET idrol = "+request.idrol+" WHERE idusuario ="+request.idusuario;

            _context.Database.ExecuteSqlRaw(queryString);

            return new JsonResult(new { message = "Modificacion Exitosa" });
        }


        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
