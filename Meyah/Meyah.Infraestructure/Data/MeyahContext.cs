using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Meyah.Domain.Entities;
using Meyah.Infraestructure.Repositories;
using Meyah.Infraestructure.Data.Configurations;

namespace Meyah.Infraestructure.Data
{
    public partial class MeyahContext : DbContext
    {
        public MeyahContext()
        {
        }

        public MeyahContext(DbContextOptions<MeyahContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Empleado> Empleados { get; set; }
        public virtual DbSet<Pedido> Pedidos { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Tarea> Tareas { get; set; }
        public virtual DbSet<Tipo> Tipos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Cliente>(new ClienteConfiguration());
            modelBuilder.ApplyConfiguration<Empleado>(new EmpleadoConfiguration());
            modelBuilder.ApplyConfiguration<Pedido>(new PedidoConfiguration());
            modelBuilder.ApplyConfiguration<Producto>(new ProductoConfiguration());
            modelBuilder.ApplyConfiguration<Tarea>(new TareaConfiguration());
            modelBuilder.ApplyConfiguration<Tipo>(new TipoConfiguration());
            modelBuilder.ApplyConfiguration<Usuario>(new UsuarioConfiguration());
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
