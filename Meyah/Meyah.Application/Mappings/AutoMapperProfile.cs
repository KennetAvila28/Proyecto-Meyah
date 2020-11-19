using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Meyah.Domain.Entities;
using Meyah.Domain.DTOs;

namespace Meyah.Application.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            var pedido = new Pedido();
            var producto = new Producto();
            CreateMap<Producto, ProductoRequestDto>();
            CreateMap<Producto, ProductoResponseDto>();
            CreateMap<ProductoRequestDto, Producto>().AfterMap(
            ((source, destination) => 
            {             
            }));
            CreateMap<Pedido,PedidoRequestDto>();
            CreateMap<Pedido,PedidoResponseDto>();
            CreateMap<PedidoRequestDto, Pedido>().AfterMap(
            ((source, destination) => {
            destination.Fechapedido = DateTime.Today;
            destination.Fechaentrega = DateTime.Today.AddDays(50);
            //destination.Precio = (producto.Precio)*(pedido.Cantidad);            
            }));

        }

    }
}
