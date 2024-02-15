using Produtos.Domain.Interfaces.Repositories;
using Produtos.Domain.Interfaces.Services;
using Produtos.Domain.Models;

namespace Produtos.Domain.Services;

public class UsuarioDomainService : IUsuarioDomainService
{
    private readonly IUsuarioRepository _usuarioRepository;

    public UsuarioDomainService(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
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

    public async Task<Usuario> Get(string login, string senha)
    {
        var usuario = await _usuarioRepository.Get(login, senha);
        return usuario;
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
}
