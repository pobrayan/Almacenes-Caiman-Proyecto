using System;
using System.Collections.Generic;

namespace Almacenes_Caiman_Proyecto.Entidades
{
    public partial class Detallesventa
    {
        public int Iddetallesventas { get; set; }
        public int? Idventa { get; set; }
        public int? Idproducto { get; set; }
        public int? Cantidad { get; set; }
        public decimal? PrecioVenta { get; set; }
        public DateTime? FechaDeCreacion { get; set; }
        public DateTime? Fechademodificacion { get; set; }
        public string? Estado { get; set; }

        public virtual Producto? IdproductoNavigation { get; set; }
        public virtual Venta? IdventaNavigation { get; set; }
    }
}
