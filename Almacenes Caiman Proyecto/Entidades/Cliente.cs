using System;
using System.Collections.Generic;

namespace Almacenes_Caiman_Proyecto.Entidades
{
    public partial class Cliente
    {
        public Cliente()
        {
            Pedidos = new HashSet<Pedido>();
            Venta = new HashSet<Venta>();
        }

        public int Idclientes { get; set; }
        public string? Nit { get; set; }
        public string Nombres { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string? Telefono { get; set; }
        public string? Correo { get; set; }
        public DateTime FechaDeCreacion { get; set; }
        public DateTime? Fechademodificacion { get; set; }
        public string Estado { get; set; } = null!;

        public virtual ICollection<Pedido> Pedidos { get; set; }
        public virtual ICollection<Venta> Venta { get; set; }
    }
}
