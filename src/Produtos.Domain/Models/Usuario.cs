namespace Produtos.Domain.Models;

public class Usuario
{
	#region Propriedades

	public Guid IdUsuario { get; set; }
	public string Nome { get; set; }
	public string Login { get; set; }
	public string Senha { get; set; }

    public byte[] Foto { get; set; }
    #endregion
}
