namespace BikeDistributor.Data
{
	public class BikeRecordSet
	{
		public string Brand { get; set; }
		public string Model { get; set; }
		public decimal Price { get; set; }

		public BikeRecordSet(string brand, string model, decimal price)
		{
			Brand = brand;
			Model = model;
			Price = price;
		}
	}

	public class CompanyRecordset
	{
		public string Name { get; set; }
		public decimal TaxRate { get; set; }

		public CompanyRecordset(string name, decimal taxRate)
		{
			Name = name;
			TaxRate = taxRate;
		}
	}

	/// <summary>
	/// Represents a DB record
	/// </summary>
	public class LineDiscountRecordSet
	{
		public string LineDiscountApplicationType { get; set; }
		public string LineDiscountOperationType { get; set; }
		public decimal PricePoint { get; set; }
		public int Quantity { get; set; }
		public decimal DiscountAmount { get; set; }
		// future discount decision inputs
		//  ex: SortOrder

		public LineDiscountRecordSet(string lineDiscountApplicationType, string lineDiscountOperationType, decimal pricePoint, int quantity, decimal discountAmount)
		{
			LineDiscountApplicationType = lineDiscountApplicationType;
			LineDiscountOperationType = lineDiscountOperationType;
			PricePoint = pricePoint;
			Quantity = quantity;
			DiscountAmount = discountAmount;
		}
	}
}