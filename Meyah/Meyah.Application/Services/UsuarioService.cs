using Meyah.Domain.Entities;
using Meyah.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Meyah.Application.Services
{
    public class UsuarioService : IUsuariosService
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioService(IUsuarioRepository repository)
        {
            this._repository = repository;
        }

        public async Task AddUsuario(Usuario usuario)
        {
            await _repository.AddUsuario(usuario);
        }

        public async Task<bool> DeleteUsuario(int id)
        {
            return await _repository.DeleteUsuario (id);
        }

        public async Task<Usuario> GetUsuario(int id)
        {
            return await _repository.GetUsuario(id);
        }
        public async Task<IEnumerable<Usuario>> GetUsuarios()
        {
            return await _repository.GetUsuarios();
        }
        public Task<bool> UpdateUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
