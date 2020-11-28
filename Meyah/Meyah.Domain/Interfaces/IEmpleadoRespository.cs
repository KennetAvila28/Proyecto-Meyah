using Meyah.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Meyah.Domain.Interfaces
{
    public interface IEmpleadoRespository
    {
        // hará una tarea de inumerable una lista de empleado, llamado GetEmpleados
        Task<IEnumerable<Empleado>> GetEmpleados();
        Task<Empleado> GetEmpleado(int id);
        Task AddEmpleado(Empleado empleado);
        Task<bool> UpdateEmpleado(Empleado empleado);
        Task<bool> DeleteEmpleado(int id);

    }
}
