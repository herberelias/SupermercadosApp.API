using Microsoft.EntityFrameworkCore;
using SupermercadosApp.API.Data;
using SupermercadosApp.API.Interfaces;
using SupermercadosApp.API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupermercadosApp.API.Repositories
{
    public class ProductoRepositorio : Repositorio<Producto>, IProductoRepositorio
    {
        public ProductoRepositorio(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Producto>> ObtenerProductosPorCategoriaAsync(int categoriaId)
        {
            return await _context.Productos
                .Include(p => p.Categoria)
                .Where(p => p.CategoriaID == categoriaId)
                .ToListAsync();
        }

        public async Task<Producto> ObtenerProductoConCategoriaAsync(int id)
        {
            return await _context.Productos
                .Include(p => p.Categoria)
                .FirstOrDefaultAsync(p => p.ProductoID == id);
        }
    }
}