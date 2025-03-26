using AutoMapper;
using SupermercadosApp.API.DTOs;
using SupermercadosApp.API.Models;

namespace SupermercadosApp.API.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // Mapeos para Categoría
            CreateMap<Categoria, CategoriaDto>();
            CreateMap<CategoriaCreacionDto, Categoria>();
            CreateMap<CategoriaActualizacionDto, Categoria>();

            // Mapeos para Producto
            CreateMap<Producto, ProductoDto>()
                .ForMember(dest => dest.CategoriaNombre, opt => opt.MapFrom(src => src.Categoria.Nombre));
            CreateMap<ProductoCreacionDto, Producto>();
            CreateMap<ProductoActualizacionDto, Producto>();
        }
    }
}