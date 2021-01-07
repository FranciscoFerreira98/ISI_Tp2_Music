using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISI_Tp2.Models;

namespace ISI_Tp2.Repositories
{
    public interface IUserRepository
    {
        List<User> InsertUser(string name, string password, string email);
        User GetUser(string email);
    }
}
