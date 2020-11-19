﻿using Meyah.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Meyah.Application.Services
{
    public interface IPedidoService
    {
        Task<IEnumerable<Pedido>> GetPedidos();
        Task<Pedido> GetPedido(int id);
        Task AddPedido(Pedido pedido);  
        Task<bool> UpdatePedido(Pedido pedido);
        Task<bool> DeletePedido(int id);
    }
}
