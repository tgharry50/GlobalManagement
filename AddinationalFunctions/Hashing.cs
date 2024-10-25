
namespace GlobalManagement.AddinationalFunctions
{
    public class Hashing
    {
        public string Hash(string password)
        {
            string hash = BCrypt.Net.BCrypt.HashPassword(password);
            return hash;
        }
    }
}
