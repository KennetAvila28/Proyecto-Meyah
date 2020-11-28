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
    public class UsuarioController : ControllerBase
    {

        private readonly IUsuariosService _service;
        private readonly IMapper _mapper;
        public UsuarioController (IUsuariosService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var usuario = await _service.GetUsuarios();
            var usuarioDto = _mapper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioResponseDto>>(usuario);
            var response = new ApiResponse<IEnumerable<UsuarioResponseDto>>(usuarioDto);
            return Ok(response);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var usuario = await _service.GetUsuario(id);
            var usuarioDto = _mapper.Map<Usuario, UsuarioResponseDto>(usuario);
            var response = new ApiResponse<UsuarioResponseDto>(usuarioDto);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> Post(UsuarioRequestDto usuarioDto)
        {
            var usuario = _mapper.Map<UsuarioRequestDto, Usuario>(usuarioDto);
            await _service.AddUsuario(usuario);
            var tareasponseDto = _mapper.Map<Usuario, Usuario>(usuario);
            return Ok(tareasponseDto);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, UsuarioRequestDto usuarioDto)
        {
            var usuario = _mapper.Map<Usuario>(usuarioDto);
            usuario.UsuarioId = id;           
            var result = await _service.UpdateUsuario(usuario);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteUsuario(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
