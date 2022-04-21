using System;
using System.Collections.Generic;

namespace Almacenes_Caiman_Proyecto.Entidades
{
    public partial class Vproducto
    {
        public int Idproducto { get; set; }
        public string Descripcion { get; set; } = null!;
        public decimal PrecioCompra { get; set; }
        public decimal Precioventa { get; set; }
        public decimal? Ganancia { get; set; }
    }
}
