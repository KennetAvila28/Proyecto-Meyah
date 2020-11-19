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
    public class ProductoRepository : IProductoRepository
    {
        private readonly MeyahContext _context;
        public ProductoRepository (MeyahContext context)
        {
            this._context = context;
        }
        public async Task<IEnumerable<Producto>> GetProductos()
        {
            return await _context.Productos.ToListAsync();
        }
        public async Task<Producto> GetProducto(int id)
        {
            return await _context.Productos.SingleOrDefaultAsync(Producto => Producto.ProductoId == id)
            ?? new Producto();
        }

        public async Task AddProducto(Producto producto)
        {
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateProducto(Producto producto)
        {
            var current = await GetProducto(producto.ProductoId);
            current.Nombreprod = producto.Nombreprod;
            current.Precio = producto.Precio;
            var rowsUpdate = await _context.SaveChangesAsync();
            return rowsUpdate > 0;
        }

        public async Task<bool> DeleteProducto(int id)
        {
            var current = await GetProducto(id);
            _context.Productos.Remove(current);
            var rowsDelete = await _context.SaveChangesAsync();
            return rowsDelete > 0;
        }
    }
}