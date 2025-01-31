using Core.Entities;

namespace Core.Repositories
{
    public interface IRevisorRepository
    {
        Task Registrar(Revisor revisor);

        Task EditarRevisor(Revisor revisor);

        Task EliminarRevisor(int id);

        Task<IEnumerable<Revisor>> ListarTodos();
    }
}
