using Meyah.Domain.Entities;
using Meyah.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Meyah.Application.Services
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly IEmpleadoRepository _repository;

        public EmpleadoService(IEmpleadoRepository repository)
        {
            this._repository = repository;
        }
        public async Task AddEmpleado(Empleado empleado)
        {
            await _repository.AddEmpleado(empleado);
        }

        public async Task<bool> DeleteEmpleado(int id)
        {
            return await _repository.DeleteEmpleado(id);
        }

        public async Task<Empleado>GetEmpleado (int id)
        {
            return await _repository.GetEmpleado(id);
        }

        public async Task<IEnumerable<Empleado>> GetEmpleados()
        {
            return await _repository.GetEmpleados();
        }

        public async Task<bool> UpdateEmpleado(Empleado empleado)
        {
            return await _repository.UpdateEmpleado(empleado);
        }
    }
}
