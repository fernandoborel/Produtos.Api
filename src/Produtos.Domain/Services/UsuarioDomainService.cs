using Produtos.Domain.Interfaces.Repositories;
using Produtos.Domain.Interfaces.Security;
using Produtos.Domain.Interfaces.Services;
using Produtos.Domain.Models;
using System.Security.Authentication;

namespace Produtos.Domain.Services;

public class UsuarioDomainService : IUsuarioDomainService
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IAuthorizationSecurity _authorizationSecurity;

    public UsuarioDomainService(IUsuarioRepository usuarioRepository, IAuthorizationSecurity authorizationSecurity)
    {
        _usuarioRepository = usuarioRepository;
        _authorizationSecurity = authorizationSecurity;
    }

    public async Task Adicionar(Usuario usuario)
    {
        await _usuarioRepository.AddAsync(usuario);
    }

    public async Task Atualizar(Usuario usuario)
    {
        await _usuarioRepository.UpdateAsync(usuario);
    }

    public async Task Remover(Guid id)
    {
        var usuario = await _usuarioRepository.GetAsync(id);
        await _usuarioRepository.DeleteAsync(usuario);
    }

    public void Dispose()
    {
        _usuarioRepository.Dispose();
    }

    public async Task<Usuario> ObterPorId(Guid id)
    {
        var usuario = await _usuarioRepository.GetAsync(id);
        return usuario;
    }

    public async Task<IEnumerable<Usuario>> ObterTodos()
    {
        return await _usuarioRepository.GetAllAsync();
    }

    public async Task<AuthorizationModel> AutenticarUsuarioAsync(string login, string senha)
    {
        var usuario = await _usuarioRepository.Get(login, senha);

        if (usuario != null)
            return new AuthorizationModel
            {
                IdUsuario = usuario.IdUsuario,
                Nome = usuario.Nome,
                Login = usuario.Login,
                DataHoraAcesso = DateTime.Now,
                AccessToken = _authorizationSecurity.CreateToken(usuario)
            };

        throw new AuthenticationException("Falha na autenticação: usuário não encontrado");
    }
}
