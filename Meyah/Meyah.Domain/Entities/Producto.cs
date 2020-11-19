using System;
using System.Collections.Generic;
using Meyah.Domain.Entities;

#nullable disable

namespace Meyah.Domain.Entities
{
    public partial class Producto
    {
        public Producto()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public int ProductoId { get; set; }
        public string Nombreprod { get; set; }
        public decimal Precio { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
