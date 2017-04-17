using System;

namespace FreshLab.MJ2C.Services.Contracts.Repositories
{
    public interface IRepository<T>
    {
        T GetById(Guid id);

        void Update(T item);

        void Save(T item);
    }
}
