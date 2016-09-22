using BikeDistributor.Library.Orders;

namespace TempClassLibrary
{
	public interface ITextTemplate
	{
		string TransformText();
	}

	public partial class TextRuntimeTemplate : ITextTemplate
	{
		private readonly Order _order;

		public TextRuntimeTemplate(Order order)
		{
			_order = order;
		}
	}

	public partial class HtmlRuntimeTemplate : ITextTemplate
	{
		private readonly Order _order;

		public HtmlRuntimeTemplate(Order order)
		{
			_order = order;
		}
	}
}