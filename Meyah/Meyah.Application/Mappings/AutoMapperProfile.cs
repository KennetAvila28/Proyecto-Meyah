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
            var empleado = new Empleado();
            var pedido = new Pedido();
            var producto = new Producto();
            var tarea = new Tarea();
            var cliente = new Cliente();
            var usuario = new Usuario();

            CreateMap<Usuario, UsuarioRequestDto>();
            CreateMap<Usuario, UsuarioResponseDto>();
            CreateMap<UsuarioRequestDto, Usuario>().AfterMap(
            ((source, destination) =>
            {                
            }));

            CreateMap<Cliente, ClienteRequestDto>();
            CreateMap<Cliente, ClienteResponseDto>();
            CreateMap<ClienteRequestDto, Cliente>().AfterMap(
            ((source, destination) =>
            {
                destination.Creado = DateTime.Now;
            }));
            CreateMap<Empleado, EmpleadoRequestDto>();
            CreateMap<Empleado, EmpleadoResponseDto>();
            CreateMap<EmpleadoRequestDto, Empleado>().AfterMap(
            ((source, destination) =>
            {
                destination.Creado = DateTime.Now;
            }));
            CreateMap<Tarea, TareaRequestDto>();
            CreateMap<Tarea, TareaResponseDto>();
            CreateMap<Producto, ProductoRequestDto>();
            CreateMap<TareaRequestDto, Tarea>().AfterMap(
            ((source, destination) =>
            {
                destination.FechaInicio = DateTime.Now;
                destination.Fechaentrega = DateTime.Now.AddDays(49);
                destination.Creado = DateTime.Now;
            }));
            CreateMap<Producto, ProductoResponseDto>();
            CreateMap<ProductoRequestDto, Producto>().AfterMap(
            ((source, destination) => 
            {             
            }));
            CreateMap<Pedido,PedidoRequestDto>();
            CreateMap<Pedido,PedidoResponseDto>();
            CreateMap<PedidoRequestDto, Pedido>().AfterMap(
            ((source, destination) => {
            destination.Fechapedido = DateTime.Now;
            destination.Fechaentrega = DateTime.Now.AddDays(50);
            //destination.Precio = (producto.Precio)*(pedido.Cantidad);            
            }));

        }

    }
}
