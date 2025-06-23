using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MbolosApi.Interfaces
{
    public interface IPasswordService
    {
        string PasswordHash(string password);
        bool VerifyPassword(string password, string hashedPassword);
    }
}