using System;
using System.Collections.Generic;
using System.Text;

namespace Meyah.Domain.DTOs
{
    public class ClienteRequestDto
    {       
        public string Nombrecl { get; set; }
        public string Apellidocl { get; set; }
        public DateTime Nacimiento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public DateTime Creado { get; set; }
        public DateTime? Modificado { get; set; }
        public int UsuarioId { get; set; }
    }
}
