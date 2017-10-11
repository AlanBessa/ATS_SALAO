using CryptSharp;

namespace SBP.Domain.SharedKernel.Helpers
{
    public class PasswordHelper
    {
        public static string Criptografar(string senha)
        {
            if (string.IsNullOrEmpty(senha))
                return string.Empty;

            return Crypter.Blowfish.Crypt(senha);
        }

        public static bool CompararSenhas(string senha, string hash)
        {
            return Crypter.CheckPassword(senha, hash);
        }


        public static string RemoverCaracterEspecial(string texto)
        {
            if (texto == null) return string.Empty;

            const string caracteresEspeciais = "()-[]{}+=_*%$#@/\\|~^´`";

            for (var i = 0; i < caracteresEspeciais.Length; i++)
                texto = texto.Replace(caracteresEspeciais[i].ToString(), string.Empty);

            return texto;
        }
    }
}
