using System;
using System.Collections.Generic;
using System.Text;

namespace ProgLib.Core.Abstractions
{
    public interface IPasswordHasher
    {
        string Generate(string password);

        bool Verify(string password, string hashedPassword);
    }
}
