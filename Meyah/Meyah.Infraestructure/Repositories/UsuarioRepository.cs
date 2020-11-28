using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Meyah.Domain.Entities;
using Meyah.Domain.Interfaces;
using Meyah.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Meyah.Infraestructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly MeyahContext _context;
        public UsuarioRepository (MeyahContext context)
        {
            this._context = context;
        }

        public async Task AddUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteUsuario(int id)
        {
            var current = await GetUsuario(id);
            _context.Usuarios.Remove(current);
            var rowsDelete = await _context.SaveChangesAsync();
            return rowsDelete > 0;
        }

        public async Task<Usuario> GetUsuario(int id)
        {
           return await _context.Usuarios.SingleOrDefaultAsync(Usuario => Usuario.UsuarioId == id)
           ?? new Usuario();
        }

        public async Task<IEnumerable<Usuario>> GetUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<bool> UpdateUsuario(Usuario usuario)
        {
            var current = await GetUsuario(usuario.UsuarioId);
            current.Email = usuario.Email;
            current.Contraseña = usuario.Contraseña;    
            var rowsUpdate = await _context.SaveChangesAsync();
            return rowsUpdate > 0;
        }       
    }
}
