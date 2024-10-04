using BCrypt.Net;

namespace backend.Services
{
    public class Criptografia
    {
        public static string Criptografa(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public static bool Compara(string password, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }
    }
}
