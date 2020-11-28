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
    public class TareaController : ControllerBase
    {
        private readonly ITareaService _service;
        private readonly IMapper _mapper;
        public TareaController(ITareaService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var tareas = await _service.GetTareas();
            var tareasDto = _mapper.Map<IEnumerable<Tarea>, IEnumerable<TareaResponseDto>>(tareas);
            var response = new ApiResponse<IEnumerable<TareaResponseDto>>(tareasDto);
            return Ok(response);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var tarea = await _service.GetTarea(id);
            var tareasDto = _mapper.Map<Tarea, TareaResponseDto>(tarea);
            var response = new ApiResponse<TareaResponseDto>(tareasDto);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> Post(TareaRequestDto tareaDto)
        {
            var tarea = _mapper.Map<TareaRequestDto, Tarea>(tareaDto);
            await _service.AddTarea(tarea);
            var tareasponseDto = _mapper.Map<Tarea, Tarea>(tarea);
            return Ok(tareasponseDto);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, TareaRequestDto tareaDto)
        {
            var tarea = _mapper.Map<Tarea>(tareaDto);
            tarea.TareaId = id;
            tarea.Modificado = DateTime.Now;
            var result = await _service.UpdateTarea(tarea);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteTarea(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
