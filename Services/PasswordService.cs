using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MbolosApi.Interfaces;

namespace MbolosApi.Services
{
    public class PasswordService : IPasswordService
    {
        public string PasswordHash(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}