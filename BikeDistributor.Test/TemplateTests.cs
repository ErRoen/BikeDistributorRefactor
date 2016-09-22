using BikeDistributor.Library;
using BikeDistributor.Library.Orders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TempClassLibrary;

namespace BikeDistributor.Test
{
	[TestClass]
	public abstract class TemplateTests
	{
		protected void RunTest(Line line, string resultStatement)
		{
			var order = new Order(
				Repository.LoadCompany(),
				Repository.LoadDiscountArbiter());
			order.AddLine(line);

			var actualReceipt = GetTemplate(order).TransformText();

			Assert.AreEqual(resultStatement, actualReceipt);
		}

		protected abstract ITextTemplate GetTemplate(Order order);

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


		[TestClass]
		public class TextTemplateTests : TemplateTests
		{
			protected override ITextTemplate GetTemplate(Order order)
			{
				return new TextRuntimeTemplate(order);
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
		public class HtmlTemplateTests : TemplateTests
		{
			protected override ITextTemplate GetTemplate(Order order)
			{
				return new HtmlRuntimeTemplate(order);
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