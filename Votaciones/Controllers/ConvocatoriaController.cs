using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
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
        [HttpGet("announcements")]
        public async Task<ActionResult<IEnumerable<Convocatoria>>> GetAnnouncements()
        {
            try
            {
                var data = await (from conv in _context.Convocatoria
                                  join cargo in _context.Cargo
                                  on conv.idcargo equals cargo.idcargo
                                  join convreq in _context.ConvocatoriaRequisitos
                                  on conv.idconvocatoria equals convreq.idconvocatoria
                                  join reqs in _context.Requisito
                                  on convreq.idrequisito equals reqs.idrequisito
                                  select new
                                  {
                                      conv,
                                      cargo,
                                      reqs
                                  }).ToListAsync();
                return new JsonResult(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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

        public class CreaterAnnounamentRequest
        {
            [Required]
            public int eleccion { get; set; }
            [Required]
            public int cargo { get; set; }
            [Required]
            public string nombre_convocatoria { get; set; }
            [Required]
            public DateTime fecha_inicio { get; set; }
            [Required]
            public DateTime fecha_fin { get; set; }

            public dynamic req { get; set; }
        }

        // POST api/<ConvocatoriaController>/createrannounament
        [HttpPost("createannounament")]
        public async Task<ActionResult<Convocatoria>> CrearteAnnounamen([FromBody] CreaterAnnounamentRequest request)
        {


            try
            {
                var cargo = await _context.Cargo.FindAsync(request.cargo);
                var eleccion = await _context.Eleccion.FindAsync(request.eleccion);
                if (eleccion.fecha_inicio <= request.fecha_inicio || eleccion.fecha_inicio <= request.fecha_fin)
                {
                    return new JsonResult(new { error = "Fechas fuera de rango por fechas de " + eleccion.nombre_eleccion });
                }
                Convocatoria convocatoria = new Convocatoria();
                convocatoria.nombre_convocatoria = request.nombre_convocatoria;
                convocatoria.fecha_inicio_convocatoria = request.fecha_inicio;
                convocatoria.fecha_fin_convocatoria = request.fecha_fin;
                convocatoria.Cargo = cargo;
                convocatoria.Eleccion = eleccion;
                _context.Convocatoria.Add(convocatoria);
                await _context.SaveChangesAsync();
                foreach (var item in request.req)
                {
                    string nombre = item;
                    var datar = _context.Requisito.Where(
                     cr => cr.nombre_requisito.Equals(nombre))
                    .FirstOrDefault();
                    ConvocatoriaRequisito convRequi = new ConvocatoriaRequisito();
                    convRequi.idrequisito = datar.idrequisito;
                    convRequi.idconvocatoria = convocatoria.idconvocatoria;
                    _context.ConvocatoriaRequisitos.Add(convRequi);
                    await _context.SaveChangesAsync();

                }
                return new JsonResult(new { message = "Creacion de Convocatoria Exitosa" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public class CreartePostulationRequest
        {
            [Required]
            public int convocatoria { get; set; }
            [Required]
            public string username { get; set; }

            [Required]
            public DateTime fechaactual { get; set; }

        }
        // POST api/<ConvocatoriaController>/createrannounament
        [HttpPost("createpostulation")]
        public async Task<ActionResult<Candidato>> CreartePostulation([FromBody] CreartePostulationRequest request)
        {
            try
            {
                var data = await (from pers in _context.Persona
                                  join user in _context.Usuario
                                  on pers.idpersona equals user.idpersona
                                  select new
                                  {
                                      user,
                                      pers
                                  }).ToListAsync();

                var cons = await _context.Candidato.Where(
                    Candidato => Candidato.idpersona.Equals(data[0].pers.idpersona)).ToListAsync();
                if (cons.Count > 0) 
                {
                    return new JsonResult(new { error = "Usuario ya Postulado" });
                }
                Candidato candidato = new Candidato();
                candidato.idpersona = data[0].pers.idpersona;
                candidato.idconvocatoria = request.convocatoria;
                candidato.estado_participante = "inactivo";
                candidato.numero_participante = new Random(Environment.TickCount).Next(1, 100);
                _context.Candidato.Add(candidato);
                await _context.SaveChangesAsync();
                return new JsonResult(new { message = "Postulacion Exitosa" });

            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("postulations/{id}")]
        public async Task<ActionResult<IEnumerable<Candidato>>> GetPostulation(int id)
        {
            try
            {
                var data = await (from pers in _context.Persona
                                  join cand in _context.Candidato
                                  on pers.idpersona equals cand.idpersona
                                  join conv in _context.Convocatoria
                                  on cand.idconvocatoria equals conv.idconvocatoria
                                  join elecc in _context.Eleccion
                                  on conv.ideleccion equals elecc.ideleccion
                                  where conv.idconvocatoria == id
                                  select new { pers, cand, conv, elecc }).ToListAsync();
                return new JsonResult(data);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        public class ChangeStatusRequest
        {
            [Required]
            public int id { get; set; }
            
        }

        [HttpPut("changestatus")]
        public async Task<ActionResult<Candidato>> PutPostulationState([FromBody] ChangeStatusRequest request)
        {
            
            try 
            {
                var data = await _context.Candidato.FindAsync(request.id);
                if (data == null) return new JsonResult(new { error = "candidato no Existente" });
                switch (data.estado_participante)
                {
                    case "activo":
                        data.estado_participante = "inactivo";
                        break;
                    case "inactivo":
                        data.estado_participante = "activo";
                        break;
                }
                await _context.SaveChangesAsync();
                return new JsonResult(new { message = "Modificacion Exitosa" });
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
