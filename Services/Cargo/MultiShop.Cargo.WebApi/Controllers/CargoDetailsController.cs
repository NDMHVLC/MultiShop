using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoDetailDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class CargoDetailsController : ControllerBase
	{
		private readonly ICargoDetailService _cargoDetailService;

		public CargoDetailsController(ICargoDetailService cargoDetailService)
		{
			_cargoDetailService = cargoDetailService;
		}

		[HttpGet]
		public IActionResult CargoDetailGetAll()
		{
			var values = _cargoDetailService.TGetAll();
			return Ok(values);
		}
		[HttpGet("{id}")]
		public IActionResult CargoDetailGetById(int id)
		{
			var value = _cargoDetailService.TGetById(id);
			return Ok(value);	
		}
		[HttpPost]
		public IActionResult CreateCargoDetail(CreateCargoDetailDto cargoDetailDto)
		{
			CargoDetail cargoDetail = new CargoDetail()
			{
				Barcode = cargoDetailDto.Barcode,
				CargoCompanyId = cargoDetailDto.CargoCompanyId,
				ReceiverCustomer = cargoDetailDto.ReceiverCustomer,
				SenderCustomer = cargoDetailDto.SenderCustomer
			};
			_cargoDetailService.TInsert(cargoDetail);
			return Ok("Kargo Detayları Başarıyla Oluşturuldu");
		}
		[HttpPut]
		public IActionResult UpdateCargoDetail(UpdateCargoDetailDto vehicleDetailDto)
		{
			CargoDetail cargoDetail = new CargoDetail()
			{
				CargoDetailId = vehicleDetailDto.CargoDetailId,
				Barcode = vehicleDetailDto.Barcode,
				ReceiverCustomer = vehicleDetailDto.ReceiverCustomer,
				CargoCompanyId= vehicleDetailDto.CargoCompanyId,
				SenderCustomer= vehicleDetailDto.SenderCustomer
			};
			_cargoDetailService.TUpdate(cargoDetail);
			return Ok("Kargo Detayları Başarıyla Güncellendi");
		}
		[HttpDelete]
		public IActionResult DeleteCargoDetail(int id)
		{
			_cargoDetailService.TDelete(id);
			return Ok("Kargo Detayları Başarıyla Silindi");
		}
	}
}
