
using SkinetCore.Entities;

namespace SkinetCore.Interfaces
{
    public interface IBasketRepository
    {
        Task<CustomerBasket> GetBasket(string basketId);
        Task<CustomerBasket> UpdateBasket(CustomerBasket basket);
        Task<bool> DeleteBasket(string baskedId);
    }
}
