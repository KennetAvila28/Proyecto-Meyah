using Meyah.Domain.Entities;
using System;
using System.Collections.Generic;

#nullable disable

namespace Meyah.Domain.Entities
{
    public partial class Pedido
    {
        public Pedido()
        {
            Tareas = new HashSet<Tarea>();
        }

        public int PedidoId { get; set; }
        public DateTime Fechapedido { get; set; }
        public DateTime? Fechaentrega { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public int ProductoId { get; set; }
        public int ClienteId { get; set; }
        public bool? Estado { get; set; }
        public DateTime? Modificado { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual Producto Producto { get; set; }
        public virtual ICollection<Tarea> Tareas { get; set; }
    }
}
