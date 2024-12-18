using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services
{
	public interface IDiscountService
	{
		Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponasync();
		Task CreateDiscountCouponasync(CreateDiscountCouponDto createCouponDto);
		Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateCouponDto);
		Task DeleteDiscountCouponAsync(int id);
		Task<GetByIdDiscountCouponDto> GetByIdDiscountCouponAsync(int id);
	}
}
