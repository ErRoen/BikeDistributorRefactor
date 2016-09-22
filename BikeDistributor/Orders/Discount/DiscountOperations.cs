using System;
using System.Collections.Generic;
using BikeDistributor.Data;

namespace BikeDistributor.Library.Orders.Discount
{
	public class DiscountOperations
	{
		public static Dictionary<string, Func<Line, LineDiscountRecordSet, decimal>> LineDiscountOperations
		{
			get
			{
				return new Dictionary<string, Func<Line, LineDiscountRecordSet, decimal>>
				       {
					       {"Straight", StraightDiscountOperation()},
					       {"Percentage", PercentageDiscountOperation()}
					       // Add future Operations logic here.
				       };
			}
		}

		private static Func<Line, LineDiscountRecordSet, decimal> PercentageDiscountOperation()
		{
			return (l, d) => l.Amount * d.DiscountAmount;
		}

		private static Func<Line, LineDiscountRecordSet, decimal> StraightDiscountOperation()
		{
			return (l, d) => l.Amount - d.DiscountAmount;
		}
	}
}