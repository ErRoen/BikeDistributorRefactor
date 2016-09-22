using System.Linq;
using System.Text;
using BikeDistributor.Library.Orders;

namespace BikeDistributor.Printers
{
	public class HtmlReceiptPrinter : IReceiptPrinter
	{
		public string PrintReceipt(Order order)
		{
			var result = new StringBuilder(string.Format("<html><body><h1>Order Receipt for {0}</h1>", order.Company.Name));
			var lines = order.GetLines().ToArray();
			if (lines.Any())
			{
				result.Append("<ul>");
				foreach (var line in lines)
				{
					result.AppendFormat("<li>{0} x {1} {2} = {3}</li>", line.Quantity, line.Item.Brand, line.Item.Model, line.Amount.ToString("C"));
				}
				result.Append("</ul>");
			}
			result.AppendFormat("<h3>Sub-Total: {0}</h3>", order.Subtotal.ToString("C"));
			result.AppendFormat("<h3>Tax: {0}</h3>", order.Tax.ToString("C"));
			result.AppendFormat("<h2>Total: {0}</h2>", order.Total.ToString("C"));
			result.Append("</body></html>");

			return result.ToString();
		}
	}
}