using Core.Entities;

namespace Core.Repositories
{
    public interface IPropuestaRepository
    {
        Task Registrar(Propuesta propuesta);

        Task EditarPropuesta(Propuesta propuesta);

        Task EliminarPropuesta(int id);

        Task<IEnumerable<object>> ListarTodas();

        Task AceptarPropuesta(int id);

        Task RechazarPropuesta(int id);
    }
}
