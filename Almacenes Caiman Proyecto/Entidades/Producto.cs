using System;
using System.Collections.Generic;

namespace Almacenes_Caiman_Proyecto.Entidades
{
    public partial class Producto
    {
        public Producto()
        {
            Detallesventa = new HashSet<Detallesventa>();
            Historialprecios = new HashSet<Historialprecio>();
        }

        public int Idproducto { get; set; }
        public string Descripcion { get; set; } = null!;
        public int Categoria { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal Precioventa { get; set; }
        public int? Stock { get; set; }
        public DateTime FechaDeCreacion { get; set; }
        public DateTime? Fechademodificacion { get; set; }
        public string Estado { get; set; } = null!;

        public virtual Categorias CategoriaNavigation { get; set; } = null!;
        public virtual ICollection<Detallesventa> Detallesventa { get; set; }
        public virtual ICollection<Historialprecio> Historialprecios { get; set; }
    }
}
