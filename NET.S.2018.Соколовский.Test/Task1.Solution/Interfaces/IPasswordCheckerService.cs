using System;
using System.Collections.Generic;

namespace Task1.Solution.Interfaces
{
    public interface IPasswordCheckerService
    {
        List<Tuple<bool, string>> VerifyPassword(string password);
    }
}