using System.Linq;
using BikeDistributor.Data;
using BikeDistributor.Library.Items;
using BikeDistributor.Library.Orders.Discount;

namespace BikeDistributor.Library
{
	public static class Repository
	{
		public static DiscountArbiter LoadDiscountArbiter()
		{
			return new DiscountArbiter(
				MockDb.DiscountsLoadedFromDb.Select(d =>
					new LineDiscount()
					{
						IsApplicable = l => DiscountApplications.LineDiscountApplications[d.LineDiscountApplicationType](l, d),
						Operation = l => DiscountOperations.LineDiscountOperations[d.LineDiscountOperationType](l, d)
					}));
		}

		public static Company LoadCompany()
		{
			return CreateCompany(MockDb.AvailableCompaniesFromDb[0]);
		}

		private static Company CreateCompany(CompanyRecordset companyRecordset)
		{
			return new Company(companyRecordset.Name, companyRecordset.TaxRate);
		}

		public static Bike LoadDefy()
		{
			return CreateBike(MockDb.AvailableBikesFromDb[0]);
		}

		public static Bike LoadElite()
		{
			return CreateBike(MockDb.AvailableBikesFromDb[1]);
		}

		public static Bike LoadDuraAce()
		{
			return CreateBike(MockDb.AvailableBikesFromDb[2]);
		}

		private static Bike CreateBike(BikeRecordSet bikeRecordSet)
		{
			return new Bike(bikeRecordSet.Brand, bikeRecordSet.Model, bikeRecordSet.Price);
		}
	}
}
