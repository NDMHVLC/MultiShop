using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCustomerDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class CargoCustomersController : ControllerBase
	{
		private readonly ICargoCustomerService _cargoCustomerService;

		public CargoCustomersController(ICargoCustomerService cargoCustomerService)
		{
			_cargoCustomerService = cargoCustomerService;
		}

		[HttpGet]
		public IActionResult CargoCustomerList()
		{
			var values = _cargoCustomerService.TGetAll();
			return Ok(values);
		}
		[HttpGet("{id}")]
		public IActionResult CargoCustomerGetById(int id)
		{
			var value = _cargoCustomerService.TGetById(id);
			return Ok(value);
		}
		[HttpPost]
		public IActionResult CreateCargoCustomer(CreateCargoCustomerDto createCargoCustomerDto)
		{
			CargoCustomer cargoCustomer = new CargoCustomer();
			cargoCustomer.Address = createCargoCustomerDto.Address;
			cargoCustomer.Phone = createCargoCustomerDto.Phone;
			cargoCustomer.Surname = createCargoCustomerDto.Surname;
			cargoCustomer.Name = createCargoCustomerDto.Name;
			cargoCustomer.City = createCargoCustomerDto.City;
			cargoCustomer.District = createCargoCustomerDto.District;
			cargoCustomer.Email = createCargoCustomerDto.Email;
			_cargoCustomerService.TInsert(cargoCustomer);
			return Ok("Kargo Müşteri Ekleme İşlemi Başarıyla Yapıldı");
		}
		[HttpPut]
		public IActionResult UpdateCargoCustomer(UpdateCargoCustomerDto updateCargoCustomerDto)
		{
			CargoCustomer cargoCustomer = new CargoCustomer()
			{
				Address = updateCargoCustomerDto.Address,
				Phone = updateCargoCustomerDto.Phone,
				Surname = updateCargoCustomerDto.Surname,
				Name = updateCargoCustomerDto.Name,
				City = updateCargoCustomerDto.City,
				District = updateCargoCustomerDto.District,
				Email = updateCargoCustomerDto.Email,
				CargoCustomerId = updateCargoCustomerDto.CargoCustomerId
			};
			_cargoCustomerService.TUpdate(cargoCustomer);
			return Ok("Kargo Müşteri Güncelleme İşlemi Başarıyla Yapıldı");
		}
		[HttpDelete]
		public IActionResult DeleteCargoCustomer(int id)
		{
			_cargoCustomerService.TDelete(id);
			return Ok("Kargo Müşteri Silme İşlemi Başarıyla Yapıldı");
		}

	}
}
