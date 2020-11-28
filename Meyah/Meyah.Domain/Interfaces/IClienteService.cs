using Meyah.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Meyah.Domain.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<Cliente>> GetClientes();
        Task<Cliente> GetCliente(int id);
        Task AddCliente(Cliente cliente);
        Task<bool> UpdateCliente (Cliente cliente);
        Task<bool> DeleteCliente(int id);
    }
}
