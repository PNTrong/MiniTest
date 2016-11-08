using Data;
using System;

namespace Training.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        SDCTestDbContext Init();
    }
}