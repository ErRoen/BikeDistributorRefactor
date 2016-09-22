using System.Collections.Generic;
using System.Linq;

namespace BikeDistributor.Library.Orders.Discount
{
	public class DiscountArbiter
	{
		private readonly IEnumerable<ILineDiscount> _discounts;

		public DiscountArbiter(IEnumerable<ILineDiscount> discounts)
		{
			_discounts = discounts;
		}

		// Perhaps by ref...
		public decimal Arbitrate(Line line)
		{
			// Could fairly easily implement DB a sort order so certain discounts are applied before others, 
			//	(ex: straight then percentage vs percentage then straight) based on biz reqs
			foreach (var discount in _discounts.Where(d => d.IsApplicable(line)))
			{
				line.Amount = discount.Operation(line);
			}
			return line.Amount;
		}
	}
}