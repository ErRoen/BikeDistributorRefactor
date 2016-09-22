using System;
using System.Text;
using BikeDistributor.Library.Orders;

namespace BikeDistributor.Printers
{
	public class TextReceiptPrinter : IReceiptPrinter
	{
		public string PrintReceipt(Order order)
		{
			var result = new StringBuilder(string.Format("Order Receipt for {0}{1}", order.Company.Name, Environment.NewLine));
			foreach (var line in order.GetLines())
			{
				result.AppendLine(string.Format("\t{0} x {1} {2} = {3}", line.Quantity, line.Item.Brand, line.Item.Model, line.Amount.ToString("C")));
			}
			result.AppendLine(string.Format("Sub-Total: {0}", order.Subtotal.ToString("C")));
			result.AppendLine(string.Format("Tax: {0}", order.Tax.ToString("C")));
			result.Append(string.Format("Total: {0}", order.Total.ToString("C")));

			return result.ToString();
		}
	}
}