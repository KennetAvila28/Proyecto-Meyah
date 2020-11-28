using Meyah.Domain.Entities;
using Meyah.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Meyah.Application.Services
{
    public class TareaService : ITareaService
    {
        private readonly ITareaRepository _repository;
        public TareaService(ITareaRepository repository)
        {
            this._repository = repository;
        }
        public async Task<IEnumerable<Tarea>> GetTareas()
        {
            return await _repository.GetTareas();
        }

        public async Task<Tarea> GetTarea(int id)
        {
            return await _repository.GetTarea(id);
        }

        public async Task AddTarea(Tarea tarea)
        {
            await _repository.AddTarea(tarea);
        }

        public async Task<bool> DeleteTarea(int id)
        {
            return await _repository.DeleteTarea(id);
        }        

        public async Task<bool> UpdateTarea(Tarea tarea)
        {
            return await _repository.UpdateTarea(tarea);
        }
    }
}
