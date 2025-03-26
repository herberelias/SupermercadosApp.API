using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SupermercadosApp.API.Models
{
    public class Categoria
    {
        public int CategoriaID { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [StringLength(255)]
        public string Descripcion { get; set; }

        [StringLength(255)]
        public string ImagenURL { get; set; }

        // Propiedad de navegación
        public ICollection<Producto> Productos { get; set; }
    }
}