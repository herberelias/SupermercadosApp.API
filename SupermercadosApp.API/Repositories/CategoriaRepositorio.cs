using Microsoft.EntityFrameworkCore;
using SupermercadosApp.API.Data;
using SupermercadosApp.API.Interfaces;
using SupermercadosApp.API.Models;
using System.Threading.Tasks;

namespace SupermercadosApp.API.Repositories
{
    public class CategoriaRepositorio : Repositorio<Categoria>, ICategoriaRepositorio
    {
        public CategoriaRepositorio(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Categoria> ObtenerCategoriaConProductosAsync(int id)
        {
            return await _context.Categorias
                .Include(c => c.Productos)
                .FirstOrDefaultAsync(c => c.CategoriaID == id);
        }
    }
}