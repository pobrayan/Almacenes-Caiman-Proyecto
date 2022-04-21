using System;
using System.Collections.Generic;

namespace Almacenes_Caiman_Proyecto.Entidades
{
    public partial class Categoria
    {
        public Categoria()
        {
            Productos = new HashSet<Producto>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; } = null!;
        public DateTime? Fecha { get; set; }
        public DateTime FechaDeCreacion { get; set; }
        public DateTime? Fechademodificacion { get; set; }
        public string? Estado { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
