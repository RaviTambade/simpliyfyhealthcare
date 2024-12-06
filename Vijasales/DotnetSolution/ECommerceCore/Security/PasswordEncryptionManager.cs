
namespace VijaySales.Security
{
    public static class PasswordEncryptionManager
    {
        public static string Encrypt(string password)
        {
            var hashed = BCrypt.Net.BCrypt.HashPassword(password, 10);
            return hashed.ToString();
        }

        public static bool Verify(string password, string dbpassword)
        {
            var hashed = BCrypt.Net.BCrypt.Verify(password, dbpassword);
            return hashed;
        }
    }
}
