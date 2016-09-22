using System;

namespace BikeDistributor.Library.Orders.Discount
{
	public interface ILineDiscount
	{
		Predicate<Line> IsApplicable { get; set; }
		Func<Line, decimal> Operation { get; set; }
	}

	public class LineDiscount : ILineDiscount
	{
		public Predicate<Line> IsApplicable { get; set; }
		public Func<Line, decimal> Operation { get; set; }
	}
}