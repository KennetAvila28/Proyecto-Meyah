using Meyah.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Meyah.Domain.Interfaces
{
    public interface IEmpleadoService
    {
        Task<IEnumerable<Empleado>> GetEmpleados();
        Task<Empleado> GetEmpleado(int id);
        Task AddEmpleado(Empleado empleado);
        Task<bool> UpdateEmpleado(Empleado empleado);
        Task<bool> DeleteEmpleado(int id);

    }
}