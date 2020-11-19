using System;
using System.Collections.Generic;
using System.Text;

namespace Meyah.Domain.DTOs
{
    public class PedidoRequestDto
    {
        public DateTime Fechapedido { get; set; }
        public DateTime Fechaentrega { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public int ProductoId { get; set; }
        public int ClienteId { get; set; }
        public bool Estado { get; set; }
        public DateTime Modificado { get; set; }
    }
}
