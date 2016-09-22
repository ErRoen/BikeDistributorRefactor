using System;
using System.Collections.Generic;
using BikeDistributor.Data;

namespace BikeDistributor.Library.Orders.Discount
{
	public static class DiscountApplications
	{
		public static Dictionary<string, Func<Line, LineDiscountRecordSet, bool>> LineDiscountApplications
		{
			get
			{
				return new Dictionary<string, Func<Line, LineDiscountRecordSet, bool>>
				       {
					       {"PricePointQuantity", PricePointQuantityApplication()}
					       // Add future IsApplicable logic here.
				       };
			}
		}

		private static Func<Line, LineDiscountRecordSet, bool> PricePointQuantityApplication()
		{
			return (l, d) => l.Item.Price == d.PricePoint && l.Quantity >= d.Quantity;
		}
	}
}