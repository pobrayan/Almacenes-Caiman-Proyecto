﻿namespace Almacenes_Caiman_Proyecto.Entidades.ClientesContoller
{
    public class ClientesActualizar
    {
        public int Idclientes { get; set; }
        public string? Nit { get; set; }
        public string Nombres { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string? Telefono { get; set; }
        public string? Correo { get; set; }
        public string Estado { get; set; } = null!;
    }
}
