using System.Security.Cryptography;
using System.Text;

namespace Produtos.Infra.Data.Utils;

public static class MD5Util
{
    public static string Get(string value)
    {
        var hash = new MD5CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(value));

        var result = string.Empty;
        foreach (var b in hash)
        {
            result += b.ToString("x2");
        }

        return result;
    }
}
