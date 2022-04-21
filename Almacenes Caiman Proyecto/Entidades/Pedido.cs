using System;
using System.Collections.Generic;

namespace Almacenes_Caiman_Proyecto.Entidades
{
    public partial class Pedido
    {
        public int Id { get; set; }
        public int? Idcliente { get; set; }
        public double? Monto { get; set; }

        public virtual Cliente? IdclienteNavigation { get; set; }
    }
}
