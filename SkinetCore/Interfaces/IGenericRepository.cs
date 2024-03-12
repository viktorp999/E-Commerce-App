using SkinetCore.Entities;
using SkinetCore.Specifications;

namespace SkinetCore.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetById(int id);
        Task<IReadOnlyList<T>> ListAll();
        Task<T> GetEntityWithSpec(ISpecification<T> spec);
        Task<IReadOnlyList<T>> List(ISpecification<T> spec);
        Task<int> Count(ISpecification<T> spec);
    }
}
