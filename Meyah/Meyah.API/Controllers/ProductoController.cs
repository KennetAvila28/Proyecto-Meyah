using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Meyah.API.Responses;
using Meyah.Application.Services;
using Meyah.Domain.DTOs;
using Meyah.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Meyah.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _service;
        private readonly IMapper _mapper;
        public ProductoController (IProductoService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var productos = await _service.GetProductos();
            var productosDto = _mapper.Map<IEnumerable<Producto>, IEnumerable<ProductoResponseDto>>(productos);
            var response = new ApiResponse<IEnumerable<ProductoResponseDto>>(productosDto);
            return Ok(response);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var producto = await _service.GetProducto(id);
            var productosDto = _mapper.Map<Producto, ProductoResponseDto>(producto);
            var response = new ApiResponse<ProductoResponseDto>(productosDto);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> Post(ProductoRequestDto productoDto)
        {
            var producto = _mapper.Map<ProductoRequestDto, Producto>(productoDto);
            await _service.AddProducto(producto);
            var pedidoresponseDto = _mapper.Map<Producto, Producto>(producto);
            return Ok(pedidoresponseDto);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, ProductoRequestDto productoDto)
        {
            var producto = _mapper.Map<Producto>(productoDto);
            producto.ProductoId = id;            
            var result = await _service.UpdateProducto(producto);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteProducto(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
