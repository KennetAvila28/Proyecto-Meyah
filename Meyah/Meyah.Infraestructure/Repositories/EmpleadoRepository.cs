using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Meyah.Domain.Entities;
using Meyah.Domain.Interfaces;
using Meyah.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Meyah.Infraestructure.Repositories
{
    public class EmpleadoRepository : IEmpleadoRepository
    {
        private readonly MeyahContext _context;
        public EmpleadoRepository (MeyahContext context)
        {
            this._context = context;
        }
        public async Task AddEmpleado(Empleado empleado)
        {
            _context.Empleados.Add(empleado);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteEmpleado(int id)
        {
            var current = await GetEmpleado(id);
            _context.Empleados.Remove(current);
            var rowsDelete = await _context.SaveChangesAsync();
            return rowsDelete > 0;
        }

        public async Task<Empleado> GetEmpleado(int id)
        {
            return await _context.Empleados.SingleOrDefaultAsync(Empleado => Empleado.EmpleadoId == id)
               ?? new Empleado();
        }

        public async Task<IEnumerable<Empleado>> GetEmpleados()
        {
            return await _context.Empleados.ToListAsync();
        }

        public async Task<bool> UpdateEmpleado(Empleado empleado)
        {
            var current = await GetEmpleado(empleado.EmpleadoId);
            current.Nombreemp = empleado.Nombreemp;
            current.Apellidoem = empleado.Apellidoem;
            current.Telefono = empleado.Telefono;
            current.Fechanacimiento = empleado.Fechanacimiento;
            current.Modificado = DateTime.Now;
            var rowsUpdate = await _context.SaveChangesAsync();
            return rowsUpdate > 0;
        }
    }
}
