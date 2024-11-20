
using GlobalManagement.Database;
using GlobalManagement.Models._DefaultModels._User;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace GlobalManagement.AddinationalFunctions
{
    public class Hashing()
    {
        public string Hash(string password)
        {
            string hash = BCrypt.Net.BCrypt.HashPassword(password);
            return hash;
        }

        public bool Compare(string password, string hash)
        {   
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }
    }
}
