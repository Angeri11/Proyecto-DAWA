using Core.Data.Context;
using Core.Entities;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Core.RepositoryImplementations
{
    public class RevisorRepositoryImpl : IRevisorRepository
    {
        private readonly ApplicationDbContext _context;

        public RevisorRepositoryImpl(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Registrar(Revisor revisor)
        {
            _context.Revisores.Add(revisor);
            await _context.SaveChangesAsync();
        }

        public async Task EditarRevisor(Revisor revisor)
        {
            var revisorExistente = await _context.Revisores.FindAsync(revisor.Id);
            if (revisorExistente != null)
            {
                revisorExistente.Nombres = revisor.Nombres;
                revisorExistente.Apellidos = revisor.Apellidos;
                revisorExistente.Cedula = revisor.Cedula;
                revisorExistente.Correo = revisor.Correo;
                await _context.SaveChangesAsync();
            }
        }

        public async Task EliminarRevisor(int id)
        {
            var revisor = await _context.Revisores.FindAsync(id);
            if (revisor != null)
            {
                _context.Revisores.Remove(revisor);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Revisor>> ListarTodos()
        {
            return await _context.Revisores.ToListAsync();
        }
    }
}
