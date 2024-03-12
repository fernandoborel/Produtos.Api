using Microsoft.EntityFrameworkCore;
using Produtos.Domain.Interfaces.Repositories;
using Produtos.Domain.Models;
using Produtos.Infra.Data.Contexts;
using Produtos.Infra.Data.Utils;

namespace Produtos.Infra.Data.Repositories;

public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
{
    private readonly SqlServerContext _context;

    public UsuarioRepository(SqlServerContext context) : base(context)
    {
        _context = context;
    }

    public async Task AddAsync(Usuario usuario)
    {
        usuario.Senha = MD5Util.Get(usuario.Senha);
        await base.AddAsync(usuario);
    }

    public async Task UpdateAsync(Usuario usuario)
    {
        usuario.Senha = MD5Util.Get(usuario.Senha);
        await base.UpdateAsync(usuario);
    }
    public async Task<Usuario> Get(string login)
    {
        return await _context.Usuarios
            .FirstOrDefaultAsync(u => u.Login.Equals(login));
    }

    public async Task<Usuario> Get(string login, string senha)
    {
        senha = MD5Util.Get(senha);

        return await _context.Usuarios
            .FirstOrDefaultAsync(u => u.Login.Equals(login) && u.Senha.Equals(senha));
    }

}
