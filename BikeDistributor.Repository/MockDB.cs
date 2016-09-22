using System.Collections.Generic;

namespace BikeDistributor.Data
{
	// Pretend these values are loaded from the DB
	public static class MockDb
	{
		private const decimal OneThousand = 1000M;
		private const decimal TwoThousand = 2000M;
		private const decimal FiveThousand = 5000M;

		public static readonly List<LineDiscountRecordSet> DiscountsLoadedFromDb
			= new List<LineDiscountRecordSet>
			  {
				  new LineDiscountRecordSet("PricePointQuantity", "Percentage", OneThousand, 20, .9M),
				  new LineDiscountRecordSet("PricePointQuantity", "Percentage", TwoThousand, 10, .8M),
				  new LineDiscountRecordSet("PricePointQuantity", "Percentage", FiveThousand, 5, .8M),
			  };

		public static readonly List<BikeRecordSet> AvailableBikesFromDb
			= new List<BikeRecordSet>
			  {
				  new BikeRecordSet("Giant", "Defy 1", OneThousand),
				  new BikeRecordSet("Specialized", "Venge Elite", TwoThousand),
				  new BikeRecordSet("Specialized", "S-Works Venge Dura-Ace", FiveThousand),
			  };

		public static readonly List<CompanyRecordset> AvailableCompaniesFromDb
			= new List<CompanyRecordset>
			  {
				  new CompanyRecordset("Anywhere Bike Shop", .0725M)
			  };
	}
}