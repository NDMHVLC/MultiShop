using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Queries.OrderDateilQueries
{
	public class GetOrderDateilByIdQuery
	{
		public int Id { get; set; }

		public GetOrderDateilByIdQuery(int id)
		{
			Id = id;
		}
	}
}
