﻿using AutoMapper;
using Produtos.Application.Commands;
using Produtos.Application.Interfaces;
using Produtos.Domain.Interfaces.Services;
using Produtos.Domain.Models;

namespace Produtos.Application.Services;

public class UsuarioAppService : IUsuarioAppService
{
    private readonly IUsuarioDomainService _usuarioDomainService;
    private readonly IMapper _mapper;

    public UsuarioAppService(IUsuarioDomainService usuarioDomainService, IMapper mapper)
    {
        _usuarioDomainService = usuarioDomainService;
        _mapper = mapper;
    }

    public async Task Adicionar(CriarUsuarioCommand command)
    {
        var usuario = _mapper.Map<Usuario>(command);
        await _usuarioDomainService.Adicionar(usuario);
    }

    public async Task Atualizar(AlterarUsuarioCommand command)
    {
        var usuario = await _usuarioDomainService.ObterPorId(command.Id);
        
        if (usuario != null)
        {
            usuario.Nome = command.Nome;
            usuario.Login = command.Login;
            usuario.Senha = command.Senha;

            await _usuarioDomainService.Atualizar(usuario);
        }
    }

    public async Task Remover(Guid id)
    {
        var usuario = await _usuarioDomainService.ObterPorId(id);
        if (usuario != null)
        {
            await _usuarioDomainService.Remover(id);
        }
    }

    public void Dispose()
    {
        _usuarioDomainService.Dispose();
    }

    public async Task<Usuario> ObterPorId(Guid id)
    {
        var usuario = await _usuarioDomainService.ObterPorId(id);
        return usuario;
    }

    public async Task<Usuario> ObterPorLogin(string login, string senha)
    {
        var usuario = await _usuarioDomainService.Get(login, senha);
        return usuario;
    }

    public async Task<IEnumerable<Usuario>> ObterTodos()
    {
        var usuarios = await _usuarioDomainService.ObterTodos();
        return usuarios;
    }
}
