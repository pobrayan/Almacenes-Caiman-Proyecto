using System;
using System.Collections.Generic;

namespace Almacenes_Caiman_Proyecto.Entidades
{
    public partial class Venta
    {
        public Venta()
        {
            Detallesventa = new HashSet<Detallesventa>();
        }

        public int Idventa { get; set; }
        public int Idclientes { get; set; }
        public decimal Descuento { get; set; }
        public DateTime FechaDeCreacion { get; set; }
        public DateTime? Fechademodificacion { get; set; }
        public string Estado { get; set; } = null!;

        public virtual Cliente IdclientesNavigation { get; set; } = null!;
        public virtual ICollection<Detallesventa> Detallesventa { get; set; }
    }
}
