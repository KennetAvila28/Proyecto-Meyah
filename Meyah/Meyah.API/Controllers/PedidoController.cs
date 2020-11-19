using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Meyah.Domain.Entities;
using Meyah.Domain.Interfaces;
using Meyah.Infraestructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Meyah.Domain.DTOs;
using Microsoft.VisualBasic;
using AutoMapper;
using Meyah.API.Responses;
using Meyah.Application.Services;

namespace Meyah.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _service;
        private readonly IMapper _mapper;
        public PedidoController(IPedidoService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var pedidos = await _service.GetPedidos();
            var pedidosDto = _mapper.Map<IEnumerable<Pedido>, IEnumerable<PedidoResponseDto>>(pedidos);
            var response = new ApiResponse<IEnumerable<PedidoResponseDto>>(pedidosDto);
            return Ok(response);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var pedido = await _service.GetPedido(id);
            var pedidosDto = _mapper.Map<Pedido, PedidoResponseDto>(pedido);
            var response = new ApiResponse<PedidoResponseDto>(pedidosDto);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> Post(PedidoRequestDto pedidoDto)
        {
            var pedido = _mapper.Map<PedidoRequestDto, Pedido>(pedidoDto);
            await _service.AddPedido(pedido);
            var pedidoresponseDto = _mapper.Map<Pedido, PedidoResponseDto>(pedido);
            return Ok(pedidoresponseDto);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeletePedido(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, PedidoRequestDto pedidoDto)
        {
            var pedido = _mapper.Map<Pedido>(pedidoDto);
            pedido.PedidoId = id;
            pedido.Modificado = DateTime.Today;
            var result = await _service.UpdatePedido(pedido);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

    }
}
