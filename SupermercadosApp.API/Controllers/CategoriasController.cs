using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupermercadosApp.API.DTOs;
using SupermercadosApp.API.Interfaces;
using SupermercadosApp.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SupermercadosApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;
        private readonly IMapper _mapper;

        public CategoriasController(ICategoriaRepositorio categoriaRepositorio, IMapper mapper)
        {
            _categoriaRepositorio = categoriaRepositorio;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaDto>>> GetCategorias()
        {
            var categorias = await _categoriaRepositorio.ObtenerTodosAsync();
            return Ok(_mapper.Map<IEnumerable<CategoriaDto>>(categorias));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaDto>> GetCategoria(int id)
        {
            var categoria = await _categoriaRepositorio.ObtenerPorIdAsync(id);

            if (categoria == null)
                return NotFound();

            return Ok(_mapper.Map<CategoriaDto>(categoria));
        }

        [HttpGet("{id}/productos")]
        public async Task<ActionResult<CategoriaDto>> GetCategoriaConProductos(int id)
        {
            var categoria = await _categoriaRepositorio.ObtenerCategoriaConProductosAsync(id);

            if (categoria == null)
                return NotFound();

            return Ok(_mapper.Map<CategoriaDto>(categoria));
        }

        [HttpPost]
        public async Task<ActionResult<CategoriaDto>> PostCategoria(CategoriaCreacionDto categoriaDto)
        {
            var categoria = _mapper.Map<Categoria>(categoriaDto);

            await _categoriaRepositorio.CrearAsync(categoria);

            return CreatedAtAction(nameof(GetCategoria), new { id = categoria.CategoriaID },
                _mapper.Map<CategoriaDto>(categoria));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoria(int id, CategoriaActualizacionDto categoriaDto)
        {
            var categoriaExistente = await _categoriaRepositorio.ObtenerPorIdAsync(id);

            if (categoriaExistente == null)
                return NotFound();

            _mapper.Map(categoriaDto, categoriaExistente);

            await _categoriaRepositorio.ActualizarAsync(categoriaExistente);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoria(int id)
        {
            var resultado = await _categoriaRepositorio.EliminarAsync(id);

            if (!resultado)
                return NotFound();

            return NoContent();
        }
    }
}