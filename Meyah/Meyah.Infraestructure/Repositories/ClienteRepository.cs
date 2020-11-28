using Meyah.Domain.Entities;
using Meyah.Domain.Interfaces;
using Meyah.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Meyah.Infraestructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly MeyahContext _context;
        public ClienteRepository(MeyahContext context)
        {
            this._context = context;
        }

        public async Task AddCliente(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Deleteliente(int id)
        {
            var current = await GetCliente(id);
            _context.Clientes.Remove(current);
            var rowsDelete = await _context.SaveChangesAsync();
            return rowsDelete > 0;
        }

        public async Task<Cliente> GetCliente(int id)
        {
            return await _context.Clientes.SingleOrDefaultAsync(Cliente => Cliente.ClienteId == id)
               ?? new Cliente();
        }

        public async Task<IEnumerable<Cliente>> GetClientes()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<bool> UpdateCliente(Cliente cliente)
        {
            var current = await GetCliente(cliente.ClienteId);
            current.Nombrecl = cliente.Nombrecl;
            current.Apellidocl = cliente.Apellidocl;
            current.Direccion = cliente.Direccion;
            current.Telefono = cliente.Telefono;
            current.Nacimiento = cliente.Nacimiento;
            current.Modificado = DateTime.Now;
            var rowsUpdate = await _context.SaveChangesAsync();
            return rowsUpdate > 0;
        }
    }
}
