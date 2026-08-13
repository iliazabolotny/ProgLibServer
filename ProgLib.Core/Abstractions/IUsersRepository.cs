using Microsoft.EntityFrameworkCore;
using ProgLib.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgLib.Core.Abstractions
{
    public interface IUsersRepository
    {
        Task Create(User user);

        Task<User> GetByEmail(string email);
    }
}
