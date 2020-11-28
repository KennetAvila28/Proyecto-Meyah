using System;
using System.Collections.Generic;
using System.Text;

namespace Meyah.Domain.DTOs
{
    public class EmpleadoResponseDto
    {
        public int EmpleadoId { get; set; }
        public string Nombreemp { get; set; }
        public string Apellidoem { get; set; }
        public DateTime Creado { get; set; }
        public DateTime Modificado { get; set; }
        public int UsuarioId { get; set; }
        public string Telefono { get; set; }
        public DateTime Fechanacimiento { get; set; }
    }
}
