namespace Almacenes_Caiman_Proyecto.Entidades.Productos
{
    public class ProductoRequest
    {
        public string Descripcion { get; set; } = null!;
        public int Categoria { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal Precioventa { get; set; }
        public int? Stock { get; set; }
        public string Estado { get; set; } = null!;

    }
}
