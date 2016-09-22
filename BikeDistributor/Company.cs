namespace BikeDistributor.Library
{
	public class Company
	{
		public string Name { get; private set; }
		public decimal TaxRate { get; private set; }

		public Company(string name, decimal taxRate)
		{
			Name = name;
			TaxRate = taxRate;
		}
	}
}