using SupermercadosApp.API.Models;
using System.Threading.Tasks;

namespace SupermercadosApp.API.Interfaces
{
    public interface ICategoriaRepositorio : IRepositorio<Categoria>
    {
        Task<Categoria> ObtenerCategoriaConProductosAsync(int id);
    }
}