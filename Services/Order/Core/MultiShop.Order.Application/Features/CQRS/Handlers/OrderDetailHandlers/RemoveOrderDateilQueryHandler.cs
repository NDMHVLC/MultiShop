using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
	public class RemoveOrderDateilQueryHandler
	{
		private readonly IRepository<OrderDetail> _repository;

		public RemoveOrderDateilQueryHandler(IRepository<OrderDetail> repository)
		{
			_repository = repository;
		}

		public async Task Handle(RemoveOrderDetailCommand command)
		{
			var value = await _repository.GetByIdAsync(command.Id);
			await _repository.DeleteAsync(value);
		}

	
	}
}
