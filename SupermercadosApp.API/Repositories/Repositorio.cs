using Microsoft.EntityFrameworkCore;
using SupermercadosApp.API.Data;
using SupermercadosApp.API.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SupermercadosApp.API.Repositories
{
    public class Repositorio<T> : IRepositorio<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repositorio(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> ObtenerTodosAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> ObtenerPorIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> CrearAsync(T entidad)
        {
            await _dbSet.AddAsync(entidad);
            await GuardarCambiosAsync();
            return entidad;
        }

        public async Task<bool> ActualizarAsync(T entidad)
        {
            _dbSet.Update(entidad);
            return await GuardarCambiosAsync();
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var entidad = await ObtenerPorIdAsync(id);
            if (entidad == null)
                return false;

            _dbSet.Remove(entidad);
            return await GuardarCambiosAsync();
        }

        public async Task<bool> GuardarCambiosAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}       