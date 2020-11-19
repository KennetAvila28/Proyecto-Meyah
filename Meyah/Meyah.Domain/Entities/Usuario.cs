using System;
using System.Collections.Generic;
using Meyah.Domain.Entities;
#nullable disable

namespace Meyah.Domain.Entities
{
    public partial class Usuario
    {
        public Usuario()
        {
            Clientes = new HashSet<Cliente>();
            Empleados = new HashSet<Empleado>();
        }
        public int UsuarioId { get; set; }
        public string Email { get; set; }
        public string Contraseña { get; set; }
        public int TipoId { get; set; }

        public virtual Tipo Tipo { get; set; }
        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}
