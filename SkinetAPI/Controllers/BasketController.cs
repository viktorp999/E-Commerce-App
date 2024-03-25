using Microsoft.AspNetCore.Mvc;
using SkinetCore.Entities;
using SkinetCore.Interfaces;

namespace SkinetAPI.Controllers
{
    public class BasketController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public BasketController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<CustomerBasket>> GetBasketById(string id)
        {
            var basket = await _unitOfWork.BasketRepository.GetBasket(id);

            return Ok(basket ?? new CustomerBasket(id));
        }

        [HttpPost]
        public async Task<ActionResult<CustomerBasket>> UpdateBasket(CustomerBasket basket)
        {
            var updatedBasket = await _unitOfWork.BasketRepository.UpdateBasket(basket);

            return Ok(updatedBasket);
        }

        [HttpDelete]
        public async Task DeleteBasket(string id)
        {
            await _unitOfWork.BasketRepository.DeleteBasket(id);
        }
    }
}
