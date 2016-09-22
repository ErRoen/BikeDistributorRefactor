namespace BikeDistributor.Library.Items
{
	public class Bike : IItem
	{
		public string Brand { get; private set; }
		public string Model { get; private set; }
		public decimal Price { get; private set; }

		public Bike(string brand, string model, decimal price)
		{
			Brand = brand;
			Model = model;
			Price = price;
		}
	}
}