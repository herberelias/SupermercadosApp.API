namespace SupermercadosApp.API.DTOs
{
    public class ProductoDto
    {
        public int ProductoID { get; set; }
        public int CategoriaID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string ImagenURL { get; set; }
        public string CodigoBarras { get; set; }
        public string UnidadMedida { get; set; }
        public string CategoriaNombre { get; set; }
    }

    public class ProductoCreacionDto
    {
        public int CategoriaID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string ImagenURL { get; set; }
        public string CodigoBarras { get; set; }
        public string UnidadMedida { get; set; }
    }

    public class ProductoActualizacionDto
    {
        public int CategoriaID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string ImagenURL { get; set; }
        public string CodigoBarras { get; set; }
        public string UnidadMedida { get; set; }
    }
}