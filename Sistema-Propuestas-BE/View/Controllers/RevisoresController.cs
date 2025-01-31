using Core.Entities;
using Core.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RevisoresController : ControllerBase
    {
        private readonly IRevisorRepository _revisorRepository;

        public RevisoresController(IRevisorRepository revisorRepository)
        {
            _revisorRepository = revisorRepository;
        }

        [HttpPost]
        public async Task<ActionResult> Registrar([FromBody] Revisor revisor)
        {
            try
            {
                if (revisor == null) return BadRequest("Datos inválidos.");
                await _revisorRepository.Registrar(revisor);
                return Ok(new { message = "Revisor registrado correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor.");
            }
        }

        [HttpPut]
        public async Task<ActionResult> Editar([FromBody] Revisor revisor)
        {
            try
            {
                if (revisor == null)
                    return BadRequest("Datos inválidos.");

                await _revisorRepository.EditarRevisor(revisor);
                return Ok(new { message = "Revisor editado correctamente" });
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
                await _revisorRepository.EliminarRevisor(id);
                return Ok(new { message = "Revisor eliminado correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor");
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Revisor>>> GetAll()
        {
            try
            {
                var revisores = await _revisorRepository.ListarTodos();
                return Ok(revisores);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor");
            }
        }
    }
}
