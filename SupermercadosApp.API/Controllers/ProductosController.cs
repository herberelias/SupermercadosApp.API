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
    public class ProductosController : ControllerBase
    {
        private readonly IProductoRepositorio _productoRepositorio;
        private readonly IMapper _mapper;

        public ProductosController(IProductoRepositorio productoRepositorio, IMapper mapper)
        {
            _productoRepositorio = productoRepositorio;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductoDto>>> GetProductos()
        {
            var productos = await _productoRepositorio.ObtenerTodosAsync();
            return Ok(_mapper.Map<IEnumerable<ProductoDto>>(productos));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoDto>> GetProducto(int id)
        {
            var producto = await _productoRepositorio.ObtenerProductoConCategoriaAsync(id);

            if (producto == null)
                return NotFound();

            return Ok(_mapper.Map<ProductoDto>(producto));
        }

        [HttpGet("categoria/{categoriaId}")]
        public async Task<ActionResult<IEnumerable<ProductoDto>>> GetProductosPorCategoria(int categoriaId)
        {
            var productos = await _productoRepositorio.ObtenerProductosPorCategoriaAsync(categoriaId);
            return Ok(_mapper.Map<IEnumerable<ProductoDto>>(productos));
        }

        [HttpPost]
        public async Task<ActionResult<ProductoDto>> PostProducto(ProductoCreacionDto productoDto)
        {
            var producto = _mapper.Map<Producto>(productoDto);

            await _productoRepositorio.CrearAsync(producto);

            return CreatedAtAction(nameof(GetProducto), new { id = producto.ProductoID },
                _mapper.Map<ProductoDto>(producto));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducto(int id, ProductoActualizacionDto productoDto)
        {
            var productoExistente = await _productoRepositorio.ObtenerPorIdAsync(id);

            if (productoExistente == null)
                return NotFound();

            _mapper.Map(productoDto, productoExistente);

            await _productoRepositorio.ActualizarAsync(productoExistente);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            var resultado = await _productoRepositorio.EliminarAsync(id);

            if (!resultado)
                return NotFound();

            return NoContent();
        }
    }
}