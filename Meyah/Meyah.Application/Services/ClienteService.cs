using Meyah.Domain.Entities;
using Meyah.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Meyah.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;

        public ClienteService(IClienteRepository repository)
        {
            this._repository = repository;
        }

        public async Task AddCliente(Cliente cliente)
        {
            await _repository.AddCliente(cliente);
        }

        public async Task<bool> DeleteCliente(int id)
        {
            return await _repository.Deleteliente(id);
        }

        public async Task<Cliente> GetCliente(int id)
        {
            return await _repository.GetCliente(id);
        }

        public async Task<IEnumerable<Cliente>> GetClientes()
        {
            return await _repository.GetClientes();
        }

        public async Task<bool> UpdateCliente(Cliente cliente)
        {
            return await _repository.UpdateCliente(cliente);
        }
    }
}
