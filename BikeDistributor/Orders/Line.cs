using BikeDistributor.Library.Items;

namespace BikeDistributor.Library.Orders
{
	public class Line
	{
		public IItem Item { get; set; }
		public int Quantity { get; set; }
		public decimal Amount { get; set; }

		public Line(IItem item, int quantity)
		{
			Item = item;
			Quantity = quantity;
			Amount = Quantity * Item.Price;
		}
	}
}