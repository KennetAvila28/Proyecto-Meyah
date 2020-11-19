using Meyah.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Meyah.Application.Services
{
    public  interface IProductoService
    {
        Task<IEnumerable<Producto>> GetProductos();
        Task<Producto> GetProducto(int id);
        Task AddProducto(Producto producto);
        Task<bool> UpdateProducto(Producto producto);
        Task<bool> DeleteProducto(int id);
    }
}
