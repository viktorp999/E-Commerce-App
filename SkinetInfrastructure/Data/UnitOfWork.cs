using SkinetCore.Entities;
using SkinetCore.Interfaces;
using StackExchange.Redis;
using System.Collections;

namespace SkinetInfrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IConnectionMultiplexer _multiplexer;
        private readonly StoreContext _context;
        private Hashtable _repositories;

        public UnitOfWork(StoreContext context, IConnectionMultiplexer multiplexer)
        {
            _multiplexer = multiplexer;
            _context = context;
            BasketRepository = new BasketRepository(_multiplexer);
        }

        public IBasketRepository BasketRepository { get; private set; }
        public IGenericRepository<T> Repository<T>() where T : BaseEntity
        {
            if (_repositories == null)
            {
                _repositories = new Hashtable();
            }

            var type = typeof(T).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<>);

                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _context);

                _repositories.Add(type, repositoryInstance);
            }

            return (IGenericRepository<T>)_repositories[type];
        }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
