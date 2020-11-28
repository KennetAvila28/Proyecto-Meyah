using System;
using System.Collections.Generic;
using System.Text;

namespace Meyah.Domain.DTOs
{
    public class UsuarioRequestDto
    {
        public string Email { get; set; }
        public string Contraseña { get; set; }
        public int TipoId { get; set; }
    }
}
