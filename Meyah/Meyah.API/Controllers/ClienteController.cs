using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Meyah.API.Responses;
using Meyah.Domain.Interfaces;
using Meyah.Domain.DTOs;
using Meyah.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Meyah.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _service;
        private readonly IMapper _mapper;
        public ClienteController(IClienteService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var clientes = await _service.GetClientes();
            var clientesDto = _mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteResponseDto>>(clientes);
            var response = new ApiResponse<IEnumerable<ClienteResponseDto>>(clientesDto);
            return Ok(response);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var cliente = await _service.GetCliente(id);
            var clienteDto = _mapper.Map<Cliente, ClienteResponseDto>(cliente);
            var response = new ApiResponse<ClienteResponseDto>(clienteDto);
            return Ok(response);
        }
        public async Task<IActionResult> Post(ClienteRequestDto clienteDto)
        {
            var cliente = _mapper.Map<ClienteRequestDto, Cliente>(clienteDto);
            await _service.AddCliente(cliente);
            var pedidoresponseDto = _mapper.Map<Cliente, ClienteResponseDto>(cliente);
            return Ok(pedidoresponseDto);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteCliente(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, ClienteRequestDto clienteDto)
        {
            var cliente = _mapper.Map<Cliente>(clienteDto);
            cliente.ClienteId = id;
            cliente.Modificado = DateTime.Now;
            var result = await _service.UpdateCliente(cliente);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
