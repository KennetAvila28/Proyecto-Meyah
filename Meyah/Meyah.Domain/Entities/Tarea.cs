using System;
using System.Collections.Generic;
using Meyah.Domain.Entities;
#nullable disable

namespace Meyah.Domain.Entities
{
    public partial class Tarea
    {
        public int TareaId { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime Fechaentrega { get; set; }
        public DateTime Creado { get; set; }
        public DateTime? Modificado { get; set; }
        public int PedidoId { get; set; }
        public int EmpleadoId { get; set; }

        public virtual Empleado Empleado { get; set; }
        public virtual Pedido Pedido { get; set; }
    }
}
