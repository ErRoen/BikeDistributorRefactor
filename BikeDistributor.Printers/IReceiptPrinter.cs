using BikeDistributor.Library.Orders;

namespace BikeDistributor.Printers
{
	public interface IReceiptPrinter
	{
		string PrintReceipt(Order order);
	}
}