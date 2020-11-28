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
    public class EmpleadoController : ControllerBase
    {
        private readonly IEmpleadoService _service;
        private readonly IMapper _mapper;
        public EmpleadoController(IEmpleadoService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var empleados = await _service.GetEmpleados();
            var empleadosDto = _mapper.Map<IEnumerable<Empleado>, IEnumerable<EmpleadoResponseDto>>(empleados);
            var response = new ApiResponse<IEnumerable<EmpleadoResponseDto>>(empleadosDto);
            return Ok(response);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var empleado = await _service.GetEmpleado(id);
            var empleadoDto = _mapper.Map<Empleado, EmpleadoResponseDto>(empleado);
            var response = new ApiResponse<EmpleadoResponseDto>(empleadoDto);
            return Ok(response);
        }
        public async Task<IActionResult> Post(EmpleadoRequestDto empleadoDto)
        {
            var empleado = _mapper.Map<EmpleadoRequestDto, Empleado>(empleadoDto);
            await _service.AddEmpleado(empleado);
            var pedidoresponseDto = _mapper.Map<Empleado, EmpleadoResponseDto>(empleado);
            return Ok(pedidoresponseDto);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteEmpleado(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, EmpleadoRequestDto empleadoDto)
        {
            var empleado = _mapper.Map<Empleado>(empleadoDto);
            empleado.EmpleadoId = id;
            empleado.Modificado = DateTime.Now;
            var result = await _service.UpdateEmpleado(empleado);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}