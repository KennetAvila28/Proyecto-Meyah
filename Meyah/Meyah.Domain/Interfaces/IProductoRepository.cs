using Meyah.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Meyah.Domain.Interfaces
{
    public interface IProductoRepository
    {
        Task<IEnumerable<Producto>> GetProductos();
        Task<Producto> GetProducto(int id);
        Task AddProducto(Producto producto);
        Task<bool> UpdateProducto(Producto producto);
        Task<bool> DeleteProducto(int id);
    }
}
