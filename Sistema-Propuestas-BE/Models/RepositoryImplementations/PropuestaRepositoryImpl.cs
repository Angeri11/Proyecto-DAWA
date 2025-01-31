using Core.Data.Context;
using Core.Entities;
using Core.Entities.Enum;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Core.RepositoryImplementations
{
    public class PropuestaRepositoryImpl : IPropuestaRepository
    {
        private readonly ApplicationDbContext _context;

        public PropuestaRepositoryImpl(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Registrar(Propuesta propuesta)
        {
            _context.Propuestas.Add(propuesta);
            await _context.SaveChangesAsync();
        }

        public async Task EditarPropuesta(Propuesta propuesta)
        {
            var propuestaExistente = await _context.Propuestas.FindAsync(propuesta.Id);
            if (propuestaExistente != null)
            {
                propuestaExistente.NombrePropuesta = propuesta.NombrePropuesta;
                propuestaExistente.NombreEstudiante = propuesta.NombreEstudiante;
                propuestaExistente.CedulaEstudiante = propuesta.CedulaEstudiante;
                propuestaExistente.FechaRegistro = propuesta.FechaRegistro;
                await _context.SaveChangesAsync();
            }
        }

        public async Task EliminarPropuesta(int id)
        {
            var propuesta = await _context.Propuestas.FindAsync(id);
            if (propuesta != null)
            {
                _context.Propuestas.Remove(propuesta);
                await _context.SaveChangesAsync();
            }
        }

        public async Task AceptarPropuesta(int id)
        {
            var propuesta = await _context.Propuestas.FindAsync(id);
            if (propuesta != null)
            {
                propuesta.Estado = EstadoPropuesta.Aprobada;
                await _context.SaveChangesAsync();
            }
        }

        public async Task RechazarPropuesta(int id)
        {
            var propuesta = await _context.Propuestas.FindAsync(id);
            if (propuesta != null)
            {
                propuesta.Estado = EstadoPropuesta.Rechazada;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<object>> ListarTodas()
        {
            return await _context.Propuestas
                .Select(p => new
                {
                    Id = p.Id,
                    NombrePropuesta = p.NombrePropuesta,
                    NombreEstudiante = p.NombreEstudiante,
                    CedulaEstudiante = p.CedulaEstudiante,
                    FechaRegistro = p.FechaRegistro,
                    Estado = p.Estado.ToString() // Convierte el enum a string antes de devolverlo
                })
                .ToListAsync();
        }
    }
}
