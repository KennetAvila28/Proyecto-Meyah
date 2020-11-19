using System;
using System.Collections.Generic;
using Meyah.Domain.Entities;
#nullable disable

namespace Meyah.Domain.Entities
{
    public partial class Tipo
    {
        public Tipo()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int TipoId { get; set; }
        public string Nombretipo { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
