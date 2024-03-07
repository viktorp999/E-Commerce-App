using SkinetCore.Entities;

namespace SkinetCore.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<T> Repository<T>() where T : BaseEntity;
        Task<int> Save();
    }
}
