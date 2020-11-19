using System;
using System.Collections.Generic;
using System.Text;

namespace Meyah.Domain.Entities
{
    public class Detalle
    {
        public Detalle()
        {
            Pedidos = new HashSet<Pedido>();
        }
        public int DetalleId { get; set; }
        public string Comentario { get; set; }
        public string foto { get; set; }
        public DateTime Creado { get; set; }

        public virtual Pedido Pedido { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }

}
