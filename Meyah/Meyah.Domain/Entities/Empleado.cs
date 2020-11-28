using Meyah.Domain.Entities;
using System;
using System.Collections.Generic;

#nullable disable

namespace Meyah.Domain.Entities
{
    public partial class Empleado
    {
        public Empleado()
        {
            Tareas = new HashSet<Tarea>();
        }

        public int EmpleadoId { get; set; }
        public string Nombreemp { get; set; }
        public string Apellidoem { get; set; }
        public DateTime Creado { get; set; }
        public DateTime? Modificado { get; set; }
        public int UsuarioId { get; set; }
        public string Telefono { get; set; }
        public DateTime Fechanacimiento { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<Tarea> Tareas { get; set; }
    }
}
