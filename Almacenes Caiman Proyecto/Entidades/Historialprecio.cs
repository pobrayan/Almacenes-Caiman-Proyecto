using System;
using System.Collections.Generic;

namespace Almacenes_Caiman_Proyecto.Entidades
{
    public partial class Historialprecio
    {
        public int Id { get; set; }
        public int Producto { get; set; }
        public decimal PrecioAntiguo { get; set; }
        public decimal NuevoPrecio { get; set; }
        public DateTime FechaDeCreacion { get; set; }
        public DateTime? Fechademodificacion { get; set; }
        public string Estado { get; set; } = null!;

        public virtual Producto ProductoNavigation { get; set; } = null!;
    }
}
