using BikeDistributor.Library;
using BikeDistributor.Library.Orders;
using BikeDistributor.Library.Orders.Discount;
using BikeDistributor.Printers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TempClassLibrary;

namespace BikeDistributor.Test
{
	[TestClass]
	public abstract class ReceiptPrinterTests
	{
		protected void RunTest(Line line, string resultStatement)
		{
			var order = new Order(Repository.LoadCompany(), GetDiscountArbiter());
			order.AddLine(line);
			var actualReceipt = GetReceiptPrinter().PrintReceipt(order);
			Assert.AreEqual(resultStatement, actualReceipt);
		}

		protected abstract IReceiptPrinter GetReceiptPrinter();

		protected static Line GetDefyLine()
		{
			return new Line(Repository.LoadDefy(), 1);
		}

		protected static Line GetEliteLine()
		{
			return new Line(Repository.LoadElite(), 1);
		}

		protected static Line GetDuraAceLine()
		{
			return new Line(Repository.LoadDuraAce(), 1);
		}

		protected static Line GetDuraAceLine5()
		{
			return new Line(Repository.LoadDuraAce(), 5);
		}

		protected DiscountArbiter GetDiscountArbiter()
		{
			return Repository.LoadDiscountArbiter();
		}


		[TestClass]
		public class TextReceiptPrinterTests : ReceiptPrinterTests
		{
			protected override IReceiptPrinter GetReceiptPrinter()
			{
				return new TextReceiptPrinter();
			}

			[TestMethod]
			public void ReceiptOneDefy()
			{
				RunTest(
					GetDefyLine(),
					@"Order Receipt for Anywhere Bike Shop
	1 x Giant Defy 1 = $1,000.00
Sub-Total: $1,000.00
Tax: $72.50
Total: $1,072.50");
			}

			[TestMethod]
			public void ReceiptOneElite()
			{
				RunTest(
					GetEliteLine(),
					@"Order Receipt for Anywhere Bike Shop
	1 x Specialized Venge Elite = $2,000.00
Sub-Total: $2,000.00
Tax: $145.00
Total: $2,145.00");
			}

			[TestMethod]
			public void ReceiptOneDuraAce()
			{
				RunTest(
					GetDuraAceLine(),
					@"Order Receipt for Anywhere Bike Shop
	1 x Specialized S-Works Venge Dura-Ace = $5,000.00
Sub-Total: $5,000.00
Tax: $362.50
Total: $5,362.50");
			}
		}

		[TestClass]
		public class HtmlReceiptPrinterTests : ReceiptPrinterTests
		{
			protected override IReceiptPrinter GetReceiptPrinter()
			{
				return new HtmlReceiptPrinter();
			}

			[TestMethod]
			public void HtmlReceiptOneDefy()
			{
				RunTest(
					GetDefyLine(),
					@"<html><body><h1>Order Receipt for Anywhere Bike Shop</h1><ul><li>1 x Giant Defy 1 = $1,000.00</li></ul><h3>Sub-Total: $1,000.00</h3><h3>Tax: $72.50</h3><h2>Total: $1,072.50</h2></body></html>");
			}

			[TestMethod]
			public void HtmlReceiptOneElite()
			{
				RunTest(
					GetEliteLine(),
					@"<html><body><h1>Order Receipt for Anywhere Bike Shop</h1><ul><li>1 x Specialized Venge Elite = $2,000.00</li></ul><h3>Sub-Total: $2,000.00</h3><h3>Tax: $145.00</h3><h2>Total: $2,145.00</h2></body></html>");
			}

			[TestMethod]
			public void HtmlReceiptOneDuraAce()
			{
				RunTest(
					GetDuraAceLine(),
					@"<html><body><h1>Order Receipt for Anywhere Bike Shop</h1><ul><li>1 x Specialized S-Works Venge Dura-Ace = $5,000.00</li></ul><h3>Sub-Total: $5,000.00</h3><h3>Tax: $362.50</h3><h2>Total: $5,362.50</h2></body></html>");
			}

			[TestMethod]
			public void HtmlReceiptOneDuraAce5()
			{
				RunTest(
					GetDuraAceLine5(),
					@"<html><body><h1>Order Receipt for Anywhere Bike Shop</h1><ul><li>5 x Specialized S-Works Venge Dura-Ace = $20,000.00</li></ul><h3>Sub-Total: $20,000.00</h3><h3>Tax: $1,450.00</h3><h2>Total: $21,450.00</h2></body></html>");
			}
		}
	}
}