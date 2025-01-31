using Core.Entities;
using Core.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropuestasController : ControllerBase
    {
        private readonly IPropuestaRepository _propuestaRepository;

        public PropuestasController(IPropuestaRepository propuestaRepository)
        {
            _propuestaRepository = propuestaRepository;
        }

        [HttpPost]
        public async Task<ActionResult> Registrar([FromBody] Propuesta propuesta)
        {
            try
            {
                if (propuesta == null)
                    return BadRequest("Datos inválidos.");

                await _propuestaRepository.Registrar(propuesta);
                return Ok(new { message = "Propuesta registrada correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor");
            }
        }

        [HttpPut]
        public async Task<ActionResult> Editar([FromBody] Propuesta propuesta)
        {
            try
            {
                if (propuesta == null)
                    return BadRequest("Datos inválidos.");

                await _propuestaRepository.EditarPropuesta(propuesta);
                return Ok(new { message = "Propuesta editada correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Eliminar(int id)
        {
            try
            {
                await _propuestaRepository.EliminarPropuesta(id);
                return Ok(new { message = "Propuesta eliminada correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor");
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Propuesta>>> GetAll()
        {
            try
            {
                var propuestas = await _propuestaRepository.ListarTodas();
                return Ok(propuestas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor");
            }
        }

        [HttpPut("aceptar/{id}")]
        public async Task<ActionResult> Aceptar(int id)
        {
            try
            {
                await _propuestaRepository.AceptarPropuesta(id);
                return Ok(new { message = "Propuesta aceptada correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor");
            }
        }

        [HttpPut("rechazar/{id}")]
        public async Task<ActionResult> Rechazar(int id)
        {
            try
            {
                await _propuestaRepository.RechazarPropuesta(id);
                return Ok(new { message = "Propuesta rechazada correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor");
            }
        }
    }
}
