namespace Security
{
    public class Encryption
    {
        public string EncryptPassword(string password)
        {
            var hashed = BCrypt.Net.BCrypt.HashPassword(password, 10);
            return hashed.ToString();
        }

        public bool CheckDecryptPassword(string password, string dbpassword)
        {
            var hashed = BCrypt.Net.BCrypt.Verify(password, dbpassword);
            return hashed;
        }
    }
}
