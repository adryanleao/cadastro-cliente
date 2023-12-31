﻿namespace Cliente.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    Task<bool> Commit();
}
