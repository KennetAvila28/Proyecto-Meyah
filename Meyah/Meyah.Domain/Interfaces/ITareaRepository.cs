using Meyah.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Meyah.Domain.Interfaces
{
    public interface ITareaRepository
    {
        Task<IEnumerable<Tarea>> GetTareas();
        Task<Tarea> GetTarea(int id);
        Task AddTarea(Tarea tarea);
        Task<bool> UpdateTarea(Tarea tarea);
        Task<bool> DeleteTarea(int id);
    }
}
