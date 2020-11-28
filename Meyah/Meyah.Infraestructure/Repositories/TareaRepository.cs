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
    public class TareaRepository : ITareaRepository
    {
        private readonly MeyahContext _context;
        public TareaRepository (MeyahContext context)
        {
            this._context = context;
        }
        public async Task<IEnumerable<Tarea>> GetTareas()
        {
            return await _context.Tareas.ToListAsync();
        }
        public async Task<Tarea> GetTarea(int id)
        {
            return await _context.Tareas.SingleOrDefaultAsync(Tarea => Tarea.TareaId == id)
            ?? new Tarea();
        }
        public async Task AddTarea(Tarea tarea)
        {
            _context.Tareas.Add(tarea);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteTarea(int id)
        {
            var current = await GetTarea(id);
            _context.Tareas.Remove(current);
            var rowsDelete = await _context.SaveChangesAsync();
            return rowsDelete > 0;

        }
        
        public async Task<bool> UpdateTarea(Tarea tarea)
        {
            var current = await GetTarea(tarea.TareaId);
            current.Descripcion = tarea.Descripcion;
            current.PedidoId = tarea.PedidoId;
            current.EmpleadoId = tarea.EmpleadoId;
            current.Modificado = tarea.Modificado;
            var rowsUpdate = await _context.SaveChangesAsync();
            return rowsUpdate > 0;
        }
    }
}