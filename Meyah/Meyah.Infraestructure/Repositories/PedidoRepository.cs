using System;
using System.Collections.Generic;
using System.Text;
using Meyah.Domain.Entities;
using System.Linq;
using Meyah.Domain.Interfaces;
using System.Threading.Tasks;
using Meyah.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Meyah.Infraestructure.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly MeyahContext _context;
        public PedidoRepository(MeyahContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<Pedido>> GetPedidos()
        {
            return await _context.Pedidos.ToListAsync();
        }
        public async Task<Pedido> GetPedido(int id)
        {
            return await _context.Pedidos.SingleOrDefaultAsync(Pedido => Pedido.PedidoId==id)
                ?? new Pedido();
        }
        public async Task AddPedido(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> DeletePedido(int id)
        {
            var current = await GetPedido(id);
            _context.Pedidos.Remove(current);
            var rowsDelete = await _context.SaveChangesAsync();
            return rowsDelete > 0;
        }
        public async Task<bool> UpdatePedido(Pedido pedido)
        {
            var current = await GetPedido(pedido.PedidoId);
            current.Estado = pedido.Estado;
            current.Cantidad = pedido.Cantidad;
            current.Precio = pedido.Precio;
            current.ProductoId = pedido.ProductoId;
            current.ClienteId = pedido.ClienteId;
            current.Modificado = pedido.Modificado;
            var rowsUpdate = await _context.SaveChangesAsync();
            return rowsUpdate > 0;
        }
    }
}