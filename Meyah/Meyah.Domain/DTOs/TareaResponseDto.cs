using System;
using System.Collections.Generic;
using System.Text;

namespace Meyah.Domain.DTOs
{
    public class TareaResponseDto
    {
        public int TareaId { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime Fechaentrega { get; set; }
        public DateTime Creado { get; set; }
        public DateTime? Modificado { get; set; }
        public int PedidoId { get; set; }
        public int EmpleadoId { get; set; }
    }
}
