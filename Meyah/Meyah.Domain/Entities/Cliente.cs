using Meyah.Domain.Entities;
using System;
using System.Collections.Generic;

#nullable disable

namespace Meyah.Domain.Entities
{
    public partial class Cliente
    {
        public Cliente()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public int ClienteId { get; set; }
        public string Nombrecl { get; set; }
        public string Apellidocl { get; set; }
        public DateTime Nacimiento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public DateTime Creado { get; set; }
        public DateTime? Modificado { get; set; }
        public int UsuarioId { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
