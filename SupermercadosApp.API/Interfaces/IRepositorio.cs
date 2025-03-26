using System.Collections.Generic;
using System.Threading.Tasks;

namespace SupermercadosApp.API.Interfaces
{
    public interface IRepositorio<T> where T : class
    {
        Task<IEnumerable<T>> ObtenerTodosAsync();
        Task<T> ObtenerPorIdAsync(int id);
        Task<T> CrearAsync(T entidad);
        Task<bool> ActualizarAsync(T entidad);
        Task<bool> EliminarAsync(int id);
        Task<bool> GuardarCambiosAsync();
    }
}