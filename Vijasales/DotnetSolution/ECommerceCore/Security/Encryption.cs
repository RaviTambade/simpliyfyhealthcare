namespace Security
{
    public static class Encryption
    {
        public static string EncryptPassword(string password)
        {
            var hashed = BCrypt.Net.BCrypt.HashPassword(password, 10);
            return hashed.ToString();
        }

        public static bool CheckDecryptPassword(string password, string dbpassword)
        {
            var hashed = BCrypt.Net.BCrypt.Verify(password, dbpassword);
            return hashed;
        }
    }
}
