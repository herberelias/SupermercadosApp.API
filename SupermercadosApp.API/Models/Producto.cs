using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupermercadosApp.API.Models
{
    public class Producto
    {
        public int ProductoID { get; set; }

        public int CategoriaID { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [StringLength(500)]
        public string Descripcion { get; set; }

        [StringLength(255)]
        public string ImagenURL { get; set; }

        [StringLength(50)]
        public string CodigoBarras { get; set; }

        [StringLength(50)]
        public string UnidadMedida { get; set; }

        // Propiedad de navegación
        [ForeignKey("CategoriaID")]
        public Categoria Categoria { get; set; }
    }
}