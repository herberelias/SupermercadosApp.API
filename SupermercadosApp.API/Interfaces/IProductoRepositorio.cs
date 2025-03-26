using SupermercadosApp.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SupermercadosApp.API.Interfaces
{
    public interface IProductoRepositorio : IRepositorio<Producto>
    {
        Task<IEnumerable<Producto>> ObtenerProductosPorCategoriaAsync(int categoriaId);
        Task<Producto> ObtenerProductoConCategoriaAsync(int id);
    }
}