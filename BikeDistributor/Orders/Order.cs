using System.Collections.Generic;
using BikeDistributor.Library.Orders.Discount;

namespace BikeDistributor.Library.Orders
{
	public class Order
	{
		private readonly List<Line> _lines;
		private readonly DiscountArbiter _discountArbiter;

		public Company Company { get; set; }
		public decimal Subtotal { get; private set; }
		public decimal Tax { get; private set; }
		public decimal Total { get; private set; }

		public Order(Company company, DiscountArbiter discountArbiter)
		{
			Company = company;
			_lines = new List<Line>();
			_discountArbiter = discountArbiter;
			Subtotal = 0M;
		}

		public IEnumerable<Line> GetLines()
		{
			return _lines;
		}

		public void AddLine(Line line)
		{
			ApplyLineDiscounts(line);
			_lines.Add(line);
		}

		private void ApplyLineDiscounts(Line line)
		{
			var discountedAmount = _discountArbiter.Arbitrate(line);
			UpdateTotals(discountedAmount);
			line.Amount = discountedAmount;
		}

		private void UpdateTotals(decimal discountedAmount)
		{
			Subtotal += discountedAmount;
			Tax = Subtotal*Company.TaxRate;
			Total = Subtotal + Tax;
		}
	}
}
