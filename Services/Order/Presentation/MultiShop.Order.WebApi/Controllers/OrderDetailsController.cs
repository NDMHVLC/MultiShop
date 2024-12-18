using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using MultiShop.Order.Application.Features.CQRS.Queries.OrderDateilQueries;

namespace MultiShop.Order.WebApi.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class OrderDetailsController : ControllerBase
	{
		private readonly GetOrderDetailByIdQueryHandler _getOrderDetailByIdQueryHandler;
		private readonly GetOrderDetailQueryHandler _getOrderDetailQueryHandler;
		private readonly CreateOrderDetailCommandHandler _createOrderDetailCommandHandler;
		private readonly UpdateOrderDetailQueryHandler _updateOrderDetailQueryHandler;
		private readonly RemoveOrderDateilQueryHandler _removeOrderDateilQueryHandler;

		public OrderDetailsController(GetOrderDetailByIdQueryHandler getOrderDetailByIdQueryHandler, GetOrderDetailQueryHandler getOrderDetailQueryHandler, CreateOrderDetailCommandHandler createOrderDetailCommandHandler, UpdateOrderDetailQueryHandler updateOrderDetailQueryHandler, RemoveOrderDateilQueryHandler removeOrderDateilQueryHandler)
		{
			_getOrderDetailByIdQueryHandler = getOrderDetailByIdQueryHandler;
			_getOrderDetailQueryHandler = getOrderDetailQueryHandler;
			_createOrderDetailCommandHandler = createOrderDetailCommandHandler;
			_updateOrderDetailQueryHandler = updateOrderDetailQueryHandler;
			_removeOrderDateilQueryHandler = removeOrderDateilQueryHandler;
		}

		[HttpGet]
		public async Task<IActionResult> OrderDetailList()
		{
			var values = await _getOrderDetailQueryHandler.Handle();
			return Ok(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetOrderDetailById(int id)
		{
			var value = await _getOrderDetailByIdQueryHandler.Handle(new GetOrderDateilByIdQuery(id));
			return Ok(value);
		}

		[HttpPost]
		public async Task<IActionResult> CreateOrderDetail(CreateOrderDetailCommand command)
		{
			await _createOrderDetailCommandHandler.Handle(command);
			return Ok("Sipariş detayı başarıyla yüklendi");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateOrderDetail(UpdateOrderDetailCommand command)
		{
			await _updateOrderDetailQueryHandler.Handle(command);
			return Ok("Sipariş detayı başarıyla güncellendi");
		}

		[HttpDelete]
		public async Task<IActionResult> RemoveOrderDetail(int id)
		{
			await _removeOrderDateilQueryHandler.Handle(new RemoveOrderDetailCommand(id));
			return Ok("Sipariş detayı başarıyla silindi");
		}
	}
}
